---
title: ".NET 7 breaking change: Reflection invoke API exception changes"
description: Learn about the .NET 7 breaking change in core .NET libraries where the exceptions thrown by reflection invoke APIs have changed.
ms.date: 04/29/2022
---
# Changes to reflection invoke API exceptions

The exceptions thrown when calling reflection invoke APIs have changed.

## Previous behavior

- Previously, when an invoked method that [returns a value by reference](../../../../csharp/language-reference/statements/jump-statements.md#ref-returns) returned `null`, a <xref:System.NullReferenceException> was thrown.

- For constructors, the following exceptions were thrown:

  - Transient exceptions, including <xref:System.OutOfMemoryException>.
  - An <xref:System.OverflowException> when a negative value was passed for the length parameter of an array.

- When `null` was passed for a [byref-like](xref:System.Type.IsByRefLike) parameter without the `ref` modifier (that is, passed by value), no exception was thrown, and the runtime substituted a default value for the null value.

## New behavior

Starting in .NET 7:

- Instead of throwing the originating exception (including <xref:System.NullReferenceException> and <xref:System.OutOfMemoryException> mentioned in [Previous behavior](#previous-behavior)), <xref:System.Reflection.TargetInvocationException> is thrown in all cases after the initial `Invoke()` parameters are validated. The inner exception contains the originating exception.

- <xref:System.NotSupportedException> is thrown when `null` is passed for a [byref-like](xref:System.Type.IsByRefLike) parameter when the parameter is declared as being "by value" (that is, it has no `ref` modifier). For the related case when the parameter is passed by reference (that is, it has the `ref` modifier), the previous and new behavior are the same: a <xref:System.NotSupportedException> is thrown.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Throwing <xref:System.Reflection.TargetInvocationException> instead of the originating exception makes the experience more consistent. It properly layers exceptions caused by the validation of the incoming parameters (which aren't wrapped with <xref:System.Reflection.TargetInvocationException>) versus exceptions thrown due to the implementation of the target method (which are wrapped). Consistent rules provide more consistent experiences across different implementations of the CLR and of `Invoke` APIs.

The change to throw <xref:System.NotSupportedException> when a [byref-like type](xref:System.Type.IsByRefLike) is passed to an `Invoke()` API fixes an oversight of the original implementation, which did not throw. The original implementation gave the appearance that `ref struct` types are supported by the `Invoke()` APIs, when they aren't. Since the current `Invoke()` APIs use <xref:System.Object?displayProperty=fullName> for parameter types, and a `ref struct` type can't be boxed to <xref:System.Object?displayProperty=fullName>, it's an unsupported scenario.

## Recommended action

If you don't use <xref:System.Reflection.BindingFlags.DoNotWrapExceptions?displayProperty=nameWithType> when calling `Invoke()`, and you have `catch` statements around the `Invoke()` APIs for exceptions other than <xref:System.Reflection.TargetInvocationException>, consider changing or removing those `catch` statements. The other exceptions will no longer be thrown as a result of the invocation. If, however, you're catching exceptions from argument validation that happens before attempting to invoke the target method, you should keep those `catch` statements. Invalid arguments that are validated before attempting to invoke are thrown without being wrapped with <xref:System.Reflection.TargetInvocationException> and did not change semantics.

Consider using <xref:System.Reflection.BindingFlags.DoNotWrapExceptions?displayProperty=nameWithType> so that <xref:System.Reflection.TargetInvocationException> is never thrown. In this case, the originating exception won't be wrapped by a <xref:System.Reflection.TargetInvocationException>. In most cases, not wrapping the exception improves the chances of the diagnosing the actual issue since not all exception reporting tools display the inner exception. In addition, by using <xref:System.Reflection.BindingFlags.DoNotWrapExceptions?displayProperty=nameWithType>, the same exceptions will be thrown as when calling the method directly (without reflection). This is desirable in most cases, since the choice of whether reflection is used or not can be arbitrary or an implementation detail that does not need to surface to the caller.

In the rare case that you need to pass a default value to a method through reflection that contains a [byref-like](xref:System.Type.IsByRefLike) parameter that's passed "by value", you can add a wrapper method that omits the parameter and calls the target method with a default value for that parameter.

## Affected APIs

- <xref:System.Reflection.MethodBase.Invoke(System.Object,System.Object[])?displayProperty=fullName>
- <xref:System.Reflection.MethodBase.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Reflection.ConstructorInfo.Invoke(System.Object[])?displayProperty=fullName>
- <xref:System.Reflection.ConstructorInfo.Invoke(System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.GetValue(System.Object)?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.GetValue(System.Object,System.Object[])?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.GetValue(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.SetValue(System.Object,System.Object)?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.SetValue(System.Object,System.Object,System.Object[])?displayProperty=fullName>
- <xref:System.Reflection.PropertyInfo.SetValue(System.Object,System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Reflection.Emit.DynamicMethod.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Activator.CreateInstance(System.Type,System.Object[])?displayProperty=fullName>
- <xref:System.Activator.CreateInstance(System.Type,System.Object[],System.Object[])?displayProperty=fullName>
- <xref:System.Activator.CreateInstance(System.Type,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)?displayProperty=fullName>
- <xref:System.Activator.CreateInstance(System.Type,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo,System.Object[])?displayProperty=fullName>
- <xref:System.Activator.CreateInstance(System.String,System.String,System.Boolean,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo,System.Object[])?displayProperty=fullName>
