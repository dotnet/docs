---
description: "Learn more about: One-Time Setup Procedure for the Windows Communication Foundation Samples"
title: "One-Time Setup Procedure for the Windows Communication Foundation Samples"
ms.date: "03/30/2017"
ms.assetid: a5848ffd-3eb5-432d-812e-bd948ccb6bca
---
# One-Time Setup Procedure for the Windows Communication Foundation Samples

Most of the Windows Communication Foundation (WCF) samples are hosted in Internet Information Services (IIS) and run from a common virtual directory. This one-time setup procedure creates a folder on the disk; it also adds a virtual directory to IIS named **ServiceModelSamples**.

The **ServiceModelSamples** virtual directory is used for building and running all samples that use an IIS-hosted service. This is the only virtual directory that is required to run the samples. Building a sample will replace any previously deployed service at this virtual directory; only the most recently built sample will be deployed and available in this virtual directory.

> [!NOTE]
>
> - You must run all commands under a local administrator account. If you are using Windows 7, Windows Vista, or Windows Server 2008 R2, you must also run the command prompt with elevated privileges. To do so, right-click the command prompt icon, and then click **Run as administrator**.
> - All commands in this article must be run in a command prompt that has the appropriate path settings. The easiest way to ensure this is by using the [Developer Command Prompt for Visual Studio](/visualstudio/ide/reference/command-prompt-powershell).

## One-time setup procedure for WCF samples

1. Ensure that ASP.NET is set up. For more information about how to set up ASP.NET, see [Internet Information Service Hosting Instructions](internet-information-service-hosting-instructions.md).

2. Ensure that .NET Framework 4+ is installed. Search the following directory for v4.0 (or later): **\Windows\Microsoft.NET\Framework**

3. Ensure you have Visual Studio 2012 or later installed, or your operating system is Windows Server 2008 SP2 or later.

4. Run the following commands. For more information about why these commands must be run, see [IIS Hosted Service Fails](/previous-versions/dotnet/netframework-3.5/ms752252(v=vs.90)).

    > [!WARNING]
    > If IIS is reinstalled, the following commands will need to be run again.

    ```console
    "%WINDIR%\Microsoft.Net\Framework\v4.0.30319\aspnet_regiis" –i –enable
    "%WINDIR%\Microsoft.Net\Framework\v4.0.30319\ServiceModelReg.exe" -r
    ```

    > [!WARNING]
    > Running the command `aspnet_regiis –i –enable` will make the Default App Pool run using .NET Framework 4, which may produce incompatibility issues for other applications on the same computer.

5. Follow the [Firewall Instructions](firewall-instructions.md) for enabling the ports used by the samples.

6. Run the [Setupvroot.bat batch file](https://github.com/dotnet/samples/blob/main/framework/wcf/Setup/setupvroot.bat). The following steps are performed:

    - A virtual directory is created in IIS named ServiceModelSamples.

    - New disk directories are created named %SystemDrive%\Inetpub\wwwroot\ServiceModelSamples and %SystemDrive%\Inetpub\wwwroot\ServiceModelSamples\bin.

    If you prefer to set up these directories manually, see the [Virtual Directory Setup Instructions](virtual-directory-setup-instructions.md). To revert all changes done in this step, run [cleanupvroot.bat](https://github.com/dotnet/samples/blob/main/framework/wcf/Setup/cleanupvroot.bat) after you finish using the samples.

    > [!NOTE]
    > This procedure must be performed only once on a computer, unless you run cleanupvroot.bat.

7. You must grant permission to modify for %SystemDrive%\inetpub\wwwroot to the account under which you are building the samples and the Network Service user. While building, some Web-hosted samples might attempt to copy the compiled binaries to the previously mentioned location, and if you have not set the appropriate permissions, the build will break. Alternatively, you can leave the permissions as they are and run the SDK command prompt or Visual Studio Command Prompt (2012) as Administrator, or build the samples in Visual Studio 2012, also run as Administrator.

    > [!NOTE]
    > If this step is not completed, all IIS-hosted samples will fail while building. Ensure that you set the permissions correctly, or run both the SDK command prompt and Visual Studio Command Prompt as Administrator.

8. Create a C:\logs directory on the computer because some samples might be expecting it. Make sure that the appropriate account has write access granted to this folder. For Windows 7, Windows Vista, and Windows Server 2008 R2, this account is **Network Service**. For  Windows Server 2008, the account is NT Authority\Network Service. For Windows XP and Windows Server 2003, the account is ASPNET.

9. Run the [Setupcerttool.bat file](https://github.com/dotnet/samples/blob/main/framework/wcf/Setup/setupCertTool.bat). This script performs the following tasks:

    - Builds the [FindPrivateKey tool](https://github.com/dotnet/samples/tree/main/framework/wcf/Setup/FindPrivateKey/CS).

    - Creates a directory called %ProgramFiles%\ServiceModelSampleTools.

    - Copies the new FindPrivateKey tool to this directory.

    This tool is required by samples that use certificates and are hosted in IIS.

    > [!NOTE]
    > For security purposes, remember to remove the virtual directory definition and permissions granted in the setup steps above by running the batch file named [cleanupvroot.bat](https://github.com/dotnet/samples/blob/main/framework/wcf/Setup/cleanupvroot.bat) after you're finished with the samples.

10. Samples that are self-hosted (not hosted in IIS) require permission to register HTTP addresses on the computer for listening. The permission for an HTTP namespace reservation comes from the user account used to run the sample. By default, administrator accounts have the permission to register any HTTP address. Non-administrator accounts must be granted permission for the HTTP namespaces used by the samples. For more information about how to configure namespace reservations, see [Configuring HTTP and HTTPS](../feature-details/configuring-http-and-https.md).

11. Some samples require Message Queuing. See [Installing Message Queuing (MSMQ)](installing-message-queuing-msmq.md) for installation instructions.

    > [!NOTE]
    > Ensure that you start the MSMQ service before you run any samples that require Message Queuing.

12. Some samples require certificates. See [Internet Information Services (IIS) Server Certificate Installation Instructions](iis-server-certificate-installation-instructions.md).
