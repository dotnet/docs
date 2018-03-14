// System.Web.Services.Protocols.SoapHeaderCollection
// System.Web.Services.Protocols.SoapHeaderCollection.SoapHeaderCollection()
// System.Web.Services.Protocols.SoapHeaderCollection.Add(SoapHeader)
// System.Web.Services.Protocols.SoapHeaderCollection.Insert(int, SoapHeader)
// System.Web.Services.Protocols.SoapHeaderCollection.CopyTo(SoapHeader[], int)
// System.Web.Services.Protocols.SoapHeaderDirection.In

/*
   The following example demonstrates various members of the 
   SoapHeaderCollection class and the In member of the SoapHeaderDirection
   enumeration. The program extends the SoapExtension class to create a 
   class that is used to log the SOAP messages transferred for an XML Web
   service method invocation. Whenever this method is invoked on the client
   side, all the SOAP message that are transfered both from the client and 
   the server are written to a log file.
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

   // Process the SOAP message received and write it to the log file.
   public override void ProcessMessage(SoapMessage message) 
   {
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput((SoapClientMessage)message);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput((SoapClientMessage)message);
            break;
         case SoapMessageStage.AfterDeserialize:
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutput(SoapClientMessage message)
   {
      newStream.Position = 0;
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
         + DateTime.Now);
      myStreamWriter.Flush();
      Copy(newStream, myFileStream);
      myStreamWriter.Close();
      myFileStream.Close();
      newStream.Position = 0;
      Copy(newStream, oldStream);
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInput(SoapClientMessage message)
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
   public string text;
}

// <Snippet1>
[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
// <Snippet6>
   public SoapHeader[] mySoapHeaders;
   
   [SoapHeaderAttribute("mySoapHeaders", 
      Direction=SoapHeaderDirection.In)]
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
      "http://tempuri.org/Add", 
      Use=System.Web.Services.Description.SoapBindingUse.Literal, 
      ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [MySoapExtensionAttribute()]
   public System.Single Add(System.Single xValue, System.Single yValue) 
   {
// <Snippet2>
      SoapHeaderCollection mySoapHeaderCollection = new SoapHeaderCollection();
      MySoapHeader mySoapHeader;
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This is the first SOAP header";
      mySoapHeaderCollection.Add(mySoapHeader);
// </Snippet2>
// <Snippet3>
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This is the second SOAP header";
      mySoapHeaderCollection.Add(mySoapHeader);
// </Snippet3>
// <Snippet4>
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This header is inserted before the first header";
      mySoapHeaderCollection.Insert(0, mySoapHeader);
// </Snippet4>
// <Snippet5>
      mySoapHeaders = new MySoapHeader[mySoapHeaderCollection.Count];
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0);
// </Snippet5>
      object[] results = this.Invoke("Add", 
         new object[] {xValue, yValue});
      return ((System.Single)(results[0]));
   }
// </Snippet6>

   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapHeaderCollection.cs.asmx";
   }

   public System.IAsyncResult BeginAdd(System.Single xValue,
      System.Single yValue, System.AsyncCallback callback, object asyncState) 
   {
      return this.BeginInvoke("Add", new object[] {xValue, yValue}, 
         callback, asyncState);
   }

   public System.Single EndAdd(System.IAsyncResult asyncResult) 
   {
      object[] results = this.EndInvoke(asyncResult);
      return ((System.Single)(results[0]));
   }
}
// </Snippet1>
