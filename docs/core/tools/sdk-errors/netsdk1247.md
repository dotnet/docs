---
title: "NETSDK1247: A file required for publishing was not found"
description: Learn how to resolve .NET SDK error NETSDK1247 when single-file publishing with --no-build can't find a required input file.
ms.topic: error-reference
ms.date: 11/16/2026
ai-usage: ai-generated
f1_keywords:
- NETSDK1247
---
# NETSDK1247: A file required for publishing was not found

This error occurs when you publish a single-file app with `--no-build` and a file required for the single-file bundle is missing. The full error message is similar to the following example:

> NETSDK1247: The file '\<path>' required for publishing was not found. Publish without '--no-build', or ensure the project has been built with the appropriate Configuration, TargetFramework, RuntimeIdentifier, and SelfContained properties.

## Common causes

- Build outputs or intermediate files, such as the assembly in the `obj` directory, were deleted or weren't copied to the environment where you run `dotnet publish`.
- The earlier build didn't produce the inputs needed for the requested configuration, target framework, runtime identifier, or self-contained setting.

## Resolve the error

To regenerate the required inputs, remove `--no-build` and publish again. For example:

```dotnetcli
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true
```

To keep separate build and publish steps, ensure the earlier build produces the inputs required by the publish operation's `Configuration`, `TargetFramework`, `RuntimeIdentifier`, and `SelfContained` values. Preserve the required build outputs and intermediate files between steps. For example, run both commands from the same project directory:

```dotnetcli
dotnet build -c Release -r win-x64 --self-contained false
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true --no-build
```

You can enable `PublishSingleFile` at publish time if all required build inputs exist. For a self-contained app, use `--self-contained true` for both commands.

## See also

- [dotnet publish](../dotnet-publish.md)
- [Single-file deployment](../../deploying/single-file/overview.md)
- [.NET SDK error and warning reference](index.md)
