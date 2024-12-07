using System;

namespace PCStore.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int prodId { get; set; }
        public int userId { get; set; }
        public int prodQtd { get; set; }
    }
}