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

        public static bool CreateValue(long userId, string cubeName)
        {
            QueryConstructor info = new QueryConstructor(cubeName);
            return data.TryAdd(userId, info);
        }

        public static QueryConstructor FindValue(long userId)
        {
            QueryConstructor info;
            data.TryGetValue(userId, out info);

            return info;
        }

        public static bool DeleteValue(long userId)
        {
            return data.Remove(userId);
        }

    }
}
