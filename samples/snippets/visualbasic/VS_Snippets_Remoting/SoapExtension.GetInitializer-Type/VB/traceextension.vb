
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO


' Define a SOAP Extension that traces the SOAP request and SOAP response
' for the XML Web service method, the SOAP extension is applied to.
Public Class TraceExtension
    Inherits SoapExtension
    
    Private m_oldStream As Stream
    Private m_newStream As Stream
    Private m_filename As String    
    
    ' When the SOAP extension is accessed for the first time the XML Web service
    ' method it is applied is accessed store the file name passed in using the
    ' corresponding SoapExtensionAttribute.    
    Public Overloads Overrides Function GetInitializer(methodInfo As LogicalMethodInfo, _
        attribute As SoapExtensionAttribute) As Object 
   
        Return CType(attribute, TraceExtensionAttribute).Filename
    End Function

'<Snippet1>
    ' The extension was configured to run using a configuration file instead of an attribute applied to a 
    ' specific XML Web service method.  Return a file name based on the class implementing the XML Web service's type.
    Public Overloads Overrides Function GetInitializer(WebServiceType As Type) As Object
	   ' Return a file name to log the trace information to based on the passed in type.
        Return "C:\" + WebServiceType.FullName + ".log"
    End Function
'</Snippet1>    

    ' Receive the filename stored by GetInitializer and store it in a member
    ' variable for this specific instance.
    Public Overrides Sub Initialize(initializer As Object)
        m_filename = CStr(initializer)
    End Sub
    
    ' If the SoapMessageStage is such that the SoapRequest or SoapResponse is
    ' still in the SOAP format to be sent or received over the wire, save it
    ' out to filename passed in using the SoapExtensionAttribute
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
    End Sub
    
    ' Save the Stream representing the SOAP request or SOAP response into a
    ' local memory buffer
    Public Overrides Function ChainStream(stream As Stream) As Stream
        m_oldStream = stream
        m_newStream = New MemoryStream()
        Return m_newStream
    End Function
    
    Public Sub WriteOutput(message As SoapMessage)
        m_newStream.Position = 0
        Dim fs As New FileStream(m_filename, FileMode.Append, FileAccess.Write)
        Dim w As New StreamWriter(fs)
        w.WriteLine("---------------------------------- Response at " _
           + DateTime.Now.ToString())
        w.Flush()
        Copy(m_newStream, fs)
        fs.Close()
        m_newStream.Position = 0
        Copy(m_newStream, m_oldStream)
    End Sub    
    
    Public Sub WriteInput(message As SoapMessage)
        Copy(m_oldStream, m_newStream)
        Dim fs As New FileStream(m_filename, FileMode.Append, FileAccess.Write)
        Dim w As New StreamWriter(fs)
        w.WriteLine("================================== Request at " _
           + DateTime.Now.ToString())
        w.Flush()
        m_newStream.Position = 0
        Copy(m_newStream, fs)
        fs.Close()
        m_newStream.Position = 0
    End Sub    
    
    Sub Copy(fromStream As Stream, toStream As Stream)        
        Dim reader As New StreamReader(fromStream)
        Dim writer As New StreamWriter(toStream)
        writer.WriteLine(reader.ReadToEnd())
        writer.Flush()
    End Sub
End Class


' Create a SoapExtensionAttribute for our SOAP Extension that can be
' applied to an XML Web service method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class TraceExtensionAttribute
    Inherits SoapExtensionAttribute
    
    Private m_filename As String = "c:\log.txt"
    Private m_priority As Integer    
    
    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(TraceExtension)
        End Get
    End Property 
    
    Public Overrides Property Priority() As Integer
        Get
            Return m_priority
        End Get
        Set
            m_priority = value
        End Set
    End Property 
    
    Public Property Filename() As String
        Get
            Return m_filename
        End Get
        Set
            m_filename = value
        End Set
    End Property
End Class