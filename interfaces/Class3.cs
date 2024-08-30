namespace LibraryManagementIOCPoc.interfaces
{

        public interface ILendingService
        {
            void LendBook(int userId, int bookId);
            void ReturnBook(int userId, int bookId);
        }
   
}
