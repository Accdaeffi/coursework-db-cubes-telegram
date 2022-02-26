using CourseTelegramBot.bot.responses;
using CourseTelegramBot.cubeConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot.commands.showCommands
{
    class ShowCubeInfoCommand : AbstractCommand
    {
        private string cubeName;
        public ShowCubeInfoCommand(long userId, string cubeName)
        {
            this.userId = userId;
            this.cubeName = cubeName;
        }

        public override StringResponse execute()
        {
            String responseText;
            List<CubeInfo> cubes = Connection.getConnection().getCubesInforamtion();

            if (cubes.Count > 0)
            {
                if (cubeName != null && cubes.Any(c => c.getName() == cubeName))
                {
                    responseText = cubes.Find(c => c.getName() == cubeName).generateText();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (CubeInfo cube in cubes)
                    {
                        sb.AppendLine(cube.generateText());

                    }

                    responseText = sb.ToString();
                }
            }
            else
            {
                responseText = "No cubes!";
            }

            return new StringResponse(responseText);
        }
    }
}
