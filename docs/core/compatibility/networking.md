---
title: Networking breaking changes
description: Lists the breaking changes in networking in .NET Core.
ms.date: 05/05/2020
---
# Networking breaking changes

The following breaking changes are documented on this page:

| Breaking change | Introduced version |
| - | - |
| [Default value of HttpRequestMessage.Version changed to 1.1](#default-value-of-httprequestmessageversion-changed-to-11) | 3.0 |
| [WebClient.CancelAsync doesn't always cancel immediately](#webclientcancelasync-doesnt-always-cancel-immediately) | 2.0 |

## .NET Core 3.0

[!INCLUDE[Default value of HttpRequestMessage.Version changed to 1.1](~/includes/core-changes/networking/3.0/httprequestmessage-version-change.md)]

***

## .NET Core 2.0

[!INCLUDE [behavior-change-webclient-cancelasync](../../../includes/core-changes/networking/2.0/behavior-change-webclient-cancelasync.md)]

***
