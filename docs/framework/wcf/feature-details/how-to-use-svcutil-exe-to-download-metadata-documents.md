---
title: "How to: Use Svcutil.exe to Download Metadata Documents"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 15524274-3167-4627-b722-d6cedb9fa8c6
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use Svcutil.exe to Download Metadata Documents
You can use Svcutil.exe to download metadata from running services and to save the metadata to local files. For HTTP and HTTPS URL schemes, Svcutil.exe attempts to retrieve metadata using WS-MetadataExchange and [XML Web Service Discovery](http://go.microsoft.com/fwlink/?LinkId=94950). For all other URL schemes, Svcutil.exe uses only WS-MetadataExchange.  
  
 By default, Svcutil.exe uses the bindings defined in the <xref:System.ServiceModel.Description.MetadataExchangeBindings> class. To configure the binding used for WS-MetadataExchange, you must define a client endpoint in the configuration file for Svcutil.exe (svcutil.exe.config) that uses the `IMetadataExchange` contract and that has the same name as the Uniform Resource Identifier (URI) scheme of the metadata endpoint address.  
  
> [!CAUTION]
>  When running Svcutil.exe to get metadata for a service that exposes two different service contracts that each contain an operation of the same name, Svcutil.exe displays an error saying, "Cannot obtain Metadata from ...." For example, if you have a service that exposes a service contract called ICarService that has an operation Get(Car c) and the same service exposes a service contract called IBookService that has an operation Get(Book b). To work around this issue, do one of the following:  
>   
>  -   Rename one of the operations  
> -   Set the <xref:System.ServiceModel.OperationContractAttribute.Name%2A> to a different name.  
> -   Set one of the operations' namespaces to a different namespace using the <xref:System.ServiceModel.ServiceContractAttribute.Namespace%2A> property.  
  
### To download metadata using Svcutil.exe  
  
1.  Locate the Svcutil.exe tool at the following location:  
  
     C:\Program Files\Microsoft SDKs\Windows\v1.0.\bin  
  
2.  At the command prompt, launch the tool using the following format.  
  
    ```  
    svcutil.exe /t:metadata  <url>* | <epr>  
    ```  
  
     You must specify the `/t:metadata` option to download metadata. Otherwise, client code and configuration are generated.  
  
3.  The <`url`>argument specifies the URL to a service endpoint that provides metadata or to a metadata document hosted online. The <`epr`> argument specifies the path to an XML file that contains a WS-Addressing `EndpointAddress` for a service endpoint that supports WS-MetadataExchange.  
  
 For more options about using this tool for metadata download, see [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md).  
  
## Example  
 The following command downloads metadata documents from a running service.  
  
```  
svcutil /t:metadata http://service/metadataEndpoint  
```  
  
## See Also  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
