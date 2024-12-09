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
    //Seta a rota usuario
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        //Seta um post para a rota login
        [HttpPost]
        [Route("login")]

        //Função de login
        public async Task<IActionResult> Login([FromBody]UsuarioLogin model, [FromServices]IUsuarioRepository repository)
        {
            //Testa o json enviado se é valido comparando com o modelo de UsuarioLogin
            if(!ModelState.IsValid){
                return BadRequest();
            }

            //Chama o repositório para fazer o teste de login
            Usuario usuario = await repository.Login(model.Email, model.Senha);

            //Se nulo, não autoriza o login
            if (usuario == null){
                return Unauthorized();
            }

            //Se válido retorna as informações completas do usuário com o token de login
            return Ok(new {
                usuario = usuario,
                token = GenerateToken(usuario)
            });
        }

        //Função para gerar token de login
        private string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("tokenExtremamaneteGigantescoParaONossoSiteDePCParaGerarUmaChave");

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}