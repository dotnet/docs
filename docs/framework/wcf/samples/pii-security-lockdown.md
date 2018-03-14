---
title: "PII Security Lockdown"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c44fb338-9527-4dd0-8607-b8787d15acb4
caps.latest.revision: 25
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# PII Security Lockdown
This sample demonstrates how to control several security-related features of a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service by:  
  
-   Encrypting sensitive information in a service's configuration file.  
  
-   Locking elements in the configuration file so that nested service subdirectories cannot override settings.  
  
-   Controlling the logging of Personally Identifiable Information (PII) in trace and message logs.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Management\SecurityLockdown`  
  
## Discussion  
 Each of these features can be used separately or together to control aspects of a service's security. This is not a definitive guide to securing a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 The .NET Framework configuration files can contain sensitive information such as connection strings to connect to databases. In shared, Web-hosted scenarios it may be desirable to encrypt this information in the configuration file for a service so that the data contained within the configuration file is resistant to casual viewing. .NET Framework 2.0 and later has the ability to encrypt portions of the configuration file using the Windows Data Protection application programming interface (DPAPI) or the RSA Cryptographic provider. The aspnet_regiis.exe using the DPAPI or RSA can encrypt select portions of a configuration file.  
  
 In Web-hosted scenarios it is possible to have services in subdirectories of other services. The default semantic for determining configuration values allows configuration files in the nested directories to override the configuration values in the parent directory. In certain situations this may be undesirable for a variety of reasons. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service configuration supports the locking of configuration values so that nested configuration generates exceptions when a nested service is run using overridden configuration values.  
  
 This sample demonstrates how to control the logging of known Personally Identifiable Information (PII) in trace and message logs, such as username and password. By default, logging of known PII is disabled however in certain situations logging of PII can be important in debugging an application. This sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md). In addition, this sample uses tracing and message logging. For more information, see the [Tracing and Message Logging](../../../../docs/framework/wcf/samples/tracing-and-message-logging.md) sample.  
  
## Encrypting Configuration File Elements  
 For security purposes in a shared Web-hosting environment, it may be desirable to encrypt certain configuration elements, such as database connection strings that may contain sensitive information. A configuration element may be encrypted using the aspnet_regiis.exe tool found in the .NET Framework folder For example, %WINDIR%\Micrsoft.NET\Framework\v4.0.20728.  
  
#### To encrypt the values in the appSettings section in Web.config for the sample  
  
1.  Open a command prompt by using Start->Run…. Type in `cmd` and click **OK**.  
  
2.  Navigate to the current .NET Framework directory by issuing the following command: `cd %WINDIR%\Microsoft.NET\Framework\v4.0.20728`.  
  
3.  Encrypt the appSettings configuration settings in the Web.config folder by issuing the following command: `aspnet_regiis -pe "appSettings" -app "/servicemodelsamples" -prov "DataProtectionConfigurationProvider"`.  
  
 More information about encrypting sections of configuration files can be found by reading a how-to on DPAPI in ASP.NET configuration ([Building Secure ASP.NET Applications: Authentication, Authorization, and Secure Communication](http://go.microsoft.com/fwlink/?LinkId=95137)) and a how-to on RSA in ASP.NET configuration ([How To: Encrypt Configuration Sections in ASP.NET 2.0 Using RSA](http://go.microsoft.com/fwlink/?LinkId=95138)).  
  
## Locking configuration file elements  
 In Web-hosted scenarios, it is possible to have services in subdirectories of services. In these situations, configuration values for the service in the subdirectory are calculated by examining values in Machine.config and successively merging with any Web.config files in parent directories moving down the directory tree and finally merging the Web.config file in the directory that contains the service. The default behavior for most configuration elements is to allow configuration files in subdirectories to override the values set in parent directories. In certain situations it may be desirable to prevent configuration files in subdirectories from overriding values set in parent directory configuration.  
  
 The .NET Framework provides a way to lock configuration file elements so that configurations that override locked configuration elements throw run-time exceptions.  
  
 A configuration element can be locked by specifying the `lockItem` attribute for a node in the configuration file, for example, to lock the CalculatorServiceBehavior node in the configuration file so that calculator services in nested configuration files cannot change the behavior, the following configuration can be used.  
  
```xml  
<configuration>  
   <system.serviceModel>  
      <behaviors>   
          <serviceBehaviors>   
             <behavior name="CalculatorServiceBehavior" lockItem="true">   
               <serviceMetadata httpGetEnabled="True"/>   
               <serviceDebug includeExceptionDetailInFaults="False" />   
             </behavior>   
          </serviceBehaviors>   
       </behaviors>   
    </system.serviceModel>  
