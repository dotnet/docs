---
title: "Object Materialization (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, client library"
  - "WCF Data Services, querying"
ms.assetid: f0dbf7b0-0292-4e31-9ae4-b98288336dc1
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Object Materialization (WCF Data Services)
When you use the **Add Service Reference** dialog to consume an [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feed in a .NET Framework-based client application, equivalent data classes are generated for each entity type in the data model exposed by the feed. For more information, see [Generating the Data Service Client Library](../../../../docs/framework/data/wcf/generating-the-data-service-client-library-wcf-data-services.md). Entity data that is returned by a query is materialized into an instance of one of these generated client data service classes. For information about merge options and identity resolution for tracked objects, see [Managing the Data Service Context](../../../../docs/framework/data/wcf/managing-the-data-service-context-wcf-data-services.md).  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] also enables you to define your own client data service classes rather than using the tool-generated data classes. This enables you to use your own data classes, also known as "plain-old CLR object" (POCO) data classes. When using these types of custom data classes, you should attribute the data class with either <xref:System.Data.Services.Common.DataServiceKeyAttribute> or <xref:System.Data.Services.Common.DataServiceEntityAttribute> and ensure that type names on the client match type names in the data model of the data service.  
  
 After the library receives the query response message, it materializes the returned data from the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed into instances of client data service classes that are of the type of the query. The general process for materializing these objects is as follows:  
  
1.  The client library reads the serialized type from the `entry` element in the response message feed and attempts to create a new instance of the correct type, in one of the following ways:  
  
    -   When the type declared in the feed has the same name as the type of the <xref:System.Data.Services.Client.DataServiceQuery%601>, a new instance of this type is created by using the empty constructor.  
  
    -   When the type declared in the feed has the same name as a type that is derived from the type of the <xref:System.Data.Services.Client.DataServiceQuery%601>, a new instance of this derived type is created by using the empty constructor.  
  
    -   When the type declared in the feed cannot be matched to the type of the <xref:System.Data.Services.Client.DataServiceQuery%601> or any derived types, a new instance of the queried type is created by using the empty constructor.  
  
    -   When the <xref:System.Data.Services.Client.DataServiceContext.ResolveType%2A> property is set, the supplied delegate is called to override the default name-based type mapping and a new instance of the type returned by the <xref:System.Func%602> is created instead. If this delegate returns a null value, a new instance of the queried type is created instead. It may be required to override the default name-based type name mapping to support inheritance scenarios.  
  
2.  The client library reads the URI value from the `id` element of the `entry`, which is the identity value of the entity. Unless a <xref:System.Data.Services.Client.DataServiceContext.MergeOption%2A> value of <xref:System.Data.Services.Client.MergeOption.NoTracking> is used, the identity value is used to track the object in the <xref:System.Data.Services.Client.DataServiceContext>. The identity value is also used to guarantee that only a single entity instance is created, even when an entity is returned multiple times in the query response.  
  
3.  The client library reads properties from the feed entry and set the corresponding properties on the newly created object. When an object that has the same identity value already occurs in the <xref:System.Data.Services.Client.DataServiceContext>, the properties are set based on the <xref:System.Data.Services.Client.MergeOption> setting of the <xref:System.Data.Services.Client.DataServiceContext>. The response might contain property values for which a corresponding property does not occur in the client type. When this occurs, the action depends on the value of the <xref:System.Data.Services.Client.DataServiceContext.IgnoreMissingProperties%2A> property of the <xref:System.Data.Services.Client.DataServiceContext>. When this property is set to `true`, the missing property is ignored. Otherwise, an error is raised. Properties are set as follows:  
  
    -   Scalar properties are set to the corresponding value in the entry in the response message.  
  
    -   Complex properties are set to a new complex type instance, which are set with the properties of the complex type from the response.  
  
    -   Navigation properties that return a collection of related entities are set to a new or existing instance of <xref:System.Collections.Generic.ICollection%601>, where `T` is the type of the related entity. This collection is empty unless the related objects have been loaded into the <xref:System.Data.Services.Client.DataServiceContext>. For more information, see [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md).  
  
        > [!NOTE]
        >  When the generated client data classes support data binding, navigation properties return instances of the <xref:System.Data.Services.Client.DataServiceCollection%601> class instead. For more information, see [Binding Data to Controls](../../../../docs/framework/data/wcf/binding-data-to-controls-wcf-data-services.md).  
  
4.  The <xref:System.Data.Services.Client.DataServiceContext.ReadingEntity> event is raised.  
  
5.  The client library attaches the object to the <xref:System.Data.Services.Client.DataServiceContext>. The object is not attached when the <xref:System.Data.Services.Client.MergeOption> is <xref:System.Data.Services.Client.MergeOption.NoTracking>.  
  
## See Also  
 [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md)  
 [Query Projections](../../../../docs/framework/data/wcf/query-projections-wcf-data-services.md)
