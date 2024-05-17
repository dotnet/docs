---
description: "Learn more about: Type Definitions (Entity SQL)"
title: "Type Definitions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 306b204a-ade5-47ef-95b5-c785d2da4a7e
---
# Type Definitions (Entity SQL)

A type definition is used in the declaration statement of an Entity SQL Inline function.

## Remarks

 The declaration statement for an inline function consists of the [FUNCTION](function-entity-sql.md) keyword followed by the identifier representing the function name (for example, "MyAvg") followed by a parameter definition list in parenthesis (for example, "dues Collection(Decimal)").

 The parameter definition list consists of zero or more parameter definitions. Each parameter definition consists of an identifier (the name of the parameter to the function, for example, "dues") followed by a type definition (for example, "Collection(Decimal)").

 The type definitions can be either:

- The type of the identifier (for example, "Int32" or "AdventureWorks.Order").

- The keyword `COLLECTION` followed by another type definition in parenthesis (for example, "Collection(AdventureWorks.Order)").

- The keyword ROW followed by a list of property definitions in parenthesis (for example, "Row(x AdventureWorks.Order)"). Property definitions have a format such as "`identifier type_definition`, `identifier type_definition`, ...".

- The keyword REF followed by the type of the identifier in parenthesis (for example, "Ref(AdventureWorks.Order)"). The REF type definition operator requires an entity type as the argument. You cannot specify a primitive type as the argument.

 You can also nest type definitions (for example, "Collection(Row(x Ref(AdventureWorks.Order)))").

 The type definition options are:

- `IdentifierName supported_type`, or

- `IdentifierName` COLLECTION(`type_definition`), or

- `IdentifierName` ROW(`property_definition`), or

- `IdentifierName` REF(`supported_entity_type`)

 The property definition option is `IdentifierName type_definition`.

 Supported types are any types in the current namespace. These include both primitive and entity types.

 Supported entity types refer to only entity types in the current namespace. They do not include primitive types.

## Examples

 The following is an example of a simple type definition.

```sql
USING Microsoft.Samples.Entity
Function MyRound(p1 EDM.Decimal) AS (
   Round(p1)
)
MyRound(CAST(1.7 as EDM.Decimal))
```

 The following is an example of a COLLECTION type definition.

```sql
USING Microsoft.Samples.Entity
Function MyRound(p1 Collection(EDM.Decimal)) AS (
   Select Round(p1) from p1
)
MyRound({CAST(1.7 as EDM.Decimal), CAST(2.7 as EDM.Decimal)})
```

 The following is an example of a ROW type definition.

```sql
USING Microsoft.Samples.Entity
Function MyRound(p1 Row(x EDM.Decimal)) AS (
   Round(p1.x)
)
select MyRound(row(a as x)) from {CAST(1.7 as EDM.Decimal), CAST(2.7 as EDM.Decimal)} as a
```

 The following is an example of a REF type definition.

```sql
USING Microsoft.Samples.Entity
Function UnReference(p1 Ref(AdventureWorks.Order)) AS (
   Deref(p1)
)
select Ref(x) from AdventureWorksEntities.SalesOrderHeaders as x
```

## See also

- [Entity SQL Overview](entity-sql-overview.md)
- [Entity SQL Reference](entity-sql-reference.md)
