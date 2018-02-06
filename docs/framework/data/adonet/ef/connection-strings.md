---
title: "Connection Strings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 78d516bc-c99f-4865-8ff1-d856bc1a01c0
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Connection Strings
A connection string contains initialization information that is passed as a parameter from a data provider to a data source. The syntax depends on the data provider, and the connection string is parsed during the attempt to open a connection. Connection strings used by the Entity Framework contain information used to connect to the underlying ADO.NET data provider that supports the Entity Framework. They also contain information about the required model and mapping files.  
  
 The connection string is used by the EntityClient provider when accessing model and mapping metadata and connecting to the data source. The connection string can be accessed or set through the <xref:System.Data.EntityClient.EntityConnection.ConnectionString%2A> property of <xref:System.Data.EntityClient.EntityConnection>. The <xref:System.Data.EntityClient.EntityConnectionStringBuilder> class can be used to programmatically construct or access parameters in the connection string. For more information, see [How to: Build an EntityConnection Connection String](../../../../../docs/framework/data/adonet/ef/how-to-build-an-entityconnection-connection-string.md).  
  
 The [Entity Data Model tools](http://msdn.microsoft.com/library/91076853-0881-421b-837a-f582f36be527) generate a connection string that is stored in the application's configuration file. <xref:System.Data.Objects.ObjectContext> retrieves this connection information automatically when creating object queries. The <xref:System.Data.EntityClient.EntityConnection> used by an <xref:System.Data.Objects.ObjectContext> instance can be accessed from the <xref:System.Data.Objects.ObjectContext.Connection%2A> property. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).  
  
## Connection String Parameters  
 The format of a connection string is a semicolon-delimited list of key/value parameter pairs:  
  
 `keyword1=value; keyword2=value;`  
  
 The equal sign (=) connects each keyword and its value. Keywords are not case sensitive, and spaces between key/value pairs are ignored. However, values  can be case sensitive, depending on the data source. Any values that contain a semicolon, single quotation marks, or double quotation marks must be enclosed in double quotation marks. The following table lists the valid names for keyword values in the <xref:System.Data.EntityClient.EntityConnection.ConnectionString%2A>.  
  
|Keyword|Description|  
|-------------|-----------------|  
|`Provider`|Required if the `Name` keyword is not specified. The provider name, which is used to retrieve the <xref:System.Data.Common.DbProviderFactory> object for the underlying provider. This value is constant.<br /><br /> When the `Name` keyword is not included in an entity connection string, a non-empty value for the `Provider` keyword is required. This keyword is mutually exclusive with the `Name` keyword.|  
|`Provider Connection String`|Optional. Specifies the provider-specific connection string that is passed to the underlying data source. This connection string is expressed by using valid keyword/value pairs for the data provider. An invalid `Provider Connection String` will cause a run-time error when it is evaluated by the data source.<br /><br /> This keyword is mutually exclusive with the `Name` keyword.<br /><br /> The value of the `Provider Connection String` must be surrounded by quotes. The following is an example:<br /><br /> `Provider Connection String ="Server=serverName; User ID = userID";`<br /><br /> The following example is not going to work:<br /><br /> `Provider Connection String =Server=serverName; User ID = userID`|  
|`Metadata`|Required if the `Name` keyword is not specified. A pipe-delimited list of directories, files, and resource locations in which to look for metadata and mapping information. The following is an example:<br /><br /> `Metadata=`<br /><br /> `c:\model &#124; c:\model\sql\mapping.msl;`<br /><br /> Blank spaces on each side of the pipe separator are ignored.<br /><br /> This keyword is mutually exclusive with the `Name` keyword.|  
|`Name`|The application can optionally specify the connection name in an application configuration file that provides the required keyword/value connection string values. In this case, you cannot supply them directly in the connection string. The `Name` keyword is not allowed in a configuration file.<br /><br /> When the `Name` keyword is not included in the connection string, a non-empty values for Provider keyword is required.<br /><br /> This keyword is mutually exclusive with all the other connection string keywords.|  
  
 The following is an example of a connection string for the [AdventureWorks Sales Model](http://msdn.microsoft.com/library/f16cd988-673f-4376-b034-129ca93c7832) stored in the application configuration file:  
  
  
  
## Model and Mapping File Locations  
 The `Metadata` parameter contains a list of locations for the `EntityClient` provider to search for model and mapping files. Model and mapping files are often deployed in the same directory as the application executable file. These files can also be deployed in a specific location or included as an embedded resource in the application.  
  
 Embedded resources are specified as follows:  
  
```  
Metadata=res://<assemblyFullName>/<resourceName>.   
```  
  
 The following options are available for defining the location of an embedded resource:  
  
|Option|Description|  
|-|-|  
|`assemblyFullName`|The full name of an assembly with the embedded resource. The name includes the simple name, version name, supported culture, and public key, as follows:<br /><br /> `ResourceLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`<br /><br /> Resources can be embedded in any assembly that is accessible by the application.<br /><br /> If you specify a wildcard (\*) for `assemblyFullName`, the Entity Framework runtime will search for resources in the following locations, in this order:<br /><br /> 1.  The calling assembly.<br />2.  The referenced assemblies.<br />3.  The assemblies in the bin directory of an application.<br /><br /> If the files are not in one of these locations, an exception will be thrown. **Note:**  When you use wildcard (*), the Entity Framework has to look through all the assemblies for resources with the correct name. To improve performance, specify the assembly name instead of the wildcard.|  
|`resourceName`|The name of the included resource, such as AdvendtureWorksModel.csdl. The metadata services will only look for files or resources with one of the following extensions: .csdl, .ssdl, or .msl. If `resourceName` is not specified, all metadata resources will be loaded. The resources should have unique names within an assembly. If multiple files with the same name are defined in different directories in the assembly, the `resourceName` must include the folder structure before the name of the resource, for example FolderName.FileName.csdl.<br /><br /> `resourceName` is not required when you specify a wildcard (*) for `assemblyFullName`.|  
  
> [!NOTE]
>  To improve performance, embed resources in the calling assembly, except in non-Web scenarios where there is no reference to underlying mapping and metadata files in the calling assembly.  
  
 The following example loads all the model and mapping files in the calling assembly, referenced assemblies, and other assemblies in the bin directory of an application.  
  
```  
Metadata=res://*/  
```  
  
 The following example loads the model.csdl file from the AdventureWorks assembly, and loads the model.ssdl and model.msl files from the default directory of the running application.  
  
```  
Metadata=res://AdventureWorks, 1.0.0.0, neutral, a14f3033def15840/model.csdl|model.ssdl|model.msl  
```  
  
 The following example loads the three specified resources from the specific assembly.  
  
```  
Metadata=res://AdventureWorks, 1.0.0.0, neutral, a14f3033def15840/model.csdl|   
res://AdventureWorks, 1.0.0.0, neutral, a14f3033def15840/model.ssdl|   
res://AdventureWorks, 1.0.0.0, neutral, a14f3033def15840/model.msl  
```  
  
 The following example loads all the embedded resources with the extensions .csdl, .msl, and .ssdl from the assembly.  
  
```  
Metadata=res://AdventureWorks, 1.0.0.0, neutral, a14f3033def15840/  
```  
  
 The following example loads all the resources in the relative file path plus "datadir\metadata\\" from the loaded assembly location.  
  
```  
Metadata=datadir\metadata\  
```  
  
 The following example loads all the resources in the relative file path from the loaded assembly location.  
  
```  
Metadata=.\  
```  
  
## Support for the &#124;DataDirectory&#124; Substitution String and the Web Application Root Operator (~)  
 `DataDirectory` and the ~ operator are used in the <xref:System.Data.EntityClient.EntityConnection.ConnectionString%2A> as part of the `Metadata` and `Provider Connection String` keywords. The <xref:System.Data.EntityClient.EntityConnection> forwards the `DataDirectory` and the ~ operator to <xref:System.Data.Metadata.Edm.MetadataWorkspace> and the store provider, respectively.  
  
|Term|Description|  
|----------|-----------------|  
|`&#124;DataDirectory&#124;`|Resolves to a relative path to a mapping and metadata files. This is the value that is set through the `AppDomain.SetData("DataDirectory", objValue)` method. The `DataDirectory` substitution string must be surrounded by the pipe characters and there cannot be any whitespace between its name and the pipe characters. The `DataDirectory` name is not case-sensitive.<br /><br /> If a physical directory named "DataDirectory" has to be passed as a member of the list of metadata paths, add whitespace should on either side or both sides of the name, for example: `Metadata="DataDirectory1 &#124; DataDirectory &#124; DataDirectory2"`. An ASP.NET application resolves &#124;DataDirectory&#124; to the "\<application root>/app_data" folder.|  
|~|Resolves to the Web application root. The ~ character at a leading position is always interpreted as the Web application root operator (~), although it might represent a valid local subdirectory. To refer to such a local subdirectory, the user should explicitly pass `./~`.|  
  
 `DataDirectory` and the ~ operator should be specified only at the beginning of a path, they are not resolved at any other position. The Entity Framework will try to resolve `~/data`, but it will treat `/data/~` as a physical path.  
  
 A path that starts with the `DataDirectory` or the ~ operator cannot resolve to a physical path outside the branch of the `DataDirectory` and the ~ operator. For example, the following paths will resolve: `~` , `~/data` , `~/bin/Model/SqlServer`. The following paths will fail to resolve: `~/..`, `~/../other`.  
  
 `DataDirectory` and the ~ operator can be extended to include sub-directories, as follows: `|DataDirectory|\Model`, `~/bin/Model`  
  
 The resolution of the `DataDirectory` substitution string and the ~ operator is non-recursive. For example, when `DataDirectory` includes the `~` character, an exception will occur. This prevents an infinite recursion.  
  
## See Also  
 [Working with Data Providers](../../../../../docs/framework/data/adonet/ef/working-with-data-providers.md)  
 [Deployment Considerations](../../../../../docs/framework/data/adonet/ef/deployment-considerations.md)  
 [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99)  
 [Connection Strings](../../../../../docs/framework/data/adonet/connection-strings.md)
