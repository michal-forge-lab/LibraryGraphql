using Microsoft.EntityFrameworkCore;
using LibraryGraphql.Models;

namespace LibraryGraphql.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options) { }
}
