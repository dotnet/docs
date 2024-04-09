using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ML.Tokenizers;

internal class LlamaTokenizerExample
{
    public static async Task RunItAsync()
    {
        // Create the Tokenizer.
        HttpClient httpClient = new HttpClient();
        string modelUrl = @"https://huggingface.co/hf-internal-testing/llama-tokenizer/resolve/main/tokenizer.model";
        using Stream remoteStream = await httpClient.GetStreamAsync(modelUrl);
        Tokenizer tokenizer = Tokenizer.CreateLlama(remoteStream);

        string text = "Hello, World!";

        // Encode to IDs.
        IReadOnlyList<int> encodedIds = tokenizer.EncodeToIds(text);
        Console.WriteLine($"encodedIds = {{{string.Join(", ", encodedIds)}}}");
        // encodedIds = {1, 15043, 29892, 2787, 29991}

        // Decode IDs to text.
        string? decodedText = tokenizer.Decode(encodedIds);
        Console.WriteLine($"decodedText = {decodedText}");
        // decodedText = Hello, World!

        // Get token count.
        int idsCount = tokenizer.CountTokens(text);
        Console.WriteLine($"idsCount = {idsCount}");
        // idsCount = 5

        // Full encoding.
        EncodingResult result = tokenizer.Encode(text);
        Console.WriteLine($"result.Tokens = {{'{string.Join("', '", result.Tokens)}'}}");
        // result.Tokens = {'<s>', '▁Hello', ',', '▁World', '!'}
        Console.WriteLine($"result.Offsets = {{{string.Join(", ", result.Offsets)}}}");
        // result.Offsets = {(0, 0), (0, 6), (6, 1), (7, 6), (13, 1)}
        Console.WriteLine($"result.Ids = {{{string.Join(", ", result.Ids)}}}");
        // result.Ids = {1, 15043, 29892, 2787, 29991}

        // Encode up to number of tokens limit.
        int index1 = tokenizer.IndexOfTokenCount(
            text,
            maxTokenCount: 2,
            out string processedText1,
            out int tokenCount1
            );// Encode up to two tokens.
        Console.WriteLine($"processedText1 = {processedText1}");
        // processedText1 =  ▁Hello,▁World!
        Console.WriteLine($"tokenCount1 = {tokenCount1}");
        // tokenCount1 = 2
        Console.WriteLine($"index1 = {index1}");
        // index1 = 6

        int index2 = tokenizer.LastIndexOfTokenCount(
            text,
            maxTokenCount: 1,
            out string processedText2,
            out int tokenCount2
            ); // Encode from end up to one token.
        Console.WriteLine($"processedText2 = {processedText2}");
        // processedText2 =  ▁Hello,▁World!
        Console.WriteLine($"tokenCount2 = {tokenCount2}");
        // tokenCount2 = 1
        Console.WriteLine($"index2 = {index2}");
        // index2 = 13
    }
}
