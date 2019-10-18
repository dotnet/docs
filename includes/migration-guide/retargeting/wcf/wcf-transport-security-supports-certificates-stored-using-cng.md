### WCF transport security supports certificates stored using CNG

|   |   |
|---|---|
|Details|Starting with apps that target the .NET Framework 4.6.2, WCF transport security supports certificates stored using the Windows Cryptography Library (CNG). This support is limited to certificates with a public key that has an exponent no more than 32 bits in length. When an application targets the .NET Framework 4.6.2, this feature is on by default.In earlier versions of the .NET Framework, the attempt to use X509 certificates with a CSG key storage provider throws an exception.|
|Suggestion|Apps that target the .NET Framework 4.6.1 and earlier but are running on the .NET Framework 4.6.2 can enable support for CNG certificates by adding the following line to the <code>&lt;runtime&gt;</code> section of the app.config or web.config file:<pre><code class="lang-xml">&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.ServiceModel.DisableCngCertificates=false&quot; /&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;</code></pre>This can also be done programmatically with the following code:<pre><code class="lang-cs">private const string DisableCngCertificates = @&quot;Switch.System.ServiceModel.DisableCngCertificate&quot;;&#13;&#10;AppContext.SetSwitch(disableCngCertificates, false);&#13;&#10;</code></pre><pre><code class="lang-vb">Const DisableCngCertificates As String = &quot;Switch.System.ServiceModel.DisableCngCertificates&quot;&#13;&#10;AppContext.SetSwitch(disableCngCertificates, False)&#13;&#10;</code></pre>Note that, because of this change, any exception handling code that depends on the attempt to initiate secure communication with a CNG certificate to fail will no longer execute.|
|Scope|Minor|
|Version|4.6.2|
|Type|Retargeting|
