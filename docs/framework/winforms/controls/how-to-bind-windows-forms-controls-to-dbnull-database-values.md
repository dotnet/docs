---
title: "How to: Bind Windows Forms Controls to DBNull Database Values"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "BindingSource component [Windows Forms], binding to DBNull values"
  - "examples [Windows Forms], BindingSource component"
  - "controls [Windows Forms], binding to DBNull values"
ms.assetid: 96494e6f-5f40-4f83-af97-bbd7192c2af8
---
# How to: Bind Windows Forms Controls to DBNull Database Values
When you bind Windows Forms controls to a data source and the data source returns a <xref:System.DBNull> value, you can substitute an appropriate value without handling, formatting, or parsing events. The <xref:System.Windows.Forms.Binding.NullValue%2A> property will convert <xref:System.DBNull> to a specified object when formatting or parsing the data source values.  
  
## Example  
 The following example demonstrates how to bind a <xref:System.DBNull> value in two different situations. The first demonstrates how to set the <xref:System.Windows.Forms.Binding.NullValue%2A> for a string property; the second demonstrates how to set the <xref:System.Windows.Forms.Binding.NullValue%2A> for an image property.  
  
 [!code-csharp[System.Windows.Forms.BindingDBNull#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BindingDBNull/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.BindingDBNull#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BindingDBNull/VB/form1.vb#1)]  
  
 The types of the bound property and the <xref:System.Windows.Forms.Binding.NullValue%2A> property must be the same or an error will result, and no further <xref:System.Windows.Forms.Binding.NullValue%2A> values will be processed. In this situation, an exception will not be thrown.  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- [BindingSource Component](bindingsource-component.md)
- [How to: Handle Errors and Exceptions that Occur with Databinding](how-to-handle-errors-and-exceptions-that-occur-with-databinding.md)
- [How to: Bind a Windows Forms Control to a Type](how-to-bind-a-windows-forms-control-to-a-type.md)
