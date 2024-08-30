namespace LibraryManagementIOCPoc.models
{
    
        public class Lending
        {
            public int LendingId { get; set; }
            public int UserId { get; set; }
            public int BookId { get; set; }
            public DateTime LendDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public User User { get; set; }
            public Book Book { get; set; }
        }

        
    

}
