using ELopesAPI.Data;
using ELopesAPI.Mappers;
using ELopesAPI.Migrations;
using ELopesAPI.Models.DTOs;
using ELopesAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELopesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoemController : ControllerBase
    {
        private readonly LiteratureDbContext context;

        public PoemController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetPoems")]
        public async Task<ActionResult<IEnumerable<Poem>>> GetPoems()
        {
            var poems = await context.Poems
                .Include(n => n.Tags)
                .ToListAsync();

            return Ok(poems);
        }

        [HttpGet("GetPoemsByTag/{filterName}")]
        public async Task<ActionResult<IEnumerable<Poem>>> GetPoemsByTag(string filterName)
        {
            var poems = await context.Poems
                .Where(n => n.Tags.Any(t => t.Name.Equals(filterName)))
                .Include(n => n.Tags)
                .ToListAsync(); ;

            return Ok(poems);
        }
    }
}
