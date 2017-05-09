---
title: "Some subkeys cannot be deleted | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: 14562137-af43-4972-84c1-a380a90f7d6c
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Some subkeys cannot be deleted
An attempt has been made to delete a registry key, but the operation failed because some subkeys cannot be deleted. Usually this is due to a lack of permissions.  
  
## To correct this error  
  
-   Make sure you have sufficient permissions to delete the specified subkeys.  
  
## See Also  
 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy?displayProperty=fullName>   
 <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%2A>   
 <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%2A>   
 <xref:System.Security.Permissions.RegistryPermission>