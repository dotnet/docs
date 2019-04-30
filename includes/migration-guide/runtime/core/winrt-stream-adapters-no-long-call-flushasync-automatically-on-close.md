### WinRT stream adapters no long call FlushAsync automatically on close

|   |   |
|---|---|
|Details|In Windows Store apps, Windows Runtime stream adapters no longer call the FlushAsync method from the Dispose method.|
|Suggestion|This change should be transparent. Developers can restore the previous behavior by writing code like this:<pre><code class="lang-csharp">using (var stream = GetWindowsRuntimeStream() as Stream)&#13;&#10;{&#13;&#10;// do something&#13;&#10;await stream.FlushAsync();&#13;&#10;}&#13;&#10;</code></pre>|
|Scope|Transparent|
|Version|4.5.1|
|Type|Runtime|
