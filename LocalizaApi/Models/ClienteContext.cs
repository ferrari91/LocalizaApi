using Microsoft.EntityFrameworkCore;

namespace LocalizaApi.Models
{
    public class BancoDadosContext:DbContext
    {
        public BancoDadosContext(DbContextOptions<BancoDadosContext> options):base(options)
        {

        }

        public DbSet<Cliente> tab_Cliente { get; set; }

        public DbSet<Veiculos> tab_Veiculo { get; set; }

        public DbSet<Veiculo_Modelo> tb_Veiculo_Modelo { get; set; }
    }
}
