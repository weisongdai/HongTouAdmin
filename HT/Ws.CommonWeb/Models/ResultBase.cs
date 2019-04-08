using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.Models
{
    public abstract class ResultBase
    {
        protected ResultBase()
        {
        }
        protected ResultBase(short code, string msg, object data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
        public short Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
