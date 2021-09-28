---
description: "Learn more about: Anticipating Adopting the Windows Communication Foundation: Easing Future Integration"
title: "Anticipating Adopting the Windows Communication Foundation: Easing Future Integration"
ms.date: "03/30/2017"
ms.assetid: 3028bba8-6355-4ee0-9ecd-c56e614cb474
---
# Anticipating Adopting the Windows Communication Foundation: Easing Future Integration

If you use ASP.NET today, and anticipate using WCF in the future, this topic provides guidance to ensure that new ASP.NET Web services will work well together with WCF applications.  
  
## General Recommendations  

 Adopt ASP.NET 2.0 for any new services. Doing so will provide access to the improvements and enhancements of the new version. However, it will also allow for the possibility of using ASP.NET 2.0 components together with WCF components in the same application.  
  
## Protocols  

 Use ASP.NET 2.0’s new facility for validating conformity to the WS-I Basic Profile 1.1:  
  
```csharp  
[WebService(Namespace = "http://tempuri.org/")]  
[WebServiceBinding(  
     ConformsTo = WsiProfiles.BasicProfile1_1,  
     EmitConformanceClaims=true)]  
public interface IEcho  
```  
  
 ASP.NET Web services that conform to WS-I Basic Profile 1.1 will be interoperable with WCF clients by using WCF predefined binding, <xref:System.ServiceModel.BasicHttpBinding>.  
  
## Service Development  

 Avoid using the <xref:System.Web.Services.Protocols.SoapDocumentServiceAttribute> attribute to have messages routed to methods based on the fully-qualified name of the body element of the SOAP message rather than the SOAPAction HTTP header. WCF uses the SOAPAction HTTP header for routing messages.  
  
## Data Representation  

 The XML into which <xref:System.Xml.Serialization.XmlSerializer> serializes a type by default is semantically identical to the XML into which the <xref:System.Runtime.Serialization.DataContractSerializer> serializes a type, provided the namespace for the XML is explicitly defined. When defining a data type for use with ASP.NET Web services in anticipation of adopting WCF in the future, do the following:  
  
1. Define the type using .NET Framework classes rather than XML Schema.  
  
2. Add only the <xref:System.SerializableAttribute> and the <xref:System.Xml.Serialization.XmlRootAttribute> to the class, using the latter to explicitly define the namespace for the type. Do no add additional attributes from the <xref:System.Xml.Serialization> namespace to control how the .NET Framework class is to be translated into XML.  
  
 By adopting this approach, you should be able to later make the .NET classes into data contracts with the addition of the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> without significantly altering the XML into which the classes are serialized for transmission. The types used in messages by ASP.NET Web services will be able to be processed as data contracts by WCF applications, yielding, amongst other benefits, better performance in WCF applications.  
  
## Security  

 Avoid using the authentication options provided by Internet Information Services (IIS). WCF clients do not support them. If a service needs to be secured, use the options provided by WCF, because these options are richer and are based on standard protocols.  
  
## See also

- [Anticipating Adopting the Windows Communication Foundation: Easing Future Migration](anticipating-adopting-wcf-migration.md)
