using Microsoft.EntityFrameworkCore;
using PCStore.Models;
using PCStore.Models.ViewModels;
using System.Linq;
using Npgsql;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.Json;

namespace PCStore.Repositories
{
    // Interfaco do Repositório do carrinho
    public interface IUserCarrinhoRepository
    {
        Task<List<ProdutoCarrinho>> List(Usuario usuario);
    }

    public class UserCarrinhoRepository : IUserCarrinhoRepository
    {
        //Função que retorna todos os itens no carrinho de um determinado usuário
        public async Task<List<ProdutoCarrinho>> List(Usuario usuario)
        {
            //Lista de produtos
            var _produtos = new List<ProdutoCarrinho>();

            //Caminho de conexão do banco de dados
            string _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Admin#123";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                //Conectando no banco de dados
                connection.Open();


                //Select para buscar os produtos do usuário
                var _sql = "SELECT c.idcarrinho, c.idprod, c.prodqtd, p.prodnome, p.prodprice, p.prodimg, p.proddesc ";
                _sql = _sql + "FROM carrinho c ";
                _sql = _sql + "INNER JOIN produtos p ON c.idprod = p.idprod ";
                _sql = _sql + "WHERE c.iduser = @Id";

                using (var cmd = new NpgsqlCommand(_sql, connection))
                {
                    cmd.Parameters.AddWithValue("Id", usuario.Id); //Parametro do id de usuario no select

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) //Leitura do banco de dados por linha
                        {
                            _produtos.Add(new ProdutoCarrinho //Adicionando cada produto a lista de produtos do usuário
                            {
                                Id = reader.GetInt32(0),
                                prodId = reader.GetInt32(1),
                                prodQtd = reader.GetInt32(2),
                                nome = reader.GetString(3),
                                price = reader.GetDouble(4),
                                img = reader.GetString(5),
                                desc = reader.GetString(6)
                            });
                        }
                    }
                    return _produtos;
                }
            }
        }
    }
}