using Microsoft.AspNetCore.Mvc;
using MODULOAPI.Context;
using MODULOAPI.Entities;

namespace MODULOAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {   
        // atributo 
        private readonly AgendaContext _context;

        // classe Construtor 
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost] // -> estamos enviando uma informação
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }
    }
}