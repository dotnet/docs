---
title: "association set"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a65247b6-ce59-44ea-974c-14ae20a7995f
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# association set
An *association set* is a logical container for [association](../../../../docs/framework/data/adonet/association-type.md) instances of the same type. An association set is not a data modeling construct; that is, it does not describe the structure of data or relationships. Instead, an association set provides a construct for a hosting or storage environment (such as the common language runtime or a SQL Server database) to group association instances so that they can be mapped to a data store.  
  
 An association set is defined within an [entity container](../../../../docs/framework/data/adonet/entity-container.md), which is a logical grouping of [entity sets](../../../../docs/framework/data/adonet/entity-set.md) and association sets.  
  
 A definition for an association set contains the following information:  
  
-   The association set name. (Required)  
  
-   The association of which it will contain instances. (Required)  
  
-   Two [association set ends](../../../../docs/framework/data/adonet/association-set-end.md).  
  
## Example  
 The diagram below shows a conceptual model with two associations: `PublishedBy`, and `WrittenBy`. Although information about association sets is not conveyed in the diagram, the next diagram shows an example of association sets and entity sets based on this model.  
  
 ![Example Model](../../../../docs/framework/data/adonet/media/examplemodel.gif "ExampleModel")  
  
 The following example shows an association set (`PublishedBy`) and two entity sets (`Books` and `Publishers`) based on the conceptual model shown above. Bi in the `Books` entity set represents an instance of the `Book` entity type at run time. Similarly, Pj represents a `Publisher` instance in the `Publishers` entity set. BiPj represents an instance of the `PublishedBy` association in the `PublishedBy` association set.  
  
 ![Sets Example](../../../../docs/framework/data/adonet/media/setsexample.gif "SetsExample")  
  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines an entity container with one association set for each association in the diagram above. Note that the name and association for each association set are defined using XML attributes.  
  
 [!code-xml[EDM_Example_Model#EntityContainerExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#entitycontainerexample)]  
  
 It is possible to define multiple association sets per association, as long as no two association sets share an [association set end](../../../../docs/framework/data/adonet/association-set-end.md). The following CSDL defines an entity container with two association sets for the `WrittenBy` association. Notice that multiple entity sets have been defined for the `Book` and `Author` entity types and that no association set shares an association set end.  
  
 [!code-xml[EDM_Example_Model#MultipleAssociationSets](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books3.edmx#multipleassociationsets)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)  
 [foreign key property](../../../../docs/framework/data/adonet/foreign-key-property.md)
