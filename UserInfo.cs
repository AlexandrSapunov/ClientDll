using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class UserInfo
    {
        public static string Name { get; set; }
        public static string Ip { get; set; }

        public static int Port = 8080;
        public static DateTime ConnectFirstTime { get; set; }
    }
}
