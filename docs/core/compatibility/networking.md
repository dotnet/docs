---
title: Networking breaking changes
description: Lists the breaking changes in networking in .NET Core.
ms.date: 05/05/2020
---
# Networking breaking changes

The following breaking changes are documented on this page:

| Breaking change | Introduced version |
| - | - |
| [WinHttpHandler removed from .NET runtime](#winhttphandler-removed-from-net-runtime) | 5.0 |
| [MulticastOption.Group doesn't accept a null value](#multicastoptiongroup-doesnt-accept-a-null-value) | 5.0 |
| [Default value of HttpRequestMessage.Version changed to 1.1](#default-value-of-httprequestmessageversion-changed-to-11) | 3.0 |
| [WebClient.CancelAsync doesn't always cancel immediately](#webclientcancelasync-doesnt-always-cancel-immediately) | 2.0 |

## .NET 5.0

[!INCLUDE [winhttphandler-removed-from-runtime](../../../includes/core-changes/networking/5.0/winhttphandler-removed-from-runtime.md)]

***

[!INCLUDE [multicastoption-group-doesnt-accept-null](../../../includes/core-changes/networking/5.0/multicastoption-group-doesnt-accept-null.md)]

***

## .NET Core 3.0

[!INCLUDE[Default value of HttpRequestMessage.Version changed to 1.1](~/includes/core-changes/networking/3.0/httprequestmessage-version-change.md)]

***

## .NET Core 2.0

[!INCLUDE [behavior-change-webclient-cancelasync](../../../includes/core-changes/networking/2.0/behavior-change-webclient-cancelasync.md)]

***
