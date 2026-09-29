---
title: Use dotnetup daily channels
description: Install and update .NET daily builds with scoped dotnetup channels.
ms.topic: how-to
ms.date: 08/07/2026
---

# Use dotnetup daily channels

Daily channels select builds from component-specific daily-build endpoints.
Use them to test changes that are not yet available in a stable or preview
release.

> [!CAUTION]
> Daily builds can change frequently and are not supported releases. They are not code-signed.

## Daily channel forms

| Form | Example | Scope |
| --- | --- | --- |
| Unscoped | `daily` | Searches the next major version first, then the latest major version in release metadata |
| Major | `11-daily` | One major version |
| Major and minor | `11.0-daily` | One major and minor version |
| SDK feature band | `11.0.1xx-daily` | One SDK feature band |
| SDK preview phase | `11.0.1xx-preview.5-daily` | One SDK feature band and preview phase |
| Runtime preview phase | `11.0-preview.5-daily` | One runtime major/minor and preview phase |

The compact phase form `preview5` is also accepted where
`preview.5` is accepted.

`preview-daily` and daily channels with a complete patch version, such as
`11.0.103-daily`, are not valid.

## Install a daily SDK

```dotnetcli
dotnetup sdk install 11.0.1xx-daily
```

Track a specific preview phase:

```dotnetcli
dotnetup sdk install 11.0.1xx-preview.5-daily
```

## Install daily runtimes

```dotnetcli
dotnetup runtime install runtime@11.0-daily aspnetcore@11.0-daily
```

On Windows, you can also install the Windows Desktop daily runtime:

```dotnetcli
dotnetup runtime install windowsdesktop@11.0-daily
```

## Update a daily build

Daily channels are tracked like other channels:

```dotnetcli
dotnetup update
```

If the endpoint resolves to a newer matching build, `dotnetup` installs it.
Garbage collection removes older files that no remaining specification needs.

## Isolate daily builds

Use a separate installation root when you do not want daily builds to share
files with your default managed installation:

```dotnetcli
dotnetup sdk install 11.0.1xx-daily --install-path .\.dotnet-daily
.\.dotnet-daily\dotnet.exe --version
```

The `dotnetup dotnet` forwarding command does not automatically select an
arbitrary custom installation root. To use a custom installation directly,
run its `dotnet` executable or activate it with
`dotnetup env script --dotnet-install-path`.
