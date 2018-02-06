---
title: "navigation property"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d0bf1a6a-1d84-484c-b7c3-b410fd8dc0b1
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# navigation property
A *navigation property* is an optional property on an [entity type](../../../../docs/framework/data/adonet/entity-type.md) that allows for navigation from one [end](../../../../docs/framework/data/adonet/association-end.md) of an [association](../../../../docs/framework/data/adonet/association-type.md) to the other end. Unlike other [properties](../../../../docs/framework/data/adonet/property.md), navigation properties do not carry data.  
  
 A navigation property definition includes the following:  
  
-   A name. (Required)  
  
-   The association that it navigates. (Required)  
  
-   The ends of the association that it navigates. (Required)  
  
 Note that navigation properties are optional on both entity types at the ends of an association. If you define a navigation property on one entity type at the end of an association, you do not have to define a navigation property on the entity type at the other end of the association.  
  
 The data type of a navigation property is determined by the [multiplicity](../../../../docs/framework/data/adonet/association-end-multiplicity.md) of its remote [association end](../../../../docs/framework/data/adonet/association-end.md). For example, suppose a navigation property, `OrdersNavProp`, exists on a `Customer` entity type and navigates a one-to-many association between `Customer` and `Order`. Because the remote association end for the navigation property has multiplicity of many (*), its data type is a collection (of `Order`). Similarly, if a navigation property, `CustomerNavProp`, exists on the `Order` entity type, its data type would be `Customer`, because the multiplicity of the remote end is one (1).  
  
## Example  
 The diagram below shows a conceptual model with three entity types: `Book`, `Publisher`, and `Author`. Navigation properties, `Publisher` and `Authors`, are defined on the Book entity type. Navigation property `Books` is defined on both the Publisher entity type and the `Author` entity type.  
  
 ![Model with Navigation Properties](../../../../docs/framework/data/adonet/media/modelwithnavprops.gif "ModelWithNavProps")  
  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines the `Book` entity type shown in the diagram above:  
  
 [!code-xml[EDM_Example_Model#EntityExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#entityexample)]  
  
 Note that XML attributes are used to communicate the information necessary to define a navigation property: The attribute `Name` contains the name of the property, `Relationship` contains the name of the association it navigates, and `FromRole` and `ToRole` contain the ends of the association.  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
