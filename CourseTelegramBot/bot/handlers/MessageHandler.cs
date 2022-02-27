using CourseTelegramBot.bot.commands;
using CourseTelegramBot.bot.responses;
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
        private static MessageParser parser = MessageParser.getParser(); 

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

            AbstractCommand command = parser.parseMessage(sender.Id, messageText);

            AbstractResponse<String> response = command.execute();

            response.send(botClient, chat.Id);
        }
    }
}
