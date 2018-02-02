---
title: "Windows Communication Foundation Privacy Information"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Communication Foundation, privacy information"
  - "WCF, privacy information"
  - "privacy information [WCF]"
ms.assetid: c9553724-f3e7-45cb-9ea5-450a22d309d9
caps.latest.revision: 34
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Communication Foundation Privacy Information
Microsoft is committed to protecting end-users' privacy. When you build an application using [!INCLUDE[indigo1](../../../includes/indigo1-md.md)], version 3.0, your application may impact your end-users' privacy. For example, your application may explicitly collect user contact information, or it may request or send information over the Internet to your Web site. If you embed Microsoft technology in your application, that technology may have its own behavior that might affect privacy. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] does not send any information to Microsoft from your application unless you or the end-user choose to send it to us.  
  
## WCF in Brief  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is a distributed messaging framework using the Microsoft .NET Framework that allows developers to build distributed applications. Messages communicated between two applications contain header and body information.  
  
 Headers may contain message routing, security information, transactions, and more depending on the services used by the application. Messages are typically encrypted by default. The one exception is when using the `BasicHttpBinding`, which was designed for use with non-secured, legacy Web services. As the application designer, you are responsible for the final design. Messages in the SOAP body contain application-specific data; however, this data, such as application-defined personal information, can be secured by using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] encryption or confidentiality features. The following sections describe the features that potentially impact privacy.  
  
## Messaging  
 Each [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] message has an address header that specifies the message destination and where the reply should go.  
  
 The address component of an endpoint address is a Uniform Resource Identifier (URI) that identifies the endpoint. The address can be a network address or a logical address. The address may include machine name (hostname, fully qualified domain name) and an IP address. The endpoint address may also contain a globally unique identifier (GUID), or a collection of GUIDs for temporary addressing used to discern each address. Each message contains a message ID that is a GUID. This feature follows the WS-Addressing reference standard.  
  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] messaging layer does not write any personal information to the local machine. However, it might propagate personal information at the network level if a service developer has created a service that exposes such information (for example, by using a person's name in an endpoint name, or including personal information in the endpoint's Web Services Description Language but not requiring clients to use https to access the WSDL). Also, if a developer runs the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool against an endpoint that exposes personal information, the tool's output could contain that information, and the output file is written to the local hard disk.  
  
## Hosting  
 The hosting feature in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] allows applications to start on demand or to enable port sharing between multiple applications. An [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application can be hosted in Internet Information Services (IIS), similar to [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)].  
  
 Hosting does not expose any specific information on the network and it does not keep data on the machine.  
  
## Message Security  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] security provides the security capabilities for messaging applications. The security functions provided include authentication and authorization.  
  
 Authentication is performed by passing credentials between the clients and services. Authentication can be either through transport-level security or through SOAP message-level security, as follows:  
  
-   In SOAP message security, authentication is performed through credentials like username/passwords, X.509 certificates, Kerberos tickets, and SAML tokens, all of which might contain personal information, depending on the issuer.  
  
-   Using transport security, authentication is done through traditional transport authentication mechanisms like HTTP authentication schemes (Basic, Digest, Negotiate, Integrated Windows Authorization, NTLM, None, and Anonymous), and form authentication.  
  
 Authentication can result in a secure session established between the communicating endpoints. The session is identified by a GUID that lasts the lifetime of the security session. The following table shows what is kept and where.  
  
|Data|Storage|  
|----------|-------------|  
|Presentation credentials, such as username, X.509 certificates, Kerberos tokens, and references to credentials.|Standard Windows credential management mechanisms such as the Windows certificate store.|  
|User membership information, such as usernames and passwords.|[!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] membership providers.|  
|Identity information about the service used to authenticate the service to clients.|Endpoint address of the service.|  
|Caller information.|Auditing logs.|  
  
