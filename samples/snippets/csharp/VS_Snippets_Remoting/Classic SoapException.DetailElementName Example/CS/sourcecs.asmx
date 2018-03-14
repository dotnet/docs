// <Snippet1>
<%@ WebService Language="C#" class="ThrowSoapException"%>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Xml;

public class ThrowSoapException : WebService 
{
    // This XML Web service method generates a SOAP client fault code 
    [WebMethod]
    public void myThrow(){

        // Build the detail element of the SOAP fault.
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.Xml.XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);


        // Build specific details for the SoapException.
        // Add first child of detail XML element.
        System.Xml.XmlNode details = doc.CreateNode(XmlNodeType.Element, "mySpecialInfo1", "http://tempuri.org/");
        System.Xml.XmlNode detailsChild = doc.CreateNode(XmlNodeType.Element, "childOfSpecialInfo", "http://tempuri.org/");
        details.AppendChild(detailsChild);

            
        // Add second child of detail XML element with an attribute.
        System.Xml.XmlNode details2 = doc.CreateNode(XmlNodeType.Element, "mySpecialInfo2", "http://tempuri.org/");
        XmlAttribute attr = doc.CreateAttribute("t", "attrName", "http://tempuri.org/");
        attr.Value = "attrValue";
        details2.Attributes.Append(attr);

        // Append the two child elements to the detail node.
        node.AppendChild(details);
        node.AppendChild(details2);

            
        // Throw the exception.    
        SoapException se = new SoapException("Fault occurred", SoapException.ClientFaultCode,Context.Request.Url.AbsoluteUri,node);

        throw se;
        return;    }
}

// </Snippet1>
