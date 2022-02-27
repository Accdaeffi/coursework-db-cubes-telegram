using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.delCommands
{
    class DelMeasure : AbstractCommand
    {
        String measure;

        public DelMeasure(String measure, long userId)
        {
            this.measure = measure;
            this.userId = userId;
        }

        public override AbstractResponse<String> execute()
        {
            String responseString;

            QueryConstructor info = MapUserInformation.FindValue(userId);

            if (info == null)
            {
                responseString = "Create query first using /create command!";
            }
            else
            {
                if (info.DelMeasure(measure))
                {
                    responseString = "Succesfully deleted!";
                }
                else
                {
                    responseString = "No such measure!";
                }
            }

            return new StringResponse<String>(responseString);
        }
    }
}
