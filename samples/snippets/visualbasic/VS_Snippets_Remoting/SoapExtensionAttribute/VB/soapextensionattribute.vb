' System.Web.Services.Protocols.SoapExtensionAttribute
' System.Web.Services.Protocols.SoapExtensionAttribute.ExtensionType
' System.Web.Services.Protocols.SoapExtensionAttribute.Priority

'  The following example demonstrates the 'ExtensionType'
'  and 'Priority' attribute of the 'SoapExtensionAttribute' class.
'  The program extends the 'SoapExtension' class to create a class
'  that is used to log the SOAP messages transferred for a web service
'  method invocation. To associate this 'SoapExtension' class with the
'  web service method on the client proxy, a class that extends from
'  'SoapExtensionAttribute' is used. This 'SoapExtensionAttribute'
'  is applied to a client proxy method which is associated with a
'  web service method. Whenever this method is invoked on the client
'  side all the SOAP message that get transffered both from the client
'  and the server(which is hosting the web service) are written into
'  a log file. 

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

' Define a SOAP Extension that traces the SOAP request and SOAP response
' for the XML Web service method the SOAP extension is applied to.
Public Class TraceExtension
    Inherits SoapExtension

    Private oldStream As Stream
    Private newStream As Stream
    Private m_filename As String

    ' Save the Stream representing the SOAP request or SOAP response into
    ' a local memory buffer.
    Public Overrides Function ChainStream(ByVal stream As Stream) As Stream
        oldStream = stream
        newStream = New MemoryStream()
        Return newStream
    End Function

    ' When the SOAP extension is accessed for the first time, the XML Web
    ' service method it is applied to is accessed to store the file
    ' name passed in, using the corresponding SoapExtensionAttribute.    
    Public Overloads Overrides Function GetInitializer(ByVal methodInfo As _
        LogicalMethodInfo, _
    ByVal attribute As SoapExtensionAttribute) As Object
        Return CType(attribute, TraceExtensionAttribute).Filename
    End Function

    ' The SOAP extension was configured to run using a configuration file
    ' instead of an attribute applied to a specific XML Web service
    ' method.  Return a file name based on the class implementing the Web
    ' Service's type.
    Public Overloads Overrides Function GetInitializer(ByVal WebServiceType As _
      Type) As Object
        ' Return a file name to log the trace information to, based on the
        ' type.
        Return "C:\" + WebServiceType.FullName + ".log"
    End Function

    ' Receive the file name stored by GetInitializer and store it in a
    ' member variable for this specific instance.
    Public Overrides Sub Initialize(ByVal initializer As Object)
        m_filename = CStr(initializer)
    End Sub

    ' If the SoapMessageStage is such that the SoapRequest or SoapResponse
    ' is still in the SOAP format to be sent or received over the network,
    ' save it out to file.
    Public Overrides Sub ProcessMessage(ByVal message As SoapMessage)
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
    End Sub

    ' Write the SOAP message out to a file.
    Public Sub WriteOutput(ByVal message As SoapMessage)
        newStream.Position = 0
        Dim fs As New FileStream(m_filename, FileMode.Append, _
                                 FileAccess.Write)
        Dim w As New StreamWriter(fs)
        w.WriteLine("-----Response at " + DateTime.Now.ToString())
        w.Flush()
        Copy(newStream, fs)
        w.Close()
        newStream.Position = 0
        Copy(newStream, oldStream)
    End Sub

    ' Write the SOAP message out to a file.
    Public Sub WriteInput(ByVal message As SoapMessage)
        Copy(oldStream, newStream)
        Dim fs As New FileStream(m_filename, FileMode.Append, _
                                 FileAccess.Write)
        Dim w As New StreamWriter(fs)

        w.WriteLine("----- Request at " + DateTime.Now.ToString())
        w.Flush()
        newStream.Position = 0
        Copy(newStream, fs)
        w.Close()
        newStream.Position = 0
    End Sub

    Sub Copy(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim reader As New StreamReader(fromStream)
        Dim writer As New StreamWriter(toStream)
        writer.WriteLine(reader.ReadToEnd())
        writer.Flush()
    End Sub
End Class
' <Snippet1>
' A SoapExtensionAttribute  that can be associated with an
' XML Web service method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class TraceExtensionAttribute
    Inherits SoapExtensionAttribute

    Private m_filename As String = "c:\log.txt"
    Private m_priority As Integer

   ' <Snippet2>
   ' Return the type of TraceExtension.
    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(TraceExtension)
        End Get
    End Property
    ' </Snippet2>

   ' <Snippet3>
   ' User can set priority of the TraceExtension.
    Public Overrides Property Priority() As Integer
        Get
            Return m_priority
        End Get
        Set(ByVal Value As Integer)
            m_priority = value
        End Set
    End Property
    '</Snippet3>

    Public Property Filename() As String
        Get
            Return m_filename
        End Get
        Set(ByVal Value As String)
            m_filename = value
        End Set
    End Property
End Class
' </Snippet1>

<System.Web.Services.WebServiceBindingAttribute _
   (Name := "MathSvcSoap", [Namespace] := "http://tempuri.org/")> _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   
   <System.Diagnostics.DebuggerStepThroughAttribute()> _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapExtensionAttribute_vb.asmx"
   End Sub 'New
   
   
   <System.Web.Services.Protocols.SoapDocumentMethodAttribute _
    ("http://tempuri.org/Add", Use := System.Web.Services.Description.SoapBindingUse.Literal, _
                 ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
                 TraceExtensionAttribute()> _
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