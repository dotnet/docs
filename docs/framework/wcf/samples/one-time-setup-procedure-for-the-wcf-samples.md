---
title: "One-Time Setup Procedure for the Windows Communication Foundation Samples"
ms.date: "03/30/2017"
ms.assetid: a5848ffd-3eb5-432d-812e-bd948ccb6bca
---
# One-Time Setup Procedure for the Windows Communication Foundation Samples

Most of the Windows Communication Foundation (WCF) samples are hosted in Internet Information Services (IIS) and run from a common virtual directory. This one-time setup procedure creates a folder on the disk; it also adds a virtual directory to IIS named **ServiceModelSamples**.

The **ServiceModelSamples** virtual directory is used for building and running all samples that use an IIS-hosted service. This is the only virtual directory that is required to run the samples. Building a sample will replace any previously deployed service at this virtual directory; only the most recently built sample will be deployed and available in this virtual directory.

> [!NOTE]
> You must run all commands under a local administrator account. If you are using Windows 7, Windows Vista, or Windows Server 2008 R2, you must also run the command prompt with elevated privileges. To do so, right-click the command prompt icon, and then click **Run as administrator**. All commands in this topic must be run in a command prompt that has the appropriate path settings.  The easiest way to ensure this is by using the Visual Studio Command Prompt. To open this prompt, click **Start**, select **All Programs**, scroll down to **Visual Studio 2010**, select **Visual Studio Tools**, right-click **Visual Studio Command Prompt (2010)**, and then click **Run as administrator**. If you have one of the Visual Studio Express editions installed, this command prompt is not available, and you will have to add "C:\Windows\Microsoft.Net\Framework\v4.0" to the system path.

### One-time setup procedure for WCF samples

1. Ensure that ASP.NET is set up. For more information about how to set up ASP.NET, see [Internet Information Service Hosting Instructions](../../../../docs/framework/wcf/samples/internet-information-service-hosting-instructions.md).

2. Ensure that .NET Framework 4 is installed. Search the following directory for v4.0 (or later): **\Windows\Microsoft.NET\Framework**

3. If Visual Studio 2012 is not installed, and your operating system is not Windows Server 2008 SP2 or later, install [Hotfix 251798](https://go.microsoft.com/fwlink/?LinkId=184693).

4. Run the following commands. For more information about why these commands must be run, see [IIS Hosted Service Fails](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms752252(v=vs.90)).

    > [!WARNING]
    > If IIS is reinstalled, the following commands will need to be run again.

    ```console
    "%WINDIR%\Microsoft.Net\Framework\v4.0.30319\aspnet_regiis" –i –enable
    "%WINDIR%\Microsoft.Net\Framework\v4.0.30319\ServiceModelReg.exe" -r
    ```

    > [!WARNING]
    > Running the command `aspnet_regiis –i –enable` will make the Default App Pool run using .NET Framework 4, which may produce incompatibility issues for other applications on the same computer.

5. Follow the [Firewall Instructions](../../../../docs/framework/wcf/samples/firewall-instructions.md) for enabling the ports used by the samples.

6. Check for the following default directory: \<InstallDrive>:**\WF_WCF_Samples**. If the samples were previously installed, this is the default directory.

7. If the samples are not installed, install them from the samples download location for [C#](https://go.microsoft.com/fwlink/?LinkId=190939).

8. After installing the samples, go to : \<InstallDrive>:**\WF_WCF_Samples\WCF\Setup\\**

9. Run the **Setupvroot.bat** batch file. The following steps are performed:

    - A virtual directory is created in IIS named ServiceModelSamples.

    - New disk directories are created named %SystemDrive%\Inetpub\wwwroot\ServiceModelSamples and %SystemDrive%\Inetpub\wwwroot\ServiceModelSamples\bin.

    If you prefer to set up these directories manually, see the [Virtual Directory Setup Instructions](../../../../docs/framework/wcf/samples/virtual-directory-setup-instructions.md). To revert all changes done in this step, run cleanupvroot.bat after you finish using the samples.

    > [!NOTE]
    > This procedure must be performed only once on a computer, unless cleanupvroot.bat is run.

10. You must grant permission to modify for %SystemDrive%\inetpub\wwwroot to the account under which you are building the samples and the Network Service user. While building, some Web-hosted samples might attempt to copy the compiled binaries to the previously mentioned location, and if you have not set the appropriate permissions, the build will break. Alternatively, you can leave the permissions as they are and run the SDK command prompt or Visual Studio Command Prompt (2012) as Administrator, or build the samples in Visual Studio 2012, also run as Administrator.

    > [!NOTE]
    > If this step is not completed, all IIS-hosted samples will fail while building. Ensure that you set the permissions correctly, or run both the SDK command prompt and Visual Studio Command Prompt (2012) as Administrator.

11. Create a C:\logs directory on the computer; some samples might be expecting it. Make sure that the appropriate account has write access granted to this folder. For Windows 7, Windows Vista, and Windows Server 2008 R2, this account is **Network Service**. For  Windows Server 2008, the account is NT Authority\Network Service. For [!INCLUDE[wxp](../../../../includes/wxp-md.md)] and Windows Server 2003, the account is ASPNET.

12. Run the Setupcerttool.bat file. This file is located in the  \<InstallPath>\WF_WCF_Samples\WCF\Setup\  folder.  This script will perform the following tasks:

    - Build the FindPrivateKey tool.

    - Create a directory called %ProgramFiles%\ServiceModelSampleTools.

    - Copy the new FindPrivateKey tool to this directory.

    This tool is required by samples that use certificates and are hosted in IIS.

    > [!NOTE]
    > For security purposes, remember to remove the virtual directory definition and permissions granted in the setup steps above by running the batch file named Cleanupvroot.bat after you are finished with the samples.

13. Samples that are self-hosted (not hosted in IIS) require permission to register HTTP addresses on the computer for listening. The permission for an HTTP namespace reservation comes from the user account used to run the sample. By default, administrator accounts have the permission to register any HTTP address. Non-administrator accounts must be granted permission for the HTTP namespaces used by the samples. For more information about how to configure namespace reservations, see [Configuring HTTP and HTTPS](../../../../docs/framework/wcf/feature-details/configuring-http-and-https.md).

14. Some samples require Message Queuing. See [Installing Message Queuing (MSMQ)](../../../../docs/framework/wcf/samples/installing-message-queuing-msmq.md) for installation instructions.

    > [!NOTE]
    > Ensure that you start the MSMQ service before you run any samples that require Message Queuing.

15. Some samples require certificates. See [Internet Information Services (IIS) Server Certificate Installation Instructions](../../../../docs/framework/wcf/samples/iis-server-certificate-installation-instructions.md).
