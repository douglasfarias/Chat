using Chat.Domain.Commands.Conversas;
using Chat.Domain.Querys.Conversas;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConversasController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConversasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var conversas = await _mediator.Send(new GetAllConversasQuery { });

        return Ok(conversas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var conversa = await _mediator.Send(new GetConversaByIdQuery { Id = id });

        if(conversa is null)
            return NotFound();

        return Ok(conversa);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateConversaCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateConversaCommand command)
    {
        if(id != command.Id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new RemoveConversaCommand { Id = id });

        return NoContent();
    }
}
