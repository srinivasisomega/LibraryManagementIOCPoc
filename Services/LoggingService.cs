using global::LibraryManagementIOCPoc.interfaces;
using System;

namespace LibraryManagementIOCPoc.Services
{
    
        public class LoggingService : ILoggingService
        {
            public void Log(string message)
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss} - {message}");
            }
        }
    

}
