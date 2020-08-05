---
title: "User input validation"
description: Learn about several ways that you can use Windows Forms to validate user input in your applications.
ms.date: "07/16/2020"
ms.topic: overview
helpviewer_keywords: 
  - "Windows Forms, validating user input"
  - "validation [Windows Forms], Windows Forms user input"
  - "user input [Windows Forms], validating in Windows Forms"
  - "validating user input [Windows Forms], Windows Forms"
---
# Overview of how to validate user input (Windows Forms .NET)

When users enter data into your application, you may want to verify that the data is valid before your application uses it. You may require that certain text fields not be zero-length, that a field formatted as a telephone number, or that a string doesn't contain invalid characters. Windows Forms provides several ways for you to validate input in your application.

## MaskedTextBox Control

If you need to require users to enter data in a well-defined format, such as a telephone number or a part number, you can accomplish this quickly and with minimal code by using the <xref:System.Windows.Forms.MaskedTextBox> control. A *mask* is a string made up of characters from a masking language that specifies which characters can be entered at any given position in the text box. The control displays a set of prompts to the user. If the user types an incorrect entry, for example, the user types a letter when a digit is required, the control will automatically reject the input.

The masking language that is used by <xref:System.Windows.Forms.MaskedTextBox> is flexible. It allows you to specify required characters, optional characters, literal characters, such as hyphens and parentheses, currency characters, and date separators. The control also works well when bound to a data source. The <xref:System.Windows.Forms.Binding.Format> event on a data binding can be used to reformat incoming data to comply with the mask, and the <xref:System.Windows.Forms.Binding.Parse> event can be used to reformat outgoing data to comply with the specifications of the data field.

<!-- TODO -->
For more information, see [MaskedTextBox Control](./controls/maskedtextbox-control-windows-forms.md).

## Event-driven validation

If you want full programmatic control over validation, or need complex validation checks, you should use the validation events that are built into most Windows Forms controls. Each control that accepts free-form user input has a <xref:System.Windows.Forms.Control.Validating> event that will occur whenever the control requires data validation. In the <xref:System.Windows.Forms.Control.Validating> event-handling method, you can validate user input in several ways. For example, if you have a text box that must contain a postal code, you can do the validation in the following ways:

- If the postal code must belong to a specific group of zip codes, you can do a string comparison on the input to validate the data entered by the user. For example, if the postal code must be in the set `{10001, 10002, 10003}`, then you can use a string comparison to validate the data.

- If the postal code must be in a specific form, you can use regular expressions to validate the data entered by the user. For example, to validate the form `#####` or `#####-####`, you can use the regular expression `^(\d{5})(-\d{4})?$`. To validate the form `A#A #A#`, you can use the regular expression `[A-Z]\d[A-Z] \d[A-Z]\d`. For more information about regular expressions, see [.NET Framework Regular Expressions](../../standard/base-types/regular-expressions.md) and [Regular Expression Examples](../../standard/base-types/regular-expression-example-scanning-for-hrefs.md).

- If the postal code must be a valid United States Zip code, you could call a Zip code Web service to validate the data entered by the user.

The <xref:System.Windows.Forms.Control.Validating> event is supplied an object of type <xref:System.ComponentModel.CancelEventArgs>. If you determine that the control's data isn't valid, cancel the <xref:System.Windows.Forms.Control.Validating> event by setting this object's <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property to `true`. If you don't set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property, Windows Forms will assume that validation succeeded for that control and raise the <xref:System.Windows.Forms.Control.Validated> event.

For a code example that validates an email address in a <xref:System.Windows.Controls.TextBox>, see the <xref:System.Windows.Forms.Control.Validating> event reference.

### Event-driven validation data-bound controls

Validation is useful when you have bound your controls to a data source, such as a database table. By using validation, you can make sure that your control's data satisfies the format required by the data source, and that it doesn't contain any special characters such as quotation marks and back slashes that might be unsafe.

When you use data binding, the data in your control is synchronized with the data source during execution of the <xref:System.Windows.Forms.Control.Validating> event. If you cancel the <xref:System.Windows.Forms.Control.Validating> event, the data won't be synchronized with the data source.

