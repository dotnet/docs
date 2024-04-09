using System;
using System.Collections.Generic;
using Microsoft.ML.Tokenizers;

internal class TiktokenExample
{
    public static void RunIt()
    {
        // <Tiktoken>
        Tokenizer tokenizer = Tokenizer.CreateTiktokenForModel("gpt-4");
        string text = "Hello, World!";

        // Encode to IDs.
        IReadOnlyList<int> encodedIds = tokenizer.EncodeToIds(text);
        Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedIds)}}}");
        // encodedIds = {9906, 11, 4435, 0}

        // Decode IDs to text.
        string decodedText = tokenizer.Decode(encodedIds);
        Console.WriteLine($"decodedText = {decodedText}");
        // decodedText = Hello, World!

        // Get token count.
        int idsCount = tokenizer.CountTokens(text);
        Console.WriteLine($"idsCount = {idsCount}");
        // idsCount = 4

        // Full encoding.
        EncodingResult result = tokenizer.Encode(text);
        Console.WriteLine($"result.Tokens = {{'{string.Join("', '", result.Tokens)}'}}");
        // result.Tokens = {'Hello', ',', ' World', '!'}
        Console.WriteLine($"result.Offsets = {{{string.Join(", ", result.Offsets)}}}");
        // result.Offsets = {(0, 5), (5, 1), (6, 6), (12, 1)}
        Console.WriteLine($"result.Ids = {{{string.Join(", ", result.Ids)}}}");
        // result.Ids = {9906, 11, 4435, 0}

        // Encode up to number of tokens limit.
        int index1 = tokenizer.IndexOfTokenCount(
            text,
            maxTokenCount: 1,
            out string processedText1,
            out int tokenCount1
            ); // Encode up to one token.
        Console.WriteLine($"processedText1 = {processedText1}");
        // processedText1 = Hello, World!
        Console.WriteLine($"tokenCount1 = {tokenCount1}");
        // tokenCount1 = 1
        Console.WriteLine($"index1 = {index1}");
        // index1 = 5

        int index2 = tokenizer.LastIndexOfTokenCount(
            text,
            maxTokenCount: 1,
            out string processedText2,
            out int tokenCount2
            ); // Encode from end up to one token.
        Console.WriteLine($"processedText2 = {processedText2}");
        // processedText2 = Hello, World!
        Console.WriteLine($"tokenCount2 = {tokenCount2}");
        // tokenCount2 = 1
        Console.WriteLine($"index2 = {index2}");
        // index2 = 12
        // </Tiktoken>
    }
}
