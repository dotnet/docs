﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main() =>
        Console.WriteLine($"docs.microsoft.com/dotnet content length = {await AccessWeb.Example.GetUrlContentLengthAsync()}");
}

class AccessWeb
{
    public static AccessWeb Example = new AccessWeb();

    // <ControlFlow>
    public async Task<int> GetUrlContentLengthAsync()
    {
        var client = new HttpClient();

        Task<string> getStringTask =
            client.GetStringAsync("https://docs.microsoft.com/dotnet");

        DoIndependentWork();

        string contents = await getStringTask;

        return contents.Length;
    }

    void DoIndependentWork()
    {
        Console.WriteLine("Working...");
    }
    // </ControlFlow>
}
