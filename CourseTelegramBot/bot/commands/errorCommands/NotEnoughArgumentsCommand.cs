using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class NotEnoughArgumentsCommand : AbstractCommand
    {
        readonly String NOT_ENOUGH_ARGUMENTS_STRING = "Not enough arguments to the command!";

        public override AbstractResponse<string> execute()
        {
            return new StringResponse<String>(NOT_ENOUGH_ARGUMENTS_STRING);
        }
    }
}
