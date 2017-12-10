---
title: "Reflection (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: d991bc0f-d16a-4ac5-9351-70e5c5b9891b
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Reflection (Visual Basic)
Reflection provides objects (of type <xref:System.Type>) that describe assemblies, modules and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties. If you are using attributes in your code, reflection enables you to access them. For more information, see [Attributes](../../../standard/attributes/index.md).  
  
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
  
-   When you have to access attributes in your program's metadata. For more information, see [Retrieving Information Stored in Attributes](../../../standard/attributes/retrieving-information-stored-in-attributes.md).  
  
-   For examining and instantiating types in an assembly.  
  
-   For building new types at runtime. Use classes in <xref:System.Reflection.Emit>.  
  
-   For performing late binding, accessing methods on types created at run time. See the topic [Dynamically Loading and Using Types](../../../framework/reflection-and-codedom/dynamically-loading-and-using-types.md).  
  
## Related Sections  
 For more information:  
  
-   [Reflection](../../../framework/reflection-and-codedom/reflection.md)  
  
-   [Viewing Type Information](../../../framework/reflection-and-codedom/viewing-type-information.md)  
  
-   [Reflection and Generic Types](../../../framework/reflection-and-codedom/reflection-and-generic-types.md)  
  
-   <xref:System.Reflection.Emit>  
  
-   [Retrieving Information Stored in Attributes](../../../standard/attributes/retrieving-information-stored-in-attributes.md)  
  
## See Also  
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)  
 [Assemblies in the Common Language Runtime](../../../framework/app-domains/assemblies-in-the-common-language-runtime.md)
