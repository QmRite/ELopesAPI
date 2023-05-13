using ELopesAPI.Models.Entities;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.JoinEntities
{
    public class NewsPostTag
    {
        public int NewsPostId { get; set; }
        [ForeignKey("NewsPostId")]
        public NewsPost NewsPost { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
