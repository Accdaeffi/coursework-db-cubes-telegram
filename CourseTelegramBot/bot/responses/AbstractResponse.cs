using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CourseTelegramBot.bot.responses
{
    abstract class AbstractResponse<T>
    {
		private protected readonly T responseContent;

		public AbstractResponse(T responseContent)
		{
			this.responseContent = responseContent;
		}

		public T getContent()
		{
			return responseContent;
		}

		public abstract void send(ITelegramBotClient sender, long chatId);
	}
}
