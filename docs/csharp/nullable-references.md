---
title: Nullable reference types
description: This article provides an overview of nullable reference types, added in C# 8. You'll learn how the feature provides safety against null reference exceptions, for new and existing projects.
ms.date: 12/03/2018
---
# Nullable reference types

C# 8 introduces **nullable reference types** and **non-nullable reference types** that enable you to make important statements about the properties for reference type variables:

- **A reference is not supposed to be null**. When variables aren't supposed to be null, the compiler enforces rules that ensure it is safe to dereference these variables without first checking that it isn't null:
  - The variable must be initialized to a non-null value.
  - The variable can never be assigned the value `null`.
- **A reference may be null**. When variables may be null, the compiler enforces different rules to ensure that you've correctly checked for a null reference:
  - The variable may only be dereferenced when the compiler can guarantee that the value isn't null.
  - These variables may be initialized with the default `null` value and may be assigned the value `null` in other code.

This new feature provides significant benefits over the handling of reference variables in earlier versions of C# where the design intent couldn't be determined from the variable declaration. The compiler didn't provide safety against null reference exceptions for reference types:

- **A reference can be null**. No warnings are issued when a reference type is initialized to null, or later assigned to null.
- **A reference is assumed to be not null**. The compiler doesn't issue any warnings when reference types are dereferenced. (With nullable references,  the compiler issues warnings whenever you dereference a variable that may be null).

A **nullable reference type** is noted using the same syntax as [nullable value types](programming-guide/nullable-types/index.md): a `?` is appended to the type of the variable. For example, the following variable declaration represents a nullable string variable, `name`:

```csharp
string? name;
```

Any variable where the `?` is not appended to the type name is a **non-nullable reference type**. That includes all reference type variables in existing code when you have enabled this feature.

The compiler uses static analysis to determine if a nullable reference is known to be non-null. The compiler warns you if you dereference a nullable reference when it may be null. You can override this behavior by using the **null-forgiving operator** (`!`) following a variable name. For example, if you know the `name` variable isn't null but the compiler issues a warning, you can write the following code to override the compiler's analysis:

```csharp
name!.Length;
```

You can read details about this operator in the [draft nullable reference types](https://github.com/dotnet/csharplang/blob/master/proposals/nullable-reference-types-specification.md#the-null-forgiving-operator) specification proposal on GitHub.

## Nullable contexts

Nullable contexts enable fine-grained control for how the compiler interprets reference type variables. The nullable context of any given source line is `enabled` or `disabled`. You can think of the pre-C# 8 compiler as compiling all your code in a `disabled` nullable context: Any reference type may be null. Warnings are not generated when variables of a reference type are dereferenced.

The nullable context is controlled using a new pragma:

- `#nullable enable` sets the nullable context to enabled.
- `#nullable disable` sets the nullable context to disabled.

The default nullable context is `disabled`. That decision means that your existing code compiles without changes and without generating any new warnings.

The compiler uses the following rules in a disabled nullable context:

- You can't declare nullable references in a disabled context.
- All reference variables may be assigned to null.
- No warnings are generated when a variable of a reference type is dereferenced.
- The null-forgiving operator may not be used in a disabled context.

The behavior is the same as previous versions of C#.

The compiler uses the following rules in an enabled nullable context:

- Any variable of a reference type is a **non-nullable reference type**.
- Any non-nullable reference may be dereferenced safely.
- Any nullable reference type (noted by `?` after the type in the variable declaration) may be null, and must be verified as not null before it can be dereferenced.
- You can use the null-forgiving operator to declare that a nullable reference isn't null.

A richer grammar is proposed for nullable contexts and will be available in future previews. For more information about nullable contexts, see the [nullable reference specification](https://github.com/dotnet/csharplang/blob/master/proposals/nullable-reference-types-specification.md#nullable-contexts) draft.

## Safely reference types by specifying nullable and non-nullable

The compiler uses static analysis to determine the **null state** of any nullable reference. The null state is either **not null** or **maybe null**. If you dereference a nullable reference when the compiler has determined it's **maybe null**, the compiler warns you. The state of a nullable reference is **maybe null** unless the compiler can determine one of two conditions:

1. The variable has been definitely assigned to a non-null value.
1. The variable has been checked against null before de-referencing it.

The compiler enforces that non-nullable references may never be set to the null value. You must initialize them to a non-null value. If you don't, the compiler warns that a non-nullable reference wasn't initialized. The compiler also warns you whenever you assign a non-nullable reference to a value that **maybe null**. That implies you can only assign a non-nullable reference to a nullable reference if that nullable reference is **not null**.

## Learn more

- [Draft Nullable reference specification](https://github.com/dotnet/csharplang/blob/master/proposals/nullable-reference-types-specification.md)
- [Intro to nullable references tutorial](tutorials/nullable-reference-types.md)
