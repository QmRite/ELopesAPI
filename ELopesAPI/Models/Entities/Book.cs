using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ELopesAPI.Models.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)] 
        public string Title { get; set; }

        public byte[] Cover { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public bool IsForChildren { get; set; }

        public ICollection<BookLink>? BookLinks { get; set; }

        public BookReview? BookReview { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
