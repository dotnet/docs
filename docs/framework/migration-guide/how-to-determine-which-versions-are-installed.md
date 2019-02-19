---
title: "How to: Determine which .NET Framework versions are installed"
ms.date: "02/15/2019"
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

When users [install the .NET Framework](../install/guide-for-developers.md), they can install and run multiple versions of it on their computers. For an app that you develop or deploy to run properly, it might need to know which .NET Framework versions are installed on a user’s computer. 

The .NET Framework consists of two main components, which are versioned separately:  
  
-   A set of assemblies, which are collections of types and resources that provide the functionality for your apps. The .NET Framework and assemblies share the same version number.  
  
-   The common language runtime (CLR), which manages and executes your app's code. The CLR is identified by its own version number. For more information, see [.NET Framework versions and dependencies](versions-and-dependencies.md).  
  
 To get a list of the .NET Framework versions installed on your computer, you access the registry. You can either use the Registry Editor to view the registry or use code to query it:
  
 - [View the registry for .NET Framework 1&#8211;4](#view-the-registry-for-net-framework-1&#8211;4)  
 - [View the registry for .NET Framework 4.5 and later](#view-the-registry-for-net-framework-4.5-and-later)  
 - [Use code to query the registry for .NET Framework 1&#8211;4](#use-code-to-query-the-registry-for-net-framework-1&#8211;4) 
 - [Use code to query the registry for .NET Framework 4.5 and later](#use-code-to-query-the-registry-for-net-framework-4.5-and-later)  
 - [Use PowerShell to query the registry for .NET Framework 4.5 and later](#use-powershell-to-query-the-registry-for-net-framework-4.5-and-later)  
  
 To find the CLR version, use a tool or code:  
  
 - [Use the Clrver tool](#find-the-clr-version-with-the-clrver-tool)  
 - [Use code to query the System.Environment class](#use-code-to-query-the-systemenvironment-class)  
  
 For information about detecting the installed updates for each version of the .NET Framework, see [How to: Determine which .NET Framework updates are installed](how-to-determine-which-net-framework-updates-are-installed.md). 
  
## View the registry for .NET Framework 1&#8211;4

Find the versions for .NET Framework 1&#8211;4 by using the registry editor: 
  
1.  From the **Start** menu, choose **Run**, enter *regedit*, and then select **OK**.
  
     You must have administrative credentials to run regedit.  
  
2.  In the Registry Editor, open the following subkey: **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP**.
  
     The registry lists the installed versions under the **NDP** subkey and stores the version number for each installation entry in the **Version** entry. For [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the **Version** entry is under the **Client** and **Full** subkeys of the installation entry. For example,  **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full**.
 
    > [!NOTE]
    > The **NET Framework Setup** folder in the registry does not begin with a period.

## View the registry for .NET Framework 4.5 and later

Find the versions for .NET Framework 4.5 and later by using the registry editor: 

1. From the **Start** menu, choose **Run**, enter *regedit*, and then select **OK**.

     You must have administrative credentials to run regedit.

2. In the Registry Editor, open the following subkey: **HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full**.

    > [!NOTE]
    > The path to the **Full** subkey includes the subkey **Net Framework** rather than **.NET Framework**.
    >
    > If the **Full** subkey isn't present, then .NET Framework 4.5 or later isn't installed.

3. Check for a DWORD value named **Release**. If it exists, then the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or later is installed. Its value specifies which version of the .NET Framework is installed.

     ![Registry entry for the .NET Framework 4.5](../../../docs/framework/migration-guide/media/clr-installdir.png "CLR_InstallDir")

    [!INCLUDE[Release key values note](~/includes/version-keys-note.md)]

    |Release DWORD value|Version|
    |--------------------------------|-------------|
    |378389|.NET Framework 4.5|
    |378675|.NET Framework 4.5.1 installed with Windows 8.1 or Windows Server 2012 R2|
    |378758|.NET Framework 4.5.1 installed on Windows 8, Windows 7 SP1, or Windows Vista SP2|
    |379893|.NET Framework 4.5.2|
    |393295: Windows 10 only <br /><br /> 393297: All other OS versions: |[!INCLUDE[net_v46](../../../includes/net-v46-md.md)]|
    |394254: Windows 10 November Update only<br /><br /> 394271: All other OS versions |[!INCLUDE[net_v461](../../../includes/net-v461-md.md)]|
    |394802: Windows 10 Anniversary Update and Windows Server 2016 <br /><br /> 394806: All other OS versions: |[!INCLUDE[net_v462](../../../includes/net-v462-md.md)]| 
    |460798: Windows 10 Creators Update only <br/><br/> 460805: All other OS versions | .NET Framework 4.7 |
    |461308: Windows 10 Fall Creators Update only <br/><br/> 461310: All other OS versions | .NET Framework 4.7.1 |
    |461808: Windows 10 April 2018 Update only <br/><br/> 461814: All other OS versions, including Windows 10 October 2018 Update | .NET Framework 4.7.2 |
    
## Use code to query the registry for .NET Framework 1&#8211;4


Find the versions for .NET Framework 1&#8211;4 by querying the registry in code: 

- Use the <xref:Microsoft.Win32.RegistryKey?displayProperty=nameWithType> class to access the **HKEY_LOCAL_MACHINE\Software\Microsoft\NET Framework Setup\NDP** subkey in the Windows registry.

     The following code shows an example of this query.

     [!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed1.cs)]
     [!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed1.vb)]

     The example produces output that's similar to the following example:

    ```
    v2.0.50727  2.0.50727.4016  SP2
    v3.0  3.0.30729.4037  SP2
    v3.5  3.5.30729.01  SP1
    v4
      Client  4.0.30319
      Full  4.0.30319
    ```

## Use code to query the registry for .NET Framework 4.5 and later

1. The existence of the **Release** DWORD keyword indicates that the .NET Framework 4.5 or later has been installed on your computer. Its value specifies the installed version. To check this keyword, use the <xref:Microsoft.Win32.RegistryKey.OpenBaseKey> and <xref:Microsoft.Win32.RegistryKey.OpenSubKey> methods of the <xref:Microsoft.Win32.RegistryKey?displayProperty=nameWithType> class to access the **HKEY_LOCAL_MACHINE\Software\Microsoft\NET Framework Setup\NDP\v4\Full** subkey in the Windows registry.

2. Check the value of the **Release** keyword to determine the installed version. To be forward-compatible, check for a value greater than or equal to the values listed in the table. The following table shows the **Release** keywords and its associated .NET Framework version.

    [!INCLUDE[Release key values note](~/includes/version-keys-note.md)]

    |Release DWORD value |Version | 
    |-------------|--------------------------------|
    |378389|.NET Framework 4.5|
    |378675|.NET Framework 4.5.1 installed with Windows 8.1|
    |378758|.NET Framework 4.5.1 installed on Windows 8, Windows 7 SP1, or Windows Vista SP2|
    |379893|.NET Framework 4.5.2|
    |393295|.NET Framework 4.6 installed with Windows 10|
    |393297|.NET Framework 4.6 installed on all other Windows OS versions|
    |394254|.NET Framework 4.6.1 installed on Windows 10|
    |394271|.NET Framework 4.6.1 installed on all other Windows OS versions|
    |394802|.NET Framework 4.6.2 installed on Windows 10 Anniversary Update and Windows Server 2016|
    |394806|.NET Framework 4.6.2 installed on all other Windows OS versions|
    |460798|.NET Framework 4.7 installed on Windows 10 Creators Update|
    |460805|.NET Framework 4.7 installed on all other Windows OS versions|
    |461308|.NET Framework 4.7.1 installed on Windows 10 Fall Creators Update|
    |461310|.NET Framework 4.7.1 installed on all other Windows OS versions|
    |461814|.NET Framework 4.7.2 installed on Windows 10 October 2018 Update|
    |461808|.NET Framework 4.7.2 installed on Windows 10 April 2018 Update|
    |461814|.NET Framework 4.7.2 installed on Windows 10 Fall Creators Update and earlier OS versions|
    
     The following example checks the **Release** value in the registry to determine whether the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or a later version of the .NET Framework is installed.

     [!code-csharp[ListVersions#5](../../../samples/snippets/csharp/framework/migration-guide/versions-installed3.cs)]
     [!code-vb[ListVersions#5](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed3.vb)]

     This example follows the recommended practice for version checking:

    - It checks whether the value of the **Release** entry is *greater than or equal to* the value of the known release keys.

    - It checks in order from the most recent version to the earliest version.

## Use PowerShell to query the registry for .NET Framework 4.5 and later

Check for a minimum-required .NET Framework version by querying the registry in PowerShell (.NET Framework 4.5 and later).

- The following example reads the value of the **Release** keyword to determine whether .NET Framework 4.6.2 or later is installed. This code returns `True` if it's installed and `False` if it's not).

    ```PowerShell
    # PowerShell 5
    Get-ChildItem 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\' | Get-ItemPropertyValue -Name Release | Foreach-Object { $_ -ge 394802 } 
    ```

    ```PowerShell
    # PowerShell 4
    (Get-ItemProperty "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Release -gt 394802
    ```

    To check for a different version, replace *394802* in the previous example with a **Release** value from the following table.
  
    |Version|Release DWORD minimum value|
    |-------------|--------------------------------|
    |.NET Framework 4.5|378389|
    |.NET Framework 4.5.1|378675|
    |.NET Framework 4.5.2|379893|
    |[!INCLUDE[net_v46](../../../includes/net-v46-md.md)]|393295|
    |[!INCLUDE[net_v461](../../../includes/net-v461-md.md)]|394254|
    |[!INCLUDE[net_v462](../../../includes/net-v462-md.md)]|394802|
    |.NET Framework 4.7|460798|
    |.NET Framework 4.7.1|461308|
    |.NET Framework 4.7.2|461808|

## Find the CLR version with the Clrver tool

Use the [CLR Version tool (Clrver.exe)](../tools/clrver-exe-clr-version-tool.md) to determine which versions of the common language runtime are installed on a computer:

- From a [Developer Command Prompt for Visual Studio](https://docs.microsoft.com/en-us/dotnet/framework/tools/developer-command-prompt-for-vs), enter `clrver`. This command produces output similar to the following example:

    ```
    Versions installed on the machine:
    v2.0.50727
    v4.0.30319
    ```

## Use code to query the System.Environment class

1. Query the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to retrieve a <xref:System.Version> object. This object identifies the version of the runtime that's currently executing the code. 

2. After you have the `Version' object, query it as follows:

   - For the major release identifier (for example, *4* for version 4.0), use the <xref:System.Version.Major%2A?displayProperty=nameWithType> property.

   - For the minor release identifier (for example, *0* for version 4.0), use the <xref:System.Version.Minor%2A?displayProperty=nameWithType> property.

   - For the entire version string (for example, *4.0.30319.18010*), use the <xref:System.Version.ToString%2A?displayProperty=nameWithType> method. This method returns a single value that reflects the version of the runtime that's executing the code. It doesn't return assembly versions or other runtime versions that may be installed on the computer.

    > [!NOTE]
    > For .NET Framework 4, 4.5, 4.5.1, and 4.5.2, the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property returns a <xref:System.Version> object whose string representation has the form `4.0.30319.xxxxx`. For .NET Framework 4.6 and later, it has the form `4.0.30319.42000`.

    > [!IMPORTANT]
    > For [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] and later, query the registry, as described in [Use code to query the registry for .NET Framework 4.5 and later](#use-code-to-query-the-registry-for-net-framework-4.5-and-later). Don't use the  <xref:System.Environment.Version%2A?displayProperty=nameWithType> property to detect the version of the runtime. 

     The following example shows how to query the <xref:System.Environment.Version%2A?displayProperty=nameWithType> property for runtime version information:

     [!code-csharp[ListVersions](../../../samples/snippets/csharp/framework/migration-guide/versions-installed2.cs)]
     [!code-vb[ListVersions](../../../samples/snippets/visualbasic/framework/migration-guide/versions-installed2.vb)]

     The code produces output that's similar to the following example:

    ```
    Version: 4.0.30319.18010
    ```

## See also

- [How to: Determine which .NET Framework updates are installed](how-to-determine-which-net-framework-updates-are-installed.md)
- [Install the .NET Framework for developers](../install/guide-for-developers.md)
- [.NET Framework versions and dependencies](versions-and-dependencies.md)
