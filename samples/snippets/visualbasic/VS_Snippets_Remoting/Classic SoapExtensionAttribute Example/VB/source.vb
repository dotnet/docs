Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

' Class added so sample will compile
Public Class TraceExtension
End Class
 
' <Snippet1>
' Create a SoapExtensionAttribute for a SOAP extension that can be
' applied to an XML Web service method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class TraceExtensionAttribute
    Inherits SoapExtensionAttribute
    
    Private m_filename As String = "c:\log.txt"
    Private m_priority As Integer

   ' Return the type of 'TraceExtension' class.
    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(TraceExtension)
        End Get
    End Property

   ' User can set priority of the 'TraceExtension'.
    Public Overrides Property Priority() As Integer
        Get
            Return m_priority
        End Get
        Set(ByVal Value As Integer)
            m_priority = value
        End Set
    End Property

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
