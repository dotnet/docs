---
title: "Bitwise Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 993868ca-16e3-47b6-9915-c29cd63b0a21
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Bitwise Canonical Functions
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] includes bitwise canonical functions.  
  
## Remarks  
 The following table shows the bitwise [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions. These functions will return `Null` if `Null` input is provided. The return type of the functions is the same as the argument type(s). Arguments must be of the same type, if the function takes more than one argument. To perform bitwise operations across different types, you need to cast to the same type explicitly.  
  
|Function|Description|  
|--------------|-----------------|  
|`BitWiseAnd (` `value1` `,`  `value2` `)`|Returns the bitwise conjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32`, and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 1.`<br /><br /> `BitWiseAnd(1,3)`|  
|`BitWiseNot (` `value` `)`|Returns the bitwise negation of `value`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32`, and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns -4.`<br /><br /> `BitWiseNot(3)`|  
|`BitWiseOr (` `value1` `,`  `value2` `)`|Returns the bitwise disjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32` and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 3.`<br /><br /> `BitWiseOr(1,3)`|  
|`BitWiseXor (` `value1` `,`  `value2` `)`|Returns the bitwise exclusive disjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32` and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 2.`<br /><br /> `BitWiseXor (1,3)`|  
  
## See Also  
 [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
