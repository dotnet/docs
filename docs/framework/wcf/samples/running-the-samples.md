---
title: "Running the Windows Communication Foundation Samples"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: db8a83da-95c1-4a21-a9d2-48caeb6398ea
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Running the Windows Communication Foundation Samples
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples can be run in a single-machine or cross-machine configuration. As supplied, the samples are ready for running on a single machine. In a cross-machine configuration, it is necessary to modify a sample's configuration file settings. The following procedures explain how to run a sample in same-machine and cross-machine configurations. Note that there are variations in the steps for services hosted in Internet Information Services (IIS) and the self-hosted samples. Most samples are hosted in IIS; see the sample readme information to determine how it is hosted.  
  
 On [!INCLUDE[wv](../../../../includes/wv-md.md)], samples that are not hosted in IIS require elevated privileges to register a listener with Http.sys. Use Httpcfg.exe to register the service's listening addresses with the account the service is running under, or launch the service from a command prompt running with administrator privileges.  
  
> [!NOTE]
>  Before building or running any of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples, be sure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
### To run the sample on the same machine  
  
1.  If the service is hosted by IIS, ensure that you can access the service using a browser by entering the following address: http://localhost/servicemodelsamples/service.svc. A confirmation page should be displayed in response. If the confirmation page is not displayed, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
2.  If the service is self-hosted, run Service.exe from \service\bin, from under the language-specific folder. Service activity is displayed on the service console window.  
  
3.  Run Client.exe from \client\bin\\, from under the language-specific folder. Client activity is displayed on the client console window.  
  
4.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across machines  
  
1.  If the service is hosted in IIS:  
  
    1.  On the service machine, create a virtual directory named ServiceModelSamples. The batch file Setupvroot.bat included with [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md) can be used to create the disk directory and virtual directory.  
  
    2.  Copy the service program files from %SystemDrive%\Inetpub\wwwroot\servicemodelsamples to the ServiceModelSamples virtual directory on the service machine. Ensure that you include the files in the \bin directory.  
  
    3.  Test that you can access the service from the client machine using a browser.  
  
     If the service is self-hosted:  
  
    1.  On the service machine, create a directory to hold the service files.  
  
    2.  Copy the service program files from the \service\bin\ folder, under the language-specific folder, to the service machine.  
  
    3.  In the service configuration file, change the address value of the endpoint definition to match the new address of your service. Replace any references to "localhost" with a fully-qualified domain name in the address.  
  
    4.  Launch Service.exe from a command prompt.  
  
2.  Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client machine.  
  
3.  Set the endpoint address.  
  
    1.  If the service is not running under a domain account, open the client configuration file and change the address value of the endpoint definition to match the new address of your service. Replace any references to "localhost" with a fully-qualified domain name in the address.  
  
    2.  If the service is running under a domain account, regenerate the client configuration by running Svcutil.exe against the service. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] running Svcutil.exe, see [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md). Use the generated file instead of the configuration file in the sample. The generated configuration file has additional identity information, and contains all settings necessary to connect to the service endpoint even though they are the default settings. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] identity information, see [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md), and [\<identity>](../../../../docs/framework/configure-apps/file-schema/wcf/identity.md).  
  
4.  On the client machine, launch Client.exe from a command prompt.  
  
### To debug a service  
  
1.  Build the solution (both client and service) using the **Build** menu or CTRL+SHIFT+B.  
  
2.  If the service is hosted in IIS:  
  
    1.  Activate the service using a browser by entering the address http://localhost/servicemodelsamples/service.svc.  
  
    2.  In the solution, choose the **Debug** menu and the **Attach to Process** menu item.  
  
    3.  Select the **Show processes from all users** check box.  
  
    4.  Select the host worker process W3wp.exe to debug (select ASPNet_wp.exe on Windows XP).  
  
3.  You can now set breakpoints in the service code and enable breakpoints on exceptions.  
  
4.  Right-click the client project item and choose **Debug**, **Start new instance**.  
  
### To clean up after the sample  
  
-   If the service is hosted in IIS for security purposes, remove the virtual directory definition and permissions granted in the setup steps when you are finished with the samples.  
  
## See Also  
 [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md)  
 [Running the Samples in a Workgroup and Across Machines](http://msdn.microsoft.com/library/a451a525-e7ce-452d-9da9-620221260113)  
 [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b)
