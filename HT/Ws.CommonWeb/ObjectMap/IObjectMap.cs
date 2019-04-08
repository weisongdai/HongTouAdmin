using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.ObjectMap
{
    public interface IObjectMap
    {
        T Map<T>(object value) where T : class;
        void Map<T>(IEnumerable<object> input, IEnumerable<T> output) where T : class;
    }
}
