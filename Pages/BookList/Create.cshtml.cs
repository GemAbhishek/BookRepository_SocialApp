using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRepository.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]  //no need to pass parameter in post action
        public Book Book { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()  //not need to pass Book obj as parameter, BindProperty applied
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}