### The default hash algorithm for WPF's Markup Compiler is now SHA256

|   |   |
|---|---|
|Details|The WPF MarkupCompiler provides compilation services for XAML markup files.  In the .NET Framework 4.7.1 and earlier versions, the default hash algorithm used for checksums was SHA1. Due to recent security concerns with SHA1, this default has been changed to SHA256 starting with the .NET Framework 4.7.2.  This change affects all checksum generation for markup files during compilation.|
|Suggestion|A developer who targets .NET Framework 4.7.2 or greater and wants to revert to SHA1 hashing behavior must set the following AppContext flag.<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Windows.Markup.DoNotUseSha256ForMarkupCompilerChecksumAlgorithm=true&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>A developer who wants to utilize SHA256 hashing while targeting a framework version below .NET 4.7.2 must set the below AppContext flag.  Note that the installed version of the .NET Framework must be 4.7.2 or greater.<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Windows.Markup.DoNotUseSha256ForMarkupCompilerChecksumAlgorithm=false&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>|
|Scope|Transparent|
|Version|4.7.2|
|Type|Retargeting|
