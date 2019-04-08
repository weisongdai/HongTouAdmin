using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws.CommonWeb.Checks;

namespace Ws.CommonWeb.ObjectMap
{
    public class ObjectMap : IObjectMap
    {
        public T Map<T>(object inputObj) where T : class
        {
            Check.NotNull(inputObj, nameof(inputObj));

            //创建返回类型的对象
            var resultModel = Activator.CreateInstance<T>();
            //获取返回类型的信息
            var resultType = resultModel.GetType();
            //获取返回类型的属性
            var resultProperties = resultType.GetProperties();

            var inputType = inputObj.GetType();//获取输入对象的类型

            foreach (var property in resultProperties)
            {
                //输入的对象里去出对应的名称数据
                var inputProperty = inputType.GetProperty(property.Name);
                //如果没有该对象，或者类型不同 跳过
                if (inputProperty is null || property.PropertyType != inputProperty.PropertyType)
                    continue;
                //获取输入对象当前属性的值，--可能回去null
                var inputPropertyValue = inputProperty.GetValue(inputObj);
                //传给返回的对象， inputPropertyValue 可能为null，但仍然可以插入
                property.SetValue(resultModel, inputPropertyValue);

            }
            return resultModel;
        }
        public void Map<T>(IEnumerable<object> input, IEnumerable<T> output) where T : class
        {
            Check.NotNull(output, nameof(output));

            Parallel.ForEach(input, e =>
            {
                lock (output)
                {
                    output.ToList().Add(this.Map<T>(e));
                }
            });
        }
    }
}
