---
title: "Use of Default Instance of a class in the class constructor could lead to infinite recursive call"
ms.date: 07/20/2015
ms.assetid: 9645b47f-7de5-46d0-bb45-d5fdaa8aaa2a
---
# Use of Default Instance of a class in the class constructor could lead to infinite recursive call
A default instance of a class has been used in the constructor of the class. This can lead to an infinite recursive call, also known as an infinite loop.  
  
## To correct this error  
  
-   Remove the default instance from the class constructor.  
  
## See also

- [Constructors](~/docs/visual-basic/programming-guide/concepts/object-oriented-programming.md#constructors)
