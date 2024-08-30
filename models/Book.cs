namespace LibraryManagementIOCPoc.models
{

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public int CopiesAvailable { get; set; }

            public Book(int bookId, string title, string author, int copiesAvailable)
            {
                BookId = bookId;
                Title = title;
                Author = author;
                CopiesAvailable = copiesAvailable;
            }
        }
    

}
