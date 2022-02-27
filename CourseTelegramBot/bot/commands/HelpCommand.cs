using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class HelpCommand : AbstractCommand
    {
        readonly String HELP_STRING = "https://telegra.ph/help-dlya-CourseworkDbCubeBot-02-27";

        public override AbstractResponse<string> execute()
        {
            return new StringResponse<String>(HELP_STRING);
        }
    }
}
