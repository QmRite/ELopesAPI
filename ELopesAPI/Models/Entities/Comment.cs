using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELopesAPI.Models.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }

        public int? NewsPostId { get; set; }

        [ForeignKey("NewsPostId")]
        public NewsPost? NewsPost { get; set; }

        public int? PostId { get; set; }

        [ForeignKey("PostId")]
        public Post? Post { get; set; }
    }
}
