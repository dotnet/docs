---
title: "How to: Use Lambda Expressions Outside LINQ - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "lambda expressions [C#], outside LINQ"
ms.assetid: 2b519274-6ee4-4455-ab2e-aed67dbfd07c
---
# How to: Use Lambda Expressions Outside LINQ (C# Programming Guide)
Lambda expressions are not limited to [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] queries. You can use them anywhere a delegate value is expected, that is, wherever an anonymous method can be used. The following example shows how to use a lambda expression in a Windows Forms event handler. Notice that the types of the inputs (<xref:System.Object> and <xref:System.Windows.Forms.MouseEventArgs>) are inferred by the compiler and do not have to be explicitly given in the lambda input parameters.  
  
## Example  
  
```csharp  
public partial class Form1 : Form  
{  
    public Form1()  
    {  
        InitializeComponent();  
        // Use a lambda expression to define an event handler.  
       this.Click += (s, e) => { MessageBox.Show(((MouseEventArgs)e).Location.ToString());};  
    }  
}  
```  
  
## See Also

- [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)  
- [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md)  
- [Language Integrated Query (LINQ))](../../../csharp/programming-guide/concepts/linq/index.md)
