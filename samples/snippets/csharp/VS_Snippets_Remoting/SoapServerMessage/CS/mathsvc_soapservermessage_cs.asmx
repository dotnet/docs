// System.Web.Services.Protocols.SoapServerMessage
// System.Web.Services.Protocols.SoapServerMessage.Action
// System.Web.Services.Protocols.SoapServerMessage.Server
// System.Web.Services.Protocols.SoapServerMessage.MethodInfo
// System.Web.Services.Protocols.SoapServerMessage.OneWay
// System.Web.Services.Protocols.SoapServerMessage.Url

/*
   The following example demonstrates the 'Action', 'Client', 'MethodInfo',
   'OneWay' and 'Url' properties  of the 'SoapServerMessage' class. The program 
   extends the 'SoapExtension' class to create a class that is used to log the 
   SOAP messages transferred for a web service method invocation. 
   To associate this 'SoapExtension' class with the web service 
   method a class that extends from 'SoapExtensionAttribute' is used. 
   This 'SoapExtensionAttribute' is applied to a web service method. 
   Whenever this method is invoked on the server, all the SOAP message 
   that get transfered both from the client(which is accessing the web service) 
   and the server are written into a log file. 
*/

<%@ WebService Language="C#" Class="MathSvc" %>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;


public class MySoapExtension : SoapExtension 
{
   Stream oldStream;
   Stream newStream;
   string filename;

   // Return the file name that is to log the SOAP messages.
   public override object GetInitializer(
      LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
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
   // Process the SOAP message received and write it to a log file.
   public override void ProcessMessage(SoapMessage message) 
   {
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput((SoapServerMessage)message);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInputBeforeDeserialize((SoapServerMessage)message);
            break;
         case SoapMessageStage.AfterDeserialize:
            WriteInputAfterDeserialize((SoapServerMessage)message);
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputAfterDeserialize(SoapServerMessage message)
   {
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      
      // Print to the log file the request header field for SoapAction header.
      myStreamWriter.WriteLine("The SoapAction HTTP request header field is: ");
      myStreamWriter.WriteLine("\t" + message.Action);
      
      // Print to the log file the type of the XML Web service.
      myStreamWriter.WriteLine("The type of the XML Web service is: ");
      if((message.Server.GetType()).Equals(typeof(MathSvc)))
         myStreamWriter.WriteLine("\tMathSvc");
         
      // Print to the log file the name of the XML Web service method.
      myStreamWriter.WriteLine(
         "The method of the XML Web service method requested:");
      myStreamWriter.WriteLine("\t" + message.MethodInfo.Name);
      
      // Print to the log file if the method invoked is OneWay.
      if(message.OneWay)
         myStreamWriter.WriteLine(
            "The client doesn't wait for the server to finish processing");
      else
         myStreamWriter.WriteLine(
            "The client waits for the server to finish processing");
         
      // Print to the log file the URL of the site that provides 
      // implementation of the XML Web service method.
      myStreamWriter.WriteLine(
         "The URL of the requested XML Web service method: ");
      myStreamWriter.WriteLine("\t" + message.Url);
      myStreamWriter.Flush();
      myStreamWriter.Close();
      myFileStream.Close();
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
   }
// </Snippet1>

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInputBeforeDeserialize(SoapServerMessage message)
   {
      Copy(oldStream, newStream);
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "================================== Request at " + DateTime.Now);
      myStreamWriter.WriteLine("The contents of the SOAP envelope are: ");
      myStreamWriter.Flush();
      newStream.Position = 0;
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutput(SoapServerMessage message)
   {
      newStream.Position = 0;
      FileStream myFileStream = 
         new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine(
         "---------------------------------- Response at " + DateTime.Now);
      myStreamWriter.Flush();
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;
      Copy(newStream, oldStream);
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
      myFilename = "C:\\logService.txt";
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

public class MathSvc : WebService 
{
        [WebMethod]
        [MySoapExtensionAttribute()]
        public float Add(float xValue, float yValue) 
        {
                return(xValue + yValue);
        }
}
