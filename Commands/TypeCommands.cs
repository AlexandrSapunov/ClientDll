using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public enum TypeCommand
    {
        Empty = -3,
        Unknow = -2,
        BadCommand = -1,
        Send,
        SetIp,
        SetName,

        [Single]
        Connect,

        [Single]
        Disconnect,

        [Single]
        Help,

        [Single]
        Status,

        [Single]
        Exit,
    }
}
