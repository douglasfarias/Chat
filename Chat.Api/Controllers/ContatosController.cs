using Chat.Domain.Commands.Contatos;
using Chat.Domain.Querys.Contatos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContatosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContatosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var contato = await _mediator.Send(new GetAllContatosQuery { });

        return Ok(contato);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var contato = await _mediator.Send(new GetContatoByIdQuery { Id = id });

        if(contato is null)
            return NotFound();

        return Ok(contato);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContatoCommand command)
    {
        var contato = await _mediator.Send(command);

        return Ok(contato);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateContatoCommand command)
    {
        if(id != command.Id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new RemoveContatoCommand { Id = id });

        return NoContent();
    }
}
