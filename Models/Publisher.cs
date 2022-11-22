﻿namespace Godja_Vasile_Lab2.Models
{
    public class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int ID { get; set; }
        public string PublisherName { get; set; } = null!;
        public ICollection<Book> Books { get; set; }
    }
}
