### Throttle concurrent requests per session

|   |   |
|---|---|
|Details|In the .NET Framework 4.6.2 and earlier, Asp.net executes requests with the same Sessionid sequentially, and asp.net always issues the Sessionid through cookie by default. If a page takes long time to response, it will significantly degrade the server performance just by pressing F5 on the browser. In the fix, we added a counter to track the queued requests and terminates the requests when they exceed a specified limit. The default value is 50. If the the limit is reached, a warning will be logged in event log and HTTP 500 response may be recorded in IIS log.|
|Suggestion|To restore the old behavior, you can add the following setting to your web.config file to opt out of the new behavior.<br /><pre><code>&lt;appSettings&gt;<br />&lt;add key=&quot;aspnet:RequestQueueLimitPerSession&quot; value=&quot;2147483647&quot;/&gt;<br />&lt;/appSettings&gt;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
