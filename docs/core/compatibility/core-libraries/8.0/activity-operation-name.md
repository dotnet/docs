---
title: ".NET 8 breaking change: Activity operation name when null"
description: Learn about the .NET 8 breaking change in core .NET libraries where the operation name of an Activity is stored as an empty string if it's specified as null when the activity is created.
ms.date: 01/26/2023
---
# Activity operation name when null

Starting in .NET 8, if you create an `Activity` object using `null` for the operation name, the operation name will be stored as an empty string (`""`) instead of `null`.

## Previous behavior

Previously, if you created an <xref:System.Diagnostics.Activity> object using a `null` operation name, the operation name inside the activity was stored as `null`.

```csharp
new Activity(operationName: null).OperationName // Value is null.
```

## New behavior

Starting in .NET 8, if you create an <xref:System.Diagnostics.Activity> object using a `null` operation name, the operation name is stored as an empty string.

```csharp
new Activity(operationName: null).OperationName // Value is "".
```

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

A `null` operation name in an <xref:System.Diagnostics.Activity> object can have an undesirable effect on backend trace collectors, which usually assume non-null operation names.
To avoid crashes, trace collectors have to special case `null` operation names inside an <xref:System.Diagnostics.Activity> object. This change removes the special case requirement.

## Recommended action

This change is unlikely to cause breaks as using `null` when creating `Activity` objects is rare. If for any reason your code depended on the `null` value for the operation name, adjust the code to either not use `null` or expect that the operation name will be stored as an empty string when you specify `null`.

## Affected APIs

- <xref:System.Diagnostics.Activity.%23ctor%2A> constructor
- <xref:System.Diagnostics.Activity.OperationName?displayProperty=fullName>
- <xref:System.Diagnostics.ActivitySource.CreateActivity%2A?displayProperty=fullName>
- <xref:System.Diagnostics.ActivitySource.StartActivity%2A?displayProperty=fullName>
