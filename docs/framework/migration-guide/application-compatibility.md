---
title: Application Compatibility in the .NET Framework
ms.custom: ""
ms.date: "05/19/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
  - "app-compat"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "application compatibility"
  - ".NET Framework application compatibility"
  - ".NET Framework changes"
caps.latest.revision: 19
ms.assetid: c4ba3ff2-fe59-4c5d-9e0b-86bba3cd865c
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Application Compatibility in the .NET Framework

## Introduction
Compatibility is a very important goal of each .NET release. Compatibility
ensures that each version is additive, so previous versions will still work. On
the other hand, changes to previous functionality (to improve performance,
address security issues, or fix bugs) can cause compatibility problems in
existing code or existing applications that run under a later version. The .NET
Framework recognizes retargeting changes and runtime changes. Retargeting
changes affect applications that target a specific version of the .NET Framework
but are running on a later version. Runtime changes affect all applications
running on a particular version.

Each app targets a specific version of the .NET Framework, which can be specified by:

* Defining a target framework in Visual Studio.
* Specifying the target framework in a project file.
* Applying a <xref:System.Runtime.Versioning.TargetFrameworkAttribute> to the source code.

When running on a newer version than what was targeted, the .NET Framework will
use quirked behavior to mimic the older targeted version. In other words, the
app will run on the newer version of the Framework, but act as if it's running
on the older version. Many of the compatibility issues between versions of the .NET
Framework are mitigated through this quirking model.

## Runtime changes

Runtime issues are those that arise when a new runtime is placed on a machine
and the same binaries are run, but different behavior is seen. If a binary was
compiled for .NET Framework 4.0 it will run in .NET Framework 4.0 compatibility
mode on 4.5 or later versions. Many of the changes that affect 4.5 will not
affect a binary compiled for 4.0. This is specific to the AppDomain and depends
on the settings of the entry assembly.

## Retargeting changes

Retargeting issues are those that arise when an assembly that was targeting 4.0
is now set to target 4.5. Now the assembly opts into the new features as well as
potential compatibility issues to old features. Again, this is dictated by the entry
assembly, so the console app that uses the assembly, or the website that
references the assembly.

## .NET Compatibility Diagnostics

The .NET Compatibility Diagnostics are Roslyn-powered analyzers that help
identify application compatibility issues between versions of the .NET
Framework. This list contains all of the analyzers available, although only a
subset will apply to any specific migration. The analyzers will determine which
issues are applicable for the planned migration and will only surface those.

Each issue includes the following information:

-   The description of what has changed from a previous version.

-   How the change affects customers and whether any workarounds are available to preserve compatibility across versions.

-   An assessment of how important the change is. Application compatibility issue are categorized as follows:

    |   |   |
    |---|---|
    |Major|A significant change that affects a large number of apps or requires substantial modification of code.|
    |Minor|A change that affects a small number of apps or that requires minor modification of code.|
    |Edge case|A change that affects apps under very specific, uncommon scenarios.|
    |Transparent|A change with no noticeable effect on the application's developer or user.|

-   Version indicates when the change first appears in the framework. Some of the changes are introduced in a particular version and reverted in a later version; that is indicated as well.

-   The type of change:

    |   |   |
    |---|---|
    |Retargeting|The change affects apps that are recompiled to target a new version of the .NET Framework.|
    |Runtime|The change affects an existing app that targets a previous version of the .NET Framework but runs on a later version.|

-   The affected APIS, if any.

-   The IDs of the available diagnostics

## Usage
To begin, select the type of compatibility change below:

* [Retargeting Changes](./retargeting/index.md)
* [Runtime Changes](./runtime/index.md)


## See Also

* [Versions and Dependencies](../../../docs/framework/migration-guide/versions-and-dependencies.md)
* [What's New](../../../docs/framework/whats-new/index.md)
* [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md)
