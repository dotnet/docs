---
title: "AJAX Integration and JSON Support"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "AJAX integration and JSON support [WCF]"
ms.assetid: 3851a8fc-d861-4ac1-873c-96af0343d3a7
---
# AJAX Integration and JSON Support
The Windows Communication Foundation (WCF) support for ASP.NET Asynchronous JavaScript and XML (AJAX) and the JavaScript Object Notation (JSON) data format allow WCF services to expose operations to AJAX clients. AJAX clients are Web pages running JavaScript code and accessing these WCF services using HTTP requests. The topics in this section provide information about this support and about how to implement it.  
  
 For more information about ASP.NET AJAX and its integration with ASP.NET 2.0, see [ASP.NET AJAX Overview](https://go.microsoft.com/fwlink/?LinkId=96725).  
  
## In This Section  
 [Creating WCF Services for ASP.NET AJAX](../../../../docs/framework/wcf/feature-details/creating-wcf-services-for-aspnet-ajax.md)  
 Describes how an WCF service can be exposed to AJAX clients by adding the appropriate AJAX endpoint either through configuration or by using a service host factory customized to generate a service host that configures the AJAX endpoint automatically.  
  
 [Creating WCF AJAX Services without ASP.NET](../../../../docs/framework/wcf/feature-details/creating-wcf-ajax-services-without-aspnet.md)  
 Describes how to create an WCF service without using ASP.NET.  
  
 [Support for JSON and Other Data Transfer Formats](../../../../docs/framework/wcf/feature-details/support-for-json-and-other-data-transfer-formats.md)  
 Describes the support of the JSON format typically used (instead of XML) for messaging with ASP.NET AJAX services.  
  
 [How to: Migrate AJAX-Enabled ASP.NET Web Services to WCF](../../../../docs/framework/wcf/feature-details/how-to-migrate-ajax-enabled-aspnet-web-services-to-wcf.md)  
 Describes how to migrate an AJAX-enabled ASP.NET Web service to a WCF Web service.  
  
## See also

- <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory>
- [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
