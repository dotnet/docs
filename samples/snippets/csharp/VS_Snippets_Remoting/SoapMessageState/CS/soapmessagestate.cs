// System.Web.Services.Protocols.SoapMessageState
// System.Web.Services.Protocols.SoapMessageState.AfterDeserialize
// System.Web.Services.Protocols.SoapMessageState.AfterSerialize
// System.Web.Services.Protocols.SoapMessageState.BeforeDeserialize
// System.Web.Services.Protocols.SoapMessageState.BeforeSerialize

/*
   The following example demonstrates the 'AfterDeserialize',
   'AfterSerialize', 'BeforeDeserialize' and 'BeforeSerialize' enum 
   members of the 'SoapMessageState' class. The program extends the 
   'SoapExtension' class to create a class that is used to log the 
   SOAP messages transferred for a web service method invocation. 
   To associate this 'SoapExtension' class with the web service 
   method on the client proxy a class that extends from 
   'SoapExtensionAttribute' is used. This 'SoapExtensionAttribute' is 
   applied to a client proxy method which is associated with a web 
   service method. Whenever this method is invoked on the client
   side all the SOAP message that get transfered both from the client
   and the server(which is hosting the web service) are written into
   a log file. 
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

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
   {
      return ((MySoapExtensionAttribute)attribute).Filename;
   }

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(Type filename) 
   {
      return (Type) filename;
   }

   // Save the name of the log file that shall save the SOAP messages.
   public override void Initialize(object initializer) 
   {
      filename = (string) initializer;
   }

// <Snippet1>
   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage message) 
   {
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput( message );
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput( message );
            break;
         case SoapMessageStage.AfterDeserialize:
            break;
         default:
            throw new Exception("invalid stage");
      }
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
   }
// </Snippet1>

   // Return a new 'MemoryStream' instance for SOAP processing.
   public override Stream ChainStream( Stream stream )
   {
      oldStream = stream;
      newStream = new MemoryStream();
      return newStream;
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutput( SoapMessage message )
   {
      newStream.Position = 0;
      FileStream myFileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
         + DateTime.Now);
      myStreamWriter.Flush();
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;
      Copy(newStream, oldStream);
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInput( SoapMessage message )
   {
      Copy(oldStream, newStream);
      FileStream myFileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("---------------------------------- Response at " 
         + DateTime.Now);
      myStreamWriter.Flush();
      newStream.Position = 0;
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;
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

// A 'SoapExtensionAttribute' that can be associated with web service method.
[AttributeUsage(AttributeTargets.Method)]
public class MySoapExtensionAttribute : SoapExtensionAttribute
{
   private string myFilename;
   private int myPriority;


   // Set the name of the log file were SOAP messages will be stored.
   public MySoapExtensionAttribute() : base()
   {
      myFilename = "C:\\logClient.txt";
   }

   // Return the type of 'MySoapExtension' class.
   public override Type ExtensionType
   {
      get
      {
         return typeof(MySoapExtension);
      }
   }

   // User can set priority of the 'SoapExtension'.
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

[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap", Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapMessageState.asmx";
   }
   
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [MySoapExtensionAttribute()]
   public System.Single Add(System.Single xValue, System.Single yValue) 
   {
      object[] results = this.Invoke("Add", new object[] {
                                             xValue,
                                             yValue});
      return ((System.Single)(results[0]));
   }

   public System.IAsyncResult BeginAdd(System.Single xValue,
                                       System.Single yValue,
                                       System.AsyncCallback callback,
                                       object asyncState) 
   {
      return this.BeginInvoke("Add", new object[] {
                                       xValue,
                                       yValue}, callback, asyncState);
   }

   public System.Single EndAdd(System.IAsyncResult asyncResult) 
   {
      object[] results = this.EndInvoke(asyncResult);
      return ((System.Single)(results[0]));
   }
}
