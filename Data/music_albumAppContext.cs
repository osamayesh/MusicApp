using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using music_albumApp.Models;

namespace music_albumApp.Data
{
    public class music_albumAppContext : DbContext
    {
        public music_albumAppContext (DbContextOptions<music_albumAppContext> options)
            : base(options)
        {
        }

        public DbSet<music_albumApp.Models.Allbum> Allbum { get; set; } = default!;
    }
}
