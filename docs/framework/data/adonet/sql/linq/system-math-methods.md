---
title: "System.Math Methods"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f299521-6f41-4720-bd70-67c93fc50948
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# System.Math Methods
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the following <xref:System.Math> methods.  
  
-   <xref:System.Math.DivRem%28System.Int32%2CSystem.Int32%2CSystem.Int32%40%29?displayProperty=nameWithType>  
  
-   <xref:System.Math.DivRem%28System.Int64%2CSystem.Int64%2CSystem.Int64%40%29?displayProperty=nameWithType>  
  
-   <xref:System.Math.IEEERemainder%28System.Double%2CSystem.Double%29?displayProperty=nameWithType>  
  
## Differences from .NET  
 The .NET Framework has different rounding semantics from SQL Server. The <xref:System.Math.Round%2A> method in the .NET Framework performs *Banker's rounding*, where numbers that ends in .5 round to the nearest even digit instead of to the next higher digit. For example, 2.5 rounds to 2, while 3.5 rounds to 4. (This technique helps avoid systematic bias toward higher values in large data transactions.)  
  
 In SQL, the `ROUND` function instead always rounds away from 0. Therefore 2.5 rounds to 3, contrasted with its rounding to 2 in the .NET Framework.  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] passes through to the SQL `ROUND` semantics and does not try to implement Banker's rounding.  
  
## See Also  
 [Data Types and Functions](../../../../../../docs/framework/data/adonet/sql/linq/data-types-and-functions.md)
