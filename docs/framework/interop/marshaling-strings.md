---
title: "Marshaling Strings"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
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
ms.workload: 
  - "dotnet"
---
# Marshaling Strings
Platform invoke copies string parameters, converting them from the .NET Framework format (Unicode) to the unmanaged format (ANSI), if needed. Because managed strings are immutable, platform invoke does not copy them back from unmanaged memory to managed memory when the function returns.  
  
 The following table lists marshaling options for strings, describes their usage, and provides a link to the corresponding .NET Framework sample.  
  
|String|Description|Sample|  
|------------|-----------------|------------|  
|By value.|Passes strings as In parameters.|[MsgBox](msgbox-sample.md)|  
|As result.|Returns strings from unmanaged code.|[Strings](https://msdn.microsoft.com/library/be9e82a3-dc95-4aaa-9396-61b66e467e02(v=vs.100))|  
|By reference.|Passes strings as In/Out parameters using <xref:System.Text.StringBuilder>.|[Buffers](https://msdn.microsoft.com/library/e30d36e8-d7c4-4936-916a-8fdbe4d9ffd5(v=vs.100))|  
|In a structure by value.|Passes strings in a structure that is an In parameter.|[Structs](https://msdn.microsoft.com/library/96a62265-dcf9-4608-bc0a-1f762ab9f48e(v=vs.100))|  
|In a structure by reference **(char\*)**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects a pointer to a character buffer and the buffer size is a member of the structure.|[Strings](https://msdn.microsoft.com/library/be9e82a3-dc95-4aaa-9396-61b66e467e02(v=vs.100))|  
|In a structure by reference **(char[])**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects an embedded character buffer.|[OSInfo](https://msdn.microsoft.com/library/69d89067-507b-41fe-859d-30bf3ff29455(v=vs.100))|  
|In a class by value **(char\*)**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects a pointer to a character buffer.|[OpenFileDlg](https://msdn.microsoft.com/library/b7dea792-cb92-4baf-ac7b-6a24803e6c75(v=vs.100))|  
|In a class by value **(char[])**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects an embedded character buffer.|[OSInfo](https://msdn.microsoft.com/library/69d89067-507b-41fe-859d-30bf3ff29455(v=vs.100))|  
|As an array of strings by value.|Creates an array of strings that is passed by value.|[Arrays](marshaling-different-types-of-arrays.md)|  
|As an array of structures that contain strings by value.|Creates an array of structures that contain strings and the array is passed by value.|[Arrays](marshaling-different-types-of-arrays.md)|  
  
## See Also  
 [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md)  
 [Platform Invoke Data Types](https://msdn.microsoft.com/library/16014d9f-d6bd-481e-83f0-df11377c550f(v=vs.100))  
 [Marshaling Classes, Structures, and Unions](marshaling-classes-structures-and-unions.md)  
 [Marshaling Arrays of Types](https://msdn.microsoft.com/library/049b1c1b-228f-4445-88ec-91bc7fd4b1e8(v=vs.100))  
 [Miscellaneous Marshaling Samples](https://msdn.microsoft.com/library/a915c948-54e9-4d0f-a525-95a77fd8ed70(v=vs.100))
