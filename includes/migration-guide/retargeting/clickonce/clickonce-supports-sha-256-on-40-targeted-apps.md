### ClickOnce supports SHA-256 on 4.0-targeted apps

|   |   |
|---|---|
|Details|Previously, a ClickOnce app with a certificate signed with SHA-256 would require .NET Framework 4.5 or later to be present, even if the app targeted 4.0. Now, .NET Framework 4.0-targeted ClickOnce apps can run on .NET Framework 4.0, even if signed with SHA-256.|
|Suggestion|This change removes that dependency and allows SHA-256 certificates to be used to sign ClickOnce apps that target .NET Framework 4 and earlier versions.|
|Scope|Minor|
|Version|4.6|
|Type|Retargeting|
