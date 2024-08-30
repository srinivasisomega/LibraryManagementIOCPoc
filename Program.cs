using Microsoft.Extensions.DependencyInjection;
using LibraryManagementIOCPoc.Services;
using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.Core;
using LibraryManagementIOCPoc.models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementIOCPoc
{

        public class Program
        {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Start the application
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var libraryManager = services.GetRequiredService<LibraryManager>();

                // Simulate user operations with multithreading
                Task user1 = Task.Run(() => SimulateUserOperations(libraryManager, 1, "User1"));
                Task user2 = Task.Run(() => SimulateUserOperations(libraryManager, 2, "User2"));

                Task.WaitAll(user1, user2);
            }

            host.Run();
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((context, services) =>
                    {
                        // Configure DbContext with a connection string
                        services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer("Data Source=COGNINE-L78;Initial Catalog=bolobapppa;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

                        // Register other services
                        services.AddTransient<IUserService, UserService>();
                        services.AddTransient<IBookService, BookService>();
                        services.AddTransient<ILendingService, LendingService>();
                        services.AddSingleton<ILoggingService, LoggingService>();
                        //services.AddScoped<IService, TransactionService>();
                        services.AddTransient<LibraryManager>();
                    });

            private static void SimulateUserOperations(LibraryManager libraryManager, int userId, string userName)
            {
                // Example of user operations, including timestamps
                Console.WriteLine($"[{DateTime.Now}] {userName} registering...");
                libraryManager.RegisterNewUser(userName, $"{userName}@example.com", "password123");

                Console.WriteLine($"[{DateTime.Now}] {userName} logging in...");
                if (libraryManager.Login($"{userName}@example.com", "password123"))
                {
                    Console.WriteLine($"[{DateTime.Now}] {userName} logged in successfully.");

                    Console.WriteLine($"[{DateTime.Now}] {userName} adding a book...");
                    libraryManager.AddNewBook("C# in Depth", "Jon Skeet", 5);

                    Console.WriteLine($"[{DateTime.Now}] {userName} searching for books...");
                    var books = libraryManager.SearchBooks("C#");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"[{DateTime.Now}] {userName} found book: {book.Title} by {book.Author}");
                    }

                    Console.WriteLine($"[{DateTime.Now}] {userName} lending a book...");
                    libraryManager.LendBookToUser(userId, 1); // Assume bookId 1 is available

                    Console.WriteLine($"[{DateTime.Now}] {userName} returning a book...");
                    libraryManager.ReturnBookFromUser(userId, 1); // Assume bookId 1 was lent
                }
                else
                {
                    Console.WriteLine($"[{DateTime.Now}] {userName} login failed.");
                }
            }
        }
    



}

