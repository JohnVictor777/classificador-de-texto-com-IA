using Microsoft.EntityFrameworkCore;

namespace ApiClassificador.Data
{
    public class ClassificacaoTextoDbContext : DbContext
    {
        public ClassificacaoTextoDbContext(DbContextOptions<ClassificacaoTextoDbContext> options) : base(options)
        {

        }
        public DbSet<Models.ClassificacaoResultado> ClassificacaoDeResultados { get; set; }

    }
}
