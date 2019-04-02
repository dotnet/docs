---
title: "'<membername>' cannot expose type '<typename>' outside the project through <containertype> '<containertypename>'"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30909"
  - "vbc30909"
helpviewer_keywords: 
  - "BC30909"
ms.assetid: ffa7395d-e182-4087-8ce8-079810fdae54
---
# '\<membername>' cannot expose type '\<typename>' outside the project through \<containertype> '\<containertypename>'
A variable, procedure parameter, or function return is exposed outside its container, but it is declared as a type that must not be exposed outside the container.  
  
 The following skeleton code shows a situation that generates this error.  
  
```  
Private Class privateClass  
End Class  
Public Class mainClass  
    Public exposedVar As New privateClass  
End Class  
```  
  
 A type that is declared `Protected`, `Friend`, `Protected Friend`, or `Private` is intended to have limited access outside its declaration context. Using it as the data type of a variable with less restricted access would defeat this purpose. In the preceding skeleton code, `exposedVar` is `Public` and would expose `privateClass` to code that should not have access to it.  
  
 **Error ID:** BC30909  
  
## To correct this error  
  
-   Change the access level of the variable, procedure parameter, or function return to be at least as restrictive as the access level of its data type.  
  
## See also

- [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)
