---
title: "Errors and warnings related to extension declarations"
description: "These errors and warnings indicate that you need to modify the declaration of an extension method using the `this` modifier on the first parameter, or an extension declaration"
ms.date: 05/23/2025
f1_keywords:
  - "CS1100"
  - "CS1101"
  - "CS1102"
  - "CS1103"
  - "CS1105"
  - "CS1106"
  - "CS1109"
  - "CS1110"
  - "CS1112"
  - "CS1113"
helpviewer_keywords: 
  - "CS1100"
  - "CS1101"
  - "CS1102"
  - "CS1103"
  - "CS1105"
  - "CS1106"
  - "CS1109"
  - "CS1110"
  - "CS1112"
  - "CS1113"
---
# Errors and warnings related to extension methods declared with `this` parameters or `extension` blocks

- **CS1112**: *Do not use '<xref:System.Runtime.CompilerServices.ExtensionAttribute>'. Use the '`this`' keyword instead.*

## CS1112

This error is generated when the <xref:System.Runtime.CompilerServices.ExtensionAttribute> is used on a non-static class that contains extension methods. If this attribute is used on a static class, another error, such as CS0708: "Cannot declare instance members in a static class," might occur.

In C#, extension methods must be defined in a static class and the first parameter of the method is modified with the `this` keyword. Do not use the attribute at all in the source code. For more information, see [Extension Methods](../../../programming-guide/classes-and-structs/extension-methods.md). To correct this error remove the attribute and apply the `this` modifier to the first parameter of the method. The following example generates CS1112:

```csharp
// cs1112.cs  
[System.Runtime.CompilerServices.ExtensionAttribute] // CS1112
public class Extensions
{
    public bool A(bool b) { return b; }
}

class A { }
```

## Compiler Error CS1100

Method 'name' has a parameter modifier 'this' which is not on the first parameter. The `this` modifier is allowed only on the first parameter of a method, which indicates to the compiler that the method is an extension method. To correct this error remove the `this` modifier from all except the first parameter of the method. The following code generates CS1100 because a `this` parameter is modifying the second parameter:

```csharp
// cs1100.cs
static class Test
{
    static void ExtMethod(int i, this Test c) // CS1100
    {
    }
}
```

## Compiler Error CS1101

The parameter modifier 'ref' cannot be used with 'this'.

When the `this` keyword modifies the first parameter of a static method, it signals to the compiler that the method is an extension method. With C# version 7.1 and below, no other modifiers are needed or allowed on the first parameter of an extension method. Since C# version 7.2, `ref` extension methods are allowed, take a look at [extension methods](../programming-guide/classes-and-structs/extension-methods.md) for more details. The following example generates CS1101:

```csharp
// cs1101.cs
// Compile with: /target:library
public static class Extensions
{
    public static void Test(ref this int i) {} // CS1101
}
```

## Compiler Error CS1102

The parameter modifier 'out' cannot be used with 'this'.

When the `this` keyword modifies the first parameter of a static method, it signals to the compiler that the method is an extension method. No other modifiers are needed or allowed on the first parameter of an extension method.

To correct this error remove the unauthorized modifiers from the first parameter. The following example generates CS1102:

```csharp
// cs1102.cs
// Compile with: /target:library.
public static class Extensions
{
    // No type parameters.
        public static void Test(this out int i) {} // CS1102

    //Single type parameter
        public static void Test<T>(this out T t) {}// CS1102

    //Multiple type parameters
        public static void Test<T,U,V>(this out U u) {}// CS1102
}
```

## Compiler Error CS1103

The first parameter of an extension method cannot be of type 'type'.

The first parameter of an extension method cannot be a pointer type. The following example generates CS1103:

```csharp
// cs1103.cs
public static class Extensions
{
    public unsafe static char* Test(this char* charP) { return charP; } // CS1103
}
```

## Compiler Error CS1105

Extension methods must be static.

Extension methods must be declared as static methods in a non-generic static class. The following example generates CS1105 because `Test` is not static:

```csharp
// cs1105.cs
// Compile with: /target:library
public class Extensions
{
  
    // Single type parameter.
        public void Test<T>(this System.String s) {} //CS1105

}
```  

## Compiler Error CS1106

Extension methods must be defined in a non generic static class.

Extension methods must be defined as static methods in a non-generic static class. The following example generates CS1106:

```csharp
// CS1106.cs
public class NonStaticClass // CS1106
{
    public static void ExtensionMethod1(this int num) {}
}

public static class StaticGenericClass<T> // CS1106
{
    public static void ExtensionMethod2(this int num) {}
}

public static class StaticClass // OK
{
    public static void ExtensionMethod3(this int num) {}
}
```

## Compiler Error CS1109

Extension Methods must be defined on top level static classes, 'name' is a nested class.

Extension methods cannot be defined in nested classes. The following example generates CS1109 because the class `Extension` is nested inside the class `Out`:

```csharp
// cs1109.cs
public class Test
{
}
static class Out
{
    static class Extension
    {
        static void ExtMethod(this Test c) // CS1109
        {
        }
    }
}
```  

## Compiler Error CS1110

Cannot use 'this' modifier on first parameter of method declaration without a reference to System.Core.dll. Add a reference to System.Core.dll or remove 'this' modifier from the method declaration.

Extension methods are supported on version 3.5 and later of .NET Framework. Extension methods generate metadata which marks the method with an attribute. The attribute class is in system.core.dll. To correct this error, as the message states, add a reference to System.Core.dll or remove the `this` modifier from the method declaration. The following example generates CS1110 if the file is not compiled with a reference to System.Core.dll:

```csharp
// cs1110.cs
// CS1110
// Compile with: /target:library
public static class Extensions
{
    public static bool Test(this bool b) { return b; }
}
```

## Compiler Error CS1113

Extension methods 'name' defined on value type 'name' cannot be used to create delegates.

Extension methods that are defined for class types can be used to create delegates. Extension methods that are defined for value types cannot. To correct this error, associate the extension method with a class type or make the method a regular method on the struct.

The following example generates CS1113:

```csharp
// cs1113.cs
using System;
public static class Extensions
{
    public static S ExtMethod(this S s)
    {
        return s;
    }
}

public struct S
{
}

public class Test
{
    static int Main()
    {
        Func<S> f = new S().ExtMethod; // CS1113
        return 1;
    }
}
```
