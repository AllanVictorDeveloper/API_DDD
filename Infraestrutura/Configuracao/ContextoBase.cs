using Entidades.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracao
{
    public class ContextoBase : IdentityDbContext<ApplicationUser>
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
        }

        public DbSet<Mensagem> Mensagem { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer(ObterStringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }



        public string ObterStringConnection()
        {
            return "Server=CAVEIRAO;Database=API_DDD_2023;User ID=sa;Password=Dev@llan73;Trusted_Connection=False;";
        }

    }
}