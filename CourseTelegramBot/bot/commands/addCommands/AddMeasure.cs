using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.addCommands
{
    class AddMeasure : AbstractCommand
    {
        String measure;

        public AddMeasure(String measure, long userId)
        {
            this.measure = measure;
            this.userId = userId;
        }

        public override StringResponse execute()
        {
            String responseString;

            QueryConstructor info = MapUserInformation.FindValue(userId);

            if (info == null)
            {
                responseString = "Create query first using /create command!";
            } else
            {
                if (info.AddNewMeasure(measure))
                {
                    responseString = "Succesfully added!";
                } else
                {
                    responseString = "Such measure already exists!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
