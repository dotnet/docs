using System;
namespace Share
{
 public class MyHelloService : MarshalByRefObject
{
       public string myFunction(string myName)
        {
            string myMessage = "Hi there " + myName + ", you are using .NET Remoting";
            Console.WriteLine(myMessage );
            return myMessage ;
        }
}
}