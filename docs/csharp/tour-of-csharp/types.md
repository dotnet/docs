---
title: Define types and their members - A tour of C#
description: The building blocks of programs are types. Learn how to create classes, structs, interfaces, and more in C#.
ms.date: 08/03/2020
---
# Types and members

## Classes and objects

*Classes* are the most fundamental of C#’s types. A class is a data structure that combines state (fields) and actions (methods and other function members) in a single unit. A class provides a definition for dynamically created *instances* of the class, also known as *objects*. Classes support *inheritance* and *polymorphism*, mechanisms whereby *derived classes* can extend and specialize *base classes*.

New classes are created using class declarations. A class declaration starts with a header that specifies the attributes and modifiers of the class, the name of the class, the base class (if given), and the interfaces implemented by the class. The header is followed by the class body, which consists of a list of member declarations written between the delimiters `{` and `}`.

The following code shows a declaration of a simple class named `Point`:

:::code language="csharp" source="./snippets/shared/Types.cs" id="PointClass":::

Instances of classes are created using the `new` operator, which allocates memory for a new instance, invokes a constructor to initialize the instance, and returns a reference to the instance. The following statements create two Point objects and store references to those objects in two variables:

:::code language="csharp" source="./snippets/shared/Types.cs" id="CreatePoints":::

The memory occupied by an object is automatically reclaimed when the object is no longer reachable. It's neither necessary nor possible to explicitly deallocate objects in C#.

### Type parameters

A class definition may specify a set of type parameters by following the class name with angle brackets enclosing a list of type parameter names. The type parameters can then be used in the body of the class declarations to define the members of the class. In the following example, the type parameters of `Pair` are `TFirst` and `TSecond`:

:::code language="csharp" source="./snippets/shared/Types.cs" id="DefinePairClass":::

A class type that is declared to take type parameters is called a *generic class type*. Struct, interface, and delegate types can also be generic.
When the generic class is used, type arguments must be provided for each of the type parameters:

:::code language="csharp" source="./snippets/shared/Types.cs" id="CreatePairObject":::

A generic type with type arguments provided, like `Pair<int,string>` above, is called a *constructed type*.

### Base classes

A class declaration may specify a base class by following the class name and type parameters with a colon and the name of the base class. Omitting a base class specification is the same as deriving from type `object`. In the following example, the base class of `Point3D` is `Point`. From the first example, the base class of `Point` is `object`:

:::code language="csharp" source="./snippets/shared/Types.cs" id="Create3DPoint":::

A class inherits the members of its base class. Inheritance means that a class implicitly contains all members of its base class, except for the instance and static constructors, and the finalizers of the base class. A derived class can add new members to those members it inherits, but it can't remove the definition of an inherited member. In the previous example, `Point3D` inherits the `x` and `y` fields from `Point`, and every `Point3D` instance contains three fields, `x`, `y`, and `z`.

An implicit conversion exists from a class type to any of its base class types. A variable of a class type can reference an instance of that class or an instance of any derived class. For example, given the previous class declarations, a variable of type `Point` can reference either a `Point` or a `Point3D`:

:::code language="csharp" source="./snippets/shared/Types.cs" id="ImplicitCastToBase":::

## Structs

Classes define types that support inheritance and polymorphism. They enable you to create sophisticated behaviors based on hierarchies of derived classes. By contrast, ***struct*** types are simpler types whose primary purpose is to store data values. Structs cannot declare a base type; they implicitly derive from <xref:System.ValueType?displayProperty=nameWithType>. You cannot derive other `struct` types from a `struct` type. They are implicitly sealed.

:::code language="csharp" source="./snippets/shared/Types.cs" id="PointStruct":::

## Interfaces

An ***interface*** defines a contract that can be implemented by classes and structs. An interface can contain methods, properties, events, and indexers. An interface typically doesn't provide implementations of the members it defines—it merely specifies the members that must be supplied by classes or structs that implement the interface.

Interfaces may employ ***multiple inheritance***. In the following example, the interface `IComboBox` inherits from both `ITextBox` and `IListBox`.

:::code language="csharp" source="./snippets/shared/Types.cs" id="FirstInterfaces":::

Classes and structs can implement multiple interfaces. In the following example, the class `EditBox` implements both `IControl` and `IDataBound`.

:::code language="csharp" source="./snippets/shared/Types.cs" id="ImplementInterfaces":::

When a class or struct implements a particular interface, instances of that class or struct can be implicitly converted to that interface type. For example

:::code language="csharp" source="./snippets/shared/Types.cs" id="UseInterfaces":::

## Enums

An ***Enum*** type defines a set of constant values. The following `enum` declares constants that define different root vegetables:

:::code language="csharp" source="./snippets/shared/Types.cs" id="EnumDeclaration":::

You can also define an `enum` be used in combination as flags. THe following declaration declares a set of flags for the four seasons. Any combination of the seasons may be applied, including an `All` value that includes all seasons:

:::code language="csharp" source="./snippets/shared/Types.cs" id="FlagsEnumDeclaration":::

The following example shows declarations of both the preceding enums:

:::code language="csharp" source="./snippets/shared/Types.cs" id="UsingEnums":::

## Nullable types

Variables of any type may be declared as ***non-nullable*** or ***nullable***. A nullable variable can hold an additional `null` value, indicating no value. Nullable Value types (structs or enums) are represented by <xref:System.Nullable%601?displayProperty=nameWithType>. Non-nullable and Nullable Reference types are both represented by the underlying reference type. The distinction is represented by metadata read by the compiler and some libraries. The compiler provides warnings when nullable references are de-referenced without first checking their value against `null`. The compiler also provides warnings when non-nullable references are assigned to a value that may be `null`. The following example declares a ***nullable int***, initializing it to `null`. Then, it sets the value to `5`. It demonstrates the same concept with a ***nullable string***.

:::code language="csharp" source="./snippets/shared/Types.cs" id="DeclareNullable":::

## Tuples

C# supports ***tuples*** which provides concise syntax to group multiple data elements in a lightweight data structure. You instantiate a tuple by declaring the types and names of the members between `(` and `)`, as shown in the following example:

:::code language="csharp" source="./snippets/shared/Types.cs" id="DeclareTuples":::

Tuples provide an alternative when you want a data structure for multiple members, but won't use the building blocks described in the next article.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](program-building-blocks.md)
