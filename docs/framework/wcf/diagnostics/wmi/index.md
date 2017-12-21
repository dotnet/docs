---
title: "Using Windows Management Instrumentation for Diagnostics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fe48738d-e31b-454d-b5ec-24c85c6bf79a
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Windows Management Instrumentation for Diagnostics
[!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] exposes inspection data of a service at runtime through a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] Windows Management Instrumentation (WMI) provider.  
  
## Enabling WMI  
 WMI is Microsoft's implementation of the Web-Based Enterprise Management (WBEM) standard. [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] the WMI SDK, see [Windows Management Instrumentation](https://msdn.microsoft.com/library/aa394582.aspx). WBEM is an industry standard for how applications expose management instrumentation to external management tools.  
  
 A WMI provider is a component that exposes instrumentation at runtime through a WBEM-compatible interface. It consists of a set of WMI objects that have attribute/value pairs. Pairs can be of a number of simple types. Management tools can connect to the services through the interface at runtime. [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] exposes attributes of services such as addresses, bindings, behaviors, and listeners.  
  
 The built-in WMI provider can be activated in the configuration file of the application. This is done through the `wmiProviderEnabled` attribute of the [\<diagnostics>](../../../../../docs/framework/configure-apps/file-schema/wcf/diagnostics.md) in the [\<system.serviceModel>](../../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md) section, as shown in the following sample configuration.  
  
```xml  
<system.serviceModel>  
    …  
    <diagnostics wmiProviderEnabled="true" />  
    …  
</system.serviceModel>  
```  
  
 This configuration entry exposes a WMI interface. Management applications can now connect through this interface and access the management instrumentation of the application.  
  
## Accessing WMI Data  
 WMI data can be accessed in many different ways. Microsoft provides WMI APIs for scripts, [!INCLUDE[vbprvb](../../../../../includes/vbprvb-md.md)] applications, C++ applications, and the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)]. For more information, see [Using WMI](http://go.microsoft.com/fwlink/?LinkId=95183).  
  
> [!CAUTION]
>  If you use the .NET Framework provided methods to programmatically access WMI data, you should be aware that such methods may throw exceptions when the connection is established. The connection is not established during the construction of the <xref:System.Management.ManagementObject> instance, but on the first request involving actual data exchange. Therefore, you should use a `try..catch` block to catch the possible exceptions.  
  
 You can change the trace and message logging level, as well as message logging options for the `System.ServiceModel` trace source in WMI. This can be done by accessing the [AppDomainInfo](../../../../../docs/framework/wcf/diagnostics/wmi/appdomaininfo.md) instance, which exposes these Boolean properties: `LogMessagesAtServiceLevel`, `LogMessagesAtTransportLevel`, `LogMalformedMessages`, and `TraceLevel`. Therefore, if you configure a trace listener for message logging, but set these options to `false` in configuration, you can later change them to `true` when the application is running. This will effectively enable message logging at runtime. Similarly, if you enable message logging in your configuration file, you can disable it at runtime using WMI.  
  
 You should be aware that if no message logging trace listeners for message logging, or no `System.ServiceModel` trace listeners for tracing are specified in the configuration file, none of your changes are taken into effect, even though the changes are accepted by WMI. For more information on properly setting up the respective listeners, see [Configuring Message Logging](../../../../../docs/framework/wcf/diagnostics/configuring-message-logging.md) and [Configuring Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md). The trace level of all other trace sources specified by configuration is effective when the application starts, and cannot be changed.  
  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] exposes a `GetOperationCounterInstanceName` method for scripting. This method returns a performance counter instance name if you provide it with an operation name. However, it does not validate your input. Therefore, if you provide an incorrect operation name, an incorrect counter name is returned.  
  
 The `OutgoingChannel` property of the `Service` instance does not count channels opened by a service to connect to another service, if the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] client to the destination service is not created within the `Service` method.  
  
 **Caution** WMI only supports a <xref:System.TimeSpan> value up to 3 decimal points. For example, if your service sets one of its properties to <xref:System.TimeSpan.MaxValue>, its value is truncated after 3 decimal points when viewed through WMI.  
  
