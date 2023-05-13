using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ELopesAPI.Models.JoinEntities;

namespace ELopesAPI.Models.Entities
{
    public class NewsPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [DataType("Markdown")]
        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? Source { get; set; }

        public ICollection<Tag>? Tags { get; set; }

        public ICollection<NewsPostTag>? NewsPostsTags { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
