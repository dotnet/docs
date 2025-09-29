---
title: "Breaking change: Package part URIs compared case-insensitively in System.IO.Packaging"
description: "Learn about the breaking change in .NET 8 where System.IO.Packaging now compares package part URIs case-insensitively to align with the OPC specification."
ms.date: 09/29/2025
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/runtime/issues/112783
---

# Package part URIs compared case-insensitively in System.IO.Packaging

Previously, part names and overrides that differed only by ASCII case (for example, `/part` and `/PART`) weren't considered equivalent in <xref:System.IO.Packaging>, even though the Open Packaging Conventions (OPC) specification requires case-insensitive equivalence (§7.2.3.5, ECMA-376). This change fixes the bug and brings .NET in line with both .NET Framework and the OPC specification.

## Version introduced

.NET 8

## Previous behavior

In .NET Core 1.0 through .NET 7, URI comparisons were case-sensitive:

- Content type overrides failed if the casing differed between the part URI and the override entry.
- Some non-compliant packages containing duplicate entries that differed only in case (for example, `/part` and `/PART`) could be loaded, leading to ambiguous results.

## New behavior

Starting in .NET 8, URI comparisons are case-insensitive (<xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>):

- Overrides with different casing work as expected.
- Non-compliant packages containing multiple entries that differ only by case are rejected when opened. This aligns with .NET Framework and the OPC specification.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change aligns <xref:System.IO.Packaging> behavior with:

- The OPC specification (case-insensitive URI equivalence is mandatory).
- Existing .NET Framework behavior, which already enforces case-insensitive matching.

## Recommended action

Ensure that OPC packages don't contain part names that differ only by case, as this is invalid per the OPC specification.

If you consume a package that violates the specification:

- Contact the package author to fix the package.
- If you need to read or inspect the contents, you can open the package as a ZIP archive. Unlike the Package API, ZIP archives don't enforce OPC rules, which allows you to access all entries, including those with conflicting case names.

## Affected APIs

- <xref:System.IO.Packaging.Package.GetPart(System.Uri)?displayProperty=fullName>
- <xref:System.IO.Packaging.Package.CreatePart(System.Uri,System.String)?displayProperty=fullName>
