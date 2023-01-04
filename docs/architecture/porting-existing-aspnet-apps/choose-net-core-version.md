---
title: Choose the right .NET version
description: How should you determine which version of .NET or .NET Core to target?
author: ardalis
ms.date: 12/08/2022
---

# Choose the right .NET Core version

[!INCLUDE [download-alert](includes/download-alert.md)]

The largest consideration for most organizations when choosing which version of .NET to target is the support lifecycle. Long Term Support (LTS) releases ship less frequently but have a longer support window than Standard Term Support (STS) releases. Currently, LTS releases are scheduled to ship every other year. Customers can choose which releases to target, and can install different releases of .NET side by side on the same machine. LTS releases will receive only critical and compatible fixes throughout their lifecycle. STS releases will receive these same fixes and will also be updated with compatible innovations and features. LTS releases are supported for three years after their initial release. STS releases are supported for six months after a subsequent STS or LTS release.

Most customers looking to migrate a large .NET Framework app to .NET (Core) today are probably looking for a stable destination, given that they haven't already made the move to an earlier version of .NET Core. In this case, the best .NET version to target for the migration is .NET 6, which is the most recent LTS version. While support for .NET Core 3.1 ends in December 2022, support for .NET 6 will continue until November 2024.

This book assumes .NET Framework apps will be upgraded to .NET 6.

## References

[.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)

>[!div class="step-by-step"]
>[Previous](migrate-aspnet-core-2-1.md)
>[Next](incremental-migration-strategies.md)
