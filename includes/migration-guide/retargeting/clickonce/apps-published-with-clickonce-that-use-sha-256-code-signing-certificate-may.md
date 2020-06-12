### Apps published with ClickOnce that use a SHA-256 code-signing certificate may fail on Windows 2003

|   |   |
|---|---|
|Details|The executable is signed with SHA256. Previously, it was signed with SHA1 regardless of whether the code-signing certificate was SHA-1 or SHA-256. This applies to:<ul><li>All applications built with Visual Studio 2012 or later.</li><li>Applications built with Visual Studio 2010 or earlier on systems with the .NET Framework 4.5 present.</li></ul>In addition, if the .NET Framework 4.5 or later is present, the ClickOnce manifest is also signed with SHA-256 for SHA-256 certificates regardless of the .NET Framework version against which it was compiled.|
|Suggestion|The change in signing the ClickOnce executable affects only Windows Server 2003 systems; they require that KB 938397 be installed. The change in signing the manifest with SHA-256 even when an app targets the .NET Framework 4.0 or earlier versions introduces a runtime dependency on the .NET Framework 4.5 or a later version.|
|Scope|Edge|
|Version|4.5|
|Type|Retargeting|
