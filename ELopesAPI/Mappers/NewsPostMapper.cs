using System.Diagnostics;
using ELopesAPI.Models.Dtos;
using ELopesAPI.Models.DTOs;
using ELopesAPI.Models.Entities;

namespace ELopesAPI.Mappers
{
    public class NewsPostMapper
    {
        public static NewsPost MapDtoToNewsPost(NewsPostDto newsPostDto)
        {
            return new NewsPost()
            {
                Id = newsPostDto.Id,
                Cover = newsPostDto.Cover,
                Title = newsPostDto.Title,
                Content = newsPostDto.Content,
                Created = newsPostDto.Created,
                Source = newsPostDto.Source,
                Tags = newsPostDto.Tags,
            };
        }

        public static NewsPostDto MapNewsPostToDto(NewsPost newsPost)
        {
            return new NewsPostDto
            {
                Id = newsPost.Id,
                Cover = newsPost.Cover,
                Title = newsPost.Title,
                Content = newsPost.Content,
                Created = newsPost.Created,
                Source = newsPost.Source,
                Tags = newsPost.Tags,
                CommentsCount = newsPost.Comments == null ? 0 : newsPost.Comments.Count
            };
        }
    }
}
