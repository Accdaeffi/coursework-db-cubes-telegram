using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class DelField : AbstractCommand
    {
        String field;

        public DelField(long userId, String field)
        {
            this.field = field;
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
                if (info.DelField(field))
                {
                    responseString = "Succesfully deleted!";
                }
                else
                {
                    responseString = "No such field!";
                }
            }

            return new StringResponse<String>(responseString);
        }
    }
}
