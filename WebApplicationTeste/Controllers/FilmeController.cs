using Microsoft.AspNetCore.Mvc;
using WebApplicationTeste.Models;

namespace WebApplicationTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id},filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();

            /*
            foreach (Filme filme in filmes){
                if(filme.Id == id)
                {
                    return filme;
                }
            }
            return null;*/
        }



    }
}
