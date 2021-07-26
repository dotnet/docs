---
title: "How to: Install and Configure WCF Activation Components"
description: Learn how to set up the Windows Process Activation Service (WAS) on Windows Vista to host WCF services that do not communicate over HTTP.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "HTTP activation [WCF]"
ms.assetid: 33a7054a-73ec-464d-83e5-b203aeded658
---
# How to: Install and Configure WCF Activation Components

This topic describes the steps required to set up Windows Process Activation Service (also known as WAS) on Windows Vista to host Windows Communication Foundation (WCF) services that do not communicate over HTTP network protocols. The following sections outline the steps for this configuration:

- Install (or confirm the installation of) the WCF activation components.

- Configure WAS to support a non-HTTP protocol. The following procedure configures Windows Vista for TCP activation.

After installing and configuring WAS, see [How to: Host a WCF Service in WAS](how-to-host-a-wcf-service-in-was.md) for the procedures to create a WCF service that exposes an non-HTTP endpoint that employs WAS.

## To install the WCF non-HTTP activation components

1. Click the **Start** button, and then click **Control Panel**.

2. Click **Programs**, and then click **Programs and Features**.

3. On the **Tasks** menu, click **Turn Windows features on or off**.

4. Find the WinFX node, select and then expand it.

5. Select the **WCF Non-Http Activation Components** box and save the setting.

## To configure the WAS to support TCP activation

1. To support net.tcp activation, the default Web site must first be bound to a net.tcp port. You can do this by using Appcmd.exe, which is installed with the IIS 7.0 management toolset. In an administrator-level Command Prompt window, run the following command.

    ```console
    %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.tcp',bindingInformation='808:*']
    ```

    > [!NOTE]
    > This command is a single line of text. This command adds a net.tcp site binding to the default Web site listening on TCP port 808 with any host name.

2. Although all applications within a site share a common net.tcp binding, each application can enable net.tcp support individually. To enable net.tcp for the application, run the following command from an administrator-level command prompt.

    ```console
    %windir%\system32\inetsrv\appcmd.exe set app
    "Default Web Site/<WCF Application>" /enabledProtocols:http,net.tcp
    ```

    > [!NOTE]
    > This command is a single line of text. This command enables the /\<*WCF Application*> application to be accessed using both `http://localhost/<WCF Application>` and `net.tcp://localhost/<WCF Application>`.

     Remove the net.tcp site binding you added for this sample.

     As a convenience, the following two steps are implemented in a batch file called RemoveNetTcpSiteBinding.cmd located in the sample directory.

    1. Remove net.tcp from the list of enabled protocols by running the following command in an administrator-level Command Prompt window.

        ```console
        %windir%\system32\inetsrv\appcmd.exe set app
        "Default Web Site/servicemodelsamples<WCF Application>" " /enabledProtocols:http
        ```

        > [!NOTE]
        > This command is a single line of text.

    2. Remove the net.tcp site binding by running the following command in an elevated Command Prompt window:

        ```console
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"
        --bindings.[protocol='net.tcp',bindingInformation='808:*']
        ```

        > [!NOTE]
        > This command is a single line of text.

## To remove net.tcp from the list of enabled protocols

1. To remove net.tcp from the list of enabled protocols, run the following command in an administrator-level Command Prompt window.

    ```console
    %windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/servicemodelsamples<WCF Application>" " /enabledProtocols:http
    ```

    > [!NOTE]
    > This command is a single line of text.

## To remove the net.tcp site binding

1. To remove the net.tcp site binding run the following command in an administrator-level Command Prompt window.

    ```console
    %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"
    -bindings.[protocol='net.tcp',bindingInformation='808:*']
    ```

    > [!NOTE]
    > This command is a single line of text.

## See also

- [TCP Activation](../samples/tcp-activation.md)
- [MSMQ Activation](../samples/msmq-activation.md)
- [NamedPipe Activation](../samples/namedpipe-activation.md)
- [Windows Server App Fabric Hosting Features](/previous-versions/appfabric/ee677189(v=azure.10))
