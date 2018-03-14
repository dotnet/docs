
'  This program is just used to show a client proxy which helps 
'  accessing a web service.

Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Web.Services

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

   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(CType(message, SoapClientMessage))
         Case SoapMessageStage.BeforeDeserialize
            WriteInput(CType(message, SoapClientMessage))
         Case SoapMessageStage.AfterDeserialize
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage

   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(message As SoapClientMessage)
      newStream.Position = 0
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("=================================== Request at " + _
                                DateTime.Now)
      myStreamWriter.Flush()
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutput

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(message As SoapClientMessage)
      Copy(oldStream, newStream)
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + _
                                DateTime.Now)
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInput

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
      filename = "C:\logClient.txt"
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

<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", _
                               [Namespace] := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_LogicalMethodInfo.vb.asmx"
   End Sub 'New

   <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", _
         Use := System.Web.Services.Description.SoapBindingUse.Literal, _
         ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
         MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single) As System.Single
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add

   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
         callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd

   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc
