# Progress

The full `AppWithPlugin.sln` build succeeded after the .NET 11 changes. Test Explorer found no tests for `AppWithPlugin`, `HelloPlugin`, or `PluginBase`. `git diff --check` passed, and a scoped search found no remaining `net5` or Visual Studio 15 version strings in this C# solution folder.

Updated the host's five hard-coded plugin output paths to `net11.0`. Runtime verification confirmed that the included `HelloPlugin.dll` loads from its new `net11.0` output path. The host then reports a missing `JsonPlugin.dll`; `JsonPlugin`, `OldJsonPlugin`, `FrenchPlugin`, and `UVPlugin` are not included in this solution or tutorial folder, so the complete multi-plugin host scenario cannot be exercised from this solution alone. This limitation predates the upgrade's project inventory and is documented rather than masked by changing sample behavior.

The separate staged/unstaged HostWithHostFxr solution change remains untouched.
