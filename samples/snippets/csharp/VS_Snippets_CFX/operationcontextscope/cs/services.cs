// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Namespace="http://Microsoft.WCF.Documentation", 
    CallbackContract=typeof(IClientCallbackContract), 
    SessionMode=SessionMode.Required
  )]
  public interface ISampleService{
    [OperationContract(IsOneWay=true)]
    void Push(string msg);
  }

  interface IClientCallbackContract
  {
    [OperationContract(IsOneWay = true)]
    void PushBack(string msg);
  }

  // <snippet2>
  class SampleService : ISampleService
  {
  #region ISampleService Members

    public void Push(string msg)
    {
 	    Console.WriteLine("Proxy: " + msg);
      this.WriteHeaders(OperationContext.Current.IncomingMessageHeaders);
      MessageHeader outBoundHeader
        = MessageHeader.CreateHeader(
          "Client-Bound-One-Way-Header", 
          "http://Microsoft.WCF.Documentation", 
          "Custom Outbound Header"
        );
      OperationContext.Current.OutgoingMessageHeaders.Add(outBoundHeader);
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("OutgoingHeader:");
      Console.Write("\t");
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine(outBoundHeader.ToString());
      Console.ResetColor();
      OperationContext.Current.GetCallbackChannel<IClientCallbackContract>().PushBack("Here's something to examine in response.");
    }

    void WriteHeaders(MessageHeaders headers)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("IncomingHeader:");
      Console.ForegroundColor = ConsoleColor.Blue;
      foreach (MessageHeaderInfo h in headers)
      {
        if (!h.Actor.Equals(String.Empty))
          Console.WriteLine("\t" + h.Actor);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t" + h.Name);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\t" + h.Namespace);
        Console.WriteLine("\t" + h.Relay);
        if (h.IsReferenceParameter == true)
        {
            Console.WriteLine("IsReferenceParameter header detected: " + h.ToString());
        }
      }
      Console.ResetColor();
    }
    // </snippet2>

  #endregion
  }
}
// </snippet1>