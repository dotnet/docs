---
title: Using environment variables with System.CommandLine
ms.date: 01/23/2026
description: "Learn how to integrate environment variables into command-line options using DefaultValueFactory and CustomParser."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "environment variables"
  - "default values"
ms.topic: how-to
---

# Using environment variables with System.CommandLine

Command-line applications often need to read configuration from environment variables. This article explains how to integrate environment variables into your CLI using `DefaultValueFactory` and `CustomParser`.

## Why environment variables?

Environment variables are useful for:
- **CI/CD pipelines** - Set configuration without changing command lines
- **User preferences** - Allow users to set defaults in their shell profile
- **Sensitive data** - Avoid passing secrets via command-line arguments (which appear in process lists)
- **Container orchestration** - Configure applications via environment in Docker/Kubernetes
- **Fallback values** - Provide defaults when command-line options aren't specified

## Using DefaultValueFactory

The `DefaultValueFactory` property lets you compute default values at parse time, including reading from environment variables.

### Basic environment variable fallback

```csharp
var apiKeyOption = new Option<string>("--api-key")
{
    Description = "API key for authentication (or set API_KEY environment variable)",
    DefaultValueFactory = _ => Environment.GetEnvironmentVariable("API_KEY")
};

// Command line: myapp           → reads from API_KEY env var
// Command line: myapp --api-key abc123  → uses "abc123"
```

The environment variable is only used when the option isn't specified on the command line.

### Multiple fallback levels

```csharp
var configOption = new Option<string>("--configuration", "-c")
{
    Description = "Build configuration",
    DefaultValueFactory = _ =>
        Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") ??
        Environment.GetEnvironmentVariable("CONFIGURATION") ??
        "Debug"  // Final fallback
};

// Priority:
// 1. Command line: --configuration Release
// 2. BUILD_CONFIGURATION environment variable
// 3. CONFIGURATION environment variable
// 4. Hard-coded default: "Debug"
```

### Environment-aware defaults

Adjust defaults based on the environment:

```csharp
private static bool IsCIEnvironment() =>
    !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI")) ||
    !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TF_BUILD")) ||
    !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITHUB_ACTIONS"));

var interactiveOption = new Option<bool>("--interactive")
{
    Description = "Enable interactive mode",
    DefaultValueFactory = _ => !IsCIEnvironment() && !Console.IsOutputRedirected
};

// Automatically defaults to:
// - false in CI environments
// - false when output is redirected
// - true in normal interactive terminal sessions
```

### Parsing environment variable values

Some environment variables need type conversion:

```csharp
var parallelOption = new Option<int>("--parallel", "-p")
{
    Description = "Number of parallel operations (or set MAX_PARALLELISM)",
    DefaultValueFactory = _ =>
    {
        var envValue = Environment.GetEnvironmentVariable("MAX_PARALLELISM");
        if (int.TryParse(envValue, out var parsed))
        {
            return parsed;
        }
        return Environment.ProcessorCount;  // Default to CPU count
    }
};
```

### Boolean environment variables

Parse truthy/falsy environment variable values:

```csharp
public static bool ParseBooleanEnvVar(string? value, bool defaultValue = false)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return defaultValue;
    }

    var normalized = value.Trim().ToLowerInvariant();
    return normalized switch
    {
        "true" or "1" or "yes" or "on" or "enabled" => true,
        "false" or "0" or "no" or "off" or "disabled" => false,
        _ => defaultValue
    };
}

var verboseOption = new Option<bool>("--verbose", "-v")
{
    Description = "Enable verbose output (or set VERBOSE=true)",
    DefaultValueFactory = _ => 
        ParseBooleanEnvVar(Environment.GetEnvironmentVariable("VERBOSE"))
};
```

### File path expansion

Expand environment variables in file paths:

```csharp
var outputOption = new Option<DirectoryInfo>("--output", "-o")
{
    Description = "Output directory",
    DefaultValueFactory = _ =>
    {
        var path = Environment.GetEnvironmentVariable("OUTPUT_DIR") ?? "./bin";
        var expanded = Environment.ExpandEnvironmentVariables(path);
        return new DirectoryInfo(expanded);
    }
};

// Supports: OUTPUT_DIR=%USERPROFILE%\builds
// Expands to: C:\Users\username\builds
```

