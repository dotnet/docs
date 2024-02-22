---
title: ".NET 8 breaking change: Method builders generate parameters with HasDefaultValue set to false"
description: Learn about the .NET 8 breaking change in core .NET libraries where ConstructorBuilder and MethodBuilder now generate method parameters with HasDefaultValue set to false.
ms.date: 08/22/2023
---
# Method builders generate parameters with HasDefaultValue set to false

<xref:System.Reflection.Emit.ConstructorBuilder?displayProperty=fullName> and <xref:System.Reflection.Emit.MethodBuilder?displayProperty=fullName> now generate method parameters that, when reflected on, have <xref:System.Reflection.ParameterInfo.HasDefaultValue?displayProperty=nameWithType> set to `false`.

## Previous behavior

Previously, <xref:System.Reflection.Emit.ConstructorBuilder> and <xref:System.Reflection.Emit.MethodBuilder> generated IL for method parameters where the <xref:System.Reflection.ParameterInfo.HasDefaultValue> of the parameters was set to `true`.

## New behavior

Starting in .NET 8, <xref:System.Reflection.Emit.ConstructorBuilder> and <xref:System.Reflection.Emit.MethodBuilder> generate IL for method parameters where the <xref:System.Reflection.ParameterInfo.HasDefaultValue> of the parameters is set to `false`, which is the expected value.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect, as no default parameter values were specified when the method or constructor was defined.

## Recommended action

If you use <xref:System.Reflection.Emit.TypeBuilder.DefineConstructor%2A?displayProperty=nameWithType> or <xref:System.Reflection.Emit.TypeBuilder.DefineMethod%2A?displayProperty=nameWithType>, make sure consumers of the generated types' methods don't rely on the <xref:System.Reflection.ParameterInfo.HasDefaultValue?displayProperty=nameWithType> property being `true`.

## Affected APIs

- <xref:System.Reflection.ParameterInfo.HasDefaultValue?displayProperty=fullName>
