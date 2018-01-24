---
title: "Type Definitions (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 306b204a-ade5-47ef-95b5-c785d2da4a7e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Type Definitions (Entity SQL)
A type definition is used in the declaration statement of an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] Inline function.  
  
## Remarks  
 The declaration statement for an inline function consists of the [FUNCTION](../../../../../../docs/framework/data/adonet/ef/language-reference/function-entity-sql.md) keyword followed by the identifier representing the function name (for example, "MyAvg") followed by a parameter definition list in parenthesis (for example, "dues Collection(Decimal)").  
  
 The parameter definition list consists of zero or more parameter definitions. Each parameter definition consists of an identifier (the name of the parameter to the function, for example, "dues") followed by a type definition (for example, "Collection(Decimal)").  
  
 The type definitions can be either:  
  
-   The type of the identifier (for example, "Int32" or "AdventureWorks.Order").  
  
-   The keyword `COLLECTION` followed by another type definition in parenthesis (for example, "Collection(AdventureWorks.Order)").  
  
-   The keyword ROW followed by a list of property definitions in parenthesis (for example, "Row(x AdventureWorks.Order)"). Property definitions have a format such as "`identifier type_definition`, `identifier type_definition`, ...".  
  
-   The keyword REF followed by the type of the identifier in parenthesis (for example, "Ref(AdventureWorks.Order)"). The REF type definition operator requires an entity type as the argument. You cannot specify a primitive type as the argument.  
  
 You can also nest type definitions (for example, "Collection(Row(x Ref(AdventureWorks.Order)))").  
  
 The type definition options are:  
  
-   `IdentifierName supported_type`, or  
  
-   `IdentifierName` COLLECTION(`type_definition`), or  
  
-   `IdentifierName` ROW(`property_definition`), or  
  
-   `IdentifierName` REF(`supported_entity_type`)  
  
 The property definition option is `IdentifierName type_definition`.  
  
 Supported types are any types in the current namespace. These include both primitive and entity types.  
  
 Supported entity types refer to only entity types in the current namespace. They do not include primitive types.  
  
## Examples  
 The following is an example of a simple type definition.  
  
```  
USING Microsoft.Samples.Entity  
Function MyRound(p1 EDM.Decimal) AS (  
   Round(p1)  
)  
MyRound(CAST(1.7 as EDM.Decimal))  
```  
  
 The following is an example of a COLLECTION type definition.  
  
```  
USING Microsoft.Samples.Entity  
Function MyRound(p1 Collection(EDM.Decimal)) AS (  
   Select Round(p1) from p1  
)  
MyRound({CAST(1.7 as EDM.Decimal), CAST(2.7 as EDM.Decimal)})  
```  
  
 The following is an example of a ROW type definition.  
  
```  
USING Microsoft.Samples.Entity  
Function MyRound(p1 Row(x EDM.Decimal)) AS (  
   Round(p1.x)  
)  
select MyRound(row(a as x)) from {CAST(1.7 as EDM.Decimal), CAST(2.7 as EDM.Decimal)} as a  
```  
  
 The following is an example of a REF type definition.  
  
```  
USING Microsoft.Samples.Entity  
Function UnReference(p1 Ref(AdventureWorks.Order)) AS (  
   Deref(p1)  
)  
select Ref(x) from AdventureWorksEntities.SalesOrderHeaders as x  
```  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
