using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ML.Tokenizers;

internal class BpeExample
{
    public static async Task RunAsync()
    {
        await BasicUsageAsync();
    }

    private static async Task BasicUsageAsync()
    {
        // <BpeBasic>
        // BPE (Byte Pair Encoding) tokenizer can be created from vocabulary and merges files.
        // Download the GPT-2 tokenizer files from Hugging Face.
        using HttpClient httpClient = new();
        const string vocabUrl = @"https://huggingface.co/openai-community/gpt2/raw/main/vocab.json";
        const string mergesUrl = @"https://huggingface.co/openai-community/gpt2/raw/main/merges.txt";

        using Stream vocabStream = await httpClient.GetStreamAsync(vocabUrl);
        using Stream mergesStream = await httpClient.GetStreamAsync(mergesUrl);

        // Create the BPE tokenizer using the vocabulary and merges streams.
        Tokenizer bpeTokenizer = BpeTokenizer.Create(vocabStream, mergesStream);

        string text = "Hello, how are you doing today?";

        // Encode text to token IDs.
        IReadOnlyList<int> ids = bpeTokenizer.EncodeToIds(text);
        Console.WriteLine($"Token IDs: {string.Join(", ", ids)}");

        // Count tokens.
        int tokenCount = bpeTokenizer.CountTokens(text);
        Console.WriteLine($"Token count: {tokenCount}");

        // Get detailed token information.
        IReadOnlyList<EncodedToken> tokens = bpeTokenizer.EncodeToTokens(text, out string? normalizedString);
        Console.WriteLine("Tokens:");
        foreach (EncodedToken token in tokens)
        {
            Console.WriteLine($"  ID: {token.Id}, Value: '{token.Value}'");
        }

        // Decode tokens back to text.
        string? decoded = bpeTokenizer.Decode(ids);
        Console.WriteLine($"Decoded: {decoded}");
        
        // Note: BpeTokenizer may not always decode IDs to the exact original text
        // as it can remove spaces during tokenization depending on the model configuration.
        // </BpeBasic>
    }
}
