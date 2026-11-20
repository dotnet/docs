---
ms.date: 04/26/2024
ms.topic: include
---
**`--artifacts-path <ARTIFACTS_DIR>`**

All build output files from the executed command will go in subfolders under the specified path, separated by project. For more information see [Artifacts Output Layout](../../sdk/artifacts-output.md). This option and the value provided must be explicitly cascaded in any `dotnet` command that depends on the output of another `dotnet` command, for example, when using `dotnet build --no-restore` and `dotnet publish --no-build`. Available since .NET 8 SDK.
