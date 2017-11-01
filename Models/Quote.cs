using System;
using System.Collections.Generic;

namespace quoteme.Models
{
    public class Quote : BaseEntity
    {
        public int quoteid { get; set; }
        public string quote { get; set; }
        public int authorid { get; set; }
        public Author author { get; set; }
        public int metaid { get; set; }
        public Meta meta { get; set; }
        // public int id { get; set; }
        public List<Quote_Category> quote_cat { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
