---
title: "complex type"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 63efbd23-11d4-4871-bc88-ad01b9837553
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# complex type
A *complex type* is a template for defining rich, structured properties on [entity types](../../../../docs/framework/data/adonet/entity-type.md) or on other complex types. Each template contains the following:  
  
-   A unique name. (Required)  
  
    > [!NOTE]
    >  The name of a complex type cannot be the same as an entity type name within the same namespace.  
  
-   Data in the form of one or more [properties](../../../../docs/framework/data/adonet/property.md). (Optional.)  
  
    > [!NOTE]
    >  A property of a complex type can be another complex type.  
  
 A complex type is similar to an entity type in that a complex type can carry a data payload in the form of primitive type properties or other complex types. However, there are some key differences between complex types and entity types:  
  
-   Complex types do not have identities and therefore cannot exist independently. Complex types can only exist as properties on entity types or other complex types.  
  
-   Complex types cannot participate in [associations](../../../../docs/framework/data/adonet/association-type.md). Neither end of an association can be a complex type, and therefore [navigation properties](../../../../docs/framework/data/adonet/navigation-property.md) cannot be defined on complex types.  
  
## Example  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines a complex type, Address, with the primitive type properties `StreetAddress`, `City`, `StateOrProvince`, `Country`, and `PostalCode`.  
  
 [!code-xml[EDM_Example_Model#ComplexTypeExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books2.edmx#complextypeexample)]  
  
 To define the complex type `Address` (above) as a property on an entity type, you must declare the property type in the entity type definition. The following CSDL declares the `Address` property as a complex type on an entity type (Publisher):  
  
 [!code-xml[EDM_Example_Model#EntityWithComplexType](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books3.edmx#entitywithcomplextype)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
