' The program extends the 'SoapExtension' class to create a class 
' that is used to log the SOAP messages transferred for a web service 
' method invocation. Whenever this method is invoked on the client 
' side all the SOAP message that get transfered both from the client 
' and the server are written into a log file. 

Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Web.Services
Imports MicroSoft.VisualBasic

Public Class MySoapExtension
   Inherits SoapExtension
   Private myOldStream As Stream
   Private myNewStream As Stream
   Private myFileName As String
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(myMethodInfo As LogicalMethodInfo, _
                        mySoapExtensionAttribute1 As SoapExtensionAttribute) As Object
      Return CType(mySoapExtensionAttribute1, MySoapExtensionAttribute).Filename
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
            WriteOutputBeforeSerialize(myMessage)
         Case SoapMessageStage.AfterSerialize
            WriteOutputAfterSerialize(myMessage)
         Case SoapMessageStage.BeforeDeserialize
            WriteInputBeforeDeserialize(myMessage)
         Case SoapMessageStage.AfterDeserialize
            WriteInputAfterDeserialize(myMessage)
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage
   
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutputBeforeSerialize(myMessage As SoapMessage)
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("================================== Request at " + DateTime.Now)
      
      myStreamWriter.WriteLine("The method that has been invoked is : ")
      myStreamWriter.WriteLine(ControlChars.Tab + myMessage.MethodInfo.ToString())
      
      myStreamWriter.WriteLine("The contents of the SOAPAction HTTP header is :")
      myStreamWriter.WriteLine(ControlChars.Tab + myMessage.Action)
      
      myStreamWriter.WriteLine("The contents of HTTP Content-type header is :")
      myStreamWriter.WriteLine(ControlChars.Tab + myMessage.ContentType)
      
      If myMessage.OneWay Then
         myStreamWriter.WriteLine("The method invoked on the client shall not wait" + _
                                                      "till the server finishes")
      Else
         myStreamWriter.WriteLine("The method invoked on the client shall wait" + _
                                                      "till the server finishes")
      End If
      
      myStreamWriter.WriteLine("The site where the web service is available is : ")
      myStreamWriter.WriteLine(ControlChars.Tab + myMessage.Url)
      
      myStreamWriter.WriteLine("The values of the in parameters are :")
      myStreamWriter.WriteLine("Value of first in parameter : {0}", myMessage.GetInParameterValue(0))
      myStreamWriter.WriteLine("Value of second in parameter : {0}", myMessage.GetInParameterValue(1))
      
      myStreamWriter.Write("Number of headers for the current request: ")
      myStreamWriter.WriteLine(myMessage.Headers.Count)
      If Not (myMessage.Exception Is Nothing) Then
         myStreamWriter.WriteLine("Exception1 : " + myMessage.Exception.Message)
      End If 
      myStreamWriter.WriteLine()
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteOutputBeforeSerialize
   
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputAfterDeserialize(myMessage As SoapMessage)
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine()
      
      myStreamWriter.WriteLine("The values of the out parameter are :")
      myStreamWriter.WriteLine("The value of the out parameter is : {0}", _
                                             myMessage.GetOutParameterValue(0))
      
      myStreamWriter.WriteLine("The values of the return parameter are :")
      If Not (myMessage.Exception Is Nothing) Then
         myStreamWriter.WriteLine("Exception2 : " + myMessage.Exception.Message)
      End If
      myStreamWriter.WriteLine("The value of the return parameter is : {0}", _
                                                      myMessage.GetReturnValue())
      
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
   End Sub 'WriteInputAfterDeserialize
   
   
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutputAfterSerialize(myMessage As SoapMessage)
      myNewStream.Position = 0
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.Flush()
      Copy(myNewStream, myFileStream)
      
      myFileStream.Close()
      myNewStream.Position = 0
      Copy(myNewStream, myOldStream)
   End Sub 'WriteOutputAfterSerialize
   
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputBeforeDeserialize(myMessage As SoapMessage)
      Copy(myOldStream, myNewStream)
      Dim myFileStream As New FileStream(myFileName, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + DateTime.Now)
      
      Dim myStream As Stream = myMessage.Stream
      myStreamWriter.Write("Length of data in the current response: ")
      myStreamWriter.WriteLine(myStream.Length)
      
      myStreamWriter.Flush()
      myNewStream.Position = 0
      Copy(myNewStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      myNewStream.Position = 0
   End Sub 'WriteInputBeforeDeserialize
   
   ' Return a new 'MemoryStream' instance for SOAP processing.
   Public Overrides Function ChainStream(myStream As Stream) As Stream
      myOldStream = myStream
      myNewStream = New MemoryStream()
      Return myNewStream
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

   ' Set the name of the log file where SOAP messages will be stored.
   Public Sub New()
      MyBase.New()
      myFilename = "C:\logClient.txt"
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

Public Class MySoapHeader
   Inherits SoapHeader
   Public [myText] As String
End Class 'MySoapHeader

<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", _
      [Namespace] := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   Public mySoapHeader1 As MySoapHeader
   
   <SoapHeaderAttribute("mySoapHeader1", Direction := SoapHeaderDirection.In), _
   System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", _
   Use := System.Web.Services.Description.SoapBindingUse.Literal, _
   ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
   MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single, ByRef returnValue As _
                                                            System.Single) As System.Single
      mySoapHeader1 = New MySoapHeader()
      mySoapHeader1.myText = "This is the first soap header"
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      returnValue = CType(results(1), System.Single)
      Return CType(results(0), System.Single)
   End Function 'Add
   
   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/SoapMessage_Exception.vb.asmx"
   End Sub 'New
   
   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
                  callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd
   
   Public Function EndAdd(asyncResult As System.IAsyncResult, ByRef returnValue As System.Single) _
                                                                              As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      returnValue = CType(results(1), System.Single)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc