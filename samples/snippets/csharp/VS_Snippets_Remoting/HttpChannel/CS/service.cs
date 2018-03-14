using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;

namespace SampleNamespace {

    // Define the event arguments
    [Serializable]
    public class SampleServiceEventArgs : EventArgs {
        private string m_Message;

        public SampleServiceEventArgs(string message) {
            m_Message = message;
        }

        public string Message {
            get {
                return m_Message;
            }
        }
    }
    
    // Define the delegate for the event
    public delegate void SomethingHappenedEventHandler (object sender, SampleServiceEventArgs e);

    // Define the remote service class
    public class SampleService : MarshalByRefObject {

        // The client will subscribe and unsubscribe to this event
        public event SomethingHappenedEventHandler SomethingHappened;

        public bool SampleMethod() {

            Console.WriteLine("Hello, you have called SampleMethod().");

            // Fire Event
            if (SomethingHappened != null) {
                // Package String in TimerServiceEventArgs
                SampleServiceEventArgs sampleEventArgs = new SampleServiceEventArgs("Something happened");
                Console.WriteLine("Firing SomethingHappened Event");
                SomethingHappened(this, sampleEventArgs);
            }
            return true;
        }
    }
}

