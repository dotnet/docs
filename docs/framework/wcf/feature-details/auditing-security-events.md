---
description: "Learn more about: Auditing Security Events"
title: "Auditing Security Events"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "auditing security events [WCF]"
ms.assetid: 5633f61c-a3c9-40dd-8070-1c373b66a716
---
# Auditing Security Events

Applications created with Windows Communication Foundation (WCF) can log security events (either success, failure, or both) with the auditing feature. The events are written to the Windows system event log and can be examined using the Event Viewer.  
  
 Auditing provides a way for an administrator to detect an attack that has already occurred or is in progress. In addition, auditing can help a developer to debug security-related problems. For example, if an error in the configuration of the authorization or checking policy accidentally denies access to an authorized user, a developer can quickly discover and isolate the cause of this error by examining the event log.  
  
 For more information about WCF security, see [Security Overview](security-overview.md). For more information about programming WCF, see [Basic WCF Programming](../basic-wcf-programming.md).  
  
## Audit Level and Behavior  

 Two levels of security audits exist:  
  
- Service authorization level, in which a caller is authorized.  
  
- Message level, in which WCF checks for message validity and authenticates the caller.  
  
 You can check both audit levels for success or failure, which is known as the *audit behavior*.  
  
## Audit Log Location  

 Once you determine an audit level and behavior, you (or an administrator) can specify a location for the audit log. The three choices include: Default, Application, and Security. When you specify Default, the actual log depends on which system you are using and whether the system supports writing to the security log. For more information, see the "Operating System" section later in this topic.  
  
 To write to the Security log requires the `SeAuditPrivilege`. By default, only Local System and Network Service accounts have this privilege. To manage the Security log functions `read` and `delete` requires the `SeSecurityPrivilege`. By default, only administrators have this privilege.  
  
 In contrast, authenticated users can read and write to the Application log. Windows XP writes audit events to the Application log by default. The log can also contain personal information that is visible to all authenticated users.  
  
## Suppressing Audit Failures  

 Another option during auditing is whether to suppress any audit failure. By default, an audit failure does not affect an application. If required, however, you can set the option to `false`, which causes an exception to be thrown.  
  
## Programming Auditing  

 You can specify auditing behavior either programmatically or through configuration.  
  
### Auditing Classes  

 The following table describes the classes and properties used to program auditing behavior.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>|Enables setting options for auditing as a service behavior.|  
|<xref:System.ServiceModel.AuditLogLocation>|Enumeration to specify which log to write to. The possible values are Default, Application, and Security. When you select Default, the operating system determines the actual log location. See the "Application or Security Event Log Choice" section later in this topic.|  
|<xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.MessageAuthenticationAuditLevel%2A>|Specifies which types of message authentication events are audited at the message level. The choices are `None`, `Failure`, `Success`, and `SuccessOrFailure`.|  
|<xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.ServiceAuthorizationAuditLevel%2A>|Specifies which types of service authorization events are audited at the service level. The choices are `None`, `Failure`, `Success`, and `SuccessOrFailure`.|  
|<xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.SuppressAuditFailure%2A>|Specifies what happens to the client request when auditing fails. For example, when the service attempts to write to the security log, but does not have `SeAuditPrivilege`. The default value of `true` indicates that failures are ignored, and the client request is processed normally.|  
  
 For an example of setting up an application to log audit events, see [How to: Audit Security Events](how-to-audit-wcf-security-events.md).  
  
### Configuration  

 You can also use configuration to specify auditing behavior by adding a [\<serviceSecurityAudit>](../../configure-apps/file-schema/wcf/servicesecurityaudit.md) under the [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md). You must add the element under a [\<behavior>](../../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) as shown in the following code.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <behavior>  
        <!-- auditLogLocation="Application" or "Security" -->  
        <serviceSecurityAudit  
                  auditLogLocation="Application"  
                  suppressAuditFailure="true"  
                  serviceAuthorizationAuditLevel="Failure"  
                  messageAuthenticationAuditLevel="SuccessOrFailure" />
      </behavior>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
 If auditing is enabled and an `auditLogLocation` is not specified, the default log name is "Security" log for the platform supporting writing to the Security log; otherwise, it is "Application" log. Only the Windows Server 2003 and Windows Vista operating systems support writing to the Security log. For more information, see the "Operating System" section later in this topic.  
  
## Security Considerations  

 If a malicious user knows that auditing is enabled, that attacker can send invalid messages that cause audit entries to be written. If the audit log is filled in this manner, the auditing system fails. To mitigate this, set the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.SuppressAuditFailure%2A> property to `true` and use the properties of the Event Viewer to control the auditing behavior.  
  
 Audit events that are written to the Application Log on Windows XP are visible to any authenticated user.  
  
## Choosing Between Application and Security Event Logs  

 The following tables provide information to help you choose whether to log into the Application or the Security event log.  
  
#### Operating System  
  
|System|Application log|Security log|  
|------------|---------------------|------------------|  
|Windows XP SP2 or later|Supported|Not supported|  
|Windows Server 2003 SP1 and Windows Vista|Supported|Thread context must possess `SeAuditPrivilege`|  
  
#### Other Factors  

 In addition to the operating system, the following table describes other settings that control the enablement of logging.  
  
|Factor|Application log|Security log|  
|------------|---------------------|------------------|  
|Audit policy management|Not applicable.|Along with configuration, the Security log is also controlled by the local security authority (LSA) policy. The "Audit object access" category must also be enabled.|  
|Default user experience|All authenticated users can write to the Application log, so no additional permission step is needed for application processes.|The application process (context) must have `SeAuditPrivilege`.|  
  
## See also

- <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>
- <xref:System.ServiceModel.AuditLogLocation>
- [Security Overview](security-overview.md)
- [Basic WCF Programming](../basic-wcf-programming.md)
- [How to: Audit Security Events](how-to-audit-wcf-security-events.md)
- [\<serviceSecurityAudit>](../../configure-apps/file-schema/wcf/servicesecurityaudit.md)
- [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
