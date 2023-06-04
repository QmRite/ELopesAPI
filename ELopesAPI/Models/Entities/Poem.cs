using ELopesAPI.Models.JoinEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ELopesAPI.Models.Entities
{
    public class Poem 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [DataType("Markdown")]
        public string Content { get; set; }


        public ICollection<PoemTag>? Tags { get; set; }

        [JsonIgnore]
        public ICollection<PoemTagJoin>? PoemTagJoins { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
