---
title: "Entity Data Model: Inheritance"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 42c7ef24-710a-4af9-8493-cd41c399ecb0
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Entity Data Model: Inheritance
The Entity Data Model (EDM) supports inheritance for [entity types](../../../../docs/framework/data/adonet/entity-type.md). Inheritance in the EDM is similar to inheritance for classes in object-oriented programming languages. Like with classes in object-oriented languages, in a conceptual model you can define an entity type (a *derived type*) that inherits from another entity type (the *base type*). However, unlike classes in object-oriented programming, in a conceptual model the derived type always inherits all the [properties](../../../../docs/framework/data/adonet/property.md) and [navigation properties](../../../../docs/framework/data/adonet/navigation-property.md) of the base type. You cannot override inherited properties in a derived type.  
  
 In a conceptual model you can build inheritance hierarchies in which a derived type inherits from another derived type. The type at the top of the hierarchy (the one type in the hierarchy that is not a derived type) is called the *root type*. In an inheritance hierarchy, the [entity key](../../../../docs/framework/data/adonet/entity-key.md) must be defined on the root type.  
  
 You cannot build inheritance hierarchies in which a derived type inherits from more than one type. For example, in a conceptual model with a `Book` entity type, you could define derived types `FictionBook` and `NonFictionBook` that each inherit from `Book`. However, you could not then define a type that inherits from both the `FictionBook` and `NonFictionBook` types.  
  
## Example  
 The diagram below shows a conceptual model with four entity types: `Book`, `FictionBook`, `Publisher`, and `Author`. The `FictionBook` entity type is a derived type, inheriting from the `Book` entity type. The `FictionBook` type inherits the `ISBN (Key)`, `Title`, and `Revision` properties, and defines an additional property called `Genre`.  
  
 ![Inheritance](../../../../docs/framework/data/adonet/media/inheritanceexample.gif "InheritanceExample")  
  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. The following CSDL defines an entity type, `FictionBook`, that inherits from the `Book` type (as in the diagram above):  
  
 [!code-xml[EDM_Example_Model#DerivedType](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books5.edmx#derivedtype)]  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
