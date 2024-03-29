﻿namespace ELopesAPI.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Description { get; set; }

        public bool IsForChildren { get; set; }
    }
}
