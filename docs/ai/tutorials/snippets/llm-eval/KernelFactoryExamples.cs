using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

// Disable warnings about experimental Semantic Kernel features
#pragma warning disable SKEXP0010
#pragma warning disable CS8604

class KernelFactoryExamples
{
    public static void Examples()
    {
        CreateKernelEval();
    }

    // <evalKernel>
    public static Kernel CreateKernelEval()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        IKernelBuilder builder = Kernel.CreateBuilder();

        builder.AddAzureOpenAIChatCompletion(
            config["AZURE_OPENAI_MODEL"],
            config["AZURE_OPENAI_ENDPOINT"],
            config["AZURE_OPENAI_KEY"]
        );

        return builder.Build();
    }

    // </evalKernel>

    // <testKernel>
    public static Kernel CreateKernelTest()
    {
        IKernelBuilder builder = Kernel.CreateBuilder();

        builder.AddOpenAIChatCompletion(
            modelId: "phi3",
            endpoint: new Uri("http://localhost:11434"),
            apiKey: "api"
        );

        return builder.Build();
    }

    // </testKernel>

    // <genKernel>
    public static Kernel CreateKernelGenerateData()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        IKernelBuilder builder = Kernel.CreateBuilder();

        builder.AddAzureOpenAIChatCompletion(
            config["AZURE_OPENAI_MODEL"],
            config["AZURE_OPENAI_ENDPOINT"],
            config["AZURE_OPENAI_KEY"]
        );

        return builder.Build();
    }
    // </genKernel>
}
