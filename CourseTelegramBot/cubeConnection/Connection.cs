using Microsoft.AnalysisServices.AdomdClient;
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

        public List<CubeInfo> getCubesInforamtion() {

            List<CubeInfo> cubes = new List<CubeInfo>();

            foreach (CubeDef cube in connection.Cubes)
            {

                if (cube.Type != CubeType.Cube) continue;
                cubes.Add(new CubeInfo(cube));
            }

            return cubes;
        }

        public string executeQuery(string commandString)
        {
            StringBuilder sb = new StringBuilder();

            AdomdCommand command = new AdomdCommand(commandString, connection);
            var data = command.ExecuteReader();

            while (data.Read())
            {
                for (int i=0; i < data.FieldCount; i++)
                {
                    sb.Append(data[i]);
                    if (i+1 != data.FieldCount)
                    {
                        sb.Append(',');
                    } else
                    {
                        sb.AppendLine();
                    }
                }
            }
            data.Close();

            return sb.ToString();
        }
    }
}
