﻿using Dimitri.ACT.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dimitri.ACT.EntryMS.Data
{
    public class EntryMSContext : DbContext
    {
        public EntryMSContext(DbContextOptions<EntryMSContext> options) : base(options) { }

        public DbSet<Entry> Entries { get; set; }
    }
}
