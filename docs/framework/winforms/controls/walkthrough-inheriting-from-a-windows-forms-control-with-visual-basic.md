---
title: "Walkthrough: Inheriting from a Windows Forms Control with Visual Basic"
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
  - "vb"
helpviewer_keywords: 
  - "inheritance [Windows Forms], custom controls"
  - "inheritance [Windows Forms], control"
  - "Windows Forms controls, inheritance"
  - "inheritance [Windows Forms], walkthroughs"
  - "custom controls [Windows Forms], inheritance"
ms.assetid: fb58d7c8-b702-4478-ad31-b00cae118882
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Inheriting from a Windows Forms Control with Visual Basic
With [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)], you can create powerful custom controls through *inheritance*. Through inheritance you are able to create controls that retain all of the inherent functionality of standard Windows Forms controls but also incorporate custom functionality. In this walkthrough, you will create a simple inherited control called `ValueButton`. This button will inherit functionality from the standard Windows Forms <xref:System.Windows.Forms.Button> control, and will expose a custom property called `ButtonValue`.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 When you create a new project, you specify its name in order to set the root namespace, assembly name, and project name, and to ensure that the default component will be in the correct namespace.  
  
#### To create the ValueButtonLib control library and the ValueButton control  
  
1.  On the **File** menu, point to **New** and then click **Project** to open the **New Project** dialog box.  
  
2.  Select the **Windows Forms Control Library** project template from the list of [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] projects, and type `ValueButtonLib` in the **Name** box.  
  
     The project name, `ValueButtonLib`, is also assigned to the root namespace by default. The root namespace is used to qualify the names of components in the assembly. For example, if two assemblies provide components named `ValueButton`, you can specify your `ValueButton` component using `ValueButtonLib.ValueButton`. For more information, see [Namespaces in Visual Basic](~/docs/visual-basic/programming-guide/program-structure/namespaces.md).  
  
3.  In **Solution Explorer**, right-click **UserControl1.vb**, then choose **Rename** from the shortcut menu. Change the file name to `ValueButton.vb`. Click the **Yes** button when you are asked if you want to rename all references to the code element 'UserControl1'.  
  
4.  In **Solution Explorer**, click the **Show All Files** button.  
  
5.  Open the **ValueButton.vb** node to display the designer-generated code file, **ValueButton.Designer.vb**. Open this file in the **Code Editor**.  
  
6.  Locate the `Class` statement, `Partial Public Class ValueButton`, and change the type from which this control inherits from <xref:System.Windows.Forms.UserControl> to <xref:System.Windows.Forms.Button>. This allows your inherited control to inherit all the functionality of the <xref:System.Windows.Forms.Button> control.  
  
7.  Locate the `InitializeComponent` method and remove the line that assigns the <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> property. This property does not exist in the <xref:System.Windows.Forms.Button> control.  
  
8.  From the **File** menu, choose **Save All** to save the project.  
  
     Note that a visual designer is no longer available. Because the <xref:System.Windows.Forms.Button> control does its own painting, you are unable to modify its appearance in the designer. Its visual representation will be exactly the same as that of the class it inherits from (that is, <xref:System.Windows.Forms.Button>) unless modified in the code.  
  
> [!NOTE]
>  You can still add components, which have no UI elements, to the design surface.  
  
## Adding a Property to Your Inherited Control  
 One possible use of inherited Windows Forms controls is the creation of controls that are identical in appearance and behavior (look and feel) to standard Windows Forms controls, but expose custom properties. In this section, you will add a property called `ButtonValue` to your control.  
  
#### To add the Value property  
  
1.  In **Solution Explorer**, right-click **ValueButton.vb**, and then click **View Code** from the shortcut menu.  
  
