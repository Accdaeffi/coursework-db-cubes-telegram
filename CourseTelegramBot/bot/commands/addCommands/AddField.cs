using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.addCommands
{
    class AddField : AbstractCommand
    {
        String field;

        public AddField(String field, long userId)
        {
            this.field = field;
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
                if (info.AddNewMeasure(field))
                {
                    responseString = "Succesfully added!";
                }
                else
                {
                    responseString = "Such field already exists!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
