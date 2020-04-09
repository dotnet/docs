---
title: "Common Attributes (C#)"
ms.date: 07/20/2015
ms.assetid: 785a0526-6c0e-4599-8c61-ccdc88dd9965
---
# Common Attributes (C#)
This topic describes the attributes that are most commonly used in C# programs.  
  
- [Global Attributes](#Global)  
  
- [Obsolete Attribute](#Obsolete)  
  
- [Conditional Attribute](#Conditional)  
  
- [Caller Info Attributes](#CallerInfo)  
  
## <a name="CallerInfo"></a> Caller Info Attributes  
 By using Caller Info attributes, you can obtain information about the caller to a method. You can obtain the file path of the source code, the line number in the source code, and the member name of the caller.  
  
 To obtain member caller information, you use attributes that are applied to optional parameters. Each optional parameter specifies a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:  
  
|Attribute|Description|Type|  
|---|---|---|  
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. This is the path at compile time.|`String`|  
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file from which the method is called.|`Integer`|  
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method name or property name of the caller. For more information, see [Caller Information (C#)](../caller-information.md).|`String`|  
  
 For more information about the Caller Info attributes, see [Caller Information (C#)](../caller-information.md).  
  
## See also

- <xref:System.Reflection>
- <xref:System.Attribute>
- [C# Programming Guide](../../index.md)
- [Attributes](../../../../standard/attributes/index.md)
- [Reflection (C#)](../reflection.md)
- [Accessing Attributes by Using Reflection (C#)](./accessing-attributes-by-using-reflection.md)
