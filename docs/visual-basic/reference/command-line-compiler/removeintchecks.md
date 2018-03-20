---
title: "-removeintchecks"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "removeintchecks"
  - "-removeintchecks"
helpviewer_keywords: 
  - "removeintchecks compiler option [Visual Basic]"
  - "/removeintchecks compiler option [Visual Basic]"
  - "-removeintchecks compiler option [Visual Basic]"
ms.assetid: c1835bd5-1e38-4fba-bd2f-6984774765d4
author: rpetrusha
ms.author: ronpet
---
# -removeintchecks
Turns overflow-error checking for integer operations on or off.  
  
## Syntax  
  
```  
-removeintchecks[+ | -]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. The `-removeintchecks-` option causes the compiler to check all integer calculations for overflow errors. The default is `-removeintchecks-`.<br /><br /> Specifying `-removeintchecks` or `-removeintchecks+` prevents error checking and can make integer calculations faster. However, without error checking, and if data type capacities are overflowed, incorrect results may be stored without raising an error.|  
  
|To set -removeintchecks in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Click the **Advanced** button.<br />4.  Modify the value of the **Remove integer overflow checks** box.|  
  
## Example  
 The following code compiles `Test.vb` and turns off integer overflow-error checking.  
  
```console
vbc -removeintchecks+ test.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
