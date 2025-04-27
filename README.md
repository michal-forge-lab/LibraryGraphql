# 📚 Library GraphQL API

Minimalna aplikacja **.NET 8 + Hot Chocolate 15** do zarządzania autorami i książkami przez GraphQL.

---

## ✨ Features

| Area      | What you get                                                           |
|-----------|-------------------------------------------------------------------------|
| GraphQL   | `/graphql` endpoint, automatyczne schema & introspekcja                 |
| Queries   | `authors`, `books`, `authorsPaged(skip, take)`                          |
| Mutations | `addAuthor(name)`, `addBook(title, authorId)`                            |
| EF Core   | In-Memory baza danych, fabryka DbContext, seed danych                   |
| Scripts   | PowerShell helpers pod `scripts/ps/` do testowania API                  |
| Workshop  | Jedno plikowy `Program.cs`, oddzielne Query i Mutation                  |

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
| `scripts/ps/get-books.ps1` | List books + author |
| `scripts/ps/get-authors-paged.ps1 -Skip 0 -Take 2` | Paged authors |
| `scripts/ps/add-author.ps1 -Name "New Author"` | Add an author |
| `scripts/ps/add-book.ps1 -Title "Title" -AuthorId 1` | Add a book |
| `scripts/ps/schema-introspection.ps1` | Show schema types |

### Print result nicely:

```powershell
.\scripts\ps\get-books.ps1 | ConvertTo-Json -Depth 5
```

---

## 🗺️ Project Structure

```text
LibraryGraphqlFixed
 ├─ GraphQL/
 │   ├─ Query.cs          # resolvery GET
 │   └─ Mutation.cs       # resolvery POST
 ├─ Models/
 │   ├─ Author.cs
 │   └─ Book.cs
 ├─ Data/
 │   └─ LibraryDbContext.cs
 ├─ Program.cs            # minimal hosting, seeding bazy
 └─ scripts/ps/           # PowerShell helper scripts
```

---

## 🏗️ Extending the API

| Idea | Hint |
|------|------|
| Update / delete mutations | Dodaj metody w `Mutation.cs` |
| Paging / Filtering / Sorting | Atrybuty `[UsePaging]`, `[UseFiltering]`, `[UseSorting]` |
| Persisted Queries | `.AddReadPersistedQueries()` |
| SQL Server | Podmiana `UseInMemoryDatabase` na `UseSqlServer` |
| Authentication | Dodanie `builder.Services.AddAuthorization()` + `[Authorize]` |

---

## 🤝 Suggested Pair-Programming Flow

1. **Start (10 min)** — clone repo, `dotnet run`, strzel pierwsze zapytanie w Playground.
2. **Dodaj nową mutację** — zmiana roli driver/navigator co 15 min.
3. **Snapshot test** — np. testy queries w xUnit + Snapshooter.
4. **Retro (5 min)** — wnioski i dalsze kroki.

---

## 📜 License

MIT — możesz używać, modyfikować i rozbudowywać do woli.
