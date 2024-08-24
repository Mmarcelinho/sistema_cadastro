using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Application.Shared.Results;
using SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPF;
using SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPJ;

namespace SistemaCadastro.API.Controllers;

public class CadastroController(IMediator _mediator) : SistemaCadastroController
{
    [HttpPost]
    public async Task<IActionResult> RegistrarPessoaFisica([FromBody] RegistrarPFCommand command)
    {
        var result = (Result)await _mediator.Send(command);

        if (!result.IsOk)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarPessoaJuridica([FromBody] RegistrarPJCommand command)
    {
        var result = (Result)await _mediator.Send(command);

        if (!result.IsOk)
            return BadRequest(result);

        return Ok(result);
    }
}