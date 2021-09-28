---
description: "Learn more about: association type"
title: "association type"
ms.date: "03/30/2017"
ms.assetid: 26c409f6-06e8-4441-ac78-1b1076a3c005
---
# association type

An *association type* (also called an association) is the fundamental building block for describing relationships in the Entity Data Model (EDM). In a conceptual model, an association represents a relationship between two [entity types](entity-type.md) (such as `Customer` and `Order`). In an application, an instance of an association represents a specific association (such as an association between an instance of `Customer` and an instance of `Order`). Association instances are logically grouped in an [association set](association-set.md).  
  
 An association definition contains the following information:  
  
- A unique name. (Required)  
  
- Two [association ends](association-end.md), one for each entity type in the relationship. (Required)  
  
    > [!NOTE]
    > An association cannot represent a relationship among more than two entity types. An association can, however, define a self-relationship by specifying the same entity type for each of its association ends.  
  
- A [referential integrity constraint](referential-integrity-constraint.md). (Optional)  
  
 Each association end must specify an [association end multiplicity](association-end-multiplicity.md) that indicates the number of entity type instances that can be at one end of the association. An association end multiplicity can have a value of one (1), zero or one (0..1), or many (\*). Entity type instances at one end of an association can be accessed through [navigation properties](navigation-property.md) or foreign keys if they are exposed on an entity type. For more information, see [Entity Data Model: Foreign Keys](foreign-key-property.md).  
  
## Example  

 The diagram below shows a conceptual model with two associations: `PublishedBy` and `WrittenBy`. The association ends for the `PublishedBy` association are the `Book` and `Publisher` entity types. The multiplicity of the `Publisher` end is one (1) and the multiplicity of the `Book` end is many (\*), indicating that a publisher publishes many books and a book is published by one publisher.  
  
 ![Example model with three entity types](./media/association-type/example-model-three-entity-types.gif)  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL defines the `PublishedBy` association shown in the diagram above:  
  
 [!code-xml[EDM_Example_Model#AssociationExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#associationexample)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
