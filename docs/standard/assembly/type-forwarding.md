---
title: "Type forwarding in the common language runtime"
description: Type forwarding allows you to move a type to another .NET assembly without having to recompile applications that use the original assembly.
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "assemblies [.NET], type forwarding"
  - "type forwarding"
ms.assetid: 51f8ffa3-c253-4201-a3d3-c4fad85ae097
dev_langs: 
  - "csharp"
  - "cpp"
---
# Type forwarding in the common language runtime

Type forwarding allows you to move a type to another assembly without having to recompile applications that use the original assembly.  
  
 For example, suppose an application uses the `Example` class in an assembly named *Utility.dll*. The developers of *Utility.dll* might decide to refactor the assembly, and in the process they might move the `Example` class to another assembly. If the old version of *Utility.dll* is replaced by the new version of *Utility.dll* and its companion assembly, the application that uses the `Example` class fails because it cannot locate the `Example` class in the new version of *Utility.dll*.  
  
 The developers of *Utility.dll* can avoid this by forwarding requests for the `Example` class, using the <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute. If the attribute has been applied to the new version of *Utility.dll*, requests for the `Example` class are forwarded to the assembly that now contains the class. The existing application continues to function normally, without recompilation.

## Forward a type

 There are four steps to forwarding a type:  
  
1. Move the source code for the type from the original assembly to the destination assembly.  

2. In the assembly where the type used to be located, add a <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> for the type that was moved. The following code shows the attribute for a type named `Example` that was moved.  

   ```cpp  
    [assembly:TypeForwardedToAttribute(Example::typeid)]  
   ```

   ```csharp  
    [assembly:TypeForwardedToAttribute(typeof(Example))]  
   ```  

3. Compile the assembly that now contains the type.  

4. Recompile the assembly where the type used to be located, with a reference to the assembly that now contains the type. For example, if you are compiling a C# file from the command line, use the [**References** (C# compiler options)](../../csharp/language-reference/compiler-options/inputs.md#references) option to specify the assembly that contains the type. In C++, use the [#using](/cpp/preprocessor/hash-using-directive-cpp) directive in the source file to specify the assembly that contains the type.  
  
## See also

- <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute>
- [Type forwarding (C++/CLI)](/cpp/windows/type-forwarding-cpp-cli)
- [#using directive](/cpp/preprocessor/hash-using-directive-cpp)
