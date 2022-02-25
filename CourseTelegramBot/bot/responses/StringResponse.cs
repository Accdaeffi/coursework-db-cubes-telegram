using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CourseTelegramBot.bot.responses
{
    class StringResponse
	{
		protected readonly String responseContent;
	
		public StringResponse(String responseContent)
		{
			this.responseContent = responseContent;
		}

		public String getContent()
		{
			return responseContent;
		}

		public void send(ITelegramBotClient sender, long chatId)
        {
			sender.SendTextMessageAsync(chatId, responseContent);
        }
	}
}
