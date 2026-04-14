---
title: "NETSDK1237: Assembly listed in PublishReadyToRunPartialAssemblies but compiled into a composite image"
description: Learn about .NET SDK warning NETSDK1237, which occurs when an assembly is listed in PublishReadyToRunPartialAssemblies but is being compiled into a ReadyToRun composite image.
ms.topic: error-reference
ms.date: 04/13/2026
f1_keywords:
- NETSDK1237
ai-usage: ai-generated
---
# NETSDK1237: Assembly listed in PublishReadyToRunPartialAssemblies but compiled into a composite image

NETSDK1237 warns you when you list an assembly in `PublishReadyToRunPartialAssemblies` but also compile it into a [ReadyToRun composite image](../../deploying/ready-to-run.md). You can only use partial compilation for assemblies compiled separately. The SDK compiles the assembly fully into the composite image and ignores the `PublishReadyToRunPartialAssemblies` setting for it.

NETSDK1237 appears when you set both `PublishReadyToRunComposite` to `true` and include assemblies in `PublishReadyToRunPartialAssemblies` in your project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <PublishReadyToRun>true</PublishReadyToRun>
    <PublishReadyToRunComposite>true</PublishReadyToRunComposite>
  </PropertyGroup>
  <ItemGroup>
    <!-- NETSDK1237 is emitted for each assembly listed here -->
    <PublishReadyToRunPartialAssemblies Include="SomeAssembly" />
  </ItemGroup>
</Project>
```

To resolve this warning, choose one of the following options:

- Remove the assemblies from `PublishReadyToRunPartialAssemblies` if you want them compiled fully into the composite image.
- Set `PublishReadyToRunComposite` to `false` if you want to compile assemblies partially and separately instead of into a composite image.
