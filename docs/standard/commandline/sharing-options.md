---
title: Sharing options across commands in System.CommandLine
ms.date: 01/23/2026
description: "Learn different approaches for sharing common options across multiple commands, including the Recursive property and factory pattern."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "recursive options"
  - "shared options"
ms.topic: how-to
---

# Sharing options across commands in System.CommandLine

Many CLI applications have options that apply to multiple commands, such as `--verbose`, `--configuration`, or `--output`. This article explains different approaches for sharing options across commands and the trade-offs of each approach.

## The challenge of shared options

Consider a CLI with multiple commands that all need a `--verbose` option:

```csharp
var buildCommand = new Command("build", "Build the project");
buildCommand.Options.Add(new Option<bool>("--verbose", "Enable verbose output"));

var testCommand = new Command("test", "Run tests");
testCommand.Options.Add(new Option<bool>("--verbose", "Enable verbose output"));

var publishCommand = new Command("publish", "Publish the project");
publishCommand.Options.Add(new Option<bool>("--verbose", "Enable verbose output"));
```

This approach has several problems:
- Code duplication
- Inconsistent aliases or descriptions
- Difficult to maintain (changes must be made in multiple places)
- Can't share option instances (each command needs its own instance)

## Approach 1: Recursive options

The `Recursive` property makes an option available to a command and all its subcommands automatically.

### Basic usage

```csharp
var rootCommand = new RootCommand("My application");

var verboseOption = new Option<bool>("--verbose", "-v")
{
    Description = "Enable verbose output",
    Recursive = true  // Available to the command it is added to, and all subcommands of that command
};

rootCommand.Options.Add(verboseOption);

var buildCommand = new Command("build", "Build the project");
var testCommand = new Command("test", "Run tests");
var publishCommand = new Command("publish", "Publish the project");

rootCommand.Subcommands.Add(buildCommand);
rootCommand.Subcommands.Add(testCommand);
rootCommand.Subcommands.Add(publishCommand);

// verboseOption is now available on all commands
// myapp --verbose build
// myapp build --verbose
// myapp test --verbose
```

### Advantages of recursive options

- **Simple to implement** - Add the option once at the root
- **Automatic propagation** - Available everywhere without manual wiring
- **Consistent behavior** - Same aliases and parsing everywhere
- **Single source of truth** - One option definition for the entire CLI

### Disadvantages of recursive options

- **No per-command customization** - Can't change description or help text for specific commands
- **All-or-nothing** - If added to root, applies to every subcommand (even if not needed)
- **Harder to document** - Can't provide command-specific usage examples in help
- **Less explicit** - Not obvious from command definition which options are available

### Example: When customization is needed

```csharp
var rootCommand = new RootCommand();

var configOption = new Option<string>("--configuration", "-c")
{
    Description = "Build configuration",  // Generic description
    Recursive = true
};
rootCommand.Options.Add(configOption);

var buildCommand = new Command("build", "Build the project");
var cleanCommand = new Command("clean", "Clean output");

rootCommand.Subcommands.Add(buildCommand);
rootCommand.Subcommands.Add(cleanCommand);

// Problem: Both commands show "Build configuration"
// but clean doesn't build anything!
// Can't customize the description per command
```

## Approach 2: Factory pattern

Create static factory methods that return new option instances for each command.

### Basic implementation

```csharp
public static class CommonOptions
{
    public static Option<bool> CreateVerboseOption() =>
        new("--verbose", "-v")
        {
            Description = "Enable verbose output",
            Arity = ArgumentArity.Zero
        };

    public static Option<string> CreateConfigurationOption(string description) =>
        new("--configuration", "-c")
        {
            Description = description,  // Customizable per command
            HelpName = "CONFIGURATION"
        };

    public static Option<DirectoryInfo> CreateOutputOption(string description) =>
        new("--output", "-o")
        {
            Description = description
        };
}
```

### Using factory methods

```csharp
var buildCommand = new Command("build", "Build the project");
buildCommand.Options.Add(CommonOptions.CreateVerboseOption());
buildCommand.Options.Add(CommonOptions.CreateConfigurationOption(
    "The build configuration (Debug or Release)"));
buildCommand.Options.Add(CommonOptions.CreateOutputOption(
    "Directory for build output"));

var publishCommand = new Command("publish", "Publish the project");
publishCommand.Options.Add(CommonOptions.CreateVerboseOption());
publishCommand.Options.Add(CommonOptions.CreateConfigurationOption(
    "The publish configuration"));
publishCommand.Options.Add(CommonOptions.CreateOutputOption(
    "Directory for published output"));
```

