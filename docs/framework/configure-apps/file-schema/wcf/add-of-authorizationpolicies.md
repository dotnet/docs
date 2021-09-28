---
description: "Learn more about: <add> of <authorizationPolicies>"
title: "<add> of <authorizationPolicies>"
ms.date: "03/30/2017"
ms.assetid: 613a03d8-4384-4556-bce2-8c23286c0bb0
---
# \<add> of \<authorizationPolicies>

Specifies an authorization policy for claim transformation.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceAuthorization>**](serviceauthorization-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<authorizationPolicies>**](authorizationpolicies.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**  
  
## Syntax  
  
```xml  
<authorizationPolicies>
  <add policyType="String" />
</authorizationPolicies>
```  
  
## Type  

 `Type`  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`policyType`|A required String attribute.<br /><br /> The Windows Communication Foundation (WCF) access control model supports provisioning a set of authorization policies as types. This attribute specifies an authorization policy, which enables transformation of one set of input claims into another set of claims. Access control can be granted or denied based on that.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<authorizationPolicies>](authorizationpolicies.md)|Specifies a collection of authorization policy types.|  
  
## Remarks  

 Each authorization policy contains a single required `policyType` attribute that is a string. The attribute specifies an authorization policy, which enables transformation of one set of input claims into another set of claims. Access control can be granted or denied based on that. For more information on how an authorization policy works, see <xref:System.IdentityModel.Policy.IAuthorizationPolicy> and [Authorization Policy](../../../wcf/samples/authorization-policy.md).  
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceAuthorizationElement>
- <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.ExternalAuthorizationPolicies%2A>
- <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>
- <xref:System.ServiceModel.Configuration.AuthorizationPolicyTypeElement>
- <xref:System.ServiceModel.Configuration.ServiceAuthorizationElement.AuthorizationPolicies%2A>
- <xref:System.ServiceModel.Configuration.AuthorizationPolicyTypeElementCollection>
- <xref:System.IdentityModel.Policy.IAuthorizationPolicy>
- [Authorizing Access to Service Operations](../../../wcf/samples/authorizing-access-to-service-operations.md)
- [How to: Create a Custom Authorization Manager for a Service](../../../wcf/extending/how-to-create-a-custom-authorization-manager-for-a-service.md)
- [\<add>](add-of-authorizationpolicies.md)
- [Authorization Policy](../../../wcf/samples/authorization-policy.md)
