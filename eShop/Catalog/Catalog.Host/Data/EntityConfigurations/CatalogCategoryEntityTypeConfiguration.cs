using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogCategoryEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogCategory>
{
    public void Configure(EntityTypeBuilder<CatalogCategory> builder)
    {
        builder.ToTable("CatalogCategory");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_category_hilo")
            .IsRequired();

        builder.Property(cb => cb.Category)
            .IsRequired()
            .HasMaxLength(100);
    }
}