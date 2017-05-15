// This is the implementation class for the remote object.

using System;

    public class MyServerImpl :MarshalByRefObject
    {
        public MyServerImpl()
        {
        }

        public String MyMethod(String name)
        {
            return "The string from client is " + name;
        }
    }

