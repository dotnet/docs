---
title: "Breaking change: Removed DynamicallyAccessedMembers annotation from trim-unsafe Microsoft.Extensions.Configuration code"
description: "Learn about the breaking change in .NET 10 where DynamicallyAccessedMembers annotations were removed from trim-unsafe Microsoft.Extensions.Configuration APIs."
ms.date: 12/21/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47433
---

# Removed DynamicallyAccessedMembers annotation from trim-unsafe Microsoft.Extensions.Configuration code

Certain Microsoft.Extensions.Configuration APIs that were marked as <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> and had <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> annotations to preserve some necessary members during trimming have had those annotations removed completely. This change affects the trimming behavior of these APIs in .NET 10.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, certain Microsoft.Extensions.Configuration APIs worked with some limited use cases while generating trimming warnings at publish time. These APIs were annotated to preserve at least some of the necessary members when trimming, making the API partially functional in trimmed scenarios.

## New behavior

Starting in .NET 10, the same Microsoft.Extensions.Configuration APIs now work with even more limited use cases while still generating trimming warnings at publish time. The <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> annotations have been completely removed, reducing the amount of code preserved during trimming.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The annotations were removed as part of an effort to remove uses of <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All> from the product. This change encourages users to migrate to more trim-safe alternatives.

## Recommended action

Use the binding configuration source generator, which works reliably with trimming and provides a trim-safe alternative to these APIs.

## Affected APIs

Overloads that generate trimming warnings.