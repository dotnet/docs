using System;
using System.Buffers;
using System.Diagnostics;
using System.Formats.Tar;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

static class LibrariesExamples
{
    static async Task ProcessRunAndCaptureExample()
    {
        // <ProcessRunAndCapture>
        // One-shot capture: stdout and stderr together, plus exit code.
        ProcessTextOutput result = await Process.RunAndCaptureTextAsync(
            "git", ["status", "--porcelain"]);

        Console.WriteLine(result.StandardOutput);
        Console.WriteLine($"Exit code: {result.ExitStatus.ExitCode}");
        // </ProcessRunAndCapture>
    }

    static void ZLibEncoderSpanExample()
    {
        // <ZLibEncoderSpan>
        ReadOnlySpan<byte> source = [0x48, 0x65, 0x6C, 0x6C, 0x6F]; // "Hello"
        byte[] buffer = new byte[source.Length + 32];
        Span<byte> destination = buffer;

        using ZLibEncoder encoder = new();
        OperationStatus status = encoder.Compress(
            source, destination, out int bytesConsumed, out int bytesWritten,
            isFinalBlock: true);

        Console.WriteLine($"Compressed {bytesConsumed} bytes into {bytesWritten} bytes. Status: {status}");
        // </ZLibEncoderSpan>
    }

    static void FloatingPointHexExample()
    {
        // <FloatingPointHex>
        double value = Math.PI;

        // Format as hexadecimal IEEE-754: preserves all bits exactly
        string hex = value.ToString("X"); // e.g., "0X1.921FB54442D18P+1"
        double roundTripped = double.Parse(hex, NumberStyles.HexFloat);

        Console.WriteLine(roundTripped == value); // True — exact round-trip
        // </FloatingPointHex>
    }

    static void UtfValidationExample()
    {
        // <UtfValidation>
        ReadOnlySpan<byte> bytes = [0xC3, 0x28]; // invalid UTF-8
        int badIndex = Utf8.IndexOfInvalidSubsequence(bytes); // 0

        ReadOnlySpan<char> chars = "valid \uD83D\uDC4D end"; // valid UTF-16 (👍 emoji)
        bool ok = Utf16.IsValid(chars); // true
        // </UtfValidation>
    }

    static void RateLimitingRetryAfterExample()
    {
        // <RateLimitingRetryAfter>
        var limiter = new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromSeconds(1),
            QueueLimit = 0,
        });

        RateLimitLease lease = limiter.AttemptAcquire();
        if (!lease.IsAcquired && lease.TryGetMetadata(MetadataName.RetryAfter, out TimeSpan retry))
        {
            Console.WriteLine($"Rate limit exceeded. Retry after {retry}.");
        }
        // </RateLimitingRetryAfter>
    }

    static void Utf8JsonWriterResetExample()
    {
        // <Utf8JsonWriterReset>
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
        writer.WriteStartObject();
        writer.WriteString("name", "example");
        writer.WriteEndObject();
        writer.Flush();

        // Reset with different options for next use — no new allocation needed
        stream.SetLength(0);
        writer.Reset(stream, new JsonWriterOptions { Indented = false });
        // </Utf8JsonWriterReset>
    }

    static void JsonTypeInfoExample()
    {
        // <JsonTypeInfoGeneric>
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
        options.MakeReadOnly();

        // Before: manual downcast required
        JsonTypeInfo<MyRecord> info1 = (JsonTypeInfo<MyRecord>)options.GetTypeInfo(typeof(MyRecord));

        // After: generic method returns the right type directly
        JsonTypeInfo<MyRecord> info2 = options.GetTypeInfo<MyRecord>();

        // TryGetTypeInfo variant for cases where the type may not be registered
        if (options.TryGetTypeInfo<MyRecord>(out JsonTypeInfo<MyRecord>? typeInfo))
        {
            // Use typeInfo
            _ = typeInfo;
        }
        // </JsonTypeInfoGeneric>
    }

    static void JsonNamingIgnoreExample()
    {
        // <JsonNamingIgnore>
        // Type-level JsonIgnore: all members use WhenWritingNull by default
        // Per-member JsonNamingPolicy: EventName uses camelCase even though the
        // serializer options use PascalCase
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.PascalCase
        };

        var data = new EventData { EventName = "Launch", Notes = null };
        string json = JsonSerializer.Serialize(data, options);
        Console.WriteLine(json);
        // {"eventName":"Launch"}  -- Notes omitted (null), EventName camel-cased
        // </JsonNamingIgnore>
    }

    static async Task TarArchiveFormatExample()
    {
        // <TarArchiveFormat>
        // Create a GNU format tar archive for Linux compatibility
        TarFile.CreateFromDirectory("/source/dir", "/dest/archive.tar",
            includeBaseDirectory: true, format: TarEntryFormat.Gnu);

        // Create a Ustar format archive for broader compatibility
        using Stream outputStream = File.OpenWrite("/dest/ustar.tar");
        TarFile.CreateFromDirectory("/source/dir", outputStream,
            includeBaseDirectory: false, format: TarEntryFormat.Ustar);

        // Async version
        CancellationToken cancellationToken = CancellationToken.None;
        await TarFile.CreateFromDirectoryAsync("/source/dir", "/dest/archive.tar",
            includeBaseDirectory: true, format: TarEntryFormat.Pax,
            cancellationToken: cancellationToken);
        // </TarArchiveFormat>
    }

    static void SafeFileHandlePipeExample()
    {
        // <SafeFileHandlePipe>
        SafeFileHandle.CreateAnonymousPipe(
            out SafeFileHandle readEnd,
            out SafeFileHandle writeEnd,
            asyncRead: true,
            asyncWrite: false);

        using (readEnd)
        using (writeEnd)
        {
            // SafeFileHandle.Type reports the kind of OS object the handle refers to
            Console.WriteLine(readEnd.Type);   // Pipe
            Console.WriteLine(writeEnd.Type);  // Pipe
        }
        // </SafeFileHandlePipe>
    }

    static void RegexAnyNewLineExample()
    {
        // <RegexAnyNewLine>
        string text = "line1\r\nline2\u0085line3\u2028line4";

        // RegexOptions.AnyNewLine makes ^, $, and . treat all Unicode newline
        // sequences as line terminators, not just \n.
        MatchCollection matches = Regex.Matches(
            text,
            @"^line\d$",
            RegexOptions.Multiline | RegexOptions.AnyNewLine);

        Console.WriteLine(matches.Count); // 4
        // </RegexAnyNewLine>
    }
}

record MyRecord(string Name, int Value);

[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
sealed class EventData
{
    [JsonNamingPolicy(JsonKnownNamingPolicy.CamelCase)]
    public string EventName { get; set; } = "";

    public string? Notes { get; set; }
}
