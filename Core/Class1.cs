using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.models;
using LibraryManagementIOCPoc.Services;
using LibraryManagementIOCPoc.Core;
using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.models;

namespace LibraryManagementIOCPoc.Core
{
    
        public class LibraryManager
        {
            private readonly IUserService _userService;
            private readonly IBookService _bookService;
            private readonly ILendingService _lendingService;
            private readonly ILoggingService _loggingService;

            public LibraryManager(IUserService userService, IBookService bookService, ILendingService lendingService, ILoggingService loggingService)
            {
                _userService = userService;
                _bookService = bookService;
                _lendingService = lendingService;
                _loggingService = loggingService;
            }

            public void RegisterNewUser(string name, string email, string password)
            {
                _userService.RegisterUser(name, email, password);
                _loggingService.Log($"User registered: {name}");
            }

            public void AddNewBook(string title, string author, int copies)
            {
                _bookService.AddBook(title, author, copies);
                _loggingService.Log($"Book added: {title} by {author}");
            }

            public List<Book> SearchBooks(string keyword)
            {
                var books = _bookService.SearchBooks(keyword);
                foreach (var book in books)
                {
                    _loggingService.Log($"Found book: {book.Title} by {book.Author}");
                }
                return books;
            }

            public void LendBookToUser(int userId, int bookId)
            {
                _lendingService.LendBook(userId, bookId);
                _loggingService.Log($"Book with ID {bookId} lent to user with ID {userId}");
            }

            public void ReturnBookFromUser(int userId, int bookId)
            {
                _lendingService.ReturnBook(userId, bookId);
                _loggingService.Log($"Book with ID {bookId} returned by user with ID {userId}");
            }
        }
    

}
