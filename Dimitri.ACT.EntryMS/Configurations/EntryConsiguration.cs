using Dimitri.ACT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimitri.ACT.EntryMS.Configurations
{
    public class EntryConsiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("Entries");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever().UseIdentityColumn();
            builder.Property(i => i.EntryType).HasColumnType("INT");
            builder.Property(i => i.Total).HasColumnType("DECIMAL(5,2)"); // 5 casas totais com 2 decimais (até 999,99)
            builder.Property(i => i.Timestamp).HasColumnType("DATETIME");
        }
    }
}
