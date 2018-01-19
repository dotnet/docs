---
title: "How to: Manually Generate Client Data Service Classes (WCF Data Services)"
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
  - "WCF Data Services, configuring"
  - "WCF Data Services, client library"
ms.assetid: b98cb1d6-956a-4e50-add6-67e4f2587346
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Manually Generate Client Data Service Classes (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] integrates with Visual Studio to enable you to automatically generate client data service classes when you use the **Add Service Reference** dialog box to add a reference to a data service in a Visual Studio project. For more information, see [How to: Add a Data Service Reference](../../../../docs/framework/data/wcf/how-to-add-a-data-service-reference-wcf-data-services.md). You can also manually generate the same client data service classes by using the code-generation tool, `DataSvcUtil.exe`. This tool, which is included with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], generates .NET Framework classes from the data service definition. It can also be used to generate data service classes from the conceptual model (.csdl) file and from the .edmx file that represents an Entity Framework model in a Visual Studio project.  
  
 The example in this topic creates client data service classes based on the Northwind sample data service. This service is created when you complete the [WCF Data Services quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md). Some examples in this topic require the conceptual model file for the Northwind model. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md). Some examples in this topic require the .edmx file for the Northwind model. For more information, see [.edmx File Overview](http://msdn.microsoft.com/library/f4c8e7ce-1db6-417e-9759-15f8b55155d4).  
  
### To generate C# classes that support data binding  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\DataSvcUtil.exe" /dataservicecollection /version:2.0 /language:CSharp /out:Northwind.cs /uri:http://localhost:12345/Northwind.svc  
    ```  
  
    > [!NOTE]
    >  You must replace the value supplied to the `/uri:` parameter with the URI of your instance of the Northwind sample data service.  
  
### To generate Visual Basic classes that support data binding  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\DataSvcUtil.exe" /dataservicecollection /version:2.0 /language:VB /out:Northwind.vb /uri:http://localhost:12345/Northwind.svc  
    ```  
  
    > [!NOTE]
    >  You must replace value supplied to the `/uri:` parameter with the URI of your instance of the Northwind sample data service.  
  
### To generate C# classes based on the service URI  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\DataSvcUtil.exe" /language:CSharp /out:northwind.cs /uri:http://localhost:12345/Northwind.svc  
    ```  
  
    > [!NOTE]
    >  You must replace the value supplied to the `/uri:` parameter with the URI of your instance of the Northwind sample data service.  
  
### To generate Visual Basic classes based on the service URI  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\datasvcutil.exe" /language:VB /out:Northwind.vb /uri:http://localhost:12345/Northwind.svc  
    ```  
  
    > [!NOTE]
    >  You must replace value supplied to the `/uri:` parameter with the URI of your instance of the Northwind sample data service.  
  
### To generate C# classes based on the conceptual model file (CSDL)  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\datasvcutil.exe" /language:CSharp /in:Northwind.csdl /out:Northwind.cs  
    ```  
  
### To generate Visual Basic classes based on the conceptual model file (CSDL)  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\datasvcutil.exe" /language:VB /in:Northwind.csdl /out:Northwind.vb  
    ```  
  
### To generate C# classes based on the .edmx file  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\datasvcutil.exe" /language:CSharp /in:Northwind.edmx /out:c:\northwind.cs   
    ```  
  
### To generate Visual Basic classes based on the .edmx file  
  
-   At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v3.5\datasvcutil.exe" /language:VB /in:Northwind.edmx /out:c:\northwind.vb   
    ```  
  
## See Also  
 [Generating the Data Service Client Library](../../../../docs/framework/data/wcf/generating-the-data-service-client-library-wcf-data-services.md)  
 [How to: Add a Data Service Reference](../../../../docs/framework/data/wcf/how-to-add-a-data-service-reference-wcf-data-services.md)  
 [WCF Data Service Client Utility (DataSvcUtil.exe)](../../../../docs/framework/data/wcf/wcf-data-service-client-utility-datasvcutil-exe.md)
