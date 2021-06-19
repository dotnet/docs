---
description: "Learn more about: How to: Create a Data Service Using the Reflection Provider (WCF Data Services)"
title: "How to: Create a Data Service Using the Reflection Provider (WCF Data Services)"
ms.date: "03/30/2017"
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "WCF Data Services, providers"
ms.assetid: 7315c6d8-f452-4fb2-a0c1-76ab0593c146
---
# How to: Create a Data Service Using the Reflection Provider (WCF Data Services)

[!INCLUDE [wcf-deprecated](~/includes/wcf-deprecated.md)]

WCF Data Services enables you to define a data model that is based on arbitrary classes as long as those classes are exposed as objects that implement the <xref:System.Linq.IQueryable%601> interface. For more information, see [Data Services Providers](data-services-providers-wcf-data-services.md).

## Example

 The following example defines a data model that includes `Orders` and `Items`. The entity container class `OrderItemData` has two public methods that return <xref:System.Linq.IQueryable%601> interfaces. These interfaces are the entity sets of the `Orders` and `Items` entity types. An `Order` can include multiple `Items`, so the `Orders` entity type has an `Items` navigation property that returns a collection of `Items` objects. The `OrderItemData` entity container class is the generic type of the <xref:System.Data.Services.DataService%601> class from which the `OrderItems` data service is derived.

> [!NOTE]
> Because this example demonstrates an in-memory data provider and changes are not persisted outside of the current object instances, there is no benefit derived from implementing the <xref:System.Data.Services.IUpdatable> interface. For an example that implements the <xref:System.Data.Services.IUpdatable> interface, see [How to: Create a Data Service Using a LINQ to SQL Data Source](create-a-data-service-using-linq-to-sql-wcf.md).

 [!code-csharp[Astoria Reflection Provider#CustomIQueryable](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria_reflection_provider/cs/orderitems.svc.cs#customiqueryable)]
 [!code-vb[Astoria Reflection Provider#CustomIQueryable](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria_reflection_provider/vb/orderitems.svc.vb#customiqueryable)]

## See also

- [How to: Create a Data Service Using a LINQ to SQL Data Source](create-a-data-service-using-linq-to-sql-wcf.md)
- [Data Services Providers](data-services-providers-wcf-data-services.md)
- [How to: Create a Data Service Using an ADO.NET Entity Framework Data Source](create-a-data-service-using-an-adonet-ef-data-wcf.md)
