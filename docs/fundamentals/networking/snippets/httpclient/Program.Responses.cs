static partial class Program
{
    static async Task HandleResponsesAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Head, 
            "https://www.example.com");

        // <request>
        using HttpResponseMessage response = await client.SendAsync(request);
        // </request>

        // <isstatuscode>
        if (response is { StatusCode: HttpStatusCode.OK })
        {
            // Omitted for brevity...
        }
        // </isstatuscode>

        // <issuccessstatuscode>
        if (response.IsSuccessStatusCode)
        {
            // Omitted for brevity...
        }
        // </issuccessstatuscode>

        // <ensurestatuscode>
        response.EnsureSuccessStatusCode();
        // </ensurestatuscode>
    }
}
