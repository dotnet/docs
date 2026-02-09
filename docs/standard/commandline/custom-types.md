---
title: Custom type parsing in System.CommandLine
ms.date: 01/22/2026
description: "Learn how to define options and arguments that accept custom data types, including complex types, specialized parsing, and collection scenarios."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "custom types"
  - "custom parsing"
ms.topic: how-to
---

# Custom type parsing in System.CommandLine

While `System.CommandLine` supports many common .NET types out of the box, you often need to parse custom types specific to your domain. This article provides detailed guidance and scenarios for parsing custom types.

## When to use custom parsers

Use custom parsers when you need to:

- Parse domain-specific types (for example, `EmailAddress`, `IpAddress`, `Coordinate`)
- Parse composite types from single string values (for example, `"lat,lon"` to `Coordinate`)
- Parse data in non-standard formats (for example, durations as `"5m30s"`)
- Provide complex validation logic during parsing
- Transform input before creating the final value

## Basic custom parser

Define a custom parser using the `CustomParser` property on `Option<T>` or `Argument<T>`:

```csharp
record Coordinate(double Latitude, double Longitude);

var locationOption = new Option<Coordinate>("--location", "Geographic location")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        var parts = value.Split(',');
        
        if (parts.Length != 2)
        {
            result.AddError("Location must be in format: latitude,longitude");
            return null;
        }

        if (!double.TryParse(parts[0], out var lat) || 
            !double.TryParse(parts[1], out var lon))
        {
            result.AddError("Latitude and longitude must be valid numbers");
            return null;
        }

        if (lat < -90 || lat > 90)
        {
            result.AddError("Latitude must be between -90 and 90");
            return null;
        }

        if (lon < -180 || lon > 180)
        {
            result.AddError("Longitude must be between -180 and 180");
            return null;
        }

        return new Coordinate(lat, lon);
    }
};

// Command line: --location 37.7749,-122.4194
```

The `CustomParser` delegate receives an `ArgumentResult` and returns the parsed value (or `null` if parsing fails).

## Parsing from multiple tokens

Some custom types might need to consume multiple command-line tokens:

```csharp
record DateRange(DateTime Start, DateTime End);

var rangeArg = new Argument<DateRange>("date-range", "Start and end dates")
{
    Arity = new ArgumentArity(2, 2),
    CustomParser = result =>
    {
        var tokens = result.Tokens;
        
        if (!DateTime.TryParse(tokens[0].Value, out var start))
        {
            result.AddError($"Invalid start date: {tokens[0].Value}");
            return null;
        }

        if (!DateTime.TryParse(tokens[1].Value, out var end))
        {
            result.AddError($"Invalid end date: {tokens[1].Value}");
            return null;
        }

        if (end < start)
        {
            result.AddError("End date must be after start date");
            return null;
        }

        return new DateRange(start, end);
    }
};

// Command line: myapp 2026-01-01 2026-12-31
```

## Parsing enumerations with aliases

Extend enum parsing to support aliases or alternative names:

```csharp
enum Priority
{
    Low,
    Medium,
    High,
    Critical
}

var priorityOption = new Option<Priority>("--priority", "Task priority")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value.ToLowerInvariant();
        
        return value switch
        {
            "low" or "l" or "1" => Priority.Low,
            "medium" or "med" or "m" or "2" => Priority.Medium,
            "high" or "h" or "3" => Priority.High,
            "critical" or "crit" or "c" or "4" => Priority.Critical,
            _ => throw new InvalidOperationException(
                $"Invalid priority: {value}. Valid values: low, medium, high, critical")
        };
    }
};

// Command line: --priority high
// Command line: --priority h
// Command line: --priority 3
```

## Parsing collections of custom types

Parse arrays or lists of custom types:

