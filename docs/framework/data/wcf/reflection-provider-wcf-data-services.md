---
title: "Reflection Provider (WCF Data Services)"
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
  - "WCF Data Services, providers"
ms.assetid: ef5ba300-6d7c-455e-a7bd-d0cc6d211ad4
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reflection Provider (WCF Data Services)
In addition to exposing data from a data model through the Entity Framework, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] can expose data that is not strictly defined in an entity-based model. The reflection provider exposes data in classes that return types that implement the <xref:System.Linq.IQueryable%601> interface. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] uses reflection to infer a data model for these classes and can translate address-based queries against resources into language integrated query (LINQ)-based queries against the exposed <xref:System.Linq.IQueryable%601> types.  
  
> [!NOTE]
>  You can use the <xref:System.Linq.Queryable.AsQueryable%2A> method to return an <xref:System.Linq.IQueryable%601> interface from any class that implements the <xref:System.Collections.Generic.IEnumerable%601> interface. This enables most generic collection types to be used as a data source for your data service.  
  
 The reflection provider supports type hierarchies. For more information, see [How to: Create a Data Service Using the Reflection Provider](../../../../docs/framework/data/wcf/create-a-data-service-using-rp-wcf-data-services.md).  
  
## Inferring the Data Model  
 When you create the data service, the provider infers the data model by using reflection. The following list shows how the reflection provider infers the data model:  
  
-   Entity container - the class that exposes the data as properties that return an <xref:System.Linq.IQueryable%601> instance. When you address a reflection-based data model, the entity container represents the root of the service. Only one entity container class is supported for a given namespace.  
  
-   Entity sets - properties that return <xref:System.Linq.IQueryable%601> instances are treated as entity sets. Entity sets are addressed directly as resources in the query. Only one property on the entity container can return an <xref:System.Linq.IQueryable%601> instance of a given type.  
  
-   Entity types - the type `T` of the <xref:System.Linq.IQueryable%601> that the entity set returns. Classes that are part of an inheritance hierarchy are translated by the reflection provider into an equivalent entity type hierarchy.  
  
-   Entity keys - each data class that is an entity type must have a key property. This property is attributed with the <xref:System.Data.Services.Common.DataServiceKeyAttribute> attribute (`[DataServiceKeyAttribute]`).  
  
    > [!NOTE]
    >  You should only apply the <xref:System.Data.Services.Common.DataServiceKeyAttribute> attribute to a property that can be used to uniquely identify an instance of the entity type. This attribute is ignored when applied to a navigation property.  
  
-   Entity type properties - other than the entity key, the reflection provider treats the accessible, non-indexer properties of a class that is an entity type as follows:  
  
    -   If the property returns a primitive type, then the property is assumed to be a property of an entity type.  
  
    -   If the property returns a type that is also an entity type, then the property is assumed to be a navigation property that represents the "one" end of a many-to-one or one-to-one relationship.  
  
    -   If the property returns an <xref:System.Collections.Generic.IEnumerable%601> of an entity type, then the property is assumed to be a navigation property that represents the "many" end of a one-to-many or many-to-many relationship.  
  
    -   If the return type of the property is a value type, then the property represents a complex type.  
  
> [!NOTE]
>  Unlike a data model that is based on the entity-relational model, models that are based on the reflection provider do not understand relational data. You should use the Entity Framework to expose relational data through [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)].  
  
## Data Type Mapping  
 When a data model is inferred from .NET Framework classes, the primitive types in the data model are mapped to .NET Framework data types as follows:  
  
|.NET Framework data type|Data model type|  
|------------------------------|---------------------|  
|<xref:System.Byte> `[]`|`Edm.Binary`|  
|<xref:System.Boolean>|`Edm.Boolean`|  
|<xref:System.Byte>|`Edm.Byte`|  
|<xref:System.DateTime>|`Edm.DateTime`|  
|<xref:System.Decimal>|`Edm.Decimal`|  
|<xref:System.Double>|`Edm.Double`|  
|<xref:System.Guid>|`Edm.Guid`|  
|<xref:System.Int16>|`Edm.Int16`|  
|<xref:System.Int32>|`Edm.Int32`|  
|<xref:System.Int64>|`Edm.Int64`|  
|<xref:System.SByte>|`Edm.SByte`|  
|<xref:System.Single>|`Edm.Single`|  
|<xref:System.String>|`Edm.String`|  
  
