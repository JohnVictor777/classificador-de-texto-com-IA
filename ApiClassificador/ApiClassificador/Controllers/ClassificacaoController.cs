using ApiClassificador.Models;
using ApiClassificador.Services;
using ApiClassificador.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiClassificador.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassificacaoController : ControllerBase
    {
        private readonly ClassificacaoService _service;
        private readonly ClassificacaoTextoDbContext _context;

        public ClassificacaoController(
            ClassificacaoService service,
            ClassificacaoTextoDbContext context)
        {
            _service = service;
            _context = context;
        }
        
        [HttpPost("classificar")]
        public async Task<ActionResult<ClassificacaoResultado>> Classificar([FromBody] ClassificacaoRequest request)
        {
            try
            {
                var resultado = _service.Classificar(request.Texto);
                _context.ClassificacaoDeResultados.Add(resultado);
                await _context.SaveChangesAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a classificação: {ex.Message}");
            }
        }

        public class ClassificacaoRequest
        {
            public string Texto { get; set; }
        }

    }
}
