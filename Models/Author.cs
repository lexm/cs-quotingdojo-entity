using System;
using System.Collections.Generic;

namespace quoteme.Models
{
    public class Author : BaseEntity
    {
        public int authorid { get; set; }
        public string name { get; set; }
        // public List<Quote> quotes { get; set; }
        // public Author()
        // {
        //     quotes = new List<Quote>();
        // }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}