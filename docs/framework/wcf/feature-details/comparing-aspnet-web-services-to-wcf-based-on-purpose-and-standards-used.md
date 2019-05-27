---
title: "Comparing ASP.NET Web Services to WCF Based on Purpose and Standards Used"
ms.date: "03/30/2017"
ms.assetid: d3890278-fa9b-4902-91ea-8da73b7143cc
---
# Comparing ASP.NET Web Services to WCF Based on Purpose and Standards Used
ASP.NET Web services was developed for building applications that send and receive messages by using the Simple Object Access Protocol (SOAP) over HTTP. The structure of the messages can be defined using an XML Schema, and a tool is provided to facilitate serializing the messages to and from .NET Framework objects. The technology can automatically generate metadata to describe Web services in the Web Services Description Language (WSDL), and a second tool is provided for generating clients for Web services from the WSDL.  
  
 WCF is for enabling .NET Framework applications to exchange messages with other software entities. SOAP is used by default, but the messages can be in any format, and conveyed by using any transport protocol. The structure of the messages can be defined using an XML Schema, and there are various options for serializing the messages to and from .NET Framework objects. WCF can automatically generate metadata to describe applications built using the technology in WSDL, and it also provides a tool for generating clients for those applications from the WSDL.  
  
 The standards supported by ASP.NET Web services are documented in [XML Web Services Created Using ASP.NET](https://go.microsoft.com/fwlink/?LinkId=94872). The more extensive list of standards supported by WCF are listed at [Web Services Protocols Supported by System-Provided Interoperability Bindings](../../../../docs/framework/wcf/feature-details/web-services-protocols-supported-by-system-provided-interoperability-bindings.md).  
  
## See also

- [Comparing ASP.NET Web Services to WCF Based on Development](../../../../docs/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-development.md)
