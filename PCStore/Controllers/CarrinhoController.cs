using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PCStore.Models;
using PCStore.Models.ViewModels;
using PCStore.Repositories;

namespace PCStore.Controllers
{
    [ApiController]
    [Route("Carrinho")] //Seta a rota para Carrinho

    public class CarrinhoController : ControllerBase
    {
        //Seta um post com rota vazia
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody]Usuario model, [FromServices] IUsuarioRepository repository)
        {
            //Not Implemented Yet
            return null;
        }

        //Seta um get para rota vazia
        [HttpGet]
        [Route("")]

        //Função para retornar os produtos no carrinho
        public async Task<IActionResult> GetCarrinho([FromBody]Usuario model, [FromServices]ICarrinhoRepository repository)
        {
            List<ProdutoCarrinho> _carrinho = await repository.List(model);

            return BadRequest();
        }
    }
    
}