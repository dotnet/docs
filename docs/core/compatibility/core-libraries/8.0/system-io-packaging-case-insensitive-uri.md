---
title: "Breaking change: Package part URIs are now compared case-insensitively in System.IO.Packaging"
description: "Learn about the breaking change in .NET 8 where System.IO.Packaging now compares package part URIs case-insensitively to align with the OPC specification."
ms.date: 09/29/2024
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/runtime/issues/112783
---

# Package part URIs are now compared case-insensitively in System.IO.Packaging

Previously, part names and overrides that differed only by ASCII case (for example, `/part` vs `/PART`) were not considered equivalent in <xref:System.IO.Packaging>, even though the Open Packaging Conventions (OPC) specification requires case-insensitive equivalence (§7.2.3.5, ECMA-376). This change fixes the bug and brings .NET 5–9 in line with both .NET Framework and the OPC specification.

## Version introduced

.NET 8

## Previous behavior

URI comparisons were case-sensitive.
Content type overrides failed if the casing differed between the part URI and the override entry.
Some non-compliant packages containing duplicate entries differing only in case (for example, `/part` and `/PART`) could be loaded, leading to ambiguous results.

## New behavior

URI comparisons are case-insensitive (<xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>).
Overrides with different casing now work as expected.
Non-compliant packages containing multiple entries that differ only by case are now rejected when opened. This aligns with .NET Framework and the OPC specification.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change aligns <xref:System.IO.Packaging> behavior with:

- The OPC specification (case-insensitive URI equivalence is mandatory).
- Existing .NET Framework behavior, which already enforces case-insensitive matching.

It prevents ambiguous lookups and ensures consistent results, and fixes [dotnet/runtime#112783](https://github.com/dotnet/runtime/issues/112783).

## Recommended action

Ensure that OPC packages do not contain part names differing only by case, as this is invalid per the OPC specification.

If consuming packages that violate the specification:

- Contact the package author to fix the package.
- If you need to read or inspect the contents, you can open the package as a ZIP archive. Unlike the Package API, ZIP archives do not enforce OPC rules and will allow you to access all entries, including those with conflicting case names.

## Affected APIs

- <xref:System.IO.Packaging.Package.GetPart(System.Uri)?displayProperty=fullName>
- <xref:System.IO.Packaging.Package.CreatePart(System.Uri,System.String)?displayProperty=fullName>
