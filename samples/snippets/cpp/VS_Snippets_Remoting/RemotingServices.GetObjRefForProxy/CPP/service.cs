using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;

namespace SampleNamespace {
    // Define the remote service class
    public class SampleService : MarshalByRefObject {
        public bool SampleMethod() {
            Console.WriteLine("Hello, you have called SampleMethod().");
            return true;
        }
    }
}
