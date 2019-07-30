### WPF AppDomain Shutdown Handling May Now Call Dispatcher.Invoke in Cleanup of Weak Events

|   |   |
|---|---|
|Details|In .NET Framework 4.7.1 and earlier versions, WPF potentially creates a <xref:System.Windows.Threading.Dispatcher?displayProperty=nameWithType> on the .NET finalizer thread during AppDomain shutdown.  This was fixed in .NET Framework 4.7.2 and later versions by making the cleanup of weak events thread-aware.  Due to this, WPF may call <xref:System.Windows.Threading.Dispatcher.Invoke%2A?displayProperty=nameWithType> to complete the cleanup process.In certain applications, this change in finalizer timing can potentially cause exceptions during AppDomain or process shutdown.  This is generally seen in applications that do not correctly shut down dispatchers running on worker threads prior to process or AppDomain shutdown.  Such applications should take care to properly manage the lifetime of dispatchers.|
|Suggestion|In .NET Framework 4.7.2 and later versions, developers can disable this fix in order to help alleviate (but not eliminate) timing issues that may occur due to the cleanup change.To disable the change in cleanup, use the following AppContext flag.<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.MS.Internal.DoNotInvokeInWeakEventTableShutdownListener=true&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>|
|Scope|Edge|
|Version|4.7.2|
|Type|Retargeting|
