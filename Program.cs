using LibraryGraphql.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibraryGraphql.Models;
using System.Linq;
using LibraryGraphql.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// 1) Rejestrujemy fabrykę kontekstów
builder.Services.AddPooledDbContextFactory<LibraryDbContext>(opt =>
    opt.UseInMemoryDatabase("Library"));

// 2) Konfigurujemy GraphQL
builder.Services
    .AddDbContext<LibraryDbContext>(opt =>            
        opt.UseInMemoryDatabase("Library"))
    .AddGraphQLServer()
    .RegisterDbContextFactory<LibraryDbContext>()    
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()  
    .AddSorting()     
    .AddProjections(); 

var app = builder.Build();

// 3) Seed danych
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider
                       .GetRequiredService<IDbContextFactory<LibraryDbContext>>();
    using var db = factory.CreateDbContext();
    if (!db.Authors.Any())
    {
        db.Authors.AddRange(
            new Author { Name = "Isaac Asimov" },
            new Author { Name = "Agatha Christie" },
            new Author { Name = "George Orwell" }
        );
        db.SaveChanges();

        var authors = db.Authors.ToList();
        db.Books.AddRange(
            new Book { Title = "Foundation", AuthorId = authors[0].Id },
            new Book { Title = "Murder on the Orient Express", AuthorId = authors[1].Id },
            new Book { Title = "1984", AuthorId = authors[2].Id }
        );
        db.SaveChanges();
    }
}

// 4) Mapujemy endpoint
app.MapGraphQL();

app.Run();
