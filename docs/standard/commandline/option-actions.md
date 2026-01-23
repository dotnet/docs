---
title: Option actions for cross-cutting behaviors in System.CommandLine
ms.date: 01/23/2026
description: "Learn how to use the Action property on options to implement middleware-like behaviors such as debugging, logging, and early termination."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "option actions"
  - "middleware"
  - "cross-cutting concerns"
ms.topic: how-to
---

# Option actions for cross-cutting behaviors in System.CommandLine

The `Action` property on options allows you to implement middleware-like behaviors that execute before your main command logic. This article explains how to use option actions for cross-cutting concerns like debugging, early termination, and global state configuration.

## What are option actions?

An option action is code that executes when an option is present, before the command handler runs. Actions are useful for:
- **Debugging** - Waiting for debugger attachment
- **Early termination** - Exiting before running the command (like `--version` or `--help`)
- **Global configuration** - Setting up logging, telemetry, or other global state
- **Side effects** - Performing actions that don't affect the command's return value

## Basic option action

The simplest action is a synchronous operation:

```csharp
using System.CommandLine;
using System.CommandLine.Invocation;

var debugOption = new Option<bool>("--debug")
{
    Description = "Wait for debugger to attach",
    Arity = ArgumentArity.Zero,
    Action = new SynchronousCommandLineAction
    {
        Name = "WaitForDebugger"
    }
};

// Implement the action
class WaitForDebuggerAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        if (parseResult.GetValue(debugOption))
        {
            Console.WriteLine("Waiting for debugger to attach...");
            Console.WriteLine($"Process ID: {Environment.ProcessId}");
            
            while (!System.Diagnostics.Debugger.IsAttached)
            {
                System.Threading.Thread.Sleep(100);  
            }
            
            Console.WriteLine("Debugger attached!");
            System.Diagnostics.Debugger.Break();
        }
        
        return 0;  // Continue to command handler
    }
}

debugOption.Action = new WaitForDebuggerAction();
```

## Terminating actions

Some actions should prevent the command from running. Use the `Terminating` property:

```csharp
class VersionAction : SynchronousCommandLineAction
{
    public override bool Terminating => true;  // Don't run command handler
    
    public override int Invoke(ParseResult parseResult)
    {
        var version = typeof(Program).Assembly.GetName().Version;
        Console.WriteLine($"MyApp version {version}");
        return 0;
    }
}

var versionOption = new Option<bool>("--version")
{
    Description = "Display version information",
    Arity = ArgumentArity.Zero,
    Action = new VersionAction()
};

// Command line: myapp --version
// Output: MyApp version 1.2.3.0
// (command handler does not run)
```

## Real-world example: Debug option

A complete implementation of a `--debug` option with conditional compilation:

```csharp
class DebugAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        #if DEBUG
        Console.WriteLine($"Process ID: {Environment.ProcessId}");
        Console.WriteLine("Waiting for debugger...");
        Console.WriteLine("Attach a debugger and press Enter to continue.");
        Console.ReadLine();
        
        if (System.Diagnostics.Debugger.IsAttached)
        {
            System.Diagnostics.Debugger.Break();
        }
        #else
        Console.WriteLine("Debug option is only available in Debug builds.");
        #endif
        
        return 0;
    }
}

var debugOption = new Option<bool>("--debug")
{
    Description = "Wait for debugger to attach (Debug builds only)",
    Arity = ArgumentArity.Zero,
    Action = new DebugAction()
};
```

Usage:
```bash
# Start the app
myapp --debug my-command --arg value

# Output:
# Process ID: 12345
# Waiting for debugger...
# Attach a debugger and press Enter to continue.

# After attaching debugger and pressing Enter:
# (Debugger breaks at current line)
# (Then continues to execute my-command)
```

## Logging and telemetry configuration

Use actions to set up global logging before the command runs:

```csharp
class VerboseAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        if (parseResult.GetValue(verboseOption))
        {
            // Enable verbose logging globally
            LogLevel.Minimum = LogLevel.Debug;
            Console.WriteLine("Verbose logging enabled");
        }
        
        return 0;
    }
}

var verboseOption = new Option<bool>("--verbose", "-v")
{
    Description = "Enable verbose output",
    Arity = ArgumentArity.Zero,
    Recursive = true,  // Available to all subcommands
    Action = new VerboseAction()
};

// The action runs before any command handler
// All subsequent logging respects the verbose setting
```

## Diagnostic schema output

The .NET CLI uses this pattern to output schema information:

```csharp
class PrintSchemaAction : SynchronousCommandLineAction
{
    public override bool Terminating => true;
    
    public override int Invoke(ParseResult parseResult)
    {
        // Generate and print CLI schema
        var schema = GenerateSchema(parseResult.CommandResult.Command);
        Console.WriteLine(schema);
        return 0;
    }
    
    private string GenerateSchema(Command command)
    {
        // Serialize command structure to JSON
        return JsonSerializer.Serialize(new
        {
            command.Name,
            command.Description,
            Options = command.Options.Select(o => new { o.Name, o.Description }),
            Subcommands = command.Subcommands.Select(c => c.Name)
        }, new JsonSerializerOptions { WriteIndented = true });
    }
}

var schemaOption = new Option<bool>("--cli-schema")
{
    Description = "Output CLI schema as JSON",
    Hidden = true,  // Not shown in normal help
    Arity = ArgumentArity.Zero,
    Recursive = true,
    Action = new PrintSchemaAction()
};
```

## Asynchronous actions

