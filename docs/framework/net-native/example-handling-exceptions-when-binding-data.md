---
title: "Example: Handling Exceptions When Binding Data"
ms.date: "03/30/2017"
ms.assetid: bd63ed96-9853-46dc-ade5-7bd1b0f39110
author: "rpetrusha"
ms.author: "ronpet"
---
# Example: Handling Exceptions When Binding Data
> [!NOTE]
> This topic refers to the .NET Native Developer Preview, which is pre-release software. You can download the preview from the [Microsoft Connect website](https://go.microsoft.com/fwlink/?LinkId=394611) (requires registration).  
  
 The following example shows how to resolve a [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) exception that is thrown when an app compiled with the .NET Native tool chain tries to bind data. Here’s the exception information:  
  
```output
This operation cannot be carried out as metadata for the following type was removed for performance reasons:   
App.ViewModels.MainPageVM  
```  
  
 Here's the associated call stack:  
  
```output
Reflection::Execution::ReflectionDomainSetupImplementation.CreateNonInvokabilityException+0x238  
Reflection::Core::ReflectionDomain.CreateNonInvokabilityException+0x2e  
Reflection::Core::Execution::ExecutionEnvironment.+0x316  
System::Reflection::Runtime::PropertyInfos::RuntimePropertyInfo.GetValue+0x1cb  
System::Reflection::PropertyInfo.GetValue+0x22  
System::Runtime::InteropServices::WindowsRuntime::CustomPropertyImpl.GetValue+0x42  
App!$66_Interop::McgNative.Func_IInspectable_IInspectable+0x158  
App!$66_Interop::McgNative::__vtable_Windows_UI_Xaml_Data__ICustomProperty.GetValue__STUB+0x46  
Windows_UI_Xaml!DirectUI::PropertyProviderPropertyAccess::GetValue+0x3f   
Windows_UI_Xaml!DirectUI::PropertyAccessPathStep::GetValue+0x31   
Windows_UI_Xaml!DirectUI::PropertyPathListener::ConnectPathStep+0x113  
```  
  
## What was the app doing?  
 At the base of the stack, frames from the <xref:Windows.UI.Xaml?displayProperty=nameWithType> namespace indicate that the XAML rendering engine was running.   The use of the <xref:System.Reflection.PropertyInfo.GetValue%2A?displayProperty=nameWithType> method indicates a reflection-based lookup of a property’s value on the type whose metadata was removed.  
  
 The first step in providing a metadata directive would be to add `serialize` metadata for the type so that its properties are all accessible:  
  
```xml  
<Type Name="App.ViewModels.MainPageVM" Serialize="Required Public" />  
```  
  
## Is this an isolated case?  
 In this scenario, if data binding has incomplete metadata for one `ViewModel`, it may for others, too.  If the code is structured in a way that the app’s view models are all in the `App.ViewModels` namespace, you could use a more general runtime directive:  
  
```xml  
<Namespace Name="App.ViewModels " Serialize="Required Public" />  
```  
  
## Could the code be rewritten to not use reflection?  
 Because data binding is reflection-intensive, changing the code to avoid reflection isn’t feasible.  
  
 However, there are ways to specify the `ViewModel` to the XAML page so that the tool chain can associate property bindings with the correct type at compile time and keep the metadata without using a runtime directive.  For example, you could apply the <xref:Windows.UI.Xaml.Data.BindableAttribute?displayProperty=nameWithType> attribute on properties. This causes the XAML compiler to generate the required lookup information and avoids requiring a runtime directive in the Default.rd.xml file.  
  
## See also

- [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md)
- [Example: Troubleshooting Dynamic Programming](../../../docs/framework/net-native/example-troubleshooting-dynamic-programming.md)
