using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaFrontEnd.Models;

namespace PracticaFrontEnd.Data
{
    public class PracticaFrontEndContext : DbContext
    {
        public PracticaFrontEndContext (DbContextOptions<PracticaFrontEndContext> options)
            : base(options)
        {
        }

        public DbSet<PracticaFrontEnd.Models.Items> Items { get; set; } = default!;
    }
}
