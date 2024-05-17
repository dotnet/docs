---
title: "Static Classes and Static Class Members"
description: Static classes can't be instantiated in C#. You access the members of a static class by using the class name itself.
ms.date: 03/15/2024
helpviewer_keywords:
  - "C# language, static members"
  - "static members [C#]"
  - "static classes [C#]"
  - "C# language, static classes"
  - "static class members [C#]"
ms.assetid: 235614b5-1371-4dbd-9abd-b406a8b0298b
---
# Static Classes and Static Class Members (C# Programming Guide)

A [static](../../language-reference/keywords/static.md) class is basically the same as a non-static class, but there's one difference: a static class can't be instantiated. In other words, you can't use the [new](../../language-reference/operators/new-operator.md) operator to create a variable of the class type. Because there's no instance variable, you access the members of a static class by using the class name itself. For example, if you have a static class that is named `UtilityClass` that has a public static method named `MethodA`, you call the method as shown in the following example:

```csharp
UtilityClass.MethodA();
```

 A static class can be used as a convenient container for sets of methods that just operate on input parameters and don't have to get or set any internal instance fields. For example, in the .NET Class Library, the static <xref:System.Math?displayProperty=nameWithType> class contains methods that perform mathematical operations, without any requirement to store or retrieve data that is unique to a particular instance of the <xref:System.Math> class. That is, you apply the members of the class by specifying the class name and the method name, as shown in the following example.

```csharp
double dub = -3.14;
Console.WriteLine(Math.Abs(dub));
Console.WriteLine(Math.Floor(dub));
Console.WriteLine(Math.Round(Math.Abs(dub)));

// Output:
// 3.14
// -4
// 3
```

 As is the case with all class types, the .NET runtime loads the type information for a static class when the program that references the class is loaded. The program can't specify exactly when the class is loaded. However, it's guaranteed to load and have its fields initialized and its static constructor called before the class is referenced for the first time in your program. A static constructor is only called one time, and a static class remains in memory for the lifetime of the application domain in which your program resides.

> [!NOTE]
> To create a non-static class that allows only one instance of itself to be created, see [Implementing Singleton in C#](/previous-versions/msp-n-p/ff650316(v=pandp.10)).

 The following list provides the main features of a static class:

- Contains only static members.

- Can't be instantiated.

- Is sealed.

- Can't contain [Instance Constructors](./instance-constructors.md).

 Creating a static class is therefore basically the same as creating a class that contains only static members and a private constructor. A private constructor prevents the class from being instantiated. The advantage of using a static class is that the compiler can check to make sure that no instance members are accidentally added. The compiler guarantees that instances of this class can't be created.

 Static classes are sealed and therefore can't be inherited. They can't inherit from any class or interface except <xref:System.Object>. Static classes can't contain an instance constructor. However, they can contain a static constructor. Non-static classes should also define a static constructor if the class contains static members that require non-trivial initialization. For more information, see [Static Constructors](./static-constructors.md).

## Example

 Here's an example of a static class that contains two methods that convert temperature from Celsius to Fahrenheit and from Fahrenheit to Celsius:

 [!code-csharp[TemperatureConverter#1](snippets/static-classes-and-static-class-members/Program.cs#1)]

## Static Members

 A non-static class can contain static methods, fields, properties, or events. The static member is callable on a class even when no instance of the class exists. The static member is always accessed by the class name, not the instance name. Only one copy of a static member exists, regardless of how many instances of the class are created. Static methods and properties can't access non-static fields and events in their containing type, and they can't access an instance variable of any object unless it's explicitly passed in a method parameter.

 It's more typical to declare a non-static class with some static members, than to declare an entire class as static. Two common uses of static fields are to keep a count of the number of objects that are instantiated, or to store a value that must be shared among all instances.

 Static methods can be overloaded but not overridden, because they belong to the class, and not to any instance of the class.

 Although a field can't be declared as `static const`, a [const](../../language-reference/keywords/const.md) field is essentially static in its behavior. It belongs to the type, not to instances of the type. Therefore, `const` fields can be accessed by using the same `ClassName.MemberName` notation used for static fields. No object instance is required.

 C# doesn't support static local variables (that is, variables that are declared in method scope).

 You declare static class members by using the `static` keyword before the return type of the member, as shown in the following example:

 [!code-csharp[AutomobileExample#2](snippets/static-classes-and-static-class-members/Program.cs#2)]

 Static members are initialized before the static member is accessed for the first time and before the static constructor, if there's one, is called. To access a static class member, use the name of the class instead of a variable name to specify the location of the member, as shown in the following example:

 [!code-csharp[AccessingStaticMembers#3](snippets/static-classes-and-static-class-members/Program.cs#3)]

 If your class contains static fields, provide a static constructor that initializes them when the class is loaded.

 A call to a static method generates a call instruction in common intermediate language (CIL), whereas a call to an instance method generates a `callvirt` instruction, which also checks for null object references. However, most of the time the performance difference between the two isn't significant.

## C# Language Specification

For more information, see [Static classes](~/_csharpstandard/standard/classes.md#15224-static-classes), [Static and instance members](~/_csharpstandard/standard/classes.md#1538-static-and-instance-members) and [Static constructors](~/_csharpstandard/standard/classes.md#1512-static-constructors) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [static](../../language-reference/keywords/static.md)
- [Classes](../../fundamentals/types/classes.md)
- [class](../../language-reference/keywords/class.md)
- [Static Constructors](./static-constructors.md)
- [Instance Constructors](./instance-constructors.md)
