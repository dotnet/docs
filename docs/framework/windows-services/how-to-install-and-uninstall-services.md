---
title: "How to: Install and uninstall Windows services"
description: See how to install and uninstall Windows services. If you're developing a Windows service with .NET, you can use InstallUtil.exe or PowerShell.
ms.date: 05/20/2021
helpviewer_keywords:
  - "Windows Service applications, deploying"
  - "services, uninstalling"
  - "services, installing"
  - "installing Windows Services"
  - "uninstalling applications, apps, Windows services"
  - "installation, Windows services"
  - "uninstalling Windows services"
  - "installutil.exe tool"
ms.assetid: c89c5169-f567-4305-9d62-db31a1de5481
---
# How to: Install and uninstall Windows services

[!INCLUDE [windows-service-disambiguation](../../core/extensions/includes/windows-service-disambiguation.md)]

If you're developing a Windows service with .NET Framework, you can quickly install your service app by using the [*InstallUtil.exe*](../tools/installutil-exe-installer-tool.md) command-line utility or [PowerShell](/powershell/scripting/overview). Developers who want to release a Windows service that users can install and uninstall can use the free [WiX Toolset](https://wixtoolset.org/) or commercial tools like [Advanced Installer](https://www.advancedinstaller.com/), [InstallShield](https://www.revenera.com/install/products/installshield.html), and others. For more information, see [Create an installer package (Windows desktop)](/visualstudio/deployment/deploying-applications-services-and-components#create-an-installer-package-windows-desktop).

> [!WARNING]
> If you want to uninstall a service from your computer, don't follow the steps in this article. Instead, find out which program or software package installed the service, and then choose **Apps** in Settings to uninstall that program. Many services are integral parts of Windows; if you remove them, you might cause system instability.

To use the steps in this article, you first need to add a service installer to your Windows service. For more information, see [Walkthrough: Creating a Windows service app](walkthrough-creating-a-windows-service-application-in-the-component-designer.md).

You can't run Windows service projects directly from the Visual Studio development environment by pressing <kbd>F5</kbd>. Before you can run the project, you must install the service in the project.

> [!TIP]
> You can use **Server Explorer** to verify that you've installed or uninstalled your service.

## Install using InstallUtil.exe utility

1. From the **Start** menu, select the **Visual Studio \<*version*>** directory, then select **Developer Command Prompt for VS \<*version*>**.

   The Developer Command Prompt for Visual Studio appears.

2. Access the directory where your project's compiled executable file is located.

3. Run *InstallUtil.exe* from the command prompt with your project's executable as a parameter:

   ```console
   installutil <yourproject>.exe
   ```

   If you're using the Developer Command Prompt for Visual Studio, *InstallUtil.exe* is already on the system path. Otherwise, you can add it to the path, or use the fully qualified path to invoke it. This tool is installed with the .NET Framework in *%WINDIR%\Microsoft.NET\Framework[64]\\<framework_version\>*.

   For example:

   - For the 32-bit version of the .NET Framework 4 or 4.5 and later, if your Windows installation directory is *C:\Windows*, the default path is *C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe*.
   - For the 64-bit version of the .NET Framework 4 or 4.5 and later, the default path is *C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe*.

## Uninstall using InstallUtil.exe utility

1. From the **Start** menu, select the **Visual Studio \<*version*>** directory, then select **Developer Command Prompt for VS \<*version*>**.

   The Developer Command Prompt for Visual Studio appears.

2. Run *InstallUtil.exe* from the command prompt with your project's output as a parameter:

   ```console
   installutil /u <yourproject>.exe
   ```

3. After the executable for a service is deleted, the service might still be present in the registry. If that's the case, use the command [sc delete](/windows-server/administration/windows-commands/sc-delete) to remove the entry for the service from the registry.

## Install using PowerShell

1. From the **Start** menu, select the **Windows PowerShell** directory, then select **Windows PowerShell**.

2. Access the directory where your project's compiled executable file is located.

3. Run the [**New-Service**](/powershell/module/microsoft.powershell.management/new-service) cmdlet with a service name and your project's output as arguments:

   ```powershell
   New-Service -Name "YourServiceName" -BinaryPathName <yourproject>.exe
   ```

## Uninstall using PowerShell

1. From the **Start** menu, select the **Windows PowerShell** directory, then select **Windows PowerShell**.

2. Run the [**Remove-Service**](/powershell/module/microsoft.powershell.management/remove-service) cmdlet with the name of your service as an argument:

   ```powershell
   Remove-Service -Name "YourServiceName"
   ```

   > [!NOTE]
   > You must have PowerShell 6 or later to use this cmdlet. For information about updating PowerShell, see [Installing PowerShell on Windows](/powershell/scripting/install/installing-powershell-core-on-windows).

3. After the executable for a service is deleted, the service might still be present in the registry. If that's the case, use the command [sc delete](/windows-server/administration/windows-commands/sc-delete) to remove the entry for the service from the registry.

   ```powershell
   sc.exe delete "YourServiceName"
   ```

## See also

- [Introduction to Windows service applications](introduction-to-windows-service-applications.md)
- [How to: Create Windows services](how-to-create-windows-services.md)
- [How to: Add installers to your service application](how-to-add-installers-to-your-service-application.md)
- [Installutil.exe (Installer tool)](../tools/installutil-exe-installer-tool.md)
