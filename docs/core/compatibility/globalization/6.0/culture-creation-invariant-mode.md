---
title: "Breaking change: Culture creation and case mapping in globalization-invariant mode"
description: Learn about the globalization breaking change in .NET 6 where the creation of new cultures is restricted and case mapping support extends to all characters in globalization-invariant mode.
ms.date: 07/23/2021
---
# Culture creation and case mapping in globalization-invariant mode

This breaking change affects *[globalization-invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md)* in two ways:

- Previously, .NET allowed any culture to be created in globalization-invariant mode, as long as the culture name conformed to [BCP-47](https://tools.ietf.org/rfc/bcp/bcp47.txt). However, [the invariant culture](/dotnet/api/system.globalization.cultureinfo#invariant-neutral-and-specific-cultures) data was used instead of the real culture data. Starting in .NET 6, an exception is thrown if you create any culture other than the invariant culture in globalization-invariant mode.
- Previously, globalization-invariant mode only supported case mapping for ASCII characters. Starting in .NET 6, globalization-invariant mode provides full case-mapping support for all Unicode-defined characters. Case mapping is used in operations such as string comparisons, string searches, and upper or lower casing strings.

[Globalization-invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is used for apps that don't required any globalization support. That is, the app runs without access to culture-specific data and behavior. Globalization-invariant mode is enabled by default on some Docker containers, for example, Alpine containers.

## Old behavior

In previous .NET versions when globalization-invariant mode is enabled:

- If an app creates a culture that's not the invariant culture, the operation succeeds but the returned culture always use the invariant culture data instead of the real culture data.
- Case mapping was performed only for ASCII characters. For example:

  ```csharp
  if ("Á".Equals("á", StringComparison.CurrentCultureIgnoreCase)) // Evaluates to false.
  ```

## New behavior

Starting in .NET 6 when globalization-invariant mode is enabled:

- If an app attempts to create a culture that's not the invariant culture, a <xref:System.Globalization.CultureNotFoundException> exception is thrown.
- Case mapping is performed for all Unicode-defined characters. For example:

  ```csharp
  if ("Á".Equals("á", StringComparison.CurrentCultureIgnoreCase)) // Evaluates to true.
  ```

## Version introduced

.NET 6

## Reason for change

The culture-creation change was introduced to more easily diagnose culture-related problems. Some users are unaware that their apps are running in an environment where globalization-invariant mode is enabled. They may experience unexpected behavior and don't make the association with globalization-invariant mode, so it's hard to diagnose the issue.

The full case-mapping support was introduced for better usability and experience in globalization-invariant mode.

## Recommended action

In most cases, no action is needed. However, if you desire the previous culture-creation behavior, you can set a runtime configuration option to allow creation of any culture in globalization-invariant mode. For more information, see [Predefined cultures](../../../run-time-config/globalization.md#predefined-cultures).

## Affected APIs

- <xref:System.Globalization.CultureInfo.%23ctor%2A>
- <xref:System.Globalization.CultureInfo.CreateSpecificCulture(System.String)?displayProperty=fullName>
- <xref:System.Globalization.CultureInfo.GetCultureInfo%2A?displayProperty=fullName>
- <xref:System.Globalization.RegionInfo.%23ctor%2A>
- Any APIs that perform string casing, comparison, or searching

## See also

- [.NET globalization invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md)
- [Invariant, neutral, and specific cultures](/dotnet/api/system.globalization.cultureinfo#invariant-neutral-and-specific-cultures)
