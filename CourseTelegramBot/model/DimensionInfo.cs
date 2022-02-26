using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.cubeConnection
{
    class DimensionInfo
    {
        internal String name;
        internal List<String> Hierarchies = new List<string>();

        internal DimensionInfo(Dimension dim)
        {
            name = dim.Name;

            foreach (Hierarchy hie in dim.Hierarchies)
            {
                Hierarchies.Add(hie.Name);
            }
        }
    }
}
