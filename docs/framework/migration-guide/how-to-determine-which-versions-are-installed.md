---
title: "How to: Determine which .NET Framework versions are installed"
ms.date: "02/20/2019"
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

Users can install and run multiple versions of the .NET Framework on their computers. When you develop or deploy your app, you might need to know which .NET Framework versions are installed on the user’s computer. Note that the .NET Framework consists of two main components, which are versioned separately:  
  
- A set of assemblies, which are collections of types and resources that provide the functionality for your apps. The .NET Framework and assemblies share the same version number.  
  
- The common language runtime (CLR), which manages and executes your app's code. The CLR is identified by its own version number (see [Versions and Dependencies](~/docs/framework/migration-guide/versions-and-dependencies.md)).  
  
To get an accurate list of the .NET Framework versions installed on a computer, you can view the registry or query the registry in code:  
  
 [Find .NET Framework versions 1-4 in the registry](#net_a)  
 [Find .NET Framework versions 4.5 and later in the registry)](#net_b)  
 [Using code to query the registry (versions 1-4)](#net_c)  
 [Using code to query the registry (version 4.5 and later)](#net_d)  
 [Using PowerShell to query the registry (version 4.5 and later)](#ps_a)  

 To find the CLR version, you can use a tool or code:  
  
 [Using the Clrver tool](#clr_a)  
 [Using code to query the System.Environment class](#clr_b)  

> [!NOTE]
> There is a difference between the .NET Framework version and the common language runtime (CLR) version. The .NET Framework is versioned based on the set of assemblies that form the .NET Framework Class Library. For example, .NET Framework versions include 4.5, 4.6.1, and 4.7.2. The CLR is versioned based on the runtime on which .NET Framework applications execute, and a single CLR version typically supports multiple .NET Framework versions. CLR version 4.30319.*xxxxx* supports .NET Framework versions 4 through 4.5.2; CLR version 4.30319.42000 supports .NET Framework versions starting with .NET Framework 4.6. For more information, see the <xref:System.Environment.Version?displayProperty=nameWithType> property.

 For information about detecting the installed updates for each version of the .NET Framework, see [How to: Determine Which .NET Framework Updates Are Installed](~/docs/framework/migration-guide/how-to-determine-which-net-framework-updates-are-installed.md). For information about installing the .NET Framework, see [Install the .NET Framework for developers](../../../docs/framework/install/guide-for-developers.md).  
  
<a name="net_a"></a>   
## Find .NET Framework versions 1-4 in the registry 
  
1.  On the **Start** menu, choose **Run**.  
  
2.  In the **Open** box, enter **regedit.exe**.  
  
     You must have administrative credentials to run regedit.exe.  
  
3.  In the Registry Editor, open the following subkey:  
  
     `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP`  
  
     For .NET Framework versions 1.1 through 3.5, the installed versions are listed as subkeys under the `NDP` subkey. The version number is stored in the version subkey's **Version** entry. 
     
     For .NET Framework 4, the **Version** entry is under the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4.0\Client` subkey, the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4.0\Full` subkey, or under both subkeys.

    > [!NOTE]
    > The "NET Framework Setup" folder in the registry does not begin with a period.

    The following figure shows that the subkey for the .NET Framework 3.5 along with its **Version** entry.

     ![The registry entry for the .NET Framework 3.5.](../../../docs/framework/migration-guide/media/net-4-and-earlier.png ".NET Framework 4 and earlier versions")

<a name="net_b"></a> 
## Find .NET Framework versions 4.5 and later in the registry

1. On the **Start** menu, choose **Run**.

2. In the **Open** box, enter **regedit.exe**.

     You must have administrative credentials to run regedit.exe.

3. In the Registry Editor, open the following subkey:

     `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full`

     Note that the path to the `Full` subkey includes the subkey `Net Framework` rather than `.NET Framework`.

    > [!NOTE]
    > If the `Full` subkey is not present, then you do not have the .NET Framework 4.5 or later installed.

     Check for a DWORD value named `Release`. The existence of the `Release` DWORD indicates that .NET Framework 4.5 or later has been installed on that computer. Its value is a release key that corresponds to a particular version of .NET Framework. In the following figure, for example, the value of the `Release` DWORD is 378389, which is the release key for .NET Framework 4.5. 

     ![The registry entry for the .NET Framework 4.5.](../../../docs/framework/migration-guide/media/clr-installdir.png "CLR_InstallDir")

The following table lists the minimum value of the `Release` DWORD for each .NET Framework version. You can use these values as follows:

- To determine whether a minimum .NET Framework version is present, test whether the `Release` DWORD value found in the registry is *greater than or equal to* the value listed in the table. For example, if your application requires .NET Framework 4.7 or later, you would test for a minimum release key value of 460798.

- To test for multiple versions, begin with the latest .NET Framework version, and then test for each successive earlier version.

[!INCLUDE[Release key values note](~/includes/version-keys-note.md)]

|.NET Framework Version|Value of the Release DWORD|
|--------------------------------|-------------|
|.NET Framework 4.5|378389|
|.NET Framework 4.5.1|378675|
|.NET Framework 4.5.2|379893|
|.NET Framework 4.6|393295|
|.NET Framework 4.6.1|394254|
|.NET Framework 4.6.2|394802|
|.NET Framework 4.7|460798|
|.NET Framework 4.7.1|461308|
|.NET Framework 4.7.2|461808|

For a complete table of release keys for the .NET Framework for specific Windows operating system versions, see [.NET Framework release keys and Windows operating system versions](release-keys-and-os-versions.md).

<a name="net_c"></a> 
## Find .NET Framework versions 1-4 with code

- Use the <xref:Microsoft.Win32.RegistryKey?displayProperty=nameWithType> class to access the `Software\Microsoft\NET Framework Setup\NDP\` subkey under `HKEY_LOCAL_MACHINE` branch in the Windows registry.

     The following code shows an example of this query.

    > [!NOTE]
    > This code does not show how to detect .NET Framework 4.5 or later. Check the `Release` DWORD to detect those versions, as described in the previous section. For code that detects .NET Framework 4.5 or later versions, see the next section in this article.

     [!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed1.cs)]
     [!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed1.vb)]

<a name="net_d"></a> 
## Find .NET Framework versions 4.5 and later with code

1. The existence of the `Release` DWORD in the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full` key indicates that the .NET Framework 4.5 or later is installed on a computer. The value of the keyword indicates the installed version. To check this keyword, use the <xref:Microsoft.Win32.RegistryKey.OpenBaseKey%2A?displayProperty=nameWithType> and <xref:Microsoft.Win32.RegistryKey.OpenSubKey%2A?displayProperty=nameWithType> methods to access the subkey in the Windows registry.

2. Check the value of the `Release` keyword to determine the installed version. To be forward-compatible, you can check for a value greater than or equal to the value listed in the table in the [Find .NET Framework versions 4.5 and later in the registry](#net_b) section.

The following example checks the `Release` value in the registry to determine whether .NET Framework 4.5 or a later version is installed.

[!code-csharp[ListVersions#5](../../../samples/snippets/csharp/framework/migration-guide/versions-installed3.cs)]
[!code-vb[ListVersions#5](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed3.vb)]

This example follows the recommended practice for version checking:

- It checks whether the value of the `Release` entry is *greater than or equal to* the value of the known release keys.

- It checks in order from most recent version to earliest version.

<a name="ps_a"></a> 
## Check for a minimum required .NET Framework version (4.5 and later) with PowerShell

The following example checks the value of the `Release` keyword to determine whether .NET Framework 4.6.2 or higher is installed (returning `True` if it is and `False` otherwise).

    ```PowerShell
    # PowerShell 5
    Get-ChildItem 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\' | Get-ItemPropertyValue -Name Release | Foreach-Object { $_ -ge 394802 } 
    ```

    ```PowerShell
    # PowerShell 4
    (Get-ItemProperty "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Release -gt 394802
    ```

    You can replace `394802` in the previous example with another value from the following table in the [Find .NET Framework versions 4.5 and later in the registry](#net_b) section to check for a different minimum required .NET Framework version.
  
<a name="clr_a"></a> 
## Find the current CLR version with Clrver.exe

Use the CLR Version Tool (Clrver.exe) to determine which versions of the common language runtime are installed on a computer.

From a Developer Command Prompt for Visual Studio, enter `clrver`. This command produces output similar to the following:

```console
Versions installed on the machine:
v2.0.50727
v4.0.30319
```

For more information about using this tool, see [Clrver.exe (CLR Version Tool)](~/docs/framework/tools/clrver-exe-clr-version-tool.md).

<a name="clr_b"></a> 
## Find the current CLR version with the Environment class

You can retrieve the value of the <xref:System.Environment.Version?displayProperty=nameWithType> property to retrieve a <xref:System.Version> object that identifies the version of the runtime that is currently executing the code. This property returns a single value that reflects the version of the runtime that is currently executing the code; it does not return assembly versions or other versions of the runtime that may have been installed on the computer.You can use the <xref:System.Version.Major%2A?displayProperty=nameWithType> property to get the major release identifier (for example, "4" for version 4.0), the <xref:System.Version.Minor%2A?displayProperty=nameWithType> property to get the minor release identifier (for example, "0" for version 4.0), or the <xref:System.Version.ToString%2A?displayProperty=nameWithType> method to get the entire version string (for example, "4.0.30319.18010", as shown in the following code). 

For the .NET Framework Versions 4, 4.5, 4.5.1, and 4.5.2, the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property returns a <xref:System.Version> object whose string representation has the form `4.0.30319.xxxxx`. For the .NET Framework 4.6 and later, it has the form `4.0.30319.42000`.

> [!IMPORTANT]
> For the .NET Framework 4.5 and later, we do not recommend using the  <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to detect the version of the runtime. Instead, we recommend that you query the registry, as described in the [To find .NET Framework versions by querying the registry in code (.NET Framework 4.5 and later)](#net_d) section earlier in this article.

The following example used the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to retrieve runtime version information:

[!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed2.cs)]
[!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed2.vb)]

## See also

- [How to: Determine Which .NET Framework Updates Are Installed](~/docs/framework/migration-guide/how-to-determine-which-net-framework-updates-are-installed.md)
- [Install the .NET Framework for developers](../../../docs/framework/install/guide-for-developers.md)
- [Versions and Dependencies](~/docs/framework/migration-guide/versions-and-dependencies.md)
