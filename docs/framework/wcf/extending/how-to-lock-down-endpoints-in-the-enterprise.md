---
title: "How to: Lock Down Endpoints in the Enterprise"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1b7eaab7-da60-4cf7-9d6a-ec02709cf75d
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Lock Down Endpoints in the Enterprise
Large enterprises often require that applications are developed in compliance with enterprise security policies. The following topic discusses how to develop and install a client endpoint validator that can be used to validate all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] client applications installed on computers.  
  
 In this case, the validator is a client validator because this endpoint behavior is added to the client [\<commonBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/commonbehaviors.md) section in the machine.config file. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] loads common endpoint behaviors only for client applications and loads common service behaviors only for service applications. To install this same validator for service applications, the validator must be a service behavior. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [\<commonBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/commonbehaviors.md) section.  
  
> [!IMPORTANT]
>  Service or endpoint behaviors not marked with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute (APTCA) that are added to the [\<commonBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/commonbehaviors.md) section of a configuration file are not run when the application runs in a partial trust environment, and no exception is thrown when this occurs. To enforce the running of common behaviors such as validators, you must either:  
>   
>  -- Mark your common behavior with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute so that it can run when deployed as a Partial Trust application. Note that a registry entry can be set on the computer to prevent APTCA-marked assemblies from running..  
>   
>  -- Ensure that if the application is deployed as a fully-trusted application that users cannot modify the code-access security settings to run the application in a Partial Trust environment. If they can do so, the custom validator does not run and no exception is thrown. For one way to ensure this, see the `levelfinal` option using [Code Access Security Policy Tool (Caspol.exe)](http://go.microsoft.com/fwlink/?LinkId=248222).  
>   
>  For more information, see [Partial Trust Best Practices](../../../../docs/framework/wcf/feature-details/partial-trust-best-practices.md) and [Supported Deployment Scenarios](../../../../docs/framework/wcf/feature-details/supported-deployment-scenarios.md).  
  
### To create the endpoint validator  
  
1.  Create an <xref:System.ServiceModel.Description.IEndpointBehavior> with the desired validation steps in the <xref:System.ServiceModel.Description.IEndpointBehavior.Validate%2A> method. The following code provides an example. (The `InternetClientValidatorBehavior` is taken from the [Security Validation](../../../../docs/framework/wcf/samples/security-validation.md) sample.)  
  
     [!code-csharp[LockdownValidation#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/internetclientvalidatorbehavior.cs#2)]  
  
2.  Create new <xref:System.ServiceModel.Configuration.BehaviorExtensionElement> that registers the endpoint validator created in step 1. The following code example shows this. (The original code for this example is in the [Security Validation](../../../../docs/framework/wcf/samples/security-validation.md) sample.)  
  
     [!code-csharp[LockdownValidation#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/internetclientvalidatorelement.cs#3)]  
  
3.  Make sure the compiled assembly is signed with a strong name. For details, see the [Strong Name Tool (SN.EXE)](http://go.microsoft.com/fwlink/?LinkId=248217) and the compiler commands for your language.  
  
### To install the validator into the target computer  
  
1.  Install the endpoint validator using the appropriate mechanism. In an enterprise, this can be using Group Policy and Systems Management Server (SMS).  
  
2.  Install the strongly-named assembly into the global assembly cache using the [Gacutil.exe (Global Assembly Cache Tool)](http://msdn.microsoft.com/library/ex0ss12c\(v=vs.110\).aspx).  
  
3.  Use the <xref:System.Configuration?displayProperty=nameWithType> namespace types to:  
  
    1.  Add the extension to the [\<behaviorExtensions>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviorextensions.md) section using a fully-qualified type name and lock the element.  
  
         [!code-csharp[LockdownValidation#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/hostapplication.cs#5)]  
  
    2.  Add the behavior element to the `EndpointBehaviors` property of the [\<commonBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/commonbehaviors.md) section and lock the element. (To install the validator on the service, the validator must be an <xref:System.ServiceModel.Description.IServiceBehavior> and added to the `ServiceBehaviors` property.) The following code example shows the proper configuration after steps a. and b., with the sole exception that there is no strong name.  
  
         [!code-csharp[LockdownValidation#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/hostapplication.cs#6)]  
  
    3.  Save the machine.config file. The following code example performs all the tasks in step 3 but saves a copy of the modified machine.config file locally.  
  
         [!code-csharp[LockdownValidation#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/hostapplication.cs#7)]  
  
## Example  
 The following code example shows how to add a common behavior to the machine.config file and save a copy to the disk. The `InternetClientValidatorBehavior` is taken from the [Security Validation](../../../../docs/framework/wcf/samples/security-validation.md) sample.  
  
 [!code-csharp[LockdownValidation#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/lockdownvalidation/cs/hostapplication.cs#1)]  
  
## .NET Framework Security  
 You may also want to encrypt the configuration file elements. For more information, see the See Also section.  
  
## See Also  
 [Encrypting configuration file elements using DPAPI](http://go.microsoft.com/fwlink/?LinkId=94954)  
 [Encrypting configuration file elements using RSA](http://go.microsoft.com/fwlink/?LinkId=94955)