## Auditing  
 Auditing records the success and failure of authentication and authorization events. Auditing records contain the following data: service URI, action URI, and the caller's identification.  
  
 Auditing also records when the administrator modifies the configuration of message logging (turning it on or off), because message logging may log application-specific data in headers and bodies. For [!INCLUDE[wxp](../../../includes/wxp-md.md)], a record is logged in the application event log. For [!INCLUDE[wv](../../../includes/wv-md.md)] and [!INCLUDE[ws2003](../../../includes/ws2003-md.md)], a record is logged in the security event log.  
  
## Transactions  
 The transactions feature provides transactional services to a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application.  
  
 Transaction headers used in transaction propagation may contain Transaction IDs or Enlistment IDs, which are GUIDs.  
  
 The Transactions feature uses the Microsoft Distributed Transaction Coordinator (MSDTC) Transaction Manager (a Windows component) to manage transaction state. By default, communications between Transactions Managers are encrypted. Transaction Managers may log endpoint references, Transaction IDs, and Enlistment IDs as part of their durable state. The lifetime of this state is determined by the lifetime of the Transaction Manager’s log file. The MSDTC service owns and maintains this log.  
  
 The Transactions feature implements the WS-Coordination and WS-Atomic Transaction standards.  
  
## Reliable Sessions  
 Reliable sessions in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provide the transfer of messages when transport or intermediary failures occur. They provide an exactly-once transfer of messages even when the underlying transport disconnects (for example, a TCP connection on a wireless network) or loses a message (an HTTP proxy dropping an outgoing or incoming message). Reliable sessions also recover message reordering (as may happen in the case of multipath routing), preserving the order in which the messages were sent.  
  
 Reliable sessions are implemented using the WS-ReliableMessaging (WS-RM) protocol. They add WS-RM headers that contain session information, which is used to identify all messages associated with a particular reliable session. Each WS-RM session has an identifier, which is a GUID.  
  
 No personal information is retained on the end-user's machine.  
  
## Queued Channels  
 Queues store messages from a sending application on behalf of a receiving application and later forward these messages to the receiving application. They help ensure the transfer of messages from sending applications to receiving applications when, for example, the receiving application is transient. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provides support for queuing by using Microsoft Message Queuing (MSMQ) as a transport.  
  
 The queued channels feature does not add headers to a message. Instead it creates a Message Queuing message with appropriate Message Queuing message properties set, and invokes Message Queuing methods to put the message in the Message Queuing queue. Message Queuing is an optional component that ships with Windows.  
  
 No information is retained on the end-user's machine by the queued channels feature, because it uses Message Queuing as the queuing infrastructure.  
  
## COM+ Integration  
 This feature wraps existing COM and COM+ functionality to create services that are compatible with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services. This feature does not use specific headers and it does not retain data on the end-user's machine.  
  
## COM Service Moniker  
 This provides an unmanaged wrapper to a standard [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client. This feature does not have specific headers on the wire nor does it persist data on the machine.  
  
## Peer Channel  
 A peer channel enables development of multiparty applications using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]. Multiparty messaging occurs in the context of a mesh. Meshes are identified by a name that nodes can join. Each node in the peer channel creates a TCP listener at a user-specified port and establishes connections with other nodes in the mesh to ensure resiliency. To connect to other nodes in the mesh, nodes also exchange some data, including the listener address and the machine's IP addresses, with other nodes in the mesh. Messages sent around in the mesh can contain security information that pertains to the sender to prevent message spoofing and tampering.  
  
 No personal information is stored on the end-user's machine.  
  
## IT Professional Experience  
  
