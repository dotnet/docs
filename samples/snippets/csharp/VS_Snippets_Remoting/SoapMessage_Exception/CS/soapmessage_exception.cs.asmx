// System.Web.Services.Protocols.SoapMessage.Exception
/*
   The following example demonstrates 'Exception' property of 
   the 'SoapMessage' class. This program is used for the server side of the
   web service. The program extends the 'SoapExtension' class to create
   a class that is used to log the SOAP messages transferred for a web 
   service method invocation. Whenever this method is invoked on the server 
   side all the SOAP message that get transfered both from the client 
   and the server are written into a log file. 
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
   string myNameOfFile;

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(LogicalMethodInfo myMethodInfo,
            SoapExtensionAttribute mySoapExtensionAttribute1) 
   {
      return ((MySoapExtensionAttribute)mySoapExtensionAttribute1).
         Filename;
   }

   // Return the filename that is to log the SOAP messages.
   public override object GetInitializer(Type myNameOfFile) 
   {
      return (Type) myNameOfFile;
   }

   // Save the name of the log file that shall save the SOAP messages.
   public override void Initialize(object myInitializer) 
   {
      myNameOfFile = (string) myInitializer;
   }

   // Process the SOAP message received and write to log file.
   public override void ProcessMessage(SoapMessage mySoapMessage) 
   {
      switch (mySoapMessage.Stage) 
      {
         case SoapMessageStage.BeforeSerialize:
            break;
         case SoapMessageStage.AfterSerialize:
            WriteOutput( mySoapMessage );
            break;
         case SoapMessageStage.BeforeDeserialize:
            WriteInput( mySoapMessage );
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
   public void WriteOutput( SoapMessage mySoapMessage )
   {
      myNewStream.Position = 0;
      FileStream myFileStream = new FileStream(myNameOfFile, 
               FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("----------- Response at "+ DateTime.Now);
// <Snippet1>
      if (mySoapMessage.Exception != null)
      {
         myStreamWriter.WriteLine("A SoapException occurred!!!"); 
         myStreamWriter.WriteLine(mySoapMessage.Exception.Message);
      }   
// </Snippet1>
      myStreamWriter.Flush();
      Copy(myNewStream, myFileStream);
      myFileStream.Close();
      myNewStream.Position = 0;
      Copy(myNewStream, myOldStream);
   }

   // Write the contents of the incoming SOAP message to the log file.
   public void WriteInput( SoapMessage mySoapMessage )
   {
      Copy(myOldStream, myNewStream);
      FileStream myFileStream = new FileStream(myNameOfFile, FileMode.Append, FileAccess.Write);
      StreamWriter myStreamWriter = new StreamWriter(myFileStream);
      myStreamWriter.WriteLine("=========== Request at "+ DateTime.Now);
      if (mySoapMessage.Exception != null)
      {  
         myStreamWriter.WriteLine("A SoapException occurred!!!"); 
         myStreamWriter.WriteLine(mySoapMessage.Exception.Message);
      }                                             
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

      if(yValue > 111)
         throw new OverflowException();
      returnValue = xValue + yValue;
      return(xValue + yValue);
   }
}
