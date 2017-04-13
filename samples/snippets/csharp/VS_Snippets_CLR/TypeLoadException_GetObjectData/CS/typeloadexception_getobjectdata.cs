// System.TypeLoadException.GetObjectData
// System.TypeLoadException

/* This program demonstrates the 'GetObjectData' method and the
   protected constructor TypeLoadException(SerializationInfo,StreamingContext)
   of 'TypeLoadException' class. It generates an exception and 
   serializes the exception data to a file and then reconstitutes the 
   exception.
*/

// <Snippet1>
// <Snippet2>

using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap; 
using System.Security.Permissions;
using System.IO;

class GetObjectDataDemo
{
   public static void Main()
   {
      // Get a reference to the assembly mscorlib.dll, which is always
      // loaded. (System.String is defined in mscorlib.)
      Assembly mscorlib = typeof(string).Assembly;

      try
      {
         Console.WriteLine ("Attempting to load a type not present in the assembly 'mscorlib'");
         // This loading of invalid type raises a TypeLoadException
         Type myType = mscorlib.GetType("System.NonExistentType", true);
      }         
      catch (TypeLoadException)
      {
         // Serialize the exception to disk and reconstitute it.
         System.DateTime ErrorDatetime = DateTime.Now;
         Console.WriteLine("A TypeLoadException has been raised.");

         // Create MyTypeLoadException instance with current time.
         MyTypeLoadException myException = new MyTypeLoadException(ErrorDatetime);
         IFormatter myFormatter = new SoapFormatter();
         Stream myFileStream = new FileStream("typeload.xml", FileMode.Create, FileAccess.Write, FileShare.None);
         Console.WriteLine("Serializing the TypeLoadException with DateTime as " + ErrorDatetime);

         // Serialize the MyTypeLoadException instance to a file.
         myFormatter.Serialize(myFileStream, myException);
         myFileStream.Close();

         Console.WriteLine("Deserializing the Exception.");
         myFileStream = new FileStream("typeload.xml", FileMode.Open, FileAccess.Read, FileShare.None);

         // Deserialize and reconstitute the instance from file.
         myException = (MyTypeLoadException) myFormatter.Deserialize(myFileStream);
         myFileStream.Close();
         Console.WriteLine("Deserialized exception has ErrorDateTime = " + myException.ErrorDateTime);
      }
   }
}

// This class overrides the GetObjectData method and initializes
// its data with current time. 

[Serializable]
public class MyTypeLoadException : TypeLoadException 
{
   private System.DateTime _errorDateTime = DateTime.Now;
   public DateTime ErrorDateTime { get { return _errorDateTime; }}

   public MyTypeLoadException(DateTime myDateTime) 
   {
      _errorDateTime = myDateTime;
   }

   protected MyTypeLoadException(SerializationInfo sInfo, StreamingContext sContext) 
       : base(sInfo, sContext)
   {
      // Reconstitute the deserialized information into the instance.
      _errorDateTime = sInfo.GetDateTime("ErrorDate");
   }

   // GetObjectData overrides must always have a demand for SerializationFormatter.
   [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
   public override void GetObjectData(SerializationInfo sInfo, StreamingContext sContext) 
   {
      base.GetObjectData(sInfo, sContext);
      // Add a value to the Serialization information.
      sInfo.AddValue("ErrorDate", ErrorDateTime);
   }
}
// </Snippet2>
// </Snippet1>
