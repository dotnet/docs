---
description: "Learn more about: <serviceAuthorization> element"
title: "<serviceAuthorization> element"
ms.date: "03/30/2017"
ms.assetid: 18cddad5-ddcb-4839-a0ac-1d6f6ab783ca
---
# \<serviceAuthorization> element

Specifies settings that authorize access to service operations

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<serviceAuthorization>**  

## Syntax

```xml
<serviceAuthorization impersonateCallerForAllOperations="Boolean"
                      principalPermissionMode="None/UseWindowsGroups/UseAspNetRoles/Custom"
                      roleProviderName="String"
                      serviceAuthorizationManagerType="String">
  <authorizationPolicies>
    <add policyType="String" />
  </authorizationPolicies>
</serviceAuthorization>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements:

### Attributes

|Attribute|Description|  
|---------------|-----------------|  
|impersonateCallerForAllOperations|A Boolean value that specifies if all the operations in the service impersonate the caller. The default is `false`.<br /><br /> When a specific service operation impersonates the caller, the thread context is switched to the caller context before executing the specified service.|  
|principalPermissionMode|Sets the principal used to carry out operations on the server. Values include the following:<br /><br /> -   None<br />-   UseWindowsGroups<br />-   UseAspNetRoles<br />-   Custom<br /><br /> The default value is UseWindowsGroups. The value is of type <xref:System.ServiceModel.Description.PrincipalPermissionMode>. For more information on using this attribute, see [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md).|  
|roleProviderName|A string that specifies the name of the role provider, which provides role information for a Windows Communication Foundation (WCF) application. The default is an empty string.|  
|ServiceAuthorizationManagerType|A string containing the type of the service authorization manager. For more information, see <xref:System.ServiceModel.ServiceAuthorizationManager>.|  

### Child elements

|Element|Description|  
|-------------|-----------------|  
|authorizationPolicies|Contains a collection of authorization policy types, which can be added using the `add` keyword. Each authorization policy contains a single required `policyType` attribute that is a string. The attribute specifies an authorization policy, which enables transformation of one set of input claims into another set of claims. Access control can be granted or denied based on that. For more information, see <xref:System.ServiceModel.Configuration.AuthorizationPolicyTypeElement>.|  

### Parent elements

|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Contains a collection of settings for the behavior of a service.|  

## Remarks

This section contains elements affecting authorization, custom role providers, and impersonation.  
  
The `principalPermissionMode` attribute specifies the groups of users to use when authorizing use of a protected method. The default value is `UseWindowsGroups` and specifies that Windows groups, such as "Administrators" or "Users," are searched for an identity trying to access a resource. You can also specify `UseAspNetRoles` to use a custom role provider that is configured under the \<system.web> element, as shown in the following code:

```xml
<system.web>
  <membership defaultProvider="SqlProvider"
              userIsOnlineTimeWindow="15">
    <providers>
      <clear />
      <add name="SqlProvider"
           type="System.Web.Security.SqlMembershipProvider"
           connectionStringName="SqlConn"
           applicationName="MembershipProvider"
           enablePasswordRetrieval="false"
           enablePasswordReset="false"
           requiresQuestionAndAnswer="false"
           requiresUniqueEmail="true"
           passwordFormat="Hashed" />
    </providers>
  </membership>
  <!-- Other configuration code not shown. -->
</system.web>
```
  
The following code shows the `roleProviderName` used with the `principalPermissionMode` attribute:
  
```xml
<behaviors>
  <behavior name="ServiceBehaviour">
    <serviceAuthorization principalPermissionMode ="UseAspNetRoles"
                          roleProviderName ="SqlProvider" />
  </behavior>
  <!-- Other configuration code not shown. -->
</behaviors>
```

For a detailed example of using this configuration element, see [Authorizing Access to Service Operations](../../../wcf/samples/authorizing-access-to-service-operations.md) and [Authorization Policy](../../../wcf/samples/authorization-policy.md).
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceAuthorizationElement>
- <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Authorizing Access to Service Operations](../../../wcf/samples/authorizing-access-to-service-operations.md)
- [How to: Create a Custom Authorization Manager for a Service](../../../wcf/extending/how-to-create-a-custom-authorization-manager-for-a-service.md)
- [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md)
- [Authorization Policy](../../../wcf/samples/authorization-policy.md)
