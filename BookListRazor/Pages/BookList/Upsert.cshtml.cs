using BookListData.DataAccess;
using BookListData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly DataContext _context;

        public UpsertModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            if (id == null)
            {
                return Page();
            }

            Book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FindAsync(id);
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    _context.Books.Add(Book);
                }
                else
                {
                    _context.Books.Update(Book);
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}