using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication12_Razor.data;
using WebApplication12_Razor.Model;

namespace WebApplication12_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Books { get; set; }        

        public async Task OnGet()
        {
            Books = await _context.Books.ToListAsync();
        }
        public async Task<IActionResult>OnPostDelete(int id)
        {
            var bookFromDb = await _context.Books.FindAsync(id);
            if (bookFromDb == null)
                return NotFound();
           _context.Books.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        
           
        
    }
}
