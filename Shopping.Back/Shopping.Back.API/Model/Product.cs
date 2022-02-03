using Shopping.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Model
{
    [Table("tb_products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
