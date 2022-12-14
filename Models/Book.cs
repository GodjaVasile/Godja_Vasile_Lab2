
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Godja_Vasile_Lab2.Models
{
    public class Book
    {
        // Daca ai avea o baza de date deja creata cu SQL Server spre exemplu, folosind EF Core poti
        // da scaffold bazei de date, adica iti creeaza modelele astea si DBContext in functie de
        // ce ai in baza de date. Ar arata ca aici, doar ca fara atributele gen Display, Column etc.
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int ID { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [StringLength(150, MinimumLength = 3)]

        public string Title { get; set; } = null!;

      

        public int AuthorID { get; set; } //cheie straina
        public virtual Author Author { get; set; } = null!; //navigation property

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; } = null!;
        public ICollection<BookCategory> BookCategories { get; set; }

    }
}
