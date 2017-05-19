### Change in behavior for Task.WaitAll methods with time-out arguments

|   |   |
|---|---|
|Details|Task.WaitAll behavior was made more consistent in .NET 4.5.In the .NET Framework 4, these methods behaved inconsistently. When the time-out expired, if one or more tasks were completed or canceled before the method call, the method threw an <xref:System.AggregateException?displayProperty=name> exception. When the time-out expired, if no tasks were completed or canceled before the method call, but one or more tasks entered these states after the method call, the method returned false.<br/><br/>In the .NET Framework 4.5, these method overloads now return false if any tasks are still running when the time-out interval expired, and they throw an <xref:System.AggregateException?displayProperty=name> exception only if an input task was cancelled (regardless of whether it was before or after the method call) and no other tasks are still running.|
|Suggestion|If an <xref:System.AggregateException?displayProperty=name> was being caught as a means of detecting a task that was cancelled prior to the WaitAll call being invoked, that code should instead do the same detection via the IsCanceled property (for example: .Any(t =&gt; t.IsCanceled)) since .NET 4.6 will only throw in that case if all awaited tasks are completed prior to the timeout.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Threading.Tasks.Task.WaitAll(System.Threading.Tasks.Task%5B%5D%2CSystem.Int32)?displayProperty=fullName></li><li><xref:System.Threading.Tasks.Task.WaitAll(System.Threading.Tasks.Task%5B%5D%2CSystem.Int32%2CSystem.Threading.CancellationToken)?displayProperty=fullName></li><li><xref:System.Threading.Tasks.Task.WaitAll(System.Threading.Tasks.Task%5B%5D%2CSystem.TimeSpan)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0026</li></ul>|

