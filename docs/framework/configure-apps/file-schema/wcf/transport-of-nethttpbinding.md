---
title: "&lt;transport&gt; of &lt;netHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b180006-1661-43bf-a699-96fd3da469af
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;transport&gt; of &lt;netHttpBinding&gt;
Defines properties that control authentication parameters for the HTTP transport.  
  
\<system.serviceModel>  
\<bindings>  
\<netHttpBinding>  
\<binding>  
\<security>  
\<transport>  
  
## Syntax  
  
```xml
<netHttpBinding>  
  <binding>  
    <security mode="None|Transport|Message|TransportWithMessageCredential|TransportCredentialOnly">  
      <transport clientCredentialType="None|Basic|Digest|Ntlm|Windows"  
                 proxyCredentialType="None|Basic|Digest|Ntlm|Windows" realm="string">  
        <extendedProtectionPolicy policyEnforcement="Never|WhenSupported|Always"  
                                  protectionScenario="TransportSelected|TrustedProxy">  
          <customServiceNames></customServiceNames>  
        </extendedProtectionPolicy>  
      </transport>  
    </security>  
  </binding>  
</netHttpBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|clientCredentialType|-   Specifies the type of credential to be used when performing client authentication using HTTP authentication.  The default is `None`. This attribute is of type <xref:System.ServiceModel.HttpClientCredentialType>.|  
|proxyCredentialType|-   Specifies the type of credential to be used when performing client authentication from within a domain using a proxy over HTTP. This attribute is applicable only when the `mode` attribute of the parent `security` element is `Transport` or `TransportCredentialsOnly`. This attribute is of type <xref:System.ServiceModel.HttpProxyCredentialType>.|  
|realm|A string that specifies the realm that is used by the HTTP authentication scheme for digest or basic authentication. The default is an empty string.|  
|policyEnforcement|This enumeration specifies when the <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> should be enforced.<br /><br /> 1.  Never – The policy is never enforced (Extended Protection is disabled).<br />2.  WhenSupported – The policy is enforced only if the client supports Extended Protection.<br />3.  Always – The policy is always enforced. Clients which don’t support Extended Protection will fail to authenticate.|  
|protectionScenario|This enumeration specifies the protection scenario enforced by the policy.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Messages are not secured during transfer.|  
|Basic|Specifies basic authentication.|  
|Digest|Specifies digest authentication.|  
|Ntlm|Specifies NTLM authentication when possible, and if Windows authentication fails.|  
|Windows|Specifies Windows integrated authentication.|  
  
## proxyCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|-   Messages are not secured during transfer.|  
|Basic|Specifies basic authentication as defined by RFC 2617 – HTTP Authentication: Basic and Digest Authentication.|  
|Digest|Specifies digest authentication as defined by RFC 2617 – HTTP Authentication: Basic and Digest Authentication.|  
|Ntlm|Specifies NTLM authentication when possible, and if Windows authentication fails.|  
|Windows|Specifies Windows integrated authentication.|  
|Certificate|Performs client authentication using a certificate. This option works only if the `Mode` attribute of the parent `security` element is set to Transport, and will not work if it is set to TransportCredentialOnly.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-nethttpbinding.md)|Defines the security capabilities for the [\<netHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/nethttpbinding.md).|  
  
## Example  
 The following example demonstrates the use of SSL transport security with the basic binding. By default, the basic binding supports HTTP communication.  
  
```xml
<system.serviceModel>  
  <services>  
    <service type="Microsoft.ServiceModel.Samples.CalculatorService"  
             behaviorConfiguration="CalculatorServiceBehavior">  
      <endpoint address=""  
                binding="netHttpBinding"  
                bindingConfiguration="Binding1"   
                contract="Microsoft.ServiceModel.Samples.ICalculator" />  
    </service>  
  </services>  
  <bindings>  
    <netHttpBinding>  
      <!-- Configure basicHttpBinding with Transport security -- >  
      <!-- mode and clientCredentialType set to None.-->  
      <binding name="Binding1">  
        <security mode="Transport">  
          <transport clientCredentialType="None"  
                     proxyCredentialType="None">  
            <extendedProtectionPolicy policyEnforcement="WhenSupported"  
                                      protectionScenario="TransportSelected">  
              <customServiceNames></customServiceNames>  
            </extendedProtectionPolicy>
          </transport> 
        </security>  
      </binding>  
    </netHttpBinding>  
  </bindings>  
</system.serviceModel>  
```  
  
## See Also  
 <xref:System.ServiceModel.BasicHttpSecurityMode.Transport>
 <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement>  
 <xref:System.ServiceModel.HttpTransportSecurity>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
