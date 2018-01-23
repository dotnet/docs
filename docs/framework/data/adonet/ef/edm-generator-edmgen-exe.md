---
title: "EDM Generator (EdmGen.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fe8297a1-1fc3-48ce-8eeb-f70f63f857aa
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# EDM Generator (EdmGen.exe)
EdmGen.exe is a command-line tool used for working with [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] model and mapping files. You can use the EdmGen.exe tool to do the following:  
  
-   Connect to a data source by using a data source–specific .NET Framework data provider, and generate the conceptual model (.csdl), storage model (.ssdl), and mapping (.msl) files that are used by the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
-   Validate an existing model. For more information, see [How to: Use EdmGen.exe to Validate Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-validate-model-and-mapping-files.md).  
  
-   Generate a C# or Visual Basic code file that contains the object classes generated from a conceptual model (.csdl) file. For more information, see [How to: Use EdmGen.exe to Generate Object-Layer Code](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-object-layer-code.md).  
  
-   Generate a C# or Visual Basic code file that contains the pre-generated views for an existing model. For more information, [How to: Pre-Generate Views to Improve Query Performance](http://msdn.microsoft.com/library/b18a9d16-e10b-4043-ba91-b632f85a2579).  
  
 The EdmGen.exe tool is installed in the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] directory. In many cases, this is located in C:\windows\Microsoft.NET\Framework\v4.0. For 64-bit systems, this is located in C:\windows\Microsoft.NET\Framework64\v4.0. You can also access the EdmGen.exe tool from the Visual Studio command prompt (Click **Start**, point to **All Programs**, point to **Microsoft Visual Studio 2010**, point to **Visual Studio Tools**, and then click **Visual Studio 2010 Command Prompt**).  
  
## Syntax  
  
```  
EdmGen /mode:choice [options]  
```  
  
## Mode  
 When using the EdmGen.exe tool, you must specify one of the following modes.  
  
|Mode|Description|  
|----------|-----------------|  
|`/mode:ValidateArtifacts`|Validates the .csdl, .ssdl, and .msl files and displays any errors or warnings.<br /><br /> This option requires at least one of the `/inssdl` or `/incsdl` arguments. If `/inmsl` is specified, the `/inssdl` and `/incsdl` arguments are also required.|  
|`/mode:FullGeneration`|Uses the database connection information specified in the `/connectionstring` option and generates .csdl, .ssdl, .msl, object layer, and view files.<br /><br /> This option requires a `/connectionstring` argument and either a `/project` argument or `/outssdl`, `/outcsdl`, `/outmsdl`, `/outobjectlayer`, `/outviews`, `/namespace`, and `/entitycontainer` arguments.|  
|`/mode:FromSSDLGeneration`|Generates .csdl and .msl files, source code, and views from the specified .ssdl file.<br /><br /> This option requires the `/inssdl` argument and either a `/project` argument or the `/outcsdl`, `/outmsl`, `/outobjectlayer`, `/outviews`, `/namespace,` and `/entitycontainer` arguments.|  
|`/mode:EntityClassGeneration`|Creates a source code file that contains the classes generated from the .csdl file.<br /><br /> This option requires the `/incsdl` argument and either the `/project` argument or the `/outobjectlayer` argument. The `/language` argument is optional.|  
|`/mode:ViewGeneration`|Creates a source code file that contains the views generated from the .csdl, .ssdl, and .msl files.<br /><br /> This option requires the `/inssdl`, `/incsdl`, `/inmsl,` and either the `/project` or `/outviews` arguments. The `/language` argument is optional.|  
  
## Options  
  
