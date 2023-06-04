using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public bool IsApproved { get; set; }


        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        [JsonIgnore]
        public Comment? Parent { get; set; }

        public int? BlogPostId { get; set; }

        [ForeignKey("NewsPostId")]
        [JsonIgnore]
        public BlogPost? BlogPost { get; set; }

        public int? NewsPostId { get; set; }

        [ForeignKey("PostId")]
        [JsonIgnore]
        public NewsPost? NewsPost { get; set; }

        public override string ToString()
        {
            return $"{Username}: {Content}";
        }
    }
}
