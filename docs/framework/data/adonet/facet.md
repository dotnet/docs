---
title: "facet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 91c4e6aa-3e54-4b6c-a38a-abf27808cc85
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# facet
A *facet* is used to add detail to a primitive type property definition. A [property](../../../../docs/framework/data/adonet/property.md) definition contains information about the property type, but often more detail is necessary. For example, an entity type in a conceptual model might have a property of type `String` whose value cannot be set to null. Facets allow you to specify this level of detail.  
  
 The table below describes the facets that are supported in the EDM.  
  
> [!NOTE]
>  The exact values and behaviors of facets are determined by the run-time environment that uses an EDM implementation.  
  
|Facet|Description|Applies to|  
|-----------|-----------------|----------------|  
|`Collation`|Specifies the collating sequence (or sorting sequence) to be used when performing comparison and ordering operations on values of the property.|`String`|  
|`ConcurrencyMode`|Indicates that the value of the property should be used for optimistic concurrency checks.|All primitive type properties|  
|`Default`|Specifies the default value of the property if no value is supplied upon instantiation.|All primitive type properties|  
|`FixedLength`|Specifies whether the length of the property value can vary.|`Binary`, `String`|  
|`MaxLength`|Specifies the maximum length of the property value.|`Binary`, `String`|  
|`Nullable`|Specifies whether the property can have a null value.|All primitive type properties|  
|`Precision`|For properties of type `Decimal`, specifies the number of digits a property value can have. For properties of type `Time`, `DateTime`, and `DateTimeOffset`, specifies the number of digits for the fractional part of seconds of the property value.|`DateTime`, `DateTimeOffset`, `Decimal`, `Time`,|  
|`Scale`|Specifies the number of digits to the right of the decimal point for the property value.|Decimal|  
|`Unicode`|Indicates whether the property value is stored as Unicode.|`String`|  
  
## Example  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines a `Book` entity type. Note that facets are implemented as XML attributes. The facet values indicate that no property can be set to null, and that the `Scale` and `Precision` of the `Revision` property are each set to 29.  
  
 [!code-xml[EDM_Example_Model#EntityExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#entityexample)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
