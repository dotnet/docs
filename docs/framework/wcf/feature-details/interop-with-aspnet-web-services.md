---
description: "Learn more about: Interoperability with ASP.NET Web Services"
title: "Interoperability with ASP.NET Web Services"
ms.date: "03/30/2017"
ms.assetid: 622422f8-6651-442f-b8be-e654a4aabcac
---
# Interoperability with ASP.NET Web Services

Interoperability between ASP.NET Web services and Windows Communication Foundation (WCF) Web services can be achieved by ensuring that services implemented using both technologies conform to the WS-I Basic Profile 1.1 specification. ASP.NET Web services that conform to WS-I Basic Profile 1.1 are interoperable with WCF clients by using WCF system-provided binding, <xref:System.ServiceModel.BasicHttpBinding>.  
  
 Use ASP.NET 2.0 option of adding the <xref:System.Web.Services.WebService> and <xref:System.Web.Services.WebMethodAttribute> attributes to an interface rather than to a class, and writing a class to implement the interface, as shown in the following sample code.  
  
```csharp
[WebService]  
public interface IEcho  
{  
    [WebMethod]  
    string Echo(string input);  
}  
  
public class Service : IEcho  
{  
  
   public string Echo(string input)  
   {  
        return input;  
    }  
}  
```  
  
 Using this option is preferred, because the interface with the <xref:System.Web.Services.WebService> attribute constitutes a contract for the operations performed by the service that can be reused with various classes that might implement that same contract in different ways.  
  
 Avoid using the <xref:System.Web.Services.Protocols.SoapDocumentServiceAttribute> attribute to have messages routed to methods based on the fully-qualified name of the body element of the SOAP message rather than the `SOAPAction` HTTP header. WCF uses the `SOAPAction` HTTP header for routing messages.  
  
 The XML into which <xref:System.Xml.Serialization.XmlSerializer> serializes a type by default is semantically identical to the XML into which the <xref:System.Runtime.Serialization.DataContractSerializer> serializes a type, provided the namespace for the XML is explicitly defined. When defining a data type for use with ASP.NETWeb services in anticipation of adopting WCF, do the following:  
  
- Define the type using .NET Framework classes rather than XML Schema.  
  
- Add only the <xref:System.SerializableAttribute> and the <xref:System.Xml.Serialization.XmlRootAttribute> to the class, using the latter to explicitly define the namespace for the type. Do not add additional attributes from the <xref:System.Xml.Serialization> namespace to control how the .NET Framework class is to be translated into XML.  
  
- By adopting this approach, you should be able to later make the .NET classes into data contracts with the addition of the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> without significantly altering the XML into which the classes are serialized for transmission. The types used in messages by ASP.NET Web services can be processed as data contracts by WCF applications, yielding, among other benefits, better performance in WCF applications.  
  
 Avoid using the authentication options provided by Internet Information Services (IIS). WCF clients do not support them. If a service must be secured, use the options provided by WCF, because these options are robust and are based on standard protocols.  
  
## Performance impact caused by loading the ServiceModel HttpModule  

 In the .NET Framework 3.0, the WCF `HttpModule` was installed in the root Web.config file such that every ASP.NET application was WCF enabled. This might affect performance, so you can remove `ServiceModel` for the Web.config file as shown in the following example.  
  
```xml  
<httpModules>  
    <remove name="ServiceModel" />  
</httpModules>
```  
  
## See also

- [How to: Configure WCF Service to Interoperate with ASP.NET Web Service Clients](config-wcf-service-with-aspnet-web-service.md)
