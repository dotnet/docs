---
title: "How to: Test the Run-Time Behavior of a UserControl"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "UserControl class [Windows Forms], testing"
  - "user controls [Windows Forms], testing"
  - "composite controls [Windows Forms], testing"
  - "UserControl Test Container"
  - "UserControl class [Windows Forms], run-time behavior"
ms.assetid: 4e4d5c49-1346-40ac-9d96-40211b573583
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Test the Run-Time Behavior of a UserControl
When you develop a <xref:System.Windows.Forms.UserControl>, you need to test its run-time behavior. You can create a separate Windows-based application project and place your control on a test form, but this procedure is inconvenient. A faster and easier way is to use the **UserControl Test Container** provided by Visual Studio. This test container starts directly from your Windows control library project.  
  
> [!IMPORTANT]
>  For the test container to load your <xref:System.Windows.Forms.UserControl>, the control must have at least one public constructor.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
> [!NOTE]
>  A Visual C++ control cannot be tested using the **UserControl Test Container**.  
  
### To test the run-time behavior of a UserControl  
  
1.  Create a Windows control library project called **TestContainerExample**. For details, see [Windows Control Library Template](http://msdn.microsoft.com/library/722f4e2d-1310-4ed5-8f33-593337ab66b4).  
  
2.  In the **Windows Forms Designer**, drag a <xref:System.Windows.Forms.Label> control from the **Toolbox** onto the control's design surface.  
  
3.  Press F5 to build the project and run the **UserControl Test Container**. The test container appears with your <xref:System.Windows.Forms.UserControl> in the **Preview** pane.  
  
4.  Select the <xref:System.Windows.Forms.Control.BackColor%2A> property displayed in the <xref:System.Windows.Forms.PropertyGrid> control to the right of the **Preview** pane. Change its value to `ControlDark`. Observe that the control changes to a darker color. Try changing other property values and observe the effect on your control.  
  
5.  Click the **Dock Fill User Control** check box below the **Preview** pane. Observe that the control is resized to fill the pane. Resize the test container and observe that the control is resized with the pane.  
  
6.  Close the test container.  
  
7.  Add another user control to the **TestContainerExample** project. For details, see [NIB:How to: Add Existing Items to a Project](http://msdn.microsoft.com/library/15f4cfb7-78ab-457f-9f14-099a25a6a2d3).  
  
8.  In the **Windows Forms Designer**, drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto the control's design surface.  
  
9. Press F5 to build the project and run the test container.  
  
10. Click the **Select User Control**<xref:System.Windows.Forms.ComboBox> to switch between the two user controls.  
  
## Testing User Controls from Another Project  
 You can test user controls from other projects in your current project's test container.  
  
#### To test user controls from another project  
  
1.  Create a Windows control library project called **TestContainerExample2**. For details, see [Windows Control Library Template](http://msdn.microsoft.com/library/722f4e2d-1310-4ed5-8f33-593337ab66b4).  
  
2.  In the **Windows Forms Designer**, drag a <xref:System.Windows.Forms.RadioButton> control from the **Toolbox** onto the control's design surface.  
  
3.  Press F5 to build the project and run the test container. The test container appears with your <xref:System.Windows.Forms.UserControl> in the **Preview** pane.  
  
4.  Click the **Load** button.  
  
5.  In the **Open** dialog box, navigate to **TestContainerExample**.dll, which you built in the previous procedure. Select **TestContainerExample**.dll and click the **Open** button to load the user controls  
  
6.  Use the **Select User Control**<xref:System.Windows.Forms.ComboBox> to switch between the two user controls from the **TestContainerExample** project.  
  
## See Also  
 <xref:System.Windows.Forms.UserControl>  
 [How to: Author Composite Controls](../../../../docs/framework/winforms/controls/how-to-author-composite-controls.md)  
 [Walkthrough: Authoring a Composite Control with Visual Basic](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-basic.md)  
 [Walkthrough: Authoring a Composite Control with Visual C#](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-csharp.md)  
 [User Control Designer](http://msdn.microsoft.com/library/2abb9eec-ba32-45cb-b73d-8b52a8bd6bf1)
