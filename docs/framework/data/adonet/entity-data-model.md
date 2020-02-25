---
title: "Entity Data Model"
ms.date: "03/30/2017"
ms.assetid: 2dda3d5b-4582-4ba0-a91d-fcd7a1498137
---
# Entity Data Model
The Entity Data Model (EDM) is a set of concepts that describe the structure of data, regardless of its stored form. The EDM borrows from the Entity-Relationship Model described by Peter Chen in 1976, but it also builds on the Entity-Relationship Model and extends its traditional uses.  
  
 The EDM addresses the challenges that arise from having data stored in many forms. For example, consider a business that stores data in relational databases, text files, XML files, spreadsheets, and reports. This presents significant challenges in data modeling, application design, and data access. When designing a data-oriented application, the challenge is to write efficient and maintainable code without sacrificing efficient data access, storage, and scalability. When data has a relational structure, data access, storage, and scalability are very efficient, but writing efficient and maintainable code becomes more difficult. When data has an object structure, the trade-offs are reversed: Writing efficient and maintainable code comes at the cost of efficient data access, storage, and scalability. Even if the right balance between these trade-offs can be found, new challenges arise when data is moved from one form to another. The Entity Data Model addresses these challenges by describing the structure of data in terms of entities and relationships that are independent of any storage schema. This makes the stored form of data irrelevant to application design and development. And, because entities and relationships describe the structure of data as it is used in an application (not its stored form), they can evolve as an application evolves.  
  
 A `conceptual model` is a specific representation of the structure of data as entities and relationships, and is generally defined in a domain-specific language (DSL) that implements the concepts of the EDM. [Conceptual schema definition language (CSDL)](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec) is an example of such a domain-specific language. Entities and relationships described in a conceptual model can be thought of as abstractions of objects and associations in an application. This allows developers to focus on the conceptual model without concern for the storage schema, and allows them to write code with efficiency and maintainability in mind. Meanwhile storage schema designers can focus on the efficiency of data access, storage, and scalability.  
  
## In This Section  
 Topics in this section describe the concepts of the Entity Data Model. Any DSL that implements the EDM should include the concepts described here. Note that the [ADO.NET Entity Framework](./ef/index.md) uses CSDL to define conceptual models. For more information, see [CSDL Specification](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec).  
  
 [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)  
  
 [Entity Data Model: Namespaces](entity-data-model-namespaces.md)  
  
 [Entity Data Model: Primitive Data Types](entity-data-model-primitive-data-types.md)  
  
 [Entity Data Model: Inheritance](entity-data-model-inheritance.md)  
  
 [association end](association-end.md)  
  
 [association end multiplicity](association-end-multiplicity.md)  
  
 [association set](association-set.md)  
  
 [association set end](association-set-end.md)  
  
 [association type](association-type.md)  
  
 [complex type](complex-type.md)  
  
 [entity container](entity-container.md)  
  
 [entity key](entity-key.md)  
  
 [entity set](entity-set.md)  
  
 [entity type](entity-type.md)  
  
 [facet](facet.md)  
  
 [foreign key property](foreign-key-property.md)  
  
 [model-declared function](model-declared-function.md)  
  
 [model-defined function](model-defined-function.md)  
  
 [navigation property](navigation-property.md)  
  
 [property](property.md)  
  
 [referential integrity constraint](referential-integrity-constraint.md)  
  
## See also

- [ADO.NET Entity Data Model Tools](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb399249(v=vs.100))
- [.edmx File Overview](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/cc982042(v=vs.100))
- [CSDL Specification](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)
