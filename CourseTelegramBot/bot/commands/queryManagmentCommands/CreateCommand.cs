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
        string cubeName;

        public CreateCommand(long userId, String cubeName)
        {
            this.userId = userId;
            this.cubeName = cubeName;
        }

        public override StringResponse<String> execute()
        {
            MapUserInformation.CreateValue(userId, cubeName);

            return new StringResponse<String>("Query succesfully created!");
        }
    }
}
