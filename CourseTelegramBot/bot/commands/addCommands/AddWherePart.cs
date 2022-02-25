using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.addCommands
{
    class AddWherePart : AbstractCommand
    {
        String wherePart;

        public AddWherePart(String wherePart, long userId)
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
                if (info.AddNewMeasure(wherePart))
                {
                    responseString = "Succesfully added!";
                }
                else
                {
                    responseString = "Such where clause already exists!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
