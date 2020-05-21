### CounterSet.CreateCounterSetInstance now throws InvalidOperationException if instance already exist

Starting in .NET Core 5.0, <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance>(string `instanceName`) throws <xref:System.InvalidOperationException> instead of <xref:System.ArgumentException> if user attempt to create already existing instance.

#### Change description

In .NET Framework and versions of .NET Core prior to 5.0, you could create an instance of the counter set by calling <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance>. However, if counter set already exist it would throw ArgumentException exception.

In .NET Core 5.0 and later versions, when you call <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance> and if the counter set exist then <xref:System.InvalidOperationException> would be thrown.

#### Version introduced

5.0 Preview 5

#### Recommended action

Catching ArgumentException is not recommended, but if you are catching <xref:System.ArgumentException> in your app, you might want to consider also catching <xref:System.InvalidOperationException>.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance>

<!--

#### Affected APIs

- `M:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance(System.String)`

-->
