using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.delCommands
{
    class DelField : AbstractCommand
    {
        String field;

        public DelField(String field, long userId)
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
                if (info.DelField(field))
                {
                    responseString = "Succesfully deleted!";
                }
                else
                {
                    responseString = "No such field!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
