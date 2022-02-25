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
                responseString = "Create query first!";
            } else
            {
                bool result = info.AddNewMeasure(measure);
                if (result)
                {

                }
            }

            throw new NotImplementedException();
        }
    }
}
