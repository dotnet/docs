### Building an Entity Framework edmx with Visual Studio 2013 can fail with error MSB4062 if using the EntityDeploySplit or EntityClean tasks

|   |   |
|---|---|
|Details|MSBuild 12.0 tools (included in Visual Studio 2013) changed MSBuild file locations, causing older Entity Framework targets files to be invalid. The result is that <code>EntityDeploySplit</code> and <code>EntityClean</code> tasks fail because they are unable to find <code>Microsoft.Data.Entity.Build.Tasks.dll</code>. Note that this break is because of a toolset (MSBuild/VS) change, not because of a .NET Framework change. It will only occur when upgrading developer tools, not when merely upgrading the .NET Framework.|
|Suggestion|Entity Framework targets files are fixed to work with the new MSBuild layout beginning in the .NET Framework 4.6. Upgrading to that version of the Framework will fix this issue. Alternatively, [this workaround](https://stackoverflow.com/a/24249247/131944) can be used to patch the targets files directly.|
|Scope|Major|
|Version|4.5.1|
|Type|Retargeting|

