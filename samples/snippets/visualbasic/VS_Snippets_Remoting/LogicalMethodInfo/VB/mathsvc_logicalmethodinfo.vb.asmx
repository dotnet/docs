' System.Web.Services.Protocols.LogicalMethodInfo

'   The following example demonstrates the general class level example
'   for the 'LogicalMethodInfo' class. The program extends the 
'   'SoapExtension' class to create a class that is used to log the 
'   SOAP messages transferred for a web service method invocation. 
'   To associate this 'SoapExtension' class with the web service 
'   method a class that extends from 'SoapExtensionAttribute' is used. 
'   This 'SoapExtensionAttribute' is applied to a web service method. 
'   Whenever this method is invoked on the server, all the SOAP message 
'   that get transfered both from the client(which is accessing the web service) 
'   and the server are written into a log file. 

<%@ WebService Language="VB" Class="MathSvc" %>

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
   Overloads Public Overrides Function GetInitializer(methodInfo As LogicalMethodInfo, _
                                 attribute As SoapExtensionAttribute) As Object
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

' <Snippet1>
   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(CType(message, SoapServerMessage))
         Case SoapMessageStage.BeforeDeserialize
            WriteInput(CType(message, SoapServerMessage))
         Case SoapMessageStage.AfterDeserialize
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(message As SoapServerMessage)
      ' Utility method to copy the contents of one stream to another.
      Copy(oldStream, newStream)
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("================================== Request at " + _
                                DateTime.Now)
      myStreamWriter.WriteLine("The method that has been invoked is : ")
      myStreamWriter.WriteLine(ControlChars.Tab + message.MethodInfo.Name)
      myStreamWriter.WriteLine("The contents of the SOAP envelope are : ")
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInput

   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(message As SoapServerMessage)
      newStream.Position = 0
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + _
                                DateTime.Now)
      myStreamWriter.Flush()
      ' Utility method to copy the contents of one stream to another.
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutput
' </Snippet1>

   ' Return a new 'MemoryStream' instance for SOAP processing.
   Public Overrides Function ChainStream(stream As Stream) As Stream
      oldStream = stream
      newStream = New MemoryStream()
      Return newStream
   End Function 'ChainStream

   ' Utility method to copy the contents of one stream to another.
   Sub Copy(fromStream As Stream, toStream As Stream)
      Dim myTextReader = New StreamReader(fromStream)
      Dim myTextWriter = New StreamWriter(toStream)
      myTextWriter.WriteLine(myTextReader.ReadToEnd())
      myTextWriter.Flush()
   End Sub 'Copy
End Class 'MySoapExtension

' A 'SoapExtensionAttribute' that can be associated with web service method.
<AttributeUsage(AttributeTargets.Method)>  _
Public Class MySoapExtensionAttribute
   Inherits SoapExtensionAttribute
   Private myFilename As String
   Private myPriority As Integer

   ' Set the name of the log file were SOAP messages will be stored.
   Public Sub New()
      MyBase.New
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
         myFilename = value
      End Set
   End Property
End Class 'MySoapExtensionAttribute

Public Class MathSvc
   Inherits WebService
   <WebMethod(), MySoapExtensionAttribute()>  _
   Public Function Add(xValue As Single, yValue As Single) As Single
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc