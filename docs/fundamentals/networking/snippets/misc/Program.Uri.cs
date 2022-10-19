public static partial class Program
{
    static void CanonicalUri()
    {
        // <canonicaluri>
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
        // </canonicaluri>
    }
}
