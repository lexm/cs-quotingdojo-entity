using System;

namespace quoteme.Models
{
    public class Category : BaseEntity
    {
        public int categoryid { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}