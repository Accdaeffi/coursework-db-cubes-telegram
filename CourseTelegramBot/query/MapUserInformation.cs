using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.query
{
    class MapUserInformation
    {
        static readonly Dictionary<long, QueryConstructor> data = new Dictionary<long, QueryConstructor>();

        public static void CreateValue(long userId)
        {
            QueryConstructor info = new QueryConstructor();
            data.Add(userId, info);
        }

        public static QueryConstructor FindValue(long userId)
        {
            QueryConstructor info = null;
            data.TryGetValue(userId, out info);

            return info;
        }

        public static bool DeleteValue(long userId)
        {
            return data.Remove(userId);
        }

    }
}