### Tracing  
 The diagnostics feature of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] infrastructure logs messages that pass through the transport and service model layers, and the activities and events associated with these messages. This feature is turned off by default. It is enabled using the application’s configuration file and the tracing behavior may be modified using the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] WMI provider at run time. When enabled, the tracing infrastructure emits a diagnostic trace that contains messages, activities, and processing events to configured listeners. The format and location of the output are determined by the administrator’s listener configuration choices, but is typically an XML formatted file. The administrator is responsible for setting the access control list (ACL) on the trace files. In particular, when hosted by Windows Activation System (WAS), the administrator should make sure the files are not served from the public virtual root directory if that is not desired.  
  
 There are two types of tracing: Message logging and Service Model diagnostic tracing, described in the following section. Each type is configured through its own trace source: <xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A> and <xref:System.ServiceModel>. Both of these logging trace sources capture data that is local to the application.  
  
### Message Logging  
 The message logging trace source (<xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A>) allows an administrator to log the messages that flow through the system. Through configuration, the user may decide to log entire messages or message headers only, whether to log at the transport and/or service model layers, and whether to include malformed messages. Also, the user may configure filtering to restrict which messages are logged.  
  
 By default, message logging is disabled. The local machine administrator can prevent the application-level administrator from turning message logging on.  
  
#### Encrypted and Decrypted Message Logging  
 Messages are logged, encrypted, or decrypted, as described in the following terms.  
  
 Transport Logging  
 Logs messages received and sent at the transport level. These messages contain all headers, and may be encrypted before being sent on the wire and when being received.  
  
 If messages are encrypted before being sent on the wire and when they are received, they are logged encrypted as well. An exception is when a security protocol is used (https): they are then logged decrypted before being sent and after being received even if they are encrypted on the wire.  
  
 Service Logging  
 Logs messages received or sent at the service model level, after channel header processing has occurred, just before and after entering user code.  
  
 Messages logged at this level are decrypted even if they were secured and encrypted on the wire.  
  
 Malformed Message Logging  
 Logs messages that the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] infrastructure cannot understand or process.  
  
 Messages are logged as-is, that is, encrypted or not  
  
 When messages are logged in decrypted or unencrypted form, by default [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] removes security keys and potentially personal information from the messages before logging them. The next sections describe what information is removed, and when. The machine administrator and application deployer must both take certain configuration actions to change the default behavior to log keys and potentially personal information.  
  
