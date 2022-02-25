using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.query
{
    class NoColumnsException : Exception
    {
        public NoColumnsException(string message) : base(message)
        {
        }
    }
}
