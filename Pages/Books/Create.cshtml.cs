﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Godja_Vasile_Lab2.Data;
using Godja_Vasile_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Godja_Vasile_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Godja_Vasile_Lab2Context _context;

        public CreateModel(Godja_Vasile_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            var book = new Book
            {
                BookCategories = new List<BookCategory>()
            };

            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = null!;

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (selectedCategories != null)
            {
                Book.BookCategories = new List<BookCategory>();

                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };

                    Book.BookCategories.Add(catToAdd);
                }
            }

            _context.Book.Add(Book);

            await _context.SaveChangesAsync();

            PopulateAssignedCategoryData(_context, Book);

            return RedirectToPage("./Index");
        }
    }
}