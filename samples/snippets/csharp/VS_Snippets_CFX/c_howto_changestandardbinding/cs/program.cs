//<snippet0>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Samples
{
    class ChangeStandardBinding
    {
        static void Main(string[] args)
        {
            //<snippet1>
            //  Create an instance of the T:System.ServiceModel.BasicHttpBinding
            //  class and set its security mode to message-level security.
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
            binding.Security.Mode = BasicHttpSecurityMode.Message;
            //</snippet1>

            //<snippet2>
            //  Create a custom binding from the binding
            CustomBinding cb = new CustomBinding(binding);
            //  Get the BindingElementCollection from this custom binding
            BindingElementCollection bec = cb.Elements();
            //</snippet2>

            //<snippet3>
            //  Loop through the collection, and when you find the HTTP binding element
            //  set its KeepAliveEnabled property to false
            foreach (BindingElement be in bec)
            {
                Type thisType = be.GetType();
                Console.WriteLine(thisType);
                if (be is HttpTransportBindingElement)
                {
                    HttpTransportBindingElement httpElement = (HttpTransportBindingElement)be;
                    Console.WriteLine($"\tBefore: HttpTransportBindingElement.KeepAliveEnabled = {httpElement.KeepAliveEnabled}");
                    httpElement.KeepAliveEnabled = false;
                    Console.WriteLine($"\tAfter:  HttpTransportBindingElement.KeepAliveEnabled = {httpElement.KeepAliveEnabled}");
                }
            }
            //</snippet3>
        }
    }
}
//</snippet0>
