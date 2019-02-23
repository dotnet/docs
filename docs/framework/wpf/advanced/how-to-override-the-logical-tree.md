---
title: "How to: Override the Logical Tree"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "overriding the logical tree [WPF]"
  - "logical tree [WPF], overriding"
ms.assetid: 0ae4d074-8113-4b06-b4fa-e0f39d4967a6
---
# How to: Override the Logical Tree
Although it is not necessary in most cases, advanced control authors have the option to override the logical tree.  
  
## Example  
 This example describes how to subclass <xref:System.Windows.Controls.StackPanel> to override the logical tree, in this case to enforce a behavior that the panel may only have and will only render a single child element. This isn't necessarily a practically desirable behavior, but is shown here as a means of illustrating the scenario for overriding an element's normal logical tree.  
  
 [!code-csharp[LogicalOverride#SingletonPanel](~/samples/snippets/csharp/VS_Snippets_Wpf/LogicalOverride/CSharp/SDKSampleLibrary/class1.cs#singletonpanel)]  
  
 For more information on the logical tree, see [Trees in WPF](trees-in-wpf.md).
