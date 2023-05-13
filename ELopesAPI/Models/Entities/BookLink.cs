using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.Entities
{
    public class BookLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Link { get; set; }

        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
