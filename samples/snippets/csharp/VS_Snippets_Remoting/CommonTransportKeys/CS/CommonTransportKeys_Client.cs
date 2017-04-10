/*
   Supporting file: Client
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Logging;

public class Client
{
    public static void Main()
    {
       try
       {
          RemotingConfiguration.Configure("channels.config");
          RemotingConfiguration.Configure("client.exe.config");

          Foo server = new Foo();     
          // Call share method. 
          server.PrintString("String logged to console.");
          Console.WriteLine("Connected to server ...");
       }
       catch(Exception e)
       {
          Console.WriteLine("Exception :{0}" , e.Message );
       }
    }
}