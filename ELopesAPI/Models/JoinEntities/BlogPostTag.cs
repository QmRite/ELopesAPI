using ELopesAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.JoinEntities
{
    public class BlogPostTag
    {
        public int BlogPostId { get; set; }
        [ForeignKey("BlogPostId")]
        public BlogPost BlogPost { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
