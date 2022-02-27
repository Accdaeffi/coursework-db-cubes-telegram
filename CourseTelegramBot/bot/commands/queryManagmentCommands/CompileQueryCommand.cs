using CourseTelegramBot.bot.responses;
using CourseTelegramBot.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    class CompileQueryCommand : AbstractCommand
    {

        public CompileQueryCommand(long userId)
        {
            this.userId = userId;
        }

        public override StringResponse<String> execute()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Compiled query:");
            sb.AppendLine();

            QueryConstructor queryConstructor = MapUserInformation.FindValue(userId);

            if (queryConstructor == null)
            {
                sb.Clear().AppendLine("Create query first using /create command!");
            }
            else
            {

                try
                {
                    sb.AppendLine(queryConstructor.CompileQuery());
                }
                catch (NoColumnsException ex)
                {
                    sb.Clear().AppendLine(ex.Message);
                }
            }

            return new StringResponse<String>(sb.ToString());
        }
    }
}
