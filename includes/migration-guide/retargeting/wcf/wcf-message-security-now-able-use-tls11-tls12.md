### WCF message security now is able to use TLS1.1 and TLS1.2

|   |   |
|---|---|
|Details|Starting in the .NET Framework 4.7, customers can configure either TLS1.1 or TLS1.2 in WCF message security in addition to SSL3.0 and TLS1.0 through application configuration settings.|
|Suggestion|In the .NET Framework 4.7, support for TLS1.1 and TLS1.2 in WCF message security is disabled by default. You can enable it by adding the following line to the <code>&lt;runtime&gt;</code> section of the app.config or web.config file:<pre><code class="lang-xml">&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols=false;Switch.System.Net.DontEnableSchUseStrongCrypto=false&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
