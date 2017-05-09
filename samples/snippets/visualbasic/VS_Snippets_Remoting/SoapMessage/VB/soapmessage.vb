' System.Web.Services.Protocols.SoapMessage
' System.Web.Services.Protocols.SoapMessage.Action
' System.Web.Services.Protocols.SoapMessage.ContentType
' System.Web.Services.Protocols.SoapMessage.OneWay
' System.Web.Services.Protocols.SoapMessage.Url
' System.Web.Services.Protocols.SoapMessage.GetInParameterValue(int)
' System.Web.Services.Protocols.SoapMessage.MethodInfo
' System.Web.Services.Protocols.SoapMessage.GetOutParameterValue(int)
' System.Web.Services.Protocols.SoapMessage.GetReturnValue()

' The following example demonstrates various members of the SoapMessage 
' class. The program extends the SoapExtension class to create a class
' that is used to log the SOAP messages transferred for an XML Web service
' method invocation. Whenever this method is invoked on the client side,
' all the SOAP messages that get transfered both from the client and the 
' server are written into a log file.

Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Web.Services
Imports Microsoft.VisualBasic

Public Class MySoapExtension
   Inherits SoapExtension
   Private oldStream As Stream
   Private newStream As Stream
   Private filename As String

   ' Return the file name that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer( _
      methodInfo As LogicalMethodInfo, attribute As SoapExtensionAttribute) _
      As Object
      Return CType(attribute, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer

   ' Return the file name that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(filename As Type) _
      As Object
      Return CType(filename, Type)
   End Function 'GetInitializer

   ' Save the name of the log file that will save the SOAP messages.
   Public Overrides Sub Initialize(initializer As Object)
      filename = CStr(initializer)
   End Sub 'Initialize

' <Snippet1>
   ' Process the SOAP message received and write to log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
            WriteOutputBeforeSerialize(message)
         Case SoapMessageStage.AfterSerialize
            WriteOutputAfterSerialize(message)
         Case SoapMessageStage.BeforeDeserialize
            WriteInputBeforeDeserialize(message)
         Case SoapMessageStage.AfterDeserialize
            WriteInputAfterDeserialize(message)
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage

   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutputBeforeSerialize(message As SoapMessage)
      Dim myFileStream As New FileStream( _
         filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " & _
         DateTime.Now)
' <Snippet7>
      myStreamWriter.WriteLine("The method that has been invoked is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.MethodInfo.ToString())
' </Snippet7>
' <Snippet2>
      myStreamWriter.WriteLine("The contents of the SOAPAction HTTP header is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Action)
' </Snippet2>
' <Snippet3>
      myStreamWriter.WriteLine("The contents of HTTP Content-type header is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.ContentType)
' </Snippet3>
' <Snippet4>
      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall not wait" & _
            " till the server finishes")
      Else
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall wait" & _
            " till the server finishes")
      End If
' </Snippet4>
' <Snippet5>
      myStreamWriter.WriteLine( _
         "The site where the XML Web service is available is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Url)
' </Snippet5>
' <Snippet6>
      myStreamWriter.WriteLine("The values of the in parameters are:")
      myStreamWriter.WriteLine("Value of first in parameter: {0}", _
         message.GetInParameterValue(0))
      myStreamWriter.WriteLine("Value of second in parameter: {0}", _
         message.GetInParameterValue(1))
' </Snippet6>
      myStreamWriter.WriteLine()
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteOutputBeforeSerialize

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputAfterDeserialize(message As SoapMessage)
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine()
' <Snippet8>
      myStreamWriter.WriteLine("The values of the out parameter are:")
      myStreamWriter.WriteLine("The value of the out parameter is: {0}", _
         message.GetOutParameterValue(0))
' </Snippet8>
' <Snippet9>
      myStreamWriter.WriteLine("The values of the return parameter are:")
      myStreamWriter.WriteLine("The value of the return parameter is: {0}", _
         message.GetReturnValue())
' </Snippet9>
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteInputAfterDeserialize

' </Snippet1>
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutputAfterSerialize(message As SoapMessage)
      newStream.Position = 0
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.Flush()
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutputAfterSerialize

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputBeforeDeserialize(message As SoapMessage)
      Copy(oldStream, newStream)
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "---------------------------------- Response at " & _
         DateTime.Now)
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInputBeforeDeserialize

   ' Return a new MemoryStream for SOAP processing.
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

' A SoapExtensionAttribute that can be associated with an 
' XML Web service method.
<AttributeUsage(AttributeTargets.Method)>  _
Public Class MySoapExtensionAttribute
   Inherits SoapExtensionAttribute
   Private myFilename As String
   Private myPriority As Integer

   ' Set the name of the log file where SOAP messages will be stored.
   Public Sub New()
      myFilename = "C:\logClient.txt"
   End Sub 'New

   ' Return the type of MySoapExtension.
   Public Overrides ReadOnly Property ExtensionType() As Type
      Get
         Return GetType(MySoapExtension)
      End Get
   End Property

   ' User can set priority of the SoapExtension.
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

Public Class MySoapHeader
   Inherits SoapHeader
   Public text As String
End Class 'MySoapHeader

<System.Web.Services.WebServiceBindingAttribute( _
   Name := "MathSvcSoap", Namespace := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

   Public mySoapHeader As MySoapHeader

   <SoapHeaderAttribute("mySoapHeader", Direction := SoapHeaderDirection.In), _
   System.Web.Services.Protocols.SoapDocumentMethodAttribute( _
      "http://tempuri.org/Add", _
      Use := System.Web.Services.Description.SoapBindingUse.Literal, _
      ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
   MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single, _
         ByRef returnValue As System.Single) As System.Single
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This is the first SOAP header"
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      returnValue = CType(results(1), System.Single)
      Return CType(results(0), System.Single)
   End Function 'Add

   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapMessage.vb.asmx"
   End Sub 'New

   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
      callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd

   Public Function EndAdd(asyncResult As System.IAsyncResult, _
         ByRef returnValue As System.Single) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      returnValue = CType(results(1), System.Single)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc
