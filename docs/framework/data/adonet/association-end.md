---
description: "Learn more about: association end"
title: "association end"
ms.date: "03/30/2017"
ms.assetid: 2c345213-0296-4d90-ac6d-cef179798a75
---
# association end

An *association end* identifies the [entity type](entity-type.md) on one end of an [association](association-type.md) and the number of entity type instances that can exist at that end of an association. Association ends are defined as part of an association; an association must have exactly two association ends. [Navigation properties](navigation-property.md) allow for navigation from one association end to the other.  
  
 An association end definition contains the following information:  
  
- One of the entity types involved in the association. (Required)  
  
    > [!NOTE]
    > For a given association, the entity type specified for each association end can be the same. This creates a self-association.  
  
- An [association end multiplicity](association-end-multiplicity.md) that indicates the number of entity type instances that can be at one end of the association. An association end multiplicity can have a value of one (1), zero or one (0..1), or many (\*).  
  
- A name for the association end. (Optional)  
  
- Information about operations that are performed on the association end, such as cascade on delete. (Optional)  
  
## Example  

 The diagram below shows a conceptual model with two associations: `PublishedBy` and `WrittenBy`. The association ends for the `PublishedBy` association are the `Book` and `Publisher` entity types. The multiplicity of the `Publisher` end is one (1) and the multiplicity of the `Book` end is many (\*), indicating that a publisher publishes many books and a book is published by one publisher.  
  
 ![Example model with three entity types](./media/association-end/example-model-three-entity-types.gif)  
  
 The ADO.NET Entity Framework uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The CSDL below defines the `PublishedBy` association shown in the diagram above. Note that the type, name, and multiplicity of each association end are specified by XML attributes (the `Type`, `Role`, and `Multiplicity` attributes, respectively). Optional information about operations performed on an end is specified in an XML element (the `OnDelete` element). In this case, if a publisher is deleted, so are all associated books.  
  
 [!code-xml[EDM_Example_Model#AssociationEnd](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books3.edmx#associationend)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
