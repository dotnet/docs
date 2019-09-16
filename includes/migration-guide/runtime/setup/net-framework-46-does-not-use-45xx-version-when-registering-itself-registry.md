### The .NET Framework 4.6 does not use a 4.5.x.x version when registering itself in the registry

|   |   |
|---|---|
|Details|As one might expect, the version key set in the registry (at <code>HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v4\Full</code>) for the .NET Framework 4.6 begins with '4.6', not '4.5'. Apps that depend on these registry keys to know which .NET Framework versions are installed on a machine should be updated to understand that 4.6 is a new possible version, and one that is compatible with previous 4.5.x releases.|
|Suggestion|Update apps probing for a .NET Framework 4.5 install by looking for 4.5 registry keys to also accept 4.6.|
|Scope|Edge|
|Version|4.6|
|Type|Runtime|
