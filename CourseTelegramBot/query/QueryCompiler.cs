using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.query
{
    class QueryCompiler
    {
        public static String compileQuery(HashSet<String> measures, HashSet<String> fields, HashSet<String> whereParts)
        {
            bool haveColumns = false;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT");

            if (measures.Count > 0)
            {
                haveColumns = true;
                sb.Append(" {");
                sb.AppendJoin(',', measures);
                sb.Append("}");

                sb.Append(" ON COLUMNS");
            }

            if (fields.Count > 0)
            {
                if (!haveColumns)
                {
                    throw new NoColumnsException("You need to select at least one measure!");
                }

                sb.Append(", {");
                sb.AppendJoin(',', fields);
                sb.Append("}");

                sb.Append(" ON ROWS");
            }

            sb.Append(" FROM [sickness_cube]");

            if (whereParts.Count > 0)
            {
                sb.Append(" WHERE ");
                sb.Append(" {");
                sb.AppendJoin(',', whereParts);
                sb.Append("}");
            }

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }
    }
}
