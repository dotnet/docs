---
title: "ErrorProvider Component Overview (Windows Forms)"
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
  - "ErrorProvider"
helpviewer_keywords: 
  - "errors [Windows Forms], displaying to users"
  - "error messages [Windows Forms], displaying"
  - "ErrorProvider component [Windows Forms], about ErrorProvider component"
ms.assetid: ced189f2-b5c8-46a7-a6f1-37f5af95dc99
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ErrorProvider Component Overview (Windows Forms)
The Windows Forms [ErrorProvider](../../../../docs/framework/winforms/controls/errorprovider-component-windows-forms.md) component is used to validate user input on a form or control. It is typically used in conjunction with validating user input on a form, or displaying errors within a dataset. An error provider is a better alternative than displaying an error message in a message box, because once a message box is dismissed, the error message is no longer visible. The <xref:System.Windows.Forms.ErrorProvider> component displays an error icon (![ErrorProvider icon](../../../../docs/framework/winforms/controls/media/vberrorprovidericon.gif "vbErrorProviderIcon")) next to the relevant control, such as a text box; when the user positions the mouse pointer over the error icon, a ToolTip appears, showing the error message string.  
  
## Key Properties  
 The <xref:System.Windows.Forms.ErrorProvider> component's key properties are <xref:System.Windows.Forms.ErrorProvider.DataSource%2A>, <xref:System.Windows.Forms.ErrorProvider.ContainerControl%2A>, and <xref:System.Windows.Forms.ErrorProvider.Icon%2A>. When using <xref:System.Windows.Forms.ErrorProvider> component with data-bound controls, the <xref:System.Windows.Forms.ErrorProvider.ContainerControl%2A> property must be set to the appropriate container (usually the Windows Form) in order for the component to display an error icon on the form. When the component is added in the designer, the <xref:System.Windows.Forms.ErrorProvider.ContainerControl%2A> property is set to the containing form; if you add the control in code, you must set it yourself.  
  
 The <xref:System.Windows.Forms.ErrorProvider.Icon%2A> property can be set to a custom error icon instead of the default. When the <xref:System.Windows.Forms.ErrorProvider.DataSource%2A> property is set, the <xref:System.Windows.Forms.ErrorProvider> component can display error messages for a dataset. The key method of the <xref:System.Windows.Forms.ErrorProvider> component is the <xref:System.Windows.Forms.ErrorProvider.SetError%2A> method, which specifies the error message string and where the error icon should appear.  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.ErrorProvider> component does not provide built-in support for accessibility clients. To make your application accessible when using this component, you must provide an additional, accessible feedback mechanism.  
  
## See Also  
 <xref:System.Windows.Forms.ErrorProvider>  
 [How to: View Errors Within a DataSet with the Windows Forms ErrorProvider Component](../../../../docs/framework/winforms/controls/view-errors-within-a-dataset-with-wf-errorprovider-component.md)  
 [How to: Display Error Icons for Form Validation with the Windows Forms ErrorProvider Component](../../../../docs/framework/winforms/controls/display-error-icons-for-form-validation-with-wf-errorprovider.md)
