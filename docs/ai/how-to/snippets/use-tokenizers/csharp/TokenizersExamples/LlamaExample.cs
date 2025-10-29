using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ML.Tokenizers;

internal class LlamaExample
{
    public static async Task RunAsync()
    {
        await BasicUsageAsync();
        AdvancedOptions();
    }

    private static async Task BasicUsageAsync()
    {
        // <LlamaBasic>
        // Open a stream to the remote Llama tokenizer model data file
        using HttpClient httpClient = new();
        const string modelUrl = @"https://huggingface.co/hf-internal-testing/llama-tokenizer/resolve/main/tokenizer.model";
        using Stream remoteStream = await httpClient.GetStreamAsync(modelUrl);

        // Create the Llama tokenizer using the remote stream
        Tokenizer llamaTokenizer = LlamaTokenizer.Create(remoteStream);

        string input = "Hello, world!";

        // Encode text to token IDs
        IReadOnlyList<int> ids = llamaTokenizer.EncodeToIds(input);
        Console.WriteLine($"Token IDs: {string.Join(", ", ids)}");
        // Output: Token IDs: 1, 15043, 29892, 3186, 29991

        // Count the tokens
        Console.WriteLine($"Tokens: {llamaTokenizer.CountTokens(input)}");
        // Output: Tokens: 5

        // Decode token IDs back to text
        string? decoded = llamaTokenizer.Decode(ids);
        Console.WriteLine($"Decoded: {decoded}");
        // Output: Decoded: Hello, world!
        // </LlamaBasic>
    }

    private static void AdvancedOptions()
    {
        // For demonstration purposes, we'll use a mock tokenizer
        // In real scenarios, you would initialize this properly
        Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-4o");
        
        // <LlamaAdvanced>
        ReadOnlySpan<char> textSpan = "Hello World".AsSpan();

        // Bypass normalization during encoding
        IReadOnlyList<int> ids = tokenizer.EncodeToIds(textSpan, considerNormalization: false);

        // Bypass pretokenization during encoding
        ids = tokenizer.EncodeToIds(textSpan, considerPreTokenization: false);

        // Bypass both normalization and pretokenization
        ids = tokenizer.EncodeToIds(textSpan, considerNormalization: false, considerPreTokenization: false);
        // </LlamaAdvanced>
    }
}
