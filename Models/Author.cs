using System.Collections.Generic;

namespace LibraryGraphql.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
