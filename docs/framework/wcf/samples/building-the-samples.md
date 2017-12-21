---
title: "Building the Windows Communication Foundation Samples"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2899e7a5-9cb2-4e8d-b8d2-f31391549198
caps.latest.revision: 33
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Building the Windows Communication Foundation Samples
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples can be built using Visual Studio 2010 or using the **msbuild** command from the command line. Both procedures are described in this topic.  
  
> [!NOTE]
>  Before building or running any of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples, ensure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
### To build the sample using a command prompt  
  
1.  Open the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt with administrator privileges and navigate to the language-specific subdirectory under the directory location where you installed the sample.  
  
2.  Type `msbuild` at the command line. The client program files are built to client\bin and the service program files are built to service\bin. If the service is hosted by Internet Information Services (IIS), the service program files are also copied to the servicemodelsamples directory and its \bin subdirectory.  
  
> [!NOTE]
>  You must set the ACLs on %systemdrive%\inetpub\wwwroot to grant modify permissions to the account under which you are running. Otherwise some post build events fail. Alternatively, you can leave the ACLs as they are and run the SDK command prompt as administrator.  
  
### To build the sample using Visual Studio  
  
1.  If you are using [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[lserver](../../../../includes/lserver-md.md)], Windows 7, or Windows Server 2008 R2, and running [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] with elevated permission. To do so, right-click the icon on the Start menu and then click **Run as administrator**.  
  
2.  From the **File** menu in [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)], click **Open**, then click **Project/Solution**. Navigate to the language-specific subdirectory under the directory in which you installed the sample, and double-click the .sln file icon to open the solution in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)].  
  
3.  In the **Build** menu, select **Rebuild Solution**. The client program files are built to client\bin and the service program files are built to service\bin. If the service is hosted in IIS, the service program files are also copied to the servicemodelsamples directory and its \bin subdirectory.  
  
> [!NOTE]
>  You must set the ACLs on %systemdrive%\inetpub\wwwroot to grant modify permissions to the account under which you are running. Otherwise some post build events fail. Alternatively, you can leave the ACLs as they are and run the SDK command prompt or Visual Studio as administrator. Some Visual Studio actions (such as attaching a debugger to the ASP.Net worker process) also require administrative privileges.  
  
## Setup Batch Files and Scripts  
 Setup.exe and Cleanup.exe batch files and scripts should be run from a Visual Studio command prompt. Several set up and clean up files perform tasks that require administrative privileges and should be launched with administrator privileges.  
  
## Important Security Information about Metadata Endpoints  
 To prevent unintentional disclosure of potentially sensitive service metadata, the default configuration for [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services disables metadata publishing. This behavior is secure by default, but also means that you cannot use a metadata import tool (such as Svcutil.exe) to generate the client code required to call the service unless the service’s metadata publishing behavior is explicitly enabled in configuration. To make experimenting with the samples easier, almost all samples expose an unsecured metadata publishing endpoint. Such endpoints are potentially available to anonymous unauthenticated consumers and care must be taken before deploying such endpoints to ensure that publicly disclosing a service’s metadata is appropriate. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] publishing service metadata, see the [Metadata Publishing Behavior](../../../../docs/framework/wcf/samples/metadata-publishing-behavior.md) sample. See the [Custom Secure Metadata Endpoint](../../../../docs/framework/wcf/samples/custom-secure-metadata-endpoint.md) sample for a sample securing a metadata endpoint.  
  
## Exception Handling  
 Generally speaking these samples do not include exception handling to keep the code focused on the subject of the sample. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] exception handling, see the [Expected Exceptions](../../../../docs/framework/wcf/samples/expected-exceptions.md) sample.  
  
## Regenerating Clients and Configuration with Svcutil  
 You can use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to regenerate client code and configuration for most of the samples. Some samples require manually edited configuration. For example, if you use Svcutil.exe to regenerate the configuration for a sample that uses client certificate credentials, you must manually specify the credentials previously configured. Some samples use specific Svcutil.exe options to affect the generated code, these options are specified in the specific sample topics.  
  
#### To regenerate the client and configuration files  
  
1.  Open an SDK command prompt and navigate to the language-specific subdirectory under the directory location where you installed the sample.  
  
2.  If the service is a Web-hosted type, use the following command.  
  
    ```  
    svcutil.exe /n:"http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples" http://localhost/servicemodelsamples/service.svc/mex /out:generatedClient.cs  
    ```  
  
     If the service is a self-hosted type the following command.  
  
    ```  
    svcutil.exe /n:"http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples" http://localhost:8000/servicemodelsamples/service.svc/mex /out:generatedClient.cs  
    ```  
  
     Replace http://localhost:8000/ServiceModelSamples/service.svc/mex with the address of the self-hosted service's mex endpoint.  
  
     To generate the client in a Visual Basic type, use the following command.  
  
    ```  
    svcutil.exe /n:"http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples" http://localhost/servicemodelsamples/service.svc/mex /l:vb /out:generatedClient.vb  
    ```  
  
     If the service is a self-hosted type, use the following command.  
  
    ```  
    svcutil.exe /n:"http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples" http://localhost:8000/servicemodelsamples/service.svc/mex /l:vb /out:generatedClient.vb  
    ```  
  
    > [!NOTE]
    >  To skip the generation of client configuration add the **/noConfig** option.  
  
## See Also  
 [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md)  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
