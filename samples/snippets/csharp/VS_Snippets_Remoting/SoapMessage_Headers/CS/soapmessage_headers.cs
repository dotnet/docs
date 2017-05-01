// System.Web.Services.Protocols.SoapMessage.Headers
// System.Web.Services.Protocols.SoapMessage.Stream

/*
   The following example demonstrates the 'Headers' and 'Stream' properties 
   of the 'SoapMessage' class. The program extends the 
   'SoapExtension' class to create a class that is used to log the 
   SOAP messages transferred for a web service method invocation. 
   Whenever this method is invoked on the client side all the SOAP 
   message that get transfered both from the client and the server 
   are written into a log file. 
*/

using System;
using System.IO;
using System.Web.Services.Protocols;
using System.Web.Services;

public class MySoapExtension : SoapExtension 
{
   Stream myOldStream;
   Stream myNewStream;
   string myFileName;

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo 
      myMethodInfo, SoapExtensionAttribute mySoapExtensionAttributeObject) 
   {
      return ((MySoapExtensionAttribute)mySoapExtensionAttributeObject).Filename;
   }

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(Type myFileName) 
   {
      return (Type) myFileName;
   }

   // Save the name of the log file that shall save the SOAP messages.
   public override void Initialize(object myInitializer) 
   {
      myFileName = (string) myInitializer;
   }

   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage myMessage) 
   {
      switch (myMessage.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            WriteOutputBeforeSerialize(myMessage);
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutputAfterSerialize(myMessage);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInputBeforeDeserialize(myMessage);
            break;
         case SoapMessageStage.AfterDeserialize:
            WriteInputAfterDeserialize(myMessage);
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

// <Snippet1>
   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutputBeforeSerialize(SoapMessage myMessage)
   {
      FileStream myFileStream = 
         new FileStream(myFileName,FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "================================== Request at "+ DateTime.Now);

      myStreamWriter.WriteLine("The values of the in parameters are:");
      myStreamWriter.WriteLine("Value of first in parameter: {0}",
                                 myMessage.GetInParameterValue(0));
      myStreamWriter.WriteLine("Value of second in parameter: {0}",
                                 myMessage.GetInParameterValue(1));

      myStreamWriter.Write("Number of headers for the current request: ");
      myStreamWriter.WriteLine(myMessage.Headers.Count);

      myStreamWriter.WriteLine();
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }
// </Snippet1>

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputAfterDeserialize(SoapMessage myMessage)
   {
      FileStream myFileStream = 
         new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine();

      myStreamWriter.WriteLine("The values of the out parameter are:");
      myStreamWriter.WriteLine("The value of the out parameter is: {0}",
         myMessage.GetOutParameterValue(0));

      myStreamWriter.WriteLine("The values of the return parameter are:");
      myStreamWriter.WriteLine("The value of the return parameter is: {0}",
         myMessage.GetReturnValue());

      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutputAfterSerialize(SoapMessage myMessage)
   {
      myNewStream.Position = 0;
      FileStream myFileStream = 
         new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.Flush();
      Copy(myNewStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      myNewStream.Position = 0;
      Copy(myNewStream, myOldStream);
   }

// <Snippet2> 
   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputBeforeDeserialize(SoapMessage myMessage)
   {
      Copy(myOldStream, myNewStream);
      FileStream myFileStream = 
         new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "---------------------------------- Response at " + DateTime.Now);     
      Stream myStream = myMessage.Stream;
      myStreamWriter.Write("Length of data in the current response: ");
      myStreamWriter.WriteLine(myStream.Length);
      myStreamWriter.Flush();
      myNewStream.Position = 0;
      Copy(myNewStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      myNewStream.Position = 0;
   }
// </Snippet2>

   // Return a new MemoryStream for SOAP processing.
   public override Stream ChainStream( Stream myStream )
   {
      myOldStream = myStream;
      myNewStream = new MemoryStream();
      return myNewStream;
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

// A SoapExtensionAttribute that can be associated with an 
// XML Web service method.
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
   public string myText;
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
   public System.Single Add(System.Single xValue, 
      System.Single yValue,
      out System.Single returnValue) 
   {
      mySoapHeader = new MySoapHeader();
      mySoapHeader.myText = "This is the first SOAP header";
      object[] results = this.Invoke("Add", 
         new object[] {xValue, yValue});
      returnValue = (System.Single)results[1];
      return ((System.Single)(results[0]));
   }

   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/SoapMessage_Headers.cs.asmx";
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
