---
title: "Hosting the Data Service (WCF Data Services)"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "WCF Data Services, configuring"
  - "WCF Data Services, Windows Communication Foundation"
ms.assetid: b48f42ce-22ce-4f8d-8f0d-f7ddac9125ee
---
# Hosting the Data Service (WCF Data Services)

By using [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you can create a service that exposes data as an [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feed. This data service is defined as a class that inherits from <xref:System.Data.Services.DataService%601>. This class provides the functionality required to process request messages, perform updates against the data source, and generate responses messages, as required by [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]. However, a data service cannot bind to and listen on a network socket for incoming HTTP requests. For this required functionality, the data service relies on a hosting component.

The data service host performs the following tasks on behalf of the data service:

-   Listens for requests and routes these requests to the data service.

-   Creates an instance of the data service for each request.

-   Requests that the data service process the incoming request.

-   Sends the response on behalf of the data service.

To simplify hosting a data service, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] is designed to integrate with Windows Communication Foundation (WCF). The data service provides a default WCF implementation that serves as the data service host in an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application. Therefore, you can host a data service in one of the following ways:

-   In an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application.

-   In a managed application that supports self-hosted WCF services.

-   In some other custom data service host.

## Self-Hosted WCF Services

Because it incorporates a WCF implementation, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] support self-hosting a data service as a WCF service. A service can be self-hosted in any [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] application, such as a console application. The <xref:System.Data.Services.DataServiceHost> class, which inherits from <xref:System.ServiceModel.Web.WebServiceHost>, is used to instantiate the data service at a specific address.

Self-hosting can be used for development and testing because it can make it easier to deploy and troubleshoot the service. However, this kind of hosting does not provide the advanced hosting and management features provided by [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] or by Internet Information Services (IIS). For more information, see [Hosting in a Managed Application](../../../../docs/framework/wcf/feature-details/hosting-in-a-managed-application.md).

## Defining a Custom Data Service Host

For cases where the WCF host implementation is too restrictive, you can also define a custom host for a data service. Any class that implements <xref:System.Data.Services.IDataServiceHost> interface can be used as the network host for a data service. A custom host must implement the <xref:System.Data.Services.IDataServiceHost> interface and be able to handle the following basic responsibilities of the data service host:

-   Provide the data service with the service root path.

-   Process request and response headers information to the appropriate <xref:System.Data.Services.IDataServiceHost> member implementation.

-   Handle exceptions raised by the data service.

-   Validate parameters in the query string.

## See Also

- [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)
- [Exposing Your Data as a Service](../../../../docs/framework/data/wcf/exposing-your-data-as-a-service-wcf-data-services.md)
- [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md)