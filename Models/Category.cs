using System;
using System.Collections.Generic;

namespace quoteme.Models
{
    public class Category : BaseEntity
    {
        public int categoryid { get; set; }
        public string name { get; set; }
        public List<Quote_Category> cat_quotes { get; set; }
        public Category()
        {
            cat_quotes = new List<Quote_Category>();
        }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}