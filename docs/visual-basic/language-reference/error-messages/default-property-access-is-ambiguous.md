---
title: "Default property access is ambiguous between the inherited interface members &#39;&lt;defaultpropertyname&gt;&#39; of interface &#39;&lt;interfacename1&gt;&#39; and &#39;&lt;defaultpropertyname&gt;&#39; of interface &#39;&lt;interfacename2&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30686"
  - "bc30686"
helpviewer_keywords: 
  - "BC30686"
ms.assetid: 784fefec-ef57-48cf-b960-957df419b439
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Default property access is ambiguous between the inherited interface members &#39;&lt;defaultpropertyname&gt;&#39; of interface &#39;&lt;interfacename1&gt;&#39; and &#39;&lt;defaultpropertyname&gt;&#39; of interface &#39;&lt;interfacename2&gt;&#39;
An interface inherits from two interfaces, each of which declares a default property with the same name. The compiler cannot resolve an access to this default property without qualification. The following example illustrates this.  
  
```  
Public Interface Iface1  
    Default Property prop(ByVal arg As Integer) As Integer  
End Interface  
Public Interface Iface2  
    Default Property prop(ByVal arg As Integer) As Integer  
End Interface  
Public Interface Iface3  
    Inherits Iface1, Iface2  
End Interface  
Public Class testClass  
    Public Sub accessDefaultProperty()  
        Dim testObj As Iface3  
        Dim testInt As Integer = testObj(1)  
    End Sub  
End Class  
```  
  
 When you specify `testObj(1)`, the compiler tries to resolve it to the default property. However, there are two possible default properties because of the inherited interfaces, so the compiler signals this error.  
  
 **Error ID:** BC30686  
  
## To correct this error  
  
-   Avoid inheriting any members with the same name. In the preceding example, if `testObj` does not need any of the members of, say, `Iface2`, then declare it as follows:  
  
    ```  
    Dim testObj As Iface1  
    ```  
  
     -or-  
  
-   Implement the inheriting interface in a class. Then you can implement each of the inherited properties with different names. However, only one of them can be the default property of the implementing class. The following example illustrates this.  
  
    ```  
    Public Class useIface3  
        Implements Iface3  
        Default Public Property prop1(ByVal arg As Integer) As Integer Implements Iface1.prop  
            ' Insert code to define Get and Set procedures for prop1.  
        End Property  
        Public Property prop2(ByVal arg As Integer) As Integer Implements Iface2.prop  
            ' Insert code to define Get and Set procedures for prop2.  
        End Property  
    End Class  
    ```  
  
## See Also  
 [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)
