using System.Buffers;
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

public static class LibrariesExamples
{
    static async Task ProcessRunAndCaptureExample()
    {
        // <ProcessRunAndCapture>
        ProcessTextOutput result = await Process.RunAndCaptureTextAsync(
            "git", new[] { "status", "--porcelain" });

        Console.WriteLine(result.StandardOutput);
        Console.WriteLine($"Exit code: {result.ExitStatus.ExitCode}");
        // </ProcessRunAndCapture>
    }

    static void ZLibEncoderSpanExample()
    {
        // <ZLibEncoderSpan>
        ReadOnlySpan<byte> source = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello"
        byte[] buffer = new byte[source.Length + 32];
        Span<byte> destination = buffer;

        using ZLibEncoder encoder = new ZLibEncoder();
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

        string hex = value.ToString("X", CultureInfo.InvariantCulture);
        double roundTripped = double.Parse(hex, NumberStyles.HexFloat, CultureInfo.InvariantCulture);

        Console.WriteLine(roundTripped == value);
        // </FloatingPointHex>
    }

    static void UtfValidationExample()
    {
        // <UtfValidation>
        ReadOnlySpan<byte> bytes = new byte[] { 0xC3, 0x28 };
        int badIndex = Utf8.IndexOfInvalidSubsequence(bytes);

        ReadOnlySpan<char> chars = "valid \uD83D\uDC4D end".AsSpan();
        bool ok = Utf16.IsValid(chars);
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

        stream.SetLength(0);
        writer.Reset(stream, new JsonWriterOptions { Indented = false });
        // </Utf8JsonWriterReset>
    }

    static void JsonTypeInfoExample()
    {
        // <JsonTypeInfoGeneric>
        JsonSerializerOptions options = new()
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        };

        JsonTypeInfo<MyRecord> info1 = (JsonTypeInfo<MyRecord>)options.GetTypeInfo(typeof(MyRecord));
        JsonTypeInfo<MyRecord> info2 = options.GetTypeInfo<MyRecord>();

