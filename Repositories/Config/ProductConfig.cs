using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.ProductName).IsRequired();
        builder.Property(p => p.Price).IsRequired();

        builder.HasData(
                new Product { ProductId = 1, CategoryId = 2, ImageUrl = "/images/computer.jpg", ProductName = "Computer", Price = 20000, ShowCase = false },
                new Product { ProductId = 2, CategoryId = 2, ImageUrl = "/images/mouse.jpg", ProductName = "Mouse", Price = 500, ShowCase = false },
                new Product { ProductId = 3, CategoryId = 2, ImageUrl = "/images/keyboard.jpg", ProductName = "Keyboard", Price = 1200, ShowCase = false },
                new Product { ProductId = 4, CategoryId = 2, ImageUrl = "/images/monitor.jpg", ProductName = "Monitor", Price = 4000, ShowCase = false },
                new Product { ProductId = 5, CategoryId = 2, ImageUrl = "/images/deck.jpg", ProductName = "Deck", Price = 1000, ShowCase = true },
                new Product { ProductId = 6, CategoryId = 1, ImageUrl = "/images/history.jpg", ProductName = "History", Price = 120, ShowCase = true }
        );
    }
}