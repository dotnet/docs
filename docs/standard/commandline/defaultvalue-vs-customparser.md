---
title: DefaultValueFactory vs CustomParser in System.CommandLine
ms.date: 01/23/2026
description: "Understand the difference between DefaultValueFactory and CustomParser, when to use each, and how they work together in System.CommandLine."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "DefaultValueFactory"
  - "CustomParser"
  - "default values"
  - "parsing"
ms.topic: conceptual
---

# DefaultValueFactory vs CustomParser in System.CommandLine

`DefaultValueFactory` and `CustomParser` are two powerful features in System.CommandLine, but they serve very different purposes. Understanding when to use each is crucial for building robust command-line applications.

## The fundamental difference

The key distinction is **when** each executes and **what** it controls:

| Feature | Purpose | When it executes | Input | Output |
|---------|---------|------------------|-------|--------|
| `DefaultValueFactory` | Provide a value when nothing is specified | When option/argument is **not present** | `ArgumentResult` | Default value |
| `CustomParser` | Control how input is parsed | When option/argument **is present** | Command-line tokens | Parsed value |

## DefaultValueFactory: Providing defaults

`DefaultValueFactory` is called when the user **does not** provide a value on the command line.

### Basic usage

```csharp
var portOption = new Option<int>("--port", "-p")
{
    Description = "Server port",
    DefaultValueFactory = _ => 8080
};

// Command line: myapp           → port = 8080 (from DefaultValueFactory)
// Command line: myapp --port 3000  → port = 3000 (from command line)
```

### When DefaultValueFactory executes

```csharp
var debugOption = new Option<bool>("--debug")
{
    DefaultValueFactory = result =>
    {
        Console.WriteLine("DefaultValueFactory called!");
        return false;
    }
};

// Command line: myapp --debug
// Output: (nothing - DefaultValueFactory NOT called)

// Command line: myapp
// Output: DefaultValueFactory called!
```

**Important:** `DefaultValueFactory` is **never** called if the user provides the option on the command line, even if they don't provide a value.

### Common DefaultValueFactory patterns

#### Environment variable fallback

```csharp
var apiKeyOption = new Option<string>("--api-key")
{
    DefaultValueFactory = _ => 
        Environment.GetEnvironmentVariable("API_KEY") ?? "default-key"
};

// Priority:
// 1. Command line value (if provided)
// 2. API_KEY environment variable
// 3. "default-key"
```

#### Dynamic defaults

```csharp
var outputOption = new Option<DirectoryInfo>("--output")
{
    DefaultValueFactory = _ => 
        new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "bin"))
};

// Default changes based on current directory
```

#### Expensive computation

```csharp
var cacheOption = new Option<string>("--cache-dir")
{
    DefaultValueFactory = _ =>
    {
        // Only computed if --cache-dir not provided
        return FindUserCacheDirectory();  // Expensive operation
    }
};
```

## CustomParser: Controlling parsing

`CustomParser` is called when the user **does** provide a value, to convert command-line tokens into the target type.

### Basic usage

```csharp
var coordinateOption = new Option<(double lat, double lon)>("--location")
{
    CustomParser = result =>
    {
        Console.WriteLine("CustomParser called!");
        var value = result.Tokens.Single().Value;
        var parts = value.Split(',');
        return (double.Parse(parts[0]), double.Parse(parts[1]));
    }
};

// Command line: myapp --location 37.7,-122.4
// Output: CustomParser called!
// Result: (37.7, -122.4)

// Command line: myapp
// Output: (nothing - CustomParser NOT called)
// Result: default value for tuple type
```

### When CustomParser executes

```csharp
var valueOption = new Option<int>("--value")
{
    CustomParser = result =>
    {
        Console.WriteLine($"Parsing: {result.Tokens.Single().Value}");
        return int.Parse(result.Tokens.Single().Value);
    }
};

// Command line: myapp --value 42
// Output: Parsing: 42

// Command line: myapp
// Output: (nothing - CustomParser NOT called)
```

**Important:** `CustomParser` is **only** called when tokens are present for the option/argument.

### Common CustomParser patterns

#### Complex type parsing

