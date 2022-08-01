using Microsoft.EntityFrameworkCore;
using ProcessoSeleticov2.Models;

namespace ProcessoSeleticov2.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<ProcessosModel> Processo { get; set; }

        public DbSet<DocumentosModel> Documento { get; set; }

        public DbSet<ProcessoSeleticov2.Models.ArquivoModel>? ArquivoModel { get; set; }

    }
}
