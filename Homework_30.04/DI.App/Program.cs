using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            var manager = new CommandManager(new CommandProcessor(new AddUserCommand(new UserStore(new InMemoryDatabaseService())), 
                new ListUsersCommand(new UserStore(new InMemoryDatabaseService()))));

            manager.Start();
        }
    }
}
