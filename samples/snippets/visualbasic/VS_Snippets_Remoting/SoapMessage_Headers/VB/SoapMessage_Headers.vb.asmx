' This program is just used for the server side of the web service.

<%@ WebService Language="VB" Class="MathSvc" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

Public Class MySoapExtension
   Inherits SoapExtension
   Private myOldStream As Stream
   Private myNewStream As Stream
   Private myFileName As String

   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(myMethodInfo As LogicalMethodInfo, _
                        mySoapExtensionAttributeObject As SoapExtensionAttribute) As Object
      Return CType(mySoapExtensionAttributeObject, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer

   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(myFileName As Type) As Object
      Return CType(myFileName, Type)
   End Function 'GetInitializer

   ' Save the name of the log file that shall save the SOAP messages.
   Public Overrides Sub Initialize(myInitializer As Object)
      myFileName = CStr(myInitializer)
   End Sub 'Initialize

   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(myMessage As SoapMessage)
      Select Case myMessage.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(myMessage)
         Case SoapMessageStage.BeforeDeserialize
            WriteInput(myMessage)
         Case SoapMessageStage.AfterDeserialize
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage

   ' Return a new 'MemoryStream' instance for SOAP processing.
   Public Overrides Function ChainStream(myStream As Stream) As Stream
      myOldStream = myStream
      myNewStream = New MemoryStream()
      Return myNewStream
   End Function 'ChainStream

   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(myMessage As SoapMessage)
      myNewStream.Position = 0
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + DateTime.Now)
      myStreamWriter.Flush()
      Copy(myNewStream, myFileStream)
      myFileStream.Close()
      myNewStream.Position = 0
      Copy(myNewStream, myOldStream)
   End Sub 'WriteOutput

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(myMessage As SoapMessage)
      Copy(myOldStream, myNewStream)
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("================================== Request at " + DateTime.Now)
      myStreamWriter.Flush()
      myNewStream.Position = 0
      Copy(myNewStream, myFileStream)
      myFileStream.Close()
      myNewStream.Position = 0
   End Sub 'WriteInput

   ' Utility method to copy the contents of one stream to another. 
   Sub Copy(myFromStream As Stream, myToStream As Stream)
      Dim myTextReader = New StreamReader(myFromStream)
      Dim myTextWriter = New StreamWriter(myToStream)
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
      MyBase.New()
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
   Public Function Add(xValue As Single, yValue As Single, ByRef returnValue As Single) As Single
      returnValue = xValue + yValue
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc