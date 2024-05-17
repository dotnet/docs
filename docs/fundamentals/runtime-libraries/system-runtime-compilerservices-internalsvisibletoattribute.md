---
title: System.Runtime.CompilerServices.InternalsVisibleToAttribute class
description: Learn about the System.Runtime.CompilerServices.InternalsVisibleToAttribute class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Runtime.CompilerServices.InternalsVisibleToAttribute class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute specifies that types that are ordinarily visible only within the current assembly are visible to a specified assembly.

Ordinarily, types and members with [`internal` scope in C#](../../csharp/language-reference/keywords/internal.md) or [`Friend` scope in Visual Basic](../../visual-basic/language-reference/modifiers/friend.md) are visible only in the assembly in which they are defined. Types and members with [`protected internal`](../../csharp/language-reference/keywords/protected-internal.md) scope ([`Protected Friend`](../../visual-basic/language-reference/modifiers/protected-friend.md) scope in Visual Basic) are visible only in their own assembly or to types that derive from their containing class. Types and members with [`private protected`](../../csharp/language-reference/keywords/private-protected.md) scope ([`Private Protected`](../../visual-basic/language-reference/modifiers/private-protected.md) scope in Visual Basic) are visible in the containing class or in types that derive from their containing class within the current assembly

The <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute makes these types and members also visible to the types in a specified assembly, which is known as a friend assembly. This applies only to `internal` (`Friend` in Visual Basic), `protected internal`(`Protected Friend` in Visual Basic), and `private protected` (`Private Protected` in Visual Basic) members, but not `private` ones.

> [!NOTE]
> In the case of `private protected` (`Private Protected` in Visual Basic) members, the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute extends accessibility only to types that derive from the *containing class* of the member.

The attribute is applied at the assembly level. This means that it can be included at the beginning of a source code file, or it can be included in the AssemblyInfo file in a Visual Studio project. You can use the attribute to specify a single friend assembly that can access the internal types and members of the current assembly. You can define multiple friend assemblies in two ways. They can appear as individual assembly-level attributes, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Runtime.CompilerServices/InternalsVisibleToAttribute/Overview/csharp/multiple1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Runtime.CompilerServices/InternalsVisibleToAttribute/Overview/vb/multiple1.vb" id="Snippet3":::

They can also appear with separate <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> tags but a single `assembly` keyword, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Runtime.CompilerServices/InternalsVisibleToAttribute/Overview/csharp/multiple2.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Runtime.CompilerServices/InternalsVisibleToAttribute/Overview/vb/multiple2.vb" id="Snippet4":::

The friend assembly is identified by the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute.%23ctor%2A> constructor. Both the current assembly and the friend assembly must be unsigned, or both assemblies must be signed with a strong name.

If both assemblies are unsigned, the `assemblyName` argument consists of the name of the friend assembly, specified without a directory path or file name extension.

If both assemblies are signed with a strong name, the argument to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute.%23ctor%2A> constructor must consist of the name of the assembly without its directory path or file name extension, along with the full public key (and not its public key token). To get the full public key of a strong-named assembly, see the [Get the full public key](#get-the-full-public-key) section later in this article. For more information about using <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> with strong-named assemblies, see the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute.%23ctor%2A> constructor.

Do not include values for the <xref:System.Reflection.AssemblyName.CultureInfo%2A>, <xref:System.Reflection.AssemblyName.Version%2A>, or <xref:System.Reflection.AssemblyName.ProcessorArchitecture%2A> field in the argument; the Visual Basic, C#, and C++ compilers treat this as a compiler error. If you use a compiler that does not treat it as an error (such as the [IL Assembler (ILAsm.exe)](../../framework/tools/ilasm-exe-il-assembler.md)) and the assemblies are strong-named, a <xref:System.MethodAccessException> exception is thrown the first time the specified friend assembly accesses the assembly that contains the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute.

For more information about how to use this attribute, see [Friend assemblies](../../standard/assembly/friend.md) and [C++ friend assemblies](/cpp/dotnet/friend-assemblies-cpp).

## Get the full public key

You can use the [Strong Name Tool (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md) to retrieve the full public key from a strong-named key (.snk) file. To do this, you perform the following steps:

1. Extract the public key from the strong-named key file to a separate file:

     `Sn -p  <snk_file> <outfile>`

2. Display the full public key to the console:

     `Sn -tp <outfile>`

3. Copy and paste the full public key value into your source code.

## Compile the friend assembly with C\#

If you use the C# compiler to compile the friend assembly, you must explicitly specify the name of the output file (.exe or .dll) by using the **/out** compiler option. This is required because the compiler has not yet generated the name for the assembly it is building at the time it is binding to external references. The **/out** compiler option is optional for the Visual Basic compiler, and the corresponding **-out** or **-o** compiler option should not be used when compiling friend assemblies with the F# compiler.

## Compile the friend assembly with C++

In C++, in order to make the internal members enabled by the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute accessible to a friend assembly, you must use the `as_friend` attribute in the C++  directive. For more information, see [Friend Assemblies (C++)](/cpp/dotnet/friend-assemblies-cpp).
