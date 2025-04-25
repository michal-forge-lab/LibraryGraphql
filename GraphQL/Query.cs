using LibraryGraphql.Data;
using LibraryGraphql.Models;
using Microsoft.EntityFrameworkCore;
using HotChocolate;          
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryGraphql.GraphQL;

public class Query
{
    private readonly IDbContextFactory<LibraryDbContext> _factory;

    public Query(IDbContextFactory<LibraryDbContext> factory)
    {
        _factory = factory;
    }

    // prosta lista autorów
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        using var db = _factory.CreateDbContext();
        return await db.Authors.ToListAsync();
    }

    // prosta lista ksi¹¿ek
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        using var db = _factory.CreateDbContext();
        return await db.Books.ToListAsync();
    }

    // przyk³adowa paginacja "rêczna"
    public async Task<AuthorPage> GetAuthorsPagedAsync(int skip = 0, int take = 10)
    {
        using var db = _factory.CreateDbContext();
        var total = await db.Authors.CountAsync();
        var items = await db.Authors
                            .OrderBy(a => a.Id)
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
        return new AuthorPage(total, items);
    }
}

// pomocniczy typ do paginacji
public record AuthorPage(int TotalCount, IEnumerable<Author> Nodes);
