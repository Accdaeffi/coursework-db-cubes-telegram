using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class AddField : AbstractCommand
    {
        String field;

        public AddField(long userId, String field)
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
                String selector = null;

                if (field.LastIndexOf(' ') > field.LastIndexOf(']'))
                {
                    selector = field.Substring(field.LastIndexOf(' ')).Trim();
                    field = field.Substring(0, field.LastIndexOf(' ')).Trim();
                }


                if (info.AddNewField(field, selector))
                {
                    responseString = "Succesfully added!";
                }
                else
                {
                    responseString = "Such field already exists!";
                }
            }

            return new StringResponse<String>(responseString);
        }
    }
}
