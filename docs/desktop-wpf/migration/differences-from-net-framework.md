---
title: Differences between .NET Framework WPF - .NET Core Desktop
description: Describes the differences between the .NET Framework implementation of Windows Presentation Foundation (WPF) and .NET Core WPF. When migrating your app, you should consider these incompatibilities.
author: thraka
ms.date: 09/21/2019
ms.author: adegeo
---

# Differences in .NET Core WPF

This article describes the differences between .NET Framework's implementation of Windows Presentation Foundation (WPF) and .NET Core's implementation of WPF. .NET Core's implementation of WPF is based on the open-source release hosted on [GitHub](https://github.com/dotnet/wpf).

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

## NuGet package references

If your .NET Framework app lists its NuGet dependencies in a *packages.config* file, migrate to the [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) format.

01. In Visual Studio, find the *Solution Explorer* pane.
01. With your WPF app, right-click **packages.config** > **Migrate packages.config to PackageReference**.

![Upgrading to PackageReference](media/differences-from-net-framework/package-reference-migration.png)

A dialog will appear showing calculated top-level NuGet dependencies and asking which other NuGet packages should be promoted to top level. Click **Ok** and the *packages.config* file will be removed from the project and `<PackageReference>` elements will be added to the project file.

When your project uses `<PackageReference>`, packages aren't stored locally in a *packages* folder, they're stored globally. Open the project file and remove any `<Analyzer>` elements that referred to the *packages* folder. These analyzers are automatically included with the NuGet package references.

## Code Access Security (CAS)

WPF no longer supports Code Access Security (CAS) as .NET Core doesn't support it. All CAS-related functionality is treated under the assumption of full-trust. Therefore, WPF has been removing CAS-related code. The public API surface of these types still exists to ensure that calls into these types succeed. However, these calls don't actually do anything.

Publicly defined CAS-related types were moved out of the WPF assemblies and into the CoreFX assemblies. The WPF assemblies have type-forwarding set to the new location of the moved types.

| Source Assembly | Target Assembly | Type                |
| --------------- | --------------- | ------------------- |
| **WindowsBase.dll** | **System.Security.Permissions.dll** | <xref:System.Security.Permissions.MediaPermission> |
|                     |                                     | <xref:System.Security.Permissions.MediaPermissionAttribute> |
|                     |                                     | <xref:System.Security.Permissions.MediaPermissionAudio> |
|                     |                                     | <xref:System.Security.Permissions.MediaPermissionImage> |
|                     |                                     | <xref:System.Security.Permissions.MediaPermissionVideo> |
|                     |                                     | <xref:System.Security.Permissions.WebBrowserPermission> |
|                     |                                     | <xref:System.Security.Permissions.WebBrowserPermissionAttribute> |
|                     |                                     | <xref:System.Security.Permissions.WebBrowserPermissionLevel> |
| **System.Xaml.dll** | **System.Security.Permissions.dll** | <xref:System.Xaml.Permissions.XamlLoadPermission> |
| **System.Xaml.dll** | **System.Windows.Extension.dll**    | <xref:System.Xaml.Permissions.XamlAccessLevel><br/> |

> [!NOTE]
> In order to minimize porting friction, the functionality for storing and retrieving information related to the following properties were retained in the `XamlAccessLevel` type.  
> - `PrivateAccessToTypeName`
> - `AssemblyNameString`

## Next steps

- [Learn how to port a .NET Framework WPF app to .NET Core.](convert-project-from-net-framework)
