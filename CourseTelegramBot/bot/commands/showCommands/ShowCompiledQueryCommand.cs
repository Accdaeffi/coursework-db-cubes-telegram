using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class ShowCompiledQueryCommand : AbstractCommand
    {
        public ShowCompiledQueryCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse<String> execute()
        {
            StringResponse<String> stringResponse;

            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            String compiledQuery = queryConstructor.getQuery();

            if (compiledQuery != null)
            {
                stringResponse = new StringResponse<String>(compiledQuery);
            }
            else
            {
                stringResponse = new StringResponse<String>("No compiled query!");
            }

            return stringResponse;
        }
    }
}
