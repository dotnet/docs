### New (ambiguous) Dispatcher.Invoke overloads could result in different behavior

#### Details

The .NET Framework 4.5 adds new overloads to <xref:System.Windows.Threading.Dispatcher.Invoke%2A?displayProperty=nameWithType> that include a parameter of type <xref:System.Action>. When existing code is recompiled, compilers may resolve calls to Dispatcher.Invoke methods that have a <xref:System.Delegate> parameter as calls to Dispatcher.Invoke methods with an <xref:System.Action> parameter. If a call to a Dispatcher.Invoke overload with a  <xref:System.Delegate> parameter is resolved as a call to a Dispatcher.Invoke overload with an <xref:System.Action> parameter, the following differences in behavior may occur:

- If an exception occurs, the <xref:System.Windows.Threading.Dispatcher.UnhandledExceptionFilter> and <xref:System.Windows.Threading.Dispatcher.UnhandledException> events are not raised. Instead, exceptions are handled by the <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=fullName> event.
- Calls to some members, such as <xref:System.Windows.Threading.DispatcherOperation.Result>, block until the operation has completed.

#### Suggestion

To avoid ambiguity (and potential differences in exception handling or blocking behaviors), code calling Dispatcher.Invoke can pass an empty object[] as a second parameter to the Invoke call to be sure of resolving to the .NET Framework 4.0 method overload.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.5         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate,System.Object[])?displayProperty=nameWithType>
- <xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate,System.TimeSpan,System.Object[])?displayProperty=nameWithType>
- <xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate,System.TimeSpan,System.Windows.Threading.DispatcherPriority,System.Object[])?displayProperty=nameWithType>
- <xref:System.Windows.Threading.Dispatcher.Invoke(System.Delegate,System.Windows.Threading.DispatcherPriority,System.Object[])?displayProperty=nameWithType>
