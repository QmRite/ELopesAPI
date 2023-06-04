using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(400)]
        public string Content { get; set; }


        public int? ParentId { get; set; }

        public int? BlogPostId { get; set; }

        public int? NewsPostId { get; set; }
    }
}
