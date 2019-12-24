using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public enum ConnectionStatuses
    {
        /// <summary>
        /// first execute application
        /// </summary>
        Idle,

        /// <summary>
        /// Disconnect
        /// </summary>
        Disconnect,

        /// <summary>
        /// Connect
        /// </summary>
        Connect,

        /// <summary>
        /// Try Connect
        /// </summary>
        TryConnect,

        /// <summary>
        /// If Time out, or bad connect
        /// </summary>
        FailConnect,
    }
}
