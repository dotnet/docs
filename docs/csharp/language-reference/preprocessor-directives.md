---
description: "Learn the different C# preprocessor directives that control conditional compilation, warnings, nullable analysis, and more"
title: "C# preprocessor directives"
ms.date: 03/17/2021
f1_keywords: 
  - "cs.preprocessor"
  - "#nullable"
  - "#if"
  - "#else"
  - "#elif"
  - "#endif"
  - "#define"
  - "#undef"
  - "#warning"
  - "#error"
  - "#line"
  - "#region"
  - "#endregion"
  - "#pragma"
  - "#pragma warning"
  - "#pragma checksum"
helpviewer_keywords: 
  - "preprocessor directives [C#]"
  - "keywords [C#], preprocessor directives"
  - "#nullable directive [C#]"
  - "#if directive [C#]"
  - "#else directive [C#]"
  - "#elif directive [C#]"
  - "#endif directive [C#]"
  - "#define directive [C#]"
  - "#undef directive [C#]"
  - "#warning directive [C#]"
  - "#error directive [C#]"
  - "#line directive [C#]"
  - "#region directive [C#]"
  - "#endregion directive [C#]"
  - "#pragma directive [C#]"
  - "#pragma warning [C#]"
  - "#pragma checksum [C#]"
---
# C# preprocessor directives

Although the compiler doesn't have a separate preprocessor, the directives described in this section are processed as if there were one. You use them to help in conditional compilation. Unlike C and C++ directives, you can't use these directives to create macros. A preprocessor directive must be the only instruction on a line.

## Nullable context

The `#nullable` preprocessor directive sets the *nullable annotation context* and *nullable warning context*. This directive controls whether nullable annotations have effect, and whether nullability warnings are given. Each context is either *disabled* or *enabled*.

