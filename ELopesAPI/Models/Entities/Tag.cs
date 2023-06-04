﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ELopesAPI.Models.JoinEntities;
using Newtonsoft.Json;

namespace ELopesAPI.Models.Entities
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<NewsPost>? NewsPosts { get; set; }

        [JsonIgnore]
        public ICollection<NewsPostTag>? NewsPostTag { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
