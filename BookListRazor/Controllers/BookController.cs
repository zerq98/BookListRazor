using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListData.DataAccess;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Books.ToList() });
        }
    }
}
