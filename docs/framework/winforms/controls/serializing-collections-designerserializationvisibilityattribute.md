---
title: "Walkthrough: Serializing Collections of Standard Types with the DesignerSerializationVisibilityAttribute"
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
  - "cpp"
helpviewer_keywords: 
  - "serialization [Windows Forms], collections"
  - "standard types [Windows Forms], collections"
  - "collections [Windows Forms], serializing"
  - "collections [Windows Forms], standard types"
ms.assetid: 020c9df4-fdc5-4dae-815a-963ecae5668c
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Serializing Collections of Standard Types with the DesignerSerializationVisibilityAttribute
Your custom controls will sometimes expose a collection as a property. This walkthrough demonstrates how to use the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute> class to control how a collection is serialized at design time. Applying the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute.Content> value to your collection property ensures that the property will be serialized.  
  
 To copy the code in this topic as a single listing, see [How to: Serialize Collections of Standard Types with the DesignerSerializationVisibilityAttribute](http://msdn.microsoft.com/library/7829fcdd-8205-405f-8231-a1282a9835c9).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Sufficient permissions to be able to create and run Windows Forms application projects on the computer where Visual Studio is installed.  
  
## Creating a Control That Has a Serializable Collection  
 The first step is to create a control that has a serializable collection as a property. You can edit the contents of this collection using the **Collection Editor**, which you can access from the **Properties** window.  
  
#### To create a control with a serializable collection  
  
1.  Create a Windows Control Library project called `SerializationDemoControlLib`. For more information, see [Windows Control Library Template](http://msdn.microsoft.com/library/722f4e2d-1310-4ed5-8f33-593337ab66b4).  
  
2.  Rename `UserControl1` to `SerializationDemoControl`. For more information, see [How to: Rename Identifiers](http://msdn.microsoft.com/library/2430f732-2b70-4516-8cf6-a7bb71cc9724).  
  
3.  In the **Properties** window, set the value of the <xref:System.Windows.Forms.Padding.All%2A?displayProperty=nameWithType> property to `10`.  
  
4.  Place a <xref:System.Windows.Forms.TextBox> control in the `SerializationDemoControl`.  
  
5.  Select the <xref:System.Windows.Forms.TextBox> control. In the **Properties** window, set the following properties.  
  
    |Property|Change to|  
    |--------------|---------------|  
    |**Multiline**|`true`|  
    |**Dock**|<xref:System.Windows.Forms.DockStyle.Fill>|  
    |**ScrollBars**|<xref:System.Windows.Forms.ScrollBars.Vertical>|  
    |**ReadOnly**|`true`|  
  
6.  In the **Code Editor**, declare a string array field named `stringsValue` in `SerializationDemoControl`.  
  
     [!code-cpp[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/cpp/form1.cpp#4)]
     [!code-csharp[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/CS/form1.cs#4)]
     [!code-vb[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/VB/form1.vb#4)]  
  
7.  Define the `Strings` property on the `SerializationDemoControl`.  
  
> [!NOTE]
>  The <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute.Content> value is used to enable serialization of the collection.  
  
 [!code-cpp[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/cpp/form1.cpp#5)]
 [!code-csharp[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/CS/form1.cs#5)]
 [!code-vb[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/VB/form1.vb#5)]  
  
1.  Press F5 to build the project and run your control in the **UserControl Test Container**.  
  
2.  Find the `Strings` property in the <xref:System.Windows.Forms.PropertyGrid> of the **UserControl Test Container**. Click the `Strings` property, then click the ellipsis (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button to open the **String Collection Editor**.  
  
3.  Enter several strings in the **String Collection Editor**. Separate them by pressing the ENTER key at the end of each string. Click **OK** when you are finished entering strings.  
  
> [!NOTE]
>  The strings you typed appear in the <xref:System.Windows.Forms.TextBox> of the `SerializationDemoControl`.  
  
## Serializing a Collection Property  
 To test the serialization behavior of your control, you will place it on a form and change the contents of the collection with the **Collection Editor**. You can see the serialized collection state by looking at a special designer file, into which the **Windows Forms Designer** emits code.  
  
#### To serialize a collection  
  
1.  Add a Windows Application project to the solution. Name the project `SerializationDemoControlTest`.  
  
2.  In the **Toolbox**, find the tab named **SerializationDemoControlLib Components**. In this tab, you will find the `SerializationDemoControl`. For more information, see [Walkthrough: Automatically Populating the Toolbox with Custom Components](../../../../docs/framework/winforms/controls/walkthrough-automatically-populating-the-toolbox-with-custom-components.md).  
  
3.  Place a `SerializationDemoControl` on your form.  
  
4.  Find the `Strings` property in the **Properties** window. Click the `Strings` property, then click the ellipsis (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button to open the **String Collection Editor**.  
  
5.  Type several strings in the **String Collection Editor**. Separate them by pressing the ENTER key at the end of each string. Click **OK** when you are finished entering strings.  
  
> [!NOTE]
>  The strings you typed appear in the <xref:System.Windows.Forms.TextBox> of the `SerializationDemoControl`.  
  
1.  In **Solution Explorer**, click the **Show All Files** button.  
  
2.  Open the **Form1** node. Beneath it is a file called **Form1.Designer.cs** or **Form1.Designer.vb**. This is the file into which the **Windows Forms Designer** emits code representing the design-time state of your form and its child controls. Open this file in the **Code Editor**.  
  
3.  Open the region called **Windows Form Designer generated code** and find the section labeled **serializationDemoControl1**. Beneath this label is the code representing the serialized state of your control. The strings you typed in step 5 appear in an assignment to the `Strings` property. The following code examples in C# and Visual Basic, show code similar to what you will see if you typed the strings "red", "orange", and "yellow".  
  
    ```csharp  
    this.serializationDemoControl1.Strings = new string[] {  
            "red",  
            "orange",  
            "yellow"};  
    ```  
    
    ```vb  
    Me.serializationDemoControl1.Strings = New String() {"red", "orange", "yellow"}  
    ```
  
4.  In the **Code Editor**, change the value of the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute> on the `Strings` property to <xref:System.ComponentModel.DesignerSerializationVisibility.Hidden>.  
  
    ```csharp  
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]  
    ```  
    ```vb  
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _  
    ```  
  
5. Rebuild the solution and repeat steps 3 and 4.  
  
> [!NOTE]
>  In this case, the **Windows Forms Designer** emits no assignment to the `Strings` property.  
  
## Next Steps  
 Once you know how to serialize a collection of standard types, consider integrating your custom controls more deeply into the design-time environment. The following topics describe how to enhance the design-time integration of your custom controls:  
  
-   [Design-Time Architecture](http://msdn.microsoft.com/library/4881917b-628f-4689-b872-472e4f8a4e3a)  
  
-   [Attributes in Windows Forms Controls](../../../../docs/framework/winforms/controls/attributes-in-windows-forms-controls.md)  
  
-   [Designer Serialization Overview](http://msdn.microsoft.com/library/c342635a-aa5f-4281-915b-b013738af15a)  
  
-   [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](../../../../docs/framework/winforms/controls/creating-a-wf-control-design-time-features.md)  
  
## See Also  
 <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute>  
 [Designer Serialization Overview](http://msdn.microsoft.com/library/c342635a-aa5f-4281-915b-b013738af15a)  
 [How to: Serialize Collections of Standard Types with the DesignerSerializationVisibilityAttribute](http://msdn.microsoft.com/library/7829fcdd-8205-405f-8231-a1282a9835c9)  
 [Walkthrough: Automatically Populating the Toolbox with Custom Components](../../../../docs/framework/winforms/controls/walkthrough-automatically-populating-the-toolbox-with-custom-components.md)
