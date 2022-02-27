using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.queryManagmentCommands
{
    class CompileQuery : AbstractCommand
    {

        public CompileQuery(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse<String> execute()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Compiled query:");
            sb.AppendLine();

            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            sb.AppendLine(queryConstructor.CompileQuery());

            return new StringResponse<String>(sb.ToString());
        }
    }
}
