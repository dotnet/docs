---
title: Differences between .NET Framework WPF - .NET Core Desktop
description: Describes the differences between the .NET Framework implementation of WPF and .NET Core WPF. When migrating your app, you should consider these incompatibilities.
author: thraka
ms.date: 09/21/2019
ms.author: adegeo
---

# Differences in .NET Core WPF

This article describes the differences between .NET Framework's implementation of Windows Presentation Foundation (WPF) and .NET Core's implementation of WPF. .NET Core's implementation of WPF is based on the open source release hosted on [GitHub]().

[!INCLUDE [desktop guide under construction](../../../includes/desktop-guide-preview-note.md)]

## Code Access Security (CAS)

WPF no longer supports Code Access Security (CAS) which is in accordance with .NET Core. This means that all CAS related functionality will now be treated as a no-op and everything operated under the assumption of full trust. Due to this, WPF has been moving to remove CAS related code. Publicly defined CAS related types were moved out of the WPF assemblies and into the CoreFX assemblies. The original WPF assemblies now have type forwarding to the new location of the moved types.

| Type | Source Assembly | Target Assembly |
| ---- | --------------- | --------------- |

| Source Assembly | Target Assembly | Type |
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
| **System.Xaml.dll** | **System.Windows.Extension.dll**    | <xref:System.Xaml.Permissions.XamlAccessLevel> |

The following list of types were moved from `WindowsBase.dll` to `System.Security.Permissions.dll`

- <xref:System.Security.Permissions.MediaPermission>
- <xref:System.Security.Permissions.MediaPermissionAttribute>
- <xref:System.Security.Permissions.MediaPermissionAudio>
- <xref:System.Security.Permissions.MediaPermissionImage>
- <xref:System.Security.Permissions.MediaPermissionVideo>
- <xref:System.Security.Permissions.WebBrowserPermission>
- <xref:System.Security.Permissions.WebBrowserPermissionAttribute>
- <xref:System.Security.Permissions.WebBrowserPermissionLevel>

The following type was hollowed out and moved from `System.Xaml.dll` to `System.Security.Permissions.dll`
- <xref:System.Xaml.Permissions.XamlLoadPermission>

The following type was hollowed out moved from `System.Xaml.dll` to `System.Windows.Extension.dll`.  
- <xref:System.Xaml.Permissions.XamlAccessLevel>

    **Note:** In order to minimize porting friction, the functionality for storing and retrieving information related to the following properties were retained in the `XamlAccessLevel` type.  
    - public string PrivateAccessToTypeName 
    - internal string AssemblyNameString 

    For more information here is the location of the moved type: https://github.com/dotnet/corefx/blob/master/src/System.Windows.Extensions/src/System/Xaml/Permissions/XamlAccessLevel.cs 


You can diff the two files below for an example of how the `MediaPermission` type has changed after hollowing out. 

**Before:** 
https://github.com/dotnet/wpf/blob/56ccaad970cefa576396e2aba8e19fa88d9b5f51/src/Microsoft.DotNet.Wpf/src/WindowsBase/System/Security/Permissions/MediaPermission.cs 

**After:** 
https://github.com/dotnet/corefx/blob/df5bb8e4509ca5166f83abbd4cfe4a063433fee7/src/System.Security.Permissions/src/System/Security/Permissions/MediaPermission.cs