# AppWithPlugin Demo

This sample demonstrates how to create an app with a plugin architecture, using the `AssemblyDependencyResolver` type and a custom `AssemblyLoadContext` to help load plugins with assembly dependencies.

## About `AssemblyDependencyResolver`

Without using `AssemblyDependencyResolver`, it is extremely difficult to correctly load plugins that have their own dependencies.

By using `AssemblyDependencyResolver` along with a custom `AssemblyLoadContext`, an application can load plugins so that each plugin's dependencies are loaded from the correct location, and one plugin's dependencies will not conflict with another. This sample includes plugins that have conflicting dependencies and plugins that rely on satellite assemblies or native libraries.

## Build and Run

1. Install .NET Core 3.0 Preview 2 or newer.
2. Use the .NET Core SDK to build the project via `dotnet build`.
   - The AppWithPlugin project does not contain any references to the plugin projects, so you need to build the solution.
3. Go to the AppWithPlugin directory and use `dotnet run` to run the app.
    - You should see the app output a list of installed commands.
4. In the AppWithPlugin directory, use `dotnet run commandName [commandName2...]` where `commandName1` and `commandName2` and so on are names that were output in step 3. Note that you can run as many commands as you want at once.
   - You should see the app run the supplied commands, even when the commands have conflicting dependencies.
