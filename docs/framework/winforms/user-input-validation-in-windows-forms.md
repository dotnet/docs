---
title: "User Input Validation in Windows Forms"
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
  - "Windows Forms, validating user input"
  - "validation [Windows Forms], Windows Forms user input"
  - "user input [Windows Forms], validating in Windows Forms"
  - "validating user input [Windows Forms], Windows Forms"
ms.assetid: 4ec07681-1dee-4bf9-be5e-718f635a33a1
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# User Input Validation in Windows Forms
When users enter data into your application, you may want to verify that the data is valid before your application uses it. You may require that certain text fields not be zero-length, that a field be formatted as a telephone number or other type of well-formed data, or that a string not contain any unsafe characters that could be used to compromise the security of a database. Windows Forms provides several ways for you to validate input in your application.  
  
## Validation with the MaskedTextBox Control  
 If you need to require users to enter data in a well-defined format, such as a telephone number or a part number, you can accomplish this quickly and with minimal code by using the <xref:System.Windows.Forms.MaskedTextBox> control. A *mask* is a string made up of characters from a masking language that specifies which characters can be entered at any given position in the text box. The control displays a set of prompts to the user. If the user types an incorrect entry, for example, the user types a letter when a digit is required, the control will automatically reject the input.  
  
 The masking language that is used by <xref:System.Windows.Forms.MaskedTextBox> is very flexible. It allows you to specify required characters, optional characters, literal characters, such as hyphens and parentheses, currency characters, and date separators. The control also works well when bound to a data source. The <xref:System.Windows.Forms.Binding.Format> event on a data binding can be used to reformat incoming data to comply with the mask, and the <xref:System.Windows.Forms.Binding.Parse> event can be used to reformat outgoing data to comply with the specifications of the data field.  
  
 For more information, see [MaskedTextBox Control](../../../docs/framework/winforms/controls/maskedtextbox-control-windows-forms.md).  
  
## Event-Driven Validation  
 If you want full programmatic control over validation, or need to perform complex validation checks, you should use the validation events built into most Windows Forms controls. Each control that accepts free-form user input has a <xref:System.Windows.Forms.Control.Validating> event that will occur whenever the control requires data validation. In the <xref:System.Windows.Forms.Control.Validating> event-handling method, you can validate user input in several ways. For example, if you have a text box that must contain a postal code, you can perform the validation in the following ways:  
  
-   If the postal code must belong to a specific group of zip codes, you can perform a string comparison on the input to validate the data entered by the user. For example, if the postal code must be in the set {10001, 10002, 10003}, then you can use a string comparison to validate the data.  
  
-   If the postal code must be in a specific form you can use regular expressions to validate the data entered by the user. For example, to validate the form `#####` or `#####-####`, you can use the regular expression `^(\d{5})(-\d{4})?$`. To validate the form `A#A #A#`, you can use the regular expression `[A-Z]\d[A-Z] \d[A-Z]\d`. For more information about regular expressions, see [.NET Framework Regular Expressions](../../../docs/standard/base-types/regular-expressions.md) and [Regular Expression Examples](../../../docs/standard/base-types/regular-expression-examples.md).  
  
-   If the postal code must be a valid United States Zip code, you could call a Zip code Web service to validate the data entered by the user.  
  
 The <xref:System.Windows.Forms.Control.Validating> event is supplied an object of type <xref:System.ComponentModel.CancelEventArgs>. If you determine that the control's data is not valid, you can cancel the <xref:System.Windows.Forms.Control.Validating> event by setting this object's <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property to `true`. If you do not set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property, Windows Forms will assume that validation succeeded for that control, and raise the <xref:System.Windows.Forms.Control.Validated> event.  
  
 For a code example that validates an email address in a <xref:System.Windows.Controls.TextBox>, see <xref:System.Windows.Forms.Control.Validating>.  
  
### Data Binding and Event-Driven Validation  
 Validation is very useful when you have bound your controls to a data source, such as a database table. By using validation, you can make sure that your control's data satisfies the format required by the data source, and that it does not contain any special characters such as quotation marks and back slashes that might be unsafe.  
  
 When you use data binding, the data in your control is synchronized with the data source during execution of the <xref:System.Windows.Forms.Control.Validating> event. If you cancel the <xref:System.Windows.Forms.Control.Validating> event, the data will not be synchronized with the data source.  
  
