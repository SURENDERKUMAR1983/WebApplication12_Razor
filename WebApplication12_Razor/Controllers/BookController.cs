using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12_Razor.data;

namespace WebApplication12_Razor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _context.Books.ToList();
            return Json(new { data = bookList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookFromDb = _context.Books.Find(id);
            if (bookFromDb == null)
                return Json(new { success = false, message = "Error while delete data" });
            _context.Books.Remove(bookFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Data successfully deleted" });
        }

    }
}
