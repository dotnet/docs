---
title: Runtime and retargeting changes - .NET Framework
ms.date: 10/29/2019
helpviewer_keywords:
  - "application compatibility"
  - ".NET Framework application compatibility"
  - ".NET Framework changes"
ms.assetid: c4ba3ff2-fe59-4c5d-9e0b-86bba3cd865c
---
# Application compatibility in the .NET Framework

Compatibility is an important goal of each .NET release. Compatibility ensures that each version is additive, so previous versions will continue to work. On the other hand, changes to previous functionality (for example, to improve performance, address security issues, or fix bugs) can cause compatibility problems in existing code or existing applications that run under a later version.

Each app targets a specific version of the .NET Framework by:

- Defining a target framework in Visual Studio.
- Specifying the target framework in a project file.
- Applying a <xref:System.Runtime.Versioning.TargetFrameworkAttribute> to the source code.

When migrating from one version of the .NET Framework to another, there are two types of changes to consider:

- [Runtime changes](#runtime-changes)
- [Retargeting changes](#retargeting-changes)

## Runtime changes

Runtime issues are those that arise when a new runtime is placed on a machine and an app's behavior changes. When running on a newer version than what was targeted, the .NET Framework uses *quirked* behavior to mimic the older targeted version. The app runs on the newer version but acts as if it's running on the older version. Many of the compatibility issues between versions of the .NET Framework are mitigated through this quirking model. For example, if a binary was compiled for .NET Framework 4.0 but runs on a machine with .NET Framework 4.5 or later, it runs in .NET Framework 4.0 compatibility mode. This means that many of the changes in the later version don't affect the binary.

The version of the .NET Framework that an application targets is determined by the target version of the entry assembly for the application domain that the code runs in. All additional assemblies loaded in that application domain target that version. For example, in the case of an executable, the version that the executable targets is the compatibility mode all assemblies in that application domain run under.

To see a list of runtime changes that apply to your environment, select the .NET Framework version you're currently targeting and then the version you wish to migrate to:

[!INCLUDE[versionselector](../../../includes/migration-guide/runtime/versionselector.md)]

## Retargeting changes

Retargeting changes are those that arise when an assembly is recompiled to target a newer version. Targeting a newer version means the assembly opts into the new features as well as potential compatibility issues for old features.

To see a list of retargeting changes that apply to your environment, select the .NET Framework version you're currently targeting and then the version you wish to migrate to:

[!INCLUDE[versionselector](../../../includes/migration-guide/retargeting/versionselector.md)]

## Impact classification

In the topics that describe runtime and retargeting changes, for example, [Retargeting changes for migrating from 4.7.2 to 4.8](retargeting/4.7.2-4.8.md), individual items are classified by their expected impact as follows:

**Major**\
A significant change that affects a large number of apps or that requires substantial modification of code.

**Minor**\
A change that affects a small number of apps or that requires minor modification of code.

**Edge case**\
A change that affects apps under very specific scenarios that are not common.

**Transparent**\
A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.

## See also

- [Versions and dependencies](versions-and-dependencies.md)
- [What's new](../whats-new/index.md)
- [What's obsolete](../whats-new/whats-obsolete.md)
