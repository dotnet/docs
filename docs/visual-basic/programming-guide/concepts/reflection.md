---
title: "Reflection (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: d991bc0f-d16a-4ac5-9351-70e5c5b9891b
caps.latest.revision: 3
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Reflection (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Reflection provides objects (of type <xref:System.Type>) that describe assemblies, modules and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties. If you are using attributes in your code, reflection enables you to access them. For more information, see [Attributes](../Topic/Extending%20Metadata%20Using%20Attributes.md).  
  
 Here's a simple example of reflection using the static method `GetType` - inherited by all types from the `Object` base class - to obtain the type of a variable:  
  
```vb  
' Using GetType to obtain type information:  
Dim i As Integer = 42  
Dim type As System.Type = i.GetType()  
System.Console.WriteLine(type)  
```  
  
 The output is:  
  
 `System.Int32`  
  
 The following example uses reflection to obtain the full name of the loaded assembly.  
  
```vb  
' Using Reflection to get information from an Assembly:  
Dim info As System.Reflection.Assembly = GetType(System.Int32).Assembly  
System.Console.WriteLine(info)  
```  
  
 The output is:  
  
 `mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089`  
  
## Reflection Overview  
 Reflection is useful in the following situations:  
  
-   When you have to access attributes in your program's metadata. For more information, see [Retrieving Information Stored in Attributes](../Topic/Retrieving%20Information%20Stored%20in%20Attributes.md).  
  
-   For examining and instantiating types in an assembly.  
  
-   For building new types at runtime. Use classes in <xref:System.Reflection.Emit>.  
  
-   For performing late binding, accessing methods on types created at run time. See the topic [Dynamically Loading and Using Types](../Topic/Dynamically%20Loading%20and%20Using%20Types.md).  
  
## Related Sections  
 For more information:  
  
-   [Reflection](../Topic/Reflection%20in%20the%20.NET%20Framework.md)  
  
-   [Viewing Type Information](../Topic/Viewing%20Type%20Information.md)  
  
-   [Reflection and Generic Types](../Topic/Reflection%20and%20Generic%20Types.md)  
  
-   <xref:System.Reflection.Emit>  
  
-   [Retrieving Information Stored in Attributes](../Topic/Retrieving%20Information%20Stored%20in%20Attributes.md)  
  
## See Also  
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)   
 [Assemblies in the Common Language Runtime](../Topic/Assemblies%20in%20the%20Common%20Language%20Runtime.md)