|Option|Description|  
|------------|-----------------|  
|`/p[roject]:`\<string>|Specifies the project name to use. The project name is used as a default for the namespace setting, the name of the model and mapping files, the name of object source file, and the name of view generation source file. The entity container name is set to \<project>Context.|  
|`/prov[ider]:`\<string>|The name of the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] data provider to be used to generate the storage model (.ssdl) file. The default provider is the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] Data Provider for SQL Server (<xref:System.Data.SqlClient?displayProperty=nameWithType>).|  
|`/c[onnectionstring]:`\<connection string>|Specifies the string that is used to connect to the data source.|  
|`/incsdl:`\<file>|Specifies the .csdl file or a directory where the .csdl files are located. This argument can be specified multiple times so that you can specify several directories or .csdl files. Specifying multiple directories can be useful for generating classes (`/mode:EntityClassGeneration`) or views (`/mode:ViewGeneration`) when the conceptual model is split across several files. This can also be useful when you want to validate multiple models (`/mode:ValidateArtifacts`).|  
|`/refcsdl:`\<file>|Specifies the additional .csdl file or files used to resolve any references in the source .csdl file. (The source .csdl file is, the file specified by the `/incsdl` option). The `/refcsdl` file contains types that the source .csdl file is dependent upon. This argument can be specified multiple times.|  
|`/inmsl:`\<file>|Specifies the .msl file or a directory where the .msl files are located. This argument can be specified multiple times so that you can specify several directories or .msl files. Specifying multiple directories can be useful for generating views (`/mode:ViewGeneration`) when the conceptual model is split across several files. This can also be useful when you want to validate multiple models (`/mode:ValidateArtifacts`).|  
|`/inssdl:`\<file>|Specifies the .ssdl file or a directory where the .ssdl file is located. This argument can be specified multiple times so that you can specify several directories or .ssdl files. This can be useful when you want to validate multiple models `(/mode:ValidateArtifacts)`.|  
|`/outcsdl:`\<file>|Specifies the name of the .csdl file that will be created.|  
|`/outmsl:`\<file>|Specifies the name of the .msl file that will be created.|  
|`/outssdl:`\<file>|Specifies the name of the .ssdl file that will be created.|  
|`/outobjectlayer:`\<file>|Specifies the name of the source code file that contains the objects generated from the .csdl file.|  
|`/outviews:`\<file>|Specifies the name of the source code file that contains the views that were generated.|  
|`/language:`[VB&#124;CSharp]|Specifies the language for the generated source code files. The language defaults to C#.|  
|`/namespace:`\<string>|Specifies the model namespace to use. The namespace is set in the .csdl file when running `/mode:FullGeneration` or `/mode:FromSSDLGeneration`. The namespace is not used when running `/mode:EntityClassGeneration`.|  
|`/entitycontainer:`\<string>|Specifies the name to apply to the `<EntityContainer>` element in the generated model and mapping files.|  
|`/pl[uralize]`|Applies English-language rules for singulars and plurals to `Entity`, `EntitySet`, and `NavigationProperty` names in the conceptual model. This option will perform the following actions:<br /><br /> -   Make all `EntityType` names singular.<br />-   Make all `EntitySet` names plural.<br />-   For each `NavigationProperty` that returns at most one entity, make the name singular.<br />-   For each `NavigationProperty` that returns more than one entity, make the name plural.|  
|`/SupressForeignKeyProperties or /nofk`|Prevents foreign key columns from being exposed as scalar properties on entity types in the conceptual model.|  
|`/help` or `?`|Displays command syntax and options for the tool.|  
|`/nologo`|Suppresses the copyright message from displaying.|  
|`/targetversion:` \<string>|The .NET Framework version that will be used to compile the generated code. The supported versions are 4 and 4.5. Defaults to 4.|  
  
## In This Section  
 [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md)  
  
 [How to: Use EdmGen.exe to Generate Object-Layer Code](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-object-layer-code.md)  
  
 [How to: Use EdmGen.exe to Validate Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-validate-model-and-mapping-files.md)  
  
## See Also  
 [ADO.NET Entity Data Model  Tools](http://msdn.microsoft.com/library/91076853-0881-421b-837a-f582f36be527)  
 [Entity Data Model](../../../../../docs/framework/data/adonet/entity-data-model.md)  
 [CSDL, SSDL, and MSL Specifications](../../../../../docs/framework/data/adonet/ef/language-reference/csdl-ssdl-and-msl-specifications.md)
