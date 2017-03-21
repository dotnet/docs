using System;
using System.Collections;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using Share;	

namespace MyNameSpace
{
   
   public class MyProxy : RealProxy
   {
      string myUrl;
      string myObjectURI;
      IMessageSink myMessageSink;

      [PermissionSet(SecurityAction.LinkDemand)]
      public MyProxy(Type myType, string myUrl1)
         : base(myType)
      {
         
         myUrl = myUrl1;

         IChannel[] myRegisteredChannels = ChannelServices.RegisteredChannels;
         foreach (IChannel channel in myRegisteredChannels )
         {
            if (channel is IChannelSender)
            {
               IChannelSender myChannelSender = (IChannelSender)channel;

               myMessageSink = myChannelSender.CreateMessageSink(myUrl, null, out myObjectURI);
               if (myMessageSink != null)
                  break;
            }
         }

         if (myMessageSink == null)
         {
            throw new Exception("A supported channel could not be found for myUrl1:"+ myUrl);
         }
      }

      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
      public override IMessage Invoke(IMessage myMesg)
      {
         Console.WriteLine("MyProxy.Invoke Start");

         if (myMesg is IMethodCallMessage)
            Console.WriteLine("IMethodCallMessage");

         if (myMesg is IMethodReturnMessage)
            Console.WriteLine("IMethodReturnMessage");

         Console.WriteLine("Message Properties");
         IDictionary myDictionary = myMesg.Properties;
         IDictionaryEnumerator myEnum = (IDictionaryEnumerator) myDictionary.GetEnumerator();

         while (myEnum.MoveNext())
         {
            object myKey = myEnum.Key;
            string myKeyName = myKey.ToString();
            object myValue = myEnum.Value;

            Console.WriteLine("{0} : {1}", myKeyName, myEnum.Value);
            if (myKeyName == "__Args")
            {
               object[] myArgs = (object[])myValue;
               for (int myInt = 0; myInt < myArgs.Length; myInt++)
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs[myInt]);
            }

            if ((myKeyName == "__MethodSignature") && (null != myValue))
            {
               object[] myArgs = (object[])myValue;
               for (int myInt = 0; myInt < myArgs.Length; myInt++)
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs[myInt]);
            }
         }

         Console.WriteLine("myUrl1 {0} object URI{1}",myUrl,myObjectURI);

         myDictionary["__Uri"] = myUrl;
         Console.WriteLine("URI {0}", myDictionary["__URI"]);
         IMessage myRetMsg = myMessageSink.SyncProcessMessage(myMesg);

         if (myRetMsg is IMethodReturnMessage)
         {
            IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)myRetMsg;
         }

         Console.WriteLine("MyProxy.Invoke - Finish");
         return myRetMsg;
      }
   }

   //
   // Main class that drives the whole sample
   //
   public class ProxySample
   {
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main()
      {
         ChannelServices.RegisterChannel(new HttpChannel());

         Console.WriteLine("Remoting Sample:");

         Console.WriteLine("Generate a new MyProxy using the Type");
         Type myType = typeof(MyHelloService);
         string myUrl1 = "http://localhost/myServiceAccess.soap";
         MyProxy myProxy = new MyProxy(myType, myUrl1);

         Console.WriteLine("Obtain the transparent proxy from myProxy");
         MyHelloService myService = (MyHelloService)myProxy.GetTransparentProxy();

         Console.WriteLine("Calling the Proxy");
         string myReturnString = myService.myFunction("bill");

         Console.WriteLine("Checking result : {0}", myReturnString);

         if (myReturnString == "Hi there bill, you are using .NET Remoting")
         {
            Console.WriteLine("myService.HelloMethod PASSED : returned {0}", myReturnString);
         }
         else
         {
            Console.WriteLine("myService.HelloMethod FAILED : returned {0}", myReturnString);
         }
      }
   }
}
