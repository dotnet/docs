---
description: "Learn more about: Sub or Function not defined (Visual Basic)"
title: "Sub or Function not defined"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID35"
ms.assetid: 661fdb90-ee7d-40ce-b30b-5e7267bd957a
---
# Sub or Function not defined (Visual Basic)

A `Sub` or `Function` must be defined in order to be called. Possible causes of this error include:  
  
- Misspelling the procedure name.  
  
- Trying to call a procedure from another project without explicitly adding a reference to that project in the **References** dialog box.  
  
- Specifying a procedure that is not visible to the calling procedure.  
  
- Declaring a Windows dynamic-link library (DLL) routine or Macintosh code-resource routine that is not in the specified library or code resource.  
  
## To correct this error  
  
1. Make sure that the procedure name is spelled correctly.  
  
2. Find the name of the project containing the procedure you want to call in the **References** dialog box. If it does not appear, click the **Browse** button to search for it. Select the check box to the left of the project name, and then click **OK**.  
  
3. Check the name of the routine.  
  
## See also

- [Error Types](../../programming-guide/language-features/error-types.md)
- [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
- [Sub Statement](../statements/sub-statement.md)
- [Function Statement](../statements/function-statement.md)
