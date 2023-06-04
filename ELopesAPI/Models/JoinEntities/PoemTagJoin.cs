using ELopesAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELopesAPI.Models.JoinEntities
{
    public class PoemTagJoin
    {
        public int PoemId { get; set; }
        [ForeignKey("PoemId")]
        public Poem Poem { get; set; }

        public int PoemTagId { get; set; }
        [ForeignKey("PoemTagId")]
        public PoemTag PoemTag { get; set; }
    }
}