#### Information Removed from Message Headers When Logging Decrypted/Unencrypted Messages  
 When messages are logged in decrypted/unencrypted form, security keys and potentially personal information are removed by default from message headers and message bodies before they are logged. The following list shows what [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] considers keys and potentially personal information.  
  
 Keys that are removed:  
  
 \- For xmlns:wst="http://schemas.xmlsoap.org/ws/2004/04/trust" and xmlns:wst="http://schemas.xmlsoap.org/ws/2005/02/trust"  
  
 wst:BinarySecret  
  
 wst:Entropy  
  
 \- For xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.1.xsd" and xmlns:wsse="http://docs.oasis-open.org/wss/2005/xx/oasis-2005xx-wss-wssecurity-secext-1.1.xsd"  
  
 wsse:Password  
  
 wsse:Nonce  
  
 Potentially personal information that is removed:  
  
 \- For xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.1.xsd" and xmlns:wsse="http://docs.oasis-open.org/wss/2005/xx/oasis-2005xx-wss-wssecurity-secext-1.1.xsd"  
  
 wsse:Username  
  
 wsse:BinarySecurityToken  
  
 \- For xmlns:saml="urn:oasis:names:tc:SAML:1.0:assertion" the items in bold (below) are removed:  
  
 \<Assertion  
  
 MajorVersion="1"  
  
 MinorVersion="1"  
  
 AssertionId="[ID]"  
  
 Issuer="[string]"  
  
 IssueInstant="[dateTime]"  
  
 >  
  
 \<Conditions NotBefore="[dateTime]" NotOnOrAfter="[dateTime]">  
  
 \<AudienceRestrictionCondition>  
  
 \<Audience>[uri]\</Audience>+  
  
 \</AudienceRestrictionCondition>*  
  
 \<DoNotCacheCondition />*  
  
 <\!-- abstract base type  
  
 \<Condition />*  
  
 -->  
  
 \</Conditions>?  
  
 \<Advice>  
  
 \<AssertionIDReference>[ID]\</AssertionIDReference>*  
  
 \<Assertion>[assertion]\</Assertion>*  
  
 [any]*  
  
 \</Advice>?  
  
 <\!-- Abstract base types  
  
 \<Statement />*  
  
 \<SubjectStatement>  
  
 \<Subject>  
  
 `<NameIdentifier`  
  
 `NameQualifier="[string]"?`  
  
 `Format="[uri]"?`  
  
 `>`  
  
 `[string]`  
  
 `</NameIdentifier>?`  
  
 \<SubjectConfirmation>  
  
 \<ConfirmationMethod>[anyUri]\</ConfirmationMethod>+  
  
 \<SubjectConfirmationData>[any]\</SubjectConfirmationData>?  
  
 \<ds:KeyInfo>...\</ds:KeyInfo>?  
  
 \</SubjectConfirmation>?  
  
 \</Subject>  
  
 \</SubjectStatement>*  
  
 -->  
  
 \<AuthenticationStatement  
  
 AuthenticationMethod="[uri]"  
  
 AuthenticationInstant="[dateTime]"  
  
 >  
  
 [Subject]  
  
 `<SubjectLocality`  
  
 `IPAddress="[string]"?`  
  
 `DNSAddress="[string]"?`  
  
 `/>?`  
  
 <AuthorityBinding  
  
 AuthorityKind="[QName]"  
  
 Location="[uri]"  
  
 Binding="[uri]"  
  
 />*  
  
 \</AuthenticationStatement>*  
  
 \<AttributeStatement>  
  
 [Subject]  
  
 \<Attribute  
  
 AttributeName="[string]"  
  
 AttributeNamespace="[uri]"  
  
 >  
  
 `<AttributeValue>[any]</AttributeValue>+`  
  
 \</Attribute>+  
  
 \</AttributeStatement>*  
  
 \<AuthorizationDecisionStatement  
  
 Resource="[uri]"  
  
 Decision="[Permit&#124;Deny&#124;Indeterminate]"  
  
 >  
  
 [Subject]  
  
 \<Action Namespace="[uri]">[string]\</Action>+  
  
 \<Evidence>  
  
 \<AssertionIDReference>[ID]\</AssertionIDReference>+  
  
 \<Assertion>[assertion]\</Assertion>+  
  
 \</Evidence>?  
  
 \</AuthorizationDecisionStatement>*  
  
 \</Assertion>  
  
#### Information Removed from Message Bodies When Logging Decrypted/Unencrypted Messages  
 As previously described, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] removes keys and known potentially personal information from message headers for logged decrypted/unencrypted messages. In addition, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] removes keys and known potentially personal information from message bodies for the body elements and actions in the following list, which describe security messages involved in key exchange.  
  
 For the following namespaces:  
  
 xmlns:wst="http://schemas.xmlsoap.org/ws/2004/04/trust" and xmlns:wst="http://schemas.xmlsoap.org/ws/2005/02/trust" (for example, if no action available)  
  
 Information is removed for these body elements, which involve key exchange:  
  
 wst:RequestSecurityToken  
  
 wst:RequestSecurityTokenResponse  
  
 wst:RequestSecurityTokenResponseCollection  
  
 Information is also removed for each of the following Actions:  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Renew  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Renew  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Cancel  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Cancel  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Validate  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Validate  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Amend  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Amend  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Renew  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Renew  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Cancel  
  
 http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Cancel  
  
 http://schemas.xmlsoap.org/ws/2004/04/security/trust/RST/SCT  
  
 http://schemas.xmlsoap.org/ws/2004/04/security/trust/RSTR/SCT  
  
 http://schemas.xmlsoap.org/ws/2004/04/security/trust/RST/SCT-Amend  
  
 http://schemas.xmlsoap.org/ws/2004/04/security/trust/RSTR/SCT-Amend  
  
