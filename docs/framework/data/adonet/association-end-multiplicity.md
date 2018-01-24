---
title: "association end multiplicity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 340926ee-aefb-4bef-92cc-453e5251fd03
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# association end multiplicity
*Association end multiplicity* defines the number of [entity type](../../../../docs/framework/data/adonet/entity-type.md) instances that can be at one end of an [association](../../../../docs/framework/data/adonet/association-type.md).  
  
 An association end multiplicity can have one of the following values:  
  
-   one (1): Indicates that exactly one entity type instance exists at the association end.  
  
-   zero or one (0..1): Indicates that zero or one entity type instances exist at the association end.  
  
-   many (*): Indicates that zero, one, or more entity type instances exist at the association end.  
  
 An association is often characterized by its association end multiplicities. For example, if the ends of an association have multiplicities one (1) and many (*), the association is called a one-to-many association. In the example below, the `PublishedBy` association is a one-to-many association (a publisher publishes many books and a book is published by one publisher). The `WrittenBy` association is a many-to-many association (a book can have multiple authors and an author can write multiple books).  
  
## Example  
 The diagram below shows a conceptual model with two associations: `PublishedBy` and `WrittenBy`. The association ends for the `PublishedBy` association are the `Book` and `Publisher` entity types. The multiplicity of the `Publisher` end is one (1) and the multiplicity of the `Book` end is many (*).  
  
 ![Example Model](../../../../docs/framework/data/adonet/media/examplemodel.gif "ExampleModel")  
  
 The ADO.NET Entity Framework uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines the `PublishedBy` association shown in the diagram above:  
  
 [!code-xml[EDM_Example_Model#AssociationExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#associationexample)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
