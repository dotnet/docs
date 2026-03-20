---
title: Install .NET Framework 3.5 on Windows 11
description: Learn how to install .NET Framework 3.5 on Windows 11. .NET Framework 3.5 can run apps that target .NET Framework 1.0 through 3.5.
ms.date: 02/09/2026
ai-usage: ai-assisted
---
# Install .NET Framework 3.5 on Windows 11

.NET Framework 3.5 is supported on Windows 11. How you obtain .NET Framework 3.5 depends on which version of Windows 11 you're using. Use the following list to identify the installation method that's applicable to you:

- [Windows 11 25H2 and earlier versions.](dotnet-35-windows.md#install-net-framework-35-on-demand)
- [Windows 11 26H1 (build 28000) and later versions.](#windows-11-26h1-build-28000-and-later)

> [!TIP]
> See [How to determine which version of Windows you're using](#how-to-determine-which-version-of-windows-youre-using) if you need help identifying your version.

## Windows 11 26H1 (build 28000) and later

[!INCLUDE [dotnet-35-installer](includes/dotnet-35-installer.md)]

For more information about this change to .NET Framework 3.5, see [.NET Framework 3.5 on Windows 11 FAQ](dotnet-35-windows-11-faq.yml).

## .NET Framework 3.5 optional components

_Applies to **Windows 11 26H1 (build 28000) and later**_

The following optional .NET Framework 3.5 components were previously available as Windows Features on Demand. Windows 11 26H1 (build 28000) removes these components:

- ASP.NET 3.5
- .NET Extensibility 3.5
- WCF HTTP Activation
- WCF non-HTTP Activation

<!-- ## How to enable ASP.NET 3.5 and WCF in IIS -->
## How to enable ASP.NET 3.5 in IIS

<!--Starting with Windows 11 26H1 (build 28000), ASP.NET 3.5 and WCF require additional registration to run in IIS.-->
Starting with Windows 11 26H1 (build 28000), ASP.NET 3.5 requires additional registration to run in IIS.

### Enable ASP.NET 3.5

Enable ASP.NET 3.5 on your device using the [`Enable-ASPNet35.ps1`](https://go.microsoft.com/fwlink/?linkid=2348600&clcid=0x409) PowerShell script. The script enables the functionality of the following optional components that have been removed from Windows:

- ASP.NET 3.5
- .NET Extensibility 3.5

> [!NOTE]
> The script only restores the functionality of these optional components so that applications that depend on them can continue working. The optional components are still missing from Windows 11 and tools like DISM won't detect these optional components as present after running the script.

#### Prerequisites

- Windows 11 26H1 (build 28000) or later.
- Windows PowerShell 5.1.
- .NET Framework 3.5.
- The Web Server (IIS) feature or role enabled, along with the **ISAPI Filters** and **ISAPI Extensions** optional components.
- An administrative PowerShell command window.

#### Run the script

1. Download the [`Enable-ASPNet35.ps1`](https://go.microsoft.com/fwlink/?linkid=2348600&clcid=0x409) script to a local directory.
1. Open a Windows PowerShell command window **as Administrator**.
1. Change the execution policy to allow scripts downloaded from the Internet and signed by trusted publishers:

   ```powershell
   Set-ExecutionPolicy RemoteSigned
   ```

   For more information about execution policy settings, see [Set-ExecutionPolicy](/powershell/module/microsoft.powershell.security/set-executionpolicy?view=powershell-5.1&preserve-view=true).

1. Go to the directory where you downloaded the script.
1. Run the script:

   ```powershell
   .\Enable-ASPNet35.ps1
   ```

<!-- ON HOLD until the instructions can be validated
### Enable WCF

To host WCF services in IIS or use advanced WCF features, you need to manually register WCF components and enable optional activation features.

#### Prerequisites

- Windows 11 26H1 (build 28000) or later.
- .NET Framework 3.5.
- An administrative command prompt.

#### Register WCF for IIS hosting

1. Open a command prompt **as Administrator**.
1. Run the **ServiceModel Registration Tool** with the `-i` parameter:

   ```cmd
   "%windir%\Microsoft.NET\Framework64\v3.0\Windows Communication Foundation\ServiceModelReg.exe" -i
   ```

#### Enable non-HTTP activation (optional)

If your WCF services require non-HTTP activation, enable the appropriate feature for your activation type.

1. Open a command prompt **as Administrator**.
1. For **TCP activation**, run the following command:

   ```cmd
   DISM /online /enable-feature /featurename:WCF-TCP-Activation45 /all
   ```

1. For **Named Pipe activation**, run the following command:

   ```cmd
   DISM /online /enable-feature /featurename:WCF-Pipe-Activation45 /all
   ```

1. For **Message Queuing (MSMQ) activation**, run the following command:

   ```cmd
   DISM /online /enable-feature /featurename:WCF-MSMQ-Activation45 /all
   ```

#### Enable TCP Port Sharing (optional)

If you need TCP port sharing for a self-hosted (non-IIS) WCF service, enable the .NET Framework 4.8 WCF Services TCP Port Sharing feature.

1. Open a command prompt **as Administrator**.
1. Use DISM to enable the `WCF-TCP-PortSharing45` feature:

   ```cmd
   DISM /online /enable-feature /featurename:WCF-TCP-PortSharing45 /all
   ```
-->

## How to determine which version of Windows you're using

[!INCLUDE [dotnet-determine-windows-version](includes/dotnet-determine-windows-version.md)]
