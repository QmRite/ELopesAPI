using ELopesAPI.Models.DTOs;
using ELopesAPI.Models.Entities;

namespace ELopesAPI.Mappers
{
    public class BlogPostMapper
    {
        public static BlogPost MapDtoToBlogPost(BlogPostDto blogPostDto)
        {
            return new BlogPost()
            {
                Id = blogPostDto.Id,
                Cover = blogPostDto.Cover,
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                Created = blogPostDto.Created,
            };
        }

        public static BlogPostDto MapBlogPostToDto(BlogPost blogPost)
        {
            return new BlogPostDto()
            {
                Id = blogPost.Id,
                Cover = blogPost.Cover,
                Title = blogPost.Title,
                Content = blogPost.Content,
                Created = blogPost.Created,
                CommentsCount = blogPost.Comments == null ? 0 : blogPost.Comments.Count
            };
        }
    }
}
