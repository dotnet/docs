### WinRT stream adapters no long call FlushAsync automatically on close

|   |   |
|---|---|
|Details|In Windows Store apps, Windows Runtime stream adapters no longer call the FlushAsync method from the Dispose method.|
|Suggestion|This change should be transparent. Developers can restore the previous behavior by writing code like this:<pre><code>using (var stream = GetWindowsRuntimeStream() as Stream)<br />{<br />// do something<br />await stream.FlushAsync();<br />}</code></pre>|
|Scope|Transparent|
|Version|4.5.1|
|Type|Runtime|