> [!IMPORTANT]
>  If you have custom validation that takes place after the <xref:System.Windows.Forms.Control.Validating> event, it will not affect the data binding. For example, if you have code in a <xref:System.Windows.Forms.Control.Validated> event that attempts to cancel the data binding, the data binding will still occur. In this case, to perform validation in the <xref:System.Windows.Forms.Control.Validated> event, change the control's **Data Source Update Mode** property (**under (Databindings)**\\**(Advanced)**) from **OnValidation** to **Never**, and add *Control*`.DataBindings["`*\<YOURFIELD>*`"].WriteValue()` to your validation code.  
  
### Implicit and Explicit Validation  
 So when does a control's data get validated? This is up to you, the developer. You can use either implicit or explicit validation, depending on the needs of your application.  
  
#### Implicit Validation  
 The implicit validation approach validates data as the user enters it. You can validate the data as the data is entered in a control by reading the keys as they are pressed, or more commonly whenever the user takes the input focus away from one control and moves to the next. This approach is useful when you want to give the user immediate feedback about the data as they are working.  
  
 If you want to use implicit validation for a control, you must set that control's <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property to `true`. If you cancel the <xref:System.Windows.Forms.Control.Validating> event, the behavior of the control will be determined by what value that you assigned to <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A>. If you assigned <xref:System.Windows.Forms.AutoValidate.EnablePreventFocusChange>, canceling the event will cause the <xref:System.Windows.Forms.Control.Validated> event not to occur. Input focus will remain on the current control until the user changes the data to a valid input. If you assigned <xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange>, the <xref:System.Windows.Forms.Control.Validated> event will not occur when you cancel the event, but focus will still change to the next control.  
  
 Assigning <xref:System.Windows.Forms.AutoValidate.Disable> to the <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property prevents implicit validation altogether. To validate your controls, you will have to use explicit validation.  
  
#### Explicit Validation  
 The explicit validation approach validates data at one time. You can validate the data in response to a user action, such as clicking a Save button or a Next link. When the user action occurs, you can trigger explicit validation in one of the following ways:  
  
-   Call <xref:System.Windows.Forms.ContainerControl.Validate%2A> to validate the last control to have lost focus.  
  
-   Call <xref:System.Windows.Forms.ContainerControl.ValidateChildren%2A> to validate all child controls in a form or container control.  
  
-   Call a custom method to validate the data in the controls manually.  
  
#### Default Implicit Validation Behavior for Windows Forms Controls  
 Different Windows Forms controls have different defaults for their <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property. The following table shows the most common controls and their defaults.  
  
|Control|Default Validation Behavior|  
|-------------|---------------------------------|  
|<xref:System.Windows.Forms.ContainerControl>|<xref:System.Windows.Forms.AutoValidate.Inherit>|  
|<xref:System.Windows.Forms.Form>|<xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange>|  
|<xref:System.Windows.Forms.PropertyGrid>|Property not exposed in Visual Studio|  
|<xref:System.Windows.Forms.ToolStripContainer>|Property not exposed in Visual Studio|  
|<xref:System.Windows.Forms.SplitContainer>|<xref:System.Windows.Forms.AutoValidate.Inherit>|  
|<xref:System.Windows.Forms.UserControl>|<xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange>|  
  
## Closing the Form and Overriding Validation  
 When a control maintains focus because the data it contains is invalid, it is impossible to close the parent form in one of the usual ways:  
  
-   By clicking the **Close** button.  
  
-   By selecting **Close** in the **System** menu.  
  
-   By calling the <xref:System.Windows.Forms.Form.Close%2A> method programmatically.  
  
 However, in some cases, you might want to let the user close the form regardless of whether the values in the controls are valid. You can override validation and close a form that still contains invalid data by creating a handler for the form's <xref:System.Windows.Forms.Form.Closing> event. In the event, set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property to `false`. This forces the form to close. For more information and an example, see <xref:System.Windows.Forms.Form.Closing?displayProperty=nameWithType>.  
  
> [!NOTE]
>  If you force the form to close in this manner, any data in the form's controls that has not already been saved is lost. In addition, modal forms do not validate the contents of controls when they are closed. You can still use control validation to lock focus to a control, but you do not have to be concerned about the behavior associated with closing the form.  
  
## See Also  
 <xref:System.Windows.Forms.Control.Validating?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Form.Closing?displayProperty=nameWithType>  
 <xref:System.ComponentModel.CancelEventArgs?displayProperty=nameWithType>  
 [MaskedTextBox Control](../../../docs/framework/winforms/controls/maskedtextbox-control-windows-forms.md)  
 [Regular Expression Examples](../../../docs/standard/base-types/regular-expression-examples.md)