```csharp
record DateRange(DateTime Start, DateTime End);

var rangeOption = new Option<DateRange>("--range")
{
    Arity = new ArgumentArity(2, 2),
    CustomParser = result =>
    {
        var start = DateTime.Parse(result.Tokens[0].Value);
        var end = DateTime.Parse(result.Tokens[1].Value);
        
        if (end < start)
        {
            result.AddError("End date must be after start date");
            return null;
        }
        
        return new DateRange(start, end);
    }
};

// Command line: myapp --range 2026-01-01 2026-12-31
```

#### Alternative formats

```csharp
var durationOption = new Option<TimeSpan>("--timeout")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        // Support multiple formats
        if (value.EndsWith("ms"))
            return TimeSpan.FromMilliseconds(double.Parse(value[..^2]));
        if (value.EndsWith("s"))
            return TimeSpan.FromSeconds(double.Parse(value[..^1]));
        if (value.EndsWith("m"))
            return TimeSpan.FromMinutes(double.Parse(value[..^1]));
        
        // Fall back to TimeSpan.Parse
        return TimeSpan.Parse(value);
    }
};

// Command line: myapp --timeout 500ms   → TimeSpan.FromMilliseconds(500)
// Command line: myapp --timeout 30s     → TimeSpan.FromSeconds(30)
// Command line: myapp --timeout 00:05:00 → TimeSpan.Parse("00:05:00")
```

## Using both together

`DefaultValueFactory` and `CustomParser` work together to provide complete control:

```csharp
var portOption = new Option<int>("--port")
{
    Description = "Server port (or set PORT environment variable)",
    
    // Called when --port is NOT provided
    DefaultValueFactory = _ =>
    {
        var envPort = Environment.GetEnvironmentVariable("PORT");
        return envPort != null ? int.Parse(envPort) : 8080;
    },
    
    // Called when --port IS provided
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        if (!int.TryParse(value, out var port))
        {
            result.AddError($"Invalid port: {value}");
            return 0;
        }
        
        if (port < 1 || port > 65535)
        {
            result.AddError($"Port must be 1-65535, got {port}");
            return 0;
        }
        
        return port;
    }
};

// Command line: myapp
// → DefaultValueFactory called → checks PORT env var → defaults to 8080

// Command line: myapp --port 3000
// → CustomParser called → validates 3000 → returns 3000

// Command line: myapp --port 99999
// → CustomParser called → validates 99999 → error!
```

## Execution flow diagram

```
User input: myapp --port 3000
                    |
                    v
             Option present?
                /     \
              No       Yes
              |         |
              v         v
    DefaultValueFactory  CustomParser
              |         |
              v         v
           Default    Parsed
           Value      Value
              |         |
              +----+----+
                   |
                   v
              Final Value
```

## Common pitfalls

### Pitfall 1: Using CustomParser for defaults

❌ **Don't use CustomParser to provide defaults:**

```csharp
// WRONG: CustomParser won't be called if option is missing
var option = new Option<int>("--value")
{
    CustomParser = result =>
    {
        if (result.Tokens.Count == 0)
            return 42;  // This never executes!
        return int.Parse(result.Tokens.Single().Value);
    }
};
```

✅ **Use DefaultValueFactory for defaults:**

```csharp
// CORRECT
var option = new Option<int>("--value")
{
    DefaultValueFactory = _ => 42
};
```

### Pitfall 2: Using DefaultValueFactory for parsing

❌ **Don't use DefaultValueFactory to parse values:**

```csharp
// WRONG: DefaultValueFactory not called when option is provided
var option = new Option<int>("--value")
{
    DefaultValueFactory = result =>
    {
        // Trying to parse from tokens - wrong place!
        if (result.Tokens.Count > 0)
            return int.Parse(result.Tokens.Single().Value);
        return 0;
    }
};
```

✅ **Use CustomParser for parsing:**

```csharp
// CORRECT
var option = new Option<int>("--value")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        return int.Parse(value);
    },
    DefaultValueFactory = _ => 0
};
```

### Pitfall 3: Duplicate logic

❌ **Avoid duplicating validation in both:**

```csharp
// WRONG: Validation duplicated
var portOption = new Option<int>("--port")
{
    DefaultValueFactory = result =>
    {
        var port = 8080;
        if (port < 1 || port > 65535)  // Unnecessary validation
            return 0;
        return port;
    },
    CustomParser = result =>
    {
        var port = int.Parse(result.Tokens.Single().Value);
        if (port < 1 || port > 65535)  // Duplicated validation
        {
            result.AddError("Invalid port");
            return 0;
        }
        return port;
    }
};
```

