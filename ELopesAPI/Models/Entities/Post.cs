using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("Markdown")]
        public string Content { get; set; }

        public string Type { get; set; } = "Post";


        public ICollection<Comment>? Comments { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
