using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class ShowQueryCommand : AbstractCommand
    {
        public ShowQueryCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse execute()
        {
            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            return new StringResponse(queryConstructor.ShowAll());
        }
    }
}
