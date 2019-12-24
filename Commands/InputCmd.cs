using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class InputCmd
    {
        public InputCmd(string input)
        {
            var command = Commands.GetCommand(input);

            switch (command.Type)
            {
                case TypeCommand.Send:
                    CommandWorker.Send(command.FullValue);
                    break;
                case TypeCommand.SetIp:
                    CommandWorker.SetIp(command.FullValue);
                    break;
                case TypeCommand.SetName:
                    if (command.Values.Length > 1)
                    {
                        Console.WriteLine("ERROR New name can not be with spaced");
                        break; ;
                    }
                    CommandWorker.SetName(command.FullValue);
                    break;
                case TypeCommand.Connect:
                    CommandWorker.Connect();
                    break;
                case TypeCommand.Disconnect:
                    CommandWorker.Disconnect();
                    break;
                case TypeCommand.Help:
                    CommandWorker.Help();
                    break;
                case TypeCommand.Status:
                    CommandWorker.Status();
                    break;
                case TypeCommand.Exit:
                    CommandWorker.Exit();
                    break;
                default:
                    break;
            }
        }
    }
}
