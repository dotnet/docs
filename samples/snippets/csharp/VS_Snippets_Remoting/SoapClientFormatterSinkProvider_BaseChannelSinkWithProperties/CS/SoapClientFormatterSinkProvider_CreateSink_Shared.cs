/* This is supporting program for the 'SoapClientFormatterSinkProvider_CreateSink_Client'.
 */
using System;

public class HelloService : MarshalByRefObject
{
   public HelloService() 
   {
      Console.WriteLine("Server Started ");
   }

   public String HelloMethod(String name)
   {
        return "Hi, " + name ;
    }
}
