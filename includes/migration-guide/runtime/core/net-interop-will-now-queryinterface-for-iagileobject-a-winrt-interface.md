### .NET Interop will now QueryInterface for IAgileObject (a WinRT interface)

|   |   |
|---|---|
|Details|When using a WinRT event with a .NET delegate, Windows will QI for IAgileObject starting with the .NET Framework 4.8.  In previous versions of the .NET Framework, the runtime would fail that QI, and the event could not be subscribed.<ul><li>[ x ] Quirked</li></ul>|
|Suggestion|If enabling the QI for IAgileObject breaks execution, you can disable this code by setting the following configuration. <h4>Method 1: Environment variable</h4> Set the following environment variable:COMPLUS_DisableCCWSupportIAgileObject=1This method affects any environment that inherits this environment variable. This might be just a single console session, or it might affect the entire machine if you set the environment variable globally. The environment variable name is not case-sensitive. <h4>Method 2: Registry</h4> Using Registry Editor (regedit.exe), find either of the following subkeys:HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft.NETFramework HKEY_CURRENT_USER\SOFTWARE\Microsoft.NETFrameworkThen add the following:Value name: DisableCCWSupportIAgileObject Type: DWORD (32-bit) Value (also called REG_WORD) Value: 1You can use the Windows REG.EXE tool to add this value from a command-line or scripting environment. For example:<pre><code class="lang-console">reg add HKLM\SOFTWARE\Microsoft\.NETFramework /v DisableCCWSupportIAgileObject /t REG_DWORD /d 1&#13;&#10;</code></pre>In this case, <code>HKLM</code> is used instead of <code>HKEY_LOCAL_MACHINE</code>. Use <code>reg add /?</code> to see help on this syntax. The registry value name is not case-sensitive.|
|Scope|Edge|
|Version|4.8|
|Type|Runtime|
