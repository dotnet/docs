---
title: "Walkthrough: Inheriting from a Windows Forms Control with Visual C#"
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
  - "inheritance [Windows Forms], custom controls"
  - "inheritance [Windows Forms], control"
  - "Windows Forms controls, inheritance"
  - "inheritance [Windows Forms], walkthroughs"
  - "custom controls [Windows Forms], inheritance"
ms.assetid: 09476da0-8d4c-4a4c-b969-649519dfb438
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Inheriting from a Windows Forms Control with Visual C# #
With [!INCLUDE[csprcslong](../../../../includes/csprcslong-md.md)], you can create powerful custom controls through *inheritance*. Through inheritance you are able to create controls that retain all of the inherent functionality of standard Windows Forms controls but also incorporate custom functionality. In this walkthrough, you will create a simple inherited control called `ValueButton`. This button will inherit functionality from the standard Windows Forms <xref:System.Windows.Forms.Button> control, and will expose a custom property called `ButtonValue`.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 When you create a new project, you specify its name in order to set the root namespace, assembly name, and project name, and to ensure that the default component will be in the correct namespace.  
  
#### To create the ValueButtonLib control library and the ValueButton control  
  
1.  On the **File** menu, point to **New** and then click **Project** to open the **New Project** dialog box.  
  
2.  Select the **Windows Forms Control Library** project template from the list of [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] Projects, and type `ValueButtonLib` in the **Name** box.  
  
     The project name, `ValueButtonLib`, is also assigned to the root namespace by default. The root namespace is used to qualify the names of components in the assembly. For example, if two assemblies provide components named `ValueButton`, you can specify your `ValueButton` component using `ValueButtonLib.ValueButton`. For more information, see [Namespaces](../../../csharp/programming-guide/namespaces/index.md).  
  
3.  In **Solution Explorer**, right-click **UserControl1.cs**, then choose **Rename** from the shortcut menu. Change the file name to `ValueButton.cs`. Click the **Yes** button when you are asked if you want to rename all references to the code element '`UserControl1`'.  
  
4.  In **Solution Explorer**, right-click **ValueButton.cs** and select **View Code**.  
  
5.  Locate the `class` statement line, `public partial class ValueButton`, and change the type from which this control inherits from <xref:System.Windows.Forms.UserControl> to <xref:System.Windows.Forms.Button>. This allows your inherited control to inherit all the functionality of the <xref:System.Windows.Forms.Button> control.  
  
6.  In **Solution Explorer**, open the **ValueButton.cs** node to display the designer-generated code file, **ValueButton.Designer.cs**. Open this file in the **Code Editor**.  
  
7.  Locate the `InitializeComponent` method and remove the line that assigns the <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> property. This property does not exist in the <xref:System.Windows.Forms.Button> control.  
  
8.  From the **File** menu, choose **Save All** to save the project.  
  
    > [!NOTE]
    >  A visual designer is no longer available. Because the <xref:System.Windows.Forms.Button> control does its own painting, you are unable to modify its appearance in the designer. Its visual representation will be exactly the same as that of the class it inherits from (that is, <xref:System.Windows.Forms.Button>) unless modified in the code. You can still add components, which have no UI elements, to the design surface.  
  
## Adding a Property to Your Inherited Control  
 One possible use of inherited Windows Forms controls is the creation of controls that are identical in look and feel of standard Windows Forms controls, but expose custom properties. In this section, you will add a property called `ButtonValue` to your control.  
  
#### To add the Value property  
  
1.  In **Solution Explorer**, right-click **ValueButton.cs**, and then click **View Code** from the shortcut menu.  
  
2.  Locate the `class` statement. Immediately after the `{`, type the following code:  
  
    ```csharp  
    // Creates the private variable that will store the value of your   
    // property.  
    private int varValue;  
    // Declares the property.  
    public int ButtonValue  
    {  
       // Sets the method for retrieving the value of your property.  
       get  
       {  
          return varValue;  
       }  
       // Sets the method for setting the value of your property.  
       set  
       {  
          varValue = value;  
       }  
    }  
    ```  
  
     This code sets the methods by which the `ButtonValue` property is stored and retrieved. The `get` statement sets the value returned to the value that is stored in the private variable `varValue`, and the `set` statement sets the value of the private variable by use of the `value` keyword.  
  
3.  From the **File** menu, choose **Save All** to save the project.  
  
## Testing Your Control  
 Controls are not stand-alone projects; they must be hosted in a container. In order to test your control, you must provide a test project for it to run in. You must also make your control accessible to the test project by building (compiling) it. In this section, you will build your control and test it in a Windows Form.  
  
#### To build your control  
  
1.  On the **Build** menu, click **Build Solution**.  
  
     The build should be successful with no compiler errors or warnings.  
  
#### To create a test project  
  
1.  On the **File** menu, point to **Add** and then click **New Project** to open the **Add New Project** dialog box.  
  
2.  Select the **Windows** node, beneath the **Visual C#** node, and click **Windows Forms Application**.  
  
3.  In the **Name** box, type `Test`.  
  
4.  In **Solution Explorer**, right-click the **References** node for your test project, then select **Add Reference** from the shortcut menu to display the **Add Reference** dialog box.  
  
5.  Click the tab labeled **Projects**. Your `ValueButtonLib` project will be listed under **Project Name**. Double-click the project to add the reference to the test project.  
  
6.  In **Solution Explorer,** right-click **Test** and select **Build**.  
  
#### To add your control to the form  
  
1.  In **Solution Explorer**, right-click **Form1.cs** and choose **View Designer** from the shortcut menu.  
  
2.  In the **Toolbox**, click **ValueButtonLib Components**. Double-click **ValueButton**.  
  
     A **ValueButton** appears on the form.  
  
3.  Right-click the **ValueButton** and select **Properties** from the shortcut menu.  
  
4.  In the **Properties** window, examine the properties of this control. Note that they are identical to the properties exposed by a standard button, except that there is an additional property, `ButtonValue`.  
  
5.  Set the `ButtonValue` property to `5`.  
  
6.  In the **All Windows Forms** tab of the **Toolbox**, double-click **Label** to add a <xref:System.Windows.Forms.Label> control to your form.  
  
7.  Relocate the label to the center of the form.  
  
8.  Double-click `valueButton1`.  
  
     The **Code Editor** opens to the `valueButton1_Click` event.  
  
9. Insert the following line of code.  
  
    ```csharp  
    label1.Text = valueButton1.ButtonValue.ToString();  
    ```  
  
10. In **Solution Explorer**, right-click **Test**, and choose **Set as Startup Project** from the shortcut menu.  
  
11. From the **Debug** menu, select **Start Debugging**.  
  
     `Form1` appears.  
  
12. Click `valueButton1`.  
  
     The numeral '5' is displayed in `label1`, demonstrating that the `ButtonValue` property of your inherited control has been passed to `label1` through the `valueButton1_Click` method. Thus your `ValueButton` control inherits all the functionality of the standard Windows Forms button, but exposes an additional, custom property.  
  
## See Also  
 [Programming with Components](http://msdn.microsoft.com/library/d4d4fcb4-e0b8-46b3-b679-7ee0026eb9e3)  
 [Component Authoring Walkthroughs](http://msdn.microsoft.com/library/c414cca9-2489-4208-8b38-954586d91c13)  
 [How to: Display a Control in the Choose Toolbox Items Dialog Box](../../../../docs/framework/winforms/controls/how-to-display-a-control-in-the-choose-toolbox-items-dialog-box.md)  
 [Walkthrough: Authoring a Composite Control with Visual C#](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-csharp.md)
