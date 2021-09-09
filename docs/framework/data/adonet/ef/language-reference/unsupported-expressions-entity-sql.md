---
description: "Learn more about: Unsupported expressions"
title: "Unsupported Expressions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 5e79da7e-e78a-413c-8fb0-f3f9cd84f579
dev_langs:
  - "sql"
---
# Unsupported expressions

This topic describes Transact-SQL expressions that are not supported in Entity SQL. For more information, see [How Entity SQL Differs from Transact-SQL](how-entity-sql-differs-from-transact-sql.md).

## Quantified predicates

Transact-SQL allows constructs of the following form:

```sql
sal > all (select salary from employees)
sal > any (select salary from employees)
```

Entity SQL, however, does not support such constructs. Equivalent expressions can be written in Entity SQL as follows:

```sql
not exists(select 0 from employees as e where sal <= e.salary)
exists(select 0 from employees as e where sal > e.salary)
```

## * operator

Transact-SQL supports the use of the * operator in the SELECT clause to indicate that all columns should be projected out. This is not supported in Entity SQL.

## See also

- [Entity SQL Overview](entity-sql-overview.md)
- [How Entity SQL Differs from Transact-SQL](how-entity-sql-differs-from-transact-sql.md)
