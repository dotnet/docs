---
title: "This single-instance application could not connect to the original instance | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrAppModel_SingleInstanceCantConnect"
ms.assetid: 7c2c0cee-02a1-4157-be03-39d18e18408f
caps.latest.revision: 12
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
# This single-instance application could not connect to the original instance
This single-instance application could not connect to the original instance. Some of the possible causes for this problem are as follows:  
  
-   The original instance stopped responding.  
  
-   The application does not have permissions to create kernel objects. For more information about kernel objects, see [Mutexes](../../standard/threading/mutexes.md).  
  
     The base name for the kernel objects comes from concatenating the assembly's GUID, major version number, and minor version number. For example, the base name could be `3639f15d-9547-43da-8145-60da347829915.1`.  
  
## To correct this error when developing the application  
  
1.  Check that the application does not go into an unresponsive state.  
  
2.  Check that the application has sufficient permissions to create kernel objects.  
  
3.  Restart the original instance of the application.  
  
4.  Restart the computer to clear any process that may be using the resource that is required to connect to the original instance application.  
  
5.  Note the circumstances under which the error occurred, and telephone Microsoft Product Support Services.  
  
## See Also  
 [NIB: How to: Specify Instancing Behavior for an Application (Visual Basic)](http://msdn.microsoft.com/en-us/48539ad8-d960-4210-beab-ee65f6c6dc6e)   
 [Debugger Basics](https://docs.microsoft.com/visualstudio/debugger/debugger-basics)   
 [PAVEOVER Product Support and Accessibility](http://msdn.microsoft.com/en-us/14e1d293-7b6d-40a6-bf3e-a92f8ee6c88c)