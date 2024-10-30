using GOBCFJMANNNN.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GOBCFJMANNNN.API.Models.DAL
{
    public class CategoriaBDContext : DbContext
    {
        public CategoriaBDContext(DbContextOptions<CategoriaBDContext> options): base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
