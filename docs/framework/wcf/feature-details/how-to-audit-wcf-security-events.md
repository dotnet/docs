---
title: "How to: Audit Windows Communication Foundation Security Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "security [WCF], auditing events"
ms.assetid: e71e9587-3336-46a2-9a9e-d72a1743ecec
caps.latest.revision: 19
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Audit Windows Communication Foundation Security Events
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] allows you to log security events to the Windows event log, which can be viewed using the Windows Event Viewer. This topic explains how to set up an application so that it logs security events. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] auditing, see [Auditing](../../../../docs/framework/wcf/feature-details/auditing-security-events.md).  
  
### To audit security events in code  
  
1.  Specify the audit log location. To do this, set the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.AuditLogLocation%2A> property of the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior> class to one of the <xref:System.ServiceModel.AuditLogLocation> enumeration values, as shown in the following code.  
  
     [!code-csharp[AuditingSecurityEvents#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/auditingsecurityevents/cs/auditingsecurityevents.cs#2)]
     [!code-vb[AuditingSecurityEvents#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/auditingsecurityevents/vb/auditingsecurityevents.vb#2)]  
  
     The <xref:System.ServiceModel.AuditLogLocation> enumeration has three values: `Application`, `Security`, or `Default`. The value specifies one of the logs visible in the Event Viewer, either the Security log or the Application log. If you use the `Default` value, the actual log will depend on the operating system the application is running on. If auditing is enabled and the log location is not specified, the default is the `Security` log for platforms that support writing to the Security log; otherwise, it will write to the `Application` log. Only [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wv](../../../../includes/wv-md.md)] support writing to the Security log by default.  
  
2.  Set up the types of events to audit. You can simultaneously audit service-level events or message-level authorization events. To do this, set the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.ServiceAuthorizationAuditLevel%2A> property or the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.MessageAuthenticationAuditLevel%2A> property to one of the <xref:System.ServiceModel.AuditLevel> enumeration values, as shown in the following code.  
  
     [!code-csharp[AuditingSecurityEvents#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/auditingsecurityevents/cs/auditingsecurityevents.cs#3)]
     [!code-vb[AuditingSecurityEvents#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/auditingsecurityevents/vb/auditingsecurityevents.vb#3)]  
  
3.  Specify whether to suppress or expose failures to the application regarding log audit events. Set the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.SuppressAuditFailure%2A> property to either `true` or `false`, as shown in the following code.  
  
     [!code-csharp[AuditingSecurityEvents#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/auditingsecurityevents/cs/auditingsecurityevents.cs#4)]
     [!code-vb[AuditingSecurityEvents#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/auditingsecurityevents/vb/auditingsecurityevents.vb#4)]  
  
     The default `SuppressAuditFailure` property is `true`, so that the failure to audit does not affect the application. Otherwise, an exception is thrown. For any successful audit, a verbose trace is written. For any failure to audit, the trace is written at the Error level.  
  
4.  Delete the existing <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior> from the collection of behaviors found in the description of a <xref:System.ServiceModel.ServiceHost>. The behavior collection is accessed by the <xref:System.ServiceModel.Description.ServiceDescription.Behaviors%2A> property, which in turn is accessed from the <xref:System.ServiceModel.ServiceHostBase.Description%2A> property. Then add the new <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior> to the same collection, as shown in the following code.  
  
     [!code-csharp[AuditingSecurityEvents#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/auditingsecurityevents/cs/auditingsecurityevents.cs#5)]
     [!code-vb[AuditingSecurityEvents#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/auditingsecurityevents/vb/auditingsecurityevents.vb#5)]  
  
### To set up auditing in configuration  
  
1.  To set up auditing in configuration, add a [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) element to the [\<behaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md) section of the web.config file. Then add a [\<serviceSecurityAudit>](../../../../docs/framework/configure-apps/file-schema/wcf/servicesecurityaudit.md) element and set the various attributes, as shown in the following example.  
  
    ```xml  
    <behaviors>  
       <behavior name="myAuditBehavior">  
          <serviceSecurityAudit auditLogLocation="Application"  
                suppressAuditFailure="false"   
                serviceAuthorizationAuditLevel="None"   
                messageAuthenticationAuditLevel="SuccessOrFailure" />  
          </behavior>  
    </behaviors>  
    ```  
  
2.  You must specify the behavior for the service, as shown in the following example.  
  
    ```xml  
    <services>  
        <service type="WCS.Samples.Service.Echo"   
        behaviorConfiguration=" myAuditBehavior">  
           <endpoint address=""  
                    binding="wsHttpBinding"  
                    bindingConfiguration="CertificateDefault"   
                    contract="WCS.Samples.Service.IEcho" />  
        </service>  
    </services>  
    ```  
  
## Example  
 The following code creates an instance of the <xref:System.ServiceModel.ServiceHost> class and adds a new <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior> to its collection of behaviors.  
  
 [!code-csharp[AuditingSecurityEvents#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/auditingsecurityevents/cs/auditingsecurityevents.cs#1)]
 [!code-vb[AuditingSecurityEvents#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/auditingsecurityevents/vb/auditingsecurityevents.vb#1)]  
  
## .NET Framework Security  
 Setting the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.SuppressAuditFailure%2A> property to `true`, suppresses any failure to generate security audits (if set to `false`, an exception is thrown). However, if you enable the following Windows **Local Security Setting**property, a failure to generate audit events will cause Windows to shut down immediately:  
  
 **Audit: Shut down system immediately if unable to log security audits**  
  
 To set the property, open the **Local Security Settings** dialog box. Under **Security Settings**, click **Local Policies**. Then click **Security Options**.  
  
 If the <xref:System.ServiceModel.AuditLogLocation> property is set to <xref:System.ServiceModel.AuditLogLocation.Security> and **Audit Object Access** is not set in the **Local Security Policy**, audit events will not be written to the Security log. Note that no failure is returned, but audit entries are not written to the Security log.  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior.AuditLogLocation%2A>  
 <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>  
 <xref:System.ServiceModel.AuditLogLocation>  
 [Auditing](../../../../docs/framework/wcf/feature-details/auditing-security-events.md)
