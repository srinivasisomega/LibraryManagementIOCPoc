using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.Services;
using LibraryManagementIOCPoc.Services;
using LibraryManagementIOCPoc.Core;
using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.models;

namespace LibraryManagementIOCPoc.Core
{
   
        public static class ServiceFactory
        {
            public static IUserService CreateUserService()
            {
                return new UserService();
            }

            public static IBookService CreateBookService()
            {
                return new BookService();
            }

            public static ILendingService CreateLendingService(IUserService userService, IBookService bookService)
            {
                return new LendingService(userService, bookService);
            }
        }
    

}
