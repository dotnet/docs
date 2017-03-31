using System;
using System.IO;
using System.Collections;
using System.Runtime.Remoting;

namespace SampleNamespace {
    public class SampleWellKnown : MarshalByRefObject {
        public int State = 0;
        
        public int Add(int a, int b) {
            Console.WriteLine("Add method called");
            return a + b;
        }
    }
}