Both contexts can be specified at the project level (outside of C# source code). The `#nullable` directive controls the annotation and warning contexts and takes precedence over the project-level settings. A directive sets the context(s) it controls until another directive overrides it, or until the end of the source file.

The effect of the directives is as follows:

- `#nullable disable`: Sets the nullable annotation and warning contexts to *disabled*.
- `#nullable enable`: Sets the nullable annotation and warning contexts to *enabled*.
- `#nullable restore`: Restores the nullable annotation and warning contexts to project settings.
- `#nullable disable annotations`: Sets the nullable annotation context to *disabled*.
- `#nullable enable annotations`: Sets the nullable annotation context to *enabled*.
- `#nullable restore annotations`: Restores the nullable annotation context to project settings.
- `#nullable disable warnings`: Sets the nullable warning context to *disabled*.
- `#nullable enable warnings`: Sets the nullable warning context to *enabled*.
- `#nullable restore warnings`: Restores the nullable warning context to project settings.

## Conditional compilation

You use four preprocessor directives to control conditional compilation:

- `#if`: Opens a conditional compilation, where code is compiled only if the specified symbol is defined.
- `#elif`: Closes the preceding conditional compilation and opens a new conditional compilation based on if the specified symbol is defined.
- `#else`: Closes the preceding conditional compilation and opens a new conditional compilation if the previous specified symbol isn't defined.
- `#endif`: Closes the preceding conditional compilation.

When the C# compiler finds an `#if` directive, followed eventually by an `#endif` directive, it compiles the code between the directives only if the specified symbol is defined. Unlike C and C++, you can't assign a numeric value to a symbol. The `#if` statement in C# is Boolean and only tests whether the symbol has been defined or not. For example:

```csharp
#if DEBUG
    Console.WriteLine("Debug version");
#endif
```

You can use the operators [`==` (equality)](operators/equality-operators.md#equality-operator-) and [`!=` (inequality)](operators/equality-operators.md#inequality-operator-) to test for the [`bool`](builtin-types/bool.md) values `true` or `false`. `true` means the symbol is defined. The statement `#if DEBUG` has the same meaning as `#if (DEBUG == true)`. You can use the [`&&` (and)](operators/boolean-logical-operators.md#conditional-logical-and-operator-), [`||` (or)](operators/boolean-logical-operators.md#conditional-logical-or-operator-), and [`!` (not)](operators/boolean-logical-operators.md#logical-negation-operator-) operators to evaluate whether multiple symbols have been defined. You can also group symbols and operators with parentheses.

`#if`, along with the `#else`, `#elif`, `#endif`, `#define`, and `#undef` directives, lets you include or exclude code based on the existence of one or more symbols. Conditional compilation can be useful when compiling code for a debug build or when compiling for a specific configuration.

A conditional directive beginning with an `#if` directive must explicitly be terminated with an `#endif` directive. `#define` lets you define a symbol. By using the symbol as the expression passed to the `#if` directive, the expression evaluates to `true`. You can also define a symbol with the [**DefineConstants**](compiler-options/language.md#defineconstants) compiler option. You can undefine a symbol with `#undef`. The scope of a symbol created with `#define` is the file in which it was defined. A symbol that you define with **DefineConstants** or with `#define` doesn't conflict with a variable of the same name. That is, a variable name shouldn't be passed to a preprocessor directive, and a symbol can only be evaluated by a preprocessor directive.

`#elif` lets you create a compound conditional directive. The `#elif` expression will be evaluated if neither the preceding `#if` nor any preceding, optional, `#elif` directive expressions evaluate to `true`. If an `#elif` expression evaluates to `true`, the compiler evaluates all the code between the `#elif` and the next conditional directive. For example:

```csharp
#define VC7
//...
#if debug
    Console.WriteLine("Debug build");
#elif VC7
    Console.WriteLine("Visual Studio 7");
#endif
```

`#else` lets you create a compound conditional directive, so that, if none of the expressions in the preceding `#if` or (optional) `#elif` directives evaluate to `true`, the compiler will evaluate all code between `#else` and the next `#endif`. `#endif`(#endif) must be the next preprocessor directive after `#else`.

`#endif` specifies the end of a conditional directive, which began with the `#if` directive.

The build system is also aware of predefined preprocessor symbols representing different [target frameworks](../../standard/frameworks.md) in SDK-style projects. They're useful when creating applications that can target more than one .NET version.

[!INCLUDE [Preprocessor symbols](~/includes/preprocessor-symbols.md)]

> [!NOTE]
> For traditional, non-SDK-style projects, you have to manually configure the conditional compilation symbols for the different target frameworks in Visual Studio via the project's properties pages.

Other predefined symbols include the `DEBUG` and `TRACE` constants. You can override the values set for the project using `#define`. The DEBUG symbol, for example, is automatically set depending on your build configuration properties ("Debug" or "Release" mode).

The following example shows you how to define a `MYTEST` symbol on a file and then test the values of the `MYTEST` and `DEBUG` symbols. The output of this example depends on whether you built the project on **Debug** or **Release** configuration mode.

```csharp
#define MYTEST
using System;
public class MyClass
{
    static void Main()
    {
#if (DEBUG && !MYTEST)
        Console.WriteLine("DEBUG is defined");
#elif (!DEBUG && MYTEST)
        Console.WriteLine("MYTEST is defined");
#elif (DEBUG && MYTEST)
        Console.WriteLine("DEBUG and MYTEST are defined");  
#else
        Console.WriteLine("DEBUG and MYTEST are not defined");
#endif
    }
}
```

The following example shows you how to test for different target frameworks so you can use newer APIs when possible:

```csharp
public class MyClass
{
    static void Main()
    {
#if NET40
        WebClient _client = new WebClient();
#else
        HttpClient _client = new HttpClient();
#endif
    }
    //...
}
```

## Defining symbols

You use the following two preprocessor directives to define or undefine symbols for conditional compilation:

- `#define`: Define a symbol.
- `#undef`: Undefine a symbol.

You use `#define` to define a symbol. When you use the symbol as the expression that's passed to the `#if` directive, the expression will evaluate to `true`, as the following example shows:

 ```csharp
 #define VERBOSE

#if VERBOSE
    Console.WriteLine("Verbose output version");
#endif

 ```

> [!NOTE]
> The `#define` directive cannot be used to declare constant values as is typically done in C and C++. Constants in C# are best defined as static members of a class or struct. If you have several such constants, consider creating a separate "Constants" class to hold them.

Symbols can be used to specify conditions for compilation. You can test for the symbol with either `#if` or `#elif`. You can also use the <xref:System.Diagnostics.ConditionalAttribute> to perform conditional compilation. You can define a symbol, but you can't assign a value to a symbol. The `#define` directive must appear in the file before you use any instructions that aren't also preprocessor directives. You can also define a symbol with the [**DefineConstants**](compiler-options/language.md#defineconstants) compiler option. You can undefine a symbol with `#undef`.

## Defining regions

You can define regions of code that can be collapsed in an outline using the following two preprocessor directives:

- `#region`: Start a region.
- `#endregion`: End a region.

`#region` lets you specify a block of code that you can expand or collapse when using the [outlining](/visualstudio/ide/outlining) feature of the code editor. In longer code files, it's convenient to collapse or hide one or more regions so that you can focus on the part of the file that you're currently working on. The following example shows how to define a region:

```csharp
#region MyClass definition
public class MyClass
{
    static void Main()
    {
    }
}
#endregion
```

A `#region` block must be terminated with an `#endregion` directive. A `#region` block can't overlap with an `#if` block. However, a `#region` block can be nested in an `#if` block, and an `#if` block can be nested in a `#region` block.

## Error and warning information

You instruct the compiler to generate user-defined compiler errors and warnings, and control line information using the following directives:

- `#error`: Generate a compiler error with a specified message.
- `#warning`: Generate a compiler warning, with a specific message.
- `#line`: Change the line number printed with compiler messages.

`#error` lets you generate a [CS1029](compiler-messages/cs1029.md) user-defined error from a specific location in your code. For example:

```csharp
#error Deprecated code in this method.
```

> [!NOTE]
> The compiler treats `#error version` in a special way and reports a compiler error, CS8304, with a message containing the used compiler and language versions.

`#warning` lets you generate a [CS1030](../misc/cs1030.md) level one compiler warning from a specific location in your code. For example:

```csharp
#warning Deprecated code in this method.
```

`#line` lets you modify the compiler's line numbering and (optionally) the file name output for errors and warnings.

The following example shows how to report two warnings associated with line numbers. The `#line 200` directive forces the next line's number to be 200 (although the default is #6), and until the next `#line` directive, the filename will be reported as "Special". The `#line default` directive returns the line numbering to its default numbering, which counts the lines that were renumbered by the previous directive.

```csharp
class MainClass
{
    static void Main()
    {
#line 200 "Special"
        int i;
        int j;
#line default
        char c;
        float f;
#line hidden // numbering not affected
        string s;
        double d;
    }
}
```

Compilation produces the following output:

```console
Special(200,13): warning CS0168: The variable 'i' is declared but never used
Special(201,13): warning CS0168: The variable 'j' is declared but never used
MainClass.cs(9,14): warning CS0168: The variable 'c' is declared but never used
MainClass.cs(10,15): warning CS0168: The variable 'f' is declared but never used
MainClass.cs(12,16): warning CS0168: The variable 's' is declared but never used
MainClass.cs(13,16): warning CS0168: The variable 'd' is declared but never used
```

The `#line` directive might be used in an automated, intermediate step in the build process. For example, if lines were removed from the original source code file, but you still wanted the compiler to generate output based on the original line numbering in the file, you could remove lines and then simulate the original line numbering with `#line`.

The `#line hidden` directive hides the successive lines from the debugger, such that when the developer steps through the code, any lines between a `#line hidden` and the next `#line` directive (assuming that it isn't another `#line hidden` directive) will be stepped over. This option can also be used to allow ASP.NET to differentiate between user-defined and machine-generated code. Although ASP.NET is the primary consumer of this feature, it's likely that more source generators will make use of it.

A `#line hidden` directive doesn't affect file names or line numbers in error reporting. That is, if the compiler finds an error in a hidden block, the compiler will report the current file name and line number of the error.

The `#line filename` directive specifies the file name you want to appear in the compiler output. By default, the actual name of the source code file is used. The file name must be in double quotation marks ("") and must be preceded by a line number.

Beginning with C# 10, you can use a new form of the `#line` directive:

```csharp
#line (1, 1) - (5, 60) 10 "partial-class.g.cs"
/*34567*/int b = 0;
```

The components of this form are:

- `(1, 1)`:  The start line and column for the first character on the line that follows the directive. In this example, the next line would be reported as line 1, column 1.
- `(5, 60)`: The end line and column for the marked region.
- `10`: The column offset for the `#line` directive to take effect. In this example, the 10th column would be reported as column one. That's where the declaration `int b = 0;` begins. This field is optional. If omitted, the directive takes effect on the first column.
- `"partial-class.g.cs"`: The name of the output file.

The preceding example would generate the following warning:

```dotnetcli
partial-class.g.cs(1,5,1,6): warning CS0219: The variable 'b' is assigned but its value is never used
```

After remapping, the variable, `b`, is on the first line, at character six.

Domain-specific languages (DSLs) typically use this format to provide a better mapping from the source file to the generated C# output. To see more examples of this format, see the [feature specification](~/_csharplang/proposals/csharp-10.0/enhanced-line-directives.md#examples) in the section on examples.

## Pragmas

`#pragma` gives the compiler special instructions for the compilation of the file in which it appears. The instructions must be supported by the compiler. In other words, you can't use `#pragma` to create custom preprocessing instructions.
  
- [`#pragma warning`](#pragma-warning): Enable or disable warnings.
- [`#pragma checksum`](#pragma-checksum): Generate a checksum.

```csharp
#pragma pragma-name pragma-arguments
```

Where `pragma-name` is the name of a recognized pragma and `pragma-arguments` is the pragma-specific arguments.

### #pragma warning

`#pragma warning` can enable or disable certain warnings.

```csharp
#pragma warning disable warning-list
#pragma warning restore warning-list
```

Where `warning-list` is a comma-separated list of warning numbers. The "CS" prefix is optional. When no warning numbers are specified, `disable` disables all warnings and `restore` enables all warnings.

> [!NOTE]
> To find warning numbers in Visual Studio, build your project and then look for the warning numbers in the **Output** window.

The `disable` takes effect beginning on the next line of the source file. The warning is restored on the line following the `restore`. If there's no `restore` in the file, the warnings are restored to their default state at the first line of any later files in the same compilation.

```csharp
// pragma_warning.cs
using System;

#pragma warning disable 414, CS3021
[CLSCompliant(false)]
public class C
{
    int i = 1;
    static void Main()
    {
    }
}
#pragma warning restore CS3021
[CLSCompliant(false)]  // CS3021
public class D
{
    int i = 1;
    public static void F()
    {
    }
}
```

### #pragma checksum

Generates checksums for source files to aid with debugging ASP.NET pages.

```csharp
#pragma checksum "filename" "{guid}" "checksum bytes"
```

Where `"filename"` is the name of the file that requires monitoring for changes or updates, `"{guid}"` is the Globally Unique Identifier (GUID) for the hash algorithm, and `"checksum_bytes"` is the string of hexadecimal digits representing the bytes of the checksum. Must be an even number of hexadecimal digits. An odd number of digits results in a compile-time warning, and the directive is ignored.

The Visual Studio debugger uses a checksum to make sure  that it always finds the right source. The compiler computes the checksum for a source file, and then emits the output to the program database (PDB) file. The debugger then uses the PDB to compare against the checksum that it computes for the source file.

This solution doesn't work for ASP.NET projects, because the computed checksum is for the generated source file, rather than the .aspx file. To address this problem, `#pragma checksum` provides checksum support for ASP.NET pages.

When you create an ASP.NET project in Visual C#, the generated source file contains a checksum for the .aspx file, from which the source is generated. The compiler then writes this information into the PDB file.

If the compiler doesn't find a `#pragma checksum` directive in the file, it computes the checksum and writes the value to the PDB file.

```csharp
class TestClass
{
    static int Main()
    {
        #pragma checksum "file.cs" "{406EA660-64CF-4C82-B6F0-42D48172A799}" "ab007f1d23d9" // New checksum
    }
}
```
