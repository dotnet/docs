---
title: .NET Install Manager overview
description: An overview of the .NET Install Manager. This tool is a guided command-line tool to manage .NET installations.
author: joeloff
ms.date: 09/14/2026
ai-usage: ai-assisted
---

# .NET Install Manager overview

The .NET Install Manager (*DNIM*) is a command-line tool used to identify, remove or update .NET installations on Windows. It's primarily intended to assist organizations in removing vulnerable copies of .NET from devices to meet compliance targets.

DNIM ships as a trimmed, single file .NET executable, making it easy to deploy across devices using tools like [Microsoft Configuration Manager](/intune/configmgr/).

> [!IMPORTANT]
> DNIM doesn't enforce any policies by default. Administrators should use the CLI to create deployments that best express their organization's compliance policies.

The tool is data driven and depends on the [release information](https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json) published for .NET. While internet access is required to download the latest release information and updates, administrators can prepare offline deployments for network restricted environments.

## Support

> [!IMPORTANT]
> Because DNIM is a single file application, new builds are regularly published to ensure the .NET runtime remains up to date. Any changes, including security fixes are documented in the release notes. Enterprise customers should contact their [customer support representative](https://engagecenter.microsoft.com/#view/Microsoft_AzureCXP_EngageHub/EngageHubMenu.MenuView/~/helpSupport) to address concerns or report issues.

## See also

* [Managed .NET installations on Windows](dnim-net-installs.md)
* [Logging](dnim-logs.md)
