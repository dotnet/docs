---
title: Intrinsic APIs marked RequiresDynamicCode
description: Learn how the tooling recognizes certain patterns in calls to APIs annotated with RequiresDynamicCode.
author: MichalStrehovsky
ms.author: michals
ms.date: 09/09/2024
---

# Intrinsic APIs marked RequiresDynamicCode

Under normal circumstances, calling APIs annotated with <xref:System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute> in an app published with native AOT triggers warning [IL3050 (Avoid calling members annotated with 'RequiresDynamicCodeAttribute' when publishing as native AOT)](warnings/il3050.md). APIs that trigger the warning might not behave correctly after AOT compilation.

Some APIs annotated RequiresDynamicCode can still be used without triggering the warning when called in a specific pattern. When used as part of a pattern, the call to the API can be statically analyzed by the compiler, does not generate a warning, and behaves as expected at run time.

## Enum.GetValues(Type) Method

Calls to this API don't trigger a warning if the concrete enum type is statically visible in the calling method body. For example, `Enum.GetValues(typeof(AttributeTargets))` does not trigger a warning, but `Enum.GetValues(typeof(T))` and `Enum.GetValues(someType)` do.

## Marshal.DestroyStructure(IntPtr, Type) Method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `Marshal.DestroyStructure(offs, typeof(bool))` does not trigger a warning, but `Marshal.DestroyStructure(offs, typeof(T))` and `Marshal.DestroyStructure(offs, someType)` do.

## Marshal.GetDelegateForFunctionPointer(IntPtr, Type) Method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `Marshal.GetDelegateForFunctionPointer(ptr, typeof(bool))` does not trigger a warning, but `Marshal.GetDelegateForFunctionPointer(ptr, typeof(T))` and `Marshal.GetDelegateForFunctionPointer(ptr, someType)` do.

## Marshal.OffsetOf(Type, String) Method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `Marshal.OffsetOf(typeof(Point), someField)` does not trigger a warning, but `Marshal.OffsetOf(typeof(T), someField)` and `Marshal.OffsetOf(someType, someField)` do.

## Marshal.PtrToStructure(IntPtr, Type) Method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `Marshal.PtrToStructure(offs, typeof(bool))` does not trigger a warning, but `Marshal.PtrToStructure(offs, typeof(T))` and `Marshal.PtrToStructure(offs, someType)` do.

## Marshal.SizeOf(Type) Method

Calls to this API don't trigger a warning if the concrete type is statically visible in the calling method body. For example, `Marshal.SizeOf(typeof(bool))` does not trigger a warning, but `Marshal.SizeOf(typeof(T))` and `Marshal.SizeOf(someType)` do.

## MethodInfo.MakeGenericMethod(Type[]) Method (.NET 9+)

Calls to this API don't trigger a warning if both the generic method definition and the instantiation arguments are statically visible within the calling method body. For example, `typeof(SomeType).GetMethod("GenericMethod").MakeGenericMethod(typeof(int))`. It's also possible to use a generic parameter as the argument: `typeof(SomeType).GetMethod("GenericMethod").MakeGenericMethod(typeof(T))` also doesn't warn.

If the generic type definition is statically visible within the calling method body and all the generic parameters of it are constrained to be a class, the call also doesn't trigger the IL3050 warning. In this case, the arguments don't have to be statically visible. For example:

```csharp
// No IL3050 warning on MakeGenericMethod because T is constrained to be class
typeof(SomeType).GetMethod("GenericMethod").MakeGenericMethod(Type.GetType(Console.ReadLine()));
class SomeType
{
    public void GenericMethod<T>() where T : class { }
}
```

All the other cases, such as `someMethod.MakeGenericMethod(typeof(int))` or `typeof(SomeType).GetMethod("GenericMethod").MakeGenericMethod(someType)` where `someType` has an unknown value, trigger a warning.

## Type.MakeGenericType(Type[]) Method (.NET 9+)

Calls to this API don't trigger a warning if both the generic type definition and the instantiation arguments are statically visible within the calling method body. For example, `typeof(List<>).MakeGenericType(typeof(int))`. It's also possible to use a generic parameter as the argument: `typeof(List<>).MakeGenericType(typeof(T))` also doesn't warn.

If the generic type definition is statically visible within the calling method body and all the generic parameters of it are constrained to be a class, the call also doesn't trigger the IL3050 warning. In this case, the arguments don't have to be statically visible. For example:

```csharp
// No IL3050 warning on MakeGenericType because T is constrained to be class
typeof(Generic<>).MakeGenericType(Type.GetType(Console.ReadLine()));
class Generic<T> where T : class { }
```

All the other cases, such as `someType.MakeGenericType(typeof(int))` or `typeof(List<>).MakeGenericType(someType)` where `someType` has an unknown value, trigger a warning.
