---
description: "Learn more about: <authorizationPolicies>"
title: "<authorizationPolicies>"
ms.date: "03/30/2017"
ms.assetid: 5b367489-54d7-408b-8f56-cb157dd68eaf
---
# \<authorizationPolicies>

This configuration section contains a collection of authorization policy types, which can be added using the `add` keyword. Each authorization policy contains a single required `policyType` attribute that is a string. The attribute specifies an authorization policy, which enables transformation of one set of input claims into another set of claims. Access control can be granted or denied based on that. For more information on how an authorization policy works, see <xref:System.IdentityModel.Policy.IAuthorizationPolicy> and [Authorization Policy](../../../wcf/samples/authorization-policy.md).  
  
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
