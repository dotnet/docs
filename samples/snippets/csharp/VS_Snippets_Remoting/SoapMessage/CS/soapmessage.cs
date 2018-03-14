// System.Web.Services.Protocols.SoapMessage
// System.Web.Services.Protocols.SoapMessage.Action
// System.Web.Services.Protocols.SoapMessage.ContentType
// System.Web.Services.Protocols.SoapMessage.OneWay
// System.Web.Services.Protocols.SoapMessage.Url
// System.Web.Services.Protocols.SoapMessage.GetInParameterValue(int)
// System.Web.Services.Protocols.SoapMessage.MethodInfo
// System.Web.Services.Protocols.SoapMessage.GetOutParameterValue(int)
// System.Web.Services.Protocols.SoapMessage.GetReturnValue()

/*
   The following example demonstrates various members of the SoapMessage
   class. The program extends the SoapExtension class to create a class 
   that is used to log the SOAP messages transferred for an XML Web service
   method invocation. Whenever this method is invoked on the client side,
   all the SOAP messages that get transfered both from the client and the 
   server are written into a log file. 
*/

using System;
using System.IO;
using System.Web.Services.Protocols;
using System.Web.Services;

public class MySoapExtension : SoapExtension 
{
   Stream oldStream;
   Stream newStream;
   string filename;

   // Return the file name that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo methodInfo,
      SoapExtensionAttribute attribute) 
   {
      return ((MySoapExtensionAttribute)attribute).Filename;
   }

   // Return the file name that is to log the SOAP messages.
   public override object GetInitializer(Type filename) 
   {
      return (Type) filename;
   }

   // Save the name of the log file that will save the SOAP messages.
   public override void Initialize(object initializer) 
   {
      filename = (string) initializer;
   }
// <Snippet1>
   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage message) 
   {
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            WriteOutputBeforeSerialize(message);
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutputAfterSerialize(message);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInputBeforeDeserialize(message);
            break;
         case SoapMessageStage.AfterDeserialize:
            WriteInputAfterDeserialize(message);
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutputBeforeSerialize(SoapMessage message)
   {
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
         + DateTime.Now);
// <Snippet7>
      myStreamWriter.WriteLine("The method that has been invoked is: ");
      myStreamWriter.WriteLine("\t" + message.MethodInfo);
// </Snippet7>
// <Snippet2>
      myStreamWriter.WriteLine(
         "The contents of the SOAPAction HTTP header is:");
      myStreamWriter.WriteLine("\t" + message.Action);
// </Snippet2>
// <Snippet3>
      myStreamWriter.WriteLine("The contents of HTTP Content-type header is:");
      myStreamWriter.WriteLine("\t" + message.ContentType);
// </Snippet3>
// <Snippet4>
      if(message.OneWay)
         myStreamWriter.WriteLine(
            "The method invoked on the client shall not wait"
            + " till the server finishes");
      else
         myStreamWriter.WriteLine(
            "The method invoked on the client shall wait"
            + " till the server finishes");
// </Snippet4>
// <Snippet5>
      myStreamWriter.WriteLine(
         "The site where the XML Web service is available is:");
      myStreamWriter.WriteLine("\t" + message.Url);
// </Snippet5>
// <Snippet6>
      myStreamWriter.WriteLine("The values of the in parameters are:");
      myStreamWriter.WriteLine("Value of first in parameter: {0}",
         message.GetInParameterValue(0));
      myStreamWriter.WriteLine("Value of second in parameter: {0}",
         message.GetInParameterValue(1));
// </Snippet6>
      myStreamWriter.WriteLine();
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputAfterDeserialize(SoapMessage message)
   {
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine();
// <Snippet8>
      myStreamWriter.WriteLine("The values of the out parameter are:");
      myStreamWriter.WriteLine("The value of the out parameter is: {0}",
         message.GetOutParameterValue(0));
// </Snippet8>
// <Snippet9>
      myStreamWriter.WriteLine("The values of the return parameter are:");
      myStreamWriter.WriteLine("The value of the return parameter is: {0}",
         message.GetReturnValue());
// </Snippet9>
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }

// </Snippet1>

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutputAfterSerialize(SoapMessage message)
   {
      newStream.Position = 0;
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.Flush();
      Copy(newStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      newStream.Position = 0;
      Copy(newStream, oldStream);
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputBeforeDeserialize(SoapMessage message)
   {
      Copy(oldStream, newStream);
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("---------------------------------- Response at " 
         + DateTime.Now);
      myStreamWriter.Flush();
      newStream.Position = 0;
      Copy(newStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      newStream.Position = 0;
   }

   // Return a new MemoryStream for SOAP processing.
   public override Stream ChainStream( Stream stream )
   {
      oldStream = stream;
      newStream = new MemoryStream();
      return newStream;
   }

   // Utility method to copy the contents of one stream to another. 
   void Copy(Stream fromStream, Stream toStream) 
   {
      TextReader myTextReader = new StreamReader(fromStream);
      TextWriter myTextWriter = new StreamWriter(toStream);
      myTextWriter.WriteLine(myTextReader.ReadToEnd());
      myTextWriter.Flush();
   }
}

// A SoapExtensionAttribute that can be associated with an XML 
// Web service method.
[AttributeUsage(AttributeTargets.Method)]
public class MySoapExtensionAttribute : SoapExtensionAttribute
{
   private string myFilename;
   private int myPriority;

   // Set the name of the log file where SOAP messages will be stored.
   public MySoapExtensionAttribute() : base()
   {
      myFilename = "C:\\logClient.txt";
   }

   // Return the type of MySoapExtension.
   public override Type ExtensionType
   {
      get
      {
         return typeof(MySoapExtension);
      }
   }

   // User can set priority of the SoapExtension.
   public override int Priority 
   {
      get 
      {
         return myPriority;
      }
      set 
      { 
         myPriority = value;
      }
   }

   public string Filename 
   {
      get
      {
         return myFilename;
      }
      set
      {
         myFilename = value;
      }
   }
}

public class MySoapHeader : SoapHeader
{
   public string text;
}

[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap",
    Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   public MySoapHeader mySoapHeader;
   
   [SoapHeaderAttribute("mySoapHeader", Direction=SoapHeaderDirection.In)]
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
      "http://tempuri.org/Add",
      Use=System.Web.Services.Description.SoapBindingUse.Literal,
      ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [MySoapExtensionAttribute()]
   public System.Single Add(System.Single xValue, System.Single yValue,
      out System.Single returnValue) 
   {
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This is the first SOAP header";
      object[] results = this.Invoke("Add", 
         new object[] {xValue, yValue});
      returnValue = (System.Single)results[1];
      return ((System.Single)(results[0]));
   }

   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapMessage.cs.asmx";
   }

   public System.IAsyncResult BeginAdd(System.Single xValue,
      System.Single yValue, System.AsyncCallback callback,
      object asyncState) 
   {
      return this.BeginInvoke("Add", 
         new object[] {xValue, yValue}, callback, asyncState);
   }

   public System.Single EndAdd(System.IAsyncResult asyncResult,
      out System.Single returnValue) 
   {
      object[] results = this.EndInvoke(asyncResult);
      returnValue = (System.Single)results[1];
      return ((System.Single)(results[0]));
   }
}
