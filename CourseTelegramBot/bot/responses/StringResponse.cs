using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CourseTelegramBot.bot.responses
{
    class StringResponse<String> : AbstractResponse<String>
	{
		public StringResponse(String responseText) : base(responseText)
        {
        }

        public override void send(ITelegramBotClient sender, long chatId)
        {
			sender.SendTextMessageAsync(chatId, responseContent.ToString());
		}
    }
}
