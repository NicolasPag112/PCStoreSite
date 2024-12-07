using System;

namespace PCStore.Models.ViewModels
{
    public class ProdutoCarrinho
    {
        public required int Id { get; set; }
        public required int prodId { get; set; }
        public required int prodQtd { get; set; }
        public required string nome  { get; set; }
        public required double price  { get; set; }
        public required string img { get; set; }
        public required string desc  { get; set; }
    }
}