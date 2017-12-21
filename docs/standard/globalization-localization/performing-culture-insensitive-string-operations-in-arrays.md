---
title: "Performing Culture-Insensitive String Operations in Arrays"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "culture-insensitive string operations, in arrays"
  - "arrays [.NET Framework], culture-insensitive string operations"
  - "comparer parameter"
ms.assetid: f12922e1-6234-4165-8896-63f0653ab478
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Performing Culture-Insensitive String Operations in Arrays
Overloads of the <xref:System.Array.Sort%2A?displayProperty=nameWithType> and <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType> methods perform culture-sensitive sorts by default using the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> property. Culture-sensitive results returned by these methods can vary by culture due to differences in sort orders. To eliminate culture-sensitive behavior, use one of the overloads of this method that accepts a `comparer` parameter. The `comparer` parameter specifies the <xref:System.Collections.IComparer> implementation to use when comparing elements in the array. For the parameter, specify a custom invariant comparer class that uses <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>. An example of a custom invariant comparer class is provided in the "Using the SortedList Class" subtopic of the [Performing Culture-Insensitive String Operations in Collections](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-operations-in-collections.md) topic.  
  
 **Note** Passing **CultureInfo.InvariantCulture** to a comparison method does perform a culture-insensitive comparison. However, it does not cause a non-linguistic comparison, for example, for file paths, registry keys, and environment variables. Neither does it support security decisions based on the comparison result. For a non-linguistic comparison or support for result-based security decisions, the application should use a comparison method that accepts a <xref:System.StringComparison> value. The application should then pass <xref:System.StringComparison.Ordinal>.  
  
## See Also  
 <xref:System.Array.Sort%2A?displayProperty=nameWithType>  
 <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType>  
 <xref:System.Collections.IComparer>  
 [Performing Culture-Insensitive String Operations](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-operations.md)
