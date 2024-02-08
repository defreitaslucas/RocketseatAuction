using RocketseatAuction.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketseatAuction.API.Entity
{
    // table serve para referenciar o nome da tabela no banco de dados
    // caso o nome da tabela seja diferente do nome da classe
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Condition  Condition { get; set; }
        public decimal BasePrice { get; set; }
        public int AuctionId { get; set; }
    }
}
