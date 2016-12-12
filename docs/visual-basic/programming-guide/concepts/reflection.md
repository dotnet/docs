---
title: "Reflection (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: d991bc0f-d16a-4ac5-9351-70e5c5b9891b
caps.latest.revision: 3
author: "stevehoag"
ms.author: "shoag"

translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Reflection (Visual Basic)
Reflection provides objects (of type <xref:System.Type>) that describe assemblies, modules and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties. If you are using attributes in your code, reflection enables you to access them. For more information, see [Attributes](https://msdn.microsoft.com/library/5x6cd29c).  
  
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
  
-   When you have to access attributes in your program's metadata. For more information, see [Retrieving Information Stored in Attributes](http://msdn.microsoft.com/library/37dfe4e3-7da0-48b6-a3d9-398981524e1c).  
  
-   For examining and instantiating types in an assembly.  
  
-   For building new types at runtime. Use classes in <xref:System.Reflection.Emit>.  
  
-   For performing late binding, accessing methods on types created at run time. See the topic [Dynamically Loading and Using Types](http://msdn.microsoft.com/library/db985bec-5942-40ec-b13a-771ae98623dc).  
  
## Related Sections  
 For more information:  
  
-   [Reflection](http://msdn.microsoft.com/library/d1a58e7f-fb39-4d50-bf84-e3b8f9bf9775)  
  
-   [Viewing Type Information](http://msdn.microsoft.com/library/7e7303a9-4064-4738-b4e7-b75974ed70d2)  
  
-   [Reflection and Generic Types](http://msdn.microsoft.com/library/f7180fc5-dd41-42d4-8a8e-1b34288e06de)  
  
-   <xref:System.Reflection.Emit>  
  
-   [Retrieving Information Stored in Attributes](http://msdn.microsoft.com/library/37dfe4e3-7da0-48b6-a3d9-398981524e1c)  
  
## See Also  
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)   
 [Assemblies in the Common Language Runtime](https://msdn.microsoft.com/library/k3677y81)