using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Pages.FriendList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Friend> Friends { get; set; }
        public async Task OnGet()
        {
            Friends = await _db.Friend.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Friend = await _db.Friend.FindAsync(id);
            if (Friend == null)
            {
                return NotFound();
            }
            _db.Friend.Remove(Friend);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostIgnor()
        {
            return RedirectToPage("Index");
        }
    }
}