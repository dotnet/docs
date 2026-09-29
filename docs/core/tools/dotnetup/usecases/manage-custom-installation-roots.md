---
title: Manage custom dotnetup installation roots
description: Install and manage .NET in custom roots and isolated manifests.
ms.topic: how-to
ms.date: 08/07/2026
---

# Manage custom dotnetup installation roots

A custom installation root can isolate repository, test, or tool installations
from the default dotnetup-managed .NET installation root.

## Track a custom root in the default manifest

Select the root with `--install-path`:

```dotnetcli
dotnetup sdk install 10.0 --install-path D:\tools\dotnet
dotnetup runtime install aspnetcore@10.0 --install-path D:\tools\dotnet
```

The default manifest records both requirements and their root. A later
unfiltered update can process this root:

```dotnetcli
dotnetup update
```

Limit list, update, or uninstall to the root when needed:

```dotnetcli
dotnetup list --install-path D:\tools\dotnet
dotnetup update --install-path D:\tools\dotnet
dotnetup sdk uninstall 10.0 --install-path D:\tools\dotnet
```

## Isolate the manifest

Use `--manifest-path` when the tracking state must also be separate:

```dotnetcli
dotnetup sdk install 10.0 \
  --install-path D:\tools\dotnet \
  --manifest-path D:\tools\dotnetup_manifest.json
```

Repeat `--manifest-path` for later list, update, and uninstall operations.
This option applies to one command. It does not move the dotnetup configuration
file or change the default installation root.

## Run the custom installation

Run its executable directly, or activate it for the current shell:

```powershell
dotnetup env script --shell pwsh --dotnet \
  --dotnet-install-path D:\tools\dotnet |
  Invoke-Expression
```

`dotnetup dotnet` does not automatically select arbitrary custom roots.

## Avoid concurrent manifest writes

`dotnetup` coordinates manifest access with a lock. Do not run concurrent write
commands against the same manifest. Use separate manifests for independent
automation.

## See also

- [How dotnetup works](../concepts/how-dotnetup-works.md)
- [dotnetup env script](../reference/dotnetup-env-script.md)
