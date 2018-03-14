' <Snippet1>
<%@ WebService Language="VB" class="ThrowSoapException"%>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.Xml

Public Class ThrowSoapException
    Inherits WebService
    
    ' This XML Web service method generates a SOAP Client Fault code 
    <WebMethod()> _
    Public Sub myThrow()
        
        ' Build the detail element of the SOAP fault.
        Dim doc As New System.Xml.XmlDocument()
        Dim node As System.Xml.XmlNode = doc.CreateNode(XmlNodeType.Element, _
            SoapException.DetailElementName.Name, _
            SoapException.DetailElementName.Namespace)
 
        ' Build specific details for the SoapException.
        ' Add first child of detail XML element.
        Dim details As System.Xml.XmlNode = doc.CreateNode(XmlNodeType.Element, _
            "mySpecialInfo1", "http://tempuri.org/")

        ' Add second child of detail XML element with an attribute.
        Dim details2 As System.Xml.XmlNode = doc.CreateNode(XmlNodeType.Element, _
            "mySpecialInfo2", "http://tempuri.org/")
        Dim attr As XmlAttribute = doc.CreateAttribute("t", "attrName", _
            "http://tempuri.org/")
        attr.Value = "attrValue"
        details2.Attributes.Append(attr)

        ' Append the two child elements to the detail node.
        node.AppendChild(details)
        node.AppendChild(details2)
                
        'Throw the exception    
        Dim se As New SoapException("Fault occurred", SoapException.ClientFaultCode, _
                                    Context.Request.Url.AbsoluteUri, node)
        Throw se
        Return
    End Sub
End Class

' </Snippet1>
