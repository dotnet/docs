---
title: ".NET Compatibility Diagnostics | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5e481270-b62a-4cb4-8dda-5b4c5b59d61d
caps.latest.revision: 7
author: "twsouthwick"
ms.author: "tasou"
manager: "wpickett"
---
# .NET Compatibility Diagnostics
The .NET Compatibility Diagnostics are Roslyn-powered analyzers that help identify application compatibility issues between versions of the .NET Framework. This list contains all of the analyzers available, although only a subset will apply to any specific migration. The analyzers will determine which issues are applicable for the planned migration and will only surface those. For issues split up by versions impacted, please see: [Application Compatibility](../../../docs/framework/migration-guide/application-compatibility.md).  
  
 Each issue includes the following information:  
  
-   The description of what has changed from a previous version.  
  
-   The suggestion is a description of how the change affects customers and whether any workarounds are available to preserve compatibility across versions.  
  
-   An assessment of how important the change is. Application compatibility issue are categorized as follows:  
  
    |||  
    |-|-|  
    |Major|A significant change that affects a large number of apps or requires substantial modification of code.|  
    |Minor|A change that affects a small number of apps or that requires minor modification of code.|  
    |Edge case|A change that affects apps under very specific, uncommon scenarios.|  
    |Transparent|A change with no noticeable effect on the application’s developer or user.|  
  
-   Version indicates when the change first appears in the framework. Some of the changes are reverted and that is indicated as well.  
  
-   The type of change:  
  
    |||  
    |-|-|  
    |Retargeting|The change affects apps that are recompiled to target a new version of the .NET Framework.|  
    |Runtime|The change affects an existing app that targets a previous version of the .NET Framework but runs on a later version.|  
  
-   The affected APIS, if any.  
  
-   The IDs of the available diagnostics  
  
<a name="diagnostic1"></a>   
## 1: SoapFormatter cannot deserialize Hashtable and similar ordered collection objects  
  
|||  
|-|-|  
|Details|The SoapFormatter does not guarantee that objects serialized under one .NET Framework version will successfully deserialize under a different version. Specifically, some ordered collections (like Hashtable) added members between 4.0 and 4.5 such that objects of these types cannot deserialize with .NET 4.0 if they were serialzied with .NET 4.5. Note that if the serialized data is both serialized and deserialized with the same .NET Framework version, no issue will occur.|  
|Suggestion|SoapFormatter serialization should be replaced with BinaryFormatter serialization or NetDataContractSerialization to be resilient to .NET Framework changes.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Deserialize%28System.IO.Stream%29?displayProperty=fullName><br /><br /> <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Deserialize%28System.IO.Stream%2CSystem.Runtime.Remoting.Messaging.HeaderHandler%29?displayProperty=fullName><br /><br /> <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Serialize%28System.IO.Stream%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Serialize%28System.IO.Stream%2CSystem.Object%2CSystem.Runtime.Remoting.Messaging.Header%5B%5D%29?displayProperty=fullName>|  
|Analyzers|CD0001B<br /><br /> CD0001A|  
  
<a name="diagnostic3"></a>   
## 3: WPF DataTemplate elements are now visible to UIA  
  
|||  
|-|-|  
|Details|Previously, DataTemplate elements were invisible to UI Automation. Beginning in 4.5, UI Automation will detect these elements. This is useful in many cases, but can break tests that depend on UIA trees not containing DataTemplate elements.|  
|Suggestion|UI Auomation tests for this app may need updated to account for the UIA tree now including previously invisible DataTemplate elements. For example, tests that expect some elements to be next to each other may now need to expect previously invisible UIA elements in between. Or tests that rely on certain counts or indexes for UIA elements may need updated with new values.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.DataTemplate.%23ctor?displayProperty=fullName><br /><br /> <xref:System.Windows.DataTemplate.%23ctor%28System.Object%29?displayProperty=fullName>|  
|Analyzers|CD0003|  
  
<a name="diagnostic4"></a>   
## 4: WPF TextBox selected text appears a different color when the text box is inactive  
  
