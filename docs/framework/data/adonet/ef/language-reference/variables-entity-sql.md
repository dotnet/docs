---
description: "Learn more about: Variables (Entity SQL)"
title: "Variables (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 3eed222a-f8f6-46b6-9cd5-220cc0e4e5d8
---
# Variables (Entity SQL)

## Variable

 A variable expression is a reference to a named expression defined in the current scope. A variable reference must be a valid Entity SQL identifier, as defined in [Identifiers](identifiers-entity-sql.md).

 The following example shows the use of a variable in the expression. The `c` in the FROM clause is the definition of the variable. The use of `c` in the SELECT clause represents the variable reference.

```sql
select c
from LOB.customers as c
```

## See also

- [Identifiers](identifiers-entity-sql.md)
- [Parameters](parameters-entity-sql.md)
- [Entity SQL Overview](entity-sql-overview.md)
