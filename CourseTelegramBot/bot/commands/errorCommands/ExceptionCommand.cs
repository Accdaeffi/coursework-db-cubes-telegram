using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class ExceptionCommand : AbstractCommand
    {
        readonly String EXCEPTION_STRING = "Inner exception!";

        public override AbstractResponse<string> execute()
        {
            return new StringResponse<String>(EXCEPTION_STRING);
        }
    }
}
