using System;
using System.Collections.Generic;
using Microsoft.ML.Tokenizers;

internal class TiktokenExample
{
    public static void Run()
    {
        BasicUsage();
        TrimText();
    }

    private static void BasicUsage()
    {
        // <TiktokenBasic>
        // Initialize the tokenizer for the gpt-4o model.
        Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-4o");

        string source = "Text tokenization is the process of splitting a string into a list of tokens.";

        // Count the tokens in the text.
        Console.WriteLine($"Tokens: {tokenizer.CountTokens(source)}");
        // Output: Tokens: 16

        // Encode text to token IDs.
        IReadOnlyList<int> ids = tokenizer.EncodeToIds(source);
        Console.WriteLine($"Token IDs: {string.Join(", ", ids)}");
        // Output: Token IDs: 1279, 6602, 2860, 382, 290, 2273, 328, 87130, 261, 1621, 1511, 261, 1562, 328, 20290, 13

        // Decode token IDs back to text.
        string? decoded = tokenizer.Decode(ids);
        Console.WriteLine($"Decoded: {decoded}");
        // Output: Decoded: Text tokenization is the process of splitting a string into a list of tokens.
        // </TiktokenBasic>
    }

    private static void TrimText()
    {
        // <TiktokenTrim>
        Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-4o");

        string source = "Text tokenization is the process of splitting a string into a list of tokens.";

        // Get the last 5 tokens from the text.
        var trimIndex = tokenizer.GetIndexByTokenCountFromEnd(source, 5, out string? processedText, out _);
        processedText ??= source;
        Console.WriteLine($"Last 5 tokens: {processedText.Substring(trimIndex)}");
        // Output: Last 5 tokens:  a list of tokens.

        // Get the first 5 tokens from the text.
        trimIndex = tokenizer.GetIndexByTokenCount(source, 5, out processedText, out _);
        processedText ??= source;
        Console.WriteLine($"First 5 tokens: {processedText.Substring(0, trimIndex)}");
        // Output: First 5 tokens: Text tokenization is the
        // </TiktokenTrim>
    }
}
