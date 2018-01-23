---
title: "Connection Strings and Configuration Files"
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
ms.assetid: 37df2641-661e-407a-a3fb-7bf9540f01e8
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Connection Strings and Configuration Files
Embedding connection strings in your application's code can lead to security vulnerabilities and maintenance problems. Unencrypted connection strings compiled into an application's source code can be viewed using the [Ildasm.exe (IL Disassembler)](../../../../docs/framework/tools/ildasm-exe-il-disassembler.md) tool. Moreover, if the connection string ever changes, your application must be recompiled. For these reasons, we recommend storing connection strings in an application configuration file.  
  
## Working with Application Configuration Files  
 Application configuration files contain settings that are specific to a particular application. For example, an ASP.NET application can have one or more **web.config** files, and a Windows application can have an optional **app.config** file. Configuration files share common elements, although the name and location of a configuration file vary depending on the application's host.  
  
### The connectionStrings Section  
 Connection strings can be stored as key/value pairs in the **connectionStrings** section of the **configuration** element of an application configuration file. Child elements include **add**, **clear**, and **remove**.  
  
 The following configuration file fragment demonstrates the schema and syntax for storing a connection string. The **name** attribute is a name that you provide to uniquely identify a connection string so that it can be retrieved at run time. The **providerName** is the invariant name of the .NET Framework data provider, which is registered in the machine.config file.  
  
```xml  
<?xml version='1.0' encoding='utf-8'?>  
  <configuration>  
    <connectionStrings>  
      <clear />  
      <add name="Name"   
       providerName="System.Data.ProviderName"   
       connectionString="Valid Connection String;" />  
    </connectionStrings>  
  </configuration>  
```  
  
> [!NOTE]
>  You can save part of a connection string in a configuration file and use the <xref:System.Data.Common.DbConnectionStringBuilder> class to complete it at run time. This is useful in scenarios where you do not know elements of the connection string ahead of time, or when you do not want to save sensitive information in a configuration file. For more information, see [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md).  
  
### Using External Configuration Files  
 External configuration files are separate files that contain a fragment of a configuration file consisting of a single section. The external configuration file is then referenced by the main configuration file. Storing the **connectionStrings** section in a physically separate file is useful in situations where connection strings may be edited after the application is deployed. For example, the standard ASP.NET behavior is to restart an application domain when configuration files are modified, which results in state information being lost. However, modifying an external configuration file does not cause an application restart. External configuration files are not limited to ASP.NET; they can also be used by Windows applications. In addition, file access security and permissions can be used to restrict access to external configuration files. Working with external configuration files at run time is transparent, and requires no special coding.  
  
 To store connection strings in an external configuration file, create a separate file that contains only the **connectionStrings** section. Do not include any additional elements, sections, or attributes. This example shows the syntax for an external configuration file.  
  
```xml  
<connectionStrings>  
  <add name="Name"   
   providerName="System.Data.ProviderName"   
   connectionString="Valid Connection String;" />  
</connectionStrings>  
```  
  
 In the main application configuration file, you use the **configSource** attribute to specify the fully qualified name and location of the external file. This example refers to an external configuration file named `connections.config`.  
  
```xml  
<?xml version='1.0' encoding='utf-8'?>  
<configuration>  
    <connectionStrings configSource="connections.config"/>  
</configuration>  
```  
  
## Retrieving Connection Strings at Run Time  
 The .NET Framework 2.0 introduced new classes in the <xref:System.Configuration> namespace to simplify retrieving connection strings from configuration files at run time. You can programmatically retrieve a connection string by name or by provider name.  
  
> [!NOTE]
>  The **machine.config** file also contains a **connectionStrings** section, which contains connection strings used by Visual Studio. When retrieving connection strings by provider name from the **app.config** file in a Windows application, the connection strings in **machine.config** get loaded first, and then the entries from **app.config**. Adding **clear** immediately after the **connectionStrings** element removes all inherited references from the data structure in memory, so that only the connection strings defined in the local **app.config** file are considered.  
  
### Working with the Configuration Classes  
 Starting with the .NET Framework 2.0, <xref:System.Configuration.ConfigurationManager> is used when working with configuration files on the local computer, replacing the deprecated <xref:System.Configuration.ConfigurationSettings>. <xref:System.Web.Configuration.WebConfigurationManager> is used to work with ASP.NET configuration files. It is designed to work with configuration files on a Web server, and allows programmatic access to configuration file sections such as **system.web**.  
  
