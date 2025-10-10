---
title: Upgrade .NET apps overview
description: Understand the aspects of upgrading from .NET Framework to .NET, upgrading to the latest .NET, and modernizing your app to the cloud.
author: adegeo
ms.date: 09/12/2025
ai-usage: ai-assisted
---

# Overview of upgrading .NET apps

This article explains how to plan and perform upgrades of .NET applications. It helps you assess your current app, choose the right upgrade path, use the available tooling, and validate the upgraded app. Follow the guidance to upgrade from .NET Framework to modern .NET, move to the latest .NET release, or modernize your app for cloud and containers.

## When to upgrade

Consider upgrading when business or technical signals show clear value:

- .NET or other dependencies reach end of support.
- New security vulnerabilities are discovered or you must meet new compliance requirements.
- Or you face performance or scalability limits that newer .NET versions address.

Upgrading is a good opportunity to modernize your app. For example, you could containerize your app, modernize a component to a cloud-native service, or apply cloud patterns that improve reliability and operability.

It also increases developer productivity by enabling newer SDKs, templates, and language features that simplify development and reduce maintenance. Prioritize upgrades by risk and return: run a targeted assessment, pilot the changes on a low-risk project, and use the results to plan broader migrations.

## Upgrade your environment

.NET releases a new major version yearly, alternating STS (standard-term support) and LTS (long-term support) versions. The .NET SDK supports targeting older versions of .NET, which you might need continue to support if you deploy to a cloud service that doesn't yet support the latest .NET runtime.

It's important to keep your developer tools up-to-date as each new release addresses security vulnerabilities and provides compatibility with new technologies.

## Use GitHub Copilot app modernization agent

The GitHub Copilot app modernization agent provides an AI-assisted, end-to-end experience to speed porting and modernization work. The agent analyzes your project and writes a plan to complete your desired upgrade. You can adjust and iterate on the plan, then perform the upgrades. With this assistant, you can:

- Upgrade projects to a newer .NET version.
- Assess your application's code, configuration, and dependencies.
- Migrate projects from older .NET versions to the latest release.
- Migrate technologies your app depends on to Azure.
- Plan and provision the right Azure resources.
- Fix issues and apply cloud-migration best practices.
- Validate that your app builds and that tests pass.

Use the GitHub Copilot app modernization agent when you want a guided, AI-powered path to assess, remediate, and modernize codebases—particularly for projects that have many dependencies, rely on Windows-specific APIs, or when you plan to containerize or migrate services to the cloud.

For more information, see [What is GitHub Copilot app modernization](github-copilot-app-modernization/overview.md).
