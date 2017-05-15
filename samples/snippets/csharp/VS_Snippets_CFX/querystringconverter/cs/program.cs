using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace QueryStringConverterSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
            // <Snippet1>
            QueryStringConverter converter = new QueryStringConverter();
            // </Snippet1>
            // <Snippet2>
            if (converter.CanConvert(typeof(Int32)))
                converter.ConvertStringToValue("123", typeof(Int32));
            // </Snippet2>
            // <Snippet3>
            int value = 321;
            string strValue = converter.ConvertValueToString(value, typeof(Int32));
            Console.WriteLine("the value = {0}, the string representation of the value = {1}", value, strValue);
            // </Snippet3>
            // </Snippet0>
        }
    }
}
