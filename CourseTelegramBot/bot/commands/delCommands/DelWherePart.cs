using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class DelWherePart : AbstractCommand
    {
        String wherePart;

        public DelWherePart(long userId, String wherePart)
        {
            this.wherePart = wherePart;
            this.userId = userId;
        }

        public override StringResponse<String> execute()
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

            return new StringResponse<String>(responseString);
        }
    }
}