## Using CustomParser with environment variables

For more complex scenarios, use `CustomParser` to combine command-line and environment variable input.

### Override or augment with environment variables

```csharp
var sourcesOption = new Option<List<string>>("--source", "-s")
{
    Description = "Package sources (or set NUGET_SOURCES)",
    Arity = ArgumentArity.ZeroOrMore,
    CustomParser = result =>
    {
        var sources = new List<string>();
        
        // Add sources from command line
        sources.AddRange(result.Tokens.Select(t => t.Value));
        
        // Add sources from environment variable
        var envSources = Environment.GetEnvironmentVariable("NUGET_SOURCES");
        if (!string.IsNullOrEmpty(envSources))
        {
            sources.AddRange(envSources.Split(';', StringSplitOptions.RemoveEmptyEntries));
        }
        
        // Add default if nothing provided
        if (sources.Count == 0)
        {
            sources.Add("https://api.nuget.org/v3/index.json");
        }
        
        return sources;
    }
};

// Command line: --source https://myget.org
// NUGET_SOURCES: https://private.feed;https://backup.feed
// Result: All three sources are used
```

### Environment variable as required fallback

```csharp
var connectionStringOption = new Option<string>("--connection-string")
{
    Description = "Database connection string (or set DB_CONNECTION_STRING)",
    CustomParser = result =>
    {
        // Check command line first
        if (result.Tokens.Count > 0)
        {
            return result.Tokens.Single().Value;
        }
        
        // Fall back to environment variable
        var envValue = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if (!string.IsNullOrEmpty(envValue))
        {
            return envValue;
        }
        
        // Neither provided - error
        result.AddError("Connection string must be provided via --connection-string or DB_CONNECTION_STRING environment variable");
        return null;
    }
};
```

### Validate environment variable values

```csharp
var timeoutOption = new Option<TimeSpan>("--timeout")
{
    Description = "Request timeout (or set REQUEST_TIMEOUT in seconds)",
    CustomParser = result =>
    {
        TimeSpan parsed;
        
        if (result.Tokens.Count > 0)
        {
            // Parse from command line
            if (!TimeSpan.TryParse(result.Tokens.Single().Value, out parsed))
            {
                result.AddError($"Invalid timeout format: {result.Tokens.Single().Value}");
                return default;
            }
        }
        else
        {
            // Parse from environment variable
            var envValue = Environment.GetEnvironmentVariable("REQUEST_TIMEOUT");
            if (envValue != null && int.TryParse(envValue, out var seconds))
            {
                parsed = TimeSpan.FromSeconds(seconds);
            }
            else
            {
                parsed = TimeSpan.FromSeconds(30);  // Default
            }
        }
        
        // Validate the value
        if (parsed > TimeSpan.FromMinutes(10))
        {
            result.AddError("Timeout cannot exceed 10 minutes");
            return default;
        }
        
        return parsed;
    }
};
```

## Patterns and best practices

### Document environment variables in help text

Make environment variables discoverable:

```csharp
var option = new Option<string>("--api-url")
{
    Description = "API endpoint URL (default: API_URL environment variable or https://api.example.com)"
};
```

### Prefix environment variables consistently

Use a consistent prefix for your application:

```csharp
public static class AppEnvironment
{
    private const string Prefix = "MYAPP_";
    
    public static string? GetValue(string name) =>
        Environment.GetEnvironmentVariable($"{Prefix}{name}");
    
    public static T GetValue<T>(string name, T defaultValue, Func<string, T> parser)
    {
        var value = GetValue(name);
        return value != null ? parser(value) : defaultValue;
    }
}

var verboseOption = new Option<bool>("--verbose")
{
    DefaultValueFactory = _ => 
        AppEnvironment.GetValue("VERBOSE", false, bool.Parse)
};
```

### Lazy evaluation for expensive operations

Use `DefaultValueFactory` for expensive operations that should only run when needed:

