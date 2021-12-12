---
title: When not to deploy to Windows Containers
description: Modernize existing .NET applications with Azure Cloud and Windows containers | When not to deploy to Windows Containers
ms.date: 12/12/2021
---
# When not to deploy to Windows Containers

Some Windows technologies are not supported by Windows Containers. In those cases, you still need to migrate to the standards VMs, usually with just Windows and IIS.

Cases not supported in Windows Containers, as of May 2018:

- Microsoft Message Queuing (MSMQ) currently is only available in Windows Containers based on Windows Server v1803 release, but not in any other prior releases.

  - [Discussion forum](https://social.msdn.microsoft.com/Forums/bce99a7d-aa60-44fa-a348-450855650810/msmqserver-is-it-supported?forum=windowscontainers)

- Microsoft Distributed Transaction Coordinator (MSDTC) currently is not supported in Windows Containers.

  - [GitHub issue](https://github.com/MicrosoftDocs/Virtualization-Documentation/issues/494)

- Microsoft Office currently does not support containers.

- UI apps (client apps with a visual user interface) are not supported scenarios.

- Windows infrastructure roles (DNS, DHCP, DC, NTP, PRINT, File server, IAM etc.) are not supported scenarios.

### Additional resources

- **Virtual machines and containers in Azure**

    <https://azure.microsoft.com/overview/containers/>

> [!div class="step-by-step"]
> [Previous](deploy-existing-net-apps-as-windows-containers.md)
> [Next](when-to-deploy-windows-containers-in-your-on-premises-iaas-vm-infrastructure.md)
