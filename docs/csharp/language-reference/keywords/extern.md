---
title: "extern modifier - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "extern_CSharpKeyword"
  - "extern"
helpviewer_keywords: 
  - "DllImport attribute"
  - "extern keyword [C#]"
ms.assetid: 9c3f02c4-51b8-4d80-9cb2-f2b6e1ae15c7
---
# extern (C# Reference)

The `extern` modifier is used to declare a method that is implemented externally. A common use of the `extern` modifier is with the `DllImport` attribute when you are using Interop services to call into unmanaged code. In this case, the method must also be declared as `static`, as shown in the following example:

```csharp
[DllImport("avifil32.dll")]
private static extern void AVIFileInit();
```

The `extern` keyword can also define an external assembly alias, which makes it possible to reference different versions of the same component from within a single assembly. For more information, see [extern alias](extern-alias.md).

It is an error to use the [abstract](abstract.md) and `extern` modifiers together to modify the same member. Using the `extern` modifier means that the method is implemented outside the C# code, whereas using the `abstract` modifier means that the method implementation is not provided in the class.

The extern keyword has more limited uses in C# than in C++. To compare the C# keyword with the C++ keyword, see Using extern to Specify Linkage in the C++ Language Reference.

## Example 1

In this example, the program receives a string from the user and displays it inside a message box. The program uses the `MessageBox` method imported from the User32.dll library.

[!code-csharp[csrefKeywordsModifiers#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#8)]

## Example 2

This example illustrates a C# program that calls into a C library (a native DLL).

1. Create the following C file and name it `cmdll.c`:

```c
// cmdll.c
// Compile with: -LD
int __declspec(dllexport) SampleMethod(int i)
{
  return i*10;
}
```

2. Open a Visual Studio x64 (or x32) Native Tools Command Prompt window from the Visual Studio installation directory and compile the `cmdll.c` file by typing **cl -LD cmdll.c** at the command prompt.

3. In the same directory, create the following C# file and name it `cm.cs`:

```csharp
// cm.cs
using System;
using System.Runtime.InteropServices;
public class MainClass
{
    [DllImport("Cmdll.dll")]
      public static extern int SampleMethod(int x);

    static void Main()
    {
        Console.WriteLine("SampleMethod() returns {0}.", SampleMethod(5));
    }
}
```

4. Open a Visual Studio x64 (or x32) Native Tools Command Prompt window from the Visual Studio installation directory and compile the `cm.cs` file by typing:

> **csc cm.cs** (for the x64 command prompt)
> —or—
> **csc -platform:x86 cm.cs** (for the x32 command prompt)

This will create the executable file `cm.exe`.

5. Run `cm.exe`. The `SampleMethod` method passes the value 5 to the DLL file, which returns the value multiplied by 10.  The program produces the following output:

```
SampleMethod() returns 50.
```

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Runtime.InteropServices.DllImportAttribute?displayProperty=nameWithType>  
- [C# Reference](../index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [Modifiers](modifiers.md)  