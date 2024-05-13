using ControlVendas.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace ControlVendas.Data
{
    public class ControlVendasContext : DbContext
    {
        public ControlVendasContext(DbContextOptions<ControlVendasContext> options)
            : base(options) { }

        public DbSet<Seller> Seller { get; set; }
        

    }
}
