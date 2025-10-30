using System;
using System.Collections.Generic;
using Microsoft.ML.Tokenizers;

internal class BpeExample
{
    public static void Run()
    {
        BasicUsage();
    }

    private static void BasicUsage()
    {
        // <BpeBasic>
        // Create a BPE tokenizer using Tiktoken.
        Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-4o");

        string text = "Hello, how are you doing today?";

        // Encode text to token IDs.
        IReadOnlyList<int> ids = tokenizer.EncodeToIds(text);
        Console.WriteLine($"Token IDs: {string.Join(", ", ids)}");

        // Count tokens.
        int tokenCount = tokenizer.CountTokens(text);
        Console.WriteLine($"Token count: {tokenCount}");

        // Get detailed token information.
        IReadOnlyList<EncodedToken> tokens = tokenizer.EncodeToTokens(text, out string? normalizedString);
        Console.WriteLine("Tokens:");
        foreach (EncodedToken token in tokens)
        {
            Console.WriteLine($"  ID: {token.Id}, Value: '{token.Value}'");
        }

        // Decode tokens back to text.
        string? decoded = tokenizer.Decode(ids);
        Console.WriteLine($"Decoded: {decoded}");
        // </BpeBasic>
    }
}
