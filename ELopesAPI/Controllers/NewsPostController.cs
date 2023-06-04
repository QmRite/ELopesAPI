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
    public class NewsPostController : Controller
    {
        private readonly LiteratureDbContext context;

        public NewsPostController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetNews")]
        public async Task<ActionResult<IEnumerable<NewsPostDto>>> GetNews()
        {
            var news = await context.NewsPosts
                .Include(n => n.Comments.Where((c => c.IsApproved)))
                .Include(n => n.Tags)
                .ToListAsync();

            var newsDto = news.Select(NewsPostMapper.MapNewsPostToDto);

            return Ok(newsDto);
        }

        // GET: api/Your/5
        [HttpGet("GetNews/{id}")]
        public async Task<ActionResult<NewsPost>> GetNews(int id)
        {
            var news = await context.NewsPosts
                .Include(n => n.Comments.Where((c => c.IsApproved)))
                .Include(n => n.Tags)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpGet("GetNewsByTag/{filterName}")]
        public async Task<ActionResult<IEnumerable<NewsPostDto>>> GetNewsByTag(string filterName)
        {
            var news = await context.NewsPosts
                .Where(n => n.Tags.Any(t => t.Name.Equals(filterName)))
                .Include(n => n.Comments.Where((c => c.IsApproved)))
                .Include(n => n.Tags)
                .ToListAsync();

            var newsDto = news.Select(NewsPostMapper.MapNewsPostToDto);

            return Ok(newsDto);
        }
    }
}
