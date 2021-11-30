---
description: "using directive - C# Reference"
title: "using directive - C# Reference"
ms.date: 08/19/2021
f1_keywords: 
  - "using_CSharpKeyword"
helpviewer_keywords:
  - "using directive [C#]"
ms.assetid: b42b8e61-5e7e-439c-bb71-370094b44ae8
---
# using directive

The `using` directive allows you to use types defined in a namespace without specifying the fully qualified namespace of that type. In its basic form, the `using` directive imports all the types from a single namespace, as shown in the following example:

```csharp
using System.Text;
```

You can apply two modifiers to a `using` directive:

- The `global` modifier has the same effect as adding the same `using` directive to every source file in your project. This modifier was introduced in C# 10.
- The `static` modifier imports the `static` members and nested types from a single type rather than importing all the types in a namespace. This modifier was introduced in C# 6.0.

You can combine both modifiers to import the static members from a type in all source files in your project.

You can also create an alias for a namespace or a type with a *using alias directive*.

```csharp
using Project = PC.MyCompany.Project;
```

You can use the `global` modifier on a *using alias directive*.

> [!NOTE]
> The `using` keyword is also used to create *using statements*, which help ensure that <xref:System.IDisposable> objects such as files and fonts are handled correctly. For more information about the *using statement*, see [using Statement](using-statement.md).

The scope of a `using` directive without the `global` modifier is the file in which it appears.

The `using` directive can appear:

- At the beginning of a source code file, before any namespace or type declarations.
- In any namespace, but before any namespaces or types declared in that namespace, unless the `global` modifier is used, in which case the directive must appear before all namespace and type declarations.

Otherwise, compiler error [CS1529](../../misc/cs1529.md) is generated.

Create a `using` directive to use the types in a namespace without having to specify the namespace. A `using` directive doesn't give you access to any namespaces that are nested in the namespace you specify. Namespaces come in two categories: user-defined and system-defined. User-defined namespaces are namespaces defined in your code. For a list of the system-defined namespaces, see [.NET API Browser](../../../../api/index.md).

## global modifier

Adding the `global` modifier to a `using` directive means that using is applied to all files in the compilation (typically a project). The `global using` directive was added in C# 10. Its syntax is:

```csharp
global using <fully-qualified-namespace>;
```

where *fully-qualified-namespace* is the fully qualified name of the namespace whose types can be referenced without specifying the namespace.

A *global using* directive can appear at the beginning of any source code file. All `global using` directives in a single file must appear before:

- All `using` directives without the `global` modifier.
- All namespace and type declarations in the file.

You may add `global using` directives to any source file. Typically, you'll want to keep them in a single location. The order of `global using` directives doesn't matter, either in a single file, or between files.

The `global` modifier may be combined with the `static` modifier. The `global` modifier may be applied to a *using alias directive*. In both cases, the directive's scope is all files in the current compilation. The following example enables using all the methods declared in the <xref:System.Math?displayProperty=fullName> in all files in your project:

```csharp
global using static System.Math;
```

