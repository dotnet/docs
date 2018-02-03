---
title: "Troubleshooting Control and Component Authoring"
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
  - "troubleshooting components"
  - "troubleshooting controls [Windows Forms]"
  - "controls [Windows Forms], troubleshooting"
  - "components [Windows Forms], troubleshooting"
  - "Windows Forms controls, debugging"
ms.assetid: e9c8c099-2271-4737-882f-50f336c7a55e
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Troubleshooting Control and Component Authoring
This topic lists the following common problems that arise when developing components and controls. For more information, see [Programming with Components](http://msdn.microsoft.com/library/d4d4fcb4-e0b8-46b3-b679-7ee0026eb9e3).  
  
-   Cannot Add Control to Toolbox  
  
-   Cannot Debug the Windows Forms User Control or Component  
  
-   Event Is Raised Twice in Inherited Control or Component  
  
-   Design-Time Error: "Failed to Create Component '*Component Name*'"  
  
-   STAThreadAttribute  
  
-   Component Icon Does Not Appear in Toolbox  
  
## Cannot Add Control to Toolbox  
 If you want to add a custom control that you created in another project or a third-party control to the **Toolbox**, you must do so manually. If the current project contains your control or component, it should appear in the **Toolbox** automatically. For more information, see [Walkthrough: Automatically Populating the Toolbox with Custom Components](../../../../docs/framework/winforms/controls/walkthrough-automatically-populating-the-toolbox-with-custom-components.md).  
  
#### To add a control to the Toolbox  
  
1.  Right-click the **Toolbox** and from the shortcut menu, select **Choose Items**.  
  
2.  In the **Choose Toolbox Items** dialog box, add the component:  
  
    -   If you want to add a .NET Framework component or control, click the **.NET Framework Components** tab.  
  
         – or –  
  
    -   If you want to add a COM component or ActiveX control, click the **COM Components** tab.  
  
3.  If your control is listed in the dialog box, confirm it is selected, and then click **OK**.  
  
     The control is added to the **Toolbox**.  
  
4.  If your control is not listed in the dialog box, do the following:  
  
    1.  Click the **Browse** button.  
  
    2.  Browse to the folder that contains the .dll file that contains your control.  
  
    3.  Select the .dll file and click **Open**.  
  
         Your control appears in the dialog box.  
  
    4.  Confirm that your control is selected, and then click **OK**.  
  
         Your control is added to the **Toolbox**.  
  
## Cannot Debug the Windows Forms User Control or Component  
 If your control derives from the <xref:System.Windows.Forms.UserControl> class, you can debug its run-time behavior with the test container. For more information, see [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md).  
  
 Other custom controls and components are not stand-alone projects. They must be hosted by an application such as a Windows Forms project. To debug a control or component, you must add it to a Windows Forms project.  
  
#### To debug a control or component  
  
1.  From the **Build** menu, click **Build Solution** to build your solution.  
  
2.  From the **File** menu, choose **Add**, and then **New Project** to add a test project to your application.  
  
3.  In the **Add New Project** dialog box choose **Windows Application** for the type of project.  
  
4.  In **Solution Explorer**, right-click the **References** node for the new project. On the shortcut menu, click **Add Reference** to add a reference to the project containing the control or component.  
  
5.  Create an instance of your control or component in the test project. If your component is in the **Toolbox**, you can drag it to your designer surface, or you can create the instance programmatically, as shown in the following code example.  
  
    ```vb  
    Dim Component1 As New MyNeatComponent()  
    ```  
  
    ```csharp  
    MyNeatComponent Component1 = new MyNeatComponent();  
    ```  
  
     You can now debug your control or component as usual.  
  
 For more information about debugging, see [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio) and [Walkthrough: Debugging Custom Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/walkthrough-debugging-custom-windows-forms-controls-at-design-time.md).  
  
## Event Is Raised Twice in Inherited Control or Component  
 This is likely due to a duplicated `Handles` clause. For more information, see [Troubleshooting Inherited Event Handlers in Visual Basic](~/docs/visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md).  
  
## Design-Time Error: "Failed to Create Component 'Component Name'"  
 Your component or control must provide a default constructor with no parameters. When the design environment creates an instance of your component or control, it does not attempt to provide any parameters to constructor overloads that take parameters.  
  
## STAThreadAttribute  
 The <xref:System.STAThreadAttribute> informs the common language runtime (CLR) that Windows Forms uses the single-threaded apartment model. You may notice unintended behavior if you do not apply this attribute to your Windows Forms application's `Main` method. For example, background images may not appear for controls like <xref:System.Windows.Forms.ListView>. Some controls may also require this attribute for correct AutoComplete and drag-and-drop behavior.  
  
## Component Icon Does Not Appear in Toolbox  
 When you use <xref:System.Drawing.ToolboxBitmapAttribute> to associate an icon with your custom component, the bitmap does not appear in the Toolbox for autogenerated components. To see the bitmap, reload the control by using the **Choose Toolbox Items** dialog box. For more information, see [How to: Provide a Toolbox Bitmap for a Control](../../../../docs/framework/winforms/controls/how-to-provide-a-toolbox-bitmap-for-a-control.md).  
  
## See Also  
 [Developing Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/developing-windows-forms-controls-at-design-time.md)  
 [Walkthrough: Automatically Populating the Toolbox with Custom Components](../../../../docs/framework/winforms/controls/walkthrough-automatically-populating-the-toolbox-with-custom-components.md)  
 [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md)  
 [Walkthrough: Debugging Custom Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/walkthrough-debugging-custom-windows-forms-controls-at-design-time.md)  
 [Component Authoring](http://msdn.microsoft.com/library/4a5a5e49-0378-4a31-83bc-24da0f1a727d)  
 [Troubleshooting Design-Time Development](http://msdn.microsoft.com/library/e048d08e-fa7c-4be8-b238-4abaa199a0a6)  
 [Programming with Components](http://msdn.microsoft.com/library/d4d4fcb4-e0b8-46b3-b679-7ee0026eb9e3)
