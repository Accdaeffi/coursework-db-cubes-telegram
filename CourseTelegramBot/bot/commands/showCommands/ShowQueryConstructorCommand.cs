using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class ShowQueryConstructorCommand : AbstractCommand
    {
        public ShowQueryConstructorCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse<String> execute()
        {
            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            return new StringResponse<String>(queryConstructor.ShowAll());
        }
    }
}
