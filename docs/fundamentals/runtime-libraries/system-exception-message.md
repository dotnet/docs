---
title: System.Exception.Message property
description: Learn about the System.Exception.Message property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Exception.Message property

[!INCLUDE [context](includes/context.md)]

Error messages target the developer who is handling the exception. The text of the <xref:System.Exception.Message> property should completely describe the error and, when possible, should also explain how to correct the error. Top-level exception handlers may display the message to end-users, so you should ensure that it is grammatically correct and that each sentence of the message ends with a period. Do not use question marks or exclamation points. If your application uses localized exception messages, you should ensure that they are accurately translated.

> [!IMPORTANT]
> Do not disclose sensitive information in exception messages without checking for the appropriate permissions.

The value of the <xref:System.Exception.Message> property is included in the information returned by <xref:System.Exception.ToString%2A>. The <xref:System.Exception.Message> property is set only when creating an <xref:System.Exception>. If no message was supplied to the constructor for the current instance, the system supplies a default message that is formatted using the current system culture.

## Examples

The following code example throws and then catches an <xref:System.Exception> exception and displays the exception's text message using the <xref:System.Exception.Message> property.

:::code language="csharp" source="./snippets/System/Exception/HelpLink/csharp/properties.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Exception/HelpLink/fsharp/properties.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Exception/HelpLink/vb/properties.vb" id="Snippet1":::
