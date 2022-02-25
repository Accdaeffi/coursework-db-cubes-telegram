using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.delCommands
{
    class DelWherePart : AbstractCommand
    {
        String wherePart;

        public DelWherePart(String wherePart, long userId)
        {
            this.wherePart = wherePart;
            this.userId = userId;
        }

        public override StringResponse execute()
        {
            String responseString;

            QueryConstructor info = MapUserInformation.FindValue(userId);

            if (info == null)
            {
                responseString = "Create query first using /create command!";
            }
            else
            {
                if (info.DelWherePart(wherePart))
                {
                    responseString = "Succesfully deleted!";
                }
                else
                {
                    responseString = "No such where clause!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
