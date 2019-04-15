---
title: "How to: Determine which .NET Framework versions are installed"
ms.date: "04/02/2019"
dev_langs: 
  - "csharp"
  - "vb"
ms.custom: "updateeachrelease"
helpviewer_keywords: 
  - "versions, determining for .NET Framework"
  - ".NET Framework, determining version"
ms.assetid: 40a67826-e4df-4f59-a651-d9eb0fdc755d
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Determine which .NET Framework versions are installed

Users can [install](https://docs.microsoft.com/dotnet/framework/install) and run multiple versions of the .NET Framework on their computers. When you develop or deploy your app, you might need to know which .NET Framework versions are installed on the user’s computer. 

The .NET Framework consists of two main components, which are versioned separately:  
  
- A set of assemblies, which are collections of types and resources that provide the functionality for your apps. The .NET Framework and assemblies share the same version number.  
  
- The common language runtime (CLR), which manages and executes your app's code. The CLR is identified by its own version number (see [Versions and Dependencies](~/docs/framework/migration-guide/versions-and-dependencies.md)).  

> [!NOTE]
> Each new version of the .NET Framework retains features from the previous versions and adds new features. You can load multiple versions of the .NET Framework on a single computer at the same time, which means that you can install the .NET Framework without having to uninstall previous versions. In general, you shouldn't uninstall previous versions of the .NET Framework, because an application you use may depend on a specific version and may break if that version is removed.
>
> There is a difference between the .NET Framework version and the CLR version: 
> - The .NET Framework version is based on the set of assemblies that form the .NET Framework class library. For example, .NET Framework versions include 4.5, 4.6.1, and 4.7.2. 
>- The CLR version is based on the runtime on which .NET Framework applications execute. A single CLR version typically supports multiple .NET Framework versions. For example, CLR version 4.0.30319.*xxxxx* supports .NET Framework versions 4 through 4.5.2 and CLR version 4.0.30319.42000 supports .NET Framework versions starting with .NET Framework 4.6. 
>
> For more information about versions, see [.NET Framework versions and dependencies](versions-and-dependencies.md).

To get a list of the .NET Framework versions installed on a computer, you access the registry. You can either use the Registry Editor to view the registry or use code to query it:
 
- Find newer .NET Framework versions (4.5 and later): 
     - [Use the Registry Editor to find .NET Framework versions](#net_b)  
     - [Use code to query the registry for .NET Framework versions](#net_d)  
     - [Use PowerShell to query the registry for .NET Framework versions](#ps_a)
- Find older .NET Framework versions (1&#8211;4):
     - [Use the Registry Editor to find .NET Framework versions](#net_a)
     - [Use code to query the registry for .NET Framework versions](#net_c)   

To get a list of the CLR versions installed on a computer, use a tool or code:  
  
- [Use the Clrver tool](#clr_a)  
- [Use code to query the Environment class](#clr_b)  

For information about detecting the installed updates for each version of the .NET Framework, see [How to: Determine which .NET Framework updates are installed](how-to-determine-which-net-framework-updates-are-installed.md). 

## Find newer .NET Framework versions (4.5 and later)

<a name="net_b"></a> 
### Find .NET Framework versions 4.5 and later in the registry

1. From the **Start** menu, choose **Run**, enter *regedit*, and then select **OK**.

     You must have administrative credentials to run regedit.

2. In the Registry Editor, open the following subkey: **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full**. If the **Full** subkey isn't present, then you don't have the .NET Framework 4.5 or later installed.

    > [!NOTE]
    > The **NET Framework Setup** folder in the registry does *not* begin with a period.

3. Check for a DWORD entry named **Release**. If it exists, then you have .NET Framework 4.5 or later versions installed. Its value is a release key that corresponds to a particular version of the .NET Framework. In the following figure, for example, the value of the **Release** entry is *378389*, which is the release key for .NET Framework 4.5. 

     ![Registry entry for the .NET Framework 4.5](media/clr-installdir.png "Registry entry for the .NET Framework 4.5")

The following table lists the value of the **Release** DWORD on individual operating systems for .NET Framework 4.5 and later versions.

[!INCLUDE[Release key values note](~/includes/version-keys-note.md)]

<a name="version_table"></a>

|.NET Framework version|Value of the Release DWORD|
|--------------------------------|-------------|
|.NET Framework 4.5|All Windows operating systems: 378389|
|.NET Framework 4.5.1|On Windows 8.1 and Windows Server 2012 R2: 378675<br />On all other Windows operating systems: 378758|
|.NET Framework 4.5.2|All Windows operating systems: 379893|
|.NET Framework 4.6|On Windows 10: 393295<br />On all other Windows operating systems: 393297|
|.NET Framework 4.6.1|On Windows 10 November Update systems: 394254<br />On all other Windows operating systems (including Windows 10): 394271|
|.NET Framework 4.6.2|On Windows 10 Anniversary Update and Windows Server 2016: 394802<br />On all other Windows operating systems (including other Windows 10 operating systems): 394806|
|.NET Framework 4.7|On Windows 10 Creators Update: 460798<br />On all other Windows operating systems (including other Windows 10 operating systems): 460805| 
|.NET Framework 4.7.1|On Windows 10 Fall Creators Update and Windows Server, version 1709: 461308<br/>On all other Windows operating systems (including other Windows 10 operating systems): 461310|
|.NET Framework 4.7.2|On Windows 10 April 2018 Update and Windows Server, version 1803: 461808<br/>On all Windows operating systems other than Windows 10 April 2018 Update and Windows Server, version 1803: 461814|  

You can use these values as follows:

- To determine whether a specific version of the .NET Framework is installed on a particular version of the Windows operating system, test whether the **Release** DWORD value is *equal to* the value listed in the table. For example, to determine whether .NET Framework 4.6 is present on a Windows 10 system, test for the a **Release** value that is *equal to* 393295.

- To determine whether a minimum version of the .NET Framework is present, use the smaller **RELEASE** DWORD value for that version. For example, if your application runs under .NET Framework 4.6 or a later version, test for a **RELEASE** DWORD value that is *greater than or equal to* 393295. For a table that lists only the minimum **RELEASE** DWORD value for each .NET Framework version, see [The minimum values of the Release DWORD for .NET Framework 4.5 and later versions](minimum-release-dword.md).

- To test for multiple versions, begin by testing for a value that is *greater than or equal to* the smaller DWORD value for the latest .NET Framework version, and then compare the value with the smaller DWORD value for each successive earlier version. For example, if your application requires .NET Framework 4.7 or later and you want to determine the specific version of .NET Framework present, start by testing for a **RELEASE** DWORD value that is *great than or equal to* to 461808 (the smaller DWORD value for .NET Framework 4.7.2). Then compare the **RELEASE** DWORD value with the smaller value for each later .NET Framework version. For a table that lists only the minimum **RELEASE** DWORD value for each .NET Framework version, see [The minimum values of the Release DWORD for .NET Framework 4.5 and later versions](minimum-release-dword.md).

<a name="net_d"></a> 
### Find .NET Framework versions 4.5 and later with code

1. Use the <xref:Microsoft.Win32.RegistryKey.OpenBaseKey%2A?displayProperty=nameWithType> and <xref:Microsoft.Win32.RegistryKey.OpenSubKey%2A?displayProperty=nameWithType> methods to access the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full** subkey in the Windows registry.

    The existence of the **Release** DWORD entry in the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full** subkey indicates that the .NET Framework 4.5 or a later version is installed on a computer. 

2. Check the value of the **Release** entry to determine the installed version. To be forward-compatible, check for a value greater than or equal to the value listed in the [.NET Framework version table](#version_table).

The following example checks the value of the **Release** entry in the registry to find the .NET Framework 4.5 and later versions that are installed:

[!code-csharp[ListVersions#5](../../../samples/snippets/csharp/framework/migration-guide/versions-installed3.cs)]
[!code-vb[ListVersions#5](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed3.vb)]

This example follows the recommended practice for version checking:

- It checks whether the value of the **Release** entry is *greater than or equal to* the value of the known release keys.

- It checks in order from most recent version to earliest version.

<a name="ps_a"></a> 
### Check for a minimum-required .NET Framework version (4.5 and later) with PowerShell

- Use PowerShell commands to check the value of the **Release** entry of the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full** subkey.

The following examples check the value of the **Release** entry to determine whether the .NET Framework 4.6.2 or later is installed. This code returns `True` if it's installed and `False` otherwise.

```PowerShell
# PowerShell 5
 Get-ChildItem 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\' |  Get-ItemPropertyValue -Name Release | Foreach-Object { $_ -ge 394802 } 
 ```

```PowerShell
# PowerShell 4
(Get-ItemProperty "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Release -ge 394802
```

To check for a different minimum-required .NET Framework version, replace *394802* in these examples with a **Release** value from the [.NET Framework version table](#version_table).

## Find older .NET Framework versions (1&#8211;4)

<a name="net_a"></a>
### Find .NET Framework versions 1&#8211;4 in the registry 
  
1. From the **Start** menu, choose **Run**, enter *regedit*, and then select **OK**.
  
    You must have administrative credentials to run regedit.  

2. In the Registry Editor, open the following subkey: **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP**:  

    - For .NET Framework versions 1.1 through 3.5, each installed version is listed as a subkey under the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP** subkey. For example, **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5**. The version number is stored as a value in the version subkey's **Version** entry. 
     
    - For .NET Framework 4, the **Version** entry is under the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4.0\Client** subkey, the **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4.0\Full** subkey, or under both subkeys.

    > [!NOTE]
    > The **NET Framework Setup** folder in the registry does not begin with a period.

    The following figure shows the subkey and its **Version** entry for the .NET Framework 3.5.

    ![The registry entry for the .NET Framework 3.5.](media/net-4-and-earlier.png ".NET Framework 3.5 and earlier versions")

<a name="net_c"></a> 
### Find .NET Framework versions 1&#8211;4 with code

- Use the <xref:Microsoft.Win32.RegistryKey?displayProperty=nameWithType> class to access the **HKEY_LOCAL_MACHINE\Software\Microsoft\NET Framework Setup\NDP** subkey in the Windows registry.

The following example finds the .NET Framework 1&#8211;4 versions that are installed:

[!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed1.cs)]
[!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed1.vb)]

## Find CLR versions
  
<a name="clr_a"></a> 
### Find the current CLR version with Clrver.exe

Use the [CLR Version tool (Clrver.exe)](../tools/clrver-exe-clr-version-tool.md) to determine which versions of the CLR are installed on a computer:

- From a [Developer Command Prompt for Visual Studio](https://docs.microsoft.com/dotnet/framework/tools/developer-command-prompt-for-vs), enter `clrver`.

    Sample output:

    ```console
    Versions installed on the machine:
    v2.0.50727
    v4.0.30319
    ```

<a name="clr_b"></a> 
### Find the current CLR version with the Environment class

> [!IMPORTANT]
> For the .NET Framework 4.5 and later versions, don't use the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to detect the version of the CLR. Instead, query the registry as described in [Find .NET Framework versions 4.5 and later with code](#net_d).

1. Query the <xref:System.Environment.Version?displayProperty=nameWithType> property to retrieve a <xref:System.Version> object. 

    The returned `System.Version` object identifies the version of the runtime that's currently executing the code. It doesn't return assembly versions or other versions of the runtime that may have been installed on the computer.

    For the .NET Framework versions 4, 4.5, 4.5.1, and 4.5.2, the string representation of the returned <xref:System.Version> object has the form 4.0.30319.*xxxxx*. For the .NET Framework 4.6 and later versions, it has the form 4.0.30319.42000.    

2. After you have the `Version` object, query it as follows:

   - For the major release identifier (for example, *4* for version 4.0), use the <xref:System.Version.Major%2A?displayProperty=nameWithType> property.

   - For the minor release identifier (for example, *0* for version 4.0), use the <xref:System.Version.Minor%2A?displayProperty=nameWithType> property.

   - For the entire version string (for example, *4.0.30319.18010*), use the <xref:System.Version.ToString%2A?displayProperty=nameWithType> method. This method returns a single value that reflects the version of the runtime that's executing the code. It doesn't return assembly versions or other runtime versions that may be installed on the computer.

The following example uses the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to retrieve CLR version information:

[!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed2.cs)]
[!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed2.vb)]

## See also

- [How to: Determine which .NET Framework updates are installed](how-to-determine-which-net-framework-updates-are-installed.md)
- [Install the .NET Framework for developers](../install/guide-for-developers.md)
- [.NET Framework versions and dependencies](versions-and-dependencies.md)
