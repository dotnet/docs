using System;

    public class MyServerImpl :MarshalByRefObject
      {
        public MyServerImpl()
        {
            Console.WriteLine("Server Activated...");
        }

        public String MyMethod(String name)
        {
            return "The client requests to "+name;
        }
    }
