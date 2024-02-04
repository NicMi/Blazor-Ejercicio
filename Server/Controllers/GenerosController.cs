using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }
    }
}
