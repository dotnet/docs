---
title: "Example: Troubleshooting Dynamic Programming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 42ed860a-a022-4682-8b7f-7c9870784671
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Example: Troubleshooting Dynamic Programming
> [!NOTE]
>  This topic refers to the .NET Native Developer Preview, which is pre-release software. You can download the preview from the [Microsoft Connect website](http://go.microsoft.com/fwlink/?LinkId=394611) (requires registration).  
  
 Not all metadata lookup failures in apps developed using the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain result in an exception.  Some can manifest in unpredictable ways in an app.  The following example shows an access violation caused by referencing a null object:  
  
```  
Access violation - code c0000005 (first chance)  
App!$3_App::Core::Util::NavigationArgs.Setup  
App!$3_App::Core::Util::NavigationArgs..ctor  
App!$0_App::Gibbon::Util::DesktopNavigationArgs..ctor  
App!$0_App::ViewModels::DesktopAppVM.NavigateToPage  
App!$3_App::Core::ViewModels::AppViewModel.NavigateToFirstPage  
App!$3_App::Core::ViewModels::AppViewModel::<HandleLaunch>d__a.MoveNext  
App!$43_System::Runtime::CompilerServices::AsyncMethodBuilderCore.CallMoveNext  
App!System::Action.InvokeClosedStaticThunk  
App!System::Action.Invoke  
App!$43_System::Threading::Tasks::AwaitTaskContinuation.InvokeAction  
App!$43_System::Threading::SendOrPostCallback.InvokeOpenStaticThunk  
[snip]  
```  
  
 Let's try to troubleshoot this exception by using the three-step approach outlined in the "Manually resolve missing metadata" section of [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md).  
  
## What was the app doing?  
 The first thing to note is the `async` keyword machinery at the base of the stack.  Determining what the app was really doing in an `async` method can be problematic, because the stack has lost the context of the originating call and has run the `async` code on a different thread. However, we can deduce that the app is trying to load its first page.  In the implementation for `NavigationArgs.Setup`, the following code caused the access violation:  
  
```  
AppViewModel.Current.LayoutVM.PageMap  
```  
  
 In this instance, the `LayoutVM` property on `AppViewModel.Current` was **null**.  Some absence of metadata caused a subtle behavior difference and resulted in a property being uninitialized instead of set, as the app expected.  Setting a breakpoint in the code where `LayoutVM` should have been initialized might throw light on the situation.  However, note that `LayoutVM`’s type is `App.Core.ViewModels.Layout.LayoutApplicationVM`.  The only metadata directive present so far in the rd.xml file is:  
  
```xml  
<Namespace Name="App.ViewModels" Browse="Required Public" Dynamic="Required Public" />  
```  
  
 A likely candidate for the failure is that `App.Core.ViewModels.Layout.LayoutApplicationVM` is missing metadata because it's in a different namespace.  
  
 In this case, adding a runtime directive for `App.Core.ViewModels` resolved the issue. The root cause was an API call to the <xref:System.Type.GetType%28System.String%29?displayProperty=nameWithType> method that returned **null**, and the app silently ignored the problem until a crash occurred.  
  
 In dynamic programming, a good practice when using reflection APIs under [!INCLUDE[net_native](../../../includes/net-native-md.md)] is to use the <xref:System.Type.GetType%2A?displayProperty=nameWithType> overloads that throw an exception on failure.  
  
## Is this an isolated case?  
 Other issues might also arise when using `App.Core.ViewModels`.  You must decide whether it’s worth identifying and fixing each missing metadata exception, or saving time and adding directives for a larger class of types.  Here, adding `dynamic` metadata for `App.Core.ViewModels` might be the best approach if the resulting size increase of the output binary isn’t an issue.  
  
## Could the code be rewritten?  
 If the app had used `typeof(LayoutApplicationVM)` instead of `Type.GetType("LayoutApplicationVM")`, the tool chain could have preserved `browse` metadata.  However, it still wouldn't have created `invoke` metadata, which would have led to a [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) exception when instantiating the type. To prevent the exception, you'd still have to add a runtime directive for the namespace or the type that specifies the `dynamic` policy. For information on runtime directives, see the [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
## See Also  
 [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md)  
 [Example: Handling Exceptions When Binding Data](../../../docs/framework/net-native/example-handling-exceptions-when-binding-data.md)
