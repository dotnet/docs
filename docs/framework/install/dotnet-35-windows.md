---
title: Install .NET Framework 3.5 on Windows
description: Learn how to install .NET Framework 3.5 on Windows and Windows Server. .NET Framework 3.5 can run apps that target .NET Framework 1.0 through 3.5.
ms.date: 02/10/2025
ms.topic: install-set-up-deploy
---
# Install .NET Framework 3.5 on Windows and Windows Server

You might need .NET Framework 3.5 to run an app on Windows or Windows Server. Windows and Windows Server come with .NET Framework 4, which doesn't support apps built with .NET Framework 1.1 through 3.5. To run these apps, install .NET Framework 3.5. If you're a developer that requires .NET Framework 3.5, see the section [Developers and .NET Framework 3.5](#developers-and-net-framework-35).

> [!TIP]
> You might be able to use a config file to force the app to run on .NET Framework 4. For more information, see [Migration: Retarget or Recompile](../migration-guide/migrating-from-the-net-framework-1-1.md#retarget-or-recompile).

## Install .NET Framework 3.5 on demand

You might see the following configuration dialog if you try to run an app that requires an older version of .NET Framework. Depending on your version of Windows, the dialog might be slightly different. Choose **Download and install this feature** to enable .NET Framework 3.5. This option requires an internet connection.

:::image type="content" source="./media/dotnet-35-windows/dotnet-framework-installation-dialog.png" alt-text="Screenshot of the .NET Framework installation dialog.":::

### Why am I getting this pop-up?

.NET Framework is created by Microsoft and provides an environment for running apps. There are different versions available. Many companies develop their apps to run using the .NET Framework, and these apps target a specific version. If you see this pop-up, you're trying to run an app that requires a .NET Framework version that isn't installed on your system.

## Enable .NET Framework 3.5 on Windows Server

Enable .NET Framework 3.5 through the **Add Roles and Features Wizard**.

1. Press the Start :::image type="icon" source="media/dotnet-35-windows/windows-keyboard-logo.png" border="false"::: button on the taskbar.
1. Search for **Add Roles and Features Wizard** and open it.
1. Search for **Windows Features** and open it. The **Turn Windows features on or off** dialog box appears.
1. Navigate through the wizard until you reach **Features**.
1. Select **.NET Framework 3.5 Features** in the list.
1. Select **Install** to start installing .NET Framework 3.5.

:::image type="content" source="media/dotnet-35-windows/server-features.png" alt-text="The Add Roles and Features Wizard dialog box from Windows Server. .NET Framework 3.5 is selected.":::

## Enable .NET Framework 3.5 on Windows

You can enable the .NET Framework 3.5 through the Windows Control Panel. This option requires an internet connection.

1. Press the Start :::image type="icon" source="media/dotnet-35-windows/windows-keyboard-logo.png" border="false"::: button on the taskbar.
1. Search for **Windows Features** and open it. The **Turn Windows features on or off** dialog box appears.
1. Select the **.NET Framework 3.5 (includes .NET 2.0 and 3.0)** check box, select **OK**, and reboot your computer if prompted.

:::image type="content" source="media/dotnet-35-windows/dotnet-control-panel.png" alt-text="Screenshot of the Windows Features dialog box. .NET Framework 3.5 is selected.":::

You don't need to select the child items for **Windows Communication Foundation (WCF) HTTP Activation** and **Windows Communication Foundation (WCF) Non-HTTP Activation** unless you're a developer or server administrator who requires this functionality.

## Download the offline installer

The .NET Framework 3.5 SP1 offline installer is available for Windows versions **prior to Windows 10 and Windows Server 2016**. For more information, see [.NET Framework 3.5 SP1 Download page](https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1?wt.mc_id=install-docs).

Starting with Windows 10 and Windows Server 2016 operating systems, the only supported way of installing .NET Framework 3.5 in an offline mode is by using the original installation media's _:::no-loc text="cab":::_ files. For more information, see [Microsoft .NET Framework 3.5 Deployment Considerations](/windows-hardware/manufacture/desktop/microsoft-net-framework-35-deployment-considerations?view=windows-10).

## Troubleshoot the installation

During installation, you might encounter error **0x800f0906**, **0x800f0907**, **0x800f081f**, or **0x800F0922**, in which case refer to [.NET Framework 3.5 installation error](https://support.microsoft.com/help/2734782/net-framework-3-5-installation-error-0x800f0906--0x800f081f--0x800f09) to see how to resolve these issues.

If you still can't resolve your installation issue or you don't have an internet connection, you can try installing it using your Windows installation media. For more information, see [Deploy .NET Framework 3.5 by using Deployment Image Servicing and Management (DISM)](/windows-hardware/manufacture/desktop/deploy-net-framework-35-by-using-deployment-image-servicing-and-management--dism). If you don't have the installation media, follow the instructions on [Create installation media for Windows](https://support.microsoft.com/help/15088/windows-create-installation-media). For more information about Windows 11 and Windows 10 Features on Demand, see [Features on Demand](/windows-hardware/manufacture/desktop/features-on-demand-v2--capabilities).

> [!WARNING]
> If you're not relying on Windows Update as the source for installing .NET Framework 3.5, you must ensure to strictly use sources from the same corresponding Windows operating system version. Using sources from a different Windows operating system version will either install a mismatched version of .NET Framework 3.5 or cause the installation to fail, leaving the system in an unsupported and unserviceable state.

## Developers and .NET Framework 3.5

If you're a developer that maintains existing software and you need to use .NET Framework 3.5, enable it with the following steps:

1. Install .NET Framework 3.5 on your system using the instructions in this article.
1. Enable **.NET Framework 3.5 Development Tools** in Visual Studio. It's listed in the **Individual Components** page.

## See also

- [Install .NET Framework on Windows and Windows Server](on-windows-and-server.md)
- [Install .NET Framework for developers](guide-for-developers.md)
- [How to: Determine which .NET Framework versions are installed](how-to-determine-which-versions-are-installed.md)
- [Versions and dependencies](versions-and-dependencies.md)
