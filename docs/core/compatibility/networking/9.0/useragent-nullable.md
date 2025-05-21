---
title: "Breaking change: HttpListenerRequest.UserAgent is nullable"
description: Learn about the .NET 9 breaking change in networking where the HttpListenerRequest.UserAgent property is annotated as being nullable.
ms.date: 01/18/2024
ms.topic: concept-article
---
# HttpListenerRequest.UserAgent is nullable

The <xref:System.Net.HttpListenerRequest.UserAgent?displayProperty=nameWithType> property was previously annotated as being non-nullable, but it was actually nullable in practice. The nullable annotation for this properties has been updated to indicate that it's nullable. This can result in new build warnings related to use of nullable members.

## Previous behavior

Previously, the property was annotated as not being nullable. You could consume its value and assume it could not be `null` without getting any warnings during build.

## New behavior

Starting in .NET 9, the property is annotated as being nullable. If you consume the value without checking for `null`, you'll get a build warning.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The annotations of this property was incorrect. This change applies the appropriate behavior for the property and ensures callers understand the value can be `null`.

## Recommended action

Update calling code to guard against `null` for this property.

## Affected APIs

- <xref:System.Net.HttpListenerRequest.UserAgent?displayProperty=fullName>
