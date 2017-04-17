// System.Web.Services.Protocols.SoapHeaderCollection.Contains(SoapHeader); System.Web.Services.Protocols.SoapHeaderCollection.IndexOf(); System.Web.Services.Protocols.SoapHeaderCollection.Item; System.Web.Services.Protocols.SoapHeaderCollection.Remove(SoapHeader)

/*
   The following example demonstrates the methods 'Contains','IndexOf' and 
   'Remove' and the property 'Item' of the 'SoapHeaderCollection' class. The 
   program extends the 'SoapExtension' class to create a class that is 
   used to log the SOAP messages transferred for a web service method 
   invocation. Whenever this method is invoked on the client side 
   all the SOAP message that get transfered both from the client
   and the server are written into a log file.
*/

using System;
using System.IO;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Xml;

public class MySoapExtension : SoapExtension 
{
   Stream oldStream;
   Stream newStream;
   string myFilename;

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute myAttribute) 
   {
      return ((MySoapExtensionAttribute)myAttribute).Filename;
   }

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(Type myFilename) 
   {
      return (Type) myFilename;
   }

   // Save the name of the log file that shall save the SOAP messages.
   public override void Initialize(object initializer) 
   {
      myFilename = (string) initializer;
   }

   // Process the SOAP message received and write to log file.
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
      FileStream myFileStream = new FileStream(myFilename, FileMode.Append, FileAccess.Write);
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
      FileStream myFileStream = new FileStream(myFilename, FileMode.Append, FileAccess.Write);
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

   // Return a new 'MemoryStream' instance for SOAP processing.
   public override Stream ChainStream( Stream myStream )
   {
      oldStream = myStream;
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

public class MySoapHeader : SoapHeader
{
   public string Text;
}


[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap", Namespace="http://tempuri.org/")]
public class MathService : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   public SoapHeader[] mySoapHeaders;
   [SoapHeaderAttribute("mySoapHeaders", Direction=SoapHeaderDirection.In, Required=false)]
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add",
            Use=System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [MySoapExtensionAttribute()]
   public System.Single Add(System.Single xValue, System.Single yValue) 
   {
      SoapHeaderCollection mySoapHeaderCollection = new SoapHeaderCollection();
      MySoapHeader myFirstSoapHeader;
      myFirstSoapHeader = new MySoapHeader();
      myFirstSoapHeader.Text = "This is the first soap header";
      mySoapHeaderCollection.Add(myFirstSoapHeader);

      MySoapHeader mySecondSoapHeader = new MySoapHeader();
      mySecondSoapHeader.Text = "This is the second soap header";
      mySoapHeaderCollection.Add(mySecondSoapHeader);
// <Snippet1>
        // Check to see whether the collection contains mySecondSoapHeader.
        if(mySoapHeaderCollection.Contains(mySecondSoapHeader))
        {
            // Get the index of mySecondSoapHeader from the collection.
            Console.WriteLine("Index of mySecondSoapHeader: " + 
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader));

            // Get the SoapHeader from the collection.
            MySoapHeader mySoapHeader1 = (MySoapHeader)mySoapHeaderCollection
                [mySoapHeaderCollection.IndexOf(mySecondSoapHeader)];
            Console.WriteLine("SoapHeader retrieved from the collection: " 
                + mySoapHeader1);

            // Remove a SoapHeader from the collection.
            mySoapHeaderCollection.Remove(mySoapHeader1);
            Console.WriteLine("Number of items after removal: {0}", 
                mySoapHeaderCollection.Count);
        }
        else
            Console.WriteLine(
                "mySoapHeaderCollection does not contain mySecondSoapHeader.");
// </Snippet1> 

      mySoapHeaders = new MySoapHeader[mySoapHeaderCollection.Count];
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0);
      object[] results = this.Invoke("Add", new object[] {
                                             xValue,
                                             yValue});
      return ((System.Single)(results[0]));
   }
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathService() 
   {
      this.Url = "http://localhost/MathService_SoapHeaderCollection.cs.asmx";
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

