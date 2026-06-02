---
title: Upgrade .NET apps overview
description: Understand the aspects of upgrading from .NET Framework to .NET, upgrading to the latest .NET, and modernizing your app to the cloud.
author: adegeo
ms.date: 06/01/2026
ai-usage: ai-assisted
---

# Overview of upgrading .NET apps

This article explains how to plan and perform upgrades of .NET applications. It helps you assess your current app, choose the right upgrade path, use the available tooling, and validate the upgraded app. Use the guidance to upgrade from .NET Framework to modern .NET, move to the latest .NET release, or modernize your app for cloud and containers.

## When to upgrade

Consider upgrading when business or technical signals show clear value:

- .NET or other dependencies reach end of support.
- New security vulnerabilities are discovered or you must meet new compliance requirements.
- You face performance or scalability limits that newer .NET versions address.

Upgrading is also a good opportunity to modernize your app. For example, you could containerize your app, move a component to a cloud-native service, or apply cloud patterns that improve reliability and operability. Upgrading also increases developer productivity by enabling newer SDKs, templates, and language features that simplify development and reduce maintenance.

Prioritize upgrades by risk and return: run a targeted assessment, pilot the changes on a low-risk project, and use the results to plan broader migrations.

## .NET release lifecycle

.NET releases a new major version yearly, alternating between standard-term support (STS) and long-term support (LTS) releases. Each release has a defined support window, after which it no longer receives security and quality updates. Plan your upgrade cadence around these dates so your apps stay on a supported version:

- **LTS releases** are supported for three years and are the typical choice for production apps that prefer stability.
- **STS releases** are supported for 18 months and are useful when you want to adopt new features sooner.

For supported versions, end-of-support dates, and patching guidance, see [.NET releases, patches, and support](../releases-and-support.md) and the [.NET and .NET Framework support policy](https://dotnet.microsoft.com/platform/support/policy).

The .NET SDK can target older versions of .NET, which you might need if you deploy to a hosting service that doesn't yet support the latest runtime. Keep your developer tools up to date because each release addresses security vulnerabilities and adds compatibility with new technologies.

## Choose an upgrade path

Most upgrades fall into one of the following categories. Start with the conceptual guide that matches your scenario, then use the tooling described in the next section to perform the work.

- **.NET Framework to modern .NET**

  Move Windows-only .NET Framework apps to cross-platform .NET. The app model, project format, and some APIs change, and you might need to replace technologies that aren't available in modern .NET. For an overview of what changes and how to plan, see [Overview of porting from .NET Framework to .NET](framework-overview.md). Related guidance:

  - [Pre-migration changes needed for .NET Framework projects](premigration-needed-changes.md)
  - [.NET Framework technologies unavailable in .NET](net-framework-tech-unavailable.md)
  - [Analyze your dependencies to port code from .NET Framework to .NET](third-party-deps.md)
  - [Use the Windows Compatibility Pack to port code to .NET](windows-compat-pack.md)

- **Older .NET to the latest .NET**

  Move from an out-of-support or older .NET version to the current release. These upgrades are usually smaller in scope—mostly target framework, dependency, and breaking-change updates. Review [.NET breaking changes](breaking-changes.md) for the versions you're crossing.

- **Modernize after upgrading**

  After your app builds and runs on modern .NET, take advantage of newer patterns such as _appsettings.json_ configuration, dependency injection, and modern web and desktop controls. For ideas and step-by-step guidance, see [Modernize after upgrading to .NET from .NET Framework](modernize.md).

- **Move to the cloud**

  Containerize your app, replace on-premises components with managed services, and adopt cloud patterns for reliability and observability.

## GitHub Copilot app modernization (recommended)

The [GitHub Copilot app modernization agent](github-copilot-app-modernization/overview.md) provides an AI-assisted, end-to-end experience that speeds porting and modernization work. The agent analyzes your project and writes a plan to complete your desired upgrade. You can adjust and iterate on the plan, then perform the upgrades. With this agent, you can:

- Upgrade projects to a newer .NET version.
- Assess your application's code, configuration, and dependencies.
- Migrate projects from older .NET versions to the latest release.
- Migrate technologies your app depends on to Azure.
- Plan and provision the right Azure resources.
- Fix issues and apply cloud-migration best practices.
- Validate that your app builds and that tests pass.

Use the agent when you want a guided, AI-powered path to assess, remediate, and modernize codebases—particularly for projects that have many dependencies, rely on Windows-specific APIs, or that you plan to containerize or migrate to the cloud. For more information, see [What is GitHub Copilot app modernization](github-copilot-app-modernization/overview.md).

### .NET Upgrade Assistant (deprecated)

[.NET Upgrade Assistant](upgrade-assistant-overview.md) is a Visual Studio extension and CLI tool that analyzes a project and applies common upgrade changes. It's officially deprecated in favor of the GitHub Copilot app modernization agent and is no longer actively developed. Use it only if you can't use the modernization agent—for example, if your environment doesn't have access to GitHub Copilot. New work should target the modernization agent instead.

## Next steps

- [Overview of porting from .NET Framework to .NET](framework-overview.md)
- [What is GitHub Copilot app modernization](github-copilot-app-modernization/overview.md)
- [Modernize after upgrading to .NET from .NET Framework](modernize.md)
- [.NET releases, patches, and support](../releases-and-support.md)
