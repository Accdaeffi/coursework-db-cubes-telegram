using CourseTelegramBot.bot;
using CourseTelegramBot.cubeConnection;
using CourseTelegramBot.query;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace CourseTelegramBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var Bot = new TelegramBotClient("5242884007:AAGfMy39Q9mLJgQyel2hd07kXcCe4vSkGCg");

            var me = await Bot.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            

            ReceiverOptions receiverOptions = new ReceiverOptions() { AllowedUpdates = { } };
            Bot.StartReceiving(Handler.HandleUpdateAsync,
                               Handler.HandleErrorAsync,
                               receiverOptions);

            


            /*String commandString = "SELECT {[Measures].[Sickness Fact Count]} ON COLUMNS, " +
                "{[Doctor Dim].[Full Name].[Martin Ford]} ON ROWS " +
                "FROM [sickness_cube] ";*/

            /*UserInformation userInformation = new UserInformation();

            userInformation.AddNewField("[Doctor Dim].[Full Name].MEMBERS");
            userInformation.addNewMeasure("[Sickness Fact Count]");

            String commandString = userInformation.compileQuery();*/

            /*String commandString = "SELECT {[Measures].[Sickness Fact Count]} ON COLUMNS, " +
                "({[Doctor Dim].[Full Name].MEMBERS}) ON ROWS " +
                "FROM [sickness_cube] ";*/


            /*Connection con = Connection.getConnection();
            con.getAllInforamtion();
            String s = con.executeQuery(commandString);

            Console.WriteLine(s);*/

            Console.ReadLine();
        }
    }
}