## Security  
 Because the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] WMI provider allows the discovery of services in an environment, you should exercise extreme caution for granting access to it. If you relax the default administrator-only access, you may allow less-trusted parties access to sensitive data in your environment. Specifically, if you loosen permissions on remote WMI access, flooding attacks can occur. If a process is flooded by excessive WMI requests, its performance can be degraded.  
  
 In addition, if you relax access permissions for the MOF file, less-trusted parties can manipulate the behavior of WMI and alter the objects that are loaded in the WMI schema. For example, fields can be removed such that critical data is concealed from the administrator or that fields that do not populate or cause exceptions are added to the file.  
  
 By default, the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] WMI provider grants "execute method", "provider write", and "enable account" permission for Administrator, and "enable account" permission for ASP.NET, Local Service and Network Service. In particular, on non-[!INCLUDE[wv](../../../../../includes/wv-md.md)] platforms, the ASP.NET account has read access to the WMI ServiceModel namespace. If you do not want to grant these privileges to a particular user group, you should either deactivate the WMI provider (it is disabled by default), or disable access for the specific user group.  
  
 In addition, when you attempt to enable WMI through configuration, WMI may not be enabled due to insufficient user privilege. However, no event is written to the event log to record this failure.  
  
 To modify user privilege levels, use the following steps.  
  
1.  Click Start and then Run and type **compmgmt.msc**.  
  
2.  Right-click **Services and Application/WMI Controls** to select **Properties**.  
  
3.  Select the **Security** Tab, and navigate to the **Root/ServiceModel** namespace. Click the **Security** button.  
  
4.  Select the specific group or user that you want to control access and use the **Allow** or **Deny** checkbox to configure permissions.  
  
## Granting WCF WMI Registration Permissions to Additional Users  
 WCF exposes management data to WMI. It does so by hosting an in-process WMI provider, sometimes called a "decoupled provider". For the management data to be exposed, the account that registers this provider must have the appropriate permissions. In Windows, only a small set of privileged accounts can register decoupled providers by default. This is a problem because users commonly want to expose WMI data from a WCF service running under an account that is not in the default set.  
  
 To provide this access, an administrator must grant the following permissions to the additional account in the following order:  
  
1.  Permission to access to the WCF WMI Namespace.  
  
2.  Permission to register the WCF Decoupled WMI Provider.  
  
#### To grant WMI namespace access permission  
  
1.  Run the following PowerShell script.  
  
    ```powershell  
    write-host ""  
    write-host "Granting Access to root/servicemodel WMI namespace to built in users group"  
    write-host ""  
  
    # Create the binary representation of the permissions to grant in SDDL  
    $newPermissions = "O:BAG:BAD:P(A;CI;CCDCLCSWRPWPRCWD;;;BA)(A;CI;CC;;;NS)(A;CI;CC;;;LS)(A;CI;CC;;;BU)"  
    $converter = new-object system.management.ManagementClass Win32_SecurityDescriptorHelper  
    $binarySD = $converter.SDDLToBinarySD($newPermissions)  
    $convertedPermissions = ,$binarySD.BinarySD  
  
    # Get the object used to set the permissions  
    $security = gwmi -namespace root/servicemodel -class __SystemSecurity  
  
    # Get and output the current settings  
    $binarySD = @($null)  
    $result = $security.PsBase.InvokeMethod("GetSD",$binarySD)  
  
    $outsddl = $converter.BinarySDToSDDL($binarySD[0])  
    write-host "Previous ACL: "$outsddl.SDDL  
  
    # Change the Access Control List (ACL) using SDDL  
    $result = $security.PsBase.InvokeMethod("SetSD",$convertedPermissions)   
  
    # Get and output the current settings  
    $binarySD = @($null)  
    $result = $security.PsBase.InvokeMethod("GetSD",$binarySD)  
  
    $outsddl = $converter.BinarySDToSDDL($binarySD[0])  
    write-host "New ACL:      "$outsddl.SDDL  
    write-host ""  
    ```  
  
     This PowerShell script uses Security Descriptor Definition Language (SDDL) to grant the Built-In Users group access to the "root/servicemodel" WMI namespace. It specifies the following ACLs:  
  
    -   Built-In Administrator (BA) - Already Had Access.  
  
    -   Network Service (NS) - Already Had Access.  
  
    -   Local System (LS) - Already Had Access.  
  
    -   Built-In Users - The group to grant access to.  
  
