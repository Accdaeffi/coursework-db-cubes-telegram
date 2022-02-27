using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class AddMeasure : AbstractCommand
    {
        String measure;

        public AddMeasure(long userId, String measure)
        {
            this.measure = measure;
            this.userId = userId;
        }

        public override StringResponse<String> execute()
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

            return new StringResponse<String>(responseString);
        }
    }
}