> [!IMPORTANT]
> If you have custom validation that takes place after the <xref:System.Windows.Forms.Control.Validating> event, it won't affect the data binding. For example, if you have code in a <xref:System.Windows.Forms.Control.Validated> event that attempts to cancel the data binding, the data binding will still occur. In this case, to perform validation in the <xref:System.Windows.Forms.Control.Validated> event, change the control's [`Binding.DataSourceUpdateMode`](xref:System.Windows.Forms.Binding.DataSourceUpdateMode) property from <xref:System.Windows.Forms.DataSourceUpdateMode.OnValidation?displayProperty=nameWithType> to <xref:System.Windows.Forms.DataSourceUpdateMode.Never?displayProperty=nameWithType>, and add `your-control.DataBindings["field-name"].WriteValue()` to your validation code.

## Implicit and explicit validation

So when does a control's data get validated? This is up to you, the developer. You can use either implicit or explicit validation, depending on the needs of your application.

### Implicit validation

The implicit validation approach validates data as the user enters it. Validate the data by reading the keys as they're pressed, or more commonly whenever the user takes the input focus away from the control. This approach is useful when you want to give the user immediate feedback about the data as they're working.

If you want to use implicit validation for a control, you must set that control's <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property to <xref:System.Windows.Forms.AutoValidate.EnablePreventFocusChange> or <xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange>. If you cancel the <xref:System.Windows.Forms.Control.Validating> event, the behavior of the control will be determined by what value you assigned to <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A>. If you assigned <xref:System.Windows.Forms.AutoValidate.EnablePreventFocusChange>, canceling the event will cause the <xref:System.Windows.Forms.Control.Validated> event not to occur. Input focus will remain on the current control until the user changes the data to a valid format. If you assigned <xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange>, the <xref:System.Windows.Forms.Control.Validated> event won't occur when you cancel the event, but focus will still change to the next control.

Assigning <xref:System.Windows.Forms.AutoValidate.Disable> to the <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property prevents implicit validation altogether. To validate your controls, you'll have to use explicit validation.

### Explicit validation

The explicit validation approach validates data at one time. You can validate the data in response to a user action, such as clicking a **Save** button or a **Next** link. When the user action occurs, you can trigger explicit validation in one of the following ways:

- Call <xref:System.Windows.Forms.ContainerControl.Validate%2A> to validate the last control to have lost focus.
- Call <xref:System.Windows.Forms.ContainerControl.ValidateChildren%2A> to validate all child controls in a form or container control.
- Call a custom method to validate the data in the controls manually.

### Default implicit validation behavior for controls

Different Windows Forms controls have different defaults for their <xref:System.Windows.Forms.ContainerControl.AutoValidate%2A> property. The following table shows the most common controls and their defaults.

| Control                                        | Default Validation Behavior                                     |
|------------------------------------------------|-----------------------------------------------------------------|
| <xref:System.Windows.Forms.ContainerControl>   | <xref:System.Windows.Forms.AutoValidate.Inherit>                |
| <xref:System.Windows.Forms.Form>               | <xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange> |
| <xref:System.Windows.Forms.PropertyGrid>       | Property not exposed in Visual Studio                           |
| <xref:System.Windows.Forms.ToolStripContainer> | Property not exposed in Visual Studio                           |
| <xref:System.Windows.Forms.SplitContainer>     | <xref:System.Windows.Forms.AutoValidate.Inherit>                |
| <xref:System.Windows.Forms.UserControl>        | <xref:System.Windows.Forms.AutoValidate.EnableAllowFocusChange> |

## Closing the form and overriding Validation

When a control maintains focus because the data it contains is invalid, it's impossible to close the parent form in one of the usual ways:

- By clicking the **Close** button.
- By selecting the **System** > **Close** menu.
- By calling the <xref:System.Windows.Forms.Form.Close%2A> method programmatically.

However, in some cases, you might want to let the user close the form regardless of whether the values in the controls are valid. You can override validation and close a form that still contains invalid data by creating a handler for the form's <xref:System.Windows.Forms.Form.FormClosing> event. In the event, set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property to `false`. This forces the form to close. For more information and an example, see <xref:System.Windows.Forms.Form.FormClosing?displayProperty=nameWithType>.

> [!NOTE]
> If you force the form to close in this manner, any data in the form's controls that has not already been saved is lost. In addition, modal forms don't validate the contents of controls when they're closed. You can still use control validation to lock focus to a control, but you don't have to be concerned about the behavior associated with closing the form.

## See also

- <xref:System.Windows.Forms.Control.Validating?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Form.FormClosing?displayProperty=nameWithType>
- <xref:System.Windows.Forms.FormClosingEventArgs?displayProperty=nameWithType>
- [Using keyboard events (Windows Forms .NET)](events.md)
- [MaskedTextBox Control](./controls/maskedtextbox-control-windows-forms.md)
