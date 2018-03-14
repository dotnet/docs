using System;

    public class MyServerImpl :MarshalByRefObject 
      {
         int i;
        public MyServerImpl()
        {
            i=0;
            Console.WriteLine("Server Activated...");
        }

        public String MyMethod(String name) 
        {
         i=i+1;
            return "The client requests to "+name +i+" time";
        }
    }


