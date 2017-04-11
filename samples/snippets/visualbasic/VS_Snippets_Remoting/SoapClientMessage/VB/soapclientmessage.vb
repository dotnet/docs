' System.Web.Services.Protocols.SoapClientMessage
' System.Web.Services.Protocols.SoapClientMessage.Action
' System.Web.Services.Protocols.SoapClientMessage.Client
' System.Web.Services.Protocols.SoapClientMessage.MethodInfo
' System.Web.Services.Protocols.SoapClientMessage.OneWay
' System.Web.Services.Protocols.SoapClientMessage.Url

'  The following example demonstrates the 'Action', 'Client', 'MethodInfo', 
'  'OneWay' and 'Url' properties of the 'SoapClientMessage' class. 
'  It extends the 'SoapExtension' class to create a class that is used to 
'  log the SOAP messages transferred for a web service method invocation. 
'  To associate this 'SoapExtension' class with the web service method on 
'  the client proxy, a class that extends from 'SoapExtensionAttribute' is 
'  used. This 'SoapExtensionAttribute' is applied to a client proxy method 
'  which is associated with a web service method. Whenever this method is 
'  invoked on the client side all the SOAP message that get transfered both
'  from the client and the server(which is hosting the web service) are 
'  written into a log file. 

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
   
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function _
       GetInitializer(methodInfo As LogicalMethodInfo, attribute As SoapExtensionAttribute) As Object
      Return CType(attribute, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer
   
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(filename As Type) As Object
      Return CType(filename, Type)
   End Function 'GetInitializer
   
   
   ' Save the name of the log file that will save the SOAP messages.
   Public Overrides Sub Initialize(initializer As Object)
      filename = CStr(initializer)
   End Sub 'Initialize
   
   
' <Snippet1>
   ' Process the SOAP message received and write to a log file.
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
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
      newStream.Position = 0
      Dim myFileStream As New FileStream(filename, FileMode.Append, _
         FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " & DateTime.Now)

      ' Print to the log file the request header field for SoapAction header.
      myStreamWriter.WriteLine("The SoapAction Http request header field is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Action)

      ' Print to the log file the type of the client that invoked
      ' the XML Web service method.
      myStreamWriter.WriteLine("The type of the client is: ")
      If message.Client.GetType().Equals(GetType(MathSvc)) Then
         myStreamWriter.WriteLine(ControlChars.Tab & "MathSvc")
      End If

     ' Print to the log file the method invoked by the client.
      myStreamWriter.WriteLine( _
         "The method that has been invoked by the client is:")
      myStreamWriter.WriteLine(ControlChars.Tab & message.MethodInfo.Name)

      ' Print to the log file if the method invoked is OneWay.
      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The client doesn't wait for the server to finish processing")
      Else
         myStreamWriter.WriteLine( _
            "The client waits for the server to finish processing")
      End If 

      ' Print to the log file the URL of the site that provides 
      ' implementation of the method.
      myStreamWriter.WriteLine( _
         "The url of the XML Web service method that has been requested is: ")
      myStreamWriter.WriteLine(ControlChars.Tab & message.Url)
      myStreamWriter.WriteLine("The contents of the SOAP envelope are: ")
      myStreamWriter.Flush()

      ' Copy the contents of one stream to another. 
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0

      ' Copy the contents of one stream to another. 
      Copy(newStream, oldStream)
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
  End Sub 'WriteOutput
' </Snippet1>
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInput(message As SoapClientMessage)
      Copy(oldStream, newStream)
      Dim myFileStream As New FileStream(filename, FileMode.Append, _
         FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "---------------------------------- Response at " & DateTime.Now)
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
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
<AttributeUsage(AttributeTargets.Method)> _
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

<System.Web.Services.WebServiceBindingAttribute _
   (Name := "MathSvcSoap", [Namespace] := "http://tempuri.org/")> _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   
 <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapClientMessage_vb.asmx"
   End Sub 'New
   
   <System.Web.Services.Protocols.SoapDocumentMethodAttribute _
      ("http://tempuri.org/Add", _
      Use := System.Web.Services.Description.SoapBindingUse.Literal, _
      ParameterStyle := _
      System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
      MySoapExtensionAttribute()> _
   Public Function Add(xValue As System.Single, yValue As System.Single) _
   As System.Single
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add
   
   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
      callback As System.AsyncCallback, asyncState As Object) _
      As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, _
         asyncState)
   End Function 'BeginAdd
   
   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc
