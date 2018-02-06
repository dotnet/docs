---
title: "Code Access Security and ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 93e099eb-daa1-4f1e-b031-c1e10a996f88
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Code Access Security and ADO.NET
The .NET Framework offers role-based security as well as code access security (CAS), both of which are implemented using a common infrastructure supplied by the common language runtime (CLR). In the world of unmanaged code, most applications execute with the permissions of the user or principal. As a result, computer systems can be damaged and private data compromised when malicious or error-filled software is run by a user with elevated privileges.  
  
 By contrast, managed code executing in the .NET Framework includes code access security, which applies to code alone. Whether the code is allowed to run or not depends on the code's origin or other aspects of the code's identity, not solely the identity of the principal. This reduces the likelihood that managed code can be misused.  
  
## Code Access Permissions  
 When code is executed, it presents evidence that is evaluated by the CLR security system. Typically, this evidence comprises the origin of the code including URL, site, and zone, and digital signatures that ensure the identity of the assembly.  
  
 The CLR allows code to perform only those operations that the code has permission to perform. Code can request permissions, and those requests are honored based on the security policy set by an administrator.  
  
> [!NOTE]
>  Code executing in the CLR cannot grant permissions to itself. For example, code can request and be granted fewer permissions than a security policy allows, but it will never be granted more permissions. When granting permissions, start with no permissions at all and then add the narrowest permissions for the particular task being performed. Starting with all permissions and then denying individual ones leads to insecure applications that may contain unintentional security holes from granting more permissions than required. For more information, see [NIB: Configuring Security Policy](http://msdn.microsoft.com/library/0f130bcd-1bba-4346-b231-0bcca7dab1a4) and [NIB: Security Policy Management](http://msdn.microsoft.com/library/d754e05d-29dc-4d3a-a2c2-95eaaf1b82b9).  
  
 There are three types of code access permissions:  
  
-   `Code access permissions` derive from the <xref:System.Security.CodeAccessPermission> class. Permissions are required in order to access protected resources, such as files and environment variables, and to perform protected operations, such as accessing unmanaged code.  
  
-   `Identity permissions` represent characteristics that identify an assembly. Permissions are granted to an assembly based on evidence, which can include items such as a digital signature or where the code originated. Identity permissions also derive from the <xref:System.Security.CodeAccessPermission> base class.  
  
-   `Role-based security permissions` are based on whether a principal has a specified identity or is a member of a specified role. The <xref:System.Security.Permissions.PrincipalPermission> class allows both declarative and imperative permission checks against the active principal.  
  
 To determine whether code is authorized to access a resource or perform an operation, the runtime's security system traverses the call stack, comparing the granted permissions of each caller to the permission being demanded. If any caller in the call stack does not have the demanded permission, a <xref:System.Security.SecurityException> is thrown and access is refused.  
  
### Requesting Permissions  
 The purpose of requesting permissions is to inform the runtime which permissions your application requires in order to run, and to ensure that it receives only the permissions that it actually needs. For example, if your application needs to write data to the local disk, it requires <xref:System.Security.Permissions.FileIOPermission>. If that permission hasn't been granted, the application will fail when it attempts to write to the disk. However, if the application requests `FileIOPermission` and that permission has not been granted, the application will generate the exception at the outset and will not load.  
  
 In a scenario where the application only needs to read data from the disk, you can request that it never be granted any write permissions. In the event of a bug or a malicious attack, your code cannot damage the data on which it operates. For more information, see [NIB: Requesting Permissions](http://msdn.microsoft.com/library/0447c49d-8cba-45e4-862c-ff0b59bebdc2).  
  
## Role-Based Security and CAS  
 Implementing both role-based security and code-accessed security (CAS) enhances overall security for your application. Role-based security can be based on a Windows account or a custom identity, making information about the security principal available to the current thread. In addition, applications are often required to provide access to data or resources based on credentials supplied by the user. Typically, such applications check the role of a user and provide access to resources based on those roles.  
  
 Role-based security enables a component to identify current users and their associated roles at run time. This information is then mapped using a CAS policy to determine the set of permissions granted at run time. For a specified application domain, the host can change the default role-based security policy and set a default security principal that represents a user and the roles associated with that user.  
  
 The CLR uses permissions to implement its mechanism for enforcing restrictions on managed code. Role-based security permissions provide a mechanism for discovering whether a user (or the agent acting on the user's behalf) has a particular identity or is a member of a specified role. For more information, see [Security Permissions](http://msdn.microsoft.com/library/b03757b4-e926-4196-b738-3733ced2bda0).  
  
 Depending on the type of application you are building, you should also consider implementing role-based permissions in the database. For more information on role-based security in SQL Server, see [SQL Server Security](../../../../docs/framework/data/adonet/sql/sql-server-security.md).  
  
## Assemblies  
 Assemblies form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions for a .NET Framework application. An assembly provides a collection of types and resources that are built to work together and form a logical unit of functionality. To the CLR, a type does not exist outside the context of an assembly. For more information on creating and deploying assemblies, see [Programming with Assemblies](../../../../docs/framework/app-domains/programming-with-assemblies.md).  
  
### Strong-naming Assemblies  
 A strong name, or digital signature, consists of the assembly's identity, which includes its simple text name, version number, and culture information (if provided), plus a public key and a digital signature. The digital signature is generated from an assembly file using the corresponding private key. The assembly file contains the assembly manifest, which contains the names and hashes of all the files that make up the assembly.  
  
 Strong naming an assembly gives an application or component a unique identity that other software can use to refer explicitly to it. Strong naming guards assemblies against being spoofed by an assembly that contains hostile code. Strong-naming also ensures versioning consistency among different versions of a component. You must strong name assemblies that will be deployed to the Global Assembly Cache (GAC). For more information, see [Creating and Using Strong-Named Assemblies](../../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md).  
  
## Partial Trust in ADO.NET 2.0  
 In ADO.NET 2.0, the .NET Framework Data Provider for SQL Server, the .NET Framework Data Provider for OLE DB, the .NET Framework Data Provider for ODBC, and the .NET Framework Data Provider for Oracle can now all run in partially trusted environments. In previous releases of the .NET Framework, only <xref:System.Data.SqlClient> was supported in less than full-trust applications.  
  
 At minimum, a partially trusted application using the SQL Server provider must have execution and <xref:System.Data.SqlClient.SqlClientPermission> permissions.  
  
### Permission Attribute Properties for Partial Trust  
 For partial trust scenarios, you can use <xref:System.Data.SqlClient.SqlClientPermissionAttribute> members to further restrict the capabilities available for the .NET Framework Data Provider for SQL Server.  
  
 The following table lists the available <xref:System.Data.SqlClient.SqlClientPermissionAttribute> properties and their descriptions:  
  
|Permission attribute property|Description|  
|-----------------------------------|-----------------|  
|`Action`|Gets or sets a security action. Inherited from <xref:System.Security.Permissions.SecurityAttribute>.|  
|`AllowBlankPassword`|Enables or disables the use of a blank password in a connection string. Valid values are `true` (to enable the use of blank passwords) and `false` (to disable the use of blank passwords). Inherited from <xref:System.Data.Common.DBDataPermissionAttribute>.|  
|`ConnectionString`|Identifies a permitted connection string. Multiple connection strings can be identified. **Note:**  Do not include a user ID or password in your connection string. In this release, you cannot change connection string restrictions using the .NET Framework Configuration Tool. <br /><br /> Inherited from <xref:System.Data.Common.DBDataPermissionAttribute>.|  
|`KeyRestrictions`|Identifies connection string parameters that are allowed or disallowed. Connection string parameters are identified in the form *\<parameter name>=*. Multiple parameters can be specified, delimited using a semicolon (;). **Note:**  If you do not specify `KeyRestrictions`, but you set `KeyRestrictionBehavior` property to `AllowOnly` or `PreventUsage`, no additional connection string parameters are allowed. Inherited from <xref:System.Data.Common.DBDataPermissionAttribute>.|  
|`KeyRestrictionBehavior`|Identifies the connection string parameters as the only additional parameters allowed (`AllowOnly`), or identifies the additional parameters that are not allowed (`PreventUsage`). `AllowOnly` is the default. Inherited from <xref:System.Data.Common.DBDataPermissionAttribute>.|  
|`TypeID`|Gets a unique identifier for this attribute when implemented in a derived class. Inherited from <xref:System.Attribute>.|  
|`Unrestricted`|Indicates whether unrestricted permission to the resource is declared. Inherited from <xref:System.Security.Permissions.SecurityAttribute>.|  
  
#### ConnectionString Syntax  
 The following example demonstrates how to use the `connectionStrings` element of a configuration file to allow only a specific connection string to be used. See [Connection Strings](../../../../docs/framework/data/adonet/connection-strings.md) for more information on storing and retrieving connection strings from configuration files.  
  
```xml  
<connectionStrings>  
  <add name="DatabaseConnection"   
    connectionString="Data Source=(local);Initial   
    Catalog=Northwind;Integrated Security=true;" />  
</connectionStrings>  
```  
  
#### KeyRestrictions Syntax  
 The following example enables the same connection string, enables the use of the `Encrypt` and `Packet``Size` connection string options, but restricts the use of any other connection string options.  
  
```xml  
<connectionStrings>  
  <add name="DatabaseConnection"   
    connectionString="Data Source=(local);Initial   
    Catalog=Northwind;Integrated Security=true;"  
    KeyRestrictions="Encrypt=;Packet Size=;"  
    KeyRestrictionBehavior="AllowOnly" />  
</connectionStrings>  
```  
  
#### KeyRestrictionBehavior with PreventUsage Syntax  
 The following example enables the same connection string and allows all other connection parameters except for `User Id`, `Password` and `Persist Security Info`.  
  
```xml  
<connectionStrings>  
  <add name="DatabaseConnection"   
    connectionString="Data Source=(local);Initial   
    Catalog=Northwind;Integrated Security=true;"  
    KeyRestrictions="User Id=;Password=;Persist Security Info=;"  
    KeyRestrictionBehavior="PreventUsage" />  
</connectionStrings>  
```  
  
#### KeyRestrictionBehavior with AllowOnly Syntax  
 The following example enables two connection strings that also contain `Initial Catalog`, `Connection Timeout`, `Encrypt`, and `Packet Size` parameters. All other connection string parameters are restricted.  
  
```xml  
<connectionStrings>  
  <add name="DatabaseConnection"   
    connectionString="Data Source=(local);Initial   
    Catalog=Northwind;Integrated Security=true;"  
    KeyRestrictions="Initial Catalog;Connection Timeout=;  
       Encrypt=;Packet Size=;"   
    KeyRestrictionBehavior="AllowOnly" />  
  
  <add name="DatabaseConnection2"   
    connectionString="Data Source=SqlServer2;Initial   
    Catalog=Northwind2;Integrated Security=true;"  
    KeyRestrictions="Initial Catalog;Connection Timeout=;  
       Encrypt=;Packet Size=;"   
    KeyRestrictionBehavior="AllowOnly" />  
</connectionStrings>  
```  
  
### Enabling Partial Trust with a Custom Permission Set  
 To enable the use of <xref:System.Data.SqlClient> permissions for a particular zone, a system administrator must create a custom permission set and set it as the permission set for a particular zone. Default permission sets, such as `LocalIntranet`, cannot be modified. For example, to include <xref:System.Data.SqlClient> permissions for code that has a <xref:System.Security.Policy.Zone> of `LocalIntranet`, a system administrator could copy the permission set for `LocalIntranet`, rename it to "CustomLocalIntranet", add the <xref:System.Data.SqlClient> permissions, import the CustomLocalIntranet permission set using the [Caspol.exe (Code Access Security Policy Tool)](../../../../docs/framework/tools/caspol-exe-code-access-security-policy-tool.md), and set the permission set of `LocalIntranet_Zone` to CustomLocalIntranet.  
  
### Sample Permission Set  
 The following is a sample permission set for the .NET Framework Data Provider for SQL Server in a partially trusted scenario. For information on creating custom permission sets, see [NIB:Configuring Permission Sets Using Caspol.exe](http://msdn.microsoft.com/library/94e2625e-21ad-4038-af36-6d1f9df40a57).  
  
```xml  
<PermissionSet class="System.Security.NamedPermissionSet"  
  version="1"  
  Name="CustomLocalIntranet"  
  Description="Custom permission set given to applications on  
    the local intranet">  
  
<IPermission class="System.Data.SqlClient.SqlClientPermission, System.Data, Version=2.0.0000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  
version="1"  
AllowBlankPassword="False">  
<add ConnectionString="Data Source=(local);Integrated Security=true;"  
 KeyRestrictions="Initial Catalog=;Connection Timeout=;  
   Encrypt=;Packet Size=;"   
 KeyRestrictionBehavior="AllowOnly" />  
 </IPermission>  
</PermissionSet>  
```  
  
## Verifying ADO.NET Code Access Using Security Permissions  
 For partial-trust scenarios, you can require CAS privileges for particular methods in your code by specifying a <xref:System.Data.SqlClient.SqlClientPermissionAttribute>. If that privilege is not allowed by the restricted security policy in effect, an exception is thrown before your code is run. For more information on security policy, see [NIB: Security Policy Management](http://msdn.microsoft.com/library/d754e05d-29dc-4d3a-a2c2-95eaaf1b82b9) and [NIB: Security Policy Best Practices](http://msdn.microsoft.com/library/d49bc4d5-efb7-4caa-a2fe-e4d3cec63c05).  
  
### Example  
 The following example demonstrates how to write code that requires a particular connection string. It simulates denying unrestricted permissions to <xref:System.Data.SqlClient>, which a system administrator would implement using a CAS policy in the real world.  
  
> [!IMPORTANT]
>  When designing CAS permissions for ADO.NET, the correct pattern is to start with the most restrictive case (no permissions at all) and then add the specific permissions that are needed for the particular task that the code needs to perform. The opposite pattern, starting with all permissions and then denying a specific permission, is not secure because there are many ways of expressing the same connection string. For example, if you start with all permissions and then attempt to deny the use of the connection string "server=someserver", the string "server=someserver.mycompany.com" would still be allowed. By always starting by granting no permissions at all, you reduce the chances that there are holes in the permission set.  
  
 The following code demonstrates how `SqlClient` performs the security demand, which throws a <xref:System.Security.SecurityException> if the appropriate CAS permissions are not in place. The <xref:System.Security.SecurityException> output is displayed in the console window.  
  
 [!code-csharp[DataWorks SqlClient.CAS#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlClient.CAS/CS/source.cs#1)]
 [!code-vb[DataWorks SqlClient.CAS#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlClient.CAS/VB/source.vb#1)]  
  
 You should see this output in the Console window:  
  
```  
Failed, as expected: <IPermission class="System.Data.SqlClient.  
SqlClientPermission, System.Data, Version=2.0.0.0,   
  Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1"  
  AllowBlankPassword="False">  
<add ConnectionString="Data Source=(local);Initial Catalog=  
  Northwind;Integrated Security=SSPI" KeyRestrictions=""  
KeyRestrictionBehavior="AllowOnly"/>  
</IPermission>  
  
Connection opened, as expected.  
Failed, as expected: Request failed.  
```  
  
## Interoperability with Unmanaged Code  
 Code that runs outside the CLR is called unmanaged code. Therefore, security mechanisms such as CAS cannot be applied to unmanaged code. COM components, ActiveX interfaces, and Win32 API functions are examples of unmanaged code. Special security considerations apply when executing unmanaged code so that you do not jeopardize overall application security. For more information, see [Interoperating with Unmanaged Code](../../../../docs/framework/interop/index.md).  
  
 The .NET Framework also supports backward compatibility to existing COM components by providing access through COM interop. You can incorporate COM components into a .NET Framework application by using COM interop tools to import the relevant COM types. Once imported, the COM types are ready to use. COM interop also enables COM clients to access managed code by exporting assembly metadata to a type library and registering the managed component as a COM component. For more information, see [Advanced COM Interoperability](http://msdn.microsoft.com/library/3ada36e5-2390-4d70-b490-6ad8de92f2fb).  
  
## See Also  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [PAVE Security in Native and .NET Framework Code](http://msdn.microsoft.com/library/bd61be84-c143-409a-a75a-44253724f784)  
 [Code Access Security](http://msdn.microsoft.com/library/23a20143-241d-4fe5-9d9f-3933fd594c03)  
 [Role-Based Security](http://msdn.microsoft.com/library/239442e3-5be4-4203-b7fd-793baffea803)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
