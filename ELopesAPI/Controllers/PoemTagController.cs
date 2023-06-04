using ELopesAPI.Data;
using ELopesAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELopesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoemTagController : ControllerBase
    {
         private readonly LiteratureDbContext context;

        public PoemTagController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetPoemTags")]
        public async Task<ActionResult<IEnumerable<Poem>>> GetPoemTags()
        {
            var poemsTags = await context.PoemTags
                .ToListAsync();

            return Ok(poemsTags);
        }
    }
}
