---
title: "How to: View assembly contents"
description: You can use the IL Disassembler to view an assembly's attributes and references to other modules and assemblies.
ms.date: "08/20/2019"
helpviewer_keywords:
  - "assembly manifest, viewing information"
  - "Ildasm.exe"
  - "MSIL Disassembler"
  - "assemblies [.NET], viewing contents"
  - "viewing assembly information"
  - "MSIL"
  - "viewing MSIL information"
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---
# How to: View assembly contents

You can use the [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md) to view Microsoft intermediate language (MSIL) information in a file. If the file being examined is an assembly, this information can include the assembly's attributes and references to other modules and assemblies. This information can be helpful in determining whether a file is an assembly or part of an assembly and whether the file has references to other modules or assemblies.

To display the contents of an assembly using *Ildasm.exe*, enter **ildasm \<assembly name>** at a command prompt. For example, the following command disassembles the *Hello.exe* assembly.

```cmd
ildasm Hello.exe
```

To view assembly manifest information, double-click the **Manifest** icon in the MSIL Disassembler window.

## Example

The following example starts with a basic "Hello World" program. After compiling the program, use *Ildasm.exe* to disassemble the *Hello.exe* assembly and view the assembly manifest.

```cpp
using namespace System;

class MainApp
{
public:
    static void Main()
    {
        Console::WriteLine("Hello World using C++/CLI!");
    }
};

int main()
{
    MainApp::Main();
}
```

```csharp
using System;

class MainApp
{
    public static void Main()
    {
        Console.WriteLine("Hello World using C#!");
    }
}
```

```vb
Class MainApp
    Public Shared Sub Main()
        Console.WriteLine("Hello World using Visual Basic!")
    End Sub
End Class
```

Running the command *ildasm.exe* on the *Hello.exe* assembly and double-clicking the **Manifest** icon in the MSIL Disassembler window produces the following output:

```output
// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Hello
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module Hello.exe
// MVID: {7C2770DB-1594-438D-BAE5-98764C39CCCA}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00600000
```

The following table describes each directive in the assembly manifest of the *Hello.exe* assembly used in the example:

|Directive|Description|
|---------------|-----------------|
|**.assembly extern \<assembly name>**|Specifies another assembly that contains items referenced by the current module (in this example, `mscorlib`).|
|**.publickeytoken \<token>**|Specifies the token of the actual key of the referenced assembly.|
|**.ver \<version number>**|Specifies the version number of the referenced assembly.|
|**.assembly \<assembly name>**|Specifies the assembly name.|
|**.hash algorithm \<int32 value>**|Specifies the hash algorithm used.|
|**.ver \<version number>**|Specifies the version number of the assembly.|
|**.module \<file name>**|Specifies the name of the modules that make up the assembly. In this example, the assembly consists of only one file.|
|**.subsystem \<value>**|Specifies the application environment required for the program. In this example, the value 3 indicates that this executable is run from a console.|
|**.corflags**|Currently a reserved field in the metadata.|

An assembly manifest can contain a number of different directives, depending on the contents of the assembly. For an extensive list of the directives in the assembly manifest, see the Ecma documentation, especially "Partition II: Metadata Definition and Semantics" and "Partition III: CIL Instruction Set":

- [ECMA C# and Common Language Infrastructure standards](../../fundamentals/standards.md)
- [Standard ECMA-335 - Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/)

## See also

- [Application domains and assemblies](../../framework/app-domains/application-domains.md#application-domains-and-assemblies)
- [Application domains and assemblies how-to topics](../../framework/app-domains/application-domains-and-assemblies-how-to-topics.md)
- [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md)
