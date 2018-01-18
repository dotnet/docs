---
title: "Type Forwarding in the Common Language Runtime"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "cpp"
helpviewer_keywords: 
  - "assemblies [.NET Framework], type forwarding"
  - "type forwarding"
ms.assetid: 51f8ffa3-c253-4201-a3d3-c4fad85ae097
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Type Forwarding in the Common Language Runtime
Type forwarding allows you to move a type to another assembly without having to recompile applications that use the original assembly.  
  
 For example, suppose an application uses the `Example` class in an assembly named `Utility.dll`. The developers of `Utility.dll` might decide to refactor the assembly, and in the process they might move the `Example` class to another assembly. If the old version of `Utility.dll` is replaced by the new version of `Utility.dll` and its companion assembly, the application that uses the `Example` class fails because it cannot locate the `Example` class in the new version of `Utility.dll`.  
  
 The developers of `Utility.dll` can avoid this by forwarding requests for the `Example` class, using the <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute. If the attribute has been applied to the new version of `Utility.dll`, requests for the `Example` class are forwarded to the assembly that now contains the class. The existing application continues to function normally, without recompilation.  
  
> [!NOTE]
>  In the .NET Framework version 2.0, you cannot forward types from assemblies written in Visual Basic. However, an application written in Visual Basic can consume forwarded types. That is, if the application uses an assembly coded in C# or C++, and a type from that assembly is forwarded to another assembly, the Visual Basic application can use the forwarded type.  
  
## Forwarding Types  
 There are four steps to forwarding a type:  
  
1.  Move the source code for the type from the original assembly to the destination assembly.  
  
2.  In the assembly where the type used to be located, add a <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> for the type that was moved. The following code shows the attribute for a type named `Example` that was moved.  
  
    ```csharp  
    [assembly:TypeForwardedToAttribute(typeof(Example))]  
    ```  
  
    ```cpp  
    [assembly:TypeForwardedToAttribute(Example::typeid)]  
    ```  
  
3.  Compile the assembly that now contains the type.  
  
4.  Recompile the assembly where the type used to be located, with a reference to the assembly that now contains the type. For example, if you are compiling a C# file from the command line, use the [/reference (C# Compiler Options)](~/docs/csharp/language-reference/compiler-options/reference-compiler-option.md) option to specify the assembly that contains the type. In C++, use the [#using](http://msdn.microsoft.com/library/870b15e5-f361-40a8-ba1c-c57d75c8809a) directive in the source file to specify the assembly that contains the type.  
  
## See Also  
 <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute>  
 [Type Forwarding (C++/CLI)](/cpp/windows/type-forwarding-cpp-cli)  
 [#using Directive](http://msdn.microsoft.com/library/870b15e5-f361-40a8-ba1c-c57d75c8809a)
