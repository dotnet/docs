using System;
using System.Threading.Tasks;

// Run examples
Console.WriteLine("=== Tiktoken Examples ===");
TiktokenExample.Run();

Console.WriteLine("\n=== Llama Examples ===");
try
{
    await LlamaExample.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Note: Llama example requires network access to download model files: {ex.Message}");
}

Console.WriteLine("\n=== BPE Examples ===");
BpeExample.Run();
