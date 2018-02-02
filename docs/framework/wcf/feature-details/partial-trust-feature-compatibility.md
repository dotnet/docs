---
title: "Partial Trust Feature Compatibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a36a540b-1606-4e63-88e0-b7c59e0e6ab7
caps.latest.revision: 75
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Partial Trust Feature Compatibility
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] supports a limited subset of functionality when running in a partially-trusted environment. The features supported in partial trust are designed around a specific set of scenarios as described in the [Supported Deployment Scenarios](../../../../docs/framework/wcf/feature-details/supported-deployment-scenarios.md) topic.  
  
## Minimum Permission Requirements  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a subset of features in applications running under either of the following standard named permission sets:  
  
-   Medium Trust permissions  
  
-   Internet Zone permissions  
  
 Attempting to use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in partially-trusted applications with more restrictive permissions may result in security exceptions at runtime.  
  
## Contracts  
 Contracts are subject to the following restrictions when running under partial trust:  
  
-   The service class that implements the `[ServiceContract]` interface must be `public` and have a `public` constructor. If it defines `[OperationContract]` methods, these must be `public`. If it instead implements a `[ServiceContract]` interface, those method implementations can be explicit or `private`, provided that the `[ServiceContract]` interface is `public`.  
  
-   When using the `[ServiceKnownType]` attribute, the method specified must be `public`.  
  
-   `[MessageContract]` classes and their members can be `public`. If the `[MessageContract]` class is defined in the application assembly it can be `internal` and have `internal` members.  
  
## System-Provided Bindings  
 The <xref:System.ServiceModel.BasicHttpBinding> and <xref:System.ServiceModel.WebHttpBinding> are fully supported in a partial trust environment. The <xref:System.ServiceModel.WSHttpBinding> is supported for Transport security mode only.  
  
 Bindings that use transports other than HTTP, such as the <xref:System.ServiceModel.NetTcpBinding>, the <xref:System.ServiceModel.NetNamedPipeBinding>, or the <xref:System.ServiceModel.NetMsmqBinding>, are not supported when running in a partial trust environment.  
  
## Custom Bindings  
 Custom bindings can be created and used in a partial trust environment, but must follow the restrictions specified in this section.  
  
### Transports  
 The only allowed transport binding elements are <xref:System.ServiceModel.Channels.HttpTransportBindingElement> and <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>.  
  
### Encoders  
 The following encoders are allowed:  
  
-   The text encoder (<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>).  
  
-   The binary encoder (<xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>).  
  
-   The Web Message encoder (<xref:System.ServiceModel.Channels.WebMessageEncodingBindingElement>).  
  
 The Message Transmission Optimization Mechanism (MTOM) encoders are not supported.  
  
### Security  
 Partially-trusted applications can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]'s transport-level security features for securing their communication. Message-level security is not supported. Configuring a binding to use message-level security results in an exception at runtime.  
  
### Unsupported Bindings  
 Bindings that use reliable messaging, transactions, or message-level security are not supported.  
  
## Serialization  
 Both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Xml.Serialization.XmlSerializer> are supported in a partial trust environment. However, use of the <xref:System.Runtime.Serialization.DataContractSerializer> is subject to the following conditions:  
  
-   All serializable `[DataContract]` types must be `public`.  
  
