---
title: "System.Object Methods | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5397fca0-689e-443e-802f-e1cbdc866427
caps.latest.revision: 2
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# System.Object Methods
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports the following <xref:System.Object> methods.  
  
|||  
|-|-|  
|<xref:System.Object.Equals%28System.Object%29?displayProperty=fullName>|<xref:System.Object.Equals%28System.Object%2CSystem.Object%29?displayProperty=fullName>|  
|<xref:System.Object.ToString?displayProperty=fullName>||  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the following <xref:System.Object> methods.  
  
|||  
|-|-|  
|<xref:System.Object.GetHashCode?displayProperty=fullName>|<xref:System.Object.ReferenceEquals%28System.Object%2CSystem.Object%29?displayProperty=fullName>|  
|<xref:System.Object.MemberwiseClone?displayProperty=fullName>|<xref:System.Object.GetType?displayProperty=fullName>|  
|<xref:System.Object.ToString?displayProperty=fullName> for binary types such as `BINARY`, `VARBINARY`, `IMAGE`, and `TIMESTAMP`.||  
  
## Differences from .NET  
 The output of <xref:System.Object.ToString?displayProperty=fullName> for double uses SQL `CONVERT`(NVARCHAR(30), @x, 2) on SQL. SQL always uses 16 digits and scientific notation in this case (for example, "0.000000000000000e+000" for 0). As a result, <xref:System.Object.ToString?displayProperty=fullName> conversion does not produce the same string as <xref:System.Convert.ToString%2A?displayProperty=fullName> in the .NET Framework.  
  
## See Also  
 [Data Types and Functions](../../../../../../docs/framework/data/adonet/sql/linq/data-types-and-functions.md)