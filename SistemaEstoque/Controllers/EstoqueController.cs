using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Model.ApplicationDbContext;
using SistemaEstoque.Model.Entidades;
using SistemaEstoque.Services;

namespace SistemaEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : Controller
    {
            private readonly ILogger<EstoqueController> _logger;
            private readonly Context context;
            private readonly ServiceEstoque serviceEstoque;
            public EstoqueController(Context context, ILogger<EstoqueController> logger)
            {
                this.context = context;
                this._logger = logger;
            }

        [HttpGet("ConsultarProduto/{id}")]
        public async Task<ActionResult> ConsultarProduto(int id)
        {
            try
            {
                var resultado = await serviceEstoque.GetConsultarProduto(id);
                return Ok(resultado);
            }
            catch (Exception x)
            {
                return BadRequest($"Erro: {x.Message}");
            }
        }

        [HttpPost("CadastrarFornecedor")]
        public async Task<ActionResult> CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var resultado = await serviceEstoque.PostCadastrarFornecedor(fornecedor);
                return Ok(resultado);
            }
            catch (Exception x)
            {
                return BadRequest($"Erro: {x.Message}");
            }
        }
        [HttpPost("CadastrarProduto")]
        public async Task<ActionResult> CadastrarProduto(AdicionarProduto produto)
        {
            try
            {
                var resultado = await serviceEstoque.PostCadastrarProduto(produto);
                return Ok(resultado);
            }
            catch (Exception x)
            {
                return BadRequest($"Erro: {x.Message}");
            }
        }
        [HttpPut("ResgistraEntrada")]
        public async Task<ActionResult> PutRegistrarEntrada(int id, int quantidade)
        {
            try
            {
                var resultado = await serviceEstoque.PutRegistrarEntrada(id, quantidade);
                return Ok(resultado);
            }
            catch (Exception x)
            {
                return BadRequest($"Erro: {x.Message}");
            }
        }
        [HttpPut("ResgistraSaida")]
        public async Task<ActionResult> PutRegistrarSaida(int id, int quantidade)
        {
            try
            {
                var resultado = await serviceEstoque.PutRegistrarSaida(id, quantidade);
                return Ok(resultado);
            }
            catch (Exception x)
            {
                return BadRequest($"Erro: {x.Message}");
            }
        }
    }
}

