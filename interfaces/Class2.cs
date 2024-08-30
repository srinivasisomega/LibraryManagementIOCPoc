using LibraryManagementIOCPoc.models;
namespace LibraryManagementIOCPoc.interfaces
{
   
        public interface IBookService
        {
            void AddBook(string title, string author, int copies);
            List<Book> SearchBooks(string keyword);
            Book GetBookById(int bookId);
        }
    

}
