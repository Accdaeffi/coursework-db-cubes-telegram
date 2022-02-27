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
        private String cubeName;

        private readonly HashSet<String> measures = new HashSet<String>();
        private readonly HashSet<String> fields = new HashSet<String>();
        private readonly HashSet<String> whereParts = new HashSet<String>();

        private String query = null;

        internal QueryConstructor (String cubeName)
        {
            this.cubeName = cubeName;
        }

        #region show
        ///
        /// <summary>Show information about active params in query constructor</summary>
        ///
        /// <return>String with description</return>
        /// 
        public String ShowAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ShowMeasures());
            sb.AppendLine();
            sb.AppendLine(ShowFields());
            sb.AppendLine();
            sb.AppendLine(ShowWhereParts());

            return sb.ToString();
        }

        ///
        /// <summary>Show information about active measures in query constructor</summary>
        ///
        /// <return>String with description</return>
        /// 
        public String ShowMeasures()
        {
            StringBuilder sb = new StringBuilder();

            if (measures.Count > 0)
            {
                sb.AppendLine("Active Measures:");
                sb.AppendJoin('\n', measures);
            } else
            {
                sb.AppendLine("No active Measures!");
            }

            return sb.ToString();
        }

        ///
        /// <summary>Show information about active fields in query constructor</summary>
        ///
        /// <return>String with description</return>
        /// 
        public String ShowFields()
        {
            StringBuilder sb = new StringBuilder();

            if (fields.Count > 0)
            {
                sb.AppendLine("Active Fields:");
                sb.AppendJoin('\n', fields);
            } else
            {
                sb.AppendLine("No active Fields!");
            }

            return sb.ToString();
        }

        ///
        /// <summary>Show information about active where clauses in query constructor</summary>
        ///
        /// <return>String with description</return>
        /// 
        public String ShowWhereParts()
        {
            StringBuilder sb = new StringBuilder();

            if (whereParts.Count > 0)
            {
                sb.AppendLine("Active Where clauses:");
                sb.AppendJoin('\n', whereParts);
            } else
            {
                sb.AppendLine("No active Where clauses!");
            }

            return sb.ToString();
        }
        #endregion

        #region adding
        ///
        /// <summary>Add new column in query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if already exists</returns>
        /// 
        public bool AddNewMeasure(String measure)
        {
            /*
            /add_measure [Sickness Fact Count]
            */

            String bufferString = new String("[Measures]." + measure);

            return measures.Add(bufferString);

        }        
        
        ///
        /// <summary>Add new row in query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if already exists</returns>
        /// 
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
        /// <summary>Add new where clause in query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if already exists</returns>
        /// 
        public bool AddWherePart(String wherePart)
        {
            /*
            /add_where [full part of query] 
             */
            return whereParts.Add(wherePart);

        }

        #endregion

        #region removing
        ///
        /// <summary>Clear everything from query constructor</summary>
        ///
        public void Clear()
        {
            measures.Clear();
            fields.Clear();
            whereParts.Clear();
        }

        ///
        /// <summary>Delete column from query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if no such column</returns>
        /// 
        public bool DelMeasure(String measure)
        {
            return measures.Remove(measure);
        }

        ///
        /// <summary>Delete row from query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if no such row</returns>
        /// 
        public bool DelField(String fieldName)
        {
            return fields.Remove(fieldName);
        }

        ///
        /// <summary>Delete where clause from query constructor</summary>
        ///
        /// <returns>true, if succesfull, false if no such part</returns>
        /// 
        public bool DelWherePart(String wherePart)
        {
            return whereParts.Remove(wherePart);
        }
        #endregion

        public string CompileQuery()
        {
            query = QueryCompiler.compileQuery(measures, fields, whereParts);
            return query;
        }

        public String getQuery()
        {
            return query;
        }
    }
}
