---
title: Configure a device for remote management
description: Configure a device for remote management (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Configure a device for remote management (POS for .NET v1.14 SDK Documentation)

Learn how to configure your Microsoft Point of Service for .NET (POS for .NET) v1.14 device to enable remote management.

If you have trouble remotely connecting to your device, you may have to configure your device for remote management. If your device is joined to a domain, some or all of the following configurations may already be configured through Group Policy settings.

## Configure a device for remote management

## To enable remote management by using a local administrator account

1. Sign in to the device with an administrator account.

2. Set the following registry key to disable User Account Control remote restrictions:

    `[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system]"LocalAccountTokenFilterPolicy"=dword:00000001`

    For more information about how to change this registry key, see [Description of User Account Control and remote restrictions](https://go.microsoft.com/fwlink/p/?linkid=259744).

3. Restart your device.

## To enable Windows Management Instrumentation (WMI) traffic through a firewall

1. On the **Start** menu, right-click **Command Prompt** and then click **Run as administrator**.

2. To establish a Windows Firewall exception for WMI traffic, type the following command:

    `netsh advfirewall firewall set rule group="windows management instrumentation (wmi)" new enable=yes`

    > [!IMPORTANT]
    > When running ELM on an OS that uses a language other than English, use the localized group name.

3. (Optional) If ELM displays an error message that WMI did not respond or failed to connect, you can use individual commands for DCOM, WMI service, callback sink, and outgoing connections to enable WMI traffic.

      - To establish a Windows Firewall exception for DCOM port 135, type the following command:

          `netsh advfirewall firewall add rule dir=in name="DCOM" program=%systemroot%\system32\svchost.exe service=rpcss action=allow protocol=TCP localport=135`

      - To establish a Windows Firewall exception for the WMI service, type the following command:

          `netsh advfirewall firewall add rule dir=in name ="WMI" program=%systemroot%\system32\svchost.exe service=winmgmt action = allow protocol=TCP localport=any`

      - To establish a Windows Firewall exception for the sink that receives callbacks from a remote computer, type the following command:

          `netsh advfirewall firewall add rule dir=in name ="UnsecApp" program=%systemroot%\system32\wbem\unsecapp.exe action=allow`

      - To establish a Windows Firewall exception for outgoing connections to a remote computer that the local computer is communicating with asynchronously, type the following command:

          `netsh advfirewall firewall add rule dir=out name ="WMI_OUT" program=%systemroot%\system32\svchost.exe service=winmgmt action=allow protocol=TCP localport=any`

For more information about how to enable WMI traffic, see [Connecting to WMI Remotely](https://go.microsoft.com/fwlink/p/?linkid=248462) on MSDN.

## See Also

#### Other Resources

- [POS Device Manager](pos-device-manager.md)