|||  
|-|-|  
|Details|In .NET 4.5, when a WPF text box control is inactive (it doesn't have focus), the selected text inside the box will appear a different color than when the control is active.|  
|Suggestion|Previous (.NET 4.0) behavior may be restored by setting the [FrameworkCompatibilityPreferences.AreInactiveSelectionHighlightBrushKeysSupported](https://msdn.microsoft.com/library/system.windows.frameworkcompatibilitypreferences.areinactiveselectionhighlightbrushkeyssupported\(v=vs.110\).aspx) property to false.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Controls.TextBox?displayProperty=fullName>|  
|Analyzers|CD0004|  
  
<a name="diagnostic5"></a>   
## 5: List\<T>.ForEach can throw exception when modifying list item  
  
|||  
|-|-|  
|Details|Beginning in .NET 4.5, a `List<T>.ForEach` enumerator will throw an InvalidOperationException exception if an element in the calling collection is modified. Previously, this would not throw an exception but could lead to race conditions.|  
|Suggestion|Ideally, code should be fixed to not modify lists while enumerating their elements because that is never a safe operation. To revert to the previous behavior, though, an app may target .NET 4.0.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Collections.Generic.List%601.ForEach%28System.Action%7B%600%7D%29?displayProperty=fullName>|  
|Analyzers|CD0005|  
  
<a name="diagnostic6"></a>   
## 6: System.Uri parsing adheres to RFC 3987  
  
|||  
|-|-|  
|Details|URI parsing has changed in several ways in .NET 4.5. Note, however, that these changes only affect code targeting .NET 4.5. If a binary targets .NET 4.0, the old behavior will be observed. Changes to URI parsing in .NET 4.5 include:<br /><br /> URI parsing will perform normalization and character checking according to the latest IRI rules in RFC 3987<br /><br /> Unicode normalization form C will only be performed on the host portion of the URI<br /><br /> Invalid mailto: URIs will now cause an exception<br /><br /> Trailing dots at the end of a path segment are now preserved<br /><br /> `file://` URIs do not escape the `?` character<br /><br /> Unicode control characters `U+0080` through `U+009F` are not supported<br /><br /> Comma characters `,` or `%2c` are not automatically unescaped|  
|Suggestion|If the old .NET 4.0 URI parsing semantics are necessary (they often aren't), they can be used by targeting .NET 4.0. This can be accomplished by using a TargetFrameworkAttribute on the assembly, or through Visual Studio's project system UI in the 'project properties' page.|  
|Scope|Major|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Uri.%23ctor%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Uri.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Uri.%23ctor%28System.String%2CSystem.UriKind%29?displayProperty=fullName><br /><br /> <xref:System.Uri.%23ctor%28System.Uri%2CSystem.String%29?displayProperty=fullName><br /><br /> <xref:System.Uri.TryCreate%28System.String%2CSystem.UriKind%2CSystem.Uri%40%29?displayProperty=fullName><br /><br /> <xref:System.Uri.TryCreate%28System.Uri%2CSystem.String%2CSystem.Uri%40%29?displayProperty=fullName><br /><br /> <xref:System.Uri.TryCreate%28System.Uri%2CSystem.Uri%2CSystem.Uri%40%29?displayProperty=fullName>|  
|Analyzers|CD0006D<br /><br /> CD0006C<br /><br /> CD0006F<br /><br /> CD0006E<br /><br /> CD0006A<br /><br /> CD0006G<br /><br /> CD0006B|  
  
<a name="diagnostic10"></a>   
## 10: System.Uri escaping now supports RFC 3986 (http://tools.ietf.org/html/rfc3986)  
  
|||  
|-|-|  
|Details|URI escaping has changed in .NET 4.5 to support [RFC 3986](http://tools.ietf.org/html/rfc3986). Specific changes include:<br /><br /> `EscapeDataString` escapes reserved characters based on RFC 3986.<br /><br /> `EscapeUriString` does not escape reserved characters.<br /><br /> `UnescapeDataString` does not throw an exception if it encounters an invalid escape sequence.<br /><br /> Unreserved escaped characters are un-escaped.|  
|Suggestion|Update applications to not rely on UnescapeDataString to throw in the case of an invalid escape sequence. Such sequences must be detected directly now.<br /><br /> Similarly, expect that Escaped and Unescaped URI and Data strings may vary from .NET 4.0 and .NET 4.5 and should not be compared across .NET versions directly. Instead, they should be parsed and normalized in a single .NET version before any comparisons are made.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Uri.EscapeDataString%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Uri.EscapeUriString%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Uri.UnescapeDataString%28System.String%29?displayProperty=fullName>|  
|Analyzers|CD0010A<br /><br /> CD0010B<br /><br /> CD0010C|  
  
<a name="diagnostic11"></a>   
## 11: System.Net.PeerToPeer.Collaboration unavailable on Windows 8  
  
|||  
|-|-|  
|Details|The System.Net.PeerToPeer.Collaboration namespace is unavailable on Windows 8 or above.|  
|Suggestion|Apps that support Windows 8 or above must be updated to not depend on this namespace or its members.|  
|Scope|Major|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Net.PeerToPeer.Collaboration?displayProperty=fullName>|  
|Analyzers|CD0011|  
  
<a name="diagnostic12"></a>   
## 12: MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer  
  
|||  
|-|-|  
|Details|Starting with the .NET Framework 4.5, MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer (XmlSerializer object). Trying to serialize a MEF catalog throws an exception.|  
|Suggestion|Can no longer use MEF to create a serializer|  
|Scope|Major|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0012|  
  
<a name="diagnostic13"></a>   
## 13: Missing Target Framework Moniker results in 4.0 behavior  
  
|||  
|-|-|  
|Details|Applications without a [TargetFrameworkAttribute](https://msdn.microsoft.com/library/system.runtime.versioning.targetframeworkattribute\(v=vs.110\).aspx) applied at the assembly level will automatically run using the semantics (quirks) of the .NET Framework 4.0. To ensure high quality, it is recommended that all binaries be explicitly attributed with a TargetFrameworkAttribute indicating the version of the .NET Framework they were built with. Note that using a target framework moniker in a project file will caues MSBuild to automatically apply a TargetFrameworkAttribute.|  
|Suggestion|A [target framework attribute](https://msdn.microsoft.com/library/system.runtime.versioning.targetframeworkattribute\(v=vs.110\).aspx) should be supplied, either through adding the attribute directly to the assembly or by specifying a target framework in the [project file or through Visual Studio's project properties GUI](http://blogs.msdn.com/b/visualstudio/archive/2010/05/19/visual-studio-managed-multi-targeting-part-1-concepts-target-framework-moniker-target-framework.aspx).|  
|Scope|Major|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0013|  
  
<a name="diagnostic14"></a>   
## 14: No longer able to set EnableViewStateMac to false  
  
|||  
|-|-|  
|Details|ASP.NET no longer allows developers to specify `<pages enableViewStateMac="false"/>` or `<@Page EnableViewStateMac="false" %>`. The view state message authentication code (MAC) is now enforced for all requests with embedded view state. Only apps that explicitly set the EnableViewStateMac property to false are affected.|  
|Suggestion|EnableViewStateMac must be assumed to be true, and any resulting MAC errors must be resolved (as explained in [this](https://support.microsoft.com/kb/2915218) guidance, which contains multiple resolutions depending on the specifics of what is causing MAC errors).|  
|Scope|Major|  
|Version|4.5.2|  
|Type|Runtime|  
|Analyzers|CD0014|  
  
<a name="diagnostic18"></a>   
## 18: BlockingCollection\<T>.TryTakeFromAny does not throw anymore  
  
|||  
|-|-|  
|Details|If one of the input collections is marked completed, `BlockingCollection<T>.TryTakeFromAny(BlockingCollection<T>[], T)` no longer returns -1 and `BlockingCollection<T>.TakeFromAny` no longer throws an exception. This change makes it possible to work with collections when one of the collections is either empty or completed, but the other collection still has items that can be retrieved.|  
|Suggestion|If TryTakeFromAny returning -1 or TakeFromAny throwing were used for control-flow purposes in cases of a blocking collection being completed, such code should now be changed to use `.Any(b => b.IsCompleted)` to detect that condition.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Collections.Concurrent.BlockingCollection%601.TakeFromAny%28System.Collections.Concurrent.BlockingCollection%7B%600%7D%5B%5D%2C%600%40%29?displayProperty=fullName><br /><br /> <xref:System.Collections.Concurrent.BlockingCollection%601.TakeFromAny%28System.Collections.Concurrent.BlockingCollection%7B%600%7D%5B%5D%2C%600%40%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Collections.Concurrent.BlockingCollection%601.TryTakeFromAny%28System.Collections.Concurrent.BlockingCollection%7B%600%7D%5B%5D%2C%600%40%29?displayProperty=fullName><br /><br /> <xref:System.Collections.Concurrent.BlockingCollection%601.TryTakeFromAny%28System.Collections.Concurrent.BlockingCollection%7B%600%7D%5B%5D%2C%600%40%2CSystem.Int32%29?displayProperty=fullName><br /><br /> <xref:System.Collections.Concurrent.BlockingCollection%601.TryTakeFromAny%28System.Collections.Concurrent.BlockingCollection%7B%600%7D%5B%5D%2C%600%40%2CSystem.TimeSpan%29?displayProperty=fullName>|  
|Analyzers|CD0018A<br /><br /> CD0018B|  
  
<a name="diagnostic19"></a>   
## 19: XmlSchemaException now sets line positions properly  
  
|||  
|-|-|  
|Details|If the LoadOptions.SetLineInfo value is passed to the Load method and a validation error occurs, the XmlSchemaException.LineNumber and XmlSchemaException.LinePosition properties now contain line information.|  
|Suggestion|Exception-handling code that assumes XmlSchemaException.LineNumber and XmlSchemaException.LinePosition will not be set should be updated since these properties will now be set properly when SetLineInfo is used while loading XML.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Xml.Linq.LoadOptions?displayProperty=fullName>|  
|Analyzers|CD0019|  
  
<a name="diagnostic20"></a>   
## 20: System.Activities is now APTCA  
  
|||  
|-|-|  
|Details|The assembly is marked with the AllowPartiallyTrustedCallersAttribute attribute.|  
|Suggestion|Derived classes cannot be marked with the SecurityCriticalAttribute. Previously, derived types had to be marked with the SecurityCriticalAttribute. However, this change should have no real impact.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0020|  
  
<a name="diagnostic21"></a>   
## 21: WorkFlow 3.0 types are obsolete  
  
|||  
|-|-|  
|Details|Windows Workflow Foundation (WWF) 3.0 APIs (those from the System.Workflow namespace) are now obsolete.|  
|Suggestion|New WWF 4.0 APIs (in System.Activities) should be used instead. An example of using the new APIs can be found [here](https://msdn.microsoft.com/library/jj205427.aspx) and further guidance is available [here](http://blogs.msdn.com/b/workflowteam/archive/2012/02/08/deprecatingwf3.aspx). Alternatively, since the WWF 3.0 APIs are still supported, they may be used and the build-time warning avoided either by suppressing it or by using an older compiler.|  
|Scope|Major|  
|Version|4.5|  
|Type|Retargeting|  
|Analyzers|CD0021|  
  
<a name="diagnostic22"></a>   
## 22: Some WorkFlow drag and drop APIs are obsolete  
  
|||  
|-|-|  
|Details|This WorkFlow Drag/Drop API is obsolete and will cause compiler warnings if the app is rebuilt against 4.5.|  
|Suggestion|New [DragDropHelper](https://msdn.microsoft.com/library/system.activities.presentation.dragdrophelper\(v=vs.110\).aspx) APIs that support operations with multiple objects should be used instead. Alternatively, the build warnings can be suppressed or they can be avoided by using an older compiler. The APIs are still supported.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Activities.Presentation.DragDropHelper.DoDragMove%28System.Activities.Presentation.WorkflowViewElement%2CSystem.Windows.Point%29?displayProperty=fullName><br /><br /> <xref:System.Activities.Presentation.DragDropHelper.GetCompositeView%28System.Windows.DragEventArgs%29?displayProperty=fullName><br /><br /> <xref:System.Activities.Presentation.DragDropHelper.GetDraggedModelItem%28System.Windows.DragEventArgs%29?displayProperty=fullName><br /><br /> <xref:System.Activities.Presentation.DragDropHelper.GetDroppedObject%28System.Windows.DependencyObject%2CSystem.Windows.DragEventArgs%2CSystem.Activities.Presentation.EditingContext%29?displayProperty=fullName>|  
|Analyzers|CD0022|  
  
<a name="diagnostic23"></a>   
## 23: New (ambiguous) Dispatcher.Invoke overloads could result in different behavior  
  
|||  
|-|-|  
|Details|The .NET Framework 4.5 adds new overloads to Dispatcher.Invoke that include a parameter of type System.Action. When existing code is recompiled, compilers may resolve calls to Dispatcher.Invoke methods that have a Delegate parameter as calls to Dispatcher.Invoke methods with an System.Action parameter. If a call to a Dispatcher.Invoke overload with a Delegate parameter is resolved as a call to a Dispatcher.Invoke overload with an System.Action parameter, the following differences in behavior may occur:<br /><br /> If an exception occurs, the Dispatcher.UnhandledExceptionFilter and Dispatcher.UnhandledException events are not raised. Instead, exceptions are handled by the UnobservedTaskException event.<br /><br /> Calls to some members, such as DispatcherOperation.Result, block until the operation has completed.|  
|Suggestion|To avoid ambiguity (and potential differences in exception handling or blocking behaviors), code calling Dispatcher.Invoke can pass an empty object[] as a second parameter to the Invoke call to be sure of resolving to the .NET 4.0 method overload.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Windows.Threading.Dispatcher.Invoke%28System.Delegate%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Windows.Threading.Dispatcher.Invoke%28System.Delegate%2CSystem.TimeSpan%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Windows.Threading.Dispatcher.Invoke%28System.Delegate%2CSystem.TimeSpan%2CSystem.Windows.Threading.DispatcherPriority%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Windows.Threading.Dispatcher.Invoke%28System.Delegate%2CSystem.Windows.Threading.DispatcherPriority%2CSystem.Object%5B%5D%29?displayProperty=fullName>|  
|Analyzers|CD0023|  
  
<a name="diagnostic24"></a>   
## 24: EncoderParameter ctor is obsolete  
  
|||  
|-|-|  
|Details|The `EncoderParameter.EncoderParameter(Encoder, Int32, Int32, Int32)` constructor is obsolete now and will introduce build warnings if used.|  
|Suggestion|Although the `EncoderParameter.EncoderParameter(Encoder, Int32, Int32, Int32)` constructor will continue to work, the following constructor should be used instead to avoid the obsolete build warning when re-compiling code with .NET 4.5 tools: [EncoderParameter.EncoderParameter(Encoder, Int32, EncoderParameterValueType, IntPtr)](https://msdn.microsoft.com/library/hh875096\(v=vs.110\).aspx).|  
|Scope|Minor|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Drawing.Imaging.EncoderParameter.%23ctor%28System.Drawing.Imaging.Encoder%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%29?displayProperty=fullName>|  
|Analyzers|CD0024|  
  
<a name="diagnostic26"></a>   
## 26: Change in behavior for Task.WaitAll methods with time-out arguments  
  
|||  
|-|-|  
|Details|Task.WaitAll behavior was made more consistent in .NET 4.5.<br /><br /> In the .NET Framework 4, these methods behaved inconsistently. When the time-out expired, if one or more tasks were completed or canceled before the method call, the method threw an AggregateException exception. When the time-out expired, if no tasks were completed or canceled before the method call, but one or more tasks entered these states after the method call, the method returned false.<br />In the .NET Framework 4.5, these method overloads now return false if any tasks are still running when the time-out interval expired, and they throw an AggregateException exception only if an input task was cancelled (regardless of whether it was before or after the method call) and no other tasks are still running.|  
|Suggestion|If an AggregateException was being caught as a means of detecting a task that was cancelled prior to the WaitAll call being invoked, that code should instead do the same detection via the IsCanceled property (for example: .Any(t => t.IsCanceled)) since .NET 4.6 will only throw in that case if all awaited tasks are completed prior to the timeout.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Threading.Tasks.Task.WaitAll%28System.Threading.Tasks.Task%5B%5D%2CSystem.Int32%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.WaitAll%28System.Threading.Tasks.Task%5B%5D%2CSystem.Int32%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.WaitAll%28System.Threading.Tasks.Task%5B%5D%2CSystem.TimeSpan%29?displayProperty=fullName>|  
|Analyzers|CD0026|  
  
<a name="diagnostic27"></a>   
## 27: Change in behavior in Data Definition Language (DDL) APIs  
  
|||  
|-|-|  
|Details|The behavior of DDL APIs when AttachDBFilename is specified has changed as follows:<br /><br /> Connection strings need not specify an Initial Catalog value. Previously, both AttatchDBFilename and Initial Catalog were required.<br /><br /> If both AttatchDBFilename and Initial Catalog are specified and the given MDF file exists, the ObjectContext.DatabaseExists method returns true. Previously, it returned false.<br /><br /> If both AttatchDBFilename and Initial Catalog are specified and the given MDF file exists, calling the ObjectContext.DeleteDatabase method deletes the files.<br /><br /> If ObjectContext.DeleteDatabase is called when the connection string specifies an AttachDBFilename value with an MDF that doesn't exist and an Initial Catalog that doesn't exist, the method throws an InvalidOperationException exception. Previously, it threw a SqlException exception.|  
|Suggestion|These changes make it easier to build tools and applications that use the DDL APIs. These changes can affect application compatibility in the following scenarios:<br /><br /> The user writes code that executes a DROP DATABASE command directly instead of calling ObjectContext.DeleteDatabase if ObjectContext.DatabaseExists returns true. This breaks existing code If the database is not attached but the MDF file exists.<br /><br /> The user writes code that expects the ObjectContext.DeleteDatabase method to throw a SqlException exception rather than an InvalidOperationException exception when the Initial Catalog and MDF file don't exist.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0027|  
  
<a name="diagnostic28"></a>   
## 28: MachineKey.Encode and MachineKey.Decode methods are now obsolete  
  
|||  
|-|-|  
|Details|These methods are now obsolete. Compilation of code that calls these methods produces a compiler warning.|  
|Suggestion|The recommended alternatives are [MachineKey.Protect](https://msdn.microsoft.com/library/system.web.security.machinekey.protect\(v=vs.110\).aspx) and [MachineKey.Unprotect](https://msdn.microsoft.com/library/system.web.security.machinekey.unprotect\(v=vs.110\).aspx). Alternatively, the build warnings can be suppressed or they can be avoided by using an older compiler. The APIs are still supported.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Web.Security.MachineKey.Decode%28System.String%2CSystem.Web.Security.MachineKeyProtection%29?displayProperty=fullName><br /><br /> <xref:System.Web.Security.MachineKey.Encode%28System.Byte%5B%5D%2CSystem.Web.Security.MachineKeyProtection%29?displayProperty=fullName>|  
|Analyzers|CD0028|  
  
<a name="diagnostic29"></a>   
## 29: The Replace method in OData URLs is disabled by default  
  
|||  
|-|-|  
|Details|Beginning in the .NET Framework 4.5, the Replace method in OData URLs is disabled by default. When OData Replace is disabled (now by default), any user requests including replace functions (which are uncommon) will fail.|  
|Suggestion|If the replace method is required (which is uncommon), it can be re-enabled through a [config settings](https://msdn.microsoft.com/library/system.data.services.configuration.dataservicesfeaturessection.replacefunction.aspx). However, an enabled replace method can open security vulnerabilities and should only be used after careful review.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Data.Services.DataService%601?displayProperty=fullName>|  
|Analyzers|CD0029|  
  
<a name="diagnostic30"></a>   
## 30: System.ServiceModel.Web.WebServiceHost object no longer adds a default endpoint  
  
|||  
|-|-|  
|Details|The System.ServiceModel.Web.WebServiceHost object no longer adds a default endpoint if an explicit endpoint has been added by application code.|  
|Suggestion|If users will expect to be able to connect to a default endpoint and other explicit endpoints have been added to the WebServiceHost, default endpoints should also be added explicitly (using AddDefaultEndpoints).|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%28System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%28System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%2CSystem.Uri%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%28System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%28System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%2CSystem.Uri%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint%28System.ServiceModel.Description.ServiceEndpoint%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint%28System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint%28System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%2CSystem.Uri%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint%28System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%29?displayProperty=fullName><br /><br /> <xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint%28System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%2CSystem.Uri%29?displayProperty=fullName>|  
|Analyzers|CD0030A<br /><br /> CD0030B|  
  
<a name="diagnostic31"></a>   
## 31: EventSource.WriteEvent impls must pass WriteEvent the same parameters that it received (plus ID)  
  
|||  
|-|-|  
|Details|The runtime now enforces the contract that specifies the following: A class derived from EventSource that defines an ETW event method must call the base class EventSource.WriteEvent method with the event ID followed by the same arguments that the ETW event method was passed.|  
|Suggestion|An IndexOutOfRangeException exception is thrown if an EventListener reads EventSource data in process for an event source that violates this contract.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Runtime|  
|Analyzers|CD0031|  
  
<a name="diagnostic32"></a>   
## 32: MinFreeMemoryPercentageToActiveService is now respected  
  
|||  
|-|-|  
|Details|This setting establishes the minimum memory that must be available on the server before a WCF service can be activated. It is designed to prevent OutOfMemoryException exceptions. In the .NET Framework 4.5, this setting had no effect. In the .NET Framework 4.5.1, the setting is observed.|  
|Suggestion|An exception occurs if the free memory available on the web server is less than the percentage defined by the configuration setting. Some WCF services that successfully started and ran in a constrained memory environment may now fail.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Runtime|  
|Analyzers|CD0032|  
  
<a name="diagnostic33"></a>   
## 33: XmlTextReader DTD entity expansion is limited to 10,000,000 characters  
  
|||  
|-|-|  
|Details|DTD entity expansion is now limited to 10,000,000 characters. Loading XML files without DTD entity expansion or with limited DTD entity expansion is unaffected. Files with DTD entities that expand to more than 10,000,000 characters fail to load, and now throw an exception.|  
|Suggestion|If the limit of DTD entity expansion is too low 10,000,000, the value can be overridden with the [XmlReaderSettings.MaxCharactersFromEntities](https://msdn.microsoft.com/library/system.xml.xmlreadersettings.maxcharactersfromentities%28v=vs.110%29.aspx) property. An XmlReaderSettings with the proper MaxCharactersFromEntity value can be passed to [XmlReader.Create](https://msdn.microsoft.com/library/System.Xml.XmlReader.Create\(v=vs.110\).aspx)|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Xml.XmlTextReader.%23ctor?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.IO.Stream%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.IO.Stream%2CSystem.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.IO.Stream%2CSystem.Xml.XmlNodeType%2CSystem.Xml.XmlParserContext%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.IO.TextReader%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.IO.TextReader%2CSystem.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.IO.Stream%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.IO.Stream%2CSystem.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.IO.TextReader%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.IO.TextReader%2CSystem.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.String%2CSystem.Xml.XmlNodeType%2CSystem.Xml.XmlParserContext%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader.%23ctor%28System.Xml.XmlNameTable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.XmlTextReader?displayProperty=fullName>|  
|Analyzers|CD0033|  
  
<a name="diagnostic35"></a>   
## 35: XSLT style sheet exception message changed  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, the text of the error message when an XSLT file is too complex is "The style sheet is too complex." In previous versions, the error message was "XSLT compile error." Application code that depends on the text of the error message will no longer work. However, the exception types remain the same, so this change should have no real impact.|  
|Suggestion|Update any app code depending on the excepton message from this error condition to expect the new message, or (even better) update the code to depend only on the exception type ([XsltException](https://msdn.microsoft.com/library/system.xml.xsl.xsltexception\(v=vs.110\).aspx)), which has not changed.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Reflection.MethodInfo%2CSystem.Byte%5B%5D%2CSystem.Type%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.String%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Type%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Xml.XPath.IXPathNavigable%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Xml.XPath.IXPathNavigable%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Xml.XmlReader%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Xml.XmlReader%2CSystem.Xml.Xsl.XsltSettings%2CSystem.Xml.XmlResolver%29?displayProperty=fullName>|  
|Analyzers|CD0035|  
  
<a name="diagnostic36"></a>   
## 36: WF serializes Expressions.Literal\<T> DateTimes differently now (breaks custom XAML parsers)  
  
|||  
|-|-|  
|Details|The associated [ValueSerializer](https://msdn.microsoft.com/library/system.windows.markup.valueserializer\(v=vs.110\).aspx) object will convert a DateTime or DateTimeOffset object whose Second and Millisecond components are non-zero and (for a DateTime value) whose DateTime.Kind property is not Unspecified to property element syntax instead of a string. This change allows DateTime and DateTimeOffset values to be round-tripped. Custom XAML parsers that assume that input XAML is in the attribute syntax will not function correctly.|  
|Suggestion|This change allows DateTime and DateTimeOffset values to be round-tripped. Custom XAML parsers that assume that input XAML is in the attribute syntax will not function correctly.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0036|  
  
<a name="diagnostic37"></a>   
## 37: New enum values in WPF's PageRangeSelection  
  
|||  
|-|-|  
|Details|Two new members (CurrentPage and SelectedPage) have been added to the [PageRangeSelection](https://msdn.microsoft.com/library/system.windows.controls.pagerangeselection\(v=vs.110\).aspx) enum.|  
|Suggestion|In most cases, these changes won't impact user code. Code that depends on a particular number of elements existing in Enum.GetNames or Enum.GetValues calls on the PageRangeSelection type should be modified, though.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Controls.PageRangeSelection?displayProperty=fullName>|  
|Analyzers|CD0037|  
  
<a name="diagnostic38"></a>   
## 38: WPF DispatcherSynchronizationContext.CreateCopy now returns a new copy instead of the current instance  
  
|||  
|-|-|  
|Details|In the .NET Framework 4, DispatcherSynchronizationContext.CreateCopy() returned a reference to the current instance, primarily as a performance optimization. In the .NET Framework 4.5, it returns a new instance which makes it possible for the first time to conclude that equal references indicate the executing thread is in the correct synchronization context.  It is unlikely that code that checks the identity of these references will be affected, but because of the change, code that calls DispatcherSynchronizationContext.CreateCopy should be tested as part of migration to the .NET Framework 4.5 or newer.|  
|Suggestion|Be aware that DispatcherSynchronizationContext.CreateCopy() will now return a new SynchronizationContext object.  Previously, code that used equivalence of references generated this way was not actually checking whether it was in the proper context, but does when built against .NET 4.5 or newer.  While unlikely to cause issues, exercising the affected code paths should be enough to determine if this poses any problem.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy?displayProperty=fullName>|  
|Analyzers|CD0038|  
  
<a name="diagnostic39"></a>   
## 39: System.Threading.Tasks.Task no longer throw ObjectDisposedException after object is disposed  
  
|||  
|-|-|  
|Details|Except for Task.IAsyncResult.AsyncWaitHandle, System.Threading.Tasks.Task methods no longer throw an ObjectDisposedException exception after the object is disposed.<br />This change supports the use of cached tasks. For example, a method can return a cached task to represent an already completed operation instead of allocating a new task. This was impossible in previous .NET Framework versions, because any consumer of the task could dispose of it, which rendered it unusable.|  
|Suggestion|Be aware that Task methods may no longer throw ObjectDisposedExceptions in cases when the object is disposed. If an app was depending on this exception to know that a task was disposed, it should be updated to explicitly check the task's status using [Task.Status](https://msdn.microsoft.com/library/system.threading.tasks.task.status\(v=vs.110\).aspx).|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0039|  
  
<a name="diagnostic40"></a>   
## 40: Different exception handling for ObjectContext.CreateDatabase and DbProviderServices.CreateDatabase methods  
  
|||  
|-|-|  
|Details|Beginning in .NET 4.5, if database creation fails, `CreateDatabase` methods will attempt to drop the empty database. If that operation succeeds, the original `SQLException` will be propagated (instead of the `InvalidOperationException` that was always thrown in .NET 4.0)|  
|Suggestion|When catching an InvalidOperationException while executing ObjectContext.CreateDatabase or DbProviderServices.CreateDatabase, SQLExceptions should now also be caught.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Data.Common.DbProviderServices.CreateDatabase%28System.Data.Common.DbConnection%2CSystem.Nullable%7BSystem.Int32%7D%2CSystem.Data.Metadata.Edm.StoreItemCollection%29?displayProperty=fullName><br /><br /> <xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=fullName>|  
|Analyzers|CD0040|  
  
<a name="diagnostic41"></a>   
## 41: ObjectContext.Translate and ObjectContext.ExecuteStoreQuery now support enum type  
  
|||  
|-|-|  
|Details|In .NET 4.0, the generic parameter `T` of `ObjectContext.Translate` and `ObjectContext.ExecuteStoreQuery` methods could not be an enum. That scenario is now supported.|  
|Suggestion|If Translate or ExecuteStoreQuery was called on an enum type in .NET 4.0, '0' was returned. If that behavior was desirable, the calls should be replaced with a constant 0 (or the enum equivalent of it).|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601%28System.String%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Data.Objects.ObjectContext.ExecuteStoreQuery%60%601%28System.String%2CSystem.String%2CSystem.Data.Objects.MergeOption%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Data.Objects.ObjectContext.Translate%60%601%28System.Data.Common.DbDataReader%29?displayProperty=fullName><br /><br /> <xref:System.Data.Objects.ObjectContext.Translate%60%601%28System.Data.Common.DbDataReader%2CSystem.String%2CSystem.Data.Objects.MergeOption%29?displayProperty=fullName>|  
|Analyzers|CD0041|  
  
<a name="diagnostic42"></a>   
## 42: Enumerable.Empty\<TResult> always returns cached instance  
  
|||  
|-|-|  
|Details|Beginning in .NET 4.5, `Enumerable.Empty` always returns a cached internal instance `IEnumerable<T>`.<br /><br /> Previously, `Enumerable.Empty` would cache an empty `IEnumerable<T>` at the time the API was called, meaning that in some conditions in which `Enumerable.Empty` was called rapidly and concurrently, different instances of the type could be returned for different calls to the API.|  
|Suggestion|Because the previous behavior was non-deterministic, code is unlikely to depend on it. However, in the unlikely case that empty enumerables are being compared and expected to sometimes be unequal, explicit empty arrays should be created (`new T[0]`) instead of using `Enumerable.Empty`.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Linq.Enumerable.Empty%60%601?displayProperty=fullName>|  
|Analyzers|CD0042|  
  
<a name="diagnostic43"></a>   
## 43: HttpRequest.ContentEncoding property prohibits UTF7  
  
|||  
|-|-|  
|Details|Beginning in .NET Framework 4.5, UTF-7 encoding is prohibited in HttpRequests' bodies. Data for applications that depend on incoming UTF-7 data will not decode properly in some cases.|  
|Suggestion|Ideally, applications should be updated to not use UTF-7 encoding in HttpRequests. Alternatively, legacy behavior can be restored by using the `aspnet:AllowUtf7RequestContentEncoding` attribute of the [appSettings](https://msdn.microsoft.com/library/hh975440\(v=vs.110\).aspx) element.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Web.HttpRequest.ContentEncoding?displayProperty=fullName>|  
|Analyzers|CD0043|  
  
<a name="diagnostic44"></a>   
## 44: HttpUtility.JavaScriptStringEncode escapes ampersand  
  
|||  
|-|-|  
|Details|Starting with the .NET Framework 4.5, JavaScriptStringEncode escapes the ampersand (&) character.|  
|Suggestion|If your app depends on the previous behavior of this method, you can add an aspnet:JavaScriptDoNotEncodeAmpersand setting to the [ASP.NET appSettings element](https://msdn.microsoft.com/library/hh975440\(v=vs.110\).aspx) in your configuration file.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Web.HttpUtility.JavaScriptStringEncode%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Web.HttpUtility.JavaScriptStringEncode%28System.String%2CSystem.Boolean%29?displayProperty=fullName>|  
|Analyzers|CD0044A<br /><br /> CD0044B|  
  
<a name="diagnostic46"></a>   
## 46: EventListener truncates strings with embedded nulls  
  
|||  
|-|-|  
|Details|EventListener truncates strings with embedded nulls. Null characters are not supported by the EventSource class. The change only affects apps that use EventListener to read EventSource data in process and that use null characters as delimiters.|  
|Suggestion|EventSource data should be updated, if possible, to not use embedded null characters.|  
|Scope|Edge|  
|Version|4.5.1|  
|Type|Runtime|  
|Affected APIs|<xref:System.Diagnostics.Tracing.EventListener.%23ctor?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Tracing.EventListener.EnableEvents%28System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%29?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Tracing.EventListener.EnableEvents%28System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%2CSystem.Diagnostics.Tracing.EventKeywords%29?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Tracing.EventListener.EnableEvents%28System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%2CSystem.Diagnostics.Tracing.EventKeywords%2CSystem.Collections.Generic.IDictionary%7BSystem.String%2CSystem.String%7D%29?displayProperty=fullName>|  
|Analyzers|CD0046|  
  
<a name="diagnostic48"></a>   
## 48: ObsoleteAttribute exports as both ObsoleteAttribute and DeprecatedAttribute in WinMD scenarios  
  
|||  
|-|-|  
|Details|When you create a Windows Metadata library (.winmd file), the ObsoleteAttribute attribute is exported as both ObsoleteAttribute and Windows.Foundation.DeprecatedAttribute.|  
|Suggestion|Recompilation of existing source code that uses the ObsoleteAttribute attribute may generate warnings when consuming that code from C++/CX or JavaScript.<br /><br /> We do not recommend applying both ObsoleteAttribute and Windows.Foundation.DeprecatedAttribute to code in managed assemblies; it may result in build warnings.|  
|Scope|Edge|  
|Version|4.5.1|  
|Type|Retargeting|  
|Analyzers|CD0048A<br /><br /> CD0048B|  
  
<a name="diagnostic49"></a>   
## 49: ResolveAssemblyReference task now warns on dependencies with the wrong architecture  
  
|||  
|-|-|  
|Details|The task emits a warning, MSB3270, which indicates that a reference or any of its dependencies does not match the app's architecture. For example, this occurs if an app that was compiled with the anycpu option includes an x86 reference. Such a scenario could result in an app failure at run time (in this case, if the app is deployed as an x64 process).|  
|Suggestion|There are two areas of impact:<br /><br /> Recompilation generates warnings that did not appear when the app was compiled under a previous version of MSBuild. However, because the warning identifies a possible source of runtime failure, it should be investigated and addressed.<br /><br /> If warnings are treated as errors, the app will fail to compile.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Retargeting|  
|Analyzers|CD0049|  
  
<a name="diagnostic51"></a>   
## 51: WPF TextBox defaults to undo limit of 100  
  
|||  
|-|-|  
|Details|In .NET 4.5, the default undo limit for a WPF textbox is 100 (as opposed to being unlimited in .NET 4.0)|  
|Suggestion|If an undo limit of 100 is too low, the limit can be set explicitly with the TextBox's UndoLimit property|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Controls.TextBox?displayProperty=fullName>|  
|Analyzers|CD0051|  
  
<a name="diagnostic55"></a>   
## 55: Exceptions during unobserved processing in System.Threading.Tasks.Task no longer propagate on finalizer thread  
  
|||  
|-|-|  
|Details|Because the System.Threading.Tasks.Task class represents an asynchronous operation, it catches all non-severe exceptions that occur during asynchronous processing. In the .NET Framework 4.5, if an exception is not observed and your code never waits on the task, the exception will no longer propagate on the finalizer thread and crash the process during garbage collection. This change enhances the reliability of applications that use the Task class to perform unobserved asynchronous processing.|  
|Suggestion|If an app depends on unobserved asynchronous exceptions propagating to the finalizer thread, the previous behavior can be restored by providing an appropriate handler for the [TaskScheduler.UnobservedTaskException](https://msdn.microsoft.com/library/system.threading.tasks.taskscheduler.unobservedtaskexception\(v=vs.110\).aspx) event, or by setting a [runtime configuration element](https://msdn.microsoft.com/library/jj160346%28v=vs.110%29.aspx).|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Threading.Tasks.Task.Run%28System.Action%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%28System.Action%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%28System.Func%7BSystem.Threading.Tasks.Task%7D%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%28System.Func%7BSystem.Threading.Tasks.Task%7D%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%60%601%28System.Func%7BSystem.Threading.Tasks.Task%7B%60%600%7D%7D%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%60%601%28System.Func%7BSystem.Threading.Tasks.Task%7B%60%600%7D%7D%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%60%601%28System.Func%7B%60%600%7D%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Run%60%601%28System.Func%7B%60%600%7D%2CSystem.Threading.CancellationToken%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Start?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.Task.Start%28System.Threading.Tasks.TaskScheduler%29?displayProperty=fullName>|  
|Analyzers|CD0055|  
  
<a name="diagnostic58"></a>   
## 58: IAsyncResult.CompletedSynchronously property must be correct for the resulting task to complete  
  
|||  
|-|-|  
|Details|When calling TaskFactory.FromAsync, the implementation of the IAsyncResult.CompletedSynchronously property must be correct for the resulting task to complete. That is, the property must return true if, and only if, the implementation completed synchronously. Previously, the property was not checked.|  
|Suggestion|If IAsyncResult implementations correctly return true for the CompletedSynchronusly property only when a task completed synchronously, then no break will be observed. Users should review IAsyncResult implementations they own (if any) to ensure that they correctly evaluate whether a task completed synchronously or not.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Threading.Tasks.TaskFactory.FromAsync%28System.Func%7BSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%28System.Func%7BSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%28System.IAsyncResult%2CSystem.Action%7BSystem.IAsyncResult%7D%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%28System.IAsyncResult%2CSystem.Action%7BSystem.IAsyncResult%7D%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%28System.IAsyncResult%2CSystem.Action%7BSystem.IAsyncResult%7D%2CSystem.Threading.Tasks.TaskCreationOptions%2CSystem.Threading.Tasks.TaskScheduler%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.Func%7BSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%600%7D%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.Func%7BSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%600%7D%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.Func%7B%60%600%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.Func%7B%60%600%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.IAsyncResult%2CSystem.Func%7BSystem.IAsyncResult%2C%60%600%7D%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.IAsyncResult%2CSystem.Func%7BSystem.IAsyncResult%2C%60%600%7D%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%601%28System.IAsyncResult%2CSystem.Func%7BSystem.IAsyncResult%2C%60%600%7D%2CSystem.Threading.Tasks.TaskCreationOptions%2CSystem.Threading.Tasks.TaskScheduler%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%602%28System.Func%7B%60%600%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%601%7D%2C%60%600%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%602%28System.Func%7B%60%600%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%601%7D%2C%60%600%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%602%28System.Func%7B%60%600%2C%60%601%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2C%60%601%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%602%28System.Func%7B%60%600%2C%60%601%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2C%60%601%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%603%28System.Func%7B%60%600%2C%60%601%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%602%7D%2C%60%600%2C%60%601%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%603%28System.Func%7B%60%600%2C%60%601%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%602%7D%2C%60%600%2C%60%601%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%603%28System.Func%7B%60%600%2C%60%601%2C%60%602%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2C%60%601%2C%60%602%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%603%28System.Func%7B%60%600%2C%60%601%2C%60%602%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Action%7BSystem.IAsyncResult%7D%2C%60%600%2C%60%601%2C%60%602%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%604%28System.Func%7B%60%600%2C%60%601%2C%60%602%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%603%7D%2C%60%600%2C%60%601%2C%60%602%2CSystem.Object%29?displayProperty=fullName><br /><br /> <xref:System.Threading.Tasks.TaskFactory.FromAsync%60%604%28System.Func%7B%60%600%2C%60%601%2C%60%602%2CSystem.AsyncCallback%2CSystem.Object%2CSystem.IAsyncResult%7D%2CSystem.Func%7BSystem.IAsyncResult%2C%60%603%7D%2C%60%600%2C%60%601%2C%60%602%2CSystem.Object%2CSystem.Threading.Tasks.TaskCreationOptions%29?displayProperty=fullName>|  
|Analyzers|CD0058|  
  
<a name="diagnostic59"></a>   
## 59: Log file name created by the ObjectContext.CreateDatabase method has changed to match SQL Server specifications  
  
|||  
|-|-|  
|Details|When the CreateDatabase method is called either directly or by using Code First with the SqlClient provider and an AttachDBFilename value in the connection string, it creates a log file named filename_log.ldf instead of filename.ldf (where filename is the name of the file specified by the AttachDBFilename value). This change improves debugging by providing a log file named according to SQL Server specifications.|  
|Suggestion|If the log file name is important for an app, the app should be updated to expect the standard _log.ldf file name format.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=fullName>|  
|Analyzers|CD0059|  
  
<a name="diagnostic60"></a>   
## 60: Page.LoadComplete event no longer causes System.Web.UI.WebControls.EntityDataSource control to invoke data binding  
  
|||  
|-|-|  
|Details|The `Page.LoadComplete` event no longer causes the System.Web.UI.WebControls.EntityDataSource control to invoke data binding for changes to create/update/delete parameters. This change eliminates an extraneous trip to the database, prevents the values of controls from being reset, and produces behavior that is consistent with other data controls, such as SqlDataSource and ObjectDataSource. This change produces different behavior in the unlikely event that applications rely on invoking data binding in the `Page.LoadComplete` event.|  
|Suggestion|If there is a need for databinding, manually invoke databind in an event that is earlier in the post-back.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0060|  
  
<a name="diagnostic61"></a>   
## 61: WebUtility.HtmlDecode no longer decodes invalid input sequences  
  
|||  
|-|-|  
|Details|By default, decoding methods no longer decode an invalid input sequence into an invalid UTF-16 string. Instead, they return the original input.|  
|Suggestion|The change in decoder output should matter only if you store binary data instead of UTF-16 data in strings. To explicitly control this behavior, set the `aspnet:AllowRelaxedUnicodeDecoding` attribute of the [appSettings](https://msdn.microsoft.com/library/ms228154\(v=vs.110\).aspx) element to true to enable legacy behavior or to false to enable the current behavior.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Net.WebUtility.HtmlDecode%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Net.WebUtility.HtmlDecode%28System.String%2CSystem.IO.TextWriter%29?displayProperty=fullName><br /><br /> <xref:System.Net.WebUtility.UrlDecode%28System.String%29?displayProperty=fullName>|  
|Analyzers|CD0061|  
  
<a name="diagnostic63"></a>   
## 63: Apps published with ClickOnce that use a SHA-256 code-signing certificate may fail on Windows 2003  
  
|||  
|-|-|  
|Details|The executable is signed with SHA256. Previously, it was signed with SHA1 regardless of whether the code-signing certificate was SHA-1 or SHA-256. This applies to:<br /><br /> All applications built with Visual Studio 2012 or later.<br /><br /> Applications built with Visual Studio 2010 or earlier on systems with the .NET Framework 4.5 present.<br /><br /> In addition, if the .NET Framework 4.5 or later is present, the ClickOnce manifest is also signed with SHA-256 for SHA-256 certificates regardless of the .NET Framework version against which it was compiled.|  
|Suggestion|The change in signing the ClickOnce executable affects only Windows Server 2003 systems; they require that KB 938397 be installed.<br /><br /> The change in signing the manifest with SHA-256 even when an app targets the .NET Framework 4.0 or earlier versions introduces a runtime dependency on the .NET Framework 4.5 or a later version.|  
|Scope|Edge|  
|Version|4.5-4.6|  
|Type|Retargeting|  
|Analyzers|CD0063|  
  
<a name="diagnostic68"></a>   
## 68: DbParameter.Precision and DbParameter.Scale are now public virtual members  
  
|||  
|-|-|  
|Details|DbParameter.Precision and DbParameter.Scale are implemented as public virtual properties. They replace the corresponding explicit interface implementations, DbParameter.IDbDataParameter.Precision and DbParameter.IDbDataParameter.Scale.|  
|Suggestion|When re-building an ADO.NET database provider, these differences will require the 'override' keyword to be applied to the Precision and Scale properties. This is only needed when re-building the components; exisiting binaries will continue to work.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Data.Common.DbParameter.Precision?displayProperty=fullName><br /><br /> <xref:System.Data.Common.DbParameter.Scale?displayProperty=fullName>|  
|Analyzers|CD0068|  
  
<a name="diagnostic73"></a>   
## 73: DataObject.GetData now retrieves data as UTF-8  
  
|||  
|-|-|  
|Details|For apps that target the .NET Framework 4 or that run on the .NET Framework 4.5.1 or earlier versions, DataObject.GetData retrieves HTML-formatted data as an ASCII string. As a result, non-ASCII characters (characters whose ASCII codes are greater than 0x7F) are represented by two random characters.<br /><br /> For apps that target the .NET Framework 4.5 or later and run on the .NET Framework 4.5.2, `DataObject.GetData` retrieves HTML-formatted data as UTF-8, which represents characters greater than 0x7F correctly.|  
|Suggestion|If you implemented a workaround for the encoding problem with HTML-formatted strings (for example, by explicitly encoding the HTML string retrieved from the Clipboard by passing it to the UTF8Encoding.GetString method) and you're retargeting your app from version 4 to 4.5, that workaround should be removed.<br /><br /> If the old behavior is needed for some reason, the app can target the .NET Framework 4.0 to get that behavior.|  
|Scope|Edge|  
|Version|4.5.2|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Windows.DataObject.GetData%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Windows.DataObject.GetData%28System.String%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Windows.DataObject.GetData%28System.Type%29?displayProperty=fullName>|  
|Analyzers|CD0073|  
  
<a name="diagnostic75"></a>   
## 75: TargetFrameworkName for default app domain no longer defaults to null if not set  
  
|||  
|-|-|  
|Details|The TargetFrameworkName was previously null in the default app domain, unless it was explicitly set. Beginning in 4.6, the TargetFrameworkName property for the default app domain will have a default value derived from the TargetFrameworkAttribute (if one is present). Non-default app domains will continue to inherit their TargetFrameworkName from the default app domain (which will not default to null in 4.6) unless it is explicitly overridden.|  
|Suggestion|Code should be updated to not depend on `AppDomainSetup.TargetFrameworkName` defaulting to null. If it is required that this property continue to evaluate to null, it can be explicitly set to that value.|  
|Scope|Edge|  
|Version|4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.AppDomainSetup.TargetFrameworkName?displayProperty=fullName>|  
|Analyzers|CD0075B<br /><br /> CD0075A|  
  
<a name="diagnostic76"></a>   
## 76: X509Certificate2.ToString(bool) does not throw now when .NET cannot handle the certificate  
  
|||  
|-|-|  
|Details|Previously, this method would throw if 'true' was passed for the verbose parameter and there were certificates installed that weren't supported by the .Net Framework. Now, the method will succeed and return a valid string that omits the inaccessible portions of the certifiate.|  
|Suggestion|Any code depending on X509Certificate2.ToString(bool) should be updated to expect that the returned string may exclude some certificate data (such as public key, private key, and extensions) in some cases in which the API would have previously thrown.|  
|Scope|Edge|  
|Version|4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString%28System.Boolean%29?displayProperty=fullName>|  
|Analyzers|CD0076|  
  
<a name="diagnostic77"></a>   
## 77: Reflection objects can no longer be passed from managed code to out-of-process DCOM clients  
  
|||  
|-|-|  
|Details|Reflection objects can no longer be passed from managed code to out-of-process DCOM clients. The following types are affected:<br /><br /> Assembly<br /><br /> MemberInfo (and its derived types, including FieldInfo, MethodInfo, Type, and TypeInfo)<br /><br /> MethodBody<br /><br /> Module<br /><br /> ParameterInfo.<br /><br /> Calls to `IMarshal` for the object return `E_NOINTERFACE`.|  
|Suggestion|Update marshaling code to work with non-reflection objects|  
|Scope|Minor|  
|Version|4.6|  
|Type|Runtime|  
|Analyzers|CD0077|  
  
<a name="diagnostic78"></a>   
## 78: ContentDisposition DateTimes returns slightly different string  
  
|||  
|-|-|  
|Details|String representations of ContentDispositions have been updated, beginning in 4.6, to always represent the hour component of a DateTime with two digits. This is to comply with [RFC822](http://www.ietf.org/rfc/rfc0822.txt) and [RFC2822](http://www.ietf.org/rfc/rfc2822.txt). This causes `ContentDisposition.ToString` to return a slightly different string in 4.6 in scenarios where one of the disposition's time elements was before 10:00 AM. Note that ContentDispositions are sometimes serialized via converting them to strings, so any ContentDisposition ToString operations, serialization, or GetHashCode calls should be reviewed.|  
|Suggestion|Do not expect that string representations of ContentDispositions from different .NET Framework versions will correctly compare to one another. Convert the strings back to ContentDispositions, if possible, before conducting a comparison.|  
|Scope|Minor|  
|Version|4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Net.Mime.ContentDisposition.GetHashCode?displayProperty=fullName><br /><br /> <xref:System.Net.Mime.ContentDisposition.ToString?displayProperty=fullName>|  
|Analyzers|CD0078|  
  
<a name="diagnostic82"></a>   
## 82: WorkflowDesigner.Load doesn't remove symbol property  
  
|||  
|-|-|  
|Details|When targeting the .NET Framework 4.5 in the workflow designer, and loading a re-hosted 3.5 workflow with the WorkflowDesigner.Load() method, a XamlDuplicateMemberException is thrown while saving the workflow.|  
|Suggestion|This bug only manifests when targeting .NET Framework 4.5 in the workflow designer, so it can be worked around by setting the `WorkflowDesigner.Context.Services.GetService<DesignerConfigurationService>().TargetFrameworkName` to the 4.0 .NET Framework.<br /><br /> Alternatively, the issue may be avoided by using the [WorkflowContext.Load(string)](https://msdn.microsoft.com/library/ee425926\(v=vs.110\).aspx) method to load the workflow, instead of [WorkflowDesigner.Load()](https://msdn.microsoft.com/library/ee403482\(v=vs.110\).aspx).|  
|Scope|Major|  
|Version|4.5-4.5.2|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Activities.Presentation.WorkflowDesigner.Load?displayProperty=fullName>|  
|Analyzers|CD0082|  
  
<a name="diagnostic83"></a>   
## 83: SqlConnection.Open fails on Windows 7 with non-IFS Winsock BSP or LSP present  
  
|||  
|-|-|  
|Details|SqlConneciton.Open and OpenAsync fail in the .NET Framework 4.5 if running on a Windows 7 machine with a non-IFS Winsock BSP or LSP are present on the computer.<br /><br /> To determine whether a non-IFS BSP or LSP is installed, use the `netsh WinSock Show Catalog` command, and examine every `Winsock Catalog Provider Entry` item that is returned. If the Service Flags value has the `0x20000` bit set, the provider uses IFS handles and will work correctly. If the `0x20000` bit is clear (not set), it is a non-IFS BSP or LSP.|  
|Suggestion|This bug has been fixed in the .NET Framework 4.5.2, so it can be avoided by upgrading the .NET Framework. Alternatively, it can be avoided by removing any installed non-IFS Winsock LSPs.|  
|Scope|Minor|  
|Version|4.5-4.5.2|  
|Type|Runtime|  
|Affected APIs|<xref:System.Data.SqlClient.SqlConnection.Open?displayProperty=fullName><br /><br /> <xref:System.Data.SqlClient.SqlConnection.OpenAsync%28System.Threading.CancellationToken%29?displayProperty=fullName>|  
|Analyzers|CD0083|  
  
<a name="diagnostic84"></a>   
## 84: ICommand.CanExecuteChanged event behaviour changed in .NET 4.5  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, a CanExecuteChangedEvent was ignored unless the sender of the event was the same object as the object that raised the event. This bug was fixed in .NET Framework 4.5 servcing updates.|  
|Suggestion|This bug has been fixed in the .NET Framework 4.5 servicing releases, so it can be avoided by making sure that the .NET Framework is up-to-date or by upgrading to .NET Framework 4.5.1. Alternatively, application code using ICommand can be modified to make sure that the sender when raising a CanExecuteChanged command is the same as the object raising the event.|  
|Scope|Minor|  
|Version|4.5-4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Input.ICommand.CanExecuteChanged?displayProperty=fullName>|  
|Analyzers|CD0084|  
  
<a name="diagnostic85"></a>   
## 85: Some .NET APIs cause first chance (handled) EntryPointNotFoundExceptions  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, a small number of .NET methods began throwing first chance EntryPointNotFoundExceptions. These exceptions were handled within the .Net Framework, but could break test automation that did not expect the first chance exceptions. These same APIs break some ApiVerifier scenarios when HighVersionLie is enabled.|  
|Suggestion|This bug can be avoided by upgrading to .NET Framework 4.5.1. Alternatively, test automation can be updated to not break on first-chance EntryPointNotFoundExceptions.|  
|Scope|Edge|  
|Version|4.5-4.5.1|  
|Type|Runtime|  
|Affected APIs|<xref:System.Diagnostics.Debug.Assert%28System.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Debug.Assert%28System.Boolean%2CSystem.String%29?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Debug.Assert%28System.Boolean%2CSystem.String%2CSystem.String%29?displayProperty=fullName><br /><br /> <xref:System.Diagnostics.Debug.Assert%28System.Boolean%2CSystem.String%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=fullName><br /><br /> <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%29?displayProperty=fullName>|  
|Analyzers|CD0085|  
  
<a name="diagnostic86"></a>   
## 86: Scrolling a WPF TreeView or grouped ListBox in a VirtualizingStackPanel can cause a hang  
  
|||  
|-|-|  
|Details|In the .NET Framework v4.5, scrolling a WPF TreeView in a virtualized stack panel can cause hangs if there are margins in the viewport (between the items in the TreeView, for example, or on an ItemsPresenter element). Additionally, in some cases, different sized items in the view can cause instability even if there are no margins.|  
|Suggestion|This bug can be avoided by upgrading to .NET Framework 4.5.1. Alternatively, margins can be removed from view collections (like TreeViews) within virtualized stack panels if all contained items are the same size.|  
|Scope|Major|  
|Version|4.5-4.5.1|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Controls.VirtualizingPanel.SetIsVirtualizing%28System.Windows.DependencyObject%2CSystem.Boolean%29?displayProperty=fullName>|  
|Analyzers|CD0086<br /><br /> CD0086|  
  
<a name="diagnostic89"></a>   
## 89: Type.IsAssignableFrom returns wrong result for generic variables with constraints  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, Type.IsAssignableFrom will incorrectly return `false` in all cases for some generic types with constraints.|  
|Suggestion|This issue was fixed in a servicing update. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue. Alternatively, avoid using IsAssignableFrom with generic types that have constraints on generic parameters. Reflection APIs can be used as a work-around.|  
|Scope|Minor|  
|Version|4.5-4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Type.IsAssignableFrom%28System.Type%29?displayProperty=fullName>|  
|Analyzers|CD0089<br /><br /> CD0089|  
  
<a name="diagnostic91"></a>   
## 91: EntityFramework 6.0 loads very slowly in apps launched from Visual Studio  
  
|||  
|-|-|  
|Details|Launching an app from Visual Studio 2013 that uses EntityFramework 6.0 can be very slow.|  
|Suggestion|This issue is fixed in EntityFramework 6.0.2. Please update EntityFramework to avoid the performance issue.|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0091|  
  
<a name="diagnostic92"></a>   
## 92: Multi-line ASP.Net TextBox spacing changed when using AntiXSSEncoder  
  
|||  
|-|-|  
|Details|In .NET Framework 4.0, extra lines were inserted between lines of a multi-line text box on postback, if using the `AntiXSSEncoder`. In .NET Framework 4.5, those extra line breaks are not included, but only if the web app is targeting .NET 4.5|  
|Suggestion|Be aware that 4.0 web apps retargeted to .NET 4.5 may have multi-line text boxes improved to no longer insert extra line breaks. If this is not desirable, the app can have the old behavior when running on .NET Framework 4.5 by targeting the .NET Framework 4.0.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Retargeting|  
|Analyzers|CD0092|  
  
<a name="diagnostic95"></a>   
## 95: ConcurrentQueue\<T>.TryPeek can return an erroneous null via its out parameter  
  
|||  
|-|-|  
|Details|In some multi-threaded scenarios, `ConcurentQueue<T>.TryPeek` can return true, but populate the out parameter with a null value (instead of the correct, peeked value).|  
|Suggestion|This issue is fixed in the .NET Framework 4.5.1. Upgrading to that Framework will solve the issue.|  
|Scope|Major|  
|Version|4.5-4.5.1|  
|Type|Runtime|  
|Affected APIs|<xref:System.Collections.Concurrent.ConcurrentQueue%601.TryPeek%28%600%40%29?displayProperty=fullName>|  
|Analyzers|CD0095|  
  
<a name="diagnostic98"></a>   
## 98: Multiple items in a single TableLayoutPanel cell may be rearranged  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, if multiple items are placed in the same TableLayoutPanel cell, they may be displayed in a different order than they were in the .NET Framework 4.0.|  
|Suggestion|This behavior was reverted in a servicing update for the .NET Framework 4.5. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue. Alternatively, avoid the ambiguous case of multiple items in the same TableLayourPanel cell.|  
|Scope|Minor|  
|Version|4.5-4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Forms.TableLayoutControlCollection.Add%28System.Windows.Forms.Control%2CSystem.Int32%2CSystem.Int32%29?displayProperty=fullName>|  
|Analyzers|CD0098|  
  
<a name="diagnostic100"></a>   
## 100: Foreach iterator variable is now scoped within the iteration, so closure capturing semantics are different (in C#5)  
  
|||  
|-|-|  
|Details|Beginning with C# 5 (Visual Studio 2012), foreach iterator variables are scoped within the iteration. This can cause breaks if code was previously depending on the variables to not be included in the foreach's closure. The symptom of this change will be that an iterator variable passed to a delagate will be treated as the value it had at the time the delegate was created, rather than the value it had at the time the delegate was invoked.|  
|Suggestion|Ideally, code should be updated to expect the new compiler behavior. If the old semantics are required, the iterator variable can be replaced with a separate variable which is explicitly placed outside of the loop's scope.|  
|Scope|Major|  
|Version|4.5|  
|Type|Retargeting|  
|Analyzers|CD0100|  
  
<a name="diagnostic101"></a>   
## 101: HtmlTextWriter does not render \`<br/\>` element correctly  
  
|||  
|-|-|  
|Details|Beginning in the .NET Framework 4.6, calling `HtmlTextWriter.RenderBeginTag()` and `HtmlTextWriter.RenderEndTag()` with a `<BR />` element will correctly insert only one `<BR />` (instead of two)|  
|Suggestion|If an app depended on the extra `<BR />` tag, `HtmlTextWriter.RenderBeginTag()` should be called a second time. Note that this behavior change only affects apps that are targeting the .NET Framework 4.6, so another option is to target a previous version of the .NET Framework in order to get the old behavior.|  
|Scope|Edge|  
|Version|4.6|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Web.UI.HtmlTextWriter.RenderBeginTag%28System.String%29?displayProperty=fullName><br /><br /> <xref:System.Web.UI.HtmlTextWriter.RenderBeginTag%28System.Web.UI.HtmlTextWriterTag%29?displayProperty=fullName>|  
|Analyzers|CD0101|  
  
<a name="diagnostic104"></a>   
## 104: Calling Items.Refresh on a WPF ListBox, ListView, or DataGrid with items selected can cause duplicate items to appear in the element  
  
|||  
|-|-|  
|Details|In the .NET Framework 4.5, calling ListBox.Items.Refresh from code while items are selected in a ListBox can cause the selected items to be duplicated in the list. A similar issue occurs with ListView and DataGrid. This is fixed in the .NET Framework 4.6.|  
|Suggestion|This issue may be worked around by programatically unselecting items before Refresh is called and then re-selecting them after the call is completed. Alternatively, this issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.|  
|Scope|Minor|  
|Version|4.5-4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Data.CollectionView.Refresh?displayProperty=fullName>|  
|Analyzers|CD0104|  
  
<a name="diagnostic105"></a>   
## 105: ETW EventListeners do not capture events from providers with explicit keywords (like the TPL provider)  
  
|||  
|-|-|  
|Details|ETW EventListeners with a blank keyword mask do not properly capture events from providers with explicit keywords. In the .NET Framework 4.5, the TPL provider began providing explicit keywords and triggered this issue. In the .NET Framework 4.6, EventListeners have been updated to no longer have this issue.|  
|Suggestion|To work around this problem, replace calls to EnableEvents(eventSource, level) with calls to the EnableEvents overload that explicitly specifies the "any keywords" mask to use: `EnableEvents(eventSource, level, unchecked((EventKeywords)0xFFFFffffFFFFffff))`.<br /><br /> Alternatively, this issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.|  
|Scope|Edge|  
|Version|4.5-4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Diagnostics.Tracing.EventListener.EnableEvents%28System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%29?displayProperty=fullName>|  
|Analyzers|CD0105|  
  
<a name="diagnostic109"></a>   
## 109: Building an Entity Framework edmx with Visual Studio 2013 can fail with error MSB4062 if using the EntityDeploySplit or EntityClean tasks  
  
|||  
|-|-|  
|Details|MSBuild 12.0 tools (included in Visual Studio 2013) changed msbuild file locations, causing older Entity Framework targets files to be invalid. The result is that `EntityDeploySplit` and `EntityClean` tasks fail because they are unable to find `Microsoft.Data.Entity.Build.Tasks.dll`. Note that this break is because of a toolset (msbuild/VS) change, not because of a .NET Framework change. It will only occur when upgrading developer tools, not when merely upgrading the .NET Framework.|  
|Suggestion|Entity Framework targets files are fixed to work with the new msbuild layout beginning in the .NET Framework 4.6. Upgrading to that version of the Framework will fix this issue. Alternatively, [this](http://stackoverflow.com/a/24249247/131944) workaround can be used to patch the targets files directly.|  
|Scope|Major|  
|Version|4.5.1-4.6|  
|Type|Retargeting|  
|Analyzers|CD0109|  
  
<a name="diagnostic111"></a>   
## 111: XSD Schema validation now correctly detects violations of unique constraints if compound keys are used and one key is empty  
  
|||  
|-|-|  
|Details|Versions of the .NET Framework prior to 4.6 had a bug that caused XSD validation to not detect unique constraints on compound keys if one of the keys was empty. In the .NET Framework 4.6, this issue is corrected. This will result in more correct validation, but it may also result in some XML not validating which previously would have.|  
|Suggestion|If looser, .NET Framework 4.0 validation is needed, the validating application can target version 4.5 (or earlier) of the .NET Framework. When retargeting to .NET 4.6, however, code review should be done to be sure that duplicate compound keys (as described in this issue's description) are not expected to validate.|  
|Scope|Edge|  
|Version|4.6|  
|Type|Retargeting|  
|Analyzers|CD0111|  
  
<a name="diagnostic112"></a>   
## 112: Calling Attribute.GetCustomAttributes on an indexer property no longer throws AmbiguousMatchException if the ambiguity can be resolved by index's type  
  
|||  
|-|-|  
|Details|Prior to the .NET Framework 4.6, calling `GetCustomAttribute(s)` on an indexer property which differed from another property only by the type of the index would result in an `AmbiguousMatchException`. Beginning in the .NET Framework 4.6, the property's attributes will be correctly returned.|  
|Suggestion|Be aware that GetCustomAttribute(s) will work more frequently now. If an app was previously relying on the `AmbiguousMatchException`, reflection should now be used to explicitly look for multiple indexers, instead.|  
|Scope|Edge|  
|Version|4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Attribute.GetCustomAttribute%28System.Reflection.MemberInfo%2CSystem.Type%29?displayProperty=fullName><br /><br /> <xref:System.Attribute.GetCustomAttribute%28System.Reflection.MemberInfo%2CSystem.Type%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Attribute.GetCustomAttributes%28System.Reflection.MemberInfo%29?displayProperty=fullName><br /><br /> <xref:System.Attribute.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Attribute.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Type%29?displayProperty=fullName><br /><br /> <xref:System.Attribute.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Type%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttribute%28System.Reflection.MemberInfo%2CSystem.Type%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttribute%28System.Reflection.MemberInfo%2CSystem.Type%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttribute%60%601%28System.Reflection.MemberInfo%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttribute%60%601%28System.Reflection.MemberInfo%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%28System.Reflection.MemberInfo%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Type%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Type%2CSystem.Boolean%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%60%601%28System.Reflection.MemberInfo%29?displayProperty=fullName><br /><br /> <xref:System.Reflection.CustomAttributeExtensions.GetCustomAttributes%60%601%28System.Reflection.MemberInfo%2CSystem.Boolean%29?displayProperty=fullName>|  
|Analyzers|CD0112|  
  
<a name="diagnostic113"></a>   
## 113: Intermittently unable to scroll to bottom item in ItemsControls (like ListBox and DataGrid) when using custom DataTemplates  
  
|||  
|-|-|  
|Details|In some instances, a bug in the .NET Framework 4.5 is causing ItemsControls (like ListBox, ComboBox, DataGrid, etc.) to not scroll to their bottom item when using custom DataTemplates. If the scrolling is attempted a second time (after scrolling back up), it will work then.|  
|Suggestion|This issue has been fixed in the .NET Framework 4.5.2 and may be addressed by upgrading to that version (or a later version) of the .NET Framework. Alternatively, users can still drag scroll bars to the final items in these collections, but may need to try twice to do so successfully.|  
|Scope|Minor|  
|Version|4.5-4.5.2|  
|Type|Runtime|  
|Analyzers|CD0113|  
  
<a name="diagnostic114"></a>   
## 114: GlyphRun.ComputeInkBoundingBox() and FormattedText.Extent return different values beginning in .NET 4.5  
  
|||  
|-|-|  
|Details|Improvements were made to GlyphRun.ComputeInkBoundingBox() and FormattedText.Extent in the .NET Framework 4.5 to address issues where the boxes were too small for the contained glyphs in some cases in the .NET Framework 4.0. As a result of this, some bounding boxes will be larger beginning in the .NET Framework 4.5, resulting in subtle differences in UI layout.|  
|Suggestion|Be aware that some glyph bounding box sizes have increased. These changes will usually improve presentation and hit box testing, but if the older (pre-.NET 4.5) behavior is desired, it can be opted into by adding the following entry to the app.config file:<br /><br /> `<appsettings> <add key="IncludeAllInkInBoundingBox" value="false"> </appsettings>`|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Media.GlyphRun.ComputeInkBoundingBox?displayProperty=fullName><br /><br /> <xref:System.Windows.Media.FormattedText.Extent?displayProperty=fullName>|  
|Analyzers|CD0114|  
  
<a name="diagnostic124"></a>   
## 124: Calling DataGrid.CommitEdit from a CellEditEnding handler drops focus  
  
|||  
|-|-|  
|Details|Calling DataGrid.CommitEdit from one of the DataGrid's CellEditEnding event handlers causes the DataGrid to lose focus.|  
|Suggestion|This bug has been fixed in the .NET Framework 4.5.2, so it can be avoided by upgrading the .NET Framework. Alternatively, it can be avoided by explicitly re-selecting the DataGrid after calling CommitEdit.|  
|Scope|Edge|  
|Version|4.5-4.5.2|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.Controls.DataGrid.CommitEdit?displayProperty=fullName><br /><br /> <xref:System.Windows.Controls.DataGrid.CommitEdit%28System.Windows.Controls.DataGridEditingUnit%2CSystem.Boolean%29?displayProperty=fullName>|  
|Analyzers|CD0124|  
  
<a name="diagnostic125"></a>   
## 125: ASP.NET MVC now escapes spaces in strings passed in via route parameters  
  
|||  
|-|-|  
|Details|In order to conform to RFC 2396, spaces in route paths are now escaped when populating action parameters from a route. So, whereas  `/controller/action/some data` would previously match the route `/controller/action/{data}` and provide `some data` as the data parameter, it will now provide `some%20data` instead.|  
|Suggestion|Code should be updated to unescape string parameters from a route. If the original URI is needed, it can be accessed with the Request.RequestUri.OriginalString API.|  
|Scope|Minor|  
|Version|4.5.2|  
|Type|Runtime|  
|Affected APIs|[System.Web.Http.RouteAttribute](https://msdn.microsoft.com/library/system.web.http.routeattribute(v=vs.118).aspx)|  
|Analyzers|CD0125|  
  
<a name="diagnostic127"></a>   
## 127: VB.NET no longer supports partial namespace qualification for System.Windows APIs  
  
|||  
|-|-|  
|Details|Beginning in .NET 4.5.2, VB.NET projects cannot specify System.Windows APIs with partially-qualified namespaces. For example, referring to `Windows.Forms.DialogResult` will fail. Instead, code must refer to the fully qualified name (`System.Windows.Forms.DialogResult`) or import the specific namespace and refer simply to `DialogResult`.|  
|Suggestion|Code should be updated to refer to `System.Windows` APIs either with simple names (and importing the relevant namespace) or with fully qualified names.|  
|Scope|Minor|  
|Version|4.5.2|  
|Type|Retargeting|  
|Analyzers|CD0127|  
  
<a name="diagnostic129"></a>   
## 129: Two-way data-binding to a property with a non-public setter is not supported  
  
|||  
|-|-|  
|Details|Attempting to data bind to a property without a public setter has never been a supported scenario. Beginning in the .NET Framework 4.5.1, this scenario will throw an InvalidOperationException. Note that this new exception will only be thrown for apps that specifically target the .NET Framework 4.5.1. If an app targets the .NET Framework 4.5, the call will be allowed. If the app does not target a particular .NET Framework version, the binding will be treated as one-way.|  
|Suggestion|The app should be updated to either use one-way binding, or expose the property's setter publicly. Alternatively, targeting the .NET Framework 4.5 will cause the app to exhibit the old behavior.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Windows.Data.BindingMode?displayProperty=fullName>|  
|Analyzers|CD0129|  
  
<a name="diagnostic130"></a>   
## 130: Marshal.SizeOf and Marshal.PtrToStructure overloads break dynamic code  
  
|||  
|-|-|  
|Details|Beginning in the .NET Framework 4.5.1, dynamically binding to the methods `Marshal.SizeOf` or `Marshal.PtrToStructure` (via Windows PowerShell, IronPython, or the C# dynamic keyword, for example) can result in `MethodInvocationExceptions` because new overloads of these methods have been added that may be ambiguous to the scripting engines.|  
|Suggestion|Update scripts to clearly indicate which overload shouldbe used. This can typically done by explicitly casting the methods' type parameters as `System.Type`. See [this link](https://support.microsoft.com/kb/2909958/) for more detail and examples of how to workaround the issue.|  
|Scope|Minor|  
|Version|4.5.1|  
|Type|Runtime|  
|Analyzers|CD0130|  
  
<a name="diagnostic131"></a>   
## 131: PreviewLostKeyboardFocus is called repeatedly if its handler shows a Windows Forms message box  
  
|||  
|-|-|  
|Details|Beginning in the .NET Framework 4.5, calling `System.Windows.Forms.MessageBox.Show` from a `UIElement.PreviewLostKeyboardFocus` handler will cause the handler to re-fire when the message box is closed, potentially resulting in an infinite loop of message boxes.|  
|Suggestion|There are two options to work around this issue -<br /><br /> It may be avoided by calling `System.Windows.MessageBox.Show` instead of `System.Windows.Forms.MessageBox.Show`.<br /><br /> It may be avoided by showing the message box from a `LostKeyboardFocus` event handler (as opposed to a `PreviewLostKeyboardFocus` event handler).|  
|Scope|Edge|  
|Version|4.5|  
|Type|Runtime|  
|Affected APIs|<xref:System.Windows.ContentElement.PreviewLostKeyboardFocus?displayProperty=fullName><br /><br /> <xref:System.Windows.IInputElement.PreviewLostKeyboardFocus?displayProperty=fullName><br /><br /> <xref:System.Windows.UIElement.PreviewLostKeyboardFocus?displayProperty=fullName><br /><br /> <xref:System.Windows.UIElement3D.PreviewLostKeyboardFocus?displayProperty=fullName>|  
|Analyzers|CD0131|  
  
<a name="diagnostic133"></a>   
## 133: A ConcurrentDictionary serialized in .NET 4.5 with NetDataContractSerializer cannot be deserialized by .NET 4.5.1 or 4.5.2  
  
|||  
|-|-|  
|Details|Due to internal changes to the type, `System.Collections.Concurrent.ConcurrentDictionary` objects that are serialized with the .NET Framework 4.5 using the `NetDataContractSerializer` cannot be deserialized in the .NET Framework 4.5.1 or in the .NET Framework 4.5.2.<br /><br /> Note that moving the other direction (serializing with the .NET Framework 4.5.x and deserializing with the .NET Framework 4.5) works. Similarly, all 4.x cross-version serialization works with the .NET Framework 4.6.<br /><br /> Serializing and deserializing with a single version of the .NET Framework is not affected.|  
|Suggestion|If it is necessary to serialize and deserialize a ConcurrentDictionary between the .NET Framework 4.5 and .NET Framework 4.5.1/4.5.2, an alternate serializer like the DataContractSerializer or BinaryFormatter serializer should be used instead of the NetDataContractSerializer.<br /><br /> Alternatively, because this issue is addressed in the .NET Framework 4.6, it may be solved by upgrading to that version of the .NET Framework.|  
|Scope|Minor|  
|Version|4.5.1-4.6|  
|Type|Runtime|  
|Analyzers|CD0133|  
  
<a name="diagnostic134"></a>   
## 134: Persian calendar now uses the Hijri solar algorithm  
  
|||  
|-|-|  
|Details|Starting with the .NET Framework 4.6, the PersianCalendar class uses the Hijri solar algorithm. Converting dates between the PersianCalendar and other calendars may produce a slightly different result beginning with the .NET Framework 4.6 for dates earlier than 1800 or later than 2023 (Gregorian).<br /><br /> Also, `PersianCalendar.MinSupportedDateTime` is now `March 22, 0622 instead of March 21, 0622`.|  
|Suggestion|Be aware that some early or late dates may be slightly different when using the PersianCalendar in .NET 4.6. Also, when serializing dates between processes which may run on different .NET Framework versions, do not store them as PersianCalendar date strings (since those values may be different).|  
|Scope|Minor|  
|Version|4.6|  
|Type|Runtime|  
|Affected APIs|<xref:System.Globalization.PersianCalendar?displayProperty=fullName>|  
|Analyzers|CD0134|  
  
<a name="diagnostic138"></a>   
## 138: Calling CreateDefaultAuthorizationContext with a null argument has changed  
  
|||  
|-|-|  
|Details|The implementation of the AuthorizationContext returned by a call to the `CreateDefaultAuthorizationContext(IList<IAuthorizationPolicy>)` with a null authorizationPolicies argument has changed its implementation in the .NET Framework 4.6.|  
|Suggestion|In rare cases, WCF apps that use custom authentication may see behavioral differences. In such cases, the previous behavior can be restored in either of two ways:<br /><br /> Recompile your app to target an earlier version of the .NET Framework than 4.6. For IIS-hosted services, use the \<httpRuntime targetFramework="x.x" /> element to target an earlier version of the .NET Framework.<br /><br /> Add the following line to the `<appSettings>` section of your app.config file: `<add key="appContext.SetSwitch:Switch.System.IdentityModel.EnableCachedEmptyDefaultAuthorizationContext" value="true" />`|  
|Scope|Minor|  
|Version|4.6|  
|Type|Retargeting|  
|Affected APIs|<xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext%28System.Collections.Generic.IList%7BSystem.IdentityModel.Policy.IAuthorizationPolicy%7D%29?displayProperty=fullName>|  
|Analyzers|CD0138|  
  
<a name="diagnostic141"></a>   
## 141: WPF TreeViewItem must be used within a TreeView  
  
|||  
|-|-|  
|Details|A change was introduced in 4.5 that restricts usage of TreeViewItem elements outside of a TreeView. This manifests under the following conditions:<br /><br /> TreeViewItem's visual parent is not a panel. (A TreeViewItem generated for a TreeView will have a panel as its parent)<br /><br /> The TreeViewItem is a descendant of a VirtualizingStackPanel acting as the "items host" for a list control (ListBox, DataGrid, ListView, etc.). Virtualization doesn't need to be enabled.<br /><br /> The VirtualizingStackPanel is item-scrolling (`ScrollUnit="Item"`).<br /><br /> Someone calls `VirtualizingStackPanel.MakeVisible(v)` to scroll an element `v` into view. This can be done explicitly, or implicitly in a number of ways; perhaps the most common way is simply clicking on `v` to give it the keyboard focus.<br /><br /> The visual-parent chain from `v` to the VirtualizingStackPanel passes through the TreeViewItem.<br /><br /> In other words, this is seen when a TreeViewItem is used outside of a TreeView, and the user clicks on a descendant of the TreeViewItem to bring it into view. If the TreeViewItem has no focusable descendants, you'll never see this issue. An example of a situation where this is hit is when a TreeViewItem is the root of a DataTemplate.  When this issue is hit, there is an InvalidCastException that occurs within the WPF framework.|  
|Suggestion|A hotfix will be made available for this.|  
|Scope|Minor|  
|Version|4.5|  
|Type|Runtime|  
|Analyzers|CD0141|  
  
<a name="diagnostic143"></a>   
## 143: X509CertificateClaimSet.FindClaims Considers All claimTypes  
  
|||  
|-|-|  
|Details|In apps that target the .NET Framework 4.6.1, if an X509 claim set is initialized from a certificate that has multiple DNS entries in its SAN field, the FindClaims method attempts to match the claimType argument with all the DNS entries.<br /><br /> For apps that target previous versions of the .NET Framework, the FindClaims method attempts to match the claimType argument only with the last DNS entry.|  
|Suggestion|This change only affects applications targeting the .NET Framework 4.6.1. This change may be disabled (or enabled if targetting pre-4.6.1) with the [DisableMultipleDNSEntries](https://msdn.microsoft.com/library/mt620030%28v=vs.110%29.aspx) compatibility switch.|  
|Scope|Minor|  
|Version|4.6.1|  
|Type|Retargeting|  
|Affected APIs|<xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims%28System.String%2CSystem.String%29?displayProperty=fullName>|  
|Analyzers|CD0143|  
  
<a name="diagnostic144"></a>   
## 144: Application.FilterMessage no longer throws for re-entrant implementations of IMessageFilter.PreFilterMessage  
  
|||  
|-|-|  
|Details|Prior to the .NET Framework 4.6.1, calling Application.FilterMessage with an IMessageFilter.PreFilterMessage which called AddMessageFilter or RemoveMessageFilter (while also calling Application.DoEvents) would cause an IndexOutOfRangeException.<br /><br /> Beginning with applications targeting the .NET Framework 4.6.1, this exception is no longer thrown, and re-entrant filters as described above may be used.|  
|Suggestion|Be aware that Application.FilterMessage will no longer throw for the re-entrant IMessageFilter.PreFilterMessage behavior described above. This only affects applications targeting the .NET Framework 4.6.1.<br /><br /> Apps targeting the .NET Framework 4.6.1 can opt out of this change (or apps targeting older Frameworks may opt in) by using the [DontSupportReentrantFilterMessage](https://msdn.microsoft.com/library/mt620032%28v=vs.110%29.aspx) compatibility switch.|  
|Scope|Edge|  
|Version|4.6.1|  
|Type|Retargeting|  
|Affected APIs|<xref:System.Windows.Forms.Application.FilterMessage%28System.Windows.Forms.Message%40%29?displayProperty=fullName>|  
|Analyzers|CD0144|  
  
<a name="diagnostic145"></a>   
## 145: CurrentCulture is not preserved across WPF Dispatcher operations  
  
|||  
|-|-|  
|Details|Beginning in the .NET Framework 4.6, changes to CurrentCulture or CurrentUICulture made within a [Dispatcher](https://msdn.microsoft.com/library/system.windows.threading.dispatcher%28v=vs.110%29.aspx) will be lost at the end of that dispatcher operation. Similarly, changes to CurrentCulture or CurrentUICulture made outside of a Dispatcher operation may not be reflected when that operation executes.<br /><br /> Practically speaking, this means that CurrentCulture and CurrentUICulture changes may not flow between WPF UI callbacks and other code in a WPF application.<br /><br /> This is due to a change in [ExecutionContext](https://msdn.microsoft.com/library/system.threading.executioncontext%28v=vs.110%29.aspx) that causes CurrentCulture and CurrentUICulture to be stored in the execution context beginning with apps targeting the .NET Framework 4.6. WPF dispatcher operations store the execution context used to begin the operation and restore the previous context when the operation is completed. Because CurrentCulture and CurrentUICulture are now part of that context, changes to them within a dispatcher operation are not persisted outside of the operation.|  
|Suggestion|Apps affected by this change may work around it by storing the desired CurrentCulture or CurrentUICulture in a field and checking in all Dispatcher operation bodies (including UI event callback handlers) that the correct CurrentCulture and CurrentUICulture are set. Alternatively, because the ExecutionContext change underlying this WPF change only affects apps targeting the .NET Framework 4.6 or newer, this break can be avoided by targeting the .NET Framework 4.5.2.|  
|Scope|Minor|  
|Version|4.6|  
|Type|Retargeting|  
|Analyzers|CD0145|