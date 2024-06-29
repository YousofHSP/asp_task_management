using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Desktop : BaseEntity
{
    public string Title { get; set; } = null!;
    public int OwnerUserId { get; set; }
    public string Description { get; set; } = null!;

    #region Navigation

    public required User Owner { get; set; }

    #endregion

}

public class DesktopConfiguration : IEntityTypeConfiguration<Desktop>
{
    public void Configure(EntityTypeBuilder<Desktop> builder)
    {
        builder.Property(d => d.OwnerUserId).IsRequired();

        builder.HasOne(d => d.Owner)
            .WithMany(u => u.Desktops)
            .HasForeignKey(d => d.OwnerUserId);
    }
}