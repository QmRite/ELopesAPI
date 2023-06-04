using ELopesAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ELopesAPI.Models.DTOs
{
    public class BlogPostDto : Controller
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }


        public int CommentsCount { get; set; }
    }
}