### Advantages of factory pattern

- **Customizable per command** - Each command can provide its own description
- **Explicit opt-in** - Commands explicitly declare which options they support
- **Type-safe and consistent** - Factory ensures consistent aliases and behavior
- **Command-specific help** - Each command can explain the option in its own context
- **Selective application** - Only add options where they make sense

### Disadvantages of factory pattern

- **More verbose** - Must explicitly add options to each command
- **Not DRY** - Repetitive option addition code
- **Risk of inconsistency** - Developers might forget to add an option to a command
- **More code to maintain** - Factory class needs to be kept up-to-date

### Advanced factory pattern

You can enhance factories with additional features:

```csharp
public static class CommonOptions
{
    // Support customization while providing defaults
    public static Option<bool> CreateVerboseOption(
        string description = "Enable verbose output",
        bool includeDebugAlias = false)
    {
        var aliases = new List<string> { "--verbose", "-v" };
        if (includeDebugAlias)
        {
            aliases.Add("--debug");
        }

        return new Option<bool>([.. aliases])
        {
            Description = description,
            Arity = ArgumentArity.Zero
        };
    }

    // Factory with common default value logic
    public static Option<string> CreateConfigurationOption(
        string description,
        string? defaultValue = null)
    {
        return new Option<string>("--configuration", "-c")
        {
            Description = description,
            DefaultValueFactory = _ => defaultValue ??
                Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") ??
                "Debug"
        };
    }
}
```

## Approach 3: Hybrid approach

Combine both patterns for maximum flexibility.

```csharp
public static class CommonOptions
{
    // Factory for when customization is needed
    public static Option<bool> CreateVerboseOption(string? description = null) =>
        new("--verbose", "-v")
        {
            Description = description ?? "Enable verbose output",
            Arity = ArgumentArity.Zero
        };

    // Singleton for truly global options
    public static readonly Option<bool> DiagnosticsOption = new("--diagnostics", "-d")
    {
        Description = "Enable diagnostics output",
        Recursive = true,
        Arity = ArgumentArity.Zero
    };
}

var rootCommand = new RootCommand();

// Add recursive option once at root
rootCommand.Options.Add(CommonOptions.DiagnosticsOption);

// Use factory for command-specific customization
var buildCommand = new Command("build", "Build the project");
buildCommand.Options.Add(CommonOptions.CreateVerboseOption(
    "Show detailed build output"));

var testCommand = new Command("test", "Run tests");
testCommand.Options.Add(CommonOptions.CreateVerboseOption(
    "Show detailed test output"));

rootCommand.Subcommands.Add(buildCommand);
rootCommand.Subcommands.Add(testCommand);
```

## Choosing an approach

Use **recursive options** when:
- The option has identical meaning across all commands
- You don't need per-command customization of help text
- The option truly applies to every subcommand
- Simplicity is more important than flexibility

Use **factory pattern** when:
- Different commands need different descriptions or help text
- Not all commands need the option
- You want explicit control over which commands have which options
- You need command-specific default values or validation

Use **hybrid approach** when:
- You have both truly global options and customizable options
- Some options need `Recursive` for simplicity
- Other options need per-command descriptions

## Real-world example: .NET CLI

The .NET CLI uses the factory pattern extensively:

```csharp
// From dotnet/sdk repository
public static class CommonOptions
{
    public static Option<string> CreateFrameworkOption(string description) =>
        new("--framework", "-f")
        {
            Description = description,  // Different for each command
            HelpName = "FRAMEWORK"
        };

    public static Option<VerbosityOptions> CreateVerbosityOption() =>
        new("--verbosity", "-v")
        {
            Description = "Set the MSBuild verbosity level",
            HelpName = "LEVEL"
        };
}

// Used in multiple commands with custom descriptions:
// dotnet build --framework: "Target framework for the build"
// dotnet publish --framework: "Target framework to publish for"
// dotnet test --framework: "Target framework to run tests against"
```

This allows each command to provide context-appropriate help text while maintaining consistency in aliases and behavior.

## Best practices

1. **Document your approach** - Make it clear whether you use recursive options or factories
2. **Be consistent** - Don't mix patterns for similar options
3. **Centralize definitions** - Keep all shared option logic in one place
4. **Use meaningful descriptions** - Especially with factories, tailor descriptions to each command
5. **Consider maintenance** - Factor pattern is more code but easier to customize later

## See also

- [System.CommandLine overview](index.md)
- [How to customize help](how-to-customize-help.md)
- [Environment variables in options](environment-variables.md)
