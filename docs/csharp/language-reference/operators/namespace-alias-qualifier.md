---
title: ":: operator - C# reference"
ms.custom: seodec18
ms.date: 08/09/2019
f1_keywords: 
  - "::_CSharpKeyword"
  - "global_CSharpKeyword"
helpviewer_keywords: 
  - ":: operator [C#]"
  - "namespace alias qualifier [C#]"
  - "namespace [C#]"
  - "global keyword [C#]"
ms.assetid: 698b5a73-85cf-4e0e-9e8e-6496887f8527
---
# :: operator (C# reference)

Use the namespace alias qualifier `::` to access members of an aliased namespace. You use the `::` qualifier between two identifiers. The left-hand identifier can be any of the following aliases:

- A namespace alias created with the [using alias directive](../keywords/using-directive.md):
  
  ```csharp
  using forwinforms = System.Drawing;
  using forwpf = System.Windows;
  
  public class Converters
  {
      public static forwpf::Point Convert(forwinforms::Point point) => new forwpf::Point(point.X, point.Y);
  }
  ```

- An [extern alias](../keywords/extern-alias.md).
- The `global` alias, which is the global namespace alias. The global namespace is the namespace that contains namespaces and types that are not declared inside a named namespace. When used with the `::` qualifier, the `global` alias always references the global namespace, even if there is the user-defined `global` namespace alias.
  
  The following example uses the `global` alias to access the .NET <xref:System> namespace, which is a member of the global namespace. Without the `global` alias, the user-defined `System` namespace, which is a member of the `MyCompany.MyProduct` namespace, would be accessed:

  ```csharp
  namespace MyCompany.MyProduct.System
  {
      class Program
      {
          static void Main() => global::System.Console.WriteLine("Using global alias");
      }
  
      class Console
      {
          string Suggestion => "Consider renaming this class";
      }
  }
  ```
  
  > [!NOTE]
  > The `global` keyword is the global namespace alias only when it's the left-hand identifier of the `::` qualifier.

You can also use the [member access `.` operator](member-access-operators.md#member-access-operator-) to access members of an aliased namespace. However, the `.` operator is also used to access members of a type. The `::` qualifier ensures that its left-hand identifier always references a namespace alias, even if there exists a type or namespace with the same name.

## C# language specification

For more information, see the [Namespace alias qualifiers](~/_csharplang/spec/namespaces.md#namespace-alias-qualifiers) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Using namespaces](../../programming-guide/namespaces/using-namespaces.md)
