using Microsoft.EntityFrameworkCore;
using PCStore.Models;
using PCStore.Models.ViewModels;
using System.Linq;
using Npgsql;
using PCStore.Config;

namespace PCStore.Repositories
{
    //Interface do Usuário
    public interface IUsuarioRepository 
    {
        Task<Usuario?> Login(string email, string senha);
        void Create(Usuario usuario);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            //Not implemented yet
        }

        //Função de Login de Usuário
        public async Task<Usuario?> Login(string useremail, string usersenha)
        {
            //Cria um novo objeto de UsuarioLogin
            UsuarioLogin _usuario = new UsuarioLogin {
                Email = useremail,
                Senha = usersenha
            };

            using (var connection = new NpgsqlConnection(GlobalSettings.DBPath))
            {
                connection.Open();

                // Select para buscar o usuário no banco de dados
                var sql = "SELECT iduser, usernome, email, usersenha FROM usuarios WHERE email = @Email AND usersenha = @Senha";

                //var sql = "";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    // Parametros para testar se ele está cadastrado
                    cmd.Parameters.AddWithValue("Email", _usuario.Email);
                    cmd.Parameters.AddWithValue("Senha", _usuario.Senha);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Usuario _login;
                        if (reader.Read()) 
                        {
                            //Cria um novo objeto para de Usuario para _login se o usuario estiver cadastrado e a senha estiver correta
                            _login = new Usuario {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Senha = reader.GetString(3)
                            };
                        }
                        else
                        {
                            //Retorna um valor nulo caso o usuário não for encontrado
                            _login = null;
                        }
                        return _login;
                    }
                }
            }            
        }
    }
}