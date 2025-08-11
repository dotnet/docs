---
title: "Breaking change: DefaultValueAttribute(System.Type type, string? value) constructor no longer annotated with DynamicallyAccessedMembers"
description: "Learn about the breaking change in .NET 10 where DefaultValueAttribute(System.Type type, string? value) constructor is no longer annotated with DynamicallyAccessedMembers."
ms.date: 01/30/2025
ai-usage: ai-assisted
---

# DefaultValueAttribute(System.Type type, string? value) constructor no longer annotated with DynamicallyAccessedMembers

The <xref:System.ComponentModel.DefaultValueAttribute.%23ctor(System.Type,System.String)?displayProperty=nameWithType> constructor is no longer annotated with <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute>. This constructor is not supported with trimming and will throw an exception if reached at runtime in a trimmed app.

## Version introduced

.NET 10

## Previous behavior

If the constructor was used in a trimmed app and the feature switch to disable exception throwing was used, publishing the app would generate a trimming warning and there was a chance the code would work at runtime.

## New behavior

If the constructor is used in a trimmed app and the feature switch to disable exception throwing is used, publishing the app will generate a trimming warning and there's a smaller chance the code will work at runtime.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This attribute should not be used in trimmed apps because it doesn't reliably work. Trimming should be free to remove type members mentioned in the attribute.

## Recommended action

Do not enable the feature switch that attempts to make this attribute (unreliably) work in trimmed apps.

## Affected APIs

- <xref:System.ComponentModel.DefaultValueAttribute.%23ctor(System.Type,System.String)?displayProperty=fullName>
