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
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            //Create
            if (id==null)
                return Page();
            //Edit
            Book = await _context.Books.FindAsync(id);
            return Page();
        }
        public async Task<IActionResult> onPost()
        {
            if (ModelState.IsValid)
                return NotFound();
            //Save//
            if (Book.Id == 0)
                await _context.Books.AddAsync(Book);
            else //Update
                _context.Books.Update(Book);
           await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }      
        
    }
}
