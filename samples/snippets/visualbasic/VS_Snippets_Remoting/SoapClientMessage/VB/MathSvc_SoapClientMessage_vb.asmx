'  This program is just used for the server side of the web service.

<%@ WebService Language="vb" Class="MathSvc" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports Microsoft.VisualBasic

Public Class MySoapExtension
   Inherits SoapExtension
   Private oldStream As Stream
   Private newStream As Stream
   Private filename As String
   
  ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer _
       (methodInfo As LogicalMethodInfo, attribute As SoapExtensionAttribute) As Object
      Return CType(attribute, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(filename As Type) As Object
      Return CType(filename, Type)
   End Function 'GetInitializer
   
   ' Save the name of the log file that shall save the SOAP messages.
   Public Overrides Sub Initialize(initializer As Object)
      filename = CStr(initializer)
   End Sub 'Initialize
   
   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(message)
         Case SoapMessageStage.BeforeDeserialize
            WriteInput(message)
         Case SoapMessageStage.AfterDeserialize
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage
   
   ' Return a new 'MemoryStream' instance for SOAP processing.
   Public Overrides Function ChainStream(stream As Stream) As Stream
      oldStream = stream
      newStream = New MemoryStream()
      Return newStream
   End Function 'ChainStream
   
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(message As SoapMessage)
      newStream.Position = 0
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + DateTime.Now)
      myStreamWriter.Flush()
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutput
   
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(message As SoapMessage)
      Copy(oldStream, newStream)
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("================================== Request at " + DateTime.Now)
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInput
   
   
   ' Utility method to copy the contents of one stream to another. 
   Sub Copy(fromStream As Stream, toStream As Stream)
      Dim myTextReader = New StreamReader(fromStream)
      Dim myTextWriter = New StreamWriter(toStream)
      myTextWriter.WriteLine(myTextReader.ReadToEnd())
      myTextWriter.Flush()
   End Sub 'Copy
End Class 'MySoapExtension

' A 'SoapExtensionAttribute' that can be associated with web service method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class MySoapExtensionAttribute
   Inherits SoapExtensionAttribute
   Private myFilename As String
   Private myPriority As Integer
   
   ' Set the name of the log file were SOAP messages will be stored.
   Public Sub New()
      myFilename = "C:\logService.txt"
   End Sub 'New
   
   ' Return the type of 'MySoapExtension' class.
   
   Public Overrides ReadOnly Property ExtensionType() As Type
      Get
         Return GetType(MySoapExtension)
      End Get
   End Property
   
   ' User can set priority of the 'SoapExtension'.
   
   Public Overrides Property Priority() As Integer
      Get
         Return myPriority
      End Get
      Set
         myPriority = value
      End Set
   End Property
   
   
   Public Property Filename() As String
      Get
         Return myFilename
      End Get
      Set
         filename = value
      End Set
   End Property
End Class 'MySoapExtensionAttribute

Public Class MathSvc
   Inherits WebService

   <WebMethod(), MySoapExtensionAttribute()> _
   Public Function Add(xValue As Single, yValue As Single) As Single
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc