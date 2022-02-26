using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.cubeConnection
{
    class CubeInfo
    {
        string CubeName;
        List<DimensionInfo> Dimensions = new List<DimensionInfo>();
        List<String> Measures = new List<String>();

        internal CubeInfo (CubeDef cube)
        {
            CubeName = cube.Name;

            foreach (Dimension dim in cube.Dimensions)
            {
                if (dim.DimensionType != DimensionTypeEnum.Measure)
                {
                    Dimensions.Add(new DimensionInfo(dim));
                }
            }

            foreach (Measure measure in cube.Measures)
            {
                Measures.Add(measure.Name);
            }
        }

        public string getName()
        {
            return CubeName;
        }

        public String generateText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Cube: " + CubeName);

            foreach (DimensionInfo dim in Dimensions)
            {
                sb.AppendLine("└Dimension: " + dim.name);

                foreach (String hie in dim.Hierarchies)
                {
                    sb.AppendLine("   └Hierarchy: " + hie);
                }
            }

            sb.AppendLine("└Measures");
            foreach (String measure in Measures)
            {
                sb.AppendLine("   └Fact: " + measure);
            }

            return sb.ToString();
        }
    }
}
