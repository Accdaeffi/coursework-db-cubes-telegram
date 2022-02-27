using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class StartCommand : AbstractCommand
    {
        readonly String START_STRING = "Hello! This is a simple bot for course work. " +
            "I recommend you check /help command for information about commands and how to use bot." ;

        public override AbstractResponse<string> execute()
        {
            return new StringResponse<String>(START_STRING);
        }
    }
}