-   All serializable `[DataMember]` fields or properties in a `[DataContract]` type must be public and read/write. The serialization and deserialization of [readonly](http://go.microsoft.com/fwlink/?LinkID=98854) fields is not supported when running [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in a partially-trusted application.  
  
-   The `[Serializable]`/ISerializable programming model is not supported in a partial trust environment.  
  
-   Known types must be specified in code or machine-level configuration (machine.config). Known types cannot be specified in application-level configuration for security reasons.  
  
-   Types that implement <xref:System.Runtime.Serialization.IObjectReference> throw an exception in a partially-trusted environment.  
  
 See the Serialization section in [Partial Trust Best Practices](../../../../docs/framework/wcf/feature-details/partial-trust-best-practices.md) for more information about security when using <xref:System.Runtime.Serialization.DataContractSerializer> safely in a partially-trusted application.  
  
### Collection Types  
 Some collection types implement both <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.Collections.IEnumerable>. Examples include types that implement <xref:System.Collections.Generic.ICollection%601>. Such types can implement a `public` implementation of `GetEnumerator()`, and an explicit implementation of `GetEnumerator()`. In this case, <xref:System.Runtime.Serialization.DataContractSerializer> invokes the `public` implementation of `GetEnumerator()`, and not the explicit implementation of `GetEnumerator()`. If none of the `GetEnumerator()` implementations are `public` and all are explicit implementations, then <xref:System.Runtime.Serialization.DataContractSerializer> invokes `IEnumerable.GetEnumerator()`.  
  
 For collection types when [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is running in a partial trust environment, if none of the `GetEnumerator()` implementations are `public`, or none of them are explicit interface implementations, then a security exception is thrown.  
  
### NetDataContractSerializer  
 Many .NET Framework collection types such as <xref:System.Collections.Generic.List%601>, <xref:System.Collections.ArrayList>, <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Hashtable> are not supported by the <xref:System.Runtime.Serialization.NetDataContractSerializer> in partial trust. These types have the `[Serializable]` attribute set, and as stated previously in the Serialization section, this attribute is not supported in partial trust. The <xref:System.Runtime.Serialization.DataContractSerializer> treats collections in a special way and is thus able to get around this restriction, but the <xref:System.Runtime.Serialization.NetDataContractSerializer> has no such mechanism to circumvent this restriction.  
  
 The <xref:System.DateTimeOffset> type is not supported by the <xref:System.Runtime.Serialization.NetDataContractSerializer> in partial trust.  
  
 A surrogate cannot be used with the <xref:System.Runtime.Serialization.NetDataContractSerializer> (using the <xref:System.Runtime.Serialization.SurrogateSelector> mechanism) when running in partial trust. Note that this restriction applies to using a surrogate, not to serializing it.  
  
## Enabling Common Behaviors to Run  
 Service or endpoint behaviors not marked with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute (APTCA) that are added to the [\<commonBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/commonbehaviors.md) section of a configuration file are not run when the application runs in a partial trust environment and no exception is thrown when this occurs. To enforce the running of common behaviors, you must do one of the following options:  
  
-   Mark your common behavior with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute so that it can run when deployed as a partial trust application. Note that a registry entry can be set on the computer to prevent APTCA-marked assemblies from running. .  
  
-   Ensure that if the application is deployed as a fully-trusted application that users cannot modify the code-access security settings to run the application in a partial trust environment. If they can do so, the behavior does not run and no exception is thrown. To ensure this, see the **levelfinal** option using [Caspol.exe (Code Access Security Policy Tool)](../../../../docs/framework/tools/caspol-exe-code-access-security-policy-tool.md).  
  
 [!INCLUDE[crexample](../../../../includes/crexample-md.md)] a common behavior, see [How to: Lock Down Endpoints in the Enterprise](../../../../docs/framework/wcf/extending/how-to-lock-down-endpoints-in-the-enterprise.md).  
  
## Configuration  
 With one exception, partially-trusted code can only load [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] configuration sections in the local `app.config` file. To load [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] configuration sections that reference [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sections in machine.config or in a root web.config file requires ConfigurationPermission(Unrestricted). Without this permission, references to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] configuration sections (behaviors, bindings) outside of the local configuration file results in an exception when the configuration is loaded.  
  
 The one exception is known-type configuration for serialization, as described in the Serialization section of this topic.  
  
> [!IMPORTANT]
>  Configuration extensions are only supported when running under Full Trust.  
  
## Diagnostics  
  
### Event Logging  
 Limited event logging is supported under partial trust. Only service activation faults and tracing/message logging failures are logged to the Event Log. The maximum number of events that can be logged by a process is 5, to avoid writing excessive messages to the Event Log.  
  
### Message Logging  
 Message logging does not work when [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is run in a partial trust environment. If enabled under partial trust, it does not fail service activation, but no message is logged.  
  
### Tracing  
 Restricted tracing functionality is available when running in a partial trust environment. In the <`listeners`> element in the configuration file, the only types that you can add are <xref:System.Diagnostics.TextWriterTraceListener> and the new <xref:System.Diagnostics.EventSchemaTraceListener>. Use of the standard <xref:System.Diagnostics.XmlWriterTraceListener> may result in incomplete or incorrect logs.  
  
 Supported trace sources are:  
  
-   <xref:System.ServiceModel>  
  
-   <xref:System.Runtime.Serialization>  
  
-   <xref:System.IdentityModel.Claims>, <xref:System.IdentityModel.Policy>, <xref:System.IdentityModel.Selectors>, and <xref:System.IdentityModel.Tokens>.  
  
 The following trace sources are not supported:  
  
-   CardSpace  
  
-   <xref:System.IO.Log>  

-   [System.ServiceModel.Internal.TransactionBridge](https://msdn.microsoft.com/library/system.servicemodel.internal.transactionbridge.aspx)]
  
 The following members of the <xref:System.Diagnostics.TraceOptions> enumeration should not be specified:  
  
-   <xref:System.Diagnostics.TraceOptions.Callstack?displayProperty=nameWithType>  
  
-   <xref:System.Diagnostics.TraceOptions.ProcessId?displayProperty=nameWithType>  
  
 When using tracing in a partial trust environment, ensure that the application has sufficient permissions to store the output of the trace listener. For example, when using the <xref:System.Diagnostics.TextWriterTraceListener> to write trace output to a text file, ensure that the application has the necessary FileIOPermission required to successfully write to the trace file.  
  
> [!NOTE]
>  To avoid flooding the trace files with duplicate errors, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] disables tracing of the resource or action after the first security failure. There is one exception trace for each failed resource access, the first time an attempt is made to access the resource or perform the action.  
  
## WCF Service Host  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service host does not support partial trust. If you want to use a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service in partial trust, do not use the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Service Library Project template in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] to build your service. Instead, create a new Web site in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by choosing the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service Web site template, which can host the service in a Web server on which [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] partial trust is supported.  
  
## Other Limitations  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is generally limited to the security considerations imposed upon it by the hosting application. For example, if [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is hosted in a XAML Browser Application (XBAP), it is subject to XBAP limitations, as described in [Windows Presentation Foundation Partial Trust Security](http://go.microsoft.com/fwlink/?LinkId=89138).  
  
 The following additional features are not enabled when running indigo2 in a partial trust environment:  
  
-   Windows Management Instrumentation (WMI)  
  
-   Event logging is only partially enabled (see discussion in **Diagnostics** section).  
  
-   Performance counters  
  
 Use of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] features that are not supported in a partial trust environment may result in exceptions at runtime.  
  
## Unlisted Features  
 The best way to discover that a piece of information or action is unavailable when running in a partial trust environment is to try to access the resource or do the action inside of a `try` block, and then `catch` the failure. To avoid flooding the trace files with duplicate errors, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] disables tracing of the resource or action after the first security failure. There is one exception trace for each failed resource access, the first time an attempt is made to access the resource or perform the action.  
  
## See Also  
 <xref:System.ServiceModel.Channels.HttpTransportBindingElement>  
 <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>  
 <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.WebMessageEncodingBindingElement>  
 [Supported Deployment Scenarios](../../../../docs/framework/wcf/feature-details/supported-deployment-scenarios.md)  
 [Partial Trust Best Practices](../../../../docs/framework/wcf/feature-details/partial-trust-best-practices.md)
