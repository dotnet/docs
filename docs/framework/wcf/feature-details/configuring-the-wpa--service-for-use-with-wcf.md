---
description: "Learn more about: Configuring the Windows Process Activation Service for Use with Windows Communication Foundation"
title: "Configuring the Windows Process Activation Service for Use with Windows Communication Foundation"
ms.date: "03/30/2017"
ms.topic: how-to
---
# Configuring the Windows Process Activation Service for Use with Windows Communication Foundation

This topic describes the steps required to set up Windows Process Activation Service (also known as WAS) in Windows Vista to host Windows Communication Foundation (WCF) services that do not communicate over HTTP network protocols. The following sections outline the steps for this configuration:  
  
- Install (or confirm the installation of) the WCF activation components required.  
  
- Create a WAS site with the network protocol bindings you wish to use, or add a new protocol binding to an existing site.  
  
- Create an application to host your services and enable that application to use the required network protocols.  
  
- Build a WCF service that exposes a non-HTTP endpoint.  
  
## Configuring a Site with Non-HTTP bindings  

 To use a non-HTTP binding with WAS, the site binding must be added to the WAS configuration. The configuration store for WAS is the applicationHost.config file, located in the %windir%\system32\inetsrv\config directory. This configuration store is shared by both WAS and IIS 7.0.  
  
 applicationHost.config is an XML text file that can be opened with any standard text editor (such as Notepad). However, the IIS 7.0 command-line configuration tool (appcmd.exe) is the preferred way to add non-HTTP site bindings.  
  
 The following command adds a net.tcp site binding to the default Web site using appcmd.exe (this command is entered as a single line).  
  
```console  
appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.tcp',bindingInformation='808:*']  
```  
  
 This command adds the new net.tcp binding to the default Web site by adding the line indicated below to the applicationHost.config file.  
  
```xml  
<sites>  
    <site name="Default Web Site" id="1">  
        <bindings>  
            <binding protocol="HTTP" bindingInformation="*:80:" />  
            //The following line is added by the command.  
            <binding protocol="net.tcp" bindingInformation="808:*" />  
        </bindings>  
    </site>  
</sites>  
```  
  
## Enabling an Application to Use Non-HTTP Protocols  

 You can enable or disable individual network protocolsat the application level. The following command illustrates how to enable both the HTTP and net.tcp protocols for an application that runs in the `Default Web Site`.  
  
```console  
appcmd.exe set app "Default Web Site/appOne" /enabledProtocols:net.tcp  
```  
  
 The list of enabled protocols can also be set in the \<applicationDefaults> element of the site's XML configuration stored in ApplicationHost.config.  
  
 The following XML code from applicationHost.config illustrates a site bound to both HTTP and non-HTTP protocols. The additional configuration required to support non-HTTP protocols is called out with comments.  
  
```xml  
<sites>  
    <site name="Default Web Site" id="1">  
      <application path="/">  
        <virtualDirectory path="/" physicalPath="D:\inetpub\wwwroot" />  
      </application>  
      <bindings>  
            <!-- The following two lines are added by the command. -->
            <binding protocol="HTTP" bindingInformation="*:80:" />  
            <binding protocol="net.tcp" bindingInformation="808:*" />  
       </bindings>  
    </site>  
    <siteDefaults>  
        <logFile
        customLogPluginClsid="{FF160663-DE82-11CF-BC0A-00AA006111E0}"  
          directory="D:\inetpub\logs\LogFiles" />  
        <traceFailedRequestsLogging
          directory="D:\inetpub\logs\FailedReqLogFiles" />  
    </siteDefaults>  
    <applicationDefaults
      applicationPool="DefaultAppPool"
      <!-- The following line is inserted by the command. -->
      enabledProtocols="http, net.tcp" />  
    <virtualDirectoryDefaults allowSubDirConfig="true" />  
</sites>  
```  
  
 If you attempt to activate a service using WAS for Non-HTTP activation and you have not installed and configured WAS you may see the following error:  
  
```output  
[InvalidOperationException: The protocol 'net.tcp' does not have an implementation of HostedTransportConfiguration type registered.]   System.ServiceModel.AsyncResult.End(IAsyncResult result) +15778592   System.ServiceModel.Activation.HostedHttpRequestAsyncResult.End(IAsyncResult result) +15698937   System.ServiceModel.Activation.HostedHttpRequestAsyncResult.ExecuteSynchronous(HttpApplication context, Boolean flowContext) +265   System.ServiceModel.Activation.HttpModule.ProcessRequest(Object sender, EventArgs e) +227   System.Web.SyncEventExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute() +80   System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously) +171  
```  
  
 If you see this error ensure WAS for Non-HTTP Activation is installed and configured properly. For more information, see [How to: Install and Configure WCF Activation Components](how-to-install-and-configure-wcf-activation-components.md).  
  
## Building a WCF Service That Uses WAS for Non-HTTP activation  

 Once you perform the steps to install and configure WAS (see [How to: Install and Configure WCF Activation Components](how-to-install-and-configure-wcf-activation-components.md)), configuring a service to use WAS for activation is similar to configuring a service that is hosted in IIS.  
  
 For detailed instructions about building a WAS-activated WCF service, see [How to: Host a WCF Service in WAS](how-to-host-a-wcf-service-in-was.md).  
  
## See also

- [Hosting in Windows Process Activation Service](hosting-in-windows-process-activation-service.md)
- [Windows Server App Fabric Hosting Features](/previous-versions/appfabric/ee677189(v=azure.10))
