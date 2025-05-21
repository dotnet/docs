---
title: "Breaking change: CreateObjectFlags.Unwrap only unwraps on target instance"
description: Learn about the breaking change in interop in .NET 8 where 'GetOrCreateObjectForComInstance()' with the 'CreateObjectFlags.Unwrap' flag only unwraps wrappers from the target 'ComWrappers' instance.
ms.date: 06/12/2023
ms.topic: concept-article
---
# CreateObjectFlags.Unwrap only unwraps on target instance

Previously, if you called <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)?displayProperty=fullName?displayProperty=nameWithType> on a <xref:System.Runtime.InteropServices.ComWrappers> instance with the <xref:System.Runtime.InteropServices.CreateObjectFlags.Unwrap?displayProperty=nameWithType> flag, a managed object wrapper was unwrapped from *any* <xref:System.Runtime.InteropServices.ComWrappers> instance. Now when the flag is specified, only wrappers from the <xref:System.Runtime.InteropServices.ComWrappers> instance that `GetOrCreateObjectFromComInstance` was called on are unwrapped.

The <xref:System.Runtime.InteropServices.CreateObjectFlags.Unwrap> flag was the only API that reached "across" <xref:System.Runtime.InteropServices.ComWrappers> instances, so its behavior was unintuitive. Additionally, the new <xref:System.Runtime.InteropServices.ComWrappers.TryGetObject(System.IntPtr,System.Object@)?displayProperty=nameWithType> API is available to unwrap a COM object from any <xref:System.Runtime.InteropServices.ComWrappers> instance.

## Previous behavior

Calling <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)> on a <xref:System.Runtime.InteropServices.ComWrappers> instance with the <xref:System.Runtime.InteropServices.CreateObjectFlags.Unwrap?displayProperty=nameWithType> flag unwrapped a managed object wrapper from any <xref:System.Runtime.InteropServices.ComWrappers> instance.

## New behavior

Calling <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)> on a <xref:System.Runtime.InteropServices.ComWrappers> instance with the <xref:System.Runtime.InteropServices.CreateObjectFlags.Unwrap?displayProperty=nameWithType> flag only unwraps a managed object wrapper from the <xref:System.Runtime.InteropServices.ComWrappers> instance that `GetOrCreateObjectForComInstance` was called on. If given a wrapper from a different <xref:System.Runtime.InteropServices.ComWrappers> instance, the `ComWrappers` instance creates a new wrapper.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was unintuitive. It also broke the encapsulation experience where developers can define how COM interop works for their code by using their own custom <xref:System.Runtime.InteropServices.ComWrappers> instances.

## Recommended action

If you want to keep the previous behavior, call <xref:System.Runtime.InteropServices.ComWrappers.TryGetObject(System.IntPtr,System.Object@)?displayProperty=nameWithType> before calling <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)>.

## Affected APIs

- <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)?displayProperty=fullName>