> [!NOTE]
>  .NET Framework nullable value types are mapped to the same data model types as the corresponding value types that cannot be assigned a null.  
  
## Enabling Updates in the Data Model  
 To allow updates to data that is exposed through this kind of data model, the reflection provider defines an <xref:System.Data.Services.IUpdatable> interface. This interface instructs the data service on how to persist updates to the exposed types. To enable updates to resources that are defined by the data model, the entity container class must implement the <xref:System.Data.Services.IUpdatable> interface. For an example of an implementation of the <xref:System.Data.Services.IUpdatable> interface, see [How to: Create a Data Service Using a LINQ to SQL Data Source](../../../../docs/framework/data/wcf/create-a-data-service-using-linq-to-sql-wcf.md).  
  
 The <xref:System.Data.Services.IUpdatable> interface requires that the following members be implemented so that updates can be propagated to the data source by using the reflection provider:  
  
|Member|Description|  
|------------|-----------------|  
|<xref:System.Data.Services.IUpdatable.AddReferenceToCollection%2A>|Provides the functionality to add an object to a collection of related objects that are accessed from a navigation property.|  
|<xref:System.Data.Services.IUpdatable.ClearChanges%2A>|Provides the functionality that cancels pending changes to the data.|  
|<xref:System.Data.Services.IUpdatable.CreateResource%2A>|Provides the functionality to create a new resource in the specified container.|  
|<xref:System.Data.Services.IUpdatable.DeleteResource%2A>|Provides the functionality to delete a resource.|  
|<xref:System.Data.Services.IUpdatable.GetResource%2A>|Provides the functionality to retrieve a resource that is identified by a specific query and type name.|  
|<xref:System.Data.Services.IUpdatable.GetValue%2A>|Provides the functionality to return the value of a property of a resource.|  
|<xref:System.Data.Services.IUpdatable.RemoveReferenceFromCollection%2A>|Provides the functionality to remove an object to a collection of related objects accessed from a navigation property.|  
|<xref:System.Data.Services.IUpdatable.ResetResource%2A>|Provides the functionality to update a specified resource.|  
|<xref:System.Data.Services.IUpdatable.ResolveResource%2A>|Provides the functionality to return the resource that is represented by a specific object instance.|  
|<xref:System.Data.Services.IUpdatable.SaveChanges%2A>|Provides the functionality to save all pending changes.|  
|<xref:System.Data.Services.IUpdatable.SetReference%2A>|Provides the functionality to set a related object reference by using a navigation property.|  
|<xref:System.Data.Services.IUpdatable.SetValue%2A>|Provides the functionality to set the value of the property of a resource.|  
  
## Handling Concurrency  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] supports an optimistic concurrency model by enabling you to define a concurrency token for an entity. This concurrency token, which includes one or more properties of the entity, is used by the data service to determine whether a change has occurred in the data that is being requested, updated, or deleted. When token values obtained from the eTag in the request differ from the current values of the entity, an exception is raised by the data service. The <xref:System.Data.Services.ETagAttribute> is applied to an entity type to define a concurrency token in the reflection provider. The concurrency token cannot include a key property or a navigation property. For more information, see [Updating the Data Service](../../../../docs/framework/data/wcf/updating-the-data-service-wcf-data-services.md).  
  
## Using LINQ to SQL with the Reflection Provider  
 Because the Entity Framework is natively supported by default, it is the recommended data provider for using relational data with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]. However, you can use the reflection provider to use LINQ to SQL classes with a data service. The <xref:System.Data.Linq.Table%601> result sets that are returned by methods on the <xref:System.Data.Linq.DataContext> generated by the LINQ to SQL Object Relational Designer (O/R Designer) implement the <xref:System.Linq.IQueryable%601> interface. This enables the reflection provider to access these methods and return entity data from SQL Server by using the generated LINQ to SQL classes. However, because LINQ to SQL does not implement the <xref:System.Data.Services.IUpdatable> interface, you need to add a partial class that extends the existing <xref:System.Data.Linq.DataContext> partial class to add the <xref:System.Data.Services.IUpdatable> implementation. For more information, see [How to: Create a Data Service Using a LINQ to SQL Data Source](../../../../docs/framework/data/wcf/create-a-data-service-using-linq-to-sql-wcf.md).  
  
## See Also  
 [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)
