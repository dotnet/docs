/*
   This program is just used for the server side of the web service.
*/

<%@ WebService Language="C#" Class="MathSvc" %>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;


public class MySoapExtension : SoapExtension 
{
   Stream myOldStream;
   Stream myNewStream;
   string myFileName;

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo myMethodInfo,
      SoapExtensionAttribute mySoapExtensionAttributeObject) 
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
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput( myMessage );
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput( myMessage );
            break;
         case SoapMessageStage.AfterDeserialize:
            break;
         default:
            throw new Exception("invalid stage");
      }
   }

   // Return a new 'MemoryStream' instance for SOAP processing.
   public override Stream ChainStream( Stream myStream )
   {
      myOldStream = myStream;
      myNewStream = new MemoryStream();
      return myNewStream;
   }

   // Write the contents of the outgoing SOAP message to the log file.
   public void WriteOutput( SoapMessage myMessage )
   {
      myNewStream.Position = 0;
      FileStream myFileStream = new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("---------------------------------- Response at " 
                                          + DateTime.Now);
      myStreamWriter.Flush();
      Copy(myNewStream, myFileStream);
      myFileStream.Close();
      myNewStream.Position = 0;
      Copy(myNewStream, myOldStream);
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInput( SoapMessage myMessage )
   {
      Copy(myOldStream, myNewStream);
      FileStream myFileStream = new FileStream(myFileName, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("================================== Request at "
                                          + DateTime.Now);
      myStreamWriter.Flush();
      myNewStream.Position = 0;
      Copy(myNewStream, myFileStream);
      myFileStream.Close();
      myNewStream.Position = 0;
   }

   // Utility method to copy the contents of one stream to another. 
   void Copy(Stream myFromStream, Stream myToStream) 
   {
      TextReader myTextReader = new StreamReader(myFromStream);
      TextWriter myTextWriter = new StreamWriter(myToStream);
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
   public float Add(float xValue, float yValue, out float returnValue) 
   {
      returnValue = xValue + yValue;
      return(xValue + yValue);
   }
}
