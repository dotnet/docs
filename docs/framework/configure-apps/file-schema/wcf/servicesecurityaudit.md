---
title: "&lt;serviceSecurityAudit&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ba517369-a034-4f8e-a2c4-66517716062b
caps.latest.revision: 17
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;serviceSecurityAudit&gt;
Specifies settings that enable auditing of security events during service operations.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceSecurityAudit>  
  
## Syntax  
  
```xml  
<serviceSecurityAudit   
   auditLogLocation="Default/Application/Security"  
   messageAuthenticationAuditLevel= None/Success/Failure/SuccessOrFailure"   serviceAuthorizationAuditLevel="None/Success/Failure/SuccessOrFailure"  
   suppressAuditFailure="Boolean"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|auditLogLocation|Specifies the location of the audit log. Valid values include the following:<br /><br /> -   Default: Security events are written to the application log on Windows XP, and to the Event Log on Windows Server 2003 and Windows Vista.<br />-   Application: Audit events are written to the Application Event Log.<br />-   Security: Audit events are written to the Security Event Log.<br /><br /> The default value is Default. For more information, see <xref:System.ServiceModel.AuditLogLocation>.|  
|suppressAuditFailure|A Boolean value that specifies the behavior for suppressing failures of writing to the audit log.<br /><br /> Applications should be notified for failures of writing to the audit log. If your application is not designed to handle audit failures, you should use this attribute to suppress failures in writing to the audit log.<br /><br /> If this attribute is `true`, exceptions other than OutOfMemoryException, StackOverFlowException, ThreadAbortException, and ArgumentException that result from attempts to write audit events are handled by the system, and are not propagated to the application. If this attribute is `false`, all exceptions that result from attempts to write audit events are passed up to the application.<br /><br /> The default is `true`.|  
|serviceAuthorizationAuditLevel|Specifies the types of authorization events that are recorded in the audit log. Valid values include the following:<br /><br /> -   None: No auditing of service authorization events is performed.<br />-   Success: Only successful service authorization events are audited.<br />-   Failure: Only failure service authorization events are audited.<br />-   SuccessOrFailure: Both success and failure service authorization events are audited.<br /><br /> The default value is None. For more information, see <xref:System.ServiceModel.AuditLevel>.|  
|messageAuthenticationAuditLevel|Specifies the type of message authentication audit events logged. Valid values include the following:<br /><br /> -   None: No audit events are generated.<br />-   Success: Only successful security (full validation including message signature validation, cipher, and token validation) events are logged.<br />-   Failure: Only failure events are logged.<br />-   SuccessOrFailure: Both success and failure events are logged.<br /><br /> The default value is None. For more information, see <xref:System.ServiceModel.AuditLevel>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 This configuraton element is used to audit [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] authentication events. When auditing is enabled, either successful or failed authentication attempts (or both) can be audited. The events are written to one of three event logs: application, security, or the default log for the operating system version. The event logs can all be viewed using the Windows Event viewer.  
  
 For a detailed example of using this configuration element, see [Service Auditing Behavior](../../../../../docs/framework/wcf/samples/service-auditing-behavior.md).  
  
 By default, on Windows XP the audit events can be seen in the Application Log; while on Windows Server 2003 and Windows Vista, the audit events can be seen in the Security Log. The location of audit events can be specified by setting the `auditLogLocation` attribute to 'Application' or 'Security'. For more information, see [How to: Audit Security Events](../../../../../docs/framework/wcf/feature-details/how-to-audit-wcf-security-events.md). If the events are written in the Security Log, the LocalSecurityPolicy-> Enable Object Access should be set for "Success" and "Failure".  
  
 When looking at the event log, the source of the audit events is "ServiceModel Audit 3.0.0.0". Message authentication audit records have a category of "MessageAuthentication" while service authorization audit records have a category of 'ServiceAuthorization'.  
  
 Message authentication audit events cover whether the message was tampered with, whether the message has expired and whether the client can authenticate to the service. They provide information about whether the authentication succeeded or failed along with the identity of the client and the endpoint the message was sent to along with the action associated with the message.  
  
 Service authorization audit events cover the authorization decision made by a service authorization manager. They provide information about whether authorization succeeded or failed along with the identity of the client, the endpoint the message was sent to, the action associated with the message, the identifier of the authorization context that was generated from the incoming message and the type of the authorization manager that made the access decision.  
  
## Example  
  
```xml  
<system.serviceModel>  
   <serviceBehaviors>  
      <behavior name="NewBehavior">  
         <serviceSecurityAudit auditLogLocation="Application"   
             suppressAuditFailure="true"  
             serviceAuthorizationAuditLevel="Success"   
             messageAuthenticationAuditLevel="Success" />  
      </behavior>  
   </serviceBehaviors>  
</behaviors>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceSecurityAuditElement>  
 <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Auditing](../../../../../docs/framework/wcf/feature-details/auditing-security-events.md)  
 [How to: Audit Security Events](../../../../../docs/framework/wcf/feature-details/how-to-audit-wcf-security-events.md)  
 [Service Auditing Behavior](../../../../../docs/framework/wcf/samples/service-auditing-behavior.md)
