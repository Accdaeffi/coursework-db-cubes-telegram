using CourseTelegramBot.bot.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTelegramBot.bot
{
    class MessageParser
    {
        private static MessageParser parser = null;

        private MessageParser()
        {

        }

        public static MessageParser getParser()
        {
            if (parser == null)
            {
                parser = new MessageParser();
            } 

            return parser;
        }

        public AbstractCommand parseMessage(long userId, String message)
        {
            AbstractCommand result;

            String[] messageArray = message.Split(' ', 2);
            String command = messageArray[0].Trim();
            String argument = null;
            if (messageArray.Length > 1)
            {
                argument = messageArray[1].Trim();
            }

            try
            {

                switch (command)
                {
                    case "/start":
                        {
                            result = new StartCommand();
                        }
                        break;
                    case "/help":
                        {
                            result = new HelpCommand();
                        }
                        break;

                    #region query managment commands
                    case "/create_query":
                        {
                            if (argument != null)
                            {
                                result = new CreateCommand(userId, argument);
                            } else
                            {
                                throw new NotEnoughArgumentsException();
                            }
                        }
                        break;
                    case "/delete_query":
                        {
                            result = new DeleteCommand(userId);
                        }
                        break;
                    case "/compile_query":
                        {
                            result = new CompileQueryCommand(userId);
                        }
                        break;
                    case "/execute_query":
                        {
                            result = new ExecuteCommand(userId);
                        }
                        break;

                    #endregion

                    #region show commands
                    case "/show_cubes":
                        {
                            if (argument != null)
                            {
                                result = new ShowCubeInfoCommand(userId, argument);
                            } else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    case "/show_query_constructor":
                        {
                            result = new ShowQueryConstructorCommand(userId);
                        }
                        break;
                    case "/show_compiled_query":
                        {
                            result = new ShowCompiledQueryCommand(userId);
                        }
                        break;
                    #endregion

                    #region add commands
                    case "/add_field":
                        {
                            if (argument != null)
                            {
                                result = new AddField(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    case "/add_measure":
                        {
                            if (argument != null)
                            {
                                result = new AddMeasure(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    case "/add_wherePart":
                        {
                            if (argument != null)
                            {
                                result = new AddWherePart(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;

                    #endregion

                    #region delete commands
                    case "/del_field":
                        {
                            if (argument != null)
                            {
                                result = new DelField(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    case "/del_measure":
                        {
                            if (argument != null)
                            {
                                result = new DelMeasure(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    case "/del_wherePart":
                        {
                            if (argument != null)
                            {
                                result = new DelWherePart(userId, argument);
                            }
                            else
                            {
                                result = new ShowCubeInfoCommand(userId);
                            }
                        }
                        break;
                    #endregion

                    default:
                        {
                            result = new UnknownCommand();
                        }
                        break;
                }
            }
            catch (NotEnoughArgumentsException)
            {
                result = new NotEnoughArgumentsCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = new ExceptionCommand();
            }

            return result;
        }

    }
}
