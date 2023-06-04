using System.Net;
using System;
using ELopesAPI.Models.Dtos;
using ELopesAPI.Models.Entities;

namespace ELopesAPI.Mappers
{
    public static class BookMapper
    {
        public static Book MapDtoToBook(BookDto bookDto)
        {
            return new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Cover = bookDto.Cover,
                Description = bookDto.Description,
                IsForChildren = bookDto.IsForChildren
            };
        }

        public static BookDto MapBookToDto(Book book)
        {
            return new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Cover = book.Cover,
                Description = book.Description,
                IsForChildren = book.IsForChildren
            };
        }
    }
}