        if (options.TryGetTypeInfo<MyRecord>(out JsonTypeInfo<MyRecord>? typeInfo))
        {
            _ = typeInfo;
        }
        // </JsonTypeInfoGeneric>
    }

    static void JsonNamingIgnoreExample()
    {
        // <JsonNamingIgnore>
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.PascalCase
        };

        var data = new EventData { EventName = "Launch", ReleaseVersion = "11", Notes = null };
        string json = JsonSerializer.Serialize(data, options);
        Console.WriteLine(json);
        // </JsonNamingIgnore>
    }

    static async Task TarArchiveFormatExample()
    {
        // <TarArchiveFormat>
        TarFile.CreateFromDirectory("/source/dir", "/dest/archive.tar",
            includeBaseDirectory: true, entryFormat: TarEntryFormat.Gnu);

        using Stream outputStream = File.OpenWrite("/dest/ustar.tar");
        TarFile.CreateFromDirectory("/source/dir", outputStream,
            includeBaseDirectory: false, entryFormat: TarEntryFormat.Ustar);

        CancellationToken cancellationToken = CancellationToken.None;
        await TarFile.CreateFromDirectoryAsync("/source/dir", "/dest/archive.tar",
            includeBaseDirectory: true, entryFormat: TarEntryFormat.Pax,
            cancellationToken: cancellationToken);
        // </TarArchiveFormat>
    }

    static void SafeFileHandlePipeExample()
    {
        // <SafeFileHandlePipe>
        SafeFileHandle.CreateAnonymousPipe(
            out SafeFileHandle readEnd,
            out SafeFileHandle writeEnd);

        using (readEnd)
        using (writeEnd)
        {
            Console.WriteLine(readEnd.Type);
            Console.WriteLine(writeEnd.Type);
        }
        // </SafeFileHandlePipe>
    }

    static void RegexAnyNewLineExample()
    {
        // <RegexAnyNewLine>
        string text = "line1\r\nline2\u0085line3\u2028line4";

        MatchCollection matches = Regex.Matches(
            text,
            @"^line\d$",
            RegexOptions.Multiline | RegexOptions.AnyNewLine);

        Console.WriteLine(matches.Count);
        // </RegexAnyNewLine>
    }

    public static void LinqJoinsExample()
    {
        // <LinqJoins>
        var products = new List<(int Id, string Name, string? Category)>
        {
            (1, "Laptop", "Electronics"),
            (2, "Mouse", "Electronics"),
            (3, "Orphan", null),
        };
        var categories = new List<(string Name, string Description)>
        {
            ("Electronics", "Electronic devices"),
            ("Furniture", "Office furniture"),
        };

        var leftJoined = products.LeftJoin(
            categories,
            p => p.Category,
            c => c.Name);

        foreach (var (product, category) in leftJoined)
            Console.WriteLine($"{product.Name}: {category.Description ?? "(none)"}");

        var fullJoined = products.FullJoin(
            categories,
            p => p.Category,
            c => c.Name);

        foreach (var (product, category) in fullJoined)
            Console.WriteLine(
                $"{product.Name ?? "(none)"}: {category.Description ?? "(none)"}");
        // </LinqJoins>
    }

    static void EqualityComparerCreateExample()
    {
        // <EqualityComparerCreate>
        var byName = EqualityComparer<(string Name, int Age)>.Create(p => p.Name);

        var people = new HashSet<(string Name, int Age)>(byName)
        {
            ("Alice", 30),
            ("Bob", 25),
            ("Alice", 40),
        };
        Console.WriteLine(people.Count);
        // </EqualityComparerCreate>
    }

    static void RandomGenericExample()
    {
        // <RandomGeneric>
        int i = Random.Shared.NextInteger<int>();
        long l = Random.Shared.NextInteger<long>(0L, 100L);
        byte b = Random.Shared.NextInteger<byte>(maxValue: 10);

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

        StringBuilder dest = StringBuilder.MoveChunks(source);
        Console.WriteLine(dest);
        Console.WriteLine(source.Length);
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

        using var arrayStream = new MemoryStream();
        PipeWriter arrayPipe = PipeWriter.Create(arrayStream);

        await JsonSerializer.SerializeAsyncEnumerable(
            arrayPipe,
            GenerateNumbers());
        await arrayPipe.CompleteAsync();

        using var jsonlStream = new MemoryStream();
        PipeWriter jsonlPipe = PipeWriter.Create(jsonlStream);

        await JsonSerializer.SerializeAsyncEnumerable(
            jsonlPipe,
            GenerateNumbers(),
            topLevelValues: true);
        await jsonlPipe.CompleteAsync();
        // </JsonSerializeAsyncEnumerablePipe>
    }

    static void X25519KeyExchangeExample()
    {
        // <X25519KeyExchange>
        using X25519DiffieHellman alice = X25519DiffieHellman.GenerateKey();
        using X25519DiffieHellman bob = X25519DiffieHellman.GenerateKey();

        byte[] aliceShared = alice.DeriveRawSecretAgreement(bob);
        byte[] bobShared = bob.DeriveRawSecretAgreement(alice);

        Console.WriteLine(aliceShared.SequenceEqual(bobShared));
        // </X25519KeyExchange>
    }

    static void NullableUnderlyingTypeExample()
    {
        // <NullableUnderlyingType>
        Type nullableIntType = typeof(int?);
        Type? underlying = nullableIntType.GetNullableUnderlyingType();
        Console.WriteLine(underlying);

        Type nonNullable = typeof(int);
        Console.WriteLine(nonNullable.GetNullableUnderlyingType() is null);
        // </NullableUnderlyingType>
    }
}

record MyRecord(string Name, int Value);

[JsonNamingPolicy(JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
sealed class EventData
{
    [JsonNamingPolicy(JsonKnownNamingPolicy.CamelCase)]
    public string EventName { get; set; } = "";

    public string ReleaseVersion { get; set; } = "";

    public string? Notes { get; set; }
}
