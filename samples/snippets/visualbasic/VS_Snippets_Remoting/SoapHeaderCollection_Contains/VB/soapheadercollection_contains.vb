' System.Web.Services.Protocols.SoapHeaderCollection.Contains(SoapHeader); System.Web.Services.Protocols.SoapHeaderCollection.IndexOf(); System.Web.Services.Protocols.SoapHeaderCollection.Item; System.Web.Services.Protocols.SoapHeaderCollection.Remove(SoapHeader)

' The following example demonstrates the methods 'Contains','IndexOf' and 
' 'Remove' and the property 'Item' of the 'SoapHeaderCollection' class. The 
' program extends the 'SoapExtension' class to create a class that is 
' used to log the SOAP messages transferred for a web service method 
' invocation. Whenever this method is invoked on the client side 
' all the SOAP message that get transfered both from the client
' and the server are written into a log file.

Imports System
Imports System.IO
Imports System.Web.Services.Protocols
Imports System.Web.Services
Imports System.Xml

Public Class MySoapExtension
   Inherits SoapExtension
   Private oldStream As Stream
   Private newStream As Stream
   Private myFilename As String
   
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(methodInfo As LogicalMethodInfo, _
                              myAttribute As SoapExtensionAttribute) As Object
      Return CType(myAttribute, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer
   
   ' Return the filename that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(myFilename As Type) As Object
      Return CType(myFilename, Type)
   End Function 'GetInitializer
   
   ' Save the name of the log file that shall save the SOAP messages.
   Public Overrides Sub Initialize(initializer As Object)
      myFilename = CStr(initializer)
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
      Dim myFileStream As New FileStream(myFilename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("================================== Request at " + DateTime.Now)
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
      Dim myFileStream As New FileStream(myFilename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine("---------------------------------- Response at " + DateTime.Now)
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myStreamWriter.Close()
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInput
   
   ' Return a new 'MemoryStream' instance for SOAP processing.
   Public Overrides Function ChainStream(myStream As Stream) As Stream
      oldStream = myStream
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
   Public [Text] As String
End Class 'MySoapHeader

<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", [Namespace] := "http://tempuri.org/")>  _
Public Class MathService
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   Public mySoapHeaders() As SoapHeader
   
   <SoapHeaderAttribute("mySoapHeaders", Direction := SoapHeaderDirection.In, Required := False), _
      System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", _
                     Use := System.Web.Services.Description.SoapBindingUse.Literal, _
                     ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
                     MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single) As System.Single
      Dim mySoapHeaderCollection As New SoapHeaderCollection()
      Dim myFirstSoapHeader As MySoapHeader
      myFirstSoapHeader = New MySoapHeader()
      myFirstSoapHeader.Text = "This is the first soap header"
      mySoapHeaderCollection.Add(myFirstSoapHeader)
      
      Dim mySecondSoapHeader As New MySoapHeader()
      mySecondSoapHeader.Text = "This is the second soap header"
      mySoapHeaderCollection.Add(mySecondSoapHeader)
' <Snippet1>
        ' Check to see whether the collection contains mySecondSoapHeader.
        If mySoapHeaderCollection.Contains(mySecondSoapHeader) Then
            ' Get the index of mySecondSoapHeader from the collection.
            Console.WriteLine("Index of mySecondSoapHeader: " & _
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader).ToString())

            ' Get the SoapHeader from the collection.
            Dim mySoapHeader1 As MySoapHeader = CType(mySoapHeaderCollection( _
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader)), _
                MySoapHeader)
            Console.WriteLine("SoapHeader retrieved from the collection: " _
                & mySoapHeader1.ToString())

           ' Remove a SoapHeader from the collection.
           mySoapHeaderCollection.Remove(mySoapHeader1)
           Console.WriteLine("Number of items after removal: {0}", _
               & mySoapHeaderCollection.Count)
        Else
        Console.WriteLine( _
            "mySoapHeaderCollection does not contain mySecondSoapHeader.")
        End If
' </Snippet1>
      mySoapHeaders = New MySoapHeader(mySoapHeaderCollection.Count-1) {}
      
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0)
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add
   
   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathService_SoapHeaderCollection.vb.asmx"
   End Sub 'New
   
   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
         callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd
   
   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathService
