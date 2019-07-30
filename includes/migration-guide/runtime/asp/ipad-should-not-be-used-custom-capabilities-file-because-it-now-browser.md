### IPad should not be used in custom capabilities file because it is now a browser capability

|   |   |
|---|---|
|Details|Beginning in .NET Framework 4.5, iPad is an identifier in the default ASP.NET browser capabilities file, so it should not be used in a custom capabilities file|
|Suggestion|If iPad-specific capabilities are required, it is necessary to modify iPad behavior by setting capabilities on the pre-defined gateway refID &quot;IPad&quot; instead of by generating a new &quot;IPad&quot; ID by user agent matching.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
