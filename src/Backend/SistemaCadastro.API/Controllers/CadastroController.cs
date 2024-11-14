namespace SistemaCadastro.API.Controllers;

public class CadastroController(ISender sender) : SistemaCadastroController
{
    [HttpPost("pessoa-fisica")]
    [ProducesResponseType(typeof(CadastroPessoaFisicaResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarPessoaFisica([FromBody] RegistrarPFCommand command)
    {
        var result = (Result)await sender.Send(command);

        if (!result.IsOk)
            return BadRequest(result);

        return Created(string.Empty, result);
    }

    [HttpPost("pessoa-juridica")]
    [ProducesResponseType(typeof(CadastroPessoaJuridicaResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarPessoaJuridica([FromBody] RegistrarPJCommand command)
    {
        var result = (Result)await sender.Send(command);

        if (!result.IsOk)
            return BadRequest(result);

        return Created(string.Empty, result);
    }
}
