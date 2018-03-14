using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Web;

namespace WebServiceHostSnippets
{
    class Snippets
    {
        public static object GetObject()
        {
            return new Object();
        }

        public static void Snippet1()
        {
            // <Snippet1>
            Uri[] baseAddresses = { new Uri("http://localhost/one"), new Uri("http://localhost/two") };
            object mySingleton = GetObject();
            WebServiceHost host = new WebServiceHost(mySingleton, baseAddresses);
            // </Snippet1>
        }

        public static void Snippet2()
        {
            // <Snippet2>
            Uri[] baseAddresses = { new Uri("http://localhost/one"), new Uri("http://localhost/two") };
            WebServiceHost host = new WebServiceHost(typeof(CalcService), baseAddresses);
            // </Snippet2>
        }

    }
}
