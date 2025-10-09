# Environment-based Provider Switching

This example demonstrates how to switch between local and cloud AI providers based on the current environment.

To run this example:

1. For local development with Ollama:
   - Install Ollama from https://ollama.ai
   - Run `ollama pull llama3.1` and `ollama pull all-minilm`
   - Set environment variable: `DOTNET_ENVIRONMENT=Development`

2. For production with Azure OpenAI:
   - Set up Azure OpenAI resource
   - Configure authentication (managed identity or API key)
   - Set environment variable: `DOTNET_ENVIRONMENT=Production`

## Usage

```bash
dotnet run
```

The application will automatically detect the environment and use the appropriate provider.