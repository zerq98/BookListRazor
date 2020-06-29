using BookListData.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListData.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
