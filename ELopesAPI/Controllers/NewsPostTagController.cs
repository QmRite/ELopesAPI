using ELopesAPI.Data;
using ELopesAPI.Models.Entities;
using ELopesAPI.Models.JoinEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELopesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPostTagController : ControllerBase
    {
        private readonly LiteratureDbContext context;

        public NewsPostTagController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetNewsPostsTags")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetNewsPostsTags()
        {
            var newsPostTags = await context.Tags
                .ToListAsync();

            return Ok(newsPostTags);
        }
    }
}
