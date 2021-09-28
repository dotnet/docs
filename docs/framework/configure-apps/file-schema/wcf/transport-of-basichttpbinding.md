---
description: "Learn more about: <transport> of <basicHttpBinding>"
title: "<transport> of <basicHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 4c5ba293-3d7e-47a6-b84e-e9022857b7e5
---
# \<transport> of \<basicHttpBinding>

Defines properties that control authentication parameters for the HTTP transport.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<basicHttpBinding>**](basichttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-basichttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<transport>**  
  
## Syntax  
  
```xml  
<basicHttpBinding>
  <binding>
    <security mode="None|Transport|Message|TransportWithMessageCredential|TransportCredentialOnly">
      <transport clientCredentialType="None|Basic|Digest|Ntlm|Windows"
                 proxyCredentialType="None|Basic|Digest|Ntlm|Windows"
                 realm="String">
        <extendedProtectionPolicy policyEnforcement="Never|WhenSupported|Always"
                                  protectionScenario="TransportSelected|TrustedProxy">
          <customServiceNames>
          </customServiceNames>
        </extendedProtectionPolicy>
      </transport>
    </security>
  </binding>
</basicHttpBinding>
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
|[\<security>](security-of-basichttpbinding.md)|Defines the security capabilities for the [\<basicHttpBinding>](basichttpbinding.md).|  
  
## Example  

 The following example demonstrates the use of SSL transport security with the basic binding. By default, the basic binding supports HTTP communication.  
  
```xml  
<system.serviceModel>
  <services>
    <service type="Microsoft.ServiceModel.Samples.CalculatorService"
             behaviorConfiguration="CalculatorServiceBehavior">
      <endpoint address=""
                binding="basicHttpBinding"
                bindingConfiguration="Binding1"
                contract="Microsoft.ServiceModel.Samples.ICalculator" />
    </service>
  </services>
  <bindings>
    <basicHttpBinding>
      <!-- Configure basicHttpBinding with Transport security -->
      <!-- mode and clientCredentialType set to None. -->
      <binding name="Binding1">
        <security mode="Transport">
          <transport clientCredentialType="None"
                     proxyCredentialType="None">
            <extendedProtectionPolicy policyEnforcement="WhenSupported"
                                      protectionScenario="TransportSelected">
              <customServiceNames>
              </customServiceNames>
            </extendedProtectionPolicy>
          </transport>
        </security>
      </binding>
    </basicHttpBinding>
  </bindings>
</system.serviceModel>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.BasicHttpSecurityElement.Transport%2A>
- <xref:System.ServiceModel.BasicHttpSecurity.Transport%2A>
- <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement>
- <xref:System.ServiceModel.HttpTransportSecurity>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
