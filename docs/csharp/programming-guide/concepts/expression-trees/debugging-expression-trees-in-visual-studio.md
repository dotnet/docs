---
title: "Debugging Expression Trees in Visual Studio (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 1369fa25-0fbd-4b92-98d0-8df79c49c27a
caps.latest.revision: 4
author: "BillWagner"
ms.author: "wiwagn"
---
# Debugging Expression Trees in Visual Studio (C#)
You can analyze the structure and content of expression trees when you debug your applications. To get a quick overview of the expression tree structure, you can use the `DebugView` property, which is available only in debug mode. For more information about debugging, see [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio).  
  
 To better represent the content of expression trees, the `DebugView` property uses Visual Studio visualizers. For more information, see [Create Custom Visualizers](/visualstudio/debugger/create-custom-visualizers-of-data).  
  
### To open a visualizer for an expression tree  
  
1.  Click the magnifying glass icon that appears next to the `DebugView` property of an expression tree in **DataTips**, a **Watch** window, the **Autos** window, or the **Locals** window.  
  
     A list of visualizers is displayed.  
  
2.  Click the visualizer you want to use.  
  
 Each expression type is displayed in the visualizer as described in the following sections.  
  
## ParameterExpressions  
 <xref:System.Linq.Expressions.ParameterExpression> variable names are displayed with a "$" symbol at the beginning.  
  
 If a parameter does not have a name, it is assigned an automatically generated name, such as `$var1` or `$var2`.  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`ParameterExpression numParam =  Expression.Parameter(typeof(int), "num");`|`$num`|  
|`ParameterExpression numParam =  Expression.Parameter(typeof(int));`|`$var1`|  
  
## ConstantExpressions  
 For <xref:System.Linq.Expressions.ConstantExpression> objects that represent integer values, strings, and `null`, the value of the constant is displayed.  
  
 For numeric types that have standard suffixes as C# literals, the suffix is added to the value. The following table shows the suffixes associated with various numeric types.  
  
|Type|Suffix|  
|----------|------------|  
|<xref:System.UInt32>|U|  
|<xref:System.Int64>|L|  
|<xref:System.UInt64>|UL|  
|<xref:System.Double>|D|  
|<xref:System.Single>|F|  
|<xref:System.Decimal>|M|  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`int num = 10; ConstantExpression expr = Expression.Constant(num);`|10|  
|`double num = 10; ConstantExpression expr = Expression.Constant(num);`|10D|  
  
## BlockExpression  
 If the type of a <xref:System.Linq.Expressions.BlockExpression> object differs from the type of the last expression in the block, the type is displayed in the `DebugInfo` property in angle brackets (\< and >). Otherwise, the type of the <xref:System.Linq.Expressions.BlockExpression> object is not displayed.  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`BlockExpression block = Expression.Block(Expression.Constant("test"));`|`.Block() {`<br /><br /> `"test"`<br /><br /> `}`|  
|`BlockExpression block =  Expression.Block(typeof(Object), Expression.Constant("test"));`|`.Block<System.Object>() {`<br /><br /> `"test"`<br /><br /> `}`|  
  
## LambdaExpression  
 <xref:System.Linq.Expressions.LambdaExpression> objects are displayed together with their delegate types.  
  
 If a lambda expression does not have a name, it is assigned an automatically generated name, such as `#Lambda1` or `#Lambda2`.  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`LambdaExpression lambda =  Expression.Lambda<Func<int>>(Expression.Constant(1));`|`.Lambda #Lambda1<System.Func'1[System.Int32]>() {`<br /><br /> `1`<br /><br /> `}`|  
|`LambdaExpression lambda =  Expression.Lambda<Func<int>>(Expression.Constant(1), "SampleLambda", null);`|`.Lambda SampleLambda<System.Func'1[System.Int32]>() {`<br /><br /> `1`<br /><br /> `}`|  
  
## LabelExpression  
 If you specify a default value for the <xref:System.Linq.Expressions.LabelExpression> object, this value is displayed before the <xref:System.Linq.Expressions.LabelTarget> object.  
  
 The `.Label` token indicates the start of the label. The `.LabelTarget` token indicates the destination of the target to jump to.  
  
 If a label does not have a name, it is assigned an automatically generated name, such as `#Label1` or `#Label2`.  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`LabelTarget target = Expression.Label(typeof(int), "SampleLabel"); BlockExpression block = Expression.Block( Expression.Goto(target, Expression.Constant(0)), Expression.Label(target, Expression.Constant(-1)));`|`.Block() {`<br /><br /> `.Goto SampleLabel { 0 };`<br /><br /> `.Label`<br /><br /> `-1`<br /><br /> `.LabelTarget SampleLabel:`<br /><br /> `}`|  
|`LabelTarget target = Expression.Label(); BlockExpression block = Expression.Block( Expression.Goto(target5), Expression.Label(target5));`|`.Block() {`<br /><br /> `.Goto #Label1 { };`<br /><br /> `.Label`<br /><br /> `.LabelTarget #Label1:`<br /><br /> `}`|  
  
## Checked Operators  
 Checked operators are displayed with the "#" symbol in front of the operator. For example, the checked addition operator is displayed as `#+`.  
  
### Examples  
  
|Expression|`DebugView` property|  
|----------------|--------------------------|  
|`Expression expr = Expression.AddChecked( Expression.Constant(1), Expression.Constant(2));`|`1 #+ 2`|  
|`Expression expr = Expression.ConvertChecked( Expression.Constant(10.0), typeof(int));`|`#(System.Int32)10D`|  
  
## See Also  
 [Expression Trees (C#)](../../../../csharp/programming-guide/concepts/expression-trees/index.md)  
 [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio)  
 [Create Custom Visualizers](/visualstudio/debugger/create-custom-visualizers-of-data)
