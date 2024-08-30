using LibraryManagementIOCPoc.interfaces;
namespace LibraryManagementIOCPoc.Services
{
    

   
        public class LendingService : ILendingService
        {
            private readonly IUserService _userService;
            private readonly IBookService _bookService;
            private readonly List<(int UserId, int BookId)> _loans = new List<(int UserId, int BookId)>();

            public LendingService(IUserService userService, IBookService bookService)
            {
                _userService = userService;
                _bookService = bookService;
            }

            public void LendBook(int userId, int bookId)
            {
                var user = _userService.GetUserById(userId);
                var book = _bookService.GetBookById(bookId);

                if (user != null && book != null && book.CopiesAvailable > 0)
                {
                    _loans.Add((userId, bookId));
                    book.CopiesAvailable--;
                    Console.WriteLine($"Book '{book.Title}' lent to {user.Name}.");
                }
                else
                {
                    Console.WriteLine("Lending failed. Either the book or user doesn't exist, or no copies are available.");
                }
            }

            public void ReturnBook(int userId, int bookId)
            {
                var loan = _loans.Find(l => l.UserId == userId && l.BookId == bookId);
                if (loan != default)
                {
                    var book = _bookService.GetBookById(bookId);
                    if (book != null)
                    {
                        _loans.Remove(loan);
                        book.CopiesAvailable++;
                        Console.WriteLine($"Book '{book.Title}' returned by {userId}.");
                    }
                }
                else
                {
                    Console.WriteLine("Return failed. No such loan found.");
                }
            }
        }
    

}
