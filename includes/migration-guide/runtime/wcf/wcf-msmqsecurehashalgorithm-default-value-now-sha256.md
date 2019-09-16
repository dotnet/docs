### WCF MsmqSecureHashAlgorithm default value is now SHA256

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.7.1, the default message signing algorithm in WCF for Msmq messages is SHA256. In the .NET Framework 4.7 and earlier versions, the default message signing algorithm is SHA1.|
|Suggestion|If you run into compatibility issues with this change on the .NET Framework 4.7.1 or later, you can opt-out the change by adding the following line to the <code>&lt;runtime&gt;</code>section of your app.config file:<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.ServiceModel.UseSha1InMsmqEncryptionAlgorithm=true&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>|
|Scope|Minor|
|Version|4.7.1|
|Type|Runtime|
