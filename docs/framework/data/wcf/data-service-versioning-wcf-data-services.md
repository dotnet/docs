---
title: "Data Service Versioning (WCF Data Services)"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "versioning, WCF Data Services"
  - "versioning [WCF Data Services]"
  - "WCF Data Services, versioning"
ms.assetid: e3e899cc-7f25-4f67-958f-063f01f79766
---
# Data Service Versioning (WCF Data Services)
The [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] enables you to create data services so that clients can access data as resources using URIs that are based on a data model. OData also supports the definition of service operations. After initial deployment, and potentially several times during their lifetime, these data services may need to be changed for a variety of reasons, such as changing business needs, information technology requirements, or to address other issues. When you make changes to an existing data service, you must consider whether to define a new version of your data service and how best to minimize the impact on existing client applications. This topic provides guidance on when and how to create a new version of a data service. It also describes how WCF Data Services handles an exchange between clients and data services that support different versions of the OData protocol.

## Versioning a WCF Data Service
 Once a data service is deployed and the data is being consumed, changes to the data service have the potential to cause compatibility issues with existing client applications. However, because changes are often required by the overall business needs of the service, you must consider when and how to create a new version of your data service with the least impact on client applications.

### Data Model Changes that Recommend a New Data Service Version
 When considering whether to publish a new version of a data service, it is important to understand how the different kinds of changes may affect client applications. Changes to a data service that might require you to create a new version of a data service can be divided into the following two categories:

-   Changes to the service contract—which include updates to service operations, changes to the accessibility of entity sets (feeds), version changes, and other changes to service behaviors.

-   Changes to the data contract—which include changes to the data model, feed formats, or feed customizations.

 The following table details for which kinds of changes you should consider publishing a new version of the data service:

|Type of Change|Requires a new version|New version not needed|
|--------------------|----------------------------|----------------------------|
|Service operations|-   Add new parameter<br />-   Change return type<br />-   Remove service operation|-   Delete existing parameter<br />-   Add new service operation|
|Service behaviors|-   Disable count requests<br />-   Disable projection support<br />-   Increase the required data service version|-   Enable count requests<br />-   Enable projection support<br />-   Decrease the required data service version|
|Entity set permissions|-   Restrict entity set permissions<br />-   Change response code (new first digit value) <sup>1</sup>|-   Relax entity set permissions<br />-   Change response code (same first digit value)|
|Entity properties|-   Remove existing property or relationship<br />-   Add non-nullable property<br />-   Change existing property|-   Add nullable property<sup>2</sup>|
|Entity sets|-   Remove entity set|-   Add derived type<br />-   Change base type<br />-   Add entity set|
|Feed customization|-   Change entity-property mapping||

 <sup>1</sup> This may depend on how strictly a client application relies on receiving a specific error code.

 <sup>2</sup> You can set the <xref:System.Data.Services.Client.DataServiceContext.IgnoreMissingProperties%2A> property to `true` to have the client ignore any new properties sent by the data service that are not defined on the client. However, when inserts are made, the properties not included by the client in the POST request are set to their default values. For updates, any existing data in a property unknown to the client might be overwritten with default values. In this case, you should send the update as a MERGE request, which is the default. For more information, see [Managing the Data Service Context](../../../../docs/framework/data/wcf/managing-the-data-service-context-wcf-data-services.md).

### How to Version a Data Service
 When required, a new data service version is defined by creating a new instance of the service with an updated service contract or data model. This new service is then exposed by using a new URI endpoint, which differentiates it from the previous version. For example:

-   Old version: `http://services.odata.org/Northwind/v1/Northwind.svc/`

-   New version: `http://services.odata.org/Northwind/v2/Northwind.svc/`

 When upgrading a data service, clients will need to also be updated based on the new data service metadata and to use the new root URI. When possible, you should maintain the previous version of the data service to support clients that have not yet been upgraded to use the new version. Older versions of a data service can be removed when they are no longer needed. You should consider maintaining the data service endpoint URI in an external configuration file.

## OData Protocol Versions
 As new versions of OData are released, client applications may not be using the same version of the OData protocol that is supported by the data service. An older client application may access a data service that supports a newer version of OData. A client application may also be using a newer version of the WCF Data Services client library, which supports a newer version of OData than does the data service that is being accessed.

 WCF Data Services leverages the support provided by OData to handle such versioning scenarios. There is also support for generating and using data model metadata to create client data service classes when the client uses a different version of OData than the data service uses. For more information, see [OData: Protocol Versioning](https://go.microsoft.com/fwlink/?LinkId=186071).

### Version Negotiation
 The data service can be configured to define the highest version of the OData protocol that will be used by the service, regardless of the version requested by the client. You can do this by specifying a <xref:System.Data.Services.Common.DataServiceProtocolVersion> value for the <xref:System.Data.Services.DataServiceBehavior.MaxProtocolVersion%2A> property of the <xref:System.Data.Services.DataServiceBehavior> used by the data service. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).

 When an application uses the WCF Data Services client libraries to access a data service, the libraries automatically set these headers to the correct values, depending on the version of OData and the features that are used in your application. By default, WCF Data Services uses the lowest protocol version that supports the requested operation.

 The following table details the versions of [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] and [!INCLUDE[silverlight](../../../../includes/silverlight-md.md)] that include WCF Data Services support for specific versions of the OData protocol.

|OData Protocol Version|Support introduced in…|
|-----------------------------------------------------------------------------------|----------------------------|
|Version 1|-   [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] Service Pack 1 (SP1)<br />-   [!INCLUDE[silverlight](../../../../includes/silverlight-md.md)] version 3|
|Version 2|-   [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)]<br />-   An update to [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] SP1. You can download and install the update from the [Microsoft Download Center](https://go.microsoft.com/fwlink/?LinkId=158125).<br />-   [!INCLUDE[silverlight](../../../../includes/silverlight-md.md)] version 4|
|Version 3|-   You can download and install a pre-release version that supports OData version 3 from the [Microsoft Download Center](https://go.microsoft.com/fwlink/?LinkId=203885).|

### Metadata Versions
 By default, WCF Data Services uses version 1.1 of CSDL to represent a data model. This is always the case for data models that are based on either a reflection provider or a custom data service provider. However, when the data model is defined by using the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)], the version of CSDL returned is the same as the version that is used by the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)]. The version of the CSDL is determined by the namespace of the [Schema element (CSDL)](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec#schema-element-csdl).

 The `DataServices` element of the returned metadata also contains a `DataServiceVersion` attribute, which is the same value as the `DataServiceVersion` header in the response message. Client applications, such as the **Add Service Reference** dialog box in Visual Studio, use this information to generate client data service classes that work correctly with the version of WCF Data Services that host the data service. For more information, see [OData: Protocol Versioning](https://go.microsoft.com/fwlink/?LinkId=186071).

## See also

- [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)
- [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)
