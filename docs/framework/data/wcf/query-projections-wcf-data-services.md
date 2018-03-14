---
title: "Query Projections (WCF Data Services)"
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
  - "projection [WCF Data Services]"
  - "WCF Data Services, projection"
  - "query projection [WCF Data Services]"
  - "WCF Data Services, querying"
ms.assetid: a09f4985-9f0d-48c8-b183-83d67a3dfe5f
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Query Projections (WCF Data Services)
Projection provides a mechanism in the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] to reduce the amount of data in the feed returned by a query by specifying that only certain properties of an entity are returned in the response. For more information, see [OData: Select System Query Option ($select)](http://go.microsoft.com/fwlink/?LinkId=186076).  
  
 This topic describes how to define a query projection, what the requirements are for entity and non-entity types, making updates to projected results, creating projected types, and lists some projection considerations.  
  
## Defining a Query Projection  
 You can add a projection clause to a query either by using the `$select` query option in a URI or by using the [select](~/docs/csharp/language-reference/keywords/select-clause.md) clause ([Select](~/docs/visual-basic/language-reference/queries/select-clause.md) in Visual Basic) in a LINQ query. Returned entity data can be projected into either entity types or non-entity types on the client. Examples in this topic demonstrate how to use the `select` clause in a LINQ query.  
  
> [!IMPORTANT]
>  Data loss might occur in the data service when you save updates that were made to projected types. For more information, see [Projection Considerations](#considerations).  
  
## Requirements for Entity and Non-Entity Types  
 Entity types must have one or more identity properties that make up the entity key. Entity types are defined on clients in one of the following ways:  
  
-   By applying the <xref:System.Data.Services.Common.DataServiceKeyAttribute> or <xref:System.Data.Services.Common.DataServiceEntityAttribute> to the type.  
  
-   When the type has a property named `ID`.  
  
-   When the type has a property named *type*`ID`, where *type* is the name of the type.  
  
 By default, when you project query results into a type defined at the client, the properties requested in the projection must exist in the client type. However, when you specify a value of `true` for the <xref:System.Data.Services.Client.DataServiceContext.IgnoreMissingProperties%2A> property of the <xref:System.Data.Services.Client.DataServiceContext>, properties specified in the projection are not required to occur in the client type.  
  
### Making Updates to Projected Results  
 When you project query results into entity types on the client, the <xref:System.Data.Services.Client.DataServiceContext> can track those objects with updates to be sent back to the data service when the <xref:System.Data.Services.Client.DataServiceContext.SaveChanges%2A> method is called. However, updates that are made to data projected into non-entity types on the client cannot be sent back to the data service. This is because without a key to identify the entity instance, the data service cannot update the correct entity in the data source. Non-entity types are not attached to the <xref:System.Data.Services.Client.DataServiceContext>.  
  
 When one or more properties of an entity type defined in the data service do not occur in the client type into which the entity is projected, inserts of new entities will not contain these missing properties. In this case, updates that are made to existing entities will **also** not include these missing properties. When a value exists for such a property, the update resets it to the default value for the property, as defined in the data source.  
  
### Creating Projected Types  
 The following example uses an anonymous LINQ query that projects the address-related properties of the `Customers` type into a new `CustomerAddress` type, which is defined on the client and is attributed as an entity type:  
  
 [!code-csharp[Astoria Northwind Client#SelectCustomerAddressSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#selectcustomeraddressspecific)]
 [!code-vb[Astoria Northwind Client#SelectCustomerAddressSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#selectcustomeraddressspecific)]  
  
 In this example, the object initializer pattern is used to create a new instance of the `CustmerAddress` type instead of calling a constructor. Constructors are not supported when projecting into entity types, but they can be used when projecting into non-entity and anonymous types. Because `CustomerAddress` is an entity type, changes can be made and sent back to the data service.  
  
 Also, the data from the `Customer` type is projected into an instance of the `CustomerAddress` entity type instead of an anonymous type. Projection into anonymous types is supported, but the data is read-only because anonymous types are treated as non-entity types.  
  
 The <xref:System.Data.Services.Client.MergeOption> settings of the <xref:System.Data.Services.Client.DataServiceContext> are used for identity resolution during query projection. This means that if an instance of the `Customer` type already exists in the <xref:System.Data.Services.Client.DataServiceContext>, an instance of `CustomerAddress` with the same identity will follow the identity resolution rules set by the <xref:System.Data.Services.Client.MergeOption>  
  
 The following table describes the behaviors when projecting results into entity and non-entity types:  
  
|Action|Entity Type|Non-Entity Type|  
|------------|-----------------|----------------------|  
|Creating a new projected instance by using initializers, as in the following example:<br /><br /> [!code-csharp[Astoria Northwind Client#ProjectWithInitializer](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#projectwithinitializer)]
 [!code-vb[Astoria Northwind Client#ProjectWithInitializer](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#projectwithinitializer)]|Supported|Supported|  
|Creating a new projected instance by using constructors, as in the following example:<br /><br /> [!code-csharp[Astoria Northwind Client#ProjectWithConstructor](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#projectwithconstructor)]
 [!code-vb[Astoria Northwind Client#ProjectWithConstructor](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#projectwithconstructor)]|A <xref:System.NotSupportedException> is raised.|Supported|  
|Using projection to transform a property value, as in the following example:<br /><br /> [!code-csharp[Astoria Northwind Client#ProjectWithTransform](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#projectwithtransform)]
 [!code-vb[Astoria Northwind Client#ProjectWithTransform](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#projectwithtransform)]<br /><br /> This transformation is not supported for entity types because it can lead to confusion and potentially overwriting the data in the data source that belongs to another entity.|A <xref:System.NotSupportedException> is raised.|Supported|  
  
<a name="considerations"></a>   
## Projection Considerations  
 The following additional considerations apply when defining a query projection.  
  
-   When you define custom feeds for the Atom format, you must make sure that all entity properties that have custom mappings defined are included in the projection. When a mapped entity property is not included in the projection, data loss might occur. For more information, see [Feed Customization](../../../../docs/framework/data/wcf/feed-customization-wcf-data-services.md).  
  
-   When inserts are made to a projected type that does not contain all of the properties of the entity in the data model of the data service, the properties not included in the projection at the client are set to their default values.  
  
-   When updates are made to a projected type that does not contain all of the properties of the entity in the data model of the data service, existing values not included in the projection on the client will be overwritten with uninitialized default values.  
  
-   When a projection includes a complex property, the entire complex object must be returned.  
  
-   When a projection includes a navigation property, the related objects are loaded implicitly without having to call the <xref:System.Data.Services.Client.DataServiceQuery%601.Expand%2A> method. The <xref:System.Data.Services.Client.DataServiceQuery%601.Expand%2A> method is not supported for use in a projected query.  
  
-   Query projections queries on the client are translated to use the `$select` query option in the request URI. When a query with projection is executed against a previous version of [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] that does not support the `$select` query option, an error is returned. This can also happen when the <xref:System.Data.Services.DataServiceBehavior.MaxProtocolVersion%2A> of the <xref:System.Data.Services.DataServiceBehavior> for the data service is set to a value of <xref:System.Data.Services.Common.DataServiceProtocolVersion.V1>. For more information, see [Data Service Versioning](../../../../docs/framework/data/wcf/data-service-versioning-wcf-data-services.md).  
  
 For more information, see [How to: Project Query Results](../../../../docs/framework/data/wcf/how-to-project-query-results-wcf-data-services.md).  
  
## See Also  
 [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md)
