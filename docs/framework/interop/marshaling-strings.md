---
title: "Marshaling Strings | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "marshaling, samples"
  - "platform invoke, marshaling data"
  - "data marshaling, strings"
  - "data marshaling, samples"
  - "data marshaling, platform invoke"
  - "marshaling. strings"
  - "marshaling, platform invoke"
  - "sample applications [.NET Framework], marshaling strings"
ms.assetid: e21b078b-70fb-4905-be26-c097ab2433ff
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Marshaling Strings
Platform invoke copies string parameters, converting them from the .NET Framework format (Unicode) to the unmanaged format (ANSI), if needed. Because managed strings are immutable, platform invoke does not copy them back from unmanaged memory to managed memory when the function returns.  
  
 The following table lists marshaling options for strings, describes their usage, and provides a link to the corresponding .NET Framework sample.  
  
|String|Description|Sample|  
|------------|-----------------|------------|  
|By value.|Passes strings as In parameters.|[MsgBox](../../../docs/framework/interop/msgbox-sample.md)|  
|As result.|Returns strings from unmanaged code.|[Strings](https://msdn.microsoft.com/library/e765dyyy.aspx)|  
|By reference.|Passes strings as In/Out parameters using <xref:System.Text.StringBuilder>.|[Buffers](https://msdn.microsoft.com/library/x3txb6xc.aspx)|  
|In a structure by value.|Passes strings in a structure that is an In parameter.|[Structs](https://msdn.microsoft.com/library/eadtsekz.aspx)|  
|In a structure by reference **(char\*)**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects a pointer to a character buffer and the buffer size is a member of the structure.|[Strings](https://msdn.microsoft.com/library/e765dyyy.aspx)|  
|In a structure by reference **(char[])**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects an embedded character buffer.|[OSInfo](https://msdn.microsoft.com/library/795sy883.aspx)|  
|In a class by value **(char\*)**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects a pointer to a character buffer.|[OpenFileDlg](https://msdn.microsoft.com/library/w5tyztk9.aspx)|  
|In a class by value **(char[])**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects an embedded character buffer.|[OSInfo](https://msdn.microsoft.com/library/795sy883.aspx)|  
|As an array of strings by value.|Creates an array of strings that is passed by value.|[Arrays](../../../docs/framework/interop/marshaling-different-types-of-arrays.md)|  
|As an array of structures that contain strings by value.|Creates an array of structures that contain strings and the array is passed by value.|[Arrays](../../../docs/framework/interop/marshaling-different-types-of-arrays.md)|  
  
## See Also  
 [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md)   
 [Platform Invoke Data Types](https://msdn.microsoft.com/library/ac7ay120.aspx)   
 [Marshaling Classes, Structures, and Unions](../../../docs/framework/interop/marshaling-classes-structures-and-unions.md)   
 [Marshaling Arrays of Types](https://msdn.microsoft.com/library/dd93y453.aspx)   
 [Miscellaneous Marshaling Samples](https://msdn.microsoft.com/library/ss9sb93t.aspx)
