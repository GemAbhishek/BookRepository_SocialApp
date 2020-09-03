using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookRepository.Pages.FriendList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Friend Friend { get; set; }

        public async Task OnGet(int id)
        {
            Friend = await _db.Friend.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var FriendDb = await _db.Friend.FindAsync(Friend.Id);
                FriendDb.Name = Friend.Name;
                FriendDb.Location = Friend.Location;
                FriendDb.Phone = Friend.Phone;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}