using ELopesAPI.Models.Dtos;
using ELopesAPI.Models.DTOs;
using ELopesAPI.Models.Entities;

namespace ELopesAPI.Mappers
{
    public class CommentMapper
    {
        public static Comment MapDtoToComment(CommentDto commentDto)
        {
            return new Comment()
            {
                Id = commentDto.Id,
                Username = commentDto.Username,
                Content = commentDto.Content,
                ParentId = commentDto.ParentId,
                BlogPostId = commentDto.BlogPostId,
                NewsPostId = commentDto.NewsPostId,
            };
        }

        public static CommentDto MapCommentToDto(Comment comment)
        {
            return new CommentDto()
            {
                Id = comment.Id,
                Username = comment.Username,
                Content = comment.Content,
                ParentId = comment.ParentId,
                BlogPostId = comment.BlogPostId,
                NewsPostId = comment.NewsPostId,
            };
        }
    }
}
