---
description: "Learn more about: System.Object Methods"
title: "System.Object Methods"
ms.date: "03/30/2017"
ms.assetid: 5397fca0-689e-443e-802f-e1cbdc866427
---
# System.Object Methods

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports the following <xref:System.Object> methods:

- <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType>
- <xref:System.Object.Equals%28System.Object%2CSystem.Object%29?displayProperty=nameWithType>
- <xref:System.Object.ToString?displayProperty=nameWithType>
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the following <xref:System.Object> methods:

- <xref:System.Object.GetHashCode?displayProperty=nameWithType>
- <xref:System.Object.ReferenceEquals%28System.Object%2CSystem.Object%29?displayProperty=nameWithType>
- <xref:System.Object.MemberwiseClone?displayProperty=nameWithType>
- <xref:System.Object.GetType?displayProperty=nameWithType>
- <xref:System.Object.ToString?displayProperty=nameWithType> for binary types such as `BINARY`, `VARBINARY`, `IMAGE`, and `TIMESTAMP`.
  
## Differences from .NET  

 The output of <xref:System.Object.ToString?displayProperty=nameWithType> for double uses SQL `CONVERT`(NVARCHAR(30), @x, 2) on SQL. SQL always uses 16 digits and scientific notation in this case (for example, "0.000000000000000e+000" for 0). As a result, <xref:System.Object.ToString?displayProperty=nameWithType> conversion does not produce the same string as <xref:System.Convert.ToString%2A?displayProperty=nameWithType> in the .NET Framework.  
  
## See also

- [Data Types and Functions](data-types-and-functions.md)
