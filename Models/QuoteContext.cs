using Microsoft.EntityFrameworkCore;

namespace quoteme.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options) { }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quote_Category> Quotes_Categories { get; set; }
    }
}