---
title: "How to: Use EdmGen.exe to Generate Object-Layer Code | Microsoft Docs"
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
ms.assetid: c44d2ebe-f66f-42cb-9741-4a3f0c2dcffb
caps.latest.revision: 4
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# How to: Use EdmGen.exe to Generate Object-Layer Code
This topic shows how to use the [EDM Generator (EdmGen.exe)](../../../../../docs/framework/data/adonet/ef/edm-generator-edmgen-exe.md) tool to generate object-layer code  based on the .csdl file.  
  
### To generate object-layer code for the School model for a Visual Basic project using EdmGen.exe  
  
1.  Create the School database. For more information, see [Creating the School Sample Database](https://msdn.microsoft.com/library/bb399731(v=vs.110).aspx).  
  
2.  Generate the School model or obtain the School.csdl file. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
3.  At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v4.0.30319\edmgen.exe" /mode:EntityClassGeneration   
    /incsdl:.\School.csdl /outobjectlayer:.\School.Objects.vb /language:VB  
    ```  
  
### To generate object-layer code for the School model for a C# project using EdmGen.exe  
  
1.  Create the School database. For more information, see [Creating the School Sample Database](https://msdn.microsoft.com/library/bb399731(v=vs.110).aspx).  
  
2.  Generate the School model or obtain the School.csdl file. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
3.  At the command prompt, execute the following command without line breaks:  
  
    ```  
    "%windir%\Microsoft.NET\Framework\v4.0.30319\edmgen.exe" /mode:EntityClassGeneration   
    /incsdl:.\School.csdl /outobjectlayer:.\School.Objects.cs /language:CSharp  
    ```  
  
## See Also  
 [Modeling and Mapping](../../../../../docs/framework/data/adonet/ef/modeling-and-mapping.md)   
 [How to: Manually Configure an Entity Framework Project](https://msdn.microsoft.com/library/bb738546(v=vs.110).aspx)   
 [ADO.NET Entity Data Model  Tools](https://msdn.microsoft.com/library/bb399249(v=vs.110).aspx)   
 [How to: Pre-Generate Views to Improve Query Performance](https://msdn.microsoft.com/library/bb896240(v=vs.110).aspx)   
 [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md)
