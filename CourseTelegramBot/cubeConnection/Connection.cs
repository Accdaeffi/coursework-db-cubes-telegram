﻿using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.cubeConnection
{
    class Connection
    {
        private static Connection singleton = null;

        private static readonly string connectionString = "Data Source=localhost;Catalog=course_work";
        private readonly AdomdConnection connection = new AdomdConnection(connectionString);
        private readonly CubeDef cube = null;


        private Connection()
        {
            connection.Open();
            cube = connection.Cubes[0];
        }

        public static Connection getConnection()
        {

            if (singleton == null)
            {
                singleton = new Connection();
            }

            return singleton;
        }


        public CubeDef getCube()
        {
            return cube;
        }

        public string getAllInforamtion() {

            StringBuilder sb = new StringBuilder();

            foreach (CubeDef cube in connection.Cubes)
            {
                if (cube.Type != CubeType.Cube) continue;
                sb.AppendLine("Cube: " + cube.Name);
                Console.WriteLine("Cube: " + cube.Name);

                foreach (Dimension dim in cube.Dimensions)
                {
                    if (dim.Name == "Measures") continue;
                    sb.AppendLine("  Dimension: " + dim.Name);
                    Console.WriteLine("  Dimension: " + dim.Name);

                    foreach (Hierarchy hie in dim.Hierarchies)
                    {
                        sb.AppendLine("\tHierarchy: " + hie.Name);
                        Console.WriteLine("\tHierarchy: " + hie.Name);
                    }
                }

                sb.AppendLine("  Measures");
                Console.WriteLine("  Measures");
                foreach (Measure measure in cube.Measures)
                {
                    sb.AppendLine("\tFact: " + measure);
                    Console.WriteLine("\tFact: " + measure);
                }
            }

            return sb.ToString();
        }
    }
}
