using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.query
{
    class QueryConstructor
    {
        readonly HashSet<String> fields = new HashSet<String>();
        readonly HashSet<String> measures = new HashSet<String>();
        readonly HashSet<String> whereParts = new HashSet<String>();

        public bool AddNewField(String fieldName, String selector = null)
        {
            /*
            /add_column [Doctor Dim].[Id].[Andy A]
            /add_column [Doctor Dim].[Id] all
            */

            switch (selector) {
                case "all": fieldName = new String(fieldName+".MEMBERS");
                    break;
            }

            return fields.Add(fieldName);
        }

        ///
        /// <summary>Add new measure in query constructor</summary>
        ///

        public bool AddNewMeasure(String measure)
        {
            /*
            /add_measure [Sickness Fact Count]
            */

            String bufferString = new String("[Measures]." + measure);

            return measures.Add(bufferString);

        }

        public bool AddWherePart(String wherePart)
        {
            /*
            /add_where [full part of query] 
             */
            return whereParts.Add(wherePart);

        }

        public String CompileQuery()
        {
            return QueryCompiler.compileQuery(measures, fields, whereParts);
        }
    }
}
