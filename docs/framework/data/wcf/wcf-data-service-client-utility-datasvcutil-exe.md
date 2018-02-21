---
title: "WCF Data Service Client Utility (DataSvcUtil.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, generating client data classes"
  - "WCF Data Services, client library"
  - "WCF Data Services, consuming"
ms.assetid: 9d0af606-929b-4c03-b307-3ef5f705afce
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Data Service Client Utility (DataSvcUtil.exe)
DataSvcUtil.exe is a command-line tool provided by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] that consumes an [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feed and generates the client data service classes that are needed to access a data service from a .NET Framework client application. This utility can generate data classes by using the following metadata sources:  
  
-   The root URI of a data service. The utility requests the service metadata document, which describes the data model exposed by the data service. For more information, see [OData: Service Metadata Document](http://go.microsoft.com/fwlink/?LinkId=186070).  
  
-   A data model file (.csdl) defined by using the conceptual schema definition language (CSDL), as defined in the [\[MC-CSDL\]: Conceptual Schema Definition File Format](http://go.microsoft.com/fwlink/?LinkID=159072) specification.  
  
-   An .edmx file created by using the Entity Data Model tools that are provided with the Entity Framework. For more information, see the [\[MC-EDMX\]: Entity Data Model for Data Services Packaging Format](http://go.microsoft.com/fwlink/?LinkID=178833) specification.  
  
 For more information, see [How to: Manually Generate Client Data Service Classes](../../../../docs/framework/data/wcf/how-to-manually-generate-client-data-service-classes-wcf-data-services.md).  
  
 The DataSvcUtil.exe tool is installed in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] directory. In many cases, this is located in C:\Windows\Microsoft.NET\Framework\v4.0,. For 64-bit systems, this is located in C:\Windows\Microsoft.NET\Framework64\v4.0. You can also access the DataSvcUtil.exe tool from the Visual Studio command prompt (Click **Start**, point to **All Programs**, point to **Microsoft Visual Studio 2010**, point to **Visual Studio Tools**, and then click **Visual Studio 2010 Command Prompt**).  
  
## Syntax  
  
```  
datasvcutil /out:file [/in:file | /uri:serviceuri] [/dataservicecollection] [/language:devlang] [/nologo] [/version:ver] [/help]  
```  
  
#### Parameters  
  
|Option|Description|  
|------------|-----------------|  
|`/dataservicecollection`|Specifies that the code required to bind objects to controls is also generated.|  
|`/help`<br /><br /> -or-<br /><br /> `/?`|Displays command syntax and options for the tool.|  
|`/in:` *\<file>*|Specifies the .csdl or .edmx file or a directory where the file is located.|  
|`/language:`[VB&#124;CSharp]|Specifies the language for the generated source code files. The language defaults to C#.|  
|`/nologo`|Suppresses the copyright message from displaying.|  
|`/out:` *\<file>*|Specifies the name of the source code file that contains the generated client data service classes.|  
|`/uri:` *\<string>*|The URI of the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed.|  
|`/version:`[1.0&#124;2.0]|Specifies the highest accepted version of [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]. The version is determined based on the `DataServiceVersion` attribute of the DataService element in the returned data service metadata. For more information, see [Data Service Versioning](../../../../docs/framework/data/wcf/data-service-versioning-wcf-data-services.md). When you specify the `/dataservicecollection` parameter, you must also specify `/version:2.0` to enable data binding.|  
  
## See Also  
 [Generating the Data Service Client Library](../../../../docs/framework/data/wcf/generating-the-data-service-client-library-wcf-data-services.md)  
 [How to: Add a Data Service Reference](../../../../docs/framework/data/wcf/how-to-add-a-data-service-reference-wcf-data-services.md)
