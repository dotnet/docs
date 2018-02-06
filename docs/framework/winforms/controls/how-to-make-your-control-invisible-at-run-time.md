---
title: "How to: Make Your Control Invisible at Run Time"
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
  - "controls [Windows Forms], making invisible at run time"
  - "invisible controls"
  - "user controls [Windows Forms], invisible"
  - "custom controls [Windows Forms], invisible"
  - "run time [Windows Forms], making controls invisible"
ms.assetid: 69eb2e72-32f5-4f79-a157-c2c5f60c1628
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Make Your Control Invisible at Run Time
There are times when you might want to create a user control that is invisible at run time. For example, a control that is an alarm clock might be invisible except when the alarm was sounding. This is easily accomplished by setting the <xref:System.Windows.Forms.Control.Visible%2A> property. If the <xref:System.Windows.Forms.Control.Visible%2A> property is `true`, your control will appear as normal. If `false`, your control will be hidden. Although code in your control may still run while invisible, you will not be able to interact with the control through the user interface. If you want to create an invisible control that still responds to user input (for example, mouse clicks), you should create a transparent control. For more information, see [Giving Your Control a Transparent Background](../../../../docs/framework/winforms/controls/how-to-give-your-control-a-transparent-background.md).  
  
### To make your control invisible at run time  
  
1.  Set the <xref:System.Windows.Forms.Control.Visible%2A> property to `false`.  
  
    ```vb  
    ' To set the Visible property from within your object's own code.  
    Me.Visible = False  
    ' To set the Visible property from another object.  
    myControl1.Visible = False  
    ```  
  
    ```csharp  
    // To set the Visible property from within your object's own code.  
    this.Visible = false;  
    // To set the Visible property from another object.  
    myControl1.Visible = false;  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.Control.Visible%2A>  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)  
 [How to: Give Your Control a Transparent Background](../../../../docs/framework/winforms/controls/how-to-give-your-control-a-transparent-background.md)
