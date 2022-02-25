using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.query
{
    class MapUserInformation
    {
        static Dictionary<long, QueryConstructor> data = new Dictionary<long, QueryConstructor>();

        public static bool CreateValue(long userId)
        {
            QueryConstructor info = new QueryConstructor();
            return data.TryAdd(userId, info);
        }

        public static QueryConstructor FindValue(long userId)
        {
            QueryConstructor info = null;
            data.TryGetValue(userId, out info);

            return info;
        }

        public static bool eleteValue(long userId)
        {
            return data.Remove(userId);
        }

    }
}
