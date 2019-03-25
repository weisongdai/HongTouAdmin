using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ws.CommonWeb.Logger.IServices
{
    public interface ILoggerService
    {
        Task Log(string msg);
        Task Log(string msg, LogType logType, string requestPath, string ipAddress);
    }
}
