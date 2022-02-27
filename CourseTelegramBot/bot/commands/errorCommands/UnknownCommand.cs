using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class UnknownCommand : AbstractCommand
    {
        readonly String UNKNOWN_COMMNAD_STRING = "Unknown command!";

        public override AbstractResponse<string> execute()
        {
            return new StringResponse<String>(UNKNOWN_COMMNAD_STRING);
        }
    }
}
