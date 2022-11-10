using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext (DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MusicStore.Models.Album> Album { get; set; } = default!;

        public DbSet<MusicStore.Models.Song>? Song { get; set; }

        public DbSet<MusicStore.Models.Artist>? Artist { get; set; }

        public DbSet<MusicStore.Models.Genre>? Genre { get; set; }
    }
}
