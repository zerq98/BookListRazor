using BookListRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
