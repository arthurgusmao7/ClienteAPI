
using Microsoft.AspNetCore.Mvc;
using ClienteApi.Services;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/conexao")]
    public class ConexaoController : ControllerBase
    {
        private readonly ConexaoBanco _conexaoBanco;

        public ConexaoController(ConexaoBanco conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        [HttpGet("testar")]
        public async Task<IActionResult> Testar()
        {
            try
            {
                int resultado = await _conexaoBanco.TestarConexao();

                return Ok(new
                {
                    mensagem = "Conexão com PostgreSQL realizada com sucesso!",
                    resultado = resultado
                });
            }
            catch
            {
                return StatusCode(500, new
                {
                    mensagem = "Não foi possível conectar ao banco de dados."
                });
            }
        }
    }
}
