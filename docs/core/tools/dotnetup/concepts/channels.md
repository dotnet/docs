---
title: dotnetup channels and versions
description: Learn how dotnetup resolves stable, preview, daily, numeric, and exact .NET version specifications.
ms.topic: conceptual
ms.date: 08/07/2026
---

# dotnetup channels and versions

A channel describes a set of .NET versions. An exact version describes one
version. `dotnetup` stores `channels` and resolves it for the
selected component.

## Named channels

| Channel | SDK selection |
| --- | --- |
| `latest` | Latest active stable .NET SDK release |
| `lts` | Latest stable release whose support phase is LTS |
| `preview` | Latest active preview or GoLive SDK. Selects an active release when no preview is available. |
| `daily` | Latest available daily build from the daily channel search |

`sts` is not a supported named channel.

## Numeric SDK channels

| Form | Example | Selection |
| --- | --- | --- |
| Major | `10` | Latest SDK release for that major version |
| Major and minor | `10.0` | Latest SDK release for that major and minor version |
| Feature band | `10.0.1xx` | Latest SDK in that feature band |
| Exact SDK version | `10.0.103` | Only that SDK version |
| Exact prerelease SDK version | `11.0.100-preview.5.25277.114` | Only that prerelease SDK version |

An exact version is pinned. `dotnetup update` does not replace it.

## Runtime channels and versions

Runtime commands use runtime versions, not SDK feature bands. Use a
major/minor channel, such as `10.0`, or an exact runtime version, such as
`10.0.3`.

Use `component@version-or-channel` to select a runtime component:

```dotnetcli
dotnetup runtime install runtime@10.0
dotnetup runtime install aspnetcore@10.0
dotnetup runtime install windowsdesktop@10.0
```

When you omit the component name, `dotnetup` selects the core .NET runtime:

```dotnetcli
dotnetup runtime install 10.0
```

## Channel matching during updates

An update resolves each tracked channel independently. If a newer matching
version exists, `dotnetup` installs it. Exact versions are skipped. After a
successful update, garbage collection removes versions that no remaining
specification needs.

The command continues with other tracked specifications if one update fails.
It returns a failure after it processes the remaining specifications.

## Release-channel details

- [Preview channel](../channels/preview.md)
- [Daily channels](../channels/daily.md)
