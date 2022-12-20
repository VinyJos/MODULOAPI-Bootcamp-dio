
using Microsoft.EntityFrameworkCore;
using MODULOAPI.Entities;

namespace MODULOAPI.Context
{   
    // vai fazer a ligação com nosso banco de dados
    public class AgendaContext : DbContext
    {
        // Aqui vamos receber a conexão e mandar para o DbContext que gerencia a nossa comunicação com o banco de dados.
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        // Entidade significa que é uma classe do meu programa e ao mesmo tempo uma tabela no sql
        public DbSet<Contato> Contatos { get; set; }
        
        
    }
}