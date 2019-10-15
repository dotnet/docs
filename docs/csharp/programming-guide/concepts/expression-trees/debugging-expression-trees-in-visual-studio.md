---
title: "Debugging Expression Trees in Visual Studio (C#)"
ms.date: 07/20/2015
ms.assetid: 1369fa25-0fbd-4b92-98d0-8df79c49c27a
---
# Debugging Expression Trees in Visual Studio (C#)
You can analyze the structure and content of expression trees when you debug your applications. To get a quick overview of the expression tree structure, you can use the `DebugView` property, which represents expression trees [using a special syntax](debugview-syntax.md). (Note that `DebugView` is available only in debug mode.)  

![Screenshot of the DebugView of an expression tree within VS debugger.](media/debugging-expression-trees-in-visual-studio/debugview-expression-tree.png)

Since `DebugView` is a string, you can use the [built-in Text Visualizer](https://docs.microsoft.com/visualstudio/debugger/view-strings-visualizer#open-a-string-visualizer) to view it across multiple lines, by selecting **Text Visualizer** from the magnifying glass icon next to the `DebugView` label.

 ![Screenshot of the Text Visualizer applied to results of DebugView.](media/debugging-expression-trees-in-visual-studio/string-visualizer-debugview.png)

Alternatively, you can install and use [a custom visualizer](https://docs.microsoft.com/visualstudio/debugger/create-custom-visualizers-of-data) for expression trees, such as:

- [Readable Expressions](https://github.com/agileobjects/ReadableExpressions) ([MIT license](https://github.com/agileobjects/ReadableExpressions/blob/master/LICENSE.md), available at the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=vs-publisher-1232914.ReadableExpressionsVisualizers)), renders the expression tree as C# code:

  ![Screenshot of the Readable Expressions visualizer.](media/debugging-expression-trees-in-visual-studio/readable-expressions-visualizer.png)

- [Expression Tree Visualizer](https://github.com/zspitz/ExpressionToString#visual-studio-debugger-visualizer-for-expression-trees) ([MIT license](https://github.com/zspitz/ExpressionToString/blob/master/LICENSE)), provides a graphical view of the expression tree, its properties, and related objects:

  ![Screenshot of the Expression Tree Visualizer.](media/debugging-expression-trees-in-visual-studio/expression-to-string-visualizer.png)

### To open a visualizer for an expression tree  
  
1. Click the magnifying glass icon that appears next to the expression tree in **DataTips**, a **Watch** window, the **Autos** window, or the **Locals** window.  

    A list of available visualizers is displayed.: 

    ![Screenshot showing the Opening of visualizers from Visual Studio.](media/debugging-expression-trees-in-visual-studio/expression-tree-visualizers.png)

2. Click the visualizer you want to use.  
  
## See also

- [Expression Trees (C#)](./index.md)
- [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio)
- [Create Custom Visualizers](/visualstudio/debugger/create-custom-visualizers-of-data)
- [`DebugView` syntax](debugview-syntax.md)
