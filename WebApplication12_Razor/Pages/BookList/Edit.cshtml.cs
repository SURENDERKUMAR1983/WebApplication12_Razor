using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication12_Razor.data;
using WebApplication12_Razor.Model;

namespace WebApplication12_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) 
        {
            _context = context;
        }
        
        public Book Book { get; set; } 
        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost(Book book)
        { 
            if (book == null)
            return NotFound();
            if(ModelState.IsValid)
            {
                _context.Update(book);
                 await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
        
    }
}
