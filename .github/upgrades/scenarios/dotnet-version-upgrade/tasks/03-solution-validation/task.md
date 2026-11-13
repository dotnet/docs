# 03-solution-validation: Validate the upgraded solution

Restore and build the complete solution, then run any tests discovered for its projects. Check the sample's plugin-host behavior where the project structure supports a direct run, and report any validation step that the solution does not provide.

## Research

- The solution contains no test projects; Test Explorer found no tests for `AppWithPlugin`, `HelloPlugin`, or `PluginBase`.
- `AppWithPlugin\Program.cs` hard-codes all five plugin output paths to `net5`, so these paths must follow the upgraded TFM.
- Only `HelloPlugin.csproj` is present among those five plugin projects. `JsonPlugin`, `OldJsonPlugin`, `FrenchPlugin`, and `UVPlugin` are not in this solution or tutorial folder, limiting end-to-end host validation.

**Done when**: The full solution builds without warnings or errors, no available tests are left unrun, plugin paths in the host use `net11.0`, and any runtime check limitation caused by absent plugin projects is documented.
