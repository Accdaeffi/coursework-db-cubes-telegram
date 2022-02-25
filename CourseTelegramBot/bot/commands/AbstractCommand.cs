using CourseTelegramBot.bot.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands
{
    abstract class AbstractCommand
    {
        protected long userId;
        public abstract StringResponse execute();
    }
}
