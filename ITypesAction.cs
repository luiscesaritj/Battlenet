using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battlenet.Webapi.Hubs.Config
{
    public interface ITypesAction
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveMessage(string message);
    }
}
