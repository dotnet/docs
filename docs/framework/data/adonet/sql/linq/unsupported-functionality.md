---
title: "Unsupported Functionality | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e480cfb5-697e-42c8-bed5-9264c945c4f9
caps.latest.revision: 2
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# Unsupported Functionality
In LINQ to SQL, the following SQL functionality cannot be exposed through translation of existing common language runtime (CLR) and .NET Framework constructs:  
  
-   `STDDEV`  
  
-   `LIKE`  
  
     Although `LIKE` is not supported through direct translation, similar functionality exists in the <xref:System.Data.Linq.SqlClient.SqlMethods> class. For more information, see [M:System.Data.Linq.SqlClient.SqlMethods.Like(System.String,System.String](assetId:///M:System.Data.Linq.SqlClient.SqlMethods.Like(System.String,System.String?qualifyHint=True&autoUpgrade=True).  
  
-   `DATEDIFF`  
  
     LINQ to SQL has limited support for `DATEDIFF`. Similar functionality exists in the [SqlMethods](assetId:///T:System.Data.Linq.SqlClient.SqlMethods?qualifyHint=False&autoUpgrade=True) class.  
  
-   `ROUND`  
  
     LINQ to SQL has limited support for `ROUND`. For more information, see [System.Math Methods](system-math-methods.md).  
  
## See Also  
 [Data Types and Functions](data-types-and-functions.md)