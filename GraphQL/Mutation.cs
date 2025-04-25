using LibraryGraphql.Data;
using LibraryGraphql.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace LibraryGraphql.GraphQL;

public class Mutation
{
    public async Task<Author> AddAuthorAsync(string name, [Service] LibraryDbContext context)
    {
        var author = new Author { Name = name };
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Book> AddBookAsync(string title, int authorId, [Service] LibraryDbContext context)
    {
        var book = new Book { Title = title, AuthorId = authorId };
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }
}
