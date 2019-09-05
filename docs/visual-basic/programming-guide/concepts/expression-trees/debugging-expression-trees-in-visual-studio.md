---
title: "Debugging Expression Trees in Visual Studio (Visual Basic)"
ms.date: 07/20/2015
ms.assetid: 492cc28f-b7a2-4c47-b582-b3c437b8a5d5
---
# Debugging Expression Trees in Visual Studio (Visual Basic)
You can analyze the structure and content of expression trees when you debug your applications. To get a quick overview of the expression tree structure, you can use the `DebugView` property, which represents expression trees [using a special syntax](debugview-syntax.md). (Note that `DebugView` is available only in debug mode.)  

![DebugView of expression tree within the Visual Studio debugger](media/debugging-expression-trees-in-visual-studio/debugview_vb.png)

Since `DebugView` is a string, you can use the [built-in Text Visualizer](https://docs.microsoft.com/visualstudio/debugger/view-strings-visualizer#open-a-string-visualizer) to view it across multiple lines, by selecting **Text Visualizer** from the magnifying glass icon next to the `DebugView` label.

 ![Text Visualizer applied to results of `DebugView`](media/debugging-expression-trees-in-visual-studio/string_visualizer_vb.png)

Alternatively, you can install and use [a custom visualizer](https://docs.microsoft.com/visualstudio/debugger/create-custom-visualizers-of-data) for expression trees, such as:

- [Readable Expressions](https://github.com/agileobjects/ReadableExpressions) ([MIT license](https://github.com/agileobjects/ReadableExpressions/blob/master/LICENSE.md), available at the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=vs-publisher-1232914.ReadableExpressionsVisualizers)), renders the expression tree as C# code:

  ![Readable Expressions visualizer](media/debugging-expression-trees-in-visual-studio/readable_expressions_visualizer.png)

- [Expression Tree Visualizer](https://github.com/zspitz/ExpressionToString#visual-studio-debugger-visualizer-for-expression-trees) ([MIT license](https://github.com/zspitz/ExpressionToString/blob/master/LICENSE)), provides a graphical view of the expression tree, its properties, and related objects; and can render the expression tree using Visual Basic code:

  ![ExpressionToString visualizer](media/debugging-expression-trees-in-visual-studio/expression_to_string_visualizer_vb.png)

### To open a visualizer for an expression tree  
  
1. Click the magnifying glass icon that appears next to the expression tree in **DataTips**, a **Watch** window, the **Autos** window, or the **Locals** window.  
  
     A list of available visualizers is displayed.: 

      ![Opening visualizers from Visual Studio](media/debugging-expression-trees-in-visual-studio/expression_tree_visualizers_vb.png)

2. Click the visualizer you want to use.  

## See also

- [Expression Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/expression-trees/index.md)
- [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio)
- [Create Custom Visualizers](/visualstudio/debugger/create-custom-visualizers-of-data)
- [`DebugView` syntax](debugview-syntax.md)
