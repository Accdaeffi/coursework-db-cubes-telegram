using CourseTelegramBot.cubeConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CourseTelegramBot.bot
{
    class MessageHandler
    {
        public static async Task Handle(ITelegramBotClient botClient, Message message) {
            Chat chat = message.Chat;
            User sender = null;
            String messageText = null;

            if (message.From != null)
            {
                sender = message.From;
            }

            if (message.Type.Equals(MessageType.Text))
            {
                messageText = message.Text;
            }

            if (sender == null || message == null)
            {
                await botClient.SendTextMessageAsync(chat.Id, "Uncorrect sender or message type!");
            }

            Connection con = Connection.getConnection();

            List<CubeInfo> cubes = Connection.getConnection().getCubesInforamtion();

            if (cubes.Count > 0)
            {
                foreach (CubeInfo cube in cubes)
                {
                    await botClient.SendTextMessageAsync(chat.Id, cube.generateText());
                }
            } else 
            {
                await botClient.SendTextMessageAsync(chat.Id, "No cubes!");
            }
        }
    }
}