2.  Locate the `Public Class ValueButton` statement. Immediately beneath this statement, type the following code:  
  
    ```vb  
    ' Creates the private variable that will store the value of your   
    ' property.  
    Private varValue as integer  
    ' Declares the property.  
    Property ButtonValue() as Integer  
    ' Sets the method for retrieving the value of your property.  
       Get  
          Return varValue  
       End Get  
    ' Sets the method for setting the value of your property.  
       Set(ByVal Value as Integer)  
          varValue = Value  
       End Set  
    End Property  
    ```  
  
     This code sets the methods by which the `ButtonValue` property is stored and retrieved. The `Get` statement sets the value returned to the value that is stored in the private variable `varValue`, and the `Set` statement sets the value of the private variable by use of the `Value` keyword.  
  
3.  From the **File** menu, choose **Save All** to save the project.  
  
## Testing Your Control  
 Controls are not stand-alone projects; they must be hosted in a container. In order to test your control, you must provide a test project for it to run in. You must also make your control accessible to the test project by building (compiling) it. In this section, you will build your control and test it in a Windows Form.  
  
#### To build your control  
  
1.  On the **Build** menu, click **Build Solution**.  
  
     The build should be successful with no compiler errors or warnings.  
  
#### To create a test project  
  
1.  On the **File** menu, point to **Add** and then click **New Project** to open the **Add New Project** dialog box.  
  
2.  Select the [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] projects node, and click **Windows Forms Application**.  
  
3.  In the **Name** box, type `Test`.  
  
4.  In **Solution Explorer**, click the **Show All Files** button.  
  
5.  In **Solution Explorer**, right-click the **References** node for your test project, then select **Add Reference** from the shortcut menu to display the **Add Reference** dialog box.  
  
6.  Click the **Projects** tab.  
  
7.  Click the tab labeled **Projects**. Your `ValueButtonLib` project will be listed under **Project Name**. Double-click the project to add the reference to the test project.  
  
8.  In **Solution Explorer,** right-click **Test** and select **Build**.  
  
#### To add your control to the form  
  
1.  In **Solution Explorer**, right-click **Form1.vb** and choose **View Designer** from the shortcut menu.  
  
2.  In the **Toolbox**, click **ValueButtonLib Components**. Double-click **ValueButton**.  
  
     A **ValueButton** appears on the form.  
  
3.  Right-click the **ValueButton** and select **Properties** from the shortcut menu.  
  
4.  In the **Properties** window, examine the properties of this control. Note that they are identical to the properties exposed by a standard button, except that there is an additional property, `ButtonValue`.  
  
5.  Set the `ButtonValue` property to `5`.  
  
6.  On the **All Windows Forms** tab of the **Toolbox**, double-click **Label** to add a <xref:System.Windows.Forms.Label> control to your form.  
  
7.  Relocate the label to the center of the form.  
  
8.  Double-click `ValueButton1`.  
  
     The **Code Editor** opens to the `ValueButton1_Click` event.  
  
9. Type the following line of code.  
  
    ```vb  
    Label1.Text = CStr(ValueButton1.ButtonValue)  
    ```  
  
10. In **Solution Explorer**, right-click **Test**, and choose **Set as Startup Project** from the shortcut menu.  
  
11. From the **Debug** menu, select **Start Debugging**.  
  
     `Form1` appears.  
  
12. Click `Valuebutton1`.  
  
     The numeral '5' is displayed in `Label1`, demonstrating that the `ButtonValue` property of your inherited control has been passed to `Label1` through the `ValueButton1_Click` method. Thus your `ValueButton` control inherits all the functionality of the standard Windows Forms button, but exposes an additional, custom property.  
  
## See Also  
 [Walkthrough: Authoring a Composite Control with Visual Basic](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-basic.md)  
 [How to: Display a Control in the Choose Toolbox Items Dialog Box](../../../../docs/framework/winforms/controls/how-to-display-a-control-in-the-choose-toolbox-items-dialog-box.md)  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)  
 [Inheritance basics (Visual Basic)](~/docs/visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)  
 [Component Authoring Walkthroughs](http://msdn.microsoft.com/library/c414cca9-2489-4208-8b38-954586d91c13)