✅ **Use validators for validation:**

```csharp
// CORRECT: Validation in one place
var portOption = new Option<int>("--port")
{
    DefaultValueFactory = _ => 8080,
    CustomParser = result => int.Parse(result.Tokens.Single().Value)
};

portOption.Validators.Add(result =>
{
    var port = result.GetValue<int>();
    if (port < 1 || port > 65535)
    {
        result.AddError($"Port must be 1-65535, got {port}");
    }
});
```

## Decision tree

Use this decision tree to choose the right approach:

```
Do you need custom behavior?
    |
    +-- No → Use built-in type support
    |
    +-- Yes → When does it apply?
            |
            +-- When option is NOT provided
            |   → Use DefaultValueFactory
            |   Examples:
            |   - Environment variable fallback
            |   - Computed default values
            |   - Context-aware defaults
            |
            +-- When option IS provided
                → Use CustomParser
                Examples:
                - Parsing complex types
                - Alternative input formats
                - Multi-token parsing
```

## Real-world example: Configuration file path

A complete example showing both features:

```csharp
var configOption = new Option<FileInfo>("--config")
{
    Description = "Configuration file path",
    
    // Default: look in standard locations
    DefaultValueFactory = _ =>
    {
        // Check standard locations in order
        var candidates = new[]
        {
            "app.config.json",
            Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), 
                "myapp", "config.json"),
            "/etc/myapp/config.json"
        };
        
        foreach (var path in candidates)
        {
            if (File.Exists(path))
            {
                return new FileInfo(path);
            }
        }
        
        return null;  // No default config found
    },
    
    // Custom parsing: expand ~ and environment variables
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        // Expand ~ to home directory
        if (value.StartsWith("~/") || value == "~")
        {
            var home = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            value = value == "~" 
                ? home 
                : Path.Combine(home, value[2..]);
        }
        
        // Expand environment variables
        value = Environment.ExpandEnvironmentVariables(value);
        
        // Create FileInfo
        var fileInfo = new FileInfo(value);
        
        if (!fileInfo.Exists)
        {
            result.AddError($"Config file not found: {fileInfo.FullName}");
            return null;
        }
        
        return fileInfo;
    }
};

// Usage examples:
// myapp
// → DefaultValueFactory searches standard locations

// myapp --config ~/my-config.json
// → CustomParser expands ~ and validates file exists

// myapp --config %APPDATA%\myapp\config.json
// → CustomParser expands %APPDATA% and validates
```

## Performance considerations

### DefaultValueFactory

- Only called when option is not provided
- Good for expensive computations (lazy evaluation)
- Can safely do I/O, network calls, etc.

```csharp
var cacheOption = new Option<string>("--cache-dir")
{
    DefaultValueFactory = _ =>
    {
        // This expensive search only runs if --cache-dir not provided
        return SearchFileSystem("/", "cache");
    }
};
```

### CustomParser

- Called for every token when option is provided
- Should be relatively fast
- Avoid expensive operations in the hot path

```csharp
var urlOption = new Option<Uri>("--url")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        // GOOD: Fast parsing
        if (Uri.TryCreate(value, UriKind.Absolute, out var uri))
            return uri;
        
        // BAD: Don't do network I/O in CustomParser
        // return CheckUrlIsReachable(value);  // Don't do this!
        
        result.AddError($"Invalid URL: {value}");
        return null;
    }
};
```

## Summary

| Scenario | Use |
|----------|-----|
| Provide a default when option is missing | `DefaultValueFactory` |
| Read from environment variable as fallback | `DefaultValueFactory` |
| Compute expensive default value | `DefaultValueFactory` |
| Parse custom type from tokens | `CustomParser` |
| Support alternative input formats | `CustomParser` |
| Parse multiple tokens into one value | `CustomParser` |
| Validate parsed values | `Validators` (not CustomParser) |

**Remember:** 
- `DefaultValueFactory` = What happens when option is **absent**
- `CustomParser` = What happens when option is **present**

## See also

- [How to customize parsing and validation](how-to-customize-parsing-and-validation.md)
- [Custom type parsing in System.CommandLine](custom-types.md)
- [Using environment variables with options](environment-variables.md)
- [Supported types in System.CommandLine](supported-types.md)
