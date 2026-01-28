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
        // BPE (Byte Pair Encoding) tokenizer can be created from vocabulary and merges files.
        // This is useful when working with custom trained models.
        
        // Example: To create a BPE tokenizer for GPT-2 or similar models:
        // string vocabFile = "path/to/vocab.json";
        // string mergesFile = "path/to/merges.txt";
        // Tokenizer bpeTokenizer = BpeTokenizer.Create(vocabFile, mergesFile);
        
        // For this example, we'll demonstrate with Tiktoken which uses BPE internally.
        // Tiktoken is a specific implementation of BPE tokenization.
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
        
        // Note: BpeTokenizer might not always decode IDs to the exact original text
        // as it can remove spaces during tokenization depending on the model configuration.
        // </BpeBasic>
    }
}
