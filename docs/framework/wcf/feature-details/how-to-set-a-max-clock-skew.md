---
title: "How to: Set a Max Clock Skew"
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
  - "MaxClockSkew property"
  - "WCF, custom bindings"
ms.assetid: 491d1705-eb29-43c2-a44c-c0cf996f74eb
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Set a Max Clock Skew
Time-critical functions can be derailed if the clock settings on two computers are different. To mitigate this possibility, you can set the `MaxClockSkew` property to a <xref:System.TimeSpan>. This property is available on two classes:  
  
 <xref:System.ServiceModel.Channels.LocalClientSecuritySettings>  
  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
  
> [!IMPORTANT]
>  Important   For a secure conversation, changes to the `MaxClockSkew` property  must be made when the service or client is bootstrapped. To do this, you must set the property on the <xref:System.ServiceModel.Channels.SecurityBindingElement> returned by the <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters.BootstrapSecurityBindingElement%2A>.  
  
 To change the property on one of the system-provided bindings, you must find the security binding element in the collection of bindings and set the `MaxClockSkew` property to a new value. Two classes derive from the <xref:System.ServiceModel.Channels.SecurityBindingElement>: <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> and <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>. When retrieving the security binding from the collection, you must cast to one of these types in order to correctly set the `MaxClockSkew` property. The following example uses a <xref:System.ServiceModel.WSHttpBinding>, which uses the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>. For a list that specifies which type of security binding to use in each system-provided binding, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md).  
  
### To create a custom binding with a new clock skew value in code  
  
1.  > [!WARNING]
    >  Note   Add references to the following namespaces in your code: <xref:System.ServiceModel.Channels>, <xref:System.ServiceModel.Description>, <xref:System.Security.Permissions>, and <xref:System.ServiceModel.Security.Tokens>.  
  
     Create an instance of a <xref:System.ServiceModel.WSHttpBinding> class and set its security mode to <xref:System.ServiceModel.SecurityMode.Message>.  
  
2.  Create a new instance of the <xref:System.ServiceModel.Channels.BindingElementCollection> class by calling the <xref:System.ServiceModel.WSHttpBinding.CreateBindingElements%2A> method.  
  
3.  Use the <xref:System.ServiceModel.Channels.BindingElementCollection.Find%2A> method of the <xref:System.ServiceModel.Channels.BindingElementCollection> class to find the security binding element.  
  
4.  When using the <xref:System.ServiceModel.Channels.BindingElementCollection.Find%2A> method, cast to the actual type. The example below casts to the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> type.  
  
5.  Set the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.MaxClockSkew%2A> property on the security binding element.  
  
6.  Create a <xref:System.ServiceModel.ServiceHost> with an appropriate service type and base address.  
  
7.  Use the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method to add an endpoint and include the <xref:System.ServiceModel.Channels.CustomBinding>.  
  
     [!code-csharp[c_MaxClockSkew#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_maxclockskew/cs/source.cs#1)]
     [!code-vb[c_MaxClockSkew#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_maxclockskew/vb/source.vb#1)]  
  
### To set the MaxClockSkew in configuration  
  
1.  Create a [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md) in the [\<bindings>](../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) element section.  
  
2.  Create a [\<binding>](../../../../docs/framework/misc/binding.md) element and set the `name` attribute to an appropriate value. The following example sets it to `MaxClockSkewBinding`.  
  
3.  Add an encoding element. The example below adds a [\<textMessageEncoding>](../../../../docs/framework/configure-apps/file-schema/wcf/textmessageencoding.md).  
  
4.  Add a [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md) element and set the `authenticationMode` attribute to an appropriate setting. The following example set the attribute to `Kerberos` to specify that the service use Windows authentication.  
  
5.  Add a [\<localServiceSettings>](../../../../docs/framework/configure-apps/file-schema/wcf/localservicesettings-element.md) and set the `maxClockSkew` attribute to a value in the form of `"##:##:##"`. The following example sets it to 7 minutes. Optionally, add a [\<localServiceSettings>](../../../../docs/framework/configure-apps/file-schema/wcf/localservicesettings-element.md) and set the `maxClockSkew` attribute to an appropriate setting.  
  
6.  Add a transport element. The following example uses an [\<httpTransport>](../../../../docs/framework/configure-apps/file-schema/wcf/httptransport.md).  
  
7.  For a secure conversation, the security settings must occur at the bootstrap in the [\<secureConversationBootstrap>](../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md) element.  
  
    ```xml  
    <bindings>  
      <customBinding>  
        <binding name="MaxClockSkewBinding">  
            <textMessageEncoding />  
            <security authenticationMode="Kerberos">  
               <localClientSettings maxClockSkew="00:07:00" />  
               <localServiceSettings maxClockSkew="00:07:00" />  
               <secureConversationBootstrap>  
                  <localClientSettings maxClockSkew="00:30:00" />  
                  <localServiceSettings maxClockSkew="00:30:00" />  
               </secureConversationBootstrap>  
            </security>  
            <httpTransport />  
        </binding>  
      </customBinding>  
    </bindings>  
    ```  
  
## See Also  
 <xref:System.ServiceModel.Channels.LocalClientSecuritySettings>  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)