For async operations, use `AsynchronousCommandLineAction`:

```csharp
class TelemetryAction : AsynchronousCommandLineAction
{
    public override async Task<int> InvokeAsync(ParseResult parseResult, 
        CancellationToken cancellationToken = default)
    {
        var optOut = Environment.GetEnvironmentVariable("TELEMETRY_OPTOUT");
        if (optOut == "1")
        {
            return 0;  // Skip telemetry
        }
        
        try
        {
            // Send anonymous usage data
            await TelemetryClient.TrackCommandAsync(
                parseResult.CommandResult.Command.Name,
                cancellationToken);
        }
        catch
        {
            // Never fail on telemetry errors
        }
        
        return 0;
    }
}

var rootCommand = new RootCommand();
// Add action directly to the command
rootCommand.Action = new TelemetryAction();
```

## Combining multiple actions

When multiple options have actions, they execute in the order the options are added:

```csharp
var rootCommand = new RootCommand("My app");

var diagnosticsOption = new Option<bool>("--diagnostics", "-d")
{
    Arity = ArgumentArity.Zero,
    Recursive = true,
    Action = new DiagnosticsAction()  // Runs first
};

var profileOption = new Option<bool>("--profile")
{
    Arity = ArgumentArity.Zero,
    Action = new ProfilingAction()  // Runs second
};

rootCommand.Options.Add(diagnosticsOption);
rootCommand.Options.Add(profileOption);

// Command line: myapp --diagnostics --profile build
// Execution order:
// 1. DiagnosticsAction
// 2. ProfilingAction
// 3. build command handler
```

## Action execution flow

Understanding when actions execute:

```csharp
class LoggingAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        Console.WriteLine("Action: Setting up logging");
        return 0;
    }
}

var rootCommand = new RootCommand();
rootCommand.Options.Add(new Option<bool>("--log")
{
    Arity = ArgumentArity.Zero,
    Action = new LoggingAction()
});

var buildCommand = new Command("build", "Build project");
buildCommand.SetAction((bool log) =>
{
    Console.WriteLine("Handler: Building project");
    return 0;
});

rootCommand.Subcommands.Add(buildCommand);

// Command line: myapp --log build
// Output:
// Action: Setting up logging
// Handler: Building project
```

The flow is:
1. Parse command line
2. Execute option actions (in order added)
3. If any action is terminating and returns non-zero, stop
4. Execute command handler
5. Return exit code

## Conditional actions

Actions can check the parse result to run conditionally:

```csharp
class ConditionalAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        // Only run for specific commands
        if (parseResult.CommandResult.Command.Name == "deploy")
        {
            Console.WriteLine("WARNING: This will deploy to production!");
            Console.Write("Are you sure? (yes/no): ");
            var response = Console.ReadLine();
            
            if (response?.ToLowerInvariant() != "yes")
            {
                Console.WriteLine("Deployment cancelled.");
                return 1;  // Non-zero exit code stops execution
            }
        }
        
        return 0;
    }
}

var confirmOption = new Option<bool>("--confirm")
{
    Description = "Confirm dangerous operations",
    Arity = ArgumentArity.Zero,
    Recursive = true,
    Action = new ConditionalAction()
};
```

## Error handling in actions

Actions should handle errors gracefully:

```csharp
class SafeAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        try
        {
            // Potentially failing operation
            InitializeExternalDependency();
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Initialization failed: {ex.Message}");
            Console.Error.WriteLine("Run with --help for usage information.");
            return 1;  // Return error code to stop execution
        }
    }
}
```

## Best practices

### Keep actions focused

Actions should do one thing:

```csharp
// GOOD: Focused action
class DebugAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        WaitForDebugger();
        return 0;
    }
}

// BAD: Kitchen sink action
class MegaAction : SynchronousCommandLineAction
{
    public override int Invoke(ParseResult parseResult)
    {
        SetupLogging();
        InitializeTelemetry();
        CheckForUpdates();
        WaitForDebugger();
        ValidateLicense();
        // Too many responsibilities!
        return 0;
    }
}
```

### Use terminating actions for early exits

```csharp
// Options that should prevent command execution
var versionOption = new Option<bool>("--version") 
{ 
    Arity = ArgumentArity.Zero,
    Action = new VersionAction() { Terminating = true }
};

var licenseOption = new Option<bool>("--license")
{
    Arity = ArgumentArity.Zero,
    Action = new LicenseAction() { Terminating = true }
};
```

### Document action behavior

Make it clear in help text when actions have side effects:

```csharp
var debugOption = new Option<bool>("--debug")
{
    Description = "Wait for debugger to attach before executing command",
    Arity = ArgumentArity.Zero,
    Action = new DebugAction()
};
```

### Be cautious with recursive actions

Recursive options with actions run for every subcommand:

```csharp
var diagnosticsOption = new Option<bool>("--diagnostics")
{
    Description = "Enable diagnostic output",
    Arity = ArgumentArity.Zero,
    Recursive = true,  // Action runs for root AND subcommands
    Action = new DiagnosticsAction()
};

// Can lead to the action running multiple times!
// Be idempotent or check if already executed
```

## Limitations

- Actions cannot access the command handler's return value
- Actions cannot directly modify the ParseResult
- Terminating actions prevent the command handler from running
- Action execution order depends on option order, which may not be obvious

## See also

- [How to parse and invoke the result](how-to-parse-and-invoke.md)
- [How to customize parsing and validation](how-to-customize-parsing-and-validation.md)
- [Sharing options across commands](sharing-options.md)
