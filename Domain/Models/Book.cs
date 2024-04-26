using System;

namespace Domain.Models
{
    public class Book : Product
    {
        public string Description { get; set; }
        public int TotalPage { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
