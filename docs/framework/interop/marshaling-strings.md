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
|As result.|Returns strings from unmanaged code.|[Strings](http://msdn.microsoft.com/en-us/be9e82a3-dc95-4aaa-9396-61b66e467e02)|  
|By reference.|Passes strings as In/Out parameters using <xref:System.Text.StringBuilder>.|[Buffers](http://msdn.microsoft.com/en-us/e30d36e8-d7c4-4936-916a-8fdbe4d9ffd5)|  
|In a structure by value.|Passes strings in a structure that is an In parameter.|[Structs](http://msdn.microsoft.com/en-us/96a62265-dcf9-4608-bc0a-1f762ab9f48e)|  
|In a structure by reference **(char\*)**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects a pointer to a character buffer and the buffer size is a member of the structure.|[Strings](http://msdn.microsoft.com/en-us/be9e82a3-dc95-4aaa-9396-61b66e467e02)|  
|In a structure by reference **(char[])**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects an embedded character buffer.|[OSInfo](http://msdn.microsoft.com/en-us/69d89067-507b-41fe-859d-30bf3ff29455)|  
|In a class by value **(char\*)**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects a pointer to a character buffer.|[OpenFileDlg](http://msdn.microsoft.com/en-us/b7dea792-cb92-4baf-ac7b-6a24803e6c75)|  
|In a class by value **(char[])**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects an embedded character buffer.|[OSInfo](http://msdn.microsoft.com/en-us/69d89067-507b-41fe-859d-30bf3ff29455)|  
|As an array of strings by value.|Creates an array of strings that is passed by value.|[Arrays](../../../docs/framework/interop/marshaling-different-types-of-arrays.md)|  
|As an array of structures that contain strings by value.|Creates an array of structures that contain strings and the array is passed by value.|[Arrays](../../../docs/framework/interop/marshaling-different-types-of-arrays.md)|  
  
## See Also  
 [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md)   
 [Platform Invoke Data Types](http://msdn.microsoft.com/en-us/16014d9f-d6bd-481e-83f0-df11377c550f)   
 [Marshaling Classes, Structures, and Unions](../../../docs/framework/interop/marshaling-classes-structures-and-unions.md)   
 [Marshaling Arrays of Types](http://msdn.microsoft.com/en-us/049b1c1b-228f-4445-88ec-91bc7fd4b1e8)   
 [Miscellaneous Marshaling Samples](http://msdn.microsoft.com/en-us/a915c948-54e9-4d0f-a525-95a77fd8ed70)