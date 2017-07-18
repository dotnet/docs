### New (ambiguous) Dispatcher.Invoke overloads could result in different behavior

|   |   |
|---|---|
|Details|The .NET Framework 4.5 adds new overloads to Dispatcher.Invoke that include a parameter of type @System.Action. When existing code is recompiled, compilers may resolve calls to Dispatcher.Invoke methods that have a @System.Delegate parameter as calls to Dispatcher.Invoke methods with an @System.Action parameter. If a call to a Dispatcher.Invoke overload with a @System.Delegate parameter is resolved as a call to a Dispatcher.Invoke overload with an @System.Action parameter, the following differences in behavior may occur:<ul><li>If an exception occurs, the <xref:System.Windows.Threading.Dispatcher.UnhandledExceptionFilter> and <xref:System.Windows.Threading.Dispatcher.UnhandledException> events are not raised. Instead, exceptions are handled by the <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=name> event.</li><li>Calls to some members, such as <xref:System.Windows.Threading.DispatcherOperation.Result>, block until the operation has completed.</li></ul>|
|Suggestion|To avoid ambiguity (and potential differences in exception handling or blocking behaviors), code calling Dispatcher.Invoke can pass an empty object[] as a second parameter to the Invoke call to be sure of resolving to the .NET 4.0 method overload.|
|Scope|Minor|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate%2CSystem.Object%5B%5D)?displayProperty=fullName></li><li><xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate%2CSystem.TimeSpan%2CSystem.Object%5B%5D)?displayProperty=fullName></li><li><xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate%2CSystem.TimeSpan%2CSystem.Windows.Threading.DispatcherPriority%2CSystem.Object%5B%5D)?displayProperty=fullName></li><li><xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate%2CSystem.Windows.Threading.DispatcherPriority%2CSystem.Object%5B%5D)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0023</li></ul>|

