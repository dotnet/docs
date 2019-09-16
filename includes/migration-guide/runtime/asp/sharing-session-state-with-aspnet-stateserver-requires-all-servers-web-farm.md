### Sharing session state with Asp.Net StateServer requires all servers in the web farm to use the same .NET Framework version

|   |   |
|---|---|
|Details|When enabling <xref:System.Web.SessionState.SessionStateMode.StateServer?displayProperty=name> session state, all of the servers in the given web farm must use the same version of the .NET Framework in order for state to be properly shared.|
|Suggestion|Be sure to upgrade .NET Framework versions on web servers that share state at the same time.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Web.SessionState.SessionStateMode.StateServer?displayProperty=nameWithType></li></ul>|