</configuration>  
```  
  
 Locking of configuration elements can be more specific. A list of elements can be specified as the value to the `lockElements` to lock a set of elements within a collection of sub-elements. A list of attributes can be specified as the value to the `lockAttributes` to lock a set of attributes within an element. An entire collection of elements or attributes can be locked except for a specified list by specifying the `lockAllElementsExcept` or `lockAllAttributesExcept` attributes on a node.  
  
## PII Logging Configuration  
 Logging of PII is controlled by two switches: a computer-wide setting found in Machine.config that allows a computer administrator to permit or deny logging of PII and an application setting that allows an application administrator to toggle logging of PII for each source in a Web.config or App.config file.  
  
 The computer-wide setting is controlled by setting `enableLoggingKnownPii` to `true` or `false`, in the `machineSettings` element in Machine.config. For example, the following allows applications to turn on logging of PII.  
  
```xml  
<configuration>  
    <system.serviceModel>  
        <machineSettings enableLoggingKnownPii="true" />  
    </system.serviceModel>  
</configuration>  
```  
  
> [!NOTE]
>  The Machine.config file has a default location: %WINDIR%\Microsoft.NET\Framework\v2.0.50727\CONFIG.  
  
 If the `enableLoggingKnownPii` attribute is not present in Machine.config, logging of PII is not allowed.  
  
 Enabling logging of PII for an application is done by setting the `logKnownPii` attribute of the source element to `true` or `false` in the Web.config or App.config file. For example, the following enables logging of PII for both message logging and trace logging.  
  
```xml  
<configuration>  
    <system.diagnostics>  
        <sources>  
            <source name="System.ServiceModel.MessageLogging" logKnownPii="true">  
                <listeners>   
                ...   
                </listeners>  
            </source>  
            <source name="System.ServiceModel" switchValue="Verbose, ActivityTracing">  
            <listeners>  
        ...   
            </listeners>  
            </source>  
        </sources>  
    </system.diagnostics>  
</configuration>  
```  
  
 If the `logKnownPii` attribute is not specified, then PII is not logged.  
  
 PII is only logged if both `enableLoggingKnownPii` is set to `true`, and `logKnownPii` is set to `true`.  
  
> [!NOTE]
>  System.Diagnostics ignores all attributes on all sources except the first one listed in the configuration file. Adding the `logKnownPii` attribute to the second source in the configuration file has no effect.  
  
> [!IMPORTANT]
>  To run this sample involves manual modification of Machine.config. Care should be taken when modifying Machine.config as incorrect values or syntax may prevent all .NET Framework applications from running.  
  
 It is also possible to encrypt configuration file elements using DPAPI and RSA. For more information, see the following links:  
  
-   [Building Secure ASP.NET Applications: Authentication, Authorization, and Secure Communication](http://go.microsoft.com/fwlink/?LinkId=95137)  
  
-   [How To: Encrypt Configuration Sections in ASP.NET 2.0 Using RSA](http://go.microsoft.com/fwlink/?LinkId=95138)  
  
#### To set up, build and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  Edit Machine.config to set the `enableLoggingKnownPii` attribute to `true`, adding the parent nodes if necessary.  
  
3.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
#### To clean up the sample  
  
1.  Edit Machine.config to set the `enableLoggingKnownPii` attribute to `false`.  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
