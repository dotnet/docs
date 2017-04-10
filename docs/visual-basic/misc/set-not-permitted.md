---
title: "Set not permitted | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrID387"
ms.assetid: 809f6768-7dd7-4632-b4dd-83856edfdb48
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Set not permitted
You attempted to change a property whose settings either cannot be set at run time or else can only be set under certain conditions. For example, you may have tried to change the `Appearance`, `ControlBox`,`MinButton`, or `MaxButton` property settings for the form at run time, or you may have tried to set the `Visible` property to `False` for the last remaining visible submenu on a parent menu.  
  
## To correct this error  
  
1.  Check the property and determine under what conditions it can be set.  
  
## See Also  
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)