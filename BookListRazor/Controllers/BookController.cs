using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListData.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return Json( new {success=false,message="Error while Deleting"});
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Book removed from library" });
        }
    }
}
