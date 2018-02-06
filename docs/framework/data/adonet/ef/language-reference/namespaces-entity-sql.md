---
title: "Namespaces (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 83991c21-60db-4af9-aca3-b416f6cae98e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Namespaces (Entity SQL)
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] introduces namespaces to avoid name conflicts for global identifiers such as type names, entity sets, functions, and so on. The namespace support in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is similar to the namespace support in the [!INCLUDE[dnprdnshort](../../../../../../includes/dnprdnshort-md.md)].  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides two forms of the USING clause: qualified namespaces (where a shorter alias is provided for the namespace), and unqualified namespaces, as illustrated in the following example:  
  
 `USING System.Data;`  
  
 `USING tsql = System.Data;`  
  
## Name Resolution Rules  
 If an identifier cannot be resolved in the local scopes, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] tries to locate the name in the global scopes (the namespaces). [!INCLUDE[esql](../../../../../../includes/esql-md.md)] first tries to match the identifier (prefix) with one of the qualified namespaces. If there is a match, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] tries to resolve the rest of the identifier in the specified namespace. If no match is found, an exception is thrown.  
  
 Next, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] tries to search all unqualified namespaces (specified in the prolog) for the identifier. If the identifier can be located in exactly one namespace, that location is returned. If more than one namespace has a match for that identifier, an exception is thrown. If no namespace can be identified for the identifier, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] passes the name onto the next outward scope (the <xref:System.Data.Common.DbCommand> or <xref:System.Data.Common.DbConnection> object), as illustrated in the following example:  
  
```  
SELECT TREAT(p AS NamespaceName.Employee)  
FROM ContainerName.Person AS p  
WHERE p IS OF (NamespaceName.Employee)  
```  
  
## Differences from the .NET Framework  
 In the [!INCLUDE[dnprdnshort](../../../../../../includes/dnprdnshort-md.md)], you can use partially qualified namespaces. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not allow this.  
  
## ADO.NET Usage  
 Queries are expressed through ADO.NET <xref:System.Data.Common.DbCommand> objects. <xref:System.Data.Common.DbCommand> objects can be built over <xref:System.Data.Common.DbConnection> objects. Namespaces can also be specified as part of the <xref:System.Data.Common.DbCommand> and <xref:System.Data.Common.DbConnection> objects. If [!INCLUDE[esql](../../../../../../includes/esql-md.md)] cannot resolve an identifier within the query itself, the external namespaces are probed (based on similar rules).  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
