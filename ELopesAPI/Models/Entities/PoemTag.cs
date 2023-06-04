using ELopesAPI.Models.JoinEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ELopesAPI.Models.Entities
{
    public class PoemTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<Poem>? Poems { get; set; }

        [JsonIgnore]
        public ICollection<PoemTagJoin>? PoemTagJoin { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
