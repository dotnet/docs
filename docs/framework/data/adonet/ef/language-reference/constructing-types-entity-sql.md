---
title: "Constructing Types (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 41fa7bde-8d20-4a3f-a3d2-fb791e128010
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Constructing Types (Entity SQL)
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides three kinds of constructors: row constructors, named type constructors, and collection constructors.  
  
## Row Constructors  
 You use row constructors in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] to construct anonymous, structurally typed records from one or more values. The result type of a row constructor is a row type whose field types correspond to the types of the values used to construct the row. For example, the following expression constructs a value of type `Record(a int, b string, c int)`:  
  
 `ROW(1 AS a, "abc" AS b, a + 34 AS c)`  
  
 If you do not provide an alias for an expression in a row constructor, the Entity Framework will try to generate one. For more information, see the "Aliasing Rules" section in [Identifiers](../../../../../../docs/framework/data/adonet/ef/language-reference/identifiers-entity-sql.md).  
  
 The following rules apply to expression aliasing in a row constructor:  
  
-   Expressions in a row constructor cannot refer to other aliases in the same constructor.  
  
-   Two expressions in the same row constructor cannot have the same alias.  
  
 For more information about row constructors, see [ROW](../../../../../../docs/framework/data/adonet/ef/language-reference/row-entity-sql.md).  
  
## Collection Constructors  
 You use collection constructors in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] to create an instance of a multiset from a list of values. All the values in the constructor must be of mutually compatible type `T`, and the constructor produces a collection of type `Multiset<T>`. For example, the following expression creates a collection of integers:  
  
 `Multiset(1, 2, 3)`  
  
 `{1, 2, 3}`  
  
 Empty multiset constructors are not allowed because the type of the elements cannot be determined. The following is not valid:  
  
 `multiset() {}`  
  
 For more information, see [MULTISET](../../../../../../docs/framework/data/adonet/ef/language-reference/multiset-entity-sql.md).  
  
## Named Type Constructors (NamedType Initializers)  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] allows type constructors (initializers) to create instances of named complex types and entity types. For example, the following expression creates an instance of a `Person` type.  
  
 `Person("abc", 12)`  
  
 The following expression creates an instance of a complex type.  
  
 `MyModel.ZipCode(‘98118’, ‘4567’)`  
  
 The following expression creates an instance of a nested complex type.  
  
 `MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567'))`  
  
 The following expression creates an instance of an entity with a nested complex type.  
  
 `MyModel.Person("Bill", MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567')))`  
  
 The following example shows how to initialize a property of a complex type to null. `MyModel.ZipCode(‘98118’, null)`  
  
 The arguments to the constructor are assumed to be in the same order as the declaration of the attributes of the type.  
  
 For more information, see [Named Type Constructor](../../../../../../docs/framework/data/adonet/ef/language-reference/named-type-constructor-entity-sql.md).  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
 [Type System](../../../../../../docs/framework/data/adonet/ef/language-reference/type-system-entity-sql.md)
