---
title: "Breaking change: 'DynamicallyAccessedMembers' annotation removed from 'DefaultValueAttribute' ctor"
description: "Learn about the breaking change in .NET 10 where a 'DefaultValueAttribute' constructor is no longer annotated with 'DynamicallyAccessedMembers'."
ms.date: 08/11/2025
ai-usage: ai-assisted
---

# `DynamicallyAccessedMembers` annotation removed from `DefaultValueAttribute` ctor

The <xref:System.ComponentModel.DefaultValueAttribute.%23ctor(System.Type,System.String)?displayProperty=nameWithType> constructor is no longer annotated with <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute>. This constructor is not supported with trimming and throws an exception if reached at run time in a trimmed app.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, if the constructor was used in a trimmed app and the feature switch to disable exception throwing was used, publishing the app generated a trimming warning, and there was a chance the code worked at run time.

## New behavior

Starting in .NET 10, if the constructor is used in a trimmed app and the feature switch to disable exception throwing is used, publishing the app still generates a trimming warning. But there's a smaller chance the code will work at run time.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This attribute should not be used in trimmed apps because it doesn't reliably work. Trimming should be free to remove type members mentioned in the attribute.

## Recommended action

Don't enable the feature switch that attempts to make <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> (unreliably) work in trimmed apps.

## Affected APIs

- <xref:System.ComponentModel.DefaultValueAttribute.%23ctor(System.Type,System.String)>
