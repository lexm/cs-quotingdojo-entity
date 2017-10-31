using System;

namespace quoteme.Models
{
    public class Author : BaseEntity
    {
        public int authorid { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}