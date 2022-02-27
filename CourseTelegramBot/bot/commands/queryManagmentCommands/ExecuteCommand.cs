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
            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            return new StringResponse<String>(Connection.getConnection()
                                                    .executeQuery(queryConstructor.getQuery()));
        }
    }
}
