using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.models;

namespace LibraryManagementIOCPoc.Services
{
    
   
        public class BookService : IBookService
        {
            private readonly List<Book> _books = new List<Book>();
            private int _nextBookId = 1;

            public void AddBook(string title, string author, int copies)
            {
                var book = new Book(_nextBookId++, title, author, copies);
                _books.Add(book);
                Console.WriteLine($"Book '{title}' by {author} added with {copies} copies.");
            }

            public List<Book> SearchBooks(string keyword)
            {
                return _books.Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                         b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            public Book GetBookById(int bookId)
            {
                return _books.Find(b => b.BookId == bookId);
            }
        }
    

}
