using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class CreateCommand : AbstractCommand
    {
        public CreateCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse execute()
        {
            MapUserInformation.CreateValue(userId);

            return new StringResponse("Запрс успешно создан!");
        }
    }
}
