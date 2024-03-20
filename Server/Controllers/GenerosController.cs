using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        private readonly ApplicationDBContext context;
        public GenerosController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            return await context.Generos.FirstOrDefaultAsync(genero => genero.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }
    }
}
