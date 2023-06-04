using ELopesAPI.Data;
using ELopesAPI.Mappers;
using ELopesAPI.Models.DTOs;
using ELopesAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELopesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly LiteratureDbContext context;

        public CommentController(LiteratureDbContext context)
        {
            this.context = context;
        }

        // POST: api/PostBook
        [HttpPost]
        public async Task<ActionResult<Comment>> PostBook(CommentDto commentDto)
        {
            var comment = CommentMapper.MapDtoToComment(commentDto);

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpPut("SetLike/{commentId}")]
        public async Task<ActionResult<Comment>> SetLike(int commentId)
        {
            var comment = await context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return BadRequest();
            }

            comment.Likes++;

            await context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpPut("RemoveLike/{commentId}")]
        public async Task<ActionResult<Comment>> RemoveLike(int commentId)
        {
            var comment = await context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return BadRequest();
            }

            comment.Likes--;

            await context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpPut("SetDislike/{commentId}")]
        public async Task<ActionResult<Comment>> SetDislike(int commentId)
        {
            var comment = await context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return BadRequest();
            }

            comment.Dislikes++;

            await context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpPut("RemoveDislike/{commentId}")]
        public async Task<ActionResult<Comment>> RemoveDislike(int commentId)
        {
            var comment = await context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return BadRequest();
            }

            comment.Dislikes--;

            await context.SaveChangesAsync();

            return Ok(comment);
        }
    }
}
