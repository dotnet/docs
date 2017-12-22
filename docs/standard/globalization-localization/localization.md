---
title: "Localization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "culture, localization"
  - "application development [.NET Framework], localization"
  - "globalization [.NET Framework], localization"
  - "code blocks"
  - "international applications [.NET Framework], localization"
  - "global applications, localization"
  - "world-ready applications, localization"
  - "user interface blocks"
  - "localization [.NET Framework], about localization"
  - "localizing resources"
ms.assetid: 49d520d7-92d7-44ee-bb24-8b615db1d41b
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Localization
Localization is the process of translating an application's resources into localized versions for each culture that the application will support. You should proceed to the localization step only after completing the [Localizability Review](../../../docs/standard/globalization-localization/localizability-review.md) step to verify that the globalized application is ready for localization.  
  
 An application that is ready for localization is separated into two conceptual blocks, a block that contains all user interface elements and a block that contains executable code. The user interface block contains only localizable user-interface elements such as strings, error messages, dialog boxes, menus, embedded object resources, and so on for the neutral culture. The code block contains only the application code to be used by all supported cultures. The common language runtime supports a satellite assembly resource model that separates an application's executable code from its resources. For more information about implementing this model, see [Resources in Desktop Apps](../../../docs/framework/resources/index.md).  
  
 For each localized version of your application, add a new satellite assembly that contains the localized user interface block translated into the appropriate language for the target culture. The code block for all cultures should remain the same. The combination of a localized version of the user interface block with the code block produces a localized version of your application.  
  
 The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] supplies the Windows Forms Resource Editor (Winres.exe) that allows you to quickly localize Windows Forms for target cultures. For information about using this tool, see [Winres.exe (Windows Forms Resource Editor)](../../../docs/framework/tools/winres-exe-windows-forms-resource-editor.md).  
  
## See Also  
 [Globalization and Localization](../../../docs/standard/globalization-localization/index.md)  
 [Localizability Review](../../../docs/standard/globalization-localization/localizability-review.md)  
 [Globalization](../../../docs/standard/globalization-localization/globalization.md)  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)
