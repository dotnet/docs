---
title: Install .NET Framework 3.5 on Windows 11
description: Learn how to install .NET Framework 3.5 on Windows 11. .NET Framework 3.5 can run apps that target .NET Framework 1.0 through 3.5.
ms.date: 02/02/2026
ai-usage: ai-assisted
---
# Install .NET Framework 3.5 on Windows 11

.NET Framework 3.5 is supported on Windows 11. How you obtain .NET Framework 3.5 depends on which version of Windows 11 you're using. Use the following list to identify the installation method that's applicable to you:

- [Windows 11 25H2 and earlier versions.](dotnet-35-windows.md#install-net-framework-35-on-demand)
- [Windows 11 Insider Preview Build 27965 and later versions.](#windows-11-insider-preview-build-27965-and-later)

## How do I determine which version of Windows I'm using?

There are a few different ways you can find the version of Windows you're using:

- Try [this link (ms-settings:about)](ms-settings:about) which might open the Settings app.

  1. Scroll down to the **Windows specifications** section and find the **Version** field.

- Try using the start menu:

  1. Press the <kbd>Windows</kbd> key to open the **Start** menu.
  1. Type `Settings` to find the **Settings** app and open it.
  1. Scroll down to the **Windows specifications** section and find the **Version** field.

- Try running the `winver.exe` app:

  1. Press the <kbd>Windows+R</kbd> keyboard shortcut to open the **Run** dialog.
  1. Type `winver.exe` and press <kbd>Enter</kbd>.

## Windows 11 Insider Preview Build 27965 and later

[!INCLUDE [dotnet-35-installer](includes/dotnet-35-installer.md)]

For more information about this change to .NET Framework 3.5, see [.NET Framework 3.5 on Windows 11 FAQ](dotnet-35-windows-11-faq.yml).

## .NET Framework 3.5 optional components

_Applies to **Windows 11 Insider Preview Build 27965 and later**_

The following optional .NET Framework 3.5 components were previously available as Windows Features on Demand. Windows 11 Insider Preview Build 27965 removes these components:

- ASP.NET 3.5
- .NET Extensibility 3.5
- WCF HTTP Activation
- WCF non-HTTP Activation

## How to enable ASP.NET 3.5 and WCF in IIS

Starting with Windows 11 Insider Preview Build 27965, ASP.NET 3.5 and WCF require additional registration to run in IIS.

Enable ASP.NET 3.5 on your device using the [`Enable-ASPNet35.ps1`](https://go.microsoft.com/fwlink/?linkid=2348600&clcid=0x409) PowerShell script. The script enables the functionality of the following optional components that have been removed from Windows:

- ASP.NET 3.5
- .NET Extensibility 3.5

> [!NOTE]
> The script only restores the functionality of these optional components so that applications that depend on them can continue working. The optional components are still missing from Windows 11 and tools like DISM won't detect these optional components as present after running the script.

### Prerequisites

- Windows Insider Preview Build 27965 or later
- Windows PowerShell 5.1
- .NET Framework 3.5
- The Web Server (IIS) feature or role enabled, along with the **ISAPI Filters** and **ISAPI Extensions** optional components
- An administrative PowerShell command window

### Run the script

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
