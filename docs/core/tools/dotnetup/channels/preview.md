---
title: Use the dotnetup preview channel
description: Install and update supported .NET preview releases with dotnetup.
ms.topic: how-to
ms.date: 08/07/2026
---

# Use the dotnetup preview channel

The `preview` channel selects the latest available preview or GoLive .NET
release. If no active preview is available, the resolver selects an active
release.

## Install a preview SDK

```dotnetcli
dotnetup sdk install preview
```

The tracked specification remains `preview`. A later update can move it to a
newer preview:

```dotnetcli
dotnetup sdk update
```

## Install preview runtimes

Select one or more runtime components:

```dotnetcli
dotnetup runtime install runtime@preview aspnetcore@preview
```

The Windows Desktop runtime is available only on Windows:

```dotnetcli
dotnetup runtime install windowsdesktop@preview
```

## Pin a prerelease version

Use a complete prerelease version when you need reproducible selection:

```dotnetcli
dotnetup sdk install 11.0.100-preview.5.25277.114
```

An exact prerelease version is pinned. Update commands do not advance it.

## Preview and daily are different

The `preview` channel uses published release metadata. A daily channel uses
daily-build endpoints and can select builds that are not published previews.
For more information, see [Daily channels](daily.md).

## Remove the preview requirement

```dotnetcli
dotnetup sdk uninstall preview
```

This command removes the explicit `preview` specification. Files remain if
another specification still requires them.
