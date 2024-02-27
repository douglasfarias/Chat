using Chat.Domain.Commands.Mensagens;
using Chat.Domain.Queries.Mensagens;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MensagensController : ControllerBase
{
    private readonly IMediator _mediator;

    public MensagensController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var mensagem = await _mediator.Send(new GetMensagemByIdQuery { Id = id });

        if(mensagem is null)
            return NotFound();

        return Ok(mensagem);
    }


    [HttpGet("conversa/{id}")]
    public async Task<IActionResult> GetByConverId(Guid id)
    {
        var mensagem = await _mediator.Send(new GetMensagensByConversaIdQuery { ConversaId = id });

        if(mensagem is null)
            return NotFound();

        return Ok(mensagem);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMensagemCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateMensagemCommand command)
    {
        if(id != command.Id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new RemoveMensagemCommand { Id = id });

        return NoContent();
    }
}
