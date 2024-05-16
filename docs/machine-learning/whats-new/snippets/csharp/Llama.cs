using Microsoft.ML.Tokenizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

internal class Llama
{
    public static void RunIt()
    {
        // <Llama>
        // Create the Tokenizer.
        string modelUrl = @"https://huggingface.co/hf-internal-testing/llama-llamaTokenizer/resolve/main/llamaTokenizer.model";
        using Stream remoteStream = File.OpenRead(modelUrl);
        Tokenizer llamaTokenizer = Tokenizer.CreateLlama(remoteStream);

        string text = "Hello, World!";

        // Encode to IDs.
        IReadOnlyList<int> encodedIds = llamaTokenizer.EncodeToIds(text);
        Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedIds)}}}");
        // encodedIds = {1, 15043, 29892, 2787, 29991}

        // Decode IDs to text.
        string? decodedText = llamaTokenizer.Decode(encodedIds);
        Console.WriteLine($"decodedText = {decodedText}");
        // decodedText = Hello, World!

        // Get token count.
        int idsCount = llamaTokenizer.CountTokens(text);
        Console.WriteLine($"idsCount = {idsCount}");
        // idsCount = 5

        // Full encoding.
        EncodingResult result = llamaTokenizer.Encode(text);
        Console.WriteLine($"result.Tokens = {{'{string.Join("', '", result.Tokens)}'}}");
        // result.Tokens = {'<s>', '▁Hello', ',', '▁World', '!'}
        Console.WriteLine($"result.Offsets = {{{string.Join(", ", result.Offsets)}}}");
        // result.Offsets = {(0, 0), (0, 6), (6, 1), (7, 6), (13, 1)}
        Console.WriteLine($"result.Ids = {{{string.Join(", ", result.Ids)}}}");
        // result.Ids = {1, 15043, 29892, 2787, 29991}

        // Encode up 2 tokens.
        int index1 = llamaTokenizer.IndexOfTokenCount(text, maxTokenCount: 2, out string processedText1, out int tokenCount1);
        Console.WriteLine($"processedText1 = {processedText1}");
        // processedText1 =  ▁Hello,▁World!
        Console.WriteLine($"tokenCount1 = {tokenCount1}");
        // tokenCount1 = 2
        Console.WriteLine($"index1 = {index1}");
        // index1 = 6

        // Encode from end up to one token.
        int index2 = llamaTokenizer.LastIndexOfTokenCount(text, maxTokenCount: 1, out string processedText2, out int tokenCount2);
        Console.WriteLine($"processedText2 = {processedText2}");
        // processedText2 =  ▁Hello,▁World!
        Console.WriteLine($"tokenCount2 = {tokenCount2}");
        // tokenCount2 = 1
        Console.WriteLine($"index2 = {index2}");
        // index2 = 13
        // </Llama>

        // <Span>
        ReadOnlySpan<char> textSpan = "Hello World".AsSpan();

        // Bypass normalization.
        IReadOnlyList<int> ids = llamaTokenizer.EncodeToIds(textSpan, considerNormalization: false);

        // Bypass pretokenization.
        ids = llamaTokenizer.EncodeToIds(textSpan, considerPreTokenization: false);
        // </Span>
    }
}
