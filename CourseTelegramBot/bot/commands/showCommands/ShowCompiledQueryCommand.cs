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
            String responseText;

            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            if (queryConstructor == null)
            {
                responseText = "Create query first using /create command!";
            }
            else
            {
                String compiledQuery = queryConstructor.getQuery();
                if (compiledQuery != null)
                {
                    responseText = compiledQuery;
                }
                else
                {
                    responseText = "No compiled query!";
                }
            }
            return new StringResponse<String>(responseText);
        }
    }
}
