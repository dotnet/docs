### WPF DispatcherSynchronizationContext.CreateCopy now returns a new copy instead of the current instance

#### Details

In the .NET Framework 4, <xref:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy> returned a reference to the current instance, primarily as a performance optimization. In the .NET Framework 4.5, it returns a new instance which makes it possible for the first time to conclude that equal references indicate the executing thread is in the correct synchronization context.  It is unlikely that code that checks the identity of these references will be affected, but because of the change, code that calls <xref:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy> should be tested as part of migration to the .NET Framework 4.5 or newer.

#### Suggestion

Be aware that <xref:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy> will now return a new <xref:System.Threading.SynchronizationContext?displayProperty=fullName> object. Previously, code that used equivalence of references generated this way was not actually checking whether it was in the proper context, but does when built against .NET Framework 4.5 or later.  While unlikely to cause issues, exercising the affected code paths should be enough to determine if this poses any problem.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

- <xref:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:System.Windows.Threading.DispatcherSynchronizationContext.CreateCopy`

-->
