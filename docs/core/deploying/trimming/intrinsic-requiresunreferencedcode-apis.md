---
title: Intrinsic APIs marked RequiresUnreferencedCode
description: Learn how the tooling recognizes certain patterns in calls to APIs annotated with RequiresUnreferencedCode.
author: MichalStrehovsky
ms.author: michals
ms.date: 09/13/2024
ms.topic: article
---

# Intrinsic APIs marked RequiresUnreferencedCode

Under normal circumstances, calling APIs annotated with <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> in an app published with trimming triggers warning [IL2026 (Members attributed with RequiresUnreferencedCode may break when trimming)](trim-warnings/il2026.md). APIs that trigger the warning might not behave correctly in a trimmed deployment.

Some APIs annotated `[RequiresUnreferencedCode]` can still be used without triggering the warning if they're called in a specific pattern. When used as part of a pattern, the call to the API can be statically analyzed by the compiler, does not generate a warning, and behaves as expected at run time.

## MethodInfo.MakeGenericMethod(Type[]) method

Calls to this API don't trigger a warning if the generic method definition is statically visible within the calling method body and none of the generic method's generic parameters have the `new()` constraint or `DynamicallyAccessedMembers` attribute. For example, `typeof(SomeType).GetMethod("GenericMethod").MakeGenericMethod(someType)` doesn't generate a warning provided there are no `new()` constraints or `DynamicallyAccessedMembers` annotations on the generic parameters.

If the generic method has parameters with the `new()` constraint or `DynamicallyAccessedMembers` attribute, the generic arguments used with `MakeGenericMethod` need to also be statically visible within the calling method body. Otherwise the warning is issued.

## MethodInfo.MakeGenericType(Type[]) method

Calls to this API don't trigger a warning if the generic type definition is statically visible within the calling method body and none of the generic type's generic parameters have the `new()` constraint or `DynamicallyAccessedMembers` attribute. For example, `typeof(SomeType<>).MakeGenericType(someType)` doesn't generate a warning provided there are no `new()` constraints or `DynamicallyAccessedMembers` annotations on the generic parameters.

If the generic type has parameters with the `new()` constraint or `DynamicallyAccessedMembers` attribute, the generic arguments used with `MakeGenericType` need to also be statically visible within the calling method body. Otherwise the warning is issued.

## RuntimeHelpers.RunClassConstructor(Type) method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `RuntimeHelpers.RunClassConstructor(typeof(string).TypeHandle)` does not trigger a warning, but `RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle)` and `RuntimeHelpers.RunClassConstructor(someTypeHandle)` do.

Additionally, starting with .NET 9, the warning isn't issued when the type handle was loaded from `Type` stored in a location annotated as `DynamicallyAccessedMemberTypes.NonPublicConstructors`. That's because non-public constructors include the static constructor:

```csharp
static void M<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>
    ([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type t)
{
    RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle); // No IL2026 warning
    RuntimeHelpers.RunClassConstructor(t.TypeHandle); // No IL2026 warning
}

```

## Type.GetType overloads

Calls to this API don't trigger a warning if the string parameter is passed as a string literal and case-insensitive search isn't requested. The API also doesn't trigger a warning if a non-literal string is used, but the string was loaded from a location annotated with `[DynamicallyAccessedMembers]`.

```csharp
static void GetTheType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors)] string s)
{
    Type.GetType(s); // No IL2026 warning
}
```
