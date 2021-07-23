---
description: "Learn more about: Namespaces (Entity SQL)"
title: "Namespaces (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 83991c21-60db-4af9-aca3-b416f6cae98e
---
# Namespaces (Entity SQL)

Entity SQL introduces namespaces to avoid name conflicts for global identifiers such as type names, entity sets, functions, and so on. The namespace support in Entity SQL is similar to the namespace support in the .NET Framework.

 Entity SQL provides two forms of the USING clause: qualified namespaces (where a shorter alias is provided for the namespace), and unqualified namespaces, as illustrated in the following example:

 `USING System.Data;`

 `USING tsql = System.Data;`

## Name Resolution Rules

 If an identifier cannot be resolved in the local scopes, Entity SQL tries to locate the name in the global scopes (the namespaces). Entity SQL first tries to match the identifier (prefix) with one of the qualified namespaces. If there is a match, Entity SQL tries to resolve the rest of the identifier in the specified namespace. If no match is found, an exception is thrown.

 Next, Entity SQL tries to search all unqualified namespaces (specified in the prolog) for the identifier. If the identifier can be located in exactly one namespace, that location is returned. If more than one namespace has a match for that identifier, an exception is thrown. If no namespace can be identified for the identifier, Entity SQL passes the name onto the next outward scope (the <xref:System.Data.Common.DbCommand> or <xref:System.Data.Common.DbConnection> object), as illustrated in the following example:

```sql
SELECT TREAT(p AS NamespaceName.Employee)
FROM ContainerName.Person AS p
WHERE p IS OF (NamespaceName.Employee)
```

## Differences from the .NET Framework

 In the .NET Framework, you can use partially qualified namespaces. Entity SQL does not allow this.

## ADO.NET Usage

 Queries are expressed through ADO.NET <xref:System.Data.Common.DbCommand> objects. <xref:System.Data.Common.DbCommand> objects can be built over <xref:System.Data.Common.DbConnection> objects. Namespaces can also be specified as part of the <xref:System.Data.Common.DbCommand> and <xref:System.Data.Common.DbConnection> objects. If Entity SQL cannot resolve an identifier within the query itself, the external namespaces are probed (based on similar rules).

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Overview](entity-sql-overview.md)
