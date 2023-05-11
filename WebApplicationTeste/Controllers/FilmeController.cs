using Microsoft.AspNetCore.Mvc;
using WebApplicationTeste.Data;
using WebApplicationTeste.Data.Dtos;
using WebApplicationTeste.Models;

namespace WebApplicationTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme{
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
                Diretor = filmeDto.Diretor,
            };
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id},filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Titulo = filme.Titulo,
                    Genero = filme.Genero,
                    Diretor= filme.Diretor,
                    Duracao = filme.Duracao,
                    Id = filme.Id,
                    HoraDaConsulta = DateTime.Now
                };
                return Ok(filmeDto);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult Atualizafilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme=>filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmeDto.Titulo;
            filme.Diretor = filmeDto.Diretor;
            filme.Duracao = filmeDto.Duracao;
            filme.Genero = filmeDto.Genero;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
