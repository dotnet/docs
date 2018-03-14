---
title: "Floating-Point Numbers"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 73c218c6-1c44-4402-a167-4f6262629a91
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Floating-Point Numbers
This topic describes some of the issues that developers frequently encounter when they work with floating-point numbers in [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)]. These issues are caused by the way that computers store floating-point numbers, and are not specific to a particular provider such as <xref:System.Data.SqlClient> or <xref:System.Data.OracleClient>.  
  
 Floating-point numbers generally do not have an exact binary representation. Instead, the computer stores an approximation of the number. At different times, different numbers of binary digits may be used to represent the number. When a floating point number is converted from one representation to another representation, the least significant digits of that number may vary slightly. Conversion typically occurs when the number is cast from one type to another type. The variation occurs whether the conversion occurs within a database, between types that represent database values, or between types. Because of these changes, numbers that would logically be equal may have changes in their least-significant digits that cause them to have different values. The number of digits of precision in the number may be larger or smaller than expected. When formatted as a string, the number may not show the expected value.  
  
 To minimize these effects, you should use the closest match between numeric types that is available to you. For example, if you are working with [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)], the exact numeric value may change if you convert a Transact-SQL value of real type to a value of float type. In the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], converting a <xref:System.Single> to a <xref:System.Double> may also produce unexpected results. In both of these cases, a good strategy is to make all the values in the application use the same numeric type. You can also use a fixed-precision decimal type, or cast floating-point numbers to a fixed-precision decimal type before you work with them.  
  
 To work around problems with equality comparison, consider coding your application so that variations in the least significant digits are ignored. For example, instead of comparing to see whether two numbers are equal, subtract one number from the other number. If the difference is within an acceptable margin of rounding, your application can treat the numbers as if they are the same.  
  
## See Also  
 [Why Floating-Point Numbers May Lose Precision](http://msdn.microsoft.com/library/1acb1add-ac06-4134-a2fd-aff13d8c4c15)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
