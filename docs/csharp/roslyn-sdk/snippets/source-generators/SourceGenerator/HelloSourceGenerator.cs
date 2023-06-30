using Microsoft.CodeAnalysis;

namespace SourceGenerator;

[Generator]
public sealed class HelloSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var compilationIncrementalValue = context.CompilationProvider;

        context.RegisterSourceOutput(
            compilationIncrementalValue, 
            static (context, compilation) =>
        {            
            // Get the entry point method
            var mainMethod = compilation.GetEntryPoint(context.CancellationToken);
            var typeName = mainMethod.ContainingType.Name;

            string source = $$"""
                // Auto-generated code
                namespace {{mainMethod.ContainingNamespace.ToDisplayString()}};
                
                public static partial class {{typeName}}
                {
                    static partial void HelloFrom(string name) =>
                        Console.WriteLine($"Generator says: Hi from '{name}'");
                }                
                """;

            // Add the source code to the compilation
            context.AddSource($"{typeName}.g.cs", source);
        });
    }
}
