---
title: "Walkthrough: Demonstrating Visual Inheritance"
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
  - "form inheritance [Windows Forms], walkthroughs"
  - "visual inheritance"
  - "inheritance [Windows Forms], walkthroughs"
  - "walkthroughs [Windows Forms], visual inheritance"
  - "Windows Forms, inheritance"
ms.assetid: 01966086-3142-450e-8210-3fd4cb33f591
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Demonstrating Visual Inheritance
Visual inheritance enables you to see the controls on the base form and to add new controls. In this walkthrough you will create a base form and compile it into a class library. You will import this class library into another project and create a new form that inherits from the base form. During this walkthrough, you will learn how to:  
  
-   Create a class library project containing a base form.  
  
-   Add a button with properties that derived classes of the base form can modify.  
  
-   Add a button that cannot be modified by inheritors of the base form.  
  
-   Create a project containing a form that inherits from `BaseForm`.  
  
 Ultimately, this walkthrough will demonstrate the difference between private and protected controls on an inherited form.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
> [!CAUTION]
>  Not all controls support visual inheritance from a base form. The following controls do not support the scenario described in this walkthrough:  
>   
>  <xref:System.Windows.Forms.WebBrowser>  
>   
>  <xref:System.Windows.Forms.ToolStrip>  
>   
>  <xref:System.Windows.Forms.ToolStripPanel>  
>   
>  <xref:System.Windows.Forms.TableLayoutPanel>  
>   
>  <xref:System.Windows.Forms.FlowLayoutPanel>  
>   
>  <xref:System.Windows.Forms.DataGridView>  
>   
>  These controls in the inherited form are always read-only regardless of the modifiers you use (`private`, `protected`, or `public`).  
  
## Scenario Steps  
 The first step is to create the base form.  
  
#### To create a class library project containing a base form  
  
1.  From the **File** menu, choose **New**, and then **Project** to open the **New Project** dialog box.  
  
2.  Create a Windows Forms application named `BaseFormLibrary`.  
  
3.  To create a class library instead of a standard Windows Forms application, in **Solution Explorer**, right-click the **BaseFormLibrary** project node and then select **Properties**.  
  
4.  In the properties for the project, change the **Output type** from **Windows Application** to **Class Library**.  
  
5.  From the **File** menu, choose **Save All** to save the project and files to the default location.  
  
 The next two procedures add buttons to the base form. To demonstrate visual inheritance, you will give the buttons different access levels by setting their `Modifiers` properties.  
  
#### To add a button that inheritors of the base form can modify  
  
1.  Open **Form1** in the designer.  
  
2.  On the **All Windows Forms** tab of the **Toolbox**, double-click **Button** to add a button to the form. Use the mouse to position and resize the button.  
  
3.  In the Properties window, set the following properties of the button:  
  
    -   Set the **Text** property to **Say Hello**.  
  
    -   Set the **(Name)** property to **btnProtected**.  
  
    -   Set the**Modifiers** property to **Protected**. This makes it possible for forms that inherit from **Form1** to modify the properties of **btnProtected**.  
  
4.  Double-click the **Say Hello** button to add an event handler for the **Click** event.  
  
5.  Add the following line of code to the event handler:  
  
    ```vb  
    MessageBox.Show("Hello, World!")  
    ```  
  
    ```csharp  
    MessageBox.Show("Hello, World!");  
    ```  
  
#### To add a button that cannot be modified by inheritors of the base form  
  
1.  Switch to design view by clicking the **Form1.vb [Design], Form1.cs [Design], or Form1.jsl [Design]** tab above the code editor, or by pressing F7.  
  
2.  Add a second button and set its properties as follows:  
  
    -   Set the **Text** property to **Say Goodbye**.  
  
    -   Set the **(Name)** property to **btnPrivate**.  
  
    -   Set the **Modifiers** property to **Private**. This makes it impossible for forms that inherit from **Form1** to modify the properties of **btnPrivate**.  
  
3.  Double-click the **Say Goodbye** button to add an event handler for the **Click** event. Place the following line of code in the event procedure:  
  
    ```vb  
    MessageBox.Show("Goodbye!")  
    ```  
  
    ```csharp  
    MessageBox.Show("Goodbye!");  
    ```  
  
4.  From the **Build** menu, choose **Build BaseForm Library** to build the class library.  
  
     Once the library is built, you can create a new project that inherits from the form you just created.  
  
#### To create a project containing a form that inherits from the base form  
  
1.  From the **File** menu, choose **Add** and then **New Project** to open the **Add New Project** dialog box.  
  
2.  Create a Windows Forms application named `InheritanceTest`.  
  
#### To add an inherited form  
  
1.  In **Solution Explorer**, right-click the **InheritanceTest** project, select **Add**, and then select**New Item**.  
  
2.  In the **Add New Item** dialog box, select the **Windows Forms** category (if you have a list of categories) and then select the **Inherited Form** template.  
  
3.  Leave the default name of `Form2` and then click **Add**.  
  
4.  In the **Inheritance Picker** dialog box, select **Form1** from the **BaseFormLibrary** project as the form to inherit from and click **OK**.  
  
     This creates a form in the **InheritanceTest** project that derives from the form in **BaseFormLibrary**.  
  
5.  Open the inherited form (**Form2**) in the designer by double-clicking it, if it is not already open.  
  
     In the designer, the inherited buttons have a symbol (![VisualBasicInheritanceSymbol screenshot](../../../../docs/framework/winforms/advanced/media/vbinheritanceglyph.gif "vbInheritanceGlyph")) in their upper corner, indicating they are inherited.  
  
6.  Select the **Say Hello** button and observe the resize handles. Because this button is protected, the inheritors can move it, resize it, change its caption, and make other modifications.  
  
7.  Select the private **Say Goodbye** button, and notice that it does not have resize handles. Additionally, in the **Properties** window, the properties of this button are grayed to indicate they cannot be modified.  
  
8.  If you are using [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)]:  
  
    1.  In **Solution Explorer**, right-click **Form1** in the **InheritanceTest** project and then choose **Delete**. In the message box that appears, click **OK** to confirm the deletion.  
  
    2.  Open the Program.cs file and change the line `Application.Run(new Form1());` to `Application.Run(new Form2());`.  
  
9. In **Solution Explorer**, right-click the **InheritanceTest** project and select **Set As Startup Project**.  
  
10. In **Solution Explorer**, right-click the **InheritanceTest** project and select **Properties**.  
  
11. In the **InheritanceTest** property pages, set the **Startup object** to be the inherited form (**Form2**).  
  
12. Press F5 to run the application, and observe the behavior of the inherited form.  
  
## Next Steps  
 Inheritance for user controls works in much the same way. Open a new class library project and add a user control. Place constituent controls on it and compile the project. Open another new class library project and add a reference to the compiled class library. Also, try adding an inherited control (through the **Add New Items** dialog box) to the project and using the **Inheritance Picker**. Add a user control, and change the `Inherits` (`:` in [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)]) statement. For more information, see [How to: Inherit Windows Forms](../../../../docs/framework/winforms/advanced/how-to-inherit-windows-forms.md).  
  
## See Also  
 [How to: Inherit Windows Forms](../../../../docs/framework/winforms/advanced/how-to-inherit-windows-forms.md)  
 [Windows Forms Visual Inheritance](../../../../docs/framework/winforms/advanced/windows-forms-visual-inheritance.md)  
 [Windows Forms](../../../../docs/framework/winforms/index.md)
