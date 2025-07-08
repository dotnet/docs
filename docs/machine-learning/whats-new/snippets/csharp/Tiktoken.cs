using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.Tokenizers;

internal class Tiktoken
{
    public static void RunIt()
    {
        // <Tiktoken>
        Tokenizer tokenizer = TiktokenTokenizer.CreateForModel("gpt-4");
        string text = "Hello, World!";

        // Encode to IDs.
        IReadOnlyList<int> encodedIds = tokenizer.EncodeToIds(text);
        Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedIds)}}}");
        // encodedIds = {9906, 11, 4435, 0}

        // Decode IDs to text.
        string? decodedText = tokenizer.Decode(encodedIds);
        Console.WriteLine($"decodedText = {decodedText}");
        // decodedText = Hello, World!

        // Get token count.
        int idsCount = tokenizer.CountTokens(text);
        Console.WriteLine($"idsCount = {idsCount}");
        // idsCount = 4

        // Full encoding.
        IReadOnlyList<EncodedToken> result = tokenizer.EncodeToTokens(text, out string? normalizedString);
        Console.WriteLine($"result.Tokens = {{'{string.Join("', '", result.Select(t => t.Value))}'}}");
        // result.Tokens = {'Hello', ',', ' World', '!'}
        Console.WriteLine($"result.Ids = {{{string.Join(", ", result.Select(t => t.Id))}}}");
        // result.Ids = {9906, 11, 4435, 0}

        // Encode up to number of tokens limit.
        int index1 = tokenizer.GetIndexByTokenCount(
            text,
            maxTokenCount: 1,
            out string? processedText1,
            out int tokenCount1
            ); // Encode up to one token.
        Console.WriteLine($"tokenCount1 = {tokenCount1}");
        // tokenCount1 = 1
        Console.WriteLine($"index1 = {index1}");
        // index1 = 5

        int index2 = tokenizer.GetIndexByTokenCountFromEnd(
            text,
            maxTokenCount: 1,
            out string? processedText2,
            out int tokenCount2
            ); // Encode from end up to one token.
        Console.WriteLine($"tokenCount2 = {tokenCount2}");
        // tokenCount2 = 1
        Console.WriteLine($"index2 = {index2}");
        // index2 = 12
        // </Tiktoken>
    }
}
