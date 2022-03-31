using api_back_facturacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion { 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 

        }
        public DbSet<Cliente> TL_Cliente { get; set; }

        public DbSet<Producto> TL_Producto { get; set; }

        public DbSet<Inventario> TL_Inventario { get; set; }

        public DbSet<Facturacion> TL_Facturacion { get; set; }
    }
}
