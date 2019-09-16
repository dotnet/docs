### Throttle concurrent requests per session

|   |   |
|---|---|
|Details|In the .NET Framework 4.6.2 and earlier, ASP.NET executes requests with the same Sessionid sequentially, and ASP.NET always issues the Sessionid through cookies by default. If a page takes a long time to respond, it will significantly degrade server performance just by pressing F5 on the browser. In the fix, we added a counter to track the queued requests and terminate the requests when they exceed a specified limit. The default value is 50. If the limit is reached, a warning will be logged in the event log, and an HTTP 500 response may be recorded in the IIS log.|
|Suggestion|To restore the old behavior, you can add the following setting to your web.config file to opt out of the new behavior.<pre><code class="lang-xml">&lt;appSettings&gt;&#13;&#10;&lt;add key=&quot;aspnet:RequestQueueLimitPerSession&quot; value=&quot;2147483647&quot;/&gt;&#13;&#10;&lt;/appSettings&gt;&#13;&#10;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
