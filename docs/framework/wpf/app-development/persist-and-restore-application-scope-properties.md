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
 The application persists application-scope properties to, and restores them from, isolated storage. Isolated storage is a protected storage area that can safely be used by applications without file access permission.  
  
 [!code-xaml[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesXAML1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/CSharp/App.xaml?highlight=1-7)]
  
 [!code-csharp[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesCODEBEHIND1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/CSharp/App.xaml.cs#persistrestoreappscopepropertiescodebehind1)]
 [!code-vb[HOWTOApplicationModelSnippets#PersistRestoreAppScopePropertiesCODEBEHIND1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOApplicationModelSnippets/visualbasic/application.xaml.vb#persistrestoreappscopepropertiescodebehind1)]
 
