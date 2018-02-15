---
title: "Comparison Semantics (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b36ce28a-2fe4-4236-b782-e5f7c054deae
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Comparison Semantics (Entity SQL)
Performing any of the following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] operators involves comparison of type instances:  
  
## Explicit comparison  
 Equality operations:  
  
-   =  
  
-   !=  
  
 Ordering operations:  
  
-   <  
  
-   \<=  
  
-   \>  
  
-   \>=  
  
 Nullability operations:  
  
-   IS NULL  
  
-   IS NOT NULL  
  
## Explicit distinction  
 Equality distinction:  
  
-   DISTINCT  
  
-   GROUP BY  
  
 Ordering distinction:  
  
-   ORDER BY  
  
## Implicit distinction  
 Set operations and predicates (equality):  
  
-   UNION  
  
-   INTERSECT  
  
-   EXCEPT  
  
-   SET  
  
-   OVERLAPS  
  
 Item predicates (equality):  
  
-   IN  
  
## Supported Combinations  
 The following table shows all the supported combinations of comparison operators for each kind of type:  
  
|**Type**|**=**<br /><br /> **!=**|**GROUP BY**<br /><br /> **DISTINCT**|**UNION**<br /><br /> **INTERSECT**<br /><br /> **EXCEPT**<br /><br /> **SET**<br /><br /> **OVERLAPS**|**IN**|**<   <=**<br /><br /> **>   >=**|**ORDER BY**|**IS NULL**<br /><br /> **IS NOT NULL**|  
|-|-|-|-|-|-|-|-|  
|Entity type|Ref<sup>1</sup>|All properties<sup>2</sup>|All properties<sup>2</sup>|All properties<sup>2</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Ref<sup>1</sup>|  
|Complex type|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|  
|Row|All properties<sup>4</sup>|All properties<sup>4</sup>|All properties<sup>4</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|All properties<sup>4</sup>|Throw<sup>3</sup>|  
|Primitive type|Provider-specific|Provider-specific|Provider-specific|Provider-specific|Provider-specific|Provider-specific|Provider-specific|  
|Multiset|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|  
|Ref|Yes<sup>5</sup>|Yes<sup>5</sup>|Yes<sup>5</sup>|Yes<sup>5</sup>|Throw|Throw|Yes<sup>5</sup>|  
|Association<br /><br /> type|Throw<sup>3</sup>|Throw|Throw|Throw|Throw<sup>3</sup>|Throw<sup>3</sup>|Throw<sup>3</sup>|  
  
 <sup>1</sup>The references of the given entity type instances are implicitly compared, as shown in the following example:  
  
```  
SELECT p1, p2   
FROM AdventureWorksEntities.Product AS p1   
     JOIN AdventureWorksEntities.Product AS p2   
WHERE p1 != p2 OR p1 IS NULL  
```  
  
 An entity instance cannot be compared to an explicit reference. If this is attempted, an exception is thrown. For example, the following query will throw an exception:  
  
```  
SELECT p1, p2   
FROM AdventureWorksEntities.Product AS p1   
     JOIN AdventureWorksEntities.Product AS p2   
WHERE p1 != REF(p2)  
```  
  
 <sup>2</sup>Properties of complex types are flattened out before being sent to the store, so they become comparable (as long as all their properties are comparable). Also see <sup>4.</sup>  
  
 <sup>3</sup>The Entity Framework runtime detects the unsupported case and throws a meaningful exception without engaging the provider/store.  
  
 <sup>4</sup>An attempt is made to compare all properties. If there is a property that is of a non-comparable type, such as text, ntext, or image, a server exception might be thrown.  
  
 <sup>5</sup>All individual elements of the references are compared (this includes the entity set name and all the key properties of the entity type).  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
