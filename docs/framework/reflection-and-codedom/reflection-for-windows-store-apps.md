---
title: "Reflection in the .NET Framework for Windows Store Apps"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "reflection, Windows Store apps"
  - ".NET for Windows Store apps, TypeInfo class"
ms.assetid: 0d07090c-9b47-4ecc-81d1-29d539603c9b
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reflection in the .NET Framework for Windows Store Apps
Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], the .NET Framework includes a set of reflection types and members for use in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps. These types and members are available in the full .NET Framework as well as in the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=225700). This document explains the major differences between these and their counterparts in the .NET Framework 4 and earlier versions.  
  
 If you are creating a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, you must use the reflection types and members in the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)]. These types and members are also available, but not required, for use in desktop apps, so you can use the same code for both types of apps.  
  
## TypeInfo and Assembly Loading  
 In the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)], the <xref:System.Reflection.TypeInfo> class contains some of the functionality of the .NET Framework 4 <xref:System.Type> class. A <xref:System.Type> object represents a reference to a type definition, whereas a <xref:System.Reflection.TypeInfo> object represents the type definition itself. This enables you to manipulate <xref:System.Type> objects without necessarily requiring the runtime to load the assembly they reference. Getting the associated <xref:System.Reflection.TypeInfo> object forces the assembly to load.  
  
 <xref:System.Reflection.TypeInfo> contains many of the members available on <xref:System.Type>, and many of the reflection properties in the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)] return collections of <xref:System.Reflection.TypeInfo> objects. To get a <xref:System.Reflection.TypeInfo> object from a <xref:System.Type> object, use the <xref:System.Reflection.IReflectableType.GetTypeInfo%2A> method.  
  
## Query Methods  
 In the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)], you use the reflection properties that return <xref:System.Collections.Generic.IEnumerable%601> collections instead of methods that return arrays. Reflection contexts can implement lazy traversal of these collections for large assemblies or types.  
  
 The reflection properties return only the declared methods on a particular object instead of traversing the inheritance tree. Moreover, they do not use <xref:System.Reflection.BindingFlags> parameters for filtering. Instead, filtering takes place in user code, by using LINQ queries on the returned collections. For reflection objects that originate with the runtime (for example, as the result of `typeof(Object)`), traversing the inheritance tree is best accomplished by using the helper methods of the <xref:System.Reflection.RuntimeReflectionExtensions> class. Consumers of objects from customized reflection contexts cannot use these methods, and must traverse the inheritance tree themselves.  
  
## Restrictions  
 In a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, access to some .NET Framework types and members is restricted. For example, you cannot call .NET Framework methods that are not included in [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)], by using a <xref:System.Reflection.MethodInfo> object. In addition, certain types and members that are not considered safe within the context of a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app are blocked, as are <xref:System.Runtime.InteropServices.Marshal> and <xref:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal> members. This restriction affects only .NET Framework types and members; you can call your code or third-party code as you normally would.  
  
## Example  
 This example uses the reflection types and members in the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)] to retrieve the methods and properties of the <xref:System.Globalization.Calendar> type, including inherited methods and properties. To run this code, paste it into the code file for a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] page that contains a [Windows.UI.Xaml.Controls.Textblock](http://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) control named `textblock1` in a project named Reflection. If you paste this code inside a project with a different name, just make sure you change the namespace name to match your project.  
  
 [!code-csharp[System.ReflectionWinStoreApp#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.reflectionwinstoreapp/cs/mainpage.xaml.cs#1)]
 [!code-vb[System.ReflectionWinStoreApp#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.reflectionwinstoreapp/vb/mainpage.xaml.vb#1)]  
  
## See Also  
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)  
 [.NET for Windows Store apps – supported APIs](http://go.microsoft.com/fwlink/?LinkID=225700)