> [!NOTE]
>  Accessing configuration files at run time requires granting permissions to the caller; the required permissions depend on the type of application, configuration file, and location. For more information, see [Using the Configuration Classes](http://msdn.microsoft.com/library/98d2b386-baf6-4a17-974b-76e3b4c87acc) and <xref:System.Web.Configuration.WebConfigurationManager> for ASP.NET applications, and <xref:System.Configuration.ConfigurationManager> for Windows applications.  
  
 You can use the <xref:System.Configuration.ConnectionStringSettingsCollection> to retrieve connection strings from application configuration files. It contains a collection of <xref:System.Configuration.ConnectionStringSettings> objects, each of which represents a single entry in the **connectionStrings** section. Its properties map to connection string attributes, allowing you to retrieve a connection string by specifying the name or the provider name.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Configuration.ConnectionStringSettings.Name%2A>|The name of the connection string. Maps to the **name** attribute.|  
|<xref:System.Configuration.ConnectionStringSettings.ProviderName%2A>|The fully qualified provider name. Maps to the **providerName** attribute.|  
|<xref:System.Configuration.ConnectionStringSettings.ConnectionString%2A>|The connection string. Maps to the **connectionString** attribute.|  
  
### Example: Listing All Connection Strings  
 This example iterates through the `ConnectionStringSettings` collection and displays the <xref:System.Configuration.ConnectionStringSettings.Name%2A>, <xref:System.Configuration.ConnectionStringSettings.ProviderName%2A>, and <xref:System.Configuration.ConnectionStringSettings.ConnectionString%2A> properties in the console window.  
  
> [!NOTE]
>  System.Configuration.dll is not included in all project types, and you may need to set a reference to it in order to use the configuration classes. The name and location of a particular application configuration file varies by the type of application and the hosting process.  
  
 [!code-csharp[DataWorks ConnectionStringSettings.RetrieveFromConfig#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfig/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStringSettings.RetrieveFromConfig#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfig/VB/source.vb#1)]  
  
### Example: Retrieving a Connection String by Name  
 This example demonstrates how to retrieve a connection string from a configuration file by specifying its name. The code creates a <xref:System.Configuration.ConnectionStringSettings> object, matching the supplied input parameter to the <xref:System.Configuration.ConfigurationManager.ConnectionStrings%2A> name. If no matching name is found, the function returns `null` (`Nothing` in Visual Basic).  
  
 [!code-csharp[DataWorks ConnectionStringSettings.RetrieveFromConfigByName#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByName/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStringSettings.RetrieveFromConfigByName#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByName/VB/source.vb#1)]  
  
### Example: Retrieving a Connection String by Provider Name  
 This example demonstrates how to retrieve a connection string by specifying the provider-invariant name in the format *System.Data.ProviderName*. The code iterates through the <xref:System.Configuration.ConnectionStringSettingsCollection> and returns the connection string for the first <xref:System.Configuration.ConnectionStringSettings.ProviderName%2A> found. If the provider name is not found, the function returns `null` (`Nothing` in Visual Basic).  
  
 [!code-csharp[DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider/VB/source.vb#1)]  
  
## Encrypting Configuration File Sections Using Protected Configuration  
 ASP.NET 2.0 introduced a new feature, called *protected configuration*, that enables you to encrypt sensitive information in a configuration file. Although primarily designed for ASP.NET, protected configuration can also be used to encrypt configuration file sections in Windows applications. For a detailed description of the protected configuration capabilities, see [Encrypting Configuration Information Using Protected Configuration](http://msdn.microsoft.com/library/51cdfe5b-9d82-458c-94ff-c551c4f38ed1).  
  
 The following configuration file fragment shows the **connectionStrings** section after it has been encrypted. The **configProtectionProvider** specifies the protected configuration provider used to encrypt and decrypt the connection strings. The **EncryptedData** section contains the cipher text.  
  
```xml  
<connectionStrings configProtectionProvider="DataProtectionConfigurationProvider">  
  <EncryptedData>  
    <CipherData>  
      <CipherValue>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAH2... </CipherValue>  
    </CipherData>  
  </EncryptedData>  
</connectionStrings>  
```  
  
 When the encrypted connection string is retrieved at run time, the .NET Framework uses the specified provider to decrypt the **CipherValue** and make it available to your application. You do not need to write any additional code to manage the decryption process.  
  
### Protected Configuration Providers  
 Protected configuration providers are registered in the **configProtectedData** section of the **machine.config** file on the local computer, as shown in the following fragment, which shows the two protected configuration providers supplied with the .NET Framework. The values shown here have been truncated for readability.  
  
```xml  
<configProtectedData defaultProvider="RsaProtectedConfigurationProvider">  
  <providers>  
    <add name="RsaProtectedConfigurationProvider"   
      type="System.Configuration.RsaProtectedConfigurationProvider, ... />  
    <add name="DataProtectionConfigurationProvider"   
      type="System.Configuration.DpapiProtectedConfigurationProvider, ... />  
  </providers>  
</configProtectedData>  
```  
  
 You can configure additional protected configuration providers by adding them to the **machine.config** file. You can also create your own protected configuration provider by inheriting from the <xref:System.Configuration.ProtectedConfigurationProvider> abstract base class. The following table describes the two configuration files included with the .NET Framework.  
  
|Provider|Description|  
|--------------|-----------------|  
|<!--zz<xref:System.Configuration.RSAProtectedConfigurationProvider>-->`System.Configuration.RSAProtectedConfigurationProvider`|Uses the RSA encryption algorithm to encrypt and decrypt data. The RSA algorithm can be used for both public key encryption and digital signatures. It is also known as "public key" or asymmetrical encryption because it employs two different keys. You can use the [ASP.NET IIS Registration Tool (Aspnet_regiis.exe)](http://msdn.microsoft.com/library/6491c41e-e2b0-481f-9863-db3614d5f96b) to encrypt sections in a Web.config file and manage the encryption keys. ASP.NET decrypts the configuration file when it processes the file. The identity of the ASP.NET application must have read access to the encryption key that is used to encrypt and decrypt the encrypted sections.|  
|<!--zz<xref:System.Configuration.DPAPIProtectedConfigurationProvider>-->`System.Configuration.DPAPIProtectedConfigurationProvider`|Uses the Windows Data Protection API (DPAPI) to encrypt configuration sections. It uses the Windows built-in cryptographic services and can be configured for either machine-specific or user-account-specific protection. Machine-specific protection is useful for multiple applications on the same server that need to share information. User-account-specific protection can be used with services that run with a specific user identity, such as a shared hosting environment. Each application runs under a separate identity which restricts access to resources such as files and databases.|  
  
 Both providers offer strong encryption of data. However, if you are planning to use the same encrypted configuration file on multiple servers, such as a Web farm, only the `RsaProtectedConfigurationProvider` enables you to export the encryption keys used to encrypt the data and import them on another server. For more information, see [Importing and Exporting Protected Configuration RSA Key Containers](http://msdn.microsoft.com/library/f3022b39-f17f-48c1-b067-025eab0ce8bc).  
  
### Using the Configuration Classes  
 The <xref:System.Configuration> namespace provides classes to work with configuration settings programmatically. The <xref:System.Configuration.ConfigurationManager> class provides access to machine, application, and user configuration files. If you are creating an ASP.NET application, you can use the <xref:System.Web.Configuration.WebConfigurationManager> class, which provides the same functionality while also allowing you to access settings that are unique to ASP.NET applications, such as those found in **\<system.web>**.  
  
> [!NOTE]
>  The <xref:System.Security.Cryptography> namespace contains classes that provide additional options for encrypting and decrypting data. Use these classes if you require cryptographic services that are not available using protected configuration. Some of these classes are wrappers for the unmanaged Microsoft CryptoAPI, while others are purely managed implementations. For more information, see [Cryptographic Services](http://msdn.microsoft.com/library/68a1e844-c63c-44af-9247-f6716eb23781).  
  
### App.config Example  
 This example demonstrates how to toggle encrypting the **connectionStrings** section in an **app.config** file for a Windows application. In this example, the procedure takes the name of the application as an argument, for example, "MyApplication.exe". The **app.config** file will then be encrypted and copied to the folder that contains the executable under the name of "MyApplication.exe.config".  
  
> [!NOTE]
>  The connection string can only be decrypted on the computer on which it was encrypted.  
  
 The code uses the <xref:System.Configuration.ConfigurationManager.OpenExeConfiguration%2A> method to open the **app.config** file for editing, and the <xref:System.Configuration.ConfigurationManager.GetSection%2A> method returns the **connectionStrings** section. The code then checks the <xref:System.Configuration.SectionInformation.IsProtected%2A> property, calling the <xref:System.Configuration.SectionInformation.ProtectSection%2A> to encrypt the section if it is not encrypted. The <xref:System.Configuration.SectionInformation.UnprotectSection%2A> method is invoked to decrypt the section. The <xref:System.Configuration.Configuration.Save%2A> method completes the operation and saves the changes.  
  
> [!NOTE]
>  You must set a reference to `System.Configuration.dll` in your project for the code to run.  
  
 [!code-csharp[DataWorks ConnectionStrings.Encrypt#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStrings.Encrypt/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStrings.Encrypt#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStrings.Encrypt/VB/source.vb#1)]  
  
### Web.config Example  
 This example uses the <xref:System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration%2A> method of the `WebConfigurationManager`. Note that in this case you can supply the relative path to the **Web.config** file by using a tilde. The code requires a reference to the `System.Web.Configuration` class.  
  
 [!code-csharp[DataWorks ConnectionStringsWeb.Encrypt#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStringsWeb.Encrypt/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStringsWeb.Encrypt#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStringsWeb.Encrypt/VB/source.vb#1)]  
  
 For more information securing ASP.NET applications, see [NIB: ASP.NET Security](http://msdn.microsoft.com/library/04b37532-18d9-40b4-8e5f-ee09a70b311d) and [ASP.NET 2.0 Security Practices at a Glance](http://go.microsoft.com/fwlink/?LinkId=59997) on the ASP.NET Developer Center.  
  
## See Also  
 [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)  
 [Using the Configuration Classes](http://msdn.microsoft.com/library/98d2b386-baf6-4a17-974b-76e3b4c87acc)  
 [Configuring Apps](../../../../docs/framework/configure-apps/index.md)  
 [ASP.NET Web Site Administration](http://msdn.microsoft.com/library/1298034b-5f7d-464d-abd1-ad9e6b3eeb7e)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
