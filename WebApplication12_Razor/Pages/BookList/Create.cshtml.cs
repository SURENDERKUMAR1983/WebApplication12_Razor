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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; } 
        public void OnGet()
        {
        }
        public async Task<IActionResult> Onpost(Book book)
        {
            if (book == null)
                return NotFound();
            if(ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
