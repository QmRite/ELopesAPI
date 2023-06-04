using ELopesAPI.Models.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.Entities
{
    public class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Cover { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [DataType("Markdown")]
        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;


        public ICollection<Comment>? Comments { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
