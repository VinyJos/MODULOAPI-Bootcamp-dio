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

        // Criar novo Contato
        [HttpPost] // -> estamos enviando uma informação
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new{id = contato.Id}, contato);
        }

        // Buscar Contato salvo
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            // validação
            if(contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        // Obter por nome
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }
        // Atualizar contato salvo
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {   
            // vai buscar no banco
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();
            
            // As novas mudanças
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            // vai fazer o update e salvar no banco
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // vai buscar no banco
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            // retorno de sucesso, não tem nada para retornar
            return NoContent();
        }
    }
}