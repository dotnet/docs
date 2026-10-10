---
title: Installing .NET Guidance
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 12/13/2024
ms.custom: linux-related-content
---

# Installing .NET Guidance

There are multiple ways to [install .NET](.). Reliability, servicing, and high availability are important requirements for many users.

## Binaries

There are multiple ways to download binaries:

- [.NET website](https://dotnet.microsoft.com/download)
- [Install script](../tools/dotnet-install-script)
- [Release JSON files](https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json)
- [Release notes](https://github.com/dotnet/core/blob/main/release-notes/README.md)

Packages and container images are also available, documented in release notes.

## Picking the best URL

Some scenarios requiring hard-coding URLs, for example [our Dockerfiles](https://github.com/dotnet/dotnet-docker/blob/85c275aed5bda401dc067ccc4a99a43bdd0d7531/src/runtime/8.0/jammy/amd64/Dockerfile#L8). We offer various URL schemes to meet specific needs.

For binaries:

- Major-version short link: https://aka.ms/dotnet/8.0/dotnet-runtime-linux-x64.tar.gz
- Patch-version link: https://builds.dotnet.microsoft.com/dotnet/Runtime/8.0.12/dotnet-runtime-8.0.12-linux-x64.tar.gz

The first link provides servicing updates transparently while the second provides repeatable stability. The first link also relies on another service (including a 3xx redirect) to arrive at the correct final link.

For the install script:

- Short link: https://dot.net/v1/dotnet-install.sh
- Long link: https://builds.dotnet.microsoft.com/dotnet/scripts/v1/dotnet-install.sh

These two links are a matter of preference.

For release JSON files:

- Official: https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json
- GitHub: https://github.com/dotnet/core/blob/main/release-notes/releases-index.json

The official `builds.dotnet.microsoft.com` link must be used for any production use of the JSON files. We do not offer production support for downtime for the GitHub link.

Notes:

- Distribution of [.NET installers changed in early 2025](https://github.com/dotnet/core/issues/9671). It is possible that you may need to adapt to those changes.
- The JSON files historically [reference binaries from `download.visualstudio.microsoft.com`](https://github.com/dotnet/core/blob/ba8e8b613986c903b0caebfdb4cee8a2c6bf7f7b/release-notes/8.0/8.0.0/release.json#L31-L34). Going forward, only the `builds.dotnet.microsoft.com` will be used.

## Checksums

We provide checksums for all binaries so that integrity can be validated.

Checksums are provided in multiple ways:

- Version-specific checksum file: https://builds.dotnet.microsoft.com/dotnet/checksums/8.0.0-sha.txt
- Release JSON: https://github.com/dotnet/core/blob/ba8e8b613986c903b0caebfdb4cee8a2c6bf7f7b/release-notes/8.0/8.0.0/release.json#L31-L34

## CI Installers

CI installers, like [GitHub Actions](https://github.com/actions/setup-dotnet) and [Azure DevOps Tasks](https://learn.microsoft.com/azure/devops/pipelines/tasks/reference/use-dotnet-v2), are built on top of these same primitives. We work with these teams so that CI installers provide the best experience.