```csharp
record Server(string Name, int Port);

var serversOption = new Option<Server[]>("--servers", "Server configurations")
{
    AllowMultipleArgumentsPerToken = true,
    CustomParser = result =>
    {
        var servers = new List<Server>();
        
        foreach (var token in result.Tokens)
        {
            var parts = token.Value.Split(':');
            if (parts.Length != 2)
            {
                result.AddError($"Invalid server format: {token.Value}. Use name:port");
                return null;
            }

            if (!int.TryParse(parts[1], out var port))
            {
                result.AddError($"Invalid port number: {parts[1]}");
                return null;
            }

            servers.Add(new Server(parts[0], port));
        }

        return servers.ToArray();
    }
};

// Command line: --servers web:8080 api:8081 db:5432
```

## Parsing from external sources

Custom parsers can load data from files or other sources:

```csharp
record Configuration
{
    public string Environment { get; init; }
    public Dictionary<string, string> Settings { get; init; }
}

var configOption = new Option<Configuration>("--config", "Configuration file path")
{
    CustomParser = result =>
    {
        var filePath = result.Tokens.Single().Value;
        
        if (!File.Exists(filePath))
        {
            result.AddError($"Configuration file not found: {filePath}");
            return null;
        }

        try
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Configuration>(json);
        }
        catch (JsonException ex)
        {
            result.AddError($"Invalid JSON in configuration file: {ex.Message}");
            return null;
        }
    }
};

// Command line: --config settings.json
```

## Parsing URLs and URIs

Parse and validate URL strings:

```csharp
var apiUrlOption = new Option<Uri>("--api-url", "API endpoint URL")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri))
        {
            result.AddError($"Invalid URL: {value}");
            return null;
        }

        if (uri.Scheme != "http" && uri.Scheme != "https")
        {
            result.AddError("URL must use HTTP or HTTPS scheme");
            return null;
        }

        return uri;
    }
};

// Command line: --api-url https://api.example.com/v1
```

## Parsing time durations with units

Parse human-friendly duration strings:

```csharp
var timeoutOption = new Option<TimeSpan>("--timeout", "Operation timeout")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        var pattern = @"^(\d+)([smhd])$";
        var match = Regex.Match(value, pattern);
        
        if (!match.Success)
        {
            result.AddError("Timeout must be in format: <number><unit> (e.g., 30s, 5m, 2h, 1d)");
            return null;
        }

        var amount = int.Parse(match.Groups[1].Value);
        var unit = match.Groups[2].Value;

        return unit switch
        {
            "s" => TimeSpan.FromSeconds(amount),
            "m" => TimeSpan.FromMinutes(amount),
            "h" => TimeSpan.FromHours(amount),
            "d" => TimeSpan.FromDays(amount),
            _ => throw new InvalidOperationException()
        };
    }
};

// Command line: --timeout 30s
// Command line: --timeout 5m
```

## Combining parsing with validation

Custom parsers can include complex validation logic:

```csharp
record EmailAddress
{
    public string Value { get; init; }
    
    public EmailAddress(string email)
    {
        if (!IsValidEmail(email))
            throw new ArgumentException($"Invalid email address: {email}");
        Value = email;
    }
    
    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

var emailOption = new Option<EmailAddress>("--email", "Email address")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        
        try
        {
            return new EmailAddress(value);
        }
        catch (ArgumentException ex)
        {
            result.AddError(ex.Message);
            return null;
        }
    }
};

// Command line: --email user@example.com
```

## Reusable custom parsers

Create reusable parser functions for types used across multiple options:

```csharp
static class CustomParsers
{
    public static Coordinate? ParseCoordinate(ArgumentResult result)
    {
        var value = result.Tokens.Single().Value;
        var parts = value.Split(',');
        
        if (parts.Length != 2 ||
            !double.TryParse(parts[0], out var lat) ||
            !double.TryParse(parts[1], out var lon))
        {
            result.AddError("Coordinate must be in format: latitude,longitude");
            return null;
        }

        return new Coordinate(lat, lon);
    }
}

// Use in multiple options
var startOption = new Option<Coordinate>("--start", "Start location")
{
    CustomParser = CustomParsers.ParseCoordinate
};

var endOption = new Option<Coordinate>("--end", "End location")
{
    CustomParser = CustomParsers.ParseCoordinate
};
```

## Generic parsing with ISpanParseable