#### To grant provider registration access  
  
1.  Run the following PowerShell script.  
  
    ```powershell  
    write-host ""  
    write-host "Granting WCF provider registration access to built in users group"  
    write-host ""  
    # Set security on ServiceModel provider  
    $provider = get-WmiObject -namespace "root\servicemodel" __Win32Provider  
  
    write-host "Previous ACL: "$provider.SecurityDescriptor  
    $result = $provider.SecurityDescriptor = "O:BUG:BUD:(A;;0x1;;;BA)(A;;0x1;;;NS)(A;;0x1;;;LS)(A;;0x1;;;BU)"  
  
    # Commit the changes and display it to the console  
    $result = $provider.Put()  
    write-host "New ACL:      "$provider.SecurityDescriptor  
    write-host ""  
    ```  
  
### Granting Access to Arbitrary Users or Groups  
 The example in this section grants WMI Provider registration privileges to all local users. If you want to grant access to a user or group that is not built in, then you must obtain that user or group’s Security Identifier (SID). There is no simple way to get the SID for an arbitrary user. One method is to log on as the desired user and then issue the following shell command.  
  
```  
Whoami /user  
```  
  
 This provides the SID of the current user, but this method cannot be used to get the SID on any arbitrary user. Another method to get the SID is to use the [getsid.exe](http://go.microsoft.com/fwlink/?LinkId=186467) tool from the [Windows 2000 Resource Kit Tools for administrative tasks](http://go.microsoft.com/fwlink/?LinkId=178660). This tool compares the SID of two users (local or domain), and as a side effect prints the two SIDs to the command line. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Well Known SIDs](http://go.microsoft.com/fwlink/?LinkId=186468).  
  
## Accessing Remote WMI Object Instances  
 If you need to access [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] WMI instances on a remote machine, you must enable packet privacy on the tools that you use for access. The following section describes how to achieve these using the WMI CIM Studio, Windows Management Instrumentation Tester, as well as .NET SDK 2.0.  
  
### WMI CIM Studio  
 If you have installed [WMI Administrative Tools](http://go.microsoft.com/fwlink/?LinkId=95185), you can use the WMI CIM Studio to access WMI instances. The tools are in the following folder  
  
 **%windir%\Program Files\WMI Tools\\**  
  
1.  In the **Connect to namespace:** window, type **root\ServiceModel** and click **OK.**  
  
2.  In the **WMI CIM Studio Login** window, click the **Options >>** button to expand the window. Select **Packet privacy** for **Authentication level**, and click **OK**.  
  
### Windows Management Instrumentation Tester  
 This tool is installed by Windows. To run it, launch a command console by typing **cmd.exe** in the **Start/Run** dialog box and click **OK**. Then, type **wbemtest.exe** in the command window. The Windows Management Instrumentation Tester tool is then launched.  
  
1.  Click the **Connect** button on the top right corner of the window.  
  
2.  In the new window, enter **root\ServiceModel** for the **Namespace** field, and select **Packet privacy** for **Authentication level**. Click **Connect**.  
  
### Using Managed Code  
 You can also access remote WMI instances programmatically by using classes provided by the <xref:System.Management> namespace. The following code sample demonstrates how to do this.  
  
```  
String wcfNamespace = String.Format(@"\\{0}\Root\ServiceModel",      
   this.serviceMachineName);  
  
ConnectionOptions connection = new ConnectionOptions();  
connection.Authentication = AuthenticationLevel.PacketPrivacy;  
ManagementScope scope = new ManagementScope(this.wcfNamespace, connection);  
```
