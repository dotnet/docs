---
title: "How to: Disable the Strong-Name Bypass Feature"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "strong-name bypass feature"
  - "strong-named assemblies, loading into trusted application domains"
ms.assetid: 234e088c-3b11-495a-8817-e0962be79d82
caps.latest.revision: 30
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Disable the Strong-Name Bypass Feature
Starting with the .NET Framework version 3.5 Service Pack 1 (SP1), strong-name signatures are not validated when an assembly is loaded into a full-trust <xref:System.AppDomain> object, such as the default <xref:System.AppDomain> for the `MyComputer` zone. This is referred to as the strong-name bypass feature. In a full-trust environment, demands for <xref:System.Security.Permissions.StrongNameIdentityPermission> always succeed for signed, full-trust assemblies regardless of their signature. The only restriction is that the assembly must be fully trusted because its zone is fully trusted. Because the strong name is not a determining factor under these conditions, there is no reason for it to be validated. Bypassing the validation of strong-name signatures provides significant performance improvements.  
  
 The bypass feature applies to any full-trust assembly that is not delay-signed and that is loaded into any full-trust <xref:System.AppDomain> from the directory specified by its <xref:System.AppDomainSetup.ApplicationBase%2A> property.  
  
 You can override the bypass feature for all applications on a computer by setting a registry key value. You can override the setting for a single application by using an application configuration file. You cannot reinstate the bypass feature for a single application if it has been disabled by the registry key.  
  
 When you override the bypass feature, the strong name is validated only for correctness; it is not checked for a <xref:System.Security.Permissions.StrongNameIdentityPermission>. If you want to confirm a specific strong name, you have to perform that check separately.  
  
> [!IMPORTANT]
>  The ability to force strong-name validation depends on a registry key, as described in the following procedure. If an application is running under an account that does not have access control list (ACL) permission to access that registry key, the setting is ineffective. You must ensure that ACL rights are configured for this key so that it can be read for all assemblies.  
  
### To disable the strong-name bypass feature for all applications  
  
-   On 32-bit computers, in the system registry, create a DWORD entry with a value of 0 named `AllowStrongNameBypass` under the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework key.  
  
-   On 64-bit computers, in the system registry, create a DWORD entry with a value of 0 named `AllowStrongNameBypass` under the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework and HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\\.NETFramework keys.  
  
### To disable the strong-name bypass feature for a single application  
  
1.  Open or create the application configuration file.  
  
     For more information about this file, see the Application Configuration Files section in [Configuring Apps](../../../docs/framework/configure-apps/index.md).  
  
2.  Add the following entry:  
  
    ```xml  
    <configuration>  
      <runtime>  
        <bypassTrustedAppStrongNames enabled="false" />  
      </runtime>  
    </configuration>  
    ```  
  
 You can restore the bypass feature for the application by removing the configuration file setting or by setting the attribute to "true".  
  
> [!NOTE]
>  You can turn strong-name validation on and off for an application only if the bypass feature is enabled for the computer. If the bypass feature has been turned off for the computer, strong names are validated for all applications and you cannot bypass validation for a single application.  
  
## See Also  
 [Sn.exe (Strong Name Tool)](../../../docs/framework/tools/sn-exe-strong-name-tool.md)  
 [\<bypassTrustedAppStrongNames> Element](../../../docs/framework/configure-apps/file-schema/runtime/bypasstrustedappstrongnames-element.md)  
 [Creating and Using Strong-Named Assemblies](../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md)
