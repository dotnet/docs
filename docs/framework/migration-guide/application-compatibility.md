---
title: Application Compatibility in the .NET Framework
ms.date: "05/19/2017"
helpviewer_keywords:
  - "application compatibility"
  - ".NET Framework application compatibility"
  - ".NET Framework changes"
ms.assetid: c4ba3ff2-fe59-4c5d-9e0b-86bba3cd865c
author: "rpetrusha"
ms.author: "ronpet"
---
# Application compatibility in the .NET Framework

Compatibility is an important goal of each .NET release. Compatibility ensures that each version is additive, so previous versions will continue to work. On the other hand, changes to previous functionality (for example, to improve performance, address security issues, or fix bugs) can cause compatibility problems in existing code or existing applications that run under a later version.

The .NET Framework recognizes two types of changes:

- retargeting changes
- runtime changes

Retargeting changes affect applications that target a specific version of the .NET Framework but are running on a later version. Runtime changes affect all applications running on a particular version.

Each app targets a specific version of the .NET Framework by:

- Defining a target framework in Visual Studio.
- Specifying the target framework in a project file.
- Applying a <xref:System.Runtime.Versioning.TargetFrameworkAttribute> to the source code.

When running on a newer version than what was targeted, the .NET Framework uses *quirked* behavior to mimic the older targeted version. The app runs on the newer version but acts as if it's running on the older version. Many of the compatibility issues between versions of the .NET Framework are mitigated through this quirking model. The version of the .NET Framework that an application targets is determined by the target version of the entry assembly for the application domain that the code runs in. All additional assemblies loaded in that application domain target that version. For example, in the case of an executable, the version that the executable targets is the compatibility mode all assemblies in that application domain will run under.

## Runtime changes

Runtime issues are those that arise when a new runtime is placed on a machine and an app's behavior changes. If a binary was compiled for .NET Framework 4.0, it runs in .NET Framework 4.0 compatibility mode on 4.5 or later versions. Many of the changes that affect 4.5 do not affect a binary compiled for 4.0. This is specific to the application domain and depends on the settings of the entry assembly.

## Retargeting changes

Retargeting issues are those that arise when an assembly that was targeting a previous version now targets a later version. Targeting a newer version means the assembly opts into the new features as well as potential compatibility issues for old features. Again, this is dictated by the entry assembly, which is the console app that uses the assembly or the website that references the assembly.

## .NET compatibility diagnostics

The .NET compatibility diagnostics are Roslyn-powered analyzers that help identify application compatibility issues between versions of the .NET Framework. This list contains all of the analyzers available, although only a subset apply to any specific migration. The analyzers determine which issues are applicable for the planned migration and will only surface those.

Each issue includes the following information:

- The description of what has changed from a previous version.

- How the change affects customers and whether any workarounds are available to preserve compatibility across versions.

- An assessment of how significant the change is.

- The version when the change first appears in the framework. Some of the changes are introduced in a particular version and reverted in a later version; that's indicated as well.

- The type of change (runtime or retargeting).

- The affected APIS, if any.

- The IDs of the available diagnostics.

## Usage

To begin, select the type of compatibility change below:

- [Retargeting Changes](./retargeting/index.md)
- [Runtime Changes](./runtime/index.md)

## See also

- [Versions and Dependencies](versions-and-dependencies.md)
- [What's New](../whats-new/index.md)
- [What's Obsolete in the Class Library](../whats-new/whats-obsolete.md)
