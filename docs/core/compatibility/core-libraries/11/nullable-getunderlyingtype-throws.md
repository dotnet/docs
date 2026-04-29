---
title: "Breaking change: Nullable.GetUnderlyingType throws for custom Type subclasses"
description: "Learn about the breaking change in .NET 11 where Nullable.GetUnderlyingType throws NotSupportedException for custom Type subclasses that don't override Type.GetNullableUnderlyingType."
ms.date: 04/29/2026
ai-usage: ai-assisted
---

# Nullable.GetUnderlyingType throws for custom Type subclasses

<xref:System.Nullable.GetUnderlyingType(System.Type)?displayProperty=nameWithType> now forwards to the new virtual method `System.Type.GetNullableUnderlyingType()`. Custom <xref:System.Type> subclasses that don't override this new virtual throw <xref:System.NotSupportedException> instead of returning `null`.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, `Nullable.GetUnderlyingType` only recognized the `Nullable<T>` provided by the currently executing runtime. For types from other reflection universes, including custom `Type` subclasses, it typically returned `null` even if they represented `Nullable<T>`.

```csharp
class MyType : Type { /* ... */ }

Type t = new MyType();
Type? u = Nullable.GetUnderlyingType(t); // returned null
```

## New behavior

Starting in .NET 11, `Nullable.GetUnderlyingType` calls the new virtual `Type.GetNullableUnderlyingType`. The base implementation on `System.Type` throws <xref:System.NotSupportedException>, so custom `Type` subclasses that don't override the virtual throw:

```csharp
class MyType : Type { /* does not override GetNullableUnderlyingType */ }

Type t = new MyType();
Type? u = Nullable.GetUnderlyingType(t);
// throws System.NotSupportedException:
//   "Derived classes must provide an implementation."
```

The `Type` subclasses shipped with .NET (runtime `Type` implementation, `TypeDelegator`, `TypeBuilder`, `EnumBuilder`, `GenericTypeParameterBuilder`, `TypeBuilderInstantiation`, `SymbolType`, `ModifiedType`, the `SignatureType` family, and the `MetadataLoadContext` types) all override the new virtual and are unaffected.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

`Nullable.GetUnderlyingType` previously hard-coded a comparison against the runtime's `typeof(Nullable<>)`. That comparison produced incorrect results for `Type` subclasses that represent types from a different reflection universe. Most notably, in `MetadataLoadContext`, `Nullable<T>` was always reported as a non-nullable type (see [dotnet/runtime#124216](https://github.com/dotnet/runtime/issues/124216)). The new virtual gives each `Type` implementation a hook to identify nullable types correctly within its own reflection model. This mirrors the long-standing `Type.GetEnumUnderlyingType` pattern.

The base implementation throws rather than returning `null` by design so that custom `Type` subclass authors are notified that they need to provide a correct answer for their domain.

## Recommended action

If you author a custom `Type` subclass, add an override of `GetNullableUnderlyingType`. Choose the appropriate implementation:

- If your subclass never represents a `Nullable<T>`, return `null`:

  ```csharp
  public override Type? GetNullableUnderlyingType() => null;
  ```

- If your subclass represents constructed generic types and might instantiate `Nullable<T>`, return the corresponding type argument:

  ```csharp
  public override Type? GetNullableUnderlyingType()
  {
      if (IsGenericType
          && !IsGenericTypeDefinition
          && GetGenericTypeDefinition() == typeof(Nullable<>))
      {
          return GetGenericArguments()[0];
      }
      return null;
  }
  ```

- If your subclass is a delegating wrapper around another `Type`, forward the call:

  ```csharp
  public override Type? GetNullableUnderlyingType() => _innerType.GetNullableUnderlyingType();
  ```

Compiling against .NET 11 surfaces the new virtual on `Type`, making the override discoverable in your IDE. No app or configuration switch reverts to the old behavior.

## Affected APIs

- <xref:System.Nullable.GetUnderlyingType(System.Type)?displayProperty=fullName>
- `System.Type.GetNullableUnderlyingType()` (new virtual; default throws <xref:System.NotSupportedException>)
