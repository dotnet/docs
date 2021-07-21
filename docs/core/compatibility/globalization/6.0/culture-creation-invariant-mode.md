---
title: "Breaking change: Culture creation and case mapping in globalization-invariant mode"
description: Learn about the globalization breaking change in .NET 6 where the creation of new cultures is restricted and case mapping support extends to all characters in globalization-invariant mode.
ms.date: 07/21/2021
---
# Culture creation and case mapping in globalization-invariant mode

[Globalization-invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md)] is used for apps that don't required any globalization support. That is, the app runs without access to culture-specific data and behavior. Globalization-invariant mode is enabled by default on some Docker containers, for example, Alpine containers.

This breaking change has two facets:

- Previously, .NET allowed any culture to be created in globalization-invariant mode, as long as the culture name conformed to [BCP-47](https://tools.ietf.org/search/bcp47). However, the invariant culture data was used instead of the real culture data. Starting in .NET 6, an exception is thrown if you create any culture other than the invariant culture in globalization-invariant mode.

## Old behavior


## New behavior


## Version introduced

.NET 6 Preview 7

## Reason for change

The culture-creation change was introduced to more easily diagnosis culture-related problems. Some users are unaware that their apps are running in an environment where globalization-invariant mode is enabled. They may experience unexpected behaviors due to globalization-invariant mode and don't make the association, so it's hard to diagnose the issue.

The full case-mapping support was introduced for better usability and experience in globalization-invariant mode.

## Recommended action

In most cases, no action is needed. However, if you desire the old behavior in globalization-invariant mode, you can use a configuration switch or environment variable.

Application configuration file:

Set `System.Globalization.PredefinedCulturesOnly` to `false`.

Environment variable:

Set `DOTNET_SYSTEM_GLOBALIZATION_PREDEFINED_CULTURES_ONLY` to `false`.

## Affected APIs



## See also

- [.NET globalization invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md)


<!--

### Category

- Globalization

-->
