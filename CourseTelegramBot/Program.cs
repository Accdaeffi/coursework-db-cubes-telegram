using CourseTelegramBot.bot;
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





            /*Connection con = Connection.getConnection();
            con.getAllInforamtion();*/

            Console.ReadLine();
        }
    }
}
