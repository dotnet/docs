---
title: "How to: Set the Input Mask"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "net.ComponentModel.MaskPropertyEditor"
helpviewer_keywords: 
  - "MaskedTextBox control [Windows Forms]"
ms.assetid: 779b3a12-cd74-4e58-b46e-04983bda5b2c
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Input Mask
The masked text box control is an enhanced text box control that supports a declarative syntax for accepting or rejecting user input. By setting the Mask property, you can specify the allowable user input without writing any custom validation logic in your application. For more information, see the Remarks section of the <xref:System.Windows.Forms.MaskedTextBox> class.  
  
## Setting the Mask Property Manually  
 If you are familiar with the characters that the Mask property supports, you can enter it manually. For a summary of the characters that the Mask property supports, see the Remarks section of the <xref:System.Windows.Forms.MaskedTextBox.Mask%2A> property.  
  
#### To set the Mask property manually  
  
1.  In **Design** view, select a <xref:System.Windows.Forms.MaskedTextBox>.  
  
2.  In the **Properties** window, locate the <xref:System.Windows.Forms.MaskedTextBox.Mask%2A> property.  
  
3.  Type the mask that you want. For example, type `###`.  
  
## Using the Input Mask Dialog Box  
 The Input Mask dialog box provides some predefined input masks. You can also change the predefined masks or enter your own mask manually.  
  
#### To open the Input Mask dialog box  
  
1.  In **Design** view, select a <xref:System.Windows.Forms.MaskedTextBox>.  
  
    1.  Click the smart tag to open the **MaskedTextBox Tasks** panel.  
  
    2.  Click **Set Mask**.  
  
     \- or -  
  
    1.  In the **Properties** window, select the <xref:System.Windows.Forms.MaskedTextBox.Mask%2A> property.  
  
    2.  Click the ellipsis button in the property value column.  
  
     The **Input Mask** dialog box appears.  
  
#### To use the Input Mask dialog box  
  
1.  (Optional) Click one of the predefined masks in the list.  
  
2.  (Optional) Edit the predefined mask in the **Mask** box.  
  
3.  (Optional) Type a new mask in the **Mask** box. That is, you do not have to use one of the predefined masks.  
  
    > [!NOTE]
    >  The Preview box displays the characters that the user sees in the <xref:System.Windows.Forms.MaskedTextBox>. These characters are a guide to help the user enter the data correctly.  
  
4.  Select or clear the **Use ValidatingType** check box. The **Use ValidatingType** check box specifies whether a data type is used to verify the data input by the user. For more information, see the <xref:System.Windows.Forms.MaskedTextBox.ValidatingType%2A> property.  
  
5.  Click **OK**.  
  
     The mask is entered in the **Mask** property in the **Properties** window.  
  
## See Also  
 [Walkthrough: Working with the MaskedTextBox Control](../../../../docs/framework/winforms/controls/walkthrough-working-with-the-maskedtextbox-control.md)
