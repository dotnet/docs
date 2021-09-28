---
title: Choose the right .NET Core version
description: How should you determine which version of .NET Core to target?
author: ardalis
ms.date: 11/13/2020
---

# Choose the right .NET Core version

The largest consideration for most organizations when choosing a version of .NET Core to target is the support lifecycle. Long Term Support (LTS) releases ship less frequently but have a longer support window than Current (non-LTS) releases. Currently, LTS releases are scheduled to ship every other year. Customers can choose which releases to target, and can install different releases of .NET Core side by side on the same machine. LTS releases will receive only critical and compatible fixes throughout their lifecycle. Current releases will receive these same fixes and will also be updated with compatible innovations and features. LTS releases are supported for three years after their initial release. Current releases are supported for three months after a subsequent Current or LTS release.

Most customers looking to migrate a large .NET Framework app to .NET Core today are probably looking for a stable destination, given that they haven't already made the move to an earlier version of .NET Core. In this case, the best .NET Core version to target for the migration is .NET Core 3.1, which is the current LTS version. Support for .NET Core 3.1 ends in December 2022. The next planned LTS release will be .NET 6.0, slated to ship in November 2021.

Updating from .NET Core 3.1 to .NET 5.0 (the next version) requires much less effort than porting from .NET Framework to .NET Core. For this reason, the recommendation for most customers is to upgrade to .NET Core 3.1 first. Then decide whether the next update should be to the latest current release (.NET 5.0) or to wait for the next LTS release (.NET 6.0) before upgrading further.

This book assumes .NET Framework apps will be upgraded to .NET Core 3.1.

## References

[.NET Core and .NET 5 Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)

>[!div class="step-by-step"]
>[Previous](migrate-aspnet-core-2-1.md)
>[Next](incremental-migration-strategies.md)
