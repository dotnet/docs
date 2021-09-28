---
description: "Learn more about: entity key"
title: "entity key"
ms.date: "03/30/2017"
ms.assetid: 0d447a6d-fa7a-4db0-8e7a-fd45e385fca0
---
# entity key

An *entity key* is a [property](property.md) or a set of properties of an [entity type](entity-type.md) that are used to determine identity. The properties that make up an entity key are chosen at design time. The values of entity key properties must uniquely identify an entity type instance within an [entity set](entity-set.md) at run time. The properties that make up an entity key should be chosen to guarantee uniqueness of instances in an entity set.  
  
 The following are the requirements for a set of properties to be an entity key:  
  
- No two entity keys within an entity set can be identical. That is, for any two entities within an entity set, the values for all of the properties that constitute a key cannot be the same. However, some (but not all) of the values that make up an entity key can be the same.  
  
- An entity key must consist of a set of non-nullable, immutable, [primitive type properties](entity-data-model-primitive-data-types.md).  
  
- The properties that make up an entity key for a given entity type cannot change. You cannot allow more than one possible entity key for a given entity type; surrogate keys are not supported.  
  
- When an entity is involved in an inheritance hierarchy, the root entity must contain all the properties that make up the entity key, and the entity key must be defined on the root entity type. For more information, see [Entity Data Model: Inheritance](entity-data-model-inheritance.md).  
  
## Example  

 The diagram below shows a conceptual model with three entity types: `Book`, `Publisher`, and `Author`. The properties of each entity type that make up its entity key are denoted with "(Key)". Note that the `Author` entity type has an entity key that consists of two properties, `Name` and `Address`.  
  
 ![Example model with three entity types](./media/entity-key/example-model-three-entity-types.gif)  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The CSDL below defines the `Book` entity type shown in the diagram above. Note that the entity key is defined by referencing the `ISBN` property of the entity type.  
  
 [!code-xml[EDM_Example_Model#EntityExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#entityexample)]  
  
 The `ISBN` property is a good choice for the entity key because an International Standard Book Number (ISBN) uniquely identifies a book.  
  
 The CSDL below defines the `Author` entity type shown in the diagram above. Note that the entity key consists of two properties, `Name` and `Address`.  
  
 [!code-xml[EDM_Example_Model#CompositeKeyExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#compositekeyexample)]  
  
 Using `Name` and `Address` for the entity key is a reasonable choice, because two authors of the same name are unlikely to live at the same address. However, this choice for an entity key does not absolutely guarantee unique entity keys in an entity set. Adding a property, such as `AuthorId`, that could be used to uniquely identify an author would be recommended in this case.  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