```csharp
private static readonly Lazy<string> CachedUserDirectory = new(() =>
{
    // Expensive: might hit network, read multiple files, etc.
    return FindUserConfigurationDirectory();
});

var configOption = new Option<string>("--config-dir")
{
    Description = "Configuration directory",
    DefaultValueFactory = _ => 
        Environment.GetEnvironmentVariable("CONFIG_DIR") ?? 
        CachedUserDirectory.Value
};
```

### Combine with validation

```csharp
var portOption = new Option<int>("--port", "-p")
{
    Description = "Server port (or set PORT environment variable)",
    DefaultValueFactory = _ =>
    {
        var envValue = Environment.GetEnvironmentVariable("PORT");
        return int.TryParse(envValue, out var port) ? port : 8080;
    }
};

portOption.Validators.Add(result =>
{
    var port = result.GetValue<int>();
    if (port < 1 || port > 65535)
    {
        result.AddError($"Port must be between 1 and 65535, got {port}");
    }
});
```

### Provide dotenv file support

Read environment variables from a `.env` file:

```csharp
public static void LoadDotEnvFile(string filePath = ".env")
{
    if (!File.Exists(filePath))
    {
        return;
    }
    
    foreach (var line in File.ReadAllLines(filePath))
    {
        var trimmed = line.Trim();
        if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith('#'))
        {
            continue;
        }
        
        var parts = trimmed.Split('=', 2);
        if (parts.Length == 2)
        {
            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
        }
    }
}

// Load before parsing
LoadDotEnvFile();
var parseResult = rootCommand.Parse(args);
```

## Security considerations

### Avoid logging environment variable values

Be careful not to log sensitive environment variables:

```csharp
var apiKeyOption = new Option<string>("--api-key")
{
    DefaultValueFactory = _ =>
    {
        var key = Environment.GetEnvironmentVariable("API_KEY");
        
        // DON'T: Log the actual key
        // Console.WriteLine($"Using API key: {key}");
        
        // DO: Log that it was found without revealing the value
        if (key != null)
        {
            Console.WriteLine("Using API key from API_KEY environment variable");
        }
        
        return key;
    }
};
```

### Clear sensitive environment variables

Remove sensitive values from the environment after reading:

```csharp
var passwordOption = new Option<string>("--password")
{
    DefaultValueFactory = _ =>
    {
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        if (password != null)
        {
            // Clear it from environment
            Environment.SetEnvironmentVariable("DB_PASSWORD", null);
        }
        return password;
    }
};
```

### Prefer command-line for secrets in containers

In containerized environments, use secrets management instead of environment variables:

```csharp
var tokenOption = new Option<string>("--token")
{
    Description = "Authentication token (or set TOKEN_FILE for container secret path)",
    CustomParser = result =>
    {
        if (result.Tokens.Count > 0)
        {
            return result.Tokens.Single().Value;
        }
        
        // Read from Docker/Kubernetes secret file
        var tokenFile = Environment.GetEnvironmentVariable("TOKEN_FILE");
        if (tokenFile != null && File.Exists(tokenFile))
        {
            return File.ReadAllText(tokenFile).Trim();
        }
        
        result.AddError("Token required via --token or TOKEN_FILE");
        return null;
    }
};
```

## Real-world example: .NET CLI

The .NET CLI uses environment variables extensively:

```csharp
// Simplified from dotnet/sdk
public static Option<bool> CreateNoLogoOption()
{
    return new Option<bool>("--no-logo", "--nologo")
    {
        Description = "Do not display the startup banner",
        DefaultValueFactory = _ =>
        {
            var envValue = Environment.GetEnvironmentVariable("DOTNET_NOLOGO");
            return ParseBooleanEnvVar(envValue, defaultValue: false);
        },
        Arity = ArgumentArity.Zero
    };
}

// Environment variables used:
// - DOTNET_NOLOGO: Suppress startup banner
// - DOTNET_CLI_TELEMETRY_OPTOUT: Disable telemetry
// - DOTNET_SKIP_FIRST_TIME_EXPERIENCE: Skip first-run experience
// - CI: Detect continuous integration environment
```

## See also

- [System.CommandLine overview](index.md)
- [How to customize parsing and validation](how-to-customize-parsing-and-validation.md)
- [Sharing options across commands](sharing-options.md)
