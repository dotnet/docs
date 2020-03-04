<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="System.Web.Script.Services.VB.WebService" %>

Imports System.Web
Imports System.Web.Services
Imports System.Xml
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

Namespace System.Web.Script.Services.VB
    
    <WebService(Namespace:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ScriptService()> _
    Public Class WebService
        Inherits System.Web.Services.WebService
    
        Private _xmlString As String = _
        "<?xml version=""1.0"" encoding=""utf-8"" ?>" + _
        "  <message>" + _
        "    <content>" + _
        "      Welcome to the asynchronous communication layer world!" + _
        "    </content>" + _
        " </message>"
       
        ' This method returns an XmlDocument type.
        ' <Snippet2>
        <WebMethod()> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Xml)> _
        Public Function GetXmlDocument() As XmlDocument
            Dim xmlDoc As New XmlDocument()
            xmlDoc.LoadXml(_xmlString)
            Return xmlDoc

        End Function 'GetXmlDocument
        ' </Snippet2>
 
        
        ' This method uses GET instead of POST.
        ' Its input parameters are sent by the 
        ' client in the URL query string.
        ' <Snippet3>
        <WebMethod()> _
        <ScriptMethod(UseHttpGet:=True)> _
        Public Function EchoStringAndDate(ByVal dt As DateTime, _
        ByVal s As String) As String
            Return s + ":" + dt.ToString()
        End Function 'EchoStringAndDate
        ' </Snippet3>
        
        <WebMethod()> _
        Public Function GetServerTime() As String
        
            Dim serverTime As String = _
            String.Format("The current time is {0}.", DateTime.Now)
        
            Return serverTime
    
        End Function 'GetServerTime
     
        
        <WebMethod()> _
        Public Function Add(ByVal a As Integer, _
        ByVal b As Integer) As String
        
            Dim addition As Integer = a + b
            Dim result As String = _
            String.Format("The addition result is {0}.", addition.ToString())
        
            Return result
    
        End Function 'Add
        
        ' <Snippet4>
        <WebMethod()> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Xml, _
            XmlSerializeString:=True)> _
        Public Function GetString() As String
            Return "Hello World"
        End Function
        ' </Snippet4>
     
    End Class 'WebService 
    
End Namespace
' </Snippet1>