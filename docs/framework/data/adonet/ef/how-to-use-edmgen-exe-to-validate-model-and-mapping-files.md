---
title: "How to: Use EdmGen.exe to Validate Model and Mapping Files | Microsoft Docs"
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
  - "VB"
  - "CSharp"
  - "C++"
  - "ESQL"
  - "jsharp"
ms.assetid: 2641906a-971a-4d0b-8aee-13fabc02a1cc
caps.latest.revision: 4
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# How to: Use EdmGen.exe to Validate Model and Mapping Files
This topic shows how to use the [EDM Generator (EdmGen.exe)](../../../../../docs/framework/data/adonet/ef/edm-generator-edmgen-exe.md) tool to validate the model and mapping files. For more information, see [Entity Data Model](../../../../../docs/framework/data/adonet/entity-data-model.md).  
  
### To validate the School model using EdmGen.exe  
  
1.  Create the School database. For more information, see [Creating the School Sample Database](https://msdn.microsoft.com/library/bb399731(v=vs.110).aspx).  
  
2.  Generate the School model. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
3.  At the command prompt, execute the following command without line breaks:  
  
    ```console
    "%windir%\Microsoft.NET\Framework\v4.0.30319\edmgen.exe" /mode:ValidateArtifacts /inssdl:.\School.ssdl /inmsl:.\School.msl /incsdl:.\School.csdl  
    ```  
  
## See Also  
 [How to: Manually Configure an Entity Framework Project](https://msdn.microsoft.com/library/bb738546(v=vs.110).aspx)   
 [ADO.NET Entity Data Model  Tools](https://msdn.microsoft.com/library/bb399249(v=vs.110).aspx)   
 [How to: Pre-Generate Views to Improve Query Performance](https://msdn.microsoft.com/library/bb896240(v=vs.110).aspx)   
 [How to: Use EdmGen.exe to Generate Object-Layer Code](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-object-layer-code.md)
