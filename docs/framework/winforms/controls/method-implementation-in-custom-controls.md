---
title: "Method Implementation in Custom Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "user controls [Windows Forms], method implementation"
  - "custom controls [Windows Forms], overloading methods"
  - "custom controls [Windows Forms], method implementation"
  - "methods [Windows Forms]"
  - "methods [Windows Forms], custom controls"
ms.assetid: 35d14fca-4bb4-4a27-8211-1f7a98ea27de
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Method Implementation in Custom Controls
A method is implemented in a control in the same manner a method would be implemented in any other component.  
  
 In Visual Basic, if a method is required to return a value, it is implemented as a `Public Function`. If no value is returned, it is implemented as a `Public Sub`. Methods are declared using the following syntax:  
  
```vb  
Public Function ConvertMatterToEnergy(Matter as Integer) As Integer  
   ' Conversion code goes here.  
End Function  
```  
  
 Because functions return a value, they must specify a return type, such as integer, string, object, and so on. The arguments `Function` or `Sub` procedures take, if any, must also be specified.  
  
 C# makes no distinction between functions and procedures, as Visual Basic does. A method either returns a value or returns `void`. The syntax for declaring a C# public method is:  
  
```csharp  
public int ConvertMatterToEnergy(int matter)  
{  
   // Conversion code goes here.  
}  
```  
  
 When you declare a method, declare all of its arguments as explicit data types whenever possible. Arguments that take object references should be declared as specific class types — for example, `As Widget` instead of `As Object`. In Visual Basic, the default setting `Option Strict` automatically enforces this rule.  
  
 Typed arguments allow many developer errors to be caught by the compiler, rather than at run time. The compiler always catches errors, whereas run-time testing is only as good as the test suite.  
  
## Overloaded Methods  
 If you want to allow users of your control to supply different combinations of parameters to a method, provide multiple overloads of the method, using explicit data types. Avoid creating parameters declared `As Object` that can contain any data type, as this can lead to errors that might not be caught in testing.  
  
> [!NOTE]
>  The universal data type in the common language runtime is `Object` rather than `Variant`. `Variant` has been removed from the language.  
  
 For example, the `Spin` method of a hypothetical `Widget` control might allow either direct specification of spin direction and speed, or specification of another `Widget` object from which angular momentum is to be absorbed:  
  
```vb  
Overloads Public Sub Spin( _  
   ByVal SpinDirection As SpinDirectionsEnum, _  
   ByVal RevolutionsPerSecond As Double)  
   ' Implementation code here.  
End Sub  
Overloads Public Sub Spin(ByVal Driver As Widget) _  
   ' Implementation code here.  
End Sub  
```  
  
```csharp  
public void Spin(SpinDirectionsEnum spinDirection, double revolutionsPerSecond)  
{  
   // Implementation code here.  
}  
  
public void Spin(Widget driver)  
{  
   // Implementation code here.  
}  
```  
  
## See Also  
 [Events](../../../../docs/standard/events/index.md)  
 [Properties in Windows Forms Controls](../../../../docs/framework/winforms/controls/properties-in-windows-forms-controls.md)
