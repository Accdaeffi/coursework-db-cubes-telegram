using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class DeleteCommand : AbstractCommand
    {

        public DeleteCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse<String> execute()
        {
            String responseText;

            if (MapUserInformation.DeleteValue(userId))
            {
                responseText = "Query succesfully deleted!";
            } else
            {
                responseText = "Can't find query!";
            }

            return new StringResponse<String>(responseText);
        }
    }
}
