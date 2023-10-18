using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DE_TallerTabla2.Models;

namespace DE_TallerTabla2.Data
{
    public class DE_TallerTabla2Context : DbContext
    {
        public DE_TallerTabla2Context(DbContextOptions<DE_TallerTabla2Context> options)
            : base(options)
        {
        }

        public DbSet<DE_TallerTabla2.Models.Burger> Burger { get; set; } = default!;
        public DbSet<DE_TallerTabla2.Models.Promo> Promos
        {
            get; set;
        }
    }
}
