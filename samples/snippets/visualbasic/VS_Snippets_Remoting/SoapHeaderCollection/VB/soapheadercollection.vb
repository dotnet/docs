' System.Web.Services.Protocols.SoapHeaderCollection
' System.Web.Services.Protocols.SoapHeaderCollection.SoapHeaderCollection()
' System.Web.Services.Protocols.SoapHeaderCollection.Add(SoapHeader)
' System.Web.Services.Protocols.SoapHeaderCollection.Insert(int, SoapHeader)
' System.Web.Services.Protocols.SoapHeaderCollection.CopyTo(SoapHeader[], int)
' System.Web.Services.Protocols.SoapHeaderDirection.In

' The following example demonstrates various members of the 
' SoapHeaderCollection class and the In member of the SoapHeaderDirection
' enumeration. The program extends the SoapExtension class to create a 
' class that is used to log the SOAP messages transferred for an XML Web
' service method invocation. Whenever this method is invoked on the client
' side, all the SOAP message that are transfered both from the client and 
' the server are written to a log file.

Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Web.Services

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

   ' Process the SOAP message received and write it to the log file.
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
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " & _
         DateTime.Now)
      myStreamWriter.Flush()
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutput

   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(message As SoapClientMessage)
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
   End Sub 'WriteInput

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

' <Snippet1>
<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", _
    Namespace := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
' <Snippet6>
   Public mySoapHeaders() As SoapHeader

   <SoapHeaderAttribute("mySoapHeaders", _
      Direction := SoapHeaderDirection.In), _
   System.Web.Services.Protocols.SoapDocumentMethodAttribute( _
      "http://tempuri.org/Add", _
      Use := System.Web.Services.Description.SoapBindingUse.Literal, _
      ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
   MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single) _
      As System.Single
' <Snippet2>
      Dim mySoapHeaderCollection As New SoapHeaderCollection()
      Dim mySoapHeader As MySoapHeader
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This is the first SOAP header"
      mySoapHeaderCollection.Add(mySoapHeader)
' </Snippet2>
' <Snippet3>
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This is the second SOAP header"
      mySoapHeaderCollection.Add(mySoapHeader)
' </Snippet3>
' <Snippet4>
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This header is inserted before the first header"
      mySoapHeaderCollection.Insert(0, mySoapHeader)
' </Snippet4>
' <Snippet5>
      mySoapHeaders = New MySoapHeader(mySoapHeaderCollection.Count-1) {}
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0)
' </Snippet5>
      Dim results() As Object = _
         Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add
' </Snippet6>

   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapHeaderCollection.vb.asmx"
   End Sub 'New

   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
      callback As System.AsyncCallback, asyncState As Object) _
      As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, _
         callback, asyncState)
   End Function 'BeginAdd

   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc
' </Snippet1>
