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
                responseString = "Сначала создайте запрос командой /create !";
            }
            else
            {
                if (info.AddNewMeasure(field))
                {
                    responseString = "Успешно добавлено!";
                }
                else
                {
                    responseString = "Данное поле уже присутствует!";
                }
            }

            return new StringResponse(responseString);
        }
    }
}
