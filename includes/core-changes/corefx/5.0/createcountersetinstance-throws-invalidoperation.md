### CounterSet.CreateCounterSetInstance now throws InvalidOperationException if instance already exist

Starting in .NET 5.0, <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance(System.String)?displayProperty=nameWithType> throws an <xref:System.InvalidOperationException> instead of an <xref:System.ArgumentException> if the counter set already exists.

#### Change description

In .NET Framework and .NET Core 1.0 to 3.1, you can create an instance of the counter set by calling <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance>. However, if the counter set already exists, the method throws an <xref:System.ArgumentException> exception.

In .NET 5.0 and later versions, when you call <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance> and the counter set exists, an <xref:System.InvalidOperationException> exception is thrown.

#### Version introduced

5.0 Preview 5

#### Recommended action

If you catch <xref:System.ArgumentException> exceptions in your app, consider also catching <xref:System.InvalidOperationException> exceptions.

> [!NOTE]
> Catching <xref:System.ArgumentException> exceptions is not recommended.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance%2A?displayProperty=fullName>

<!--

#### Affected APIs

- `M:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance(System.String)`

-->