You can also globally include a namespace by adding a `<Using>` item to your project file, for example, `<Using Include="My.Awesome.Namespace" />`. For more information, see [`<Using>` item](../../../core/project-sdk/msbuild-props.md#using).

[!INCLUDE [csharp10-templates](../../../../includes/csharp10-templates.md)]

## static modifier

The `using static` directive names a type whose static members and nested types you can access without specifying a type name. The `using static` directive was introduced in C# 6. Its syntax is:

```csharp
using static <fully-qualified-type-name>;
```

The `<fully-qualified-type-name>` is the name of the type whose static members and nested types can be referenced without specifying a type name. If you don't provide a fully qualified type name (the full namespace name along with the type name), C# generates compiler error [CS0246](../compiler-messages/cs0246.md): "The type or namespace name 'type/namespace' couldn't be found (are you missing a using directive or an assembly reference?)".

The `using static` directive applies to any type that has static members (or nested types), even if it also has instance members. However, instance members can only be invoked through the type instance.

You can access static members of a type without having to qualify the access with the type name:

```csharp
using static System.Console;
using static System.Math;
class Program
{
    static void Main()
    {
        WriteLine(Sqrt(3*3 + 4*4));
    }
}
```

Ordinarily, when you call a static member, you provide the type name along with the member name. Repeatedly entering the same type name to invoke members of the type can result in verbose, obscure code. For example, the following definition of a `Circle` class references many members of the <xref:System.Math> class.

:::code language="csharp" source="./snippets/using-static1.cs" id="Snippet1":::

By eliminating the need to explicitly reference the <xref:System.Math> class each time a member is referenced, the `using static` directive produces cleaner code:

:::code language="csharp" source="./snippets/using-static2.cs":::

`using static` imports only accessible static members and nested types declared in the specified type.  Inherited members aren't imported.  You can import from any named type with a `using static` directive, including Visual Basic modules.  If F# top-level functions appear in metadata as static members of a named type whose name is a valid C# identifier, then the F# functions can be imported.

`using static` makes extension methods declared in the specified type available for extension method lookup.  However, the names of the extension methods aren't imported into scope for unqualified reference in code.

Methods with the same name imported from different types by different `using static` directives in the same compilation unit or namespace form a method group.  Overload resolution within these method groups follows normal C# rules.

The following example uses the `using static` directive to make the static members of the <xref:System.Console>, <xref:System.Math>, and <xref:System.String> classes available without having to specify their type name.

:::code language="csharp" source="./snippets/using-static3.cs" id="Snippet1":::

In the example, the `using static` directive could also have been applied to the <xref:System.Double> type. Adding that directive would make it possible to call the <xref:System.Double.TryParse(System.String,System.Double@)> method without specifying a type name. However, using `TryParse` without a type name creates less readable code, since it becomes necessary to check the `using static` directives to determine which numeric type's `TryParse` method is called.

`using static` also applies to `enum` types.  By adding `using static` with the enum, the type is no longer required to use the enum members.

```csharp
using static Color;

enum Color
{
    Red,
    Green,
    Blue
}

class Program
{
    public static void Main()
    {
        Color color = Green;
    }
}
```

## using alias

Create a `using` alias directive to make it easier to qualify an identifier to a namespace or type. In any `using` directive, the fully qualified namespace or type must be used regardless of the `using` directives that come before it. No `using` alias can be used in the declaration of a `using` directive. For example, the following example generates a compiler error:

```csharp
using s = System.Text;
using s.RegularExpressions; // Generates a compiler error.
```

The following example shows how to define and use a `using` alias for a namespace:

:::code language="csharp" source="./snippets/csrefKeywordsNamespace2.cs" id="Snippet8":::

A using alias directive can't have an open generic type on the right-hand side. For example, you can't create a using alias for a `List<T>`, but you can create one for a `List<int>`.

The following example shows how to define a `using` directive and a `using` alias for a class:

:::code language="csharp" source="./snippets/csrefKeywordsNamespace2.cs" id="Snippet9":::

## How to use the Visual Basic `My` namespace

The <xref:Microsoft.VisualBasic.MyServices> namespace (`My` in Visual Basic) provides easy and intuitive access to a number of .NET classes, enabling you to write code that interacts with the computer, application, settings, resources, and so on. Although originally designed for use with Visual Basic, the `MyServices` namespace can be used in C# applications.

For more information about using the `MyServices` namespace from Visual Basic, see [Development with My](../../../visual-basic/developing-apps/development-with-my/index.md).

You need to add a reference to the *Microsoft.VisualBasic.dll* assembly in your project. Not all the classes in the `MyServices` namespace can be called from a C# application: for example, the <xref:Microsoft.VisualBasic.MyServices.FileSystemProxy> class is not compatible. In this particular case, the static methods that are part of <xref:Microsoft.VisualBasic.FileIO.FileSystem>, which are also contained in VisualBasic.dll, can be used instead. For example, here is how to use one such method to duplicate a directory:

:::code language="csharp" source="./snippets/Namespaces3.cs" id="Snippet20":::

## C# language specification

For more information, see [Using directives](~/_csharplang/spec/namespaces.md#using-directives) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

For more information on the *global using* modifier, see the [global usings feature specification - C# 10](~/_csharplang/proposals/csharp-10.0/GlobalUsingDirective.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Namespaces](../../fundamentals/types/namespaces.md)
- [using Statement](using-statement.md)
