---
title: "Resolve errors using delegates and function pointers"
description: "This article helps you diagnose and correct compiler errors and warnings related to delegate and function pointer declarations and uses"
f1_keywords:
  - "CS0059"
  - "CS0123"
  - "CS0148"
  - "CS0410"
  - "CS0644"
  - "CS1599"
  - "CS1958"
  - "CS8755"
  - "CS8756"
  - "CS8757"
  - "CS8758"
  - "CS8759"
  - "CS8786"
  - "CS8787"
  - "CS8788"
  - "CS8789"
  - "CS8806"
  - "CS8807"
  - "CS8808"
  - "CS8809"
  - "CS8811"
  - "CS8909"
  - "CS8911"
helpviewer_keywords:
  - "CS0059"
  - "CS0123"
  - "CS0148"
  - "CS0410"
  - "CS0644"
  - "CS1599"
  - "CS1958"
  - "CS8755"
  - "CS8756"
  - "CS8757"
  - "CS8758"
  - "CS8759"
  - "CS8786"
  - "CS8787"
  - "CS8788"
  - "CS8789"
  - "CS8806"
  - "CS8807"
  - "CS8808"
  - "CS8809"
  - "CS8811"
  - "CS8909"
  - "CS8911"
ms.date: 04/27/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for delegate and function pointers

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0059**](#delegate-signature-mismatches): *Inconsistent accessibility: parameter type 'type' is less accessible than delegate 'delegate'.*
- [**CS0123**](#delegate-signature-mismatches): *No overload for 'method' matches delegate 'delegate'.*
- [**CS0148**](#delegate-signature-mismatches): *The delegate 'delegate' does not have a valid constructor.*
- [**CS0410**](#delegate-signature-mismatches): *No overload for 'method' has the correct parameter and return types.*
- [**CS0644**](#delegate-type-restrictions): *'class' cannot derive from special class 'class'.*
- [**CS1599**](#delegate-type-restrictions): *The return type of a method, delegate, or function pointer cannot be 'type'.*
- [**CS1958**](#delegate-type-restrictions): *Object and collection initializer expressions may not be applied to a delegate creation expression.*
- [**CS8755**](#function-pointer-signature-mismatches): *'modifier' cannot be used as a modifier on a function pointer parameter.*
- [**CS8756**](#function-pointer-signature-mismatches): *Function pointer 'type' does not take 'count' arguments.*
- [**CS8757**](#function-pointer-signature-mismatches): *No overload for 'method' matches function pointer 'type'.*
- [**CS8758**](#function-pointer-signature-mismatches): *Ref mismatch between 'method' and function pointer 'type'.*
- [**CS8759**](#function-pointer-signature-mismatches): *Cannot create a function pointer for 'method' because it is not a static method.*
- [**CS8786**](#function-pointer-calling-conventions-and-return-types): *Calling convention of 'convention' is not compatible with 'convention'.*
- [**CS8787**](#function-pointer-signature-mismatches): *Cannot convert method group to function pointer. (Are you missing a '&'?)*
- [**CS8788**](#function-pointer-signature-mismatches): *Cannot use an extension method with a receiver as the target of a '&' operator.*
- [**CS8789**](#function-pointer-usage-restrictions): *The type of a local declared in a fixed statement cannot be a function pointer type.*
- [**CS8806**](#function-pointer-calling-conventions-and-return-types): *The calling convention of 'convention' is not supported by the language.*
- [**CS8807**](#function-pointer-calling-conventions-and-return-types): *'specifier' is not a valid calling convention specifier for a function pointer.*
- [**CS8808**](#function-pointer-calling-conventions-and-return-types): *'modifier' is not a valid function pointer return type modifier. Valid modifiers are 'ref' and 'ref readonly'.*
- [**CS8809**](#function-pointer-calling-conventions-and-return-types): *A return type can only have one 'modifier' modifier.*
- [**CS8811**](#function-pointer-signature-mismatches): *Cannot convert &method group 'method' to delegate type 'type'.*
- [**CS8909**](#function-pointer-usage-restrictions): *Comparison of function pointers might yield an unexpected result, since pointers to the same function may be distinct.*
- [**CS8911**](#function-pointer-usage-restrictions): *Using a function pointer type in this context is not supported.*

## Delegate signature mismatches

- **CS0059**: *Inconsistent accessibility: parameter type 'type' is less accessible than delegate 'delegate'.*
- **CS0123**: *No overload for 'method' matches delegate 'delegate'.*
- **CS0148**: *The delegate 'delegate' does not have a valid constructor.*
- **CS0410**: *No overload for 'method' has the correct parameter and return types.*

When you create or assign a delegate, the compiler verifies that the target method's signature matches the delegate type's declaration. The signature includes the parameter types, return type, and accessibility. For the full rules, see [Delegates](../../programming-guide/delegates/index.md) and [Accessibility constraints](~/_csharpstandard/standard/basic-concepts.md#755-accessibility-constraints) in the C# specification.

- Change all parameter types in the delegate declaration to types that are at least as accessible as the delegate itself (**CS0059**). A `public` delegate can't reference a less-accessible type in its parameter list because callers outside the assembly wouldn't be able to provide the argument. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).
- Adjust either the method signature or the delegate signature so the parameter types and return type match exactly (**CS0123**). The compiler requires an exact signature match when you assign a method to a delegate.
- Verify that the delegate was compiled by a conformant compiler (**CS0148**). This error occurs when you import a managed assembly built by a compiler that produced an ill-formed delegate constructor. Recompile the assembly with a standards-compliant compiler to resolve the error.

> [!NOTE]
> **CS0410** is no longer produced by the current C# compiler. The same condition now produces CS0123 instead. Older assemblies compiled with earlier compilers might still reference this error code.

**CS0148** is a build-only diagnostic:

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

## Delegate type restrictions

- **CS0644**: *'class' cannot derive from special class 'class'.*
- **CS1599**: *The return type of a method, delegate, or function pointer cannot be 'type'.*
- **CS1958**: *Object and collection initializer expressions may not be applied to a delegate creation expression.*

The C# language restricts how you can use certain special types, including `System.Delegate`. For the full rules on delegate declarations, see [Delegates](../../programming-guide/delegates/index.md) and [Delegates](~/_csharpstandard/standard/delegates.md) in the C# specification.

- Remove the explicit base class and use a `delegate` declaration instead (**CS0644**). Classes can't explicitly inherit from `System.Delegate`, `System.Enum`, `System.ValueType`, or `System.Array`. The compiler uses these types as implicit base classes. For example, every `delegate` declaration implicitly derives from `System.Delegate`.
- Change the return type to a type that's permitted as a return value (**CS1599**). Certain types in the .NET class library, such as <xref:System.TypedReference>, <xref:System.RuntimeArgumentHandle>, and <xref:System.ArgIterator>, can't be used as return types for methods, delegates, or function pointers because they can potentially enable unsafe stack operations.
- Remove the braces after the delegate creation expression (**CS1958**). Delegates don't have members that you can set through object or collection initializer syntax. If you have `{ }` after a `new DelegateType(method)` expression, remove the braces.

## Function pointer signature mismatches

- **CS8755**: *'modifier' cannot be used as a modifier on a function pointer parameter.*
- **CS8756**: *Function pointer 'type' does not take 'count' arguments.*
- **CS8757**: *No overload for 'method' matches function pointer 'type'.*
- **CS8758**: *Ref mismatch between 'method' and function pointer 'type'.*
- **CS8759**: *Cannot create a function pointer for 'method' because it is not a static method.*
- **CS8787**: *Cannot convert method group to function pointer. (Are you missing a '&'?)*
- **CS8788**: *Cannot use an extension method with a receiver as the target of a '&' operator.*
- **CS8811**: *Cannot convert &method group 'method' to delegate type 'type'.*

When you assign a method to a function pointer by using the address-of (`&`) operator, the compiler checks that the method's signature matches the function pointer type. For the full rules on function pointer declarations and usage, see [Function pointers](../unsafe-code.md#function-pointers) and [Unsafe code](../unsafe-code.md).

- Remove the unsupported modifier from the function pointer parameter (**CS8755**). Function pointer parameters support only `ref`, `out`, and `in` modifiers. Other parameter modifiers, such as `params`, aren't valid in function pointer type declarations.
- Change the number of arguments at the call site to match the function pointer's parameter count (**CS8756**). The function pointer type defines a fixed number of parameters, and you must pass exactly that many arguments.
- Adjust the method's signature so its parameter types, return type, and parameter count match the function pointer type (**CS8757**). Unlike delegates, function pointers don't support implicit conversions between compatible method signatures. The match must be exact.
- Align the `ref`, `out`, or `in` modifiers between the method's parameters and the function pointer type's parameters (**CS8758**). Each parameter's ref kind must match exactly. A `ref` parameter can't satisfy an `in` or `out` position in the function pointer type.
- Change the target method to `static` (**CS8759**). Function pointers can only point to static methods because they represent raw function addresses without an associated object instance.
- Add the `&` operator before the method group when assigning to a function pointer (**CS8787**). Unlike delegates, function pointers require the explicit address-of operator: `delegate*<void> ptr = &MyMethod;`.
- Use a static method instead of an extension method with a receiver (**CS8788**). The `&` operator requires a direct method reference. Extension methods called on an instance have an implicit receiver that can't be captured in a function pointer.
- Remove the `&` operator and use delegate syntax instead, or change the target type from a delegate to a function pointer (**CS8811**). The `&` operator produces a function pointer, not a delegate. To assign a method group to a delegate type, omit the `&` and use standard delegate creation syntax.

## Function pointer calling conventions and return types

- **CS8786**: *Calling convention of 'convention' is not compatible with 'convention'.*
- **CS8806**: *The calling convention of 'convention' is not supported by the language.*
- **CS8807**: *'specifier' is not a valid calling convention specifier for a function pointer.*
- **CS8808**: *'modifier' is not a valid function pointer return type modifier. Valid modifiers are 'ref' and 'ref readonly'.*
- **CS8809**: *A return type can only have one 'modifier' modifier.*

Function pointer declarations include a calling convention and optional return type modifiers. The compiler validates these options. For the full rules, see [Function pointers](../unsafe-code.md#function-pointers).

- Change either the method's calling convention or the function pointer type's calling convention so they match (**CS8786**). When you assign a method to a function pointer, the calling conventions must be compatible. For example, a method using `Cdecl` can't be assigned to a function pointer declared with `Stdcall`.
- Use a supported calling convention in the function pointer declaration (**CS8806**). The language supports `managed` and `unmanaged`. For a specific unmanaged convention, use the `unmanaged` keyword with the convention in square brackets, such as `unmanaged[Cdecl]`, `unmanaged[Stdcall]`, `unmanaged[Thiscall]`, or `unmanaged[Fastcall]`.
- Replace the invalid specifier with a supported calling convention (**CS8807**). Use `managed`, `unmanaged`, or `unmanaged` with a calling convention type in square brackets (for example, `unmanaged[Cdecl]`).
- Use only `ref` or `ref readonly` as the return type modifier (**CS8808**). Other modifiers, such as `out` or `in`, aren't valid for function pointer return types.
- Remove the duplicate return type modifier so only one `ref` or `ref readonly` appears (**CS8809**). The compiler allows at most one return type modifier on a function pointer declaration.

## Function pointer usage restrictions

- **CS8789**: *The type of a local declared in a fixed statement cannot be a function pointer type.*
- **CS8909**: *Comparison of function pointers might yield an unexpected result, since pointers to the same function may be distinct.*
- **CS8911**: *Using a function pointer type in this context is not supported.*

The compiler restricts how function pointer types can be used in certain contexts. For the full rules, see [Function pointers](../unsafe-code.md#function-pointers).

- Change the local variable type in the `fixed` statement to a data pointer type instead of a function pointer type (**CS8789**). The `fixed` statement pins managed objects in memory for data access. Function pointers represent code addresses, not data, and can't be pinned.
- Avoid comparing function pointers for equality (**CS8909**). This warning indicates that comparing function pointers with `==` or `!=` might produce unexpected results. The runtime might return different pointers for the same function due to implementation details such as thunking or JIT compilation. To suppress the warning when you confirm the comparison is intentional, use `#pragma warning disable CS8909`.
- Move the function pointer usage to a supported context (**CS8911**). Function pointer types can't be used in certain positions, such as attribute arguments or `typeof` expressions. Restructure the code to avoid using function pointer types in unsupported contexts.
