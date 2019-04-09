---
title: "Marshaling Strings"
ms.date: "03/30/2017"
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
author: "rpetrusha"
ms.author: "ronpet"
---
# Marshaling Strings
Platform invoke copies string parameters, converting them from the .NET Framework format (Unicode) to the unmanaged format (ANSI), if needed. Because managed strings are immutable, platform invoke does not copy them back from unmanaged memory to managed memory when the function returns.  
  
 The following table lists marshaling options for strings, describes their usage, and provides a link to the corresponding .NET Framework sample.  
  
|String|Description|Sample|  
|------------|-----------------|------------|  
|By value.|Passes strings as In parameters.|[MsgBox](msgbox-sample.md)|  
|As result.|Returns strings from unmanaged code.|[Strings](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/e765dyyy(v=vs.100))|  
|By reference.|Passes strings as In/Out parameters using <xref:System.Text.StringBuilder>.|[Buffers](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/x3txb6xc(v=vs.100))|  
|In a structure by value.|Passes strings in a structure that is an In parameter.|[Structs](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/eadtsekz(v=vs.100))|  
|In a structure by reference **(char\*)**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects a pointer to a character buffer and the buffer size is a member of the structure.|[Strings](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/e765dyyy(v=vs.100))|  
|In a structure by reference **(char[])**.|Passes strings in a structure that is an In/Out parameter. The unmanaged function expects an embedded character buffer.|[OSInfo](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/795sy883(v=vs.100))|  
|In a class by value **(char\*)**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects a pointer to a character buffer.|[OpenFileDlg](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/w5tyztk9(v=vs.100))|  
|In a class by value **(char[])**.|Passes strings in a class (a class is an In/Out parameter). The unmanaged function expects an embedded character buffer.|[OSInfo](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/795sy883(v=vs.100))|  
|As an array of strings by value.|Creates an array of strings that is passed by value.|[Arrays](marshaling-different-types-of-arrays.md)|  
|As an array of structures that contain strings by value.|Creates an array of structures that contain strings and the array is passed by value.|[Arrays](marshaling-different-types-of-arrays.md)|  
  
## See also

- [Default Marshaling for Strings](default-marshaling-for-strings.md)
- [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md)
- [Marshaling Classes, Structures, and Unions](marshaling-classes-structures-and-unions.md)
- [Marshaling Different Types of Arrays](marshaling-different-types-of-arrays.md)
- [Miscellaneous Marshaling Samples](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ss9sb93t(v=vs.100))
