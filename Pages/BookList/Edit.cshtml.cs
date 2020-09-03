using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRepository.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookDb = await _db.Book.FindAsync(Book.Id);
                BookDb.Name = Book.Name;
                BookDb.Author = Book.Author;
                BookDb.ISBN = Book.ISBN;
                BookDb.Phone = Book.Phone;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}