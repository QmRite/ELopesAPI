using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.Entities
{
    public class NewsPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("Markdown")]
        public string Content { get; set; }

        public string Type { get; set; } = "Main";


        public ICollection<Comment>? Comments { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
