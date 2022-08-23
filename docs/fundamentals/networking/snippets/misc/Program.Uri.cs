public static partial class Program
{
    // <dangerousuri>
    static void DangerousUri()
    {
        const string uriString =
            "https://localhost:5001/path%4A?query%4A#/foo";

        UriCreationOptions creationOptions = new()
        {
            DangerousDisablePathAndQueryCanonicalization = true
        };

        Uri uri = new(uriString, creationOptions);
        Console.WriteLine(uri);
        Console.WriteLine(uri.AbsolutePath);
        Console.WriteLine(uri.Query);
        Console.WriteLine(uri.PathAndQuery);
        Console.WriteLine(uri.Fragment);
        // Sample output:
        //     https://localhost:5001/path%4A?query%4A#/foo
        //     /path%4A
        //     ?query%4A#/foo
        //     /path%4A?query%4A#/foo

        Uri canonicalUri = new(uriString);
        Console.WriteLine(canonicalUri.PathAndQuery);
        Console.WriteLine(canonicalUri.Fragment);
        // Sample output:
        //     /pathJ?queryJ
        //     #/foo
    }
    // </dangerousuri>

    // <canonicaluri>
    static void CanonicalUri()
    {
        const string uriString =
            "https://docs.microsoft.com/en-us/dotnet/path?key=value#bookmark";

        Uri canonicalUri = new(uriString);
        Console.WriteLine(canonicalUri.Host);
        Console.WriteLine(canonicalUri.PathAndQuery);
        Console.WriteLine(canonicalUri.Fragment);
        // Sample output:
        //     docs.microsoft.com
        //     /en-us/dotnet/path?key=value
        //     #bookmark
    }
    // </canonicaluri>
}