#### No Information Is Removed from Application-specific Headers and Body Data  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] does not track personal information in application-specific headers (for example, query strings) or body data (for example, credit card number).  
  
 When message logging is on, personal information in application-specific headers and body information may be visible in the logs. Again, the application deployer is responsible for setting the ACLs on the configuration and log files. He also can turn off logging if he does not want this information to be visible, or he may filter out this information from the log files after it is logged.  
  
### Service Model Tracing  
 The Service Model trace source (<xref:System.ServiceModel>) enables tracing of activities and events related to message processing. This feature uses the .NET Framework diagnostic functionality from <xref:System.Diagnostics>. As with the <xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A> property, the location and its ACL are user-configurable using .NET Framework application configuration files. As with message logging, the file location is always configured when the administrator enables tracing; thus, the administrator controls the ACL.  
  
 Traces contain message headers when a message is in scope. The same rules for hiding potentially personal information in message headers in the previous section apply: the personal information previously identified is removed by default from the headers in traces. Both the machine administrator and the application deployer must modify the configuration in order to log potentially personal information. However, personal information contained in application-specific headers is logged in traces. The application deployer is responsible for setting the ACLs on the configuration and trace files. He also can turn off tracing if he does not want this information to be visible, or he can filter out this information from the trace files after it is logged.  
  
 As part of ServiceModel Tracing, Unique IDs (called Activity IDs, and typically a GUID) link different activities together as a message flows through different parts of the infrastructure.  
  
#### Custom Trace Listeners  
 For both message logging and tracing, a custom trace listener can be configured, which can send traces and messages on the wire (for example, to a remote database). The application deployer is responsible for configuring custom listeners or enabling users to do so. He is also responsible for any personal information exposed at the remote location, and for properly applying ACLs to this location.  
  
### Other features for IT Professionals  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] has a WMI provider that exposes the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] infrastructure configuration information through WMI (shipped with Windows). By default, the WMI interface is available to administrators.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration uses the .NET Framework configuration mechanism. The configuration files are stored on the machine. The application developer and the administrator create the configuration files and ACL for each of the application's requirements. A configuration file can contain endpoint addresses and links to certificates in the certificate store. The certificates can be used to provide application data to configure various properties of the features used by the application.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] also uses the .NET Framework process dump functionality by calling the <xref:System.Environment.FailFast%2A> method.  
  
### IT Pro Tools  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] also provides the following IT professional tools, which ship in the Windows SDK.  
  
#### SvcTraceViewer.exe  
 The viewer displays [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] trace files. The viewer shows whatever information is contained in the traces.  
  
#### SvcConfigEditor.exe  
 The editor allows the user to create and edit [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration files. The editor shows whatever information is contained in the configuration files. The same task can be accomplished with a text editor.  
  
#### ServiceModel_Reg  
 This tool allows the user to manage ServiceModel installs on a machine. The tool displays status messages in a console window when it runs and, in the process, may display information about the configuration of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] installation.  
  
#### WSATConfig.exe and WSATUI.dll  
 These tools allow IT Professionals to configure interoperable WS-AtomicTransaction network support in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]. The tools display and allow the user to change the values of the most commonly used WS-AtomicTransaction settings stored in the registry.  
  
## Cross-cutting Features  
 The following features are cross-cutting. That is, they can be composed with any of the preceding features.  
  
### Service Framework  
 Headers can contain an instance ID, which is a GUID that associates a message with an instance of a CLR class.  
  
 The Web Services Description Language (WSDL) contains a definition of the port. Each port has an endpoint address and a binding that represents the services used by the application. Exposing WSDL can be turned off using configuration. No information is retained on the machine.  
  
## See Also  
 [Windows Communication Foundation](http://msdn.microsoft.com/library/fd327ade-0260-4c40-adbe-b74645ba3277)  
 [Security](../../../docs/framework/wcf/feature-details/security.md)
