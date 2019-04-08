using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.Models
{
    public class ResultModel : ResultBase
    {
        public ResultModel()
        {

        }
        public ResultModel(string msg)
        {
            this.Code = 0;
            this.Msg = msg;
        }
        public ResultModel(short code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }
        public ResultModel(short code, string msg, object data)
        {
            this.Data = data;
            this.Code = code;
            this.Msg = msg;
        }
    }
}
