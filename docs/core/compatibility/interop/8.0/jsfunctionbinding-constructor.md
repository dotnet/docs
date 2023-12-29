---
title: "Breaking change: JSFunctionBinding implicit public default constructor removed"
description: Learn about the breaking change in interop in .NET 8 where the implicit public default constructor for System.Runtime.InteropServices.JavaScript.JSFunctionBinding was removed.
ms.date: 11/02/2023
---
# JSFunctionBinding implicit public default constructor removed

The implicit public default constructor for `System.Runtime.InteropServices.JavaScript.JSFunctionBinding` has been removed.

## Previous behavior

Previously, you could create empty instances of `System.Runtime.InteropServices.JavaScript.JSFunctionBinding`.

## New behavior

Starting in .NET 8, you can't instantiate a `System.Runtime.InteropServices.JavaScript.JSFunctionBinding` object.

## Version introduced

.NET 8

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The constructor was not intended to be public; this change fixes the mistake.

## Recommended action

N/A

## Affected APIs

- `System.Runtime.InteropServices.JavaScript.JSFunctionBinding.#ctor`
