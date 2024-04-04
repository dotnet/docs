---
author: tdykstra
ms.author: tdykstra
ms.date: 04/04/2024
ms.topic: include
---
- **`-c|--configuration <CONFIGURATION>`**

  Defines the build configuration. If you're developing with the .NET 8 SDK or a later version, the command uses the `Release` configuration by default for projects whose TargetFramework is set to `net8.0` or a later version. The default build configuration is `Debug` for earlier versions of the SDK and for earlier target frameworks. You can override the default in project settings or by using this option. For more information, see ['dotnet publish' uses Release configuration](~/docs/core/compatibility/sdk/8.0/dotnet-publish-config.md) and ['dotnet pack' uses Release configuration](~/docs/core/compatibility/sdk/8.0/dotnet-pack-config.md).
