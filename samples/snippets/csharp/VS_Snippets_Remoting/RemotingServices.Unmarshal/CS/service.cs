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

        public ObjRef GetManuallyMarshaledObject() {
            SampleTwo objectTwo = new SampleTwo();
            ObjRef objRefTwo = RemotingServices.Marshal(objectTwo);
            return objRefTwo;
        }
    }

    public class SampleTwo : MarshalByRefObject {
        public void PrintMessage(string s) {
            Console.WriteLine("This message was received from the client:");
            Console.WriteLine("\t{0}", s);
        }
    }
}

