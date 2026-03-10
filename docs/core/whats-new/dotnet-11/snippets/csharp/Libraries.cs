using System.Formats.Tar;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

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
}

record MyRecord(string Name, int Value);
