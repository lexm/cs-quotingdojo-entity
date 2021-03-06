using System;

namespace quoteme.Models
{
    public class Quote_Category : BaseEntity
    {
        public int id { get; set; }
        public int quoteid { get; set; }
        public Quote quote { get; set; }
        public int categoryid { get; set; }
        public Category category { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}