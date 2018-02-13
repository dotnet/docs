---
title: "association type"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 26c409f6-06e8-4441-ac78-1b1076a3c005
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# association type
An *association type* (also called an association) is the fundamental building block for describing relationships in the Entity Data Model (EDM). In a conceptual model, an association represents a relationship between two [entity types](../../../../docs/framework/data/adonet/entity-type.md) (such as `Customer` and `Order`). In an application, an instance of an association represents a specific association (such as an association between an instance of `Customer` and an instance of `Order`). Association instances are logically grouped in an [association set](../../../../docs/framework/data/adonet/association-set.md).  
  
 An association definition contains the following information:  
  
-   A unique name. (Required)  
  
-   Two [association ends](../../../../docs/framework/data/adonet/association-end.md), one for each entity type in the relationship. (Required)  
  
    > [!NOTE]
    >  An association cannot represent a relationship among more than two entity types. An association can, however, define a self-relationship by specifying the same entity type for each of its association ends.  
  
-   A [referential integrity constraint](../../../../docs/framework/data/adonet/referential-integrity-constraint.md). (Optional)  
  
 Each association end must specify an [association end multiplicity](../../../../docs/framework/data/adonet/association-end-multiplicity.md) that indicates the number of entity type instances that can be at one end of the association. An association end multiplicity can have a value of one (1), zero or one (0..1), or many (*). Entity type instances at one end of an association can be accessed through [navigation properties](../../../../docs/framework/data/adonet/navigation-property.md) or foreign keys if they are exposed on an entity type. For more information, see [Entity Data Model: Foreign Keys](../../../../docs/framework/data/adonet/foreign-key-property.md).  
  
## Example  
 The diagram below shows a conceptual model with two associations: `PublishedBy` and `WrittenBy`. The association ends for the `PublishedBy` association are the `Book` and `Publisher` entity types. The multiplicity of the `Publisher` end is one (1) and the multiplicity of the `Book` end is many (*), indicating that a publisher publishes many books and a book is published by one publisher.  
  
 ![Example Model](../../../../docs/framework/data/adonet/media/examplemodel.gif "ExampleModel")  
  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines the `PublishedBy` association shown in the diagram above:  
  
 [!code-xml[EDM_Example_Model#AssociationExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#associationexample)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
