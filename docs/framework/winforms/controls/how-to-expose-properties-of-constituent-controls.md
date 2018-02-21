---
title: "How to: Expose Properties of Constituent Controls"
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
  - "user controls [Windows Forms], exposing constituent controls"
  - "controls [Windows Forms], constituent"
  - "custom controls [Windows Forms], exposing properties"
  - "constituent controls"
ms.assetid: 5c1ec98b-aa48-4823-986e-4712551cfdf1
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Expose Properties of Constituent Controls
The controls that make up a composite control are called *constituent controls*. These controls are normally declared private, and thus cannot be accessed by the developer. If you want to make properties of these controls available to future users, you must expose them to the user. A property of a constituent control is exposed by creating a property in the user control, and using the `get` and `set` accessors of that property to effect the change in the private property of the constituent control.  
  
 Consider a hypothetical user control with a constituent button named `MyButton`. In this example, when the user requests the `ConstituentButtonBackColor` property, the value stored in the <xref:System.Windows.Forms.Control.BackColor%2A> property of `MyButton` is delivered. When the user assigns a value to this property, that value is automatically passed to the <xref:System.Windows.Forms.Control.BackColor%2A> property of `MyButton` and the `set` code will execute, changing the color of `MyButton`.  
  
 The following example shows how to expose the <xref:System.Windows.Forms.Control.BackColor%2A> property of the constituent button:  
  
```vb  
Public Property ButtonColor() as System.Drawing.Color  
   Get  
      Return MyButton.BackColor  
   End Get  
   Set(Value as System.Drawing.Color)  
      MyButton.BackColor = Value  
   End Set  
End Property  
```  
  
```csharp  
public Color ButtonColor  
{  
   get  
   {  
      return(myButton.BackColor);  
   }  
   set  
   {  
      myButton.BackColor = value;  
   }  
}  
```  
  
### To expose a property of a constituent control  
  
1.  Create a public property for your user control.  
  
2.  In the `get` section of the property, write code that retrieves the value of the property you want to expose.  
  
3.  In the `set` section of the property, write code that passes the value of the property to the exposed property of the constituent control.  
  
## See Also  
 <xref:System.Windows.Forms.UserControl>  
 [Properties in Windows Forms Controls](../../../../docs/framework/winforms/controls/properties-in-windows-forms-controls.md)  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)
