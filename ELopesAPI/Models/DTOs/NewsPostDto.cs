using ELopesAPI.Models.Entities;

namespace ELopesAPI.Models.DTOs
{
    public class NewsPostDto
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public string? Source { get; set; }

        public ICollection<Tag>? Tags { get; set; }

        public int CommentsCount { get; set; }
    }
}
