---
title: "How to: Create a Custom Authorization Manager for a Service"
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
  - "Windows Communication Foundation, extending"
  - "OperationRequirement class"
ms.assetid: 6214afde-44c1-4bf5-ba07-5ad6493620ea
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Authorization Manager for a Service
The Identity Model infrastructure in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] supports an extensible claims-based authorization model. Claims are extracted from tokens and optionally processed by custom authorization policies and then placed into an <xref:System.IdentityModel.Policy.AuthorizationContext>. An authorization manager examines the claims in the <xref:System.IdentityModel.Policy.AuthorizationContext> to make authorization decisions.  
  
 By default, authorization decisions are made by the <xref:System.ServiceModel.ServiceAuthorizationManager> class; however these decisions can be overridden by creating a custom authorization manager. To create a custom authorization manager, create a class that derives from <xref:System.ServiceModel.ServiceAuthorizationManager> and implement <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method. Authorization decisions are made in the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method, which returns `true` when access is granted and `false` when access is denied.  
  
 If the authorization decision depends on the contents of the message body, use the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccess%2A> method.  
  
 Because of performance issues, if possible you should redesign your application so that the authorization decision does not require access to the message body.  
  
 Registration of the custom authorization manager for a service can be done in code or configuration.  
  
### To create a custom authorization manager  
  
1.  Derive a class from the <xref:System.ServiceModel.ServiceAuthorizationManager> class.  
  
     [!code-csharp[c_CustomAuthMgr#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customauthmgr/cs/c_customauthmgr.cs#5)]
     [!code-vb[c_CustomAuthMgr#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customauthmgr/vb/c_customauthmgr.vb#5)]  
  
2.  Override the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%28System.ServiceModel.OperationContext%29> method.  
  
     Use the <xref:System.ServiceModel.OperationContext> that is passed to the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%28System.ServiceModel.OperationContext%29> method to make authorization decisions.  
  
     The following code example uses the <xref:System.IdentityModel.Claims.ClaimSet.FindClaims%28System.String%2CSystem.String%29> method to find the custom claim `http://www.contoso.com/claims/allowedoperation` to make an authorization decision.  
  
     [!code-csharp[c_CustomAuthMgr#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customauthmgr/cs/c_customauthmgr.cs#6)]
     [!code-vb[c_CustomAuthMgr#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customauthmgr/vb/c_customauthmgr.vb#6)]  
  
### To register a custom authorization manager using code  
  
1.  Create an instance of the custom authorization manager and assign it to the <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.ServiceAuthorizationManager%2A> property.  
  
     The <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior> can be accessed using <xref:System.ServiceModel.ServiceHostBase.Authorization%2A> property.  
  
     The following code example registers the `MyServiceAuthorizationManager` custom authorization manager.  
  
     [!code-csharp[c_CustomAuthMgr#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customauthmgr/cs/c_customauthmgr.cs#4)]
     [!code-vb[c_CustomAuthMgr#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customauthmgr/vb/c_customauthmgr.vb#4)]  
  
### To register a custom authorization manager using configuration  
  
1.  Open the configuration file for the service.  
  
2.  Add a [\<serviceAuthorization>](../../../../docs/framework/configure-apps/file-schema/wcf/serviceauthorization-element.md) to the [\<behaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md).  
  
     To the [\<serviceAuthorization>](../../../../docs/framework/configure-apps/file-schema/wcf/serviceauthorization-element.md), add a `serviceAuthorizationManagerType` attribute and set its value to the type that represents the custom authorization manager.  
  
3.  Add a binding that secures the communication between the client and service.  
  
     The binding that is chosen for this communication determines the claims that are added to the <xref:System.IdentityModel.Policy.AuthorizationContext>, which the custom authorization manager uses to make authorization decisions. For more details about the system-provided bindings, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md).  
  
4.  Associate the behavior to a service endpoint, by adding a [\<service>](../../../../docs/framework/configure-apps/file-schema/wcf/service.md) element and set the value of the `behaviorConfiguration` attribute to the value of the name attribute for the [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-servicebehaviors.md) element.  
  
     For more information about configuring a service endpoint, see [How to: Create a Service Endpoint in Configuration](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-configuration.md).  
  
     The following code example registers the custom authorization manager `Samples.MyServiceAuthorizationManager`.  
  
    ```xml  
    <configuration>  
      <system.serviceModel>  
        <services>  
          <service   
              name="Microsoft.ServiceModel.Samples.CalculatorService"  
              behaviorConfiguration="CalculatorServiceBehavior">  
            <host>  
              <baseAddresses>  
                <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>  
              </baseAddresses>  
            </host>  
            <endpoint address=""  
                      binding="wsHttpBinding_Calculator"  
                      contract="Microsoft.ServiceModel.Samples.ICalculator" />  
          </service>  
        </services>  
        <bindings>  
          <WSHttpBinding>  
           <binding name = "wsHttpBinding_Calculator">  
             <security mode="Message">  
               <message clientCredentialType="Windows"/>  
             </security>  
            </binding>  
          </WSHttpBinding>  
    </bindings>  
        <behaviors>  
          <serviceBehaviors>  
            <behavior name="CalculatorServiceBehavior">  
              <serviceAuthorization serviceAuthorizationManagerType="Samples.MyServiceAuthorizationManager,MyAssembly" />  
             </behavior>  
         </serviceBehaviors>  
       </behaviors>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
    > [!WARNING]
    >  Note that when you specify the serviceAuthorizationManagerType, the string must contain the fully qualified type name. a comma, and the name of the assembly in which the type is defined. If you leave out the assembly name, WCF will attempt to load the type from System.ServiceModel.dll.  
  
## Example  
 The following code example demonstrates a basic implementation of a <xref:System.ServiceModel.ServiceAuthorizationManager> class that includes overriding the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method. The example code examines the <xref:System.IdentityModel.Policy.AuthorizationContext> for a custom claim and returns `true` when the resource for that custom claim matches the action value from the <xref:System.ServiceModel.OperationContext>. For a more complete implementation of a <xref:System.ServiceModel.ServiceAuthorizationManager> class, see [Authorization Policy](../../../../docs/framework/wcf/samples/authorization-policy.md).  
  
 [!code-csharp[c_CustomAuthMgr#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customauthmgr/cs/c_customauthmgr.cs#2)]
 [!code-vb[c_CustomAuthMgr#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customauthmgr/vb/c_customauthmgr.vb#2)]  
  
## See Also  
 <xref:System.ServiceModel.ServiceAuthorizationManager>  
 [Authorization Policy](../../../../docs/framework/wcf/samples/authorization-policy.md)  
 [Authorization Policy](../../../../docs/framework/wcf/samples/authorization-policy.md)
