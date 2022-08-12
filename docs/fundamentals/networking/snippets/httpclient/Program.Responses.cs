static partial class Program
{
    static async Task HandleResponsesAsync<T>(HttpClient client)
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

        // <stream>
        await using Stream responseStream =
            await response.Content.ReadAsStreamAsync();
        // </stream>

        // <array>
        byte[] responseByteArray = await response.Content.ReadAsByteArrayAsync();
        // </array>

        // <string>
        string responseString = await response.Content.ReadAsStringAsync();
        // </string>

        // <json>
        T? result = await response.Content.ReadFromJsonAsync<T>();
        // </json>
    }
}
