---
description: "Learn more about: Entity Data Model: Inheritance"
title: "Entity Data Model: Inheritance"
ms.date: "03/30/2017"
ms.assetid: 42c7ef24-710a-4af9-8493-cd41c399ecb0
---
# Entity Data Model: Inheritance

The Entity Data Model (EDM) supports inheritance for [entity types](entity-type.md). Inheritance in the EDM is similar to inheritance for classes in object-oriented programming languages. Like with classes in object-oriented languages, in a conceptual model you can define an entity type (a *derived type*) that inherits from another entity type (the *base type*). However, unlike classes in object-oriented programming, in a conceptual model the derived type always inherits all the [properties](property.md) and [navigation properties](navigation-property.md) of the base type. You cannot override inherited properties in a derived type.  
  
 In a conceptual model you can build inheritance hierarchies in which a derived type inherits from another derived type. The type at the top of the hierarchy (the one type in the hierarchy that is not a derived type) is called the *root type*. In an inheritance hierarchy, the [entity key](entity-key.md) must be defined on the root type.  
  
 You cannot build inheritance hierarchies in which a derived type inherits from more than one type. For example, in a conceptual model with a `Book` entity type, you could define derived types `FictionBook` and `NonFictionBook` that each inherit from `Book`. However, you could not then define a type that inherits from both the `FictionBook` and `NonFictionBook` types.  
  
## Example  

The following diagram shows a conceptual model with four entity types: `Book`, `FictionBook`, `Publisher`, and `Author`. The `FictionBook` entity type is a derived type, inheriting from the `Book` entity type. The `FictionBook` type inherits the `ISBN (Key)`, `Title`, and `Revision` properties, and defines an additional property called `Genre`.  
  
 ![Diagram that shows a conceptual model with four entity types.](./media/entity-data-model-inheritance/entity-type-inheritance.gif)  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL defines an entity type, `FictionBook`, that inherits from the `Book` type (as in the diagram above):  
  
 [!code-xml[EDM_Example_Model#DerivedType](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books5.edmx#derivedtype)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
