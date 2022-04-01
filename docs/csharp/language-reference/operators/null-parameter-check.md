---
title: "!! (null validation) operator - C# reference"
description: "Learn about simplified null-parameter checks. This operator instructs the compiler to add runtime checks that the argument used for a parameter isn't null."
ms.date: 03/30/2022
helpviewer_keywords:
  - "null-forgiving operator [C#]"
  - "!! operator [C#]"
---
# !! (null validation) operator (C# reference)

The `!!` operator, introduced in C# 11, provides null validation parameter syntax. Adding `!!` to a parameter declaration instructs the compiler to add a runtime check for that parameter. For example:

``` csharp
void Method(string name!!)
{
    // ...
}
```

generates code similar to the following example:

``` csharp
void Method(string name) 
{
    if (name is null)
    {
        throw new ArgumentNullException(nameof(name));
    }
    // ...
}
```

Multiple annotated parameters are checked in the order declared on the method. For example, the following code:

``` csharp
void Method(string firstName!!, string lastName!!, string? nickName, string message)
{
    // ...
}
```

generates code similar to the following example:

```csharp
void Method(string firstName, string lastName, string nickName, string message) 
{
    if (firstName is null)
    {
        throw new ArgumentNullException(nameof(firstName));
    }
    if (lastName is null)
    {
        throw new ArgumentNullException(nameof(lastName));
    }
    // ...
}
```

It's intended for library authors to provide runtime checks even when APIs have been annotated for nullable reference types. Some libraries support projects that aren't nullable enabled. Some projects support multiple versions including some that predate nullable reference types. These checks can simplify the necessary validation. You should only add the `!!` operator on those parameters that require a null-check for safety. In the preceding example, the `message` parameter doesn't have a runtime null check.

There are a few rules that govern where you can add the `!!` operator on a parameter declaration:

- The `!!` operator directs the compiler to add runtime behavior. It can't be applied to a declaration without an implementation. You can't add `!!` to the parameter of an abstract member, an interface method without an implementation, or a parameter on a delegate type declaration.
- The parameter type must be a type that can be compared to `null`. For example, the parameter can't be a non-nullable value type. If the parameter is a type parameter, it can't be constrained to be a non-nullable type (for example the `struct`, `notnull`, and `unmanaged` constraints are disallowed.)

In almost all cases, the code the compiler generates for `!!` on an argument is consistent with the preceding example. However, the null check is inserted before any code you write in the method. The compiler generated null-check in constructors appears before the compiler generated calls to field initializers and before the call to any other constructor or base constructor. You can't catch the <xref:System.ArgumentNullException?displayProperty=nameWithType> thrown by the null check added by the compiler.

## Null parameter checks and nullable types

With null state analysis, any parameter annotated with `!!` has an initial null state of *not null*. The compiler has already added a null check. The compiler generates a warning when you write a method where a parameter is nullable and you've added a null check. Consider the following example:

```csharp
void Method(string? name!!)
{
    // ...
}
```

The compiler issues the warning *"Nullable type 'string?' is null-checked and will throw if null."* The signature indicates that the method should accept `null` as the argument for `name`, and yet throws when that argument is supplied.

This feature is intended for library authors whose libraries will be used by code that may not enable nullable reference types. When all components are compiled in a nullable enabled context, the need for extra null parameter checks is reduced, and may not be needed at all. However, when consumers may not have enabled nullable reference types, that code may call methods with null arguments. You can add the runtime checks to improve the resilience of your code. The `!!` syntax makes those extra checks more concise.
