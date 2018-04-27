---
title: When not to deploy to Windows Containers
description: .NET Microservices Architecture for Containerized .NET Applications | When not to deploy to Windows Containers
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/26/2017
ms.prod: .net
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# When not to deploy to Windows Containers

Some Windows technologies are not supported by Windows Containers. In those cases, you still need to migrate to standards VMs, usually with just Windows and IIS.

Cases not supported in Windows Containers, as of mid-2017:

-   Microsoft Message Queuing (MSMQ) currently is not supported in Windows Containers.

    -   [UserVoice request forum](https://windowsserver.uservoice.com/forums/304624-containers/suggestions/15719031-create-base-container-image-with-msmq-server)

    -   [Discussion forum](https://social.msdn.microsoft.com/Forums/bce99a7d-aa60-44fa-a348-450855650810/msmqserver-is-it-supported?forum=windowscontainers)

-   Microsoft Distributed Transaction Coordinator (MSDTC) currently is not supported in Windows Containers

    -   [GitHub issue](https://github.com/MicrosoftDocs/Virtualization-Documentation/issues/494)

-   Microsoft Office currently does not support containers

    -   [UserVoice request forum](https://windowsserver.uservoice.com/forums/304624-containers/suggestions/19686220-provide-office-support-for-containers)

For additional not-supported scenarios and requests from the community, see the UserVoice forum for Windows Containers: <https://windowsserver.uservoice.com/forums/304624-containers>.

### Additional resources

-   **Virtual machines and containers in Azure**

    [https://docs.microsoft.com/azure/virtual-machines/windows/containers](https://docs.microsoft.com/azure/virtual-machines/windows/containers)

>[!div class="step-by-step"]
[Previous](deploy-existing-net-apps-as-windows-containers.md)
[Next](when-to-deploy-windows-containers-in-your-on-premises-iaas-vm-infrastructure.md)
