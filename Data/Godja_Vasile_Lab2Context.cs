using Microsoft.EntityFrameworkCore;
using Godja_Vasile_Lab2.Models;

namespace Godja_Vasile_Lab2.Data
{
    public class Godja_Vasile_Lab2Context : DbContext
    {
        public Godja_Vasile_Lab2Context (DbContextOptions<Godja_Vasile_Lab2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; } = null!;

        public virtual DbSet<Publisher> Publisher { get; set; } = null!;

        public virtual DbSet<Author> Author { get; set; } = null!;

        public virtual DbSet<Category> Category { get; set; } = null!;

        public DbSet<Godja_Vasile_Lab2.Models.Member> Member { get; set; }

        public DbSet<Godja_Vasile_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
