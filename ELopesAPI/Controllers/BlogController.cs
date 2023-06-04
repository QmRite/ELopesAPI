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
    public class BlogController : Controller
    {
        private readonly LiteratureDbContext context;

        public BlogController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetBlogs")]
        public async Task<ActionResult<IEnumerable<NewsPostDto>>> GetNews()
        {
            var blogPosts = await context.BlogPost
                .Include(n => n.Comments.Where((c => c.IsApproved)))
                .ToListAsync();

            var blogPostDto = blogPosts.Select(BlogPostMapper.MapBlogPostToDto);

            return Ok(blogPostDto);
        }

        // GET: api/GetBlogPost/5
        [HttpGet("GetBlogPost/{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            var blogPost = await context.BlogPost
                .Include(n => n.Comments.Where((c => c.IsApproved)))
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }
    }
}
