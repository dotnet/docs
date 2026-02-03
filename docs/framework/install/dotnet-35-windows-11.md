---
title: Install .NET Framework 3.5 on Windows 11
description: Learn how to install .NET Framework 3.5 on Windows 11. .NET Framework 3.5 can run apps that target .NET Framework 1.0 through 3.5.
ms.date: 02/02/2026
ai-usage: ai-assisted
---
# Install .NET Framework 3.5 on Windows 11

[!INCLUDE [dotnet-35-installer](includes/dotnet-35-installer.md)]

## .NET Framework 3.5 optional components

The following optional .NET Framework 3.5 components were previously available as Windows Features on Demand. Windows 11 removes these components:

- ASP.NET 3.5
- .NET Extensibility 3.5
- WCF HTTP Activation
- WCF non-HTTP Activation

## Enable ASP.NET 3.5 and WCF in IIS

ASP.NET 3.5 and WCF require additional registration to run in IIS.

Enable ASP.NET 3.5 on your device using the [`Enable-ASPNet35.ps1`](https://go.microsoft.com/fwlink/?linkid=2348600&clcid=0x409) PowerShell script. The script enables the functionality of the following optional components that have been removed from Windows:

- ASP.NET 3.5
- .NET Extensibility 3.5

> [!NOTE]
> The script only restores the functionality of these optional components so that applications that depend on them can continue working. The optional components are still missing from Windows 11 and tools like DISM won't detect these optional components as present after running the script.

To run the script, make sure your device meets these prerequisites:

- Windows Insider Preview Build 27965 or later
- Windows PowerShell 5.1
- .NET Framework 3.5
- The Web Server (IIS) feature or role enabled, along with the **ISAPI Filters** and **ISAPI Extensions** optional components
- An administrative PowerShell command window

To run the script:

1. Download the [`Enable-ASPNet35.ps1`](https://go.microsoft.com/fwlink/?linkid=2348600&clcid=0x409) script to a local directory.
1. Open a Windows PowerShell command window **as Administrator**.
1. Change the execution policy to allow scripts downloaded from the Internet and signed by trusted publishers:

   ```powershell
   Set-ExecutionPolicy RemoteSigned
   ```

   For more information about execution policy settings, see [Set-ExecutionPolicy](/powershell/module/microsoft.powershell.security/set-executionpolicy?view=powershell-5.1).

1. Go to the directory where you downloaded the script.
1. Run the script:

   ```powershell
   .\Enable-ASPNet35.ps1
   ```
