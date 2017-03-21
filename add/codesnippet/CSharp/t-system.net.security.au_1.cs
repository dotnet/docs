
    // The following class displays the properties of an authenticatedStream.
    public class AuthenticatedStreamReporter
{
    public static void DisplayProperties(AuthenticatedStream stream)
   {
        Console.WriteLine("IsAuthenticated: {0}", stream.IsAuthenticated);
        Console.WriteLine("IsMutuallyAuthenticated: {0}", stream.IsMutuallyAuthenticated);
        Console.WriteLine("IsEncrypted: {0}", stream.IsEncrypted);
        Console.WriteLine("IsSigned: {0}", stream.IsSigned);
        Console.WriteLine("IsServer: {0}", stream.IsServer);
    }
}