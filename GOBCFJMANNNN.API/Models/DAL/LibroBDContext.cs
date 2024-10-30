using GOBCFJMANNNN.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GOBCFJMANNNN.API.Models.DAL
{
    public class LibroBDContext : DbContext
    {
        public LibroBDContext(DbContextOptions<LibroBDContext> options): base(options)
        {
            
        }

        public DbSet<Libro> Libros { get; set; }
    }
}
