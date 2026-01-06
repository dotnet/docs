---
title: Handle invalid tool input from AI models
description: Learn strategies to handle invalid tool input when AI models provide incorrect or malformed function call parameters.
ms.date: 01/05/2026
ai-usage: ai-assisted
---

# Handle invalid tool input from AI models

When AI models call functions in your .NET code, they might sometimes provide invalid input that doesn't match the expected schema. The `Microsoft.Extensions.AI` library provides several strategies to handle these scenarios gracefully.

## Common scenarios for invalid input

AI models can provide invalid function call input in several ways:

- Missing required parameters.
- Incorrect data types (for example, sending a string when an integer is expected).
- Malformed JSON that can't be deserialized.

Without proper error handling, these issues can cause your application to fail or provide poor user experiences.

## Enable detailed error messages

By default, when a function invocation fails, the AI model receives a generic error message. You can enable detailed error reporting using the <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient.IncludeDetailedErrors?displayProperty=nameWithType> property. When this property is set to `true` and an error occurs during function invocation, the full exception message is added to the chat history. This allows the AI model to see what went wrong and potentially self-correct in subsequent attempts.

:::code language="csharp" source="snippets/handle-invalid-tool-input/csharp/IncludeDetailedErrors.cs" id="BasicUsage":::

> [!NOTE]
> Setting `IncludeDetailedErrors` to `true` can expose internal system details to the AI model and potentially to end users. Ensure exception messages don't contain secrets, connection strings, or other sensitive information. To avoid leaking sensitive information, consider disabling detailed errors in production environments.

## Implement custom error handling

For more control over error handling, you can set a custom <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient.FunctionInvoker?displayProperty=nameWithType> delegate. This allows you to intercept function calls, catch exceptions, and return custom error messages to the AI model.

The following example shows how to implement a custom function invoker that catches serialization errors and provides helpful feedback:

:::code language="csharp" source="snippets/handle-invalid-tool-input/csharp/FunctionInvoker.cs" id="BasicInvoker":::

By returning descriptive error messages instead of throwing exceptions, you allow the AI model to see what went wrong and try again with corrected input.

### Best practices for error messages

When returning error messages to enable AI self-correction, provide clear, actionable feedback:

- **Be specific**: Explain exactly what was wrong with the input.
- **Provide examples**: Show the expected format or valid values.
- **Use consistent format**: Help the AI model learn from patterns.
- **Log errors**: Track error patterns for debugging and monitoring.

## Use strict JSON schema (OpenAI only)

When using OpenAI models, you can enable strict JSON schema mode to enforce that the model's output strictly adheres to your function's schema. This helps prevent type mismatches and missing required fields.

Enable strict mode using the `Strict` additional property on your function metadata. When enabled, OpenAI models try to ensure their output matches your schema exactly:

:::code language="csharp" source="snippets/handle-invalid-tool-input/csharp/StrictSchema.cs" id="StrictMode":::

For the latest list of models that support strict JSON schema, check the [OpenAI documentation](https://platform.openai.com/docs/guides/structured-outputs).

### Limitations

While strict mode significantly improves schema adherence, keep these limitations in mind:

- Not all JSON Schema features are supported in strict mode.
- Complex schemas might still produce occasional errors.
- Always validate outputs even with strict mode enabled.
- Strict mode is OpenAI-specific and doesn't apply to other AI providers.

## Next steps

- [Access data in AI functions](access-data-in-functions.md)
- [Execute a local .NET function](../quickstarts/use-function-calling.md)
- [Build a chat app](../quickstarts/build-chat-app.md)
