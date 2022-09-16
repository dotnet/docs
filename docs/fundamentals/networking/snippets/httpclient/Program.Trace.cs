static partial class Program
{
    static void Trace()
    {
        // <trace>
        using HttpRequestMessage request = new(
            HttpMethod.Trace, 
            "{ValidRequestUri}");
        // </trace>
    }
}
