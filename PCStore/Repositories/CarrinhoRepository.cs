using Microsoft.EntityFrameworkCore;
using PCStore.Models;
using PCStore.Models.ViewModels;
using System.Linq;
using Npgsql;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.Json;
using PCStore.Config;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PCStore.Repositories
{
    // Interfaco do Repositório do carrinho
    public interface ICarrinhoRepository
    {
        Task<List<ProdutoCarrinho>> List(Carrinho carrinho);
        Task<bool> AddItem(Carrinho carrinho);
    }

    public class CarrinhoRepository : ICarrinhoRepository
    {
        //Função que retorna todos os itens no carrinho de um determinado usuário
        public async Task<List<ProdutoCarrinho>> List(Carrinho carrinho)
        {
            //Lista de produtos
            var _produtos = new List<ProdutoCarrinho>();

            using (var connection = new NpgsqlConnection(GlobalSettings.DBPath))
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
                    cmd.Parameters.AddWithValue("Id", carrinho.userId); //Parametro do id de usuario no select

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
        public async Task<bool> AddItem(Carrinho carrinho){
            using (var connection = new NpgsqlConnection(GlobalSettings.DBPath))
            {
                //Conectando no banco de dados
                connection.Open();

                //Insert para inserir a nova instância no banco de dados
                var _sql = "INSERT INTO Carrinho ";
                _sql = _sql + "(idProd, idUser, prodQtd) ";
                _sql = _sql + "VALUES ";
                _sql = _sql + "(@prodId, @userId, @prodQtd) ";

                using (var cmd = new NpgsqlCommand(_sql, connection))
                {
                    cmd.Parameters.AddWithValue("prodId", carrinho.prodId); //Parametro do id de produto no insert
                    cmd.Parameters.AddWithValue("userId", carrinho.userId); //Parametro do id de usuário no insert
                    cmd.Parameters.AddWithValue("prodQtd", carrinho.prodQtd); //Parametro de quantidade de produtos no insert

                    int rowsAffected = await cmd.ExecuteNonQueryAsync(); //Executa o insert

                    return rowsAffected > 0; // Retorna verdadeiro se pelo menos uma linha foi afetada (sucesso)
                }
            }
        }
    }
}