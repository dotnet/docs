// System.Web.Services.Protocols.SoapExtensionAttribute
// System.Web.Services.Protocols.SoapExtensionAttribute.ExtensionType
// System.Web.Services.Protocols.SoapExtensionAttribute.Priority

/*
   The following example demonstrates the 'ExtensionType'
   and 'Priority' attribute of the 'SoapExtensionAttribute' class.
   The program extends the 'SoapExtension' class to create a class
   that is used to log the SOAP messages transferred for a web service
   method invocation. To associate this 'SoapExtension' class with the
   web service method on the client proxy, a class that extends from
   'SoapExtensionAttribute' is used. This 'SoapExtensionAttribute'
   is applied to a client proxy method which is associated with a
   web service method. Whenever this method is invoked on the client
   side all the SOAP message that get transffered both from the client
   and the server(which is hosting the web service) are written into
   a log file. 
*/

using System;
using System.IO;
using System.Web.Services.Protocols;
using System.Web.Services;
	// Define a SOAP Extension that traces the SOAP request and SOAP
	// response for the XML Web service method the SOAP extension is
	// applied to.

public class TraceExtension : SoapExtension 
{
	Stream oldStream;
	Stream newStream;
	string filename;

	// Save the Stream representing the SOAP request or SOAP response into
	// a local memory buffer.
	public override Stream ChainStream( Stream stream )
	{
		oldStream = stream;
		newStream = new MemoryStream();
		return newStream;
	}

	// When the SOAP extension is accessed for the first time, the XML Web
	// service method it is applied to is accessed to store the file
	// name passed in, using the corresponding SoapExtensionAttribute.	
	public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
	{
		return ((TraceExtensionAttribute) attribute).Filename;
	}

	// The SOAP extension was configured to run using a configuration file
	// instead of an attribute applied to a specific XML Web service
	// method.
	public override object GetInitializer(Type WebServiceType) 
	{
		// Return a file name to log the trace information to, based on the
		// type.
		return "C:\\" + WebServiceType.FullName + ".log";    
	}

	// Receive the file name stored by GetInitializer and store it in a
	// member variable for this specific instance.
	public override void Initialize(object initializer) 
	{
		filename = (string) initializer;
	}

	//  If the SoapMessageStage is such that the SoapRequest or
	//  SoapResponse is still in the SOAP format to be sent or received,
	//  save it out to a file.
	public override void ProcessMessage(SoapMessage message) 
	{
		switch (message.Stage) 
		{
			case SoapMessageStage.BeforeSerialize:
				break;
			case SoapMessageStage.AfterSerialize:
				WriteOutput(message);
				break;
			case SoapMessageStage.BeforeDeserialize:
				WriteInput(message);
				break;
			case SoapMessageStage.AfterDeserialize:
				break;
			default:
				throw new Exception("invalid stage");
		}
	}

	public void WriteOutput(SoapMessage message)
	{
		newStream.Position = 0;
		FileStream fs = new FileStream(filename, FileMode.Append,
			FileAccess.Write);
		StreamWriter w = new StreamWriter(fs);

		string soapString = (message is SoapServerMessage) ? "SoapResponse" : "SoapRequest";
		w.WriteLine("-----" + soapString + " at " + DateTime.Now);
		w.Flush();
		Copy(newStream, fs);
		w.Close();
		newStream.Position = 0;
		Copy(newStream, oldStream);
	}

	public void WriteInput(SoapMessage message)
	{
		Copy(oldStream, newStream);
		FileStream fs = new FileStream(filename, FileMode.Append,
			FileAccess.Write);
		StreamWriter w = new StreamWriter(fs);

		string soapString = (message is SoapServerMessage) ?
			"SoapRequest" : "SoapResponse";
		w.WriteLine("-----" + soapString + 
			" at " + DateTime.Now);
		w.Flush();
		newStream.Position = 0;
		Copy(newStream, fs);
		w.Close();
		newStream.Position = 0;
	}

	void Copy(Stream from, Stream to) 
	{
		TextReader reader = new StreamReader(from);
		TextWriter writer = new StreamWriter(to);
		writer.WriteLine(reader.ReadToEnd());
		writer.Flush();
	}
}

// <Snippet1>
// A SoapExtensionAttribute that can be associated with an 
// XML Web service method.
[AttributeUsage(AttributeTargets.Method)]
public class TraceExtensionAttribute : SoapExtensionAttribute
{
   private string myFilename;
   private int myPriority;

   // Set the name of the log file where SOAP messages will be stored.
   public TraceExtensionAttribute() : base()
   {
      myFilename = "C:\\logClient.txt";
   }

// <Snippet2>
   // Return the type of TraceExtension.
   public override Type ExtensionType
   {
      get
      {
         return typeof(TraceExtension);
      }
   }
// </Snippet2>

// <Snippet3>
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
// </Snippet3>

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
// </Snippet1>

[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap", Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapExtensionAttribute.asmx";
   }
   
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [TraceExtension()]
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
