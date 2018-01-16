---
title: "The Shape of the Command Trees"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2215585e-ca47-45f8-98d4-8cb982f8c1d3
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# The Shape of the Command Trees
The SQL generation module is responsible for generating a backend specific SQL query based on a given input query command tree expression. This section discusses the characteristics, properties, and structure of the query command trees.  
  
## Query Command Trees Overview  
 A query command tree is an object model representation of a query. Query command trees serve two purposes:  
  
-   To express an input query that is specified against the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)].  
  
-   To express an output query that is given to a provider and describes a query against the backend.  
  
 Query command trees support richer semantics than SQL:1999 compliant queries, including support for working with nested collections and type operations, like checking whether an entity is of a particular type, or filtering sets based on a type.  
  
 The DBQueryCommandTree.Query property is the root of the expression tree that describes the query logic. The DBQueryCommandTree.Parameters property contains a list of parameters that are used in the query. The expression tree is composed of DbExpression objects.  
  
 A DbExpression object represents some computation. Several kinds of expressions are provided by the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] for composing query expressions, including constants, variables, functions, constructors, and standard relational operators like filter and join. Every DbExpression object has a ResultType property that represents the type of the result produced by that expression. This type is expressed as a TypeUsage.  
  
## Shapes of the Output Query Command Tree  
 Output query command trees closely represent relational (SQL) queries and adhere to much stricter rules than those that apply to query command trees. They typically contain constructs that are easily translated to SQL.  
  
 Input command trees are expressed against the conceptual model, which supports navigation properties, associations among entities, and inheritance. Output command trees are expressed against the storage model. Input command trees allow you to project nested collections, but output command trees do not.  
  
 Output query command trees are built using a subset of the available DbExpression objects and even some expressions in that subset have restricted usage.  
  
 Type operations, like checking whether a given expression is of a particular type or filtering sets based on a type, are not present in output command trees.  
  
 In output command trees, only expressions that return Boolean values are used for projections and only for predicates in expressions requiring a predicate, like a filter or a case statement.  
  
 The root of an output query command trees is a DbProjectExpression object.  
  
### Expression Types Not Present in Output Query Command Trees  
 The following expression types are not valid in an output query command tree and do not need to be handled by providers:  
  
 DbDerefExpression  
  
 DbEntityRefExpression  
  
 DbRefKeyExpression  
  
 DbIsOfExpression  
  
 DbOfTypeExpression  
  
 DbRefExpression  
  
 DbRelationshipNavigationExpression  
  
 DbTreatExpression  
  
### Expression Restrictions and Notes  
 Many expressions can only be used in a restricted manner in output query command trees:  
  
#### DbFunctionExpression  
 The following function types can be passed:  
  
-   Canonical functions that are recognized by the Edm namespace.  
  
-   Built-in (store) functions that are recognized by the BuiltInAttribute.  
  
-   User-defined functions.  
  
 Canonical functions (see [Canonical Functions](../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md) for more information) are specified as part of the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)], and providers should supply implementations for canonical functions based on those specifications. Store functions are based on the specifications in the corresponding provider manifest. User defined functions are based on specifications in the SSDL.  
  
 Also, functions having the NiladicFunction attribute have no arguments and should be translated without the parenthesis at the end.  That is, to *\<functionName>* instead of *\<functionName>()*.  
  
#### DbNewInstanceExpression  
 DbNewInstanceExpression can only occur in the following two cases:  
  
-   As the Projection property of DbProjectExpression.  When used as such the following restrictions apply:  
  
    -   The result type must be a row type.  
  
    -   Each of its arguments is an expression that produces a result with a primitive type. Typically, each argument is a scalar expression, like a PropertyExpression over a DbVariableReferenceExpression, a function invocation, or an arithmetic computation of the DbPropertyExpression over a DbVariableReferenceExpression or a function invocation. However, an expression representing a scalar subquery can also occur in the list of arguments for a DbNewInstanceExpression. An expression that represents a scalar subquery is an expression tree that represents a subquery that returns exactly one row and one column of a primitive type with a DbElementExperession object root  
  
-   With a collection return type, in which case it defines a new collection of the expressions provided as arguments.  
  
#### DbVariableReferenceExpression  
 A DbVariableReferenceExpression has to be a child of DbPropertyExpression node.  
  
#### DbGroupByExpression  
 The Aggregates property of a DbGroupByExpression can only have elements of type DbFunctionAggregate. There are no other aggregate types.  
  
#### DbLimitExpression  
 The property Limit can only be a DbConstantExpression or a DbParameterReferenceExpression. Also property WithTies is always false as of version 3.5 of the .NET Framework.  
  
#### DbScanExpression  
 When used in output command trees, the DbScanExpression effectively represents a scan over a table, a view, or a store query, represented by EnitySetBase::Target.  
  
 If the metadata property "Defining Query" of the target is non-null, then it represents a query, the query text for which is provided in that metadata property in the provider’s specific language (or dialect) as specified in the store schema definition.  
  
 Otherwise, the target represents a table or a view. Its schema prefix is either in the "Schema" metadata property, if not null, otherwise is the entity container name.  The table or view name is either the "Table" metadata property, if not null, otherwise the Name property of the entity set base.  
  
 All these properties originate from the definition of the corresponding EntitySet in the store schema definition file (the SSDL).  
  
### Using Primitive Types  
 When primitive types are referenced in output command trees, they are typically referenced in the conceptual model's primitive types. However, for certain expressions, providers need the corresponding store primitive type. Examples of such expressions include DbCastExpression and possibly DbNullExpression, if the provider needs to cast the null to the corresponding type. In these cases, providers should do the mapping to the provider type based on the primitive type kind and its facets.  
  
## See Also  
 [SQL Generation](../../../../../docs/framework/data/adonet/ef/sql-generation.md)
