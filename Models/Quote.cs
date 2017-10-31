using System;

namespace quoteme.Models
{
    public class Quote : BaseEntity
    {
        public int quoteid { get; set; }
        public int authorid { get; set; }
        public Author author { get; set; }
        public string quote { get; set; }
        public List<Quote_Category> quote_cat { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
