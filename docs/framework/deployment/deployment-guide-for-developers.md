---
title: ".NET Framework deployment guide for developers"
description: Read the .NET deployment guide for developers. Use this information if you want to install any version of .NET from version 4.5 to 4.8 with your apps.
ms.date: "04/26/2021"
helpviewer_keywords:
  - "developer's guide, deploying .NET Framework"
  - "deployment [.NET Framework], developer's guide"
ms.assetid: 094d043e-33c4-40ba-a503-e0b20b55f4cf
---
# .NET Framework deployment guide for developers

This article provides information for developers who want to install any version of .NET Framework from .NET Framework 4.5 to [!INCLUDE[net_current](../../../includes/net-current-version.md)] with their apps.

You can download the redistributable packages and language packs for .NET Framework from the download pages:

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [.NET Framework 4.7.1](https://dotnet.microsoft.com/download/dotnet-framework/net471)
- [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
- [.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462)
- [.NET Framework 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework/net461)
- [.NET Framework 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46)
- [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452)
- [.NET Framework 4.5.1](https://dotnet.microsoft.com/download/dotnet-framework/net451)
- [.NET Framework 4.5](https://dotnet.microsoft.com/download/dotnet-framework/net45)

[!INCLUDE[net_retirement](../../../includes/net-framework-retired-versions.md)]

 Important notes:

- Versions of .NET Framework from .NET Framework 4.5.1 through [!INCLUDE[net_current](../../../includes/net-current-version.md)] are in-place updates to .NET Framework 4.5, which means they use the same runtime version, but the assembly versions are updated and include new types and members.

- .NET Framework 4.5 and later versions are built incrementally on .NET Framework 4. When you install .NET Framework 4.5 or later versions on a system that has .NET Framework 4 installed, the version 4 assemblies are replaced with newer versions.

- If you are referencing a Microsoft [out-of-band package](../get-started/the-net-framework-and-out-of-band-releases.md) in your app, the assembly will be included in the app package.

- You must have administrator privileges to install .NET Framework 4.5 or later versions.

- .NET Framework 4.5 is included in Windows 8 and Windows Server 2012, so you don't have to deploy it with your app on those operating systems. Similarly, .NET Framework 4.5.1 is included in Windows 8.1 and Windows Server 2012 R2. .NET Framework 4.5.2 isn't included in any operating systems. .NET Framework 4.6 is included in Windows 10, .NET Framework 4.6.1 is included in Windows 10 November Update, and .NET Framework 4.6.2 is included in Windows 10 Anniversary Update. .NET Framework 4.7 is included in Windows 10 Creators Update, .NET Framework 4.7.1 is included in Windows 10 Fall Creators Update, and .NET Framework 4.7.2 is included in Windows 10 October 2018 Update and Windows 10 April 2018 Update. .NET Framework 4.8 is included in Windows 10 May 2019 Update and all later Windows 10 updates. For a full list of hardware and software requirements, see [System Requirements](../get-started/system-requirements.md).

- Starting with .NET Framework 4.5, your users can view a list of running .NET Framework apps during setup and close them easily. This may help avoid system restarts caused by .NET Framework installations. See [Reducing System Restarts](reducing-system-restarts.md).

- Uninstalling .NET Framework 4.5 or later versions also removes pre-existing .NET Framework 4 files. If you want to go back to .NET Framework 4, you must reinstall it and any updates to it. See [Installing the .NET Framework 4](/previous-versions/dotnet/netframework-4.0/5a4x27ek(v=vs.100)).

- The .NET Framework 4.5 redistributable was updated on October 9, 2012 to correct an issue related to an improper timestamp on a digital certificate, which caused the digital signature on files produced and signed by Microsoft to expire prematurely. If you previously installed the .NET Framework 4.5 redistributable package dated August 16, 2012, we recommend that you update your copy with the latest redistributable from the [.NET Framework download page](https://dotnet.microsoft.com/download/dotnet-framework/net45). For more information about this issue, see [Microsoft Security Advisory 2749655](/security-updates/SecurityAdvisories/2012/2749655).

For information about how a system administrator can deploy the .NET Framework and its system dependencies across a network, see [Deployment Guide for Administrators](guide-for-administrators.md).

## Deployment options for your app

When you're ready to publish your app to a web server or other centralized location so that users can install it, you can choose from several deployment methods. Some of these are provided with Visual Studio. The following table lists the deployment options for your app and specifies the .NET Framework redistributable package that supports each option. In addition to these, you can write a custom setup program for your app; for more information, see the section [Chaining the .NET Framework Installation to Your App's Setup](#chaining).

|Deployment strategy for your app|Deployment methods available|.NET Framework redistributable to use|
|--------------------------------------|----------------------------------|-------------------------------------------|
|Install from the web|- [InstallAware](#installaware-deployment)<br />- [InstallShield](#installshield-deployment)<br />- [WiX toolset](#wix)<br />- [Manual installation](#installing_manually)|[Web installer](#redistributable-packages)|
|Install from disc|- [InstallAware](#installaware-deployment)<br />- [InstallShield](#installshield-deployment)<br />- [WiX toolset](#wix)<br />- [Manual installation](#installing_manually)|[Offline installer](#redistributable-packages)|
|Install from a local area network (for enterprise apps)|- [ClickOnce](#clickonce-deployment)|Either [web installer](#redistributable-packages) (see [ClickOnce](#clickonce-deployment) for restrictions) or [offline installer](#redistributable-packages)|

## Redistributable packages

.NET Framework is available in two redistributable packages: web installer (bootstrapper) and offline installer (stand-alone redistributable). All .NET Framework downloads are hosted on the [Download .NET Framework page](https://dotnet.microsoft.com/download/dotnet-framework/). The following table compares the two packages:

|                                   | Web installer                                          | Offline installer                                                                                              |
|-----------------------------------|--------------------------------------------------------|----------------------------------------------------------------------------------------------------------------|
| **Internet connection required?** | Yes                                                    | No                                                                                                             |
| **Size of download**              | Smaller (includes installer for target platform only)*| Larger*                                                                                                        |
| **Language packs**                | Included**                                             | Must be [installed separately](#chain_langpack), unless you use the package that targets all operating systems |
| **Deployment method**             | Supports all methods:<br /><br />- [ClickOnce](#clickonce-deployment)<br />- [InstallAware](#installaware-deployment)<br />- [InstallShield](#installshield-deployment)<br />- [Windows Installer XML (WiX)](#wix)<br />- [Manual installation](#installing_manually)<br />- [Custom setup (chaining)](#chaining) | Supports all methods:<br /><br />- [ClickOnce](#clickonce-deployment)<br />- [InstallAware](#installaware-deployment)<br />- [InstallShield](#installshield-deployment)<br />- [Windows Installer XML (WiX)](#wix)<br />- [Manual installation](#installing_manually)<br />- [Custom setup (chaining)](#chaining)|

\* The offline installer is larger because it contains the components for all the target platforms. When you finish running setup, the Windows operating system caches only the installer that was used. If the offline installer is deleted after the installation, the disk space used is the same as that used by the web installer. If the tool you use (for example, [InstallAware](#installaware-deployment) or [InstallShield](#installshield-deployment)) to create your app's setup program provides a setup file folder that is removed after installation, the offline installer can be automatically deleted by placing it into the setup folder.

\*\* If you're using the web installer with custom setup, you can use default language settings based on the user's Multilingual User Interface (MUI) setting, or specify another language pack by using the `/LCID` option on the command line. See the section [Chaining by Using the Default .NET Framework UI](#chaining_default) for examples.

## Deployment methods

Four deployment methods are available:

- You can set a dependency on .NET Framework. You can specify .NET Framework as a prerequisite in your app's installation, using one of these methods:

  - Use [ClickOnce deployment](#clickonce-deployment) (available with Visual Studio)

  - Create an [InstallAware project](#installaware-deployment) (free edition available for Visual Studio users)

  - Create an [InstallShield project](#installshield-deployment) (available with Visual Studio)

  - Use the [Windows Installer XML (WiX) toolset](#wix)

- You can ask your users to [install .NET Framework manually](#installing_manually).

- You can chain (include) the .NET Framework setup process in your app's setup, and decide how you want to handle the .NET Framework installation experience:

  - [Use the default UI](#chaining_default). Let the .NET Framework installer provide the installation experience.

  - [Customize the UI](#chaining_custom) to present a unified installation experience and to monitor the .NET Framework installation progress.

These deployment methods are discussed in detail in the following sections.

## Set a dependency on .NET Framework

If you use ClickOnce, InstallAware, InstallShield, or WiX to deploy your app, you can add a dependency on .NET Framework so it can be installed as part of your app.

### ClickOnce deployment

ClickOnce deployment is available for projects that are created with Visual Basic and Visual C#, but it is not available for Visual C++.

In Visual Studio, to choose ClickOnce deployment and add a dependency on .NET Framework:

1. Open the app project you want to publish.

2. In Solution Explorer, open the shortcut menu for your project, and then choose **Properties**.

3. Choose the **Publish** pane.

4. Choose the **Prerequisites** button.

5. In the **Prerequisites** dialog box, make sure that the **Create setup program to install prerequisite components** check box is selected.

6. In the prerequisites list, locate and select the version of .NET Framework that you've used to build your project.

7. Choose an option to specify the source location for the prerequisites, and then choose **OK**.

     If you supply a URL for the .NET Framework download location, you can specify either the .NET Framework download page or a site of your own. If you are placing the redistributable package on your own server, it must be the offline installer and not the web installer. You can only link to the web installer on the .NET Framework download page. The URL can also specify a disc on which your own app is being distributed.

8. In the **Property Pages** dialog box, choose **OK**.

<a name="installaware"></a>

### InstallAware deployment

InstallAware builds Windows app (APPX), Windows Installer (MSI), Native Code (EXE), and App-V (Application Virtualization) packages from a single source. Easily [include any version of the .NET Framework](https://www.installaware.com/one-click-pre-requisite-installer.htm) in your setup, optionally customizing the installation by [editing the default scripts](https://www.installaware.com/msicode.htm). For example, InstallAware pre-installs certificates on Windows 7, without which .NET Framework 4.7 setup fails. For more information on InstallAware, see the [InstallAware for Windows Installer](https://www.installaware.com/) website.

### InstallShield deployment

InstallShield builds Windows app packages (MSIX, APPX), Windows Installer packages (MSI), and Native Code (EXE) installers. InstallShield also provides Visual Studio integration. For more information, see the [InstallShield](https://www.flexerasoftware.com/install/products/installshield.html) website.

<a name="wix"></a>

### Windows Installer XML (WiX) deployment

The Windows Installer XML (WiX) toolset builds Windows installation packages from XML source code. WiX supports a command-line environment that can be integrated into your build processes to build MSI and MSM setup packages. By using WiX, you can [specify the .NET Framework as a prerequisite](https://wixtoolset.org/documentation/manual/v3/howtos/redistributables_and_install_checks/install_dotnet.html), or [create a chainer](https://wixtoolset.org/documentation/manual/v3/xsd/wix/exepackage.html) to fully control the .NET Framework deployment experience. For more information about WiX, see the [Windows Installer XML (WiX) toolset](https://wixtoolset.org/) website.

<a name="installing_manually"></a>

## Install .NET Framework manually

In some situations, it might be impractical to automatically install .NET Framework with your app. In that case, you can have users install .NET Framework themselves. The redistributable package is available in [two packages](#redistributable-packages). In your setup process, provide instructions for how users should locate and install .NET Framework.

<a name="chaining"></a>

## Chain the .NET Framework installation to your app's setup

If you're creating a custom setup program for your app, you can chain (include) the .NET Framework setup process in your app's setup process. Chaining provides two UI options for the .NET Framework installation:

- Use the default UI provided by the .NET Framework installer.

- Create a custom UI for the .NET Framework installation for consistency with your app's setup program.

Both methods allow you to use either the web installer or the offline installer. Each package has its advantages:

- If you use the web installer, the .NET Framework setup process will decide which installation package is required, and download and install only that package from the web.

- If you use the offline installer, you can include the complete set of .NET Framework installation packages with your redistribution media so that your users don't have to download any additional files from the web during setup.

<a name="chaining_default"></a>

### Chaining by using the default .NET Framework UI

To silently chain the .NET Framework installation process and let the .NET Framework installer provide the UI, add the following command to your setup program:

`<.NET Framework redistributable> /q /norestart /ChainingPackage <PackageName>`

For example, if your executable program is Contoso.exe and you want to silently install the .NET Framework 4.5 offline redistributable package, use the command:

`dotNetFx45_Full_x86_x64.exe /q /norestart /ChainingPackage Contoso`

You can use additional command-line options to customize the installation. For example:

- To provide a way for users to close running .NET Framework apps to minimize system restarts, set passive mode and use the `/showrmui` option as follows:

    `dotNetFx45_Full_x86_x64.exe /norestart /passive /showrmui /ChainingPackage Contoso`

     This command allows Restart Manager to display a message box that gives users the opportunity to close .NET Framework apps before installing the .NET Framework.

- If you're using the web installer, you can use the `/LCID` option to specify a language pack. For example, to chain the .NET Framework 4.5 web installer to your Contoso setup program and install the Japanese language pack, add the following command to your app's setup process:

    `dotNetFx45_Full_setup.exe /q /norestart /ChainingPackage Contoso /LCID 1041`

     If you omit the `/LCID` option, setup will install the language pack that matches the user's MUI setting.

    > [!NOTE]
    > Different language packs may have different release dates. If the language pack you specify is not available at the download center, setup will install the .NET Framework without the language pack. If the .NET Framework is already installed on the user’s computer, the setup will install only the language pack.

For a complete list of options, see the [Command-Line Options](#command-line-options) section.

For common return codes, see the [Return Codes](#return-codes) section.

<a name="chaining_custom"></a>

### Chaining by using a Custom UI

If you have a custom setup package, you may want to silently launch and track the .NET Framework setup while showing your own view of the setup progress. If this is the case, make sure that your code covers the following:

- Check for [.NET Framework hardware and software requirements](../get-started/system-requirements.md).

- [Detect](#detect_net) whether the correct version of the .NET Framework is already installed on the user’s computer.

    > [!IMPORTANT]
    > In determining whether the correct version of the .NET Framework is already installed, you should check whether your target version *or* a later version is installed, not whether your target version is installed. In other words, you should evaluate whether the release key you retrieve from the registry is greater than or equal to the release key of your target version, *not* whether it equals the release key of your target version.

- [Detect](#detect-language-packs) whether the language packs are already installed on the user’s computer.

- If you want to control the deployment, silently launch and track the .NET Framework setup process (see [How to: Get Progress from the .NET Framework 4.5 Installer](how-to-get-progress-from-the-dotnet-installer.md)).

- If you’re deploying the offline installer, [chain the language packs separately](#chain_langpack).

- Customize deployment by using [command-line options](#command-line-options). For example, if you’re chaining the .NET Framework web installer, but you want to override the default language pack, use the `/LCID` option, as described in the previous section.

- [Troubleshoot](#troubleshooting).

<a name="detect_net"></a>

### Detect .NET Framework

The .NET Framework installer writes registry keys when installation is successful. You can test whether .NET Framework 4.5 or later is installed by checking the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full` folder in the registry for a `DWORD` value named `Release`. (Note that "NET Framework Setup" doesn't begin with a period.) The existence of this key indicates that .NET Framework 4.5 or a later version has been installed on that computer. The value of `Release` indicates which version of .NET Framework is installed.

> [!IMPORTANT]
> Check for a value  **greater than or equal to** the release keyword value when attempting to detect whether a specific version is present.

| Version                                                                                                                                                                    | Value of the Release DWORD |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------|
| .NET Framework 4.8 installed on Windows 10 May 2020 Update and Windows 10 October 2020 Update                                                                              | 528372                     |
| .NET Framework 4.8 installed on Windows 10 May 2019 Update and Windows 10 November 2019 Update                                                                             | 528040                     |
| .NET Framework 4.8 installed on all OS versions other than the listed Windows 10 Update versions                                                                           | 528049                     |
| .NET Framework 4.7.2 installed on Windows 10 April 2018 Update and on Windows Server, version 1803                                                                         | 461808                     |
| .NET Framework 4.7.2 installed on all OS versions other than Windows 10 April 2018 Update, and Windows Server, version 1803. This includes Windows 10 October 2018 Update. | 461814                     |
| .NET Framework 4.7.1 installed on Windows 10 Fall Creators Update and on Windows Server, version 1709                                                                      | 461308                     |
| .NET Framework 4.7.1 installed on all OS versions other than Windows 10 Fall Creators Update and Windows Server, version 1709                                              | 461310                     |
| .NET Framework 4.7 installed on Windows 10 Creators Update                                                                                                                 | 460798                     |
| .NET Framework 4.7 installed on all OS versions other than Windows 10 Creators Update                                                                                      | 460805                     |
| .NET Framework 4.6.2 installed on Windows 10 Anniversary Edition and on Windows Server 2016                                                                                | 394802                     |
| .NET Framework 4.6.2 installed on all OS versions other than Windows 10 Anniversary Edition and Windows Server 2016                                                        | 394806                     |
| .NET Framework 4.6.1 installed on Windows 10 November Update                                                                                                               | 394254                     |
| .NET Framework 4.6.1 installed on all OS versions other than Windows 10 November Update                                                                                    | 394271                     |
| .NET Framework 4.6 installed on Windows 10                                                                                                                                 | 393295                     |
| .NET Framework 4.6 installed on all OS versions other than Windows 10                                                                                                      | 393297                     |
| .NET Framework 4.5.2                                                                                                                                                       | 379893                     |
| .NET Framework 4.5.1 installed with Windows 8.1 or Windows Server 2012 R2                                                                                                  | 378675                     |
| .NET Framework 4.5.1 installed on Windows 8, Windows 7                                                                                                                     | 378758                     |
| .NET Framework 4.5                                                                                                                                                         | 378389                     |

### Detect language packs

You can test whether a specific language pack is installed by checking the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\\*LCID* folder in the registry for a DWORD value named `Release`. (Note that "NET Framework Setup" doesn't begin with a period.) *LCID* specifies a locale identifier; see [supported languages](#supported-languages) for a list of these.

For example, to detect whether the full Japanese language pack (LCID=1041) is installed, retrieve the following named value from the registry:

|           | Value                                                                      |
|-----------|----------------------------------------------------------------------------|
| **Key**   | HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\1041 |
| **Entry** | Release                                                                    |
| **Type**  | DWORD                                                                      |

To determine whether the final release version of a language pack is installed for a particular version of .NET Framework from 4.5 through 4.7.2, check the value of the RELEASE key DWORD value described in the previous section, [Detecting .NET Framework](#detect_net).

<a name="chain_langpack"></a>

### Chaining the language packs to your app setup

.NET Framework provides a set of stand-alone language pack executable files that contain localized resources for specific cultures. The language packs are available from the .NET Framework download pages:

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [.NET Framework 4.7.1](https://dotnet.microsoft.com/download/dotnet-framework/net471)
- [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
- [.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462)
- [.NET Framework 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework/net461)
- [.NET Framework 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46)
- [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452)
- [.NET Framework 4.5.1](https://dotnet.microsoft.com/download/dotnet-framework/net451)
- [.NET Framework 4.5](https://dotnet.microsoft.com/download/dotnet-framework/net45)

> [!IMPORTANT]
> The language packs don't contain the .NET Framework components that are required to run an app. You must install .NET Framework by using the web or offline installer before you install a language pack.

Starting with .NET Framework 4.5.1, the package names take the form NDP<`version`>-KB<`number`>-x86-x64-AllOS-<`culture`>.exe, where `version` is the version number of the .NET Framework, `number` is a Microsoft Knowledge Base article number, and `culture` specifies a [country/region](#supported-languages). An example of one of these packages is `NDP452-KB2901907-x86-x64-AllOS-JPN.exe`. Package names are listed in the [Redistributable Packages](#redistributable-packages) section earlier in this article.

To install a language pack with the .NET Framework offline installer, you must chain it to your app's setup. For example, to deploy .NET Framework 4.5.1 offline installer with the Japanese language pack, use the following command:

`NDP451-KB2858728-x86-x64-AllOS-JPN.exe /q /norestart /ChainingPackage <ProductName>`

You do not have to chain the language packs if you use the web installer; setup will install the language pack that matches the user's MUI setting. If you want to install a different language, you can use the `/LCID` option to specify a language pack.

For a complete list of command-line options, see the [Command-Line Options](#command-line-options) section.

### Troubleshooting

#### Return codes

The following table lists the most common return codes for the .NET Framework redistributable installer. The return codes are the same for all versions of the installer. For links to detailed information, see the next section.

| Return code | Description                                                                         |
|-------------|-------------------------------------------------------------------------------------|
| 0           | Installation completed successfully.                                                |
| 1602        | The user canceled installation.                                                     |
| 1603        | A fatal error occurred during installation.                                         |
| 1641        | A restart is required to complete the installation. This message indicates success. |
| 3010        | A restart is required to complete the installation. This message indicates success. |
| 5100        | The user's computer does not meet system requirements.                              |

#### Download error codes

See the following content:

- [Background Intelligent Transfer Service (BITS) error codes](/windows/win32/bits/bits-return-values)

- [URL moniker error codes](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775145(v=vs.85))

- [WinHttp error codes](/windows/win32/winhttp/error-messages)

#### Other error codes

See the following content:

- [Windows Installer error codes](/previous-versions/aa368542(v=vs.85))

- [Windows Update Agent result codes](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc720442(v=ws.10))

## Uninstall .NET Framework

Starting with Windows 8, you can uninstall .NET Framework 4.5 or later versions by using **Turn Windows features on and off** in Control Panel. In older versions of Windows, you can uninstall .NET Framework 4.5 or later versions by using **Add or Remove Programs** in Control Panel.

> [!IMPORTANT]
> For Windows 7 and earlier operating systems, uninstalling .NET Framework 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, 4.7.2, or 4.8 doesn't restore .NET Framework 4.5 files, and uninstalling .NET Framework 4.5 doesn't restore .NET Framework 4 files. If you want to go back to the older version, you must reinstall it and any updates to it.

## Appendix

### Command-line options

The following table lists options that you can include when you chain the .NET Framework 4.5 redistributable to your app's setup.

|Option|Description|
|------------|-----------------|
|**/CEIPConsent**|Overwrites the default behavior and sends anonymous feedback to Microsoft to improve future deployment experiences. This option can be used only if the setup program prompts for consent and if the user grants permission to send anonymous feedback to Microsoft.|
|**/chainingpackage** `packageName`|Specifies the name of the executable that is doing the chaining. This information is sent to Microsoft as anonymous feedback to help improve future deployment experiences.<br /><br /> If the package name includes spaces, use double quotation marks as delimiters; for example: **/chainingpackage "Lucerne Publishing"**. For an example of a chaining package, see [Getting Progress Information from an Installation Package](/previous-versions/cc825975(v=vs.100)).|
|**/LCID**  `LCID`<br /><br /> where `LCID` specifies a locale identifier (see [supported languages](#supported-languages))|Installs the language pack specified by `LCID` and forces the displayed UI to be shown in that language, unless quiet mode is set.<br /><br /> For the web installer, this option chain-installs the language package from the web. **Note:**  Use this option only with the web installer.|
|**/log** `file` &#124; `folder`|Specifies the location of the log file. The default is the temporary folder for the process, and the default file name is based on the package. If the file extension is .txt, a text log is produced. If you specify any other extension or no extension, an HTML log is created.|
|**/msioptions**|Specifies options to be passed for .msi and .msp items; for example: `/msioptions "PROPERTY1='Value'"`.|
|**/norestart**|Prevents the setup program from rebooting automatically. If you use this option, the chaining app has to capture the return code and handle rebooting (see [Getting Progress Information from an Installation Package](/previous-versions/cc825975(v=vs.100))).|
|**/passive**|Sets passive mode. Displays the progress bar to indicate that installation is in progress, but does not display any prompts or error messages to the user. In this mode, when chained by a setup program, the chaining package must handle [return codes](#return-codes).|
|**/pipe**|Creates a communication channel to enable a chaining package to get progress.|
|**/promptrestart**|Passive mode only, if the setup program requires a restart, it prompts the user. This option requires user interaction if a restart is required.|
|**/q**|Sets quiet mode.|
|**/repair**|Triggers the repair functionality.|
|**/serialdownload**|Forces the installation to happen only after the package has been downloaded.|
|**/showfinalerror**|Sets passive mode. Displays errors only if the installation is not successful. This option requires user interaction if the installation is not successful.|
|**/showrmui**|Used only with the **/passive** option. Displays a message box that prompts users to close .NET Framework apps that are currently running. This message box behaves the same in passive and non-passive mode.|
|**/uninstall**|Uninstalls the .NET Framework redistributable.|

### Supported languages

The following table lists .NET Framework language packs that are available for .NET Framework 4.5 and later versions.

| LCID | Language – country/region     | Culture |
|------|-------------------------------|---------|
| 1025 | Arabic - Saudi Arabia         | ar      |
| 1028 | Chinese – Traditional         | zh-Hant |
| 1029 | Czech                         | cs      |
| 1030 | Danish                        | da      |
| 1031 | German – Germany              | de      |
| 1032 | Greek                         | el      |
| 1035 | Finnish                       | fi      |
| 1036 | French – France               | fr      |
| 1037 | Hebrew                        | he      |
| 1038 | Hungarian                     | hu      |
| 1040 | Italian – Italy               | it      |
| 1041 | Japanese                      | ja      |
| 1042 | Korean                        | ko      |
| 1043 | Dutch – Netherlands           | nl      |
| 1044 | Norwegian (Bokmål)            | no      |
| 1045 | Polish                        | pl      |
| 1046 | Portuguese – Brazil           | pt-BR   |
| 1049 | Russian                       | ru      |
| 1053 | Swedish                       | sv      |
| 1055 | Turkish                       | tr      |
| 2052 | Chinese – Simplified          | zh-Hans |
| 2070 | Portuguese – Portugal         | pt-PT   |
| 3082 | Spanish - Spain (Modern Sort) | es      |

## See also

- [Deployment Guide for Administrators](guide-for-administrators.md)
- [System Requirements](../get-started/system-requirements.md)
- [Install the .NET Framework for developers](../install/guide-for-developers.md)
- [Troubleshoot blocked .NET Framework installations and uninstallations](../install/troubleshoot-blocked-installations-and-uninstallations.md)
- [Reducing System Restarts During .NET Framework 4.5 Installations](reducing-system-restarts.md)
- [How to: Get Progress from the .NET Framework 4.5 Installer](how-to-get-progress-from-the-dotnet-installer.md)
