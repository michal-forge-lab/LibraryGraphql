# 📚 Library GraphQL API

A minimal **.NET 8 + Hot Chocolate 15** application for managing authors and books via GraphQL.

---

## ✨ Features

| Area      | What you get                                                           |
|-----------|-------------------------------------------------------------------------|
| GraphQL   | `/graphql` endpoint, auto-generated schema & introspection              |
| Queries   | `authors`, `books`, `authorsPaged(skip, take)`                          |
| Mutations | `addAuthor(name)`, `addBook(title, authorId)`                            |
| EF Core   | In-Memory database, pooled `DbContextFactory`, seeded initial data       |
| Scripts   | PowerShell helpers under `scripts/ps/` for easy testing                  |
| Workshop  | Single-file `Program.cs`, clear separation of Queries and Mutations      |

---

## 🏃‍♂️ Quick Start

```bash
git clone <repo-url>
cd LibraryGraphqlFixed
dotnet restore
dotnet run
```

```
Now listening on http://localhost:61483
GraphQL endpoint → POST http://localhost:61483/graphql
```

---

## 🐚 CLI Cheat-sheet (PowerShell 7)

| Script | Purpose |
|--------|---------|
| `scripts/ps/get-books.ps1` | List books with their authors |
| `scripts/ps/get-authors-paged.ps1 -Skip 0 -Take 2` | Paginated authors |
| `scripts/ps/add-author.ps1 -Name "New Author"` | Add a new author |
| `scripts/ps/add-book.ps1 -Title "Title" -AuthorId 1` | Add a new book |
| `scripts/ps/schema-introspection.ps1` | View available schema types |

### Pretty print the result:

```powershell
.\scripts\ps\get-books.ps1 | ConvertTo-Json -Depth 5
```

---

## 🗺️ Project Structure

```text
LibraryGraphqlFixed
 ├─ GraphQL/
 │   ├─ Query.cs          # resolvers for reading data
 │   └─ Mutation.cs       # resolvers for writing data
 ├─ Models/
 │   ├─ Author.cs
 │   └─ Book.cs
 ├─ Data/
 │   └─ LibraryDbContext.cs
 ├─ Program.cs            # minimal hosting + database seeding
 └─ scripts/ps/           # PowerShell helper scripts
```

---

## 🏗️ Extending the API

| Idea | Hint |
|------|------|
| Add Update/Delete mutations | Add new methods in `Mutation.cs` |
| Pagination / Filtering / Sorting | Use attributes like `[UsePaging]`, `[UseFiltering]`, `[UseSorting]` |
| Persisted Queries | Enable with `.AddReadPersistedQueries()` |
| Switch to SQL Server | Replace `UseInMemoryDatabase` with `UseSqlServer` |
| Authentication and Authorization | Add `builder.Services.AddAuthorization()` + `[Authorize]` attributes |

---

## 🤝 Suggested Pair-Programming Flow

1. **Kick-off (10 min)** — clone the repo, run `dotnet run`, make your first query in Playground.
2. **Add a new mutation together** — switch driver/navigator every 15 minutes.
3. **Snapshot testing** — create a simple query test using xUnit + Snapshooter.
4. **Retro (5 min)** — discuss challenges and next steps.

---

## 📜 License

MIT — free to use, modify, and extend.
