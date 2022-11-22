namespace Godja_Vasile_Lab2.Models
{
    public class Category
    {
        public Category()
        {
            BookCategories = new HashSet<BookCategory>();

        }

        public int ID { get; set; }
        public string CategoryName { get; set; } = null!; 
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
