using System;
using System.Formats.Tar;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

static class LibrariesExamples
{
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
