---
title: "Entity Data Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2dda3d5b-4582-4ba0-a91d-fcd7a1498137
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Entity Data Model
The Entity Data Model (EDM) is a set of concepts that describe the structure of data, regardless of its stored form. The EDM borrows from the Entity-Relationship Model described by Peter Chen in 1976, but it also builds on the Entity-Relationship Model and extends its traditional uses.  
  
 The EDM addresses the challenges that arise from having data stored in many forms. For example, consider a business that stores data in relational databases, text files, XML files, spreadsheets, and reports. This presents significant challenges in data modeling, application design, and data access. When designing a data-oriented application, the challenge is to write efficient and maintainable code without sacrificing efficient data access, storage, and scalability. When data has a relational structure, data access, storage, and scalability are very efficient, but writing efficient and maintainable code becomes more difficult. When data has an object structure, the trade-offs are reversed: Writing efficient and maintainable code comes at the cost of efficient data access, storage, and scalability. Even if the right balance between these trade-offs can be found, new challenges arise when data is moved from one form to another. The Entity Data Model addresses these challenges by describing the structure of data in terms of entities and relationships that are independent of any storage schema. This makes the stored form of data irrelevant to application design and development. And, because entities and relationships describe the structure of data as it is used in an application (not its stored form), they can evolve as an application evolves.  
  
 A `conceptual model` is a specific representation of the structure of data as entities and relationships, and is generally defined in a domain-specific language (DSL) that implements the concepts of the EDM. [Conceptual schema definition language (CSDL)](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md) is an example of such a domain-specific language. Entities and relationships described in a conceptual model can be thought of as abstractions of objects and associations in an application. This allows developers to focus on the conceptual model without concern for the storage schema, and allows them to write code with efficiency and maintainability in mind. Meanwhile storage schema designers can focus on the efficiency of data access, storage, and scalability.  
  
## In This Section  
 Topics in this section describe the concepts of the Entity Data Model. Any DSL that implements the EDM should include the concepts described here. Note that the [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses CSDL to define conceptual models. For more information, see [CSDL Specification](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md).  
  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
  
 [Entity Data Model: Namespaces](../../../../docs/framework/data/adonet/entity-data-model-namespaces.md)  
  
 [Entity Data Model: Primitive Data Types](../../../../docs/framework/data/adonet/entity-data-model-primitive-data-types.md)  
  
 [Entity Data Model: Inheritance](../../../../docs/framework/data/adonet/entity-data-model-inheritance.md)  
  
 [association end](../../../../docs/framework/data/adonet/association-end.md)  
  
 [association end multiplicity](../../../../docs/framework/data/adonet/association-end-multiplicity.md)  
  
 [association set](../../../../docs/framework/data/adonet/association-set.md)  
  
 [association set end](../../../../docs/framework/data/adonet/association-set-end.md)  
  
 [association type](../../../../docs/framework/data/adonet/association-type.md)  
  
 [complex type](../../../../docs/framework/data/adonet/complex-type.md)  
  
 [entity container](../../../../docs/framework/data/adonet/entity-container.md)  
  
 [entity key](../../../../docs/framework/data/adonet/entity-key.md)  
  
 [entity set](../../../../docs/framework/data/adonet/entity-set.md)  
  
 [entity type](../../../../docs/framework/data/adonet/entity-type.md)  
  
 [facet](../../../../docs/framework/data/adonet/facet.md)  
  
 [foreign key property](../../../../docs/framework/data/adonet/foreign-key-property.md)  
  
 [model-declared function](../../../../docs/framework/data/adonet/model-declared-function.md)  
  
 [model-defined function](../../../../docs/framework/data/adonet/model-defined-function.md)  
  
 [navigation property](../../../../docs/framework/data/adonet/navigation-property.md)  
  
 [property](../../../../docs/framework/data/adonet/property.md)  
  
 [referential integrity constraint](../../../../docs/framework/data/adonet/referential-integrity-constraint.md)  
  
## See Also  
 [ADO.NET Entity Data Model  Tools](http://msdn.microsoft.com/library/91076853-0881-421b-837a-f582f36be527)  
 [.edmx File Overview](http://msdn.microsoft.com/library/f4c8e7ce-1db6-417e-9759-15f8b55155d4)  
 [CSDL Specification](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)
