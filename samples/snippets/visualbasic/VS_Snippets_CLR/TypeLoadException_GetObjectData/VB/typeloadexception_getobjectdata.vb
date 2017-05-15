'  System.TypeLoadException.GetObjectData
'  System.TypeLoadException

'  This program demonstrates the 'GetObjectData' method and the 
'  protected constructor TypeLoadException(SerializationInfo,StreamingContext)
'  of 'TypeLoadException' class. It generates an exception and serializes 
'  the exception data to a file and then reconstitutes the exception.

' <Snippet1>
' <Snippet2>
Imports System
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Security.Permissions
Imports System.IO

Class GetObjectDataDemo

   Public Shared Sub Main()
      ' Get a reference to the assembly mscorlib.dll, which is always
      ' loaded. (System.String is defined in mscorlib.)
      Dim tString As Type = GetType(String)
      Dim mscorlib As [Assembly] = tString.Assembly

      Try
         Console.WriteLine("Attempting to load a type not present in the assembly 'mscorlib'")
         ' This loading of invalid type raises a TypeLoadException
         Dim myType As Type = mscorlib.GetType("System.NonExistentType", True)
      Catch
         ' Serialize the exception to disk and reconstitute it.
         Dim ErrorDatetime as System.DateTime = DateTime.Now
         Console.WriteLine("A TypeLoadException has been raised.")

         ' Create MyTypeLoadException instance with current time.
         Dim myException As new MyTypeLoadException(ErrorDatetime)
         Dim myFormatter as IFormatter  = new SoapFormatter()
         Dim myFileStream as Stream 
         myFileStream = New FileStream("typeload.xml", FileMode.Create, FileAccess.Write, FileShare.None)
         Console.WriteLine("Serializing the TypeLoadException with DateTime as " _
             & ErrorDatetime.ToString())

         ' Serialize the MyTypeLoadException instance to a file.
         myFormatter.Serialize(myFileStream, myException)
         myFileStream.Close()

         Console.WriteLine("Deserializing the Exception.")
         myFileStream = New FileStream("typeload.xml", FileMode.Open, FileAccess.Read, FileShare.None)

         ' Deserialize and reconstitute the instance from file.
         myException = CType(myFormatter.Deserialize(myFileStream), MyTypeLoadException)
         myFileStream.Close()
         Console.WriteLine("Deserialized exception has ErrorDateTime = " + myException.ErrorDateTime.ToString())
      End Try
   End Sub 'Main
End Class

' This class overrides the GetObjectData method and initializes
' its data with current time. 
<Serializable()> _
Public Class MyTypeLoadException
   Inherits TypeLoadException

   Private _errorDateTime As System.DateTime = DateTime.Now
   Public ReadOnly Property ErrorDateTime As DateTime
      Get
         Return _errorDateTime
      End Get
   End Property

   Public Sub New(myDateTime As DateTime)
      _errorDateTime = myDateTime
   End Sub 'New

   Protected Sub New(sInfo As SerializationInfo, sContext As StreamingContext)
      MyBase.New(sInfo, sContext)
      ' Reconstitute the deserialized information into the instance.
      _errorDateTime = sInfo.GetDateTime("ErrorDate")
   End Sub 'New

   ' GetObjectData overrides must always have a demand for SerializationFormatter.
   <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=true)> _
   Public Overrides Sub GetObjectData(sInfo As SerializationInfo, sContext As StreamingContext)
      MyBase.GetObjectData(sInfo, sContext)
      ' Add a value to the Serialization information.
      sInfo.AddValue("ErrorDate", ErrorDateTime)
   End Sub 'GetObjectData

End Class 'MyTypeLoadExceptionChild
' </Snippet2>
' </Snippet1>