.NET 7 and later provide the <xref:System.ISpanParseable%601> interface, which allows types to be parsed from a `ReadOnlySpan<char>`. You can create a generic parser that works with any type implementing this interface:

```csharp
#if NET7_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

static class CustomParsers
{
    public static T? ParseSpanParseable<T>(ArgumentResult result) 
        where T : ISpanParseable<T>
    {
        var value = result.Tokens.Single().Value;
        
        if (T.TryParse(value.AsSpan(), provider: null, out var parsed))
        {
            return parsed;
        }
        
        result.AddError($"Cannot parse '{value}' as {typeof(T).Name}");
        return default;
    }
}

// This works with any type that implements ISpanParseable<T>
// Examples: Int128, Half, DateOnly, TimeOnly, and your own custom types

var int128Option = new Option<Int128>("--large-number", "A very large integer")
{
    CustomParser = CustomParsers.ParseSpanParseable<Int128>
};

var halfOption = new Option<Half>("--precision", "Half-precision floating point")
{
    CustomParser = CustomParsers.ParseSpanParseable<Half>
};
#endif
```

You can also implement `ISpanParseable<T>` on your own types to enable this generic parsing:

```csharp
#if NET7_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

readonly record struct Temperature : ISpanParseable<Temperature>
{
    public double Value { get; init; }
    public TemperatureUnit Unit { get; init; }

    public static Temperature Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out var result))
            throw new FormatException($"Invalid temperature format: {s}");
        return result;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, 
        [MaybeNullWhen(false)] out Temperature result)
    {
        result = default;
        
        if (s.IsEmpty)
            return false;

        var unit = s[^1] switch
        {
            'C' or 'c' => TemperatureUnit.Celsius,
            'F' or 'f' => TemperatureUnit.Fahrenheit,
            'K' or 'k' => TemperatureUnit.Kelvin,
            _ => TemperatureUnit.None
        };

        var valueSpan = unit != TemperatureUnit.None ? s[..^1] : s;
        
        if (!double.TryParse(valueSpan, out var value))
            return false;

        result = new Temperature { Value = value, Unit = unit };
        return true;
    }

    public static Temperature Parse(string s, IFormatProvider? provider) 
        => Parse(s.AsSpan(), provider);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, 
        [MaybeNullWhen(false)] out Temperature result)
    {
        if (s is null)
        {
            result = default;
            return false;
        }
        return TryParse(s.AsSpan(), provider, out result);
    }
}

enum TemperatureUnit { None, Celsius, Fahrenheit, Kelvin }

// Use the generic parser
var tempOption = new Option<Temperature>("--temperature", "Temperature value")
{
    CustomParser = CustomParsers.ParseSpanParseable<Temperature>
};

// Command line: --temperature 23.5C
// Command line: --temperature 75F
// Command line: --temperature 298K
#endif
```

This approach provides:

- **Type safety** - Works with any `ISpanParseable<T>` type
- **Performance** - Avoids string allocations using `ReadOnlySpan<char>`
- **Reusability** - Single generic parser for multiple types
- **Consistency** - Uses the same parsing logic as the type's built-in parser

## Error handling best practices

When creating custom parsers:

1. **Use specific error messages** - Tell users exactly what went wrong and what format is expected
2. **Use `result.AddError()`** - Add errors to the `ArgumentResult` rather than throwing exceptions
3. **Return `null` on failure** - Signal parsing failure by returning `null` (or `default`)
4. **Validate early** - Check format and constraints as soon as possible
5. **Provide examples** - Include format examples in error messages

```csharp
// Good error handling
CustomParser = result =>
{
    var value = result.Tokens.Single().Value;
    
    if (string.IsNullOrWhiteSpace(value))
    {
        result.AddError("Value cannot be empty");
        return null;
    }
    
    if (!value.Contains('@'))
    {
        result.AddError($"Invalid email format: {value}. Example: user@example.com");
        return null;
    }
    
    // ... rest of parsing logic
}
```

## See also

- [How to customize parsing and validation](how-to-customize-parsing-and-validation.md)
- [Supported types in System.CommandLine](supported-types.md)
- [System.CommandLine overview](index.md)
