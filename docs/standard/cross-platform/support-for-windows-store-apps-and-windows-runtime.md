---
title: ".NET Framework Support for Windows Store Apps and Windows Runtime"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Store apps, .NET Framework support for"
  - "Windows Runtime, .NET Framework support for"
  - ".NET for Windows Store apps"
  - ".NET Framework, and Windows Store apps"
  - ".NET Framework, and Windows Runtime"
ms.assetid: 6fa7d044-ae12-4c54-b8ee-50915607a565
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# .NET Framework Support for Windows Store Apps and Windows Runtime
The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] supports a number of software development scenarios with the [!INCLUDE[wrt](../../../includes/wrt-md.md)]. These scenarios fall into three categories:  
  
-   Developing [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps with XAML controls, as described in [Roadmap for Windows Store apps using C# or Visual Basic](http://go.microsoft.com/fwlink/p/?LinkID=242212), [Developing Windows Store apps (VB/C#/C++ and XAML)](http://go.microsoft.com/fwlink/p/?LinkId=238311), and [.NET for Windows Store apps overview](http://go.microsoft.com/fwlink/p/?LinkId=238312) in the Windows Dev Center.  
  
-   Developing class libraries to use in the [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps that you create with the .NET Framework.  
  
-   Developing [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components, packaged in .WinMD files, which can be used by any programming language that supports the [!INCLUDE[wrt](../../../includes/wrt-md.md)]. For example, see [Creating Windows Runtime Components in C# and Visual Basic](http://go.microsoft.com/fwlink/p/?LinkId=238313) in the Windows Dev Center.  
  
 This topic outlines the support that the .NET Framework provides for all three categories, and describes the scenarios for [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components. The first section includes basic information about the relationship between the .NET Framework and the [!INCLUDE[wrt](../../../includes/wrt-md.md)], and explains some oddities you might encounter in the Help system and the IDE. The [second section](#WindowsRuntimeComponents) discusses scenarios for developing [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components.  
  
## The Basics  
 The .NET Framework supports the three development scenarios listed earlier by providing [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)], and by supporting the [!INCLUDE[wrt](../../../includes/wrt-md.md)] itself.  
  
-   [.NET for Windows Store apps](http://go.microsoft.com/fwlink/p/?LinkId=247912) provides a streamlined view of the .NET Framework class libraries and include only the types and members you can use to create [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps and [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components.  
  
    -   When you use Visual Studio ([!INCLUDE[vs_dev11_long](../../../includes/vs-dev11-long-md.md)] or later) to develop a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app or a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component, a set of reference assemblies ensures that you see only the relevant types and members.  
  
    -   This streamlined API set is simplified further by the removal of features that are duplicated within the .NET Framework or that duplicate [!INCLUDE[wrt](../../../includes/wrt-md.md)] features. For example, it contains only the generic versions of collection types, and the XML document object model is eliminated in favor of the [!INCLUDE[wrt](../../../includes/wrt-md.md)] XML API set.  
  
    -   Features that simply wrap the operating system API are also removed, because the [!INCLUDE[wrt](../../../includes/wrt-md.md)] is easy to call from managed code.  
  
     To read more about the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)], see the [.NET for Windows Store apps overview](http://go.microsoft.com/fwlink/p/?LinkId=238312) in the Windows Dev Center.To read about the API selection process, see the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/p/?LinkId=251061) entry in the .NET blog.  
  
-   The [Windows Runtime](http://go.microsoft.com/fwlink/p/?LinkId=238319) provides the user interface elements for building [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, and provides access to operating system features. Like the .NET Framework, the [!INCLUDE[wrt](../../../includes/wrt-md.md)] has metadata that enables the C# and Visual Basic compilers to use the [!INCLUDE[wrt](../../../includes/wrt-md.md)] the way they use the .NET Framework class libraries. The .NET Framework makes it easier to use the [!INCLUDE[wrt](../../../includes/wrt-md.md)] by hiding some differences:  
  
    -   Some differences in programming patterns between the .NET Framework and the [!INCLUDE[wrt](../../../includes/wrt-md.md)], such as the pattern for adding and removing event handlers, are hidden. You simply use the .NET Framework pattern.  
  
    -   Some differences in commonly used types (for example, primitive types and collections) are hidden. You simply use the .NET Framework type, as discussed in [Differences That Are Visible in the IDE](#DifferencesVisibleInIDE), later in this article.  
  
 Most of the time, .NET Framework support for the [!INCLUDE[wrt](../../../includes/wrt-md.md)] is transparent. The next section discusses some of the apparent differences between managed code and the [!INCLUDE[wrt](../../../includes/wrt-md.md)].  
  
<a name="AboutReferenceDocumentation"></a>   
### The .NET Framework and the [!INCLUDE[wrt](../../../includes/wrt-md.md)] Reference Documentation  
 The Windows and the .NET Framework documentation sets are separate. If you press F1 to display Help on a type or member, reference documentation from the appropriate set is displayed. However, if you browse through the [Windows Runtime reference](http://go.microsoft.com/fwlink/p/?LinkId=238319) you might encounter examples that seem puzzling:  
  
-   Topics such as the [IIterable interface](http://go.microsoft.com/fwlink/p/?LinkId=238321) don't have declaration syntax for Visual Basic or C#. Instead, a note appears above the syntax section (in this case, ".NET: This interface appears as System.Collections.Generic.IEnumerable\<T>"). This is because the .NET Framework and the [!INCLUDE[wrt](../../../includes/wrt-md.md)] provide similar functionality with different interfaces. In addition, there are behavioral differences: `IIterable` has a `First` method instead of a <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> method to return the enumerator. Instead of forcing you to learn a different way of performing a common task, the .NET Framework supports the [!INCLUDE[wrt](../../../includes/wrt-md.md)] by making your managed code appear to use the type you're familiar with. You won't see the `IIterable` interface in the IDE, and therefore the only way you'll encounter it in the [!INCLUDE[wrt](../../../includes/wrt-md.md)] reference documentation is by browsing through that documentation directly.  
  
-   The [SyndicationFeed constructor](http://go.microsoft.com/fwlink/p/?LinkId=238322) documentation illustrates a closely related issue: Its parameter types appear to be different for different languages. For C# and Visual Basic, the parameter types are <xref:System.String?displayProperty=nameWithType> and <xref:System.Uri?displayProperty=nameWithType>. Again, this is because the .NET Framework has its own `String` and `Uri` types, and for such commonly used types it doesn't make sense to force .NET Framework users to learn a different way of doing things. In the IDE, the .NET Framework hides the corresponding [!INCLUDE[wrt](../../../includes/wrt-md.md)] types.  
  
-   In a few cases, such as the [Windows.UI.Xaml.GridLength](http://go.microsoft.com/fwlink/p/?LinkId=251059) structure, the .NET Framework provides a type with the same name but more functionality. For example, a set of constructor and property topics are associated with `GridLength`, but they have syntax blocks only for Visual Basic and C# because the members are available only in managed code. In the [!INCLUDE[wrt](../../../includes/wrt-md.md)], structures have only fields. The [!INCLUDE[wrt](../../../includes/wrt-md.md)] structure requires a helper class, [Windows.UI.Xaml.GridLengthHelper](http://go.microsoft.com/fwlink/p/?LinkId=251060), to provide equivalent functionality. You won't see that helper class in the IDE when you're writing managed code.  
  
-   In the IDE, [!INCLUDE[wrt](../../../includes/wrt-md.md)] types appear to derive from <xref:System.Object?displayProperty=nameWithType>. They appear to have members inherited from <xref:System.Object>, such as <xref:System.Object.ToString%2A?displayProperty=nameWithType>. These members operate as they would if the types actually inherited from <xref:System.Object>, and [!INCLUDE[wrt](../../../includes/wrt-md.md)] types can be cast to <xref:System.Object>. This functionality is part of the support that the .NET Framework provides for the [!INCLUDE[wrt](../../../includes/wrt-md.md)]. However, if you view the types in the [!INCLUDE[wrt](../../../includes/wrt-md.md)] reference documentation, no such members appear. The documentation for these apparent inherited members is provided by the <xref:System.Object?displayProperty=nameWithType> reference documentation.  
  
<a name="DifferencesVisibleInIDE"></a>   
### Differences That Are Visible in the IDE  
 In more advanced programming scenarios, such as using a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component written in C# to provide the application logic for a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app built for Windows using JavaScript, such differences are apparent in the IDE as well as in the documentation. When your component returns an `IDictionary<int, string>` to JavaScript, and you look at it in the JavaScript debugger, you'll see the methods of `IMap<int, string>` because JavaScript uses the [!INCLUDE[wrt](../../../includes/wrt-md.md)] type. Some commonly used collection types that appear differently in the two languages are shown in the following table:  
  
|[!INCLUDE[wrt](../../../includes/wrt-md.md)] type|Corresponding .NET Framework type|  
|--------------------------------------------------------------|---------------------------------------|  
|`IIterable<T>`|`IEnumerable<T>`|  
|`IIterator<T>`|`IEnumerator<T>`|  
|`IVector<T>`|`IList<T>`|  
|`IVectorView<T>`|`IReadOnlyList<T>`|  
|`IMap<K, V>`|`IDictionary<TKey, TValue>`|  
|`IMapView<K, V>`|`IReadOnlyDictionary<TKey, TValue>`|  
|`IBindableIterable`|`IEnumerable`|  
|`IBindableVector`|`IList`|  
|`Windows.UI.Xaml.Data.INotifyPropertyChanged`|`System.ComponentModel.INotifyPropertyChanged`|  
|`Windows.UI.Xaml.Data.PropertyChangedEventHandler`|`System.ComponentModel.PropertyChangedEventHandler`|  
|`Windows.UI.Xaml.Data.PropertyChangedEventArgs`|`System.ComponentModel.PropertyChangedEventArgs`|  
  
 In the [!INCLUDE[wrt](../../../includes/wrt-md.md)], `IMap<K, V>` and `IMapView<K, V>` are iterated using `IKeyValuePair`. When you pass them to managed code, they appear as `IDictionary<TKey, TValue>` and `IReadOnlyDictionary<TKey, TValue>`, so naturally you use `System.Collections.Generic.KeyValuePair<TKey, TValue>` to enumerate them.  
  
 The way interfaces appear in managed code affects the way types that implement these interfaces appear. For example, the `PropertySet` class implements `IMap<K, V>`, which appears in managed code as `IDictionary<TKey, TValue>`. `PropertySet` appears as if it implemented `IDictionary<TKey, TValue>` instead of `IMap<K, V>`, so in managed code it appears to have an `Add` method, which behaves like the `Add` method on .NET Framework dictionaries. It doesn't appear to have an `Insert` method.  
  
 For more information about using the .NET Framework to create a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component, and a walkthrough that shows how to use such a component with JavaScript, see [Creating Windows Runtime Components in C# and Visual Basic](http://go.microsoft.com/fwlink/p/?LinkId=238313) in the Windows Dev Center.  
  
### Primitive Types  
 To enable the natural use of the [!INCLUDE[wrt](../../../includes/wrt-md.md)] in managed code, .NET Framework primitive types appear instead of [!INCLUDE[wrt](../../../includes/wrt-md.md)] primitive types in your code. In the .NET Framework, primitive types like the `Int32` structure have many useful properties and methods, such as the `Int32.TryParse` method. By contrast, primitive types and structures in the [!INCLUDE[wrt](../../../includes/wrt-md.md)] have only fields. When you use primitives in managed code, they appear to be .NET Framework types, and you can use the properties and methods of the .NET Framework types as you normally would. The following list provides a summary:  
  
-   For the [!INCLUDE[wrt](../../../includes/wrt-md.md)] primitives `Int32`, `Int64`, `Single`, `Double`, `Boolean`, `String` (an immutable collection of Unicode characters), `Enum`, `UInt32`, `UInt64`, and `Guid`, use the type of the same name in the `System` namespace.  
  
-   For `UInt8`, use `System.Byte`.  
  
-   For `Char16`, use `System.Char`.  
  
-   For the `IInspectable` interface, use `System.Object`.  
  
-   For `HRESULT`, use a structure with one `System.Int32` member.  
  
 As with interface types, the only time you might see evidence of this representation is when your .NET Framework project is a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component that is used by a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app built using JavaScript.  
  
 Other basic, commonly used [!INCLUDE[wrt](../../../includes/wrt-md.md)] types that appear in managed code as their .NET Framework equivalents include the `Windows.Foundation.DateTime` structure, which appears in managed code as the <xref:System.DateTimeOffset?displayProperty=nameWithType> structure, and the `Windows.Foundation.TimeSpan` structure, which appears as the <xref:System.TimeSpan?displayProperty=nameWithType> structure.  
  
### Other Differences  
 In a few cases, the fact that .NET Framework types appear in your code instead of [!INCLUDE[wrt](../../../includes/wrt-md.md)] types requires action on your part. For example, the [Windows.Foundation.Uri](http://go.microsoft.com/fwlink/p/?LinkId=238376) class appears as <xref:System.Uri?displayProperty=nameWithType> in .NET Framework code. <xref:System.Uri?displayProperty=nameWithType> allows a relative URI, but [Windows.Foundation.Uri](http://go.microsoft.com/fwlink/p/?LinkId=238376) requires an absolute URI. Therefore, when you pass a URI to a [!INCLUDE[wrt](../../../includes/wrt-md.md)] method, you must ensure that it's absolute. (See [Passing a URI to the Windows Runtime](../../../docs/standard/cross-platform/passing-a-uri-to-the-windows-runtime.md).)  
  
<a name="WindowsRuntimeComponents"></a>   
## Scenarios for Developing Windows Runtime Components  
 The scenarios that are supported for managed [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components depend on the following general principles:  
  
-   [!INCLUDE[wrt](../../../includes/wrt-md.md)] Components that are built using the .NET Framework have no apparent differences from other [!INCLUDE[wrt](../../../includes/wrt-md.md)]libraries. For example, if you re-implement a native [!INCLUDE[wrt](../../../includes/wrt-md.md)] component by using managed code, the two components are outwardly indistinguishable. The fact that your component is written in managed code is invisible to the code that uses it, even if that code is itself managed code. However, internally, your component is true managed code and runs on the common language runtime (CLR).  
  
-   Components can contain types that implement application logic, [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] UI controls, or both.  
  
    > [!NOTE]
    >  It's good practice to separate UI elements from application logic. Also, you can't use [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] UI controls in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app built for Windows using JavaScript and HTML.  
  
-   A component can be a project within a Visual Studio solution for a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, or a reusable component that you can add to multiple solutions.  
  
    > [!NOTE]
    >  If your component will be used only with C# or Visual Basic, there's no reason to make it a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component. If you make it an ordinary .NET Framework class library instead, you don't have to restrict its public API surface to [!INCLUDE[wrt](../../../includes/wrt-md.md)] types.  
  
-   You can release versions of reusable components by using the [!INCLUDE[wrt](../../../includes/wrt-md.md)][VersionAttribute](http://go.microsoft.com/fwlink/p/?LinkId=238563) attribute to identify which types (and which members within a type) were added in different versions.  
  
-   The types in your component can derive from [!INCLUDE[wrt](../../../includes/wrt-md.md)] types. Controls can derive from the primitive control types in the [Windows.UI.Xaml.Controls.Primitives](http://go.microsoft.com/fwlink/p/?LinkId=238564) namespace or from more finished controls such as [Button](http://go.microsoft.com/fwlink/p/?LinkId=238565).  
  
    > [!IMPORTANT]
    >  Starting with [!INCLUDE[win8](../../../includes/win8-md.md)] and the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], all public types in a managed [!INCLUDE[wrt](../../../includes/wrt-md.md)] component must be sealed. A type in another [!INCLUDE[wrt](../../../includes/wrt-md.md)] component can't derive from them. If you want to provide polymorphic behavior in your component, you can create an interface and implement it in the polymorphic types.  
  
-   All parameter and return types on the public types in your component must be [!INCLUDE[wrt](../../../includes/wrt-md.md)] types (including the [!INCLUDE[wrt](../../../includes/wrt-md.md)] types that your component defines).  
  
 The following sections provide examples of common scenarios.  
  
### Application Logic for a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] App with JavaScript  
 When you develop a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app for Windows using JavaScript, you might find that some parts of the application logic perform better in managed code, or are easier to develop. JavaScript can't use .NET Framework class libraries directly, but you can make the class library a .WinMD file. In this scenario, the [!INCLUDE[wrt](../../../includes/wrt-md.md)] component is an integral part of the app, so it doesn't make sense to provide version attributes.  
  
### Reusable [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] UI Controls  
 You can package a set of related UI controls in a reusable [!INCLUDE[wrt](../../../includes/wrt-md.md)] component. The component can be marketed on its own or used as an element in the apps you create. In this scenario, it makes sense to use the [!INCLUDE[wrt](../../../includes/wrt-md.md)][VersionAttribute](http://go.microsoft.com/fwlink/p/?LinkId=238563) attribute to improve compatibility.  
  
### Reusable Application Logic from Existing .NET Framework Apps  
 You can package managed code from your existing desktop apps as a standalone [!INCLUDE[wrt](../../../includes/wrt-md.md)] component. This enables you to use the component in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps built using C++ or JavaScript, as well as in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps built using C# or Visual Basic. Versioning is an option if there are multiple reuse scenarios for the code.  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[.NET for Windows Store apps overview](http://go.microsoft.com/fwlink/p/?LinkId=238312)|Describes the .NET Framework types and members that you can use to create [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps and [!INCLUDE[wrt](../../../includes/wrt-md.md)]Components. (In the Windows Dev Center.)|  
|[Roadmap for Windows Store apps using C# or Visual Basic](http://go.microsoft.com/fwlink/p/?LinkId=242212)|Provides key resources to help you get started developing [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps by using C# or Visual Basic, including many Quickstart topics, guidelines, and best practices. (In the Windows Dev Center.)|  
|[Developing Windows Store apps (VB/C#/C++ and XAML)](http://go.microsoft.com/fwlink/p/?LinkId=238311)|Provides key resources to help you get started developing [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps by using C# or Visual Basic, including many Quickstart topics, guidelines, and best practices. (In the Windows Dev Center.)|  
|[Creating Windows Runtime Components in C# and Visual Basic](http://go.microsoft.com/fwlink/p/?LinkId=238313)|Describes how to create a [!INCLUDE[wrt](../../../includes/wrt-md.md)] component using the .NET Framework, explains how to use it as part of a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app built for Windows using JavaScript, and describes how to debug the combination with Visual Studio. (In the Windows Dev Center.)|  
|[Windows Runtime reference](/uwp/api/)|The reference documentation for the [!INCLUDE[wrt](../../../includes/wrt-md.md)]. (In the Windows Dev Center.)|  
|[Passing a URI to the Windows Runtime](../../../docs/standard/cross-platform/passing-a-uri-to-the-windows-runtime.md)|Describes an issue that can arise when you pass a URI from managed code to the [!INCLUDE[wrt](../../../includes/wrt-md.md)], and how to avoid it.|
