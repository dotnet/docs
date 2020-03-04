// System.Web.Services.Protocols.LogicalMethodInfo

/*
The following example demonstrates the general class level example
for the 'LogicalMethodInfo' class. The program extends the 
'SoapExtension' class to create a class that is used to log the 
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
      switch (message.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput((SoapServerMessage)message);
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput((SoapServerMessage)message);
            break;
         case SoapMessageStage.AfterDeserialize:
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInput(SoapServerMessage message)
   {
      // Utility method to copy the contents of one stream to another. 
      Copy(oldStream, newStream);
      FileStream myFileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
         + DateTime.Now);
      myStreamWriter.WriteLine("The method that has been invoked is : ");
      myStreamWriter.WriteLine("\t" + message.MethodInfo.Name);
      myStreamWriter.WriteLine("The contents of the SOAP envelope are : ");
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
      FileStream myFileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("---------------------------------- Response at " 
                                          + DateTime.Now);
      myStreamWriter.Flush();
      // Utility method to copy the contents of one stream to another. 
      Copy(newStream, myFileStream);
      myFileStream.Close();
      newStream.Position = 0;
      Copy(newStream, oldStream);
   }
// </Snippet1>
   // Return a new 'MemoryStream' instance for SOAP processing.
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

// A 'SoapExtensionAttribute' that can be associated with web service method.
[AttributeUsage(AttributeTargets.Method)]
public class MySoapExtensionAttribute : SoapExtensionAttribute
{
   private string myFilename;
   private int myPriority;

   // Set the name of the log file were SOAP messages will be stored.
   public MySoapExtensionAttribute() : base()
   {
      myFilename = "C:\\logService.txt";
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

public class MathSvc : WebService {

   [WebMethod]
   [MySoapExtensionAttribute()]
   public float Add(float xValue, float yValue) {
      return(xValue + yValue);
   }
}
