---
title: "How to: Persist and Restore Application-Scope Properties Across Application Sessions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application-scope properties [WPF], persisting"
  - "persisting application-scope properties [WPF]"
  - "properties [WPF], persisting"
  - "restoring application-scope properties [WPF]"
  - "properties [WPF], restoring"
  - "application-scope properties [WPF], restoring"
ms.assetid: 55d5904a-f444-4eb5-abd3-6bc74dd14226
---
# How to: Persist and Restore Application-Scope Properties Across Application Sessions
This example shows how to persist application-scope properties when an application shuts down, and how to restore application-scope properties when an application is next launch.  
  
## Example  
 The application persists application-scope properties to, and restores them from, isolated storage. Isolated storage is a protected storage area that can safely be used by applications without file access permission.  The *App.xaml* file defines the `App_Startup` method as the handler for the <xref:System.Windows.Application.Startup?displayProperty=nameWithType> event, and the `App_Exit` method as the handler for the  <xref:System.Windows.Application.Exit?displayProperty=nameWithType> event, as shown in the highlighted lines of the first example. The second example shows a portion of the *App.xaml.cs* and *App.xaml.vb* files that highlights the code for the `App_Startup` method, which restores application-scope properties, and the `App_Exit` method, which saves application-scope properties.

 [!code-xaml[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesXAML1](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/CSharp/App.xaml?highlight=1-7)]
  
 [!code-csharp[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesCODEBEHIND1](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/CSharp/App.xaml.cs?highlight=17-55)]
 [!code-vb[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesCODEBEHIND1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/visualbasic/application.xaml.vb#persistrestoreappscopepropertiescodebehind1)]
