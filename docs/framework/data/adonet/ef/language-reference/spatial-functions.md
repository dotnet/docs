---
title: "Spatial Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 90cb177d-88a0-45be-97e8-3b306283c6e0
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Spatial Functions
There is no literal format for spatial types. However, you can use canonical Entity Framework functions that you call using strings in Well-Known Text format. For example, the following function call creates a geometry point:  
  
```  
GeometryFromText('POINT (43 -73)')  
```  
  
 The [SpatialEdmFunctions Methods](http://msdn.microsoft.com/library/hh749531.aspx) page lists all spatial canonical Entity Framework methods. Click on a method of interest to see what parameters should be passed to a function.
