using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELopesAPI.Models.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(400)]
        public string Content { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; }


        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Comment? Parent { get; set; }

        public int? BlogPostId { get; set; }

        [ForeignKey("NewsPostId")]
        public BlogPost? BlogPost { get; set; }

        public int? NewsPostId { get; set; }

        [ForeignKey("PostId")]
        public NewsPost? NewsPost { get; set; }

        public override string ToString()
        {
            return $"{Username}: {Content}";
        }
    }
}
