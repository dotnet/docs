---
title: Handle invalid tool input from AI models
description: Learn strategies to handle invalid tool input when AI models provide incorrect or malformed function call parameters.
ms.date: 01/05/2026
ai-usage: ai-assisted
---

# Handle invalid tool input from AI models

When AI models call functions in your .NET code, they might sometimes provide invalid input that doesn't match the expected schema. This can happen due to serialization errors, missing required parameters, or incorrect data types. The `Microsoft.Extensions.AI` library provides several strategies to handle these scenarios gracefully.

## Common scenarios for invalid input

AI models can provide invalid function call input in several ways:

- Missing required parameters
- Incorrect data types (for example, sending a string when a number is expected)
- Malformed JSON that can't be deserialized
- Values that violate business rules or constraints

Without proper error handling, these issues can cause your application to fail or provide poor user experiences.

## Enable detailed error messages

By default, when a function invocation fails, the AI model receives a generic error message. You can enable detailed error reporting using the <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient.IncludeDetailedErrors?displayProperty=nameWithType> property to send the full exception details back to the AI model.

### How it works

When `IncludeDetailedErrors` is set to `true`, the full exception message is added to the chat history if an error occurs during function invocation. This allows the AI model to see what went wrong and potentially self-correct in subsequent attempts.

:::code language="csharp" source="snippets/handle-invalid-tool-input/IncludeDetailedErrors.cs" id="BasicUsage":::

### Security considerations

Setting `IncludeDetailedErrors` to `true` can expose internal system details to the AI model and potentially to end users. Consider the following:

- **Development and debugging**: Enable detailed errors to help the AI model understand and fix issues
- **Production environments**: Disable detailed errors to avoid leaking sensitive information
- **Sensitive data**: Ensure exception messages don't contain secrets, connection strings, or other sensitive information

## Implement custom error handling

For more control over error handling, you can set a custom <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient.FunctionInvoker?displayProperty=nameWithType> delegate. This allows you to intercept function calls, catch exceptions, and return custom error messages to the AI model.

### Basic custom invoker

The following example shows how to implement a custom function invoker that catches serialization errors and provides helpful feedback:

:::code language="csharp" source="snippets/handle-invalid-tool-input/FunctionInvoker.cs" id="BasicInvoker":::

### Implement retry logic

You can extend the custom invoker pattern to implement retry logic. This is useful when you want to give the AI model multiple chances to provide valid input:

:::code language="csharp" source="snippets/handle-invalid-tool-input/FunctionInvoker.cs" id="RetryInvoker":::

### Best practices for retry prompts

When implementing retry logic, provide clear, actionable feedback to the AI model:

- **Be specific**: Explain exactly what was wrong with the input
- **Provide examples**: Show the expected format or valid values
- **Set limits**: Avoid infinite retry loops by limiting retry attempts
- **Log attempts**: Track retry attempts for debugging and monitoring

Example retry messages:

- ❌ "Invalid input. Please retry." (too vague)
- ✅ "The 'temperature' parameter must be a number between -50 and 50. You provided 'hot'. Please retry with a numeric value."
- ✅ "Missing required parameter 'location'. Please provide a location string and retry."

## Use strict JSON schema with OpenAI

When using OpenAI models, you can enable strict JSON schema mode to enforce that the model's output strictly adheres to your function's schema. This helps prevent type mismatches and missing required fields.

### Enable strict mode

Strict mode is enabled using the `Strict` additional property on your function metadata. When enabled, OpenAI models try to ensure their output matches your schema exactly:

:::code language="csharp" source="snippets/handle-invalid-tool-input/StrictSchema.cs" id="StrictMode":::

### Supported models

Strict JSON schema mode is only supported on certain OpenAI models:

- `gpt-4o-2024-08-06` and later
- `gpt-4o-mini-2024-07-18` and later

Check the [OpenAI documentation](https://platform.openai.com/docs/guides/structured-outputs) for the latest list of supported models.

### Limitations

While strict mode significantly improves schema adherence, keep these limitations in mind:

- Not all JSON Schema features are supported in strict mode
- Complex schemas might still produce occasional errors
- Always validate outputs even with strict mode enabled
- Strict mode is OpenAI-specific and doesn't apply to other AI providers

## Combine strategies

For robust error handling, combine multiple strategies:

:::code language="csharp" source="snippets/handle-invalid-tool-input/Combined.cs" id="CombinedStrategies":::

## Next steps

- [Access data in AI functions](access-data-in-functions.md)
- [Execute a local .NET function](../quickstarts/use-function-calling.md)
- [Build a chat app](../quickstarts/build-chat-app.md)
