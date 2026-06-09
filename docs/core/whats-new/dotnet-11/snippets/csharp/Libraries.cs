using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Globalization;
using System.IO.Compression;
using System.IO.Pipelines;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using System.Text.Unicode;
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

    static void LinqJoinsExample()
    {
        // <LinqJoins>
        var products = new List<(int Id, string Name, string? Category)>
        {
            (1, "Laptop", "Electronics"),
            (2, "Mouse", "Electronics"),
            (3, "Orphan", null), // No matching category
        };
        var categories = new List<(string Name, string Description)>
        {
            ("Electronics", "Electronic devices"),
            ("Furniture", "Office furniture"), // No matching product
        };

        // LeftJoin: all products, matched categories (null if none)
        var leftJoined = products.LeftJoin(
            categories,
            p => p.Category,
            c => c.Name);

        foreach (var (product, category) in leftJoined)
            Console.WriteLine($"{product.Name}: {category?.Description ?? "(none)"}");
        // Laptop: Electronic devices
        // Mouse: Electronic devices
        // Orphan: (none)

        // FullJoin: all products and categories, paired where they match
        var fullJoined = products.FullJoin(
            categories,
            p => p.Category,
            c => c.Name);

        foreach (var (product, category) in fullJoined)
            Console.WriteLine(
                $"{product?.Name ?? "(none)"}: {category?.Description ?? "(none)"}");
        // Laptop: Electronic devices
        // Mouse: Electronic devices
        // Orphan: (none)
        // (none): Office furniture
        // </LinqJoins>
    }

    static void EqualityComparerCreateExample()
    {
        // <EqualityComparerCreate>

        // Create an equality comparer based on a key selector
        var byName = EqualityComparer<(string Name, int Age)>.Create(p => p.Name);

        var people = new HashSet<(string Name, int Age)>(byName)
        {
            ("Alice", 30),
            ("Bob", 25),
            ("Alice", 40), // Duplicate by name — not added
        };
        Console.WriteLine(people.Count); // 2
        // </EqualityComparerCreate>
    }

    static void RandomGenericExample()
    {
        // <RandomGeneric>
        // Generate a random integer of any binary integer type
        int i = Random.Shared.NextInteger<int>();
        long l = Random.Shared.NextInteger<long>(0L, 100L);
        byte b = Random.Shared.NextInteger<byte>(maxValue: (byte)10);

        // Generate a random floating-point value of any IEEE-754 type
        float f = Random.Shared.NextBinaryFloat<float>();
        double d = Random.Shared.NextBinaryFloat<double>();
        Half h = Random.Shared.NextBinaryFloat<Half>();

        Console.WriteLine($"int={i}, long={l}, byte={b}");
        Console.WriteLine($"float={f}, double={d}, Half={h}");
        // </RandomGeneric>
    }

    static void StringBuilderMoveChunksExample()
    {
        // <StringBuilderMoveChunks>
        var source = new StringBuilder("Hello, ");
        source.Append("World!");

        // MoveChunks transfers all content from source to a new StringBuilder.
        // After the call, source contains no characters.
        StringBuilder dest = StringBuilder.MoveChunks(source);
        Console.WriteLine(dest);          // Hello, World!
        Console.WriteLine(source.Length); // 0
        // </StringBuilderMoveChunks>
    }

    static async Task JsonSerializeAsyncEnumerablePipeExample()
    {
        // <JsonSerializeAsyncEnumerablePipe>
        static async IAsyncEnumerable<int> GenerateNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;
                await Task.Yield();
            }
        }

        var pipe = new Pipe();

        // Write a JSON array: [0,1,2,3,4]
        await JsonSerializer.SerializeAsyncEnumerable(
            pipe.Writer,
            GenerateNumbers());

        // Write NDJSON (one value per line): 0\n1\n2\n3\n4\n
        await JsonSerializer.SerializeAsyncEnumerable(
            pipe.Writer,
            GenerateNumbers(),
            topLevelValues: true);
        // </JsonSerializeAsyncEnumerablePipe>
    }

    static void X25519KeyExchangeExample()
    {
        // <X25519KeyExchange>
        // Generate key pairs for Alice and Bob
        using X25519DiffieHellman alice = X25519DiffieHellman.GenerateKey();
        using X25519DiffieHellman bob = X25519DiffieHellman.GenerateKey();

        // Each party derives the shared secret using the other's public key
        byte[] aliceShared = alice.DeriveRawSecretAgreement(bob);
        byte[] bobShared = bob.DeriveRawSecretAgreement(alice);

        // Both parties arrive at the same secret
        Console.WriteLine(aliceShared.SequenceEqual(bobShared)); // True
        // </X25519KeyExchange>
    }

    static void NullableUnderlyingTypeExample()
    {
        // <NullableUnderlyingType>
        Type nullableIntType = typeof(int?);
        Type? underlying = nullableIntType.GetNullableUnderlyingType();
        Console.WriteLine(underlying); // System.Int32

        Type nonNullable = typeof(int);
        Console.WriteLine(nonNullable.GetNullableUnderlyingType() is null); // True
        // </NullableUnderlyingType>
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
