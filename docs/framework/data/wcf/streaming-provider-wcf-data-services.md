---
title: "Streaming Provider (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF Data Services, providers"
  - "WCF Data Services, binary data"
  - "streaming data provider [WCF Data Services]"
  - "WCF Data Services, streams"
ms.assetid: f0978fe4-5f9f-42aa-a5c2-df395d7c9495
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Streaming Provider (WCF Data Services)
A data service can expose large object binary data. This binary data might represent video and audio streams, images, document files, or other types of binary media. When an entity in the data model includes one or more binary properties, the data service returns this binary data encoded as base-64 inside the entry in the response feed. Because loading and serializing large binary data in this manner can affect performance, the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] defines a mechanism for retrieving binary data independent of the entity to which it belongs. This is accomplished by separating the binary data from the entity into one or more data streams.  
  
-   Media resource - binary data that belongs to an entity, such as a video, audio, image or other type of media resource stream.  
  
-   Media link entry - an entity that has a reference to a related media resource stream.  
  
 With [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you define a binary resource stream by implementing a streaming data provider. The streaming provider implementation supplies the data service with the media resource stream associated with a specific entity as an <xref:System.IO.Stream> object. This implementation enables the data service to accept and return media resources over HTTP as binary data streams of a specified MIME type.  
  
 Configuring a data service to support the streaming of binary data requires the following steps:  
  
1.  Attribute one or more entities in the data model as a media link entry. These entities should not include the binary data to be streamed. Any binary properties of an entity are always returned in the entry as base-64 encoded binary.  
  
2.  Implement the T:System.Data.Services.Providers.IDataServiceStreamProvider interface.  
  
3.  Define a data service that implements the <xref:System.IServiceProvider> interface. The data service uses the <xref:System.IServiceProvider.GetService%2A> implementation to access the streaming data provider implementation. This method returns the appropriate streaming provider implementation.  
  
4.  Enable large message streams in the Web application configuration.  
  
5.  Enable access to binary resources on the server or in a data source.  
  
 The examples in this topic are based on a sample streaming photo service, which is discussed in depth in the post [Data Services Streaming Provider Series: Implementing a Streaming Provider (Part 1)](http://go.microsoft.com/fwlink/?LinkID=198989). The source code for this sample service is available on the [Streaming Photo Data Service Sample page](http://go.microsoft.com/fwlink/?LinkID=198988) on MSDN Code Gallery.  
  
## Defining a Media Link Entry in the Data Model  
 The data source provider determines the way that an entity is defined as a media link entry in the data model.  
  
 **Entity Framework Provider**  
 To indicate that an entity is a media link entry, add the `HasStream` attribute to the entity type definition in the conceptual model, as in the following example:  
  
 [!code-xml[Astoria Photo Streaming Service#HasStream](../../../../samples/snippets/xml/VS_Snippets_Misc/astoria photo streaming service/xml/photodata.edmx#hasstream)]  
  
 You must also add the namespace `xmlns:m=http://schemas.microsoft.com/ado/2007/08/dataservices/metadata` either to the entity or to the root of the .edmx or .csdl file that defines the data model.  
  
 [!INCLUDE[crexample](../../../../includes/crexample-md.md)] a data service that uses the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] provider and exposes a media resource, see the post [Data Services Streaming Provider Series: Implementing a Streaming Provider (Part 1)](http://go.microsoft.com/fwlink/?LinkID=198989).  
  
 **Reflection Provider**  
 To indicate that an entity is a media link entry, add the <xref:System.Data.Services.Common.HasStreamAttribute> to the class that defines the entity type in the reflection provider.  
  
 **Custom Data Service Provider**  
 When using custom service providers, you implement the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface to define the metadata for your data service. For more information, see [Custom Data Service Providers](../../../../docs/framework/data/wcf/custom-data-service-providers-wcf-data-services.md). You indicate that a binary resource stream belongs to a <xref:System.Data.Services.Providers.ResourceType> by setting the <xref:System.Data.Services.Providers.ResourceType.IsMediaLinkEntry%2A> property to `true` on the <xref:System.Data.Services.Providers.ResourceType> that represents the entity type, which is a media link entry.  
  
## Implementing the IDataServiceStreamProvider Interface  
 To create a data service that supports binary data streams, you must implement the <xref:System.Data.Services.Providers.IDataServiceStreamProvider> interface. This implementation enables the data service to return binary data as a stream to the client and consume binary data as a stream sent from the client. The data service creates an instance of this interface whenever it needs to access binary data as a stream. The <xref:System.Data.Services.Providers.IDataServiceStreamProvider> interface specifies the following members:  
  
|Member name|Description|  
|-----------------|-----------------|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.DeleteStream%2A>|This method is invoked by the data service to delete the corresponding media resource when its media link entry is deleted. When you implement <xref:System.Data.Services.Providers.IDataServiceStreamProvider>, this method contains the code that deletes the media resource associated with the supplied media link entry.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetReadStream%2A>|This method is invoked by the data service to return a media resource as a stream. When you implement <xref:System.Data.Services.Providers.IDataServiceStreamProvider>, this method contains the code that provides a stream that is used by the data service to the return media resource that is associated with the provided media link entry.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetReadStreamUri%2A>|This method is invoked by the data service to return the URI that is used to request the media resource for the media link entry. This value is used to create the `src` attribute in the content element of the media link entry and that is used to request the data stream. When this method returns `null`, the data service automatically determines the URI. Use this method when you need to provide clients with direct access to binary data without using the steam provider.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetStreamContentType%2A>|This method is invoked by the data service to return the Content-Type value of the media resource that is associated with the specified media link entry.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetStreamETag%2A>|This method is invoked by the data service to return the eTag of the data stream that is associated with the specified entity. This method is used when you manage concurrency for the binary data. When this method returns null, the data service does not track concurrency.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A>|This method is invoked by the data service to obtain the stream that is used when receiving the stream sent from the client. When you implement <xref:System.Data.Services.Providers.IDataServiceStreamProvider>, you must return a writable stream to which the data service writes received stream data.|  
|<xref:System.Data.Services.Providers.IDataServiceStreamProvider.ResolveType%2A>|Returns a namespace-qualified type name that represents the type that the data service runtime must create for the media link entry that is associated with the data stream for the media resource that is being inserted.|  
  
## Creating the Streaming Data Service  
 To provide the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] runtime with access to the <xref:System.Data.Services.Providers.IDataServiceStreamProvider> implementation, the data service that you create must also implement the <xref:System.IServiceProvider> interface. The following example shows how to implement the <xref:System.IServiceProvider.GetService%2A> method to return an instance of the `PhotoServiceStreamProvider` class that implements <xref:System.Data.Services.Providers.IDataServiceStreamProvider>.  
  
 [!code-csharp[Astoria Photo Streaming Service#PhotoServiceStreamingProvider](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria photo streaming service/cs/photodata.svc.cs#photoservicestreamingprovider)]
 [!code-vb[Astoria Photo Streaming Service#PhotoServiceStreamingProvider](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria photo streaming service/vb/photodata.svc.vb#photoservicestreamingprovider)]  
  
 For general information about how to create a data service, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).  
  
## Enabling Large Binary Streams in the Hosting Environment  
 When you create a data service in an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web application, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is used to provide the HTTP protocol implementation. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] limits the size of HTTP messages to only 65K bytes. To be able to stream large binary data to and from the data service, you must also configure the Web application to enable large binary files and to use streams for transfer. To do this, add the following in the `<configuration />` element of the application's Web.config file:  
  
  
  
> [!NOTE]
>  You must use a <xref:System.ServiceModel.TransferMode.Streamed?displayProperty=nameWithType> transfer mode to ensure that the binary data in both the request and response messages are streamed and not buffered by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 For more information, see [Streaming Message Transfer](../../../../docs/framework/wcf/feature-details/streaming-message-transfer.md) and [Transport Quotas](../../../../docs/framework/wcf/feature-details/transport-quotas.md).  
  
 By default, Internet Information Services (IIS) also limits the size of requests to 4MB. To enable your data service to receive streams larger than 4MB when running on IIS, you must also set the `maxRequestLength` attribute of the [httpRuntime Element (ASP.NET Settings Schema)](http://msdn.microsoft.com/library/e9b81350-8aaf-47cc-9843-5f7d0c59f369) in the `<system.web />` configuration section, as shown in the following example:  
  
  
  
## Using Data Streams in a Client Application  
 The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library enables you to both retrieve and update these exposed resources as binary streams on the client. For more information, see [Working with Binary Data](../../../../docs/framework/data/wcf/working-with-binary-data-wcf-data-services.md).  
  
## Considerations for Working with a Streaming Provider  
 The following are things to consider when you implement a streaming provider and when you access media resources from a data service.  
  
-   MERGE requests are not supported for media resources. Use a PUT request to change the media resource of an existing entity.  
  
-   A POST request cannot be used to create a new media link entry. Instead, you must issue a POST request to create a new media resource, and the data service creates a new media link entry with default values. This new entity can be updated by a subsequent MERGE or PUT request. You may also consider caching the entity and make updates in the disposer, such as setting the property value to the value of the Slug header in the POST request.  
  
-   When a POST request is received, the data service calls <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A> to create the media resource before it calls <xref:System.Data.Services.IUpdatable.SaveChanges%2A> to create the media link entry.  
  
-   An implementation of <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A> should not return a <xref:System.IO.MemoryStream> object. When you use this kind of stream, memory resource issues will occur when the service receives very large data streams.  
  
-   The following are things to consider when storing media resources in a database:  
  
    -   A binary property that is a media resource should not be included in the data model. All properties exposed in a data model are returned in the entry in a response feed.  
  
    -   To improve performance with a large binary stream, we recommend that you create a custom stream class to store binary data in the database. This class is returned by your <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A> implementation and sends the binary data to the database in chunks. For a [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] database, we recommend that you use a FILESTREAM to stream data into the database when the binary data is larger than 1MB.  
  
    -   Ensure that your database is designed to store the binary large streams that are to be received by your data service.  
  
    -   When a client sends a POST request to insert a media link entry with a media resource in a single request, <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A> is called to obtain the stream before the data service inserts the new entity into the database. A streaming provider implementation must be able to handle this data service behavior. Consider using a separate data table to store the binary data or store the data stream in a file until after the entity has been inserted into the database.  
  
-   When you implement the <xref:System.Data.Services.Providers.IDataServiceStreamProvider.DeleteStream%2A>, <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetReadStream%2A>, or <xref:System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream%2A> methods, you must use the eTag and Content-Type values that are supplied as method parameters. Do not set eTag or Content-Type headers in your <xref:System.Data.Services.Providers.IDataServiceStreamProvider> provider implementation.  
  
-   By default, the client sends large binary streams by using a chunked HTTP Transfer-Encoding. Because the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Development Server does not support this kind of encoding, you cannot use this Web server to host a streaming data service that must accept large binary streams. For more information on [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Development Server, see [Web Servers in Visual Studio for ASP.NET Web Projects](http://msdn.microsoft.com/library/31d4f588-df59-4b7e-b9ea-e1f2dd204328).  
  
<a name="versioning"></a>   
## Versioning Requirements  
 The streaming provider has the following [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol versioning requirements:  
  
-   The streaming provider requires that the data service support version 2.0 of the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol and later versions.  
  
 For more information, see [Data Service Versioning](../../../../docs/framework/data/wcf/data-service-versioning-wcf-data-services.md).  
  
## See Also  
 [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)  
 [Custom Data Service Providers](../../../../docs/framework/data/wcf/custom-data-service-providers-wcf-data-services.md)  
 [Working with Binary Data](../../../../docs/framework/data/wcf/working-with-binary-data-wcf-data-services.md)
