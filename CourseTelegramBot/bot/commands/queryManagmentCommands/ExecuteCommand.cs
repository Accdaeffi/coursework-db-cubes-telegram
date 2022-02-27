using CourseTelegramBot.bot.responses;
using CourseTelegramBot.cubeConnection;
using CourseTelegramBot.query;
using System;

namespace CourseTelegramBot.bot.commands
{
    class ExecuteCommand : AbstractCommand
    {

        public ExecuteCommand(long userId)
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
                responseText = Connection.getConnection()
                                                    .executeQuery(queryConstructor.getQuery());

            }

            return new StringResponse<String>(responseText);
        }
    }
}
