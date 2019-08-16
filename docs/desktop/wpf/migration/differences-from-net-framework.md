---
title: WPF - .NET Core
description: Learn how to ...
author: thraka
ms.date: 01/01/1900
ms.author: adegeo
---

# Do something

First paragraph


**Code Access Security (CAS)**

WPF no longer supports Code Access Security (CAS) which is in accordance with .NET Core. This means that all CAS related functionality will now be treated as a no-op and everything operated under the assumption of full trust. Due to this, WPF has been moving to remove CAS related code. We hollowed out and moved publicly defined CAS related types out of WPF assemblies into CoreFX assemblies. The original WPF assemblies now have type forwarding to the new location of the moved types. 

The following list of types were hollowed out and moved from `WindowsBase.dll` to `System.Security.Permissions.dll` 

- MediaPermission 
- MediaPermissionAttribute 
- MediaPermissionAudio 
- MediaPermissionImage 
- MediaPermissionVideo 
- WebBrowserPermission 
- WebBrowserPermissionAttribute 
- WebBrowserPermissionLevel 


The following type was hollowed out and moved from `System.Xaml.dll` to `System.Security.Permissions.dll` 
- XamlLoadPermission 

The following type was hollowed out moved from `System.Xaml.dll` to `System.Windows.Extension.dll`.  
- XamlAccessLevel

    **Note:** In order to minimize porting friction, the functionality for storing and retrieving information related to the following properties were retained in the `XamlAccessLevel` type.  
    - public string PrivateAccessToTypeName 
    - internal string AssemblyNameString 

    For more information here is the location of the moved type: https://github.com/dotnet/corefx/blob/master/src/System.Windows.Extensions/src/System/Xaml/Permissions/XamlAccessLevel.cs 


You can diff the two files below for an example of how the `MediaPermission` type has changed after hollowing out. 
**Before:** 
https://github.com/dotnet/wpf/blob/56ccaad970cefa576396e2aba8e19fa88d9b5f51/src/Microsoft.DotNet.Wpf/src/WindowsBase/System/Security/Permissions/MediaPermission.cs 
**After:** 
https://github.com/dotnet/corefx/blob/df5bb8e4509ca5166f83abbd4cfe4a063