---
title: "referential integrity constraint"
description: Learn about referential integrity constraints in the Entity Data Model, which ensure that valid associations always exist between entity types.
ms.date: "03/30/2017"
ms.assetid: 3d3ba44b-4302-40d8-a7a9-62932e0395e5
---
# referential integrity constraint

A *referential integrity constraint* in the Entity Data Model (EDM) is similar to a referential integrity constraint in a relational database. In the same way that a column (or columns) from a database table can reference the primary key of another table, a [property](property.md) (or properties) of an [entity type](entity-type.md) can reference the [entity key](entity-key.md) of another entity type. The entity type that is referenced is called the *principal end* of the constraint. The entity type that references the principal end is called the *dependent end* of the constraint.  
  
 A referential integrity constraint is defined as part of an [association](association-type.md) between two entity types. The definition for a referential integrity constraint specifies the following information:  
  
- The principal end of the constraint. (An entity type whose entity key is referenced by the dependent end.)  
  
- The entity key of the principal end.  
  
- The dependent end of the constraint. (An entity type that has a property or properties that reference the entity key of the principal end.)  
  
- The referencing property or properties of the dependent end.  
  
 The purpose of referential integrity constraints in the EDM is to ensure that valid associations always exist. For more information, see [foreign key property](foreign-key-property.md).  
  
## Example  

 The diagram below shows a conceptual model with two associations: `WrittenBy` and `PublishedBy`. The `Book` entity type has a property, `PublisherId`, that references the entity key of the `Publisher` entity type when you define a referential integrity constraint on the `PublishedBy` association.  
  
 ![RefConstraintModel](./media/referential-integrity-constraint/reference-constraint-model.gif "Example of a referential constraint model")  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL defines a referential integrity constraint on the `PublishedBy` association shown in the conceptual model above.  
  
 [!code-xml[EDM_Example_Model#RefConstraint](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books4.edmx#refconstraint)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
