using Microsoft.EntityFrameworkCore;

namespace quoteme.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options) { }
        public DbSet<Quote> quotes { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Meta> metas { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Quote_Category> quotes_categories { get; set; }
    }
}