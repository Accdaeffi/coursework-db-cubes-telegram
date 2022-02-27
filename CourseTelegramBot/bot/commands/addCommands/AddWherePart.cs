using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class AddWherePart : AbstractCommand
    {
        String wherePart;

        public AddWherePart(long userId, String wherePart)
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
                if (info.AddWherePart(wherePart))
                {
                    responseString = "Succesfully added!";
                }
                else
                {
                    responseString = "Such where clause already exists!";
                }
            }

            return new StringResponse<String>(responseString);
        }
    }
}
