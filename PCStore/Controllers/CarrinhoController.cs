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
        public async Task<IActionResult> AddItem([FromBody]Carrinho model, [FromServices]ICarrinhoRepository repository)
        {
            bool _success = await repository.AddItem(model);

            if (!_success) {
                return BadRequest();
            }

            return Ok();
        }

        //Seta um get para rota vazia
        [HttpGet]
        [Route("")]

        //Função para retornar os produtos no carrinho
        public async Task<IActionResult> GetCarrinho([FromBody]Carrinho model, [FromServices]ICarrinhoRepository repository)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            List<ProdutoCarrinho> _carrinho = await repository.List(model);

            if (!_carrinho.Any())
            {
                return BadRequest(_carrinho);
            }

            return Ok(_carrinho);
            
        }
    }
    
}