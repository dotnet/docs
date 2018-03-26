---
title: "How to: Develop a Simple Windows Forms Control"
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
  - "controls [Windows Forms]"
  - "custom controls [Windows Forms], creating simple controls using code"
  - "Control class [Windows Forms], Windows Forms"
ms.assetid: 86cbe435-45b7-4cb4-9b5a-47418369758d
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Develop a Simple Windows Forms Control
This section walks you through the key steps for authoring a custom Windows Forms control. The simple control developed in this walkthrough allows the alignment of its <xref:System.Windows.Forms.Control.Text%2A> property to be changed. It does not raise or handle events.  
  
### To create a simple custom control  
  
1.  Define a class that derives from <xref:System.Windows.Forms.Control?displayProperty=nameWithType>.  
  
    ```vb  
    Public Class FirstControl  
       Inherits Control  
  
    End Class  
    ```  
  
    ```csharp  
    public class FirstControl:Control{}  
    ```  
  
2.  Define properties. (You are not required to define properties, because a control inherits many properties from the <xref:System.Windows.Forms.Control> class, but most custom controls generally do define additional properties.) The following code fragment defines a property named `TextAlignment` that `FirstControl` uses to format the display of the <xref:System.Windows.Forms.Control.Text%2A> property inherited from <xref:System.Windows.Forms.Control>. For more information about defining properties, see [Properties Overview](http://msdn.microsoft.com/library/8f1a1ff1-0f05-40e0-bfdf-80de8fff7d52).  
  
     [!code-csharp[System.Windows.Forms.FirstControl#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/CS/FirstControl.cs#3)]
     [!code-vb[System.Windows.Forms.FirstControl#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/VB/FirstControl.vb#3)]  
  
     When you set a property that changes the visual display of the control, you must invoke the <xref:System.Windows.Forms.Control.Invalidate%2A> method to redraw the control. <xref:System.Windows.Forms.Control.Invalidate%2A> is defined in the base class <xref:System.Windows.Forms.Control>.  
  
3.  Override the protected <xref:System.Windows.Forms.Control.OnPaint%2A> method inherited from <xref:System.Windows.Forms.Control> to provide rendering logic to your control. If you do not override <xref:System.Windows.Forms.Control.OnPaint%2A>, your control will not be able to draw itself. In the following code fragment, the <xref:System.Windows.Forms.Control.OnPaint%2A> method displays the <xref:System.Windows.Forms.Control.Text%2A> property inherited from <xref:System.Windows.Forms.Control> with the alignment specified by the `alignmentValue` field.  
  
     [!code-csharp[System.Windows.Forms.FirstControl#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/CS/FirstControl.cs#4)]
     [!code-vb[System.Windows.Forms.FirstControl#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/VB/FirstControl.vb#4)]  
  
4.  Provide attributes for your control. Attributes enable a visual designer to display your control and its properties and events appropriately at design time. The following code fragment applies attributes to the `TextAlignment` property. In a designer such as Visual Studio, the <xref:System.ComponentModel.CategoryAttribute.Category%2A> attribute (shown in the code fragment) causes the property to be displayed under a logical category. The <xref:System.ComponentModel.DescriptionAttribute.Description%2A> attribute causes a descriptive string to be displayed at the bottom of the **Properties** window when the `TextAlignment` property is selected. For more information about attributes, see [Design-Time Attributes for Components](http://msdn.microsoft.com/library/12050fe3-9327-4509-9e21-4ee2494b95c3).  
  
     [!code-csharp[System.Windows.Forms.FirstControl#5](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/CS/FirstControl.cs#5)]
     [!code-vb[System.Windows.Forms.FirstControl#5](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/VB/FirstControl.vb#5)]  
  
5.  (optional) Provide resources for your control. You can provide a resource, such as a bitmap, for your control by using a compiler option (`/res` for C#) to package resources with your control. At run time, the resource can be retrieved using the methods of the <xref:System.Resources.ResourceManager> class. For more information about creating and using resources, see the [Resources in Desktop Apps](../../../../docs/framework/resources/index.md).  
  
6.  Compile and deploy your control. To compile and deploy `FirstControl,` execute the following steps:  
  
    1.  Save the code in the following sample to a source file (such as FirstControl.cs or FirstControl.vb).  
  
    2.  Compile the source code into an assembly and save it in your application's directory. To accomplish this, execute the following command from the directory that contains the source file.  
  
        ```console  
        vbc -t:library -out:[path to your application's directory]/CustomWinControls.dll -r:System.dll -r:System.Windows.Forms.dll -r:System.Drawing.dll FirstControl.vb  
        ```  
  
        ```console 
        csc -t:library -out:[path to your application's directory]/CustomWinControls.dll -r:System.dll -r:System.Windows.Forms.dll -r:System.Drawing.dll FirstControl.cs  
        ```  
  
         The `/t:library` compiler option tells the compiler that the assembly you are creating is a library (and not an executable). The `/out` option specifies the path and name of the assembly. The`/r` option provides the name of the assemblies that are referenced by your code. In this example, you create a private assembly that only your applications can use. Hence, you have to save it in your application's directory. For more information about packaging and deploying a control for distribution, see [Deployment](../../../../docs/framework/deployment/index.md).  
  
 The following sample shows the code for `FirstControl`. The control is enclosed in the namespace `CustomWinControls`. A namespace provides a logical grouping of related types. You can create your control in a new or existing namespace. In C#, the `using` declaration (in Visual Basic, `Imports`) allows types to be accessed from a namespace without using the fully qualified name of the type. In the following example, the `using` declaration allows code to access the class <xref:System.Windows.Forms.Control> from <xref:System.Windows.Forms?displayProperty=nameWithType> as simply <xref:System.Windows.Forms.Control> instead of having to use the fully qualified name <xref:System.Windows.Forms.Control?displayProperty=nameWithType>.  
  
 [!code-csharp[System.Windows.Forms.FirstControl#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/CS/FirstControl.cs#1)]
 [!code-vb[System.Windows.Forms.FirstControl#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/VB/FirstControl.vb#1)]  
  
## Using the Custom Control on a Form  
 The following example shows a simple form that uses `FirstControl`. It creates three instances of `FirstControl`, each with a different value for the `TextAlignment` property.  
  
#### To compile and run this sample  
  
1.  Save the code in the following example to a source file (SimpleForm.cs or SimpleForms.vb).  
  
2.  Compile the source code into an executable assembly by executing the following command from the directory that contains the source file.  
  
    ```console  
    vbc -r:CustomWinControls.dll -r:System.dll -r:System.Windows.Forms.dll -r:System.Drawing.dll SimpleForm.vb  
    ```  
  
    ```console 
    csc -r:CustomWinControls.dll -r:System.dll -r:System.Windows.Forms.dll -r:System.Drawing.dll SimpleForm.cs  
    ```  
  
     CustomWinControls.dll is the assembly that contains the class `FirstControl`. This assembly must be in the same directory as the source file for the form that accesses it (SimpleForm.cs or SimpleForms.vb).  
  
3.  Execute SimpleForm.exe using the following command.  
  
    ```console
    SimpleForm  
    ```  
  
 [!code-csharp[System.Windows.Forms.FirstControl#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/CS/SimpleForm.cs#10)]
 [!code-vb[System.Windows.Forms.FirstControl#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FirstControl/VB/SimpleForm.vb#10)]  
  
## See Also  
 [Properties in Windows Forms Controls](../../../../docs/framework/winforms/controls/properties-in-windows-forms-controls.md)  
 [Events in Windows Forms Controls](../../../../docs/framework/winforms/controls/events-in-windows-forms-controls.md)
