using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kartapp.Models
{
    public class KartappContext : DbContext
    {
        public KartappContext (DbContextOptions<KartappContext> options)
            : base(options)
        {
        }

        public DbSet<Kartapp.Models.RaceModel> RaceModel { get; set; }
    }
}
