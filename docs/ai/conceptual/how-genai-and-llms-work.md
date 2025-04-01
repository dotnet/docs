---
title: "How Generative AI and LLMs work"
description: "Understand how Generative AI and large language models (LLMs) work and how they might be useful in your .NET projects."
author: haywoodsloan
ms.topic: concept-article
ms.date: 11/24/2024

#customer intent: As a .NET developer, I want to understand how Generative AI and large language models (LLMs) work and how they may be useful in my .NET projects.

---

# How generative AI and LLMs work

Generative AI is a type of artificial intelligence capable of creating original content, such as natural language, images, audio, and code. The output of a generative AI is based on the inputs provided by the user. One common way for users to interact with generative AI is through chat applications that use natural language as their input. ChatGPT, developed by OpenAI, is a popular example of this. Generative AI applications that use natural language as an input are powered by large language models (LLMs) to perform natural language processing (NLP).

## How generative AI works

All generative AI is built on top of models. These models are trained with large sets of data in the form of content, such as natural language, images, audio, and code. Generative AI models use the patterns identified in the training data to produce new, statistically similar content.

The input provided by the user is used by the AI model to build an output. The input is first parsed into a form of data that the model can understand. The model then uses that data to identify matching patterns from its training that it combines to build the final output. Generative AI models are designed to produce unique content, so they won't generate the same output for identical inputs.

Generative AI applications that support natural language as an input or output utilize LLMs to do so. The LLM is used to perform NLP, which classifies the input text and determines its sentiment. That classification and sentiment analysis is used by the generative AI model to identify patterns and build the output. If the output is text, the LLM alone can be used to generate it. If the output is audio or images, additional models are used to provide the data and patterns for generating outputs in that format.

## Common uses of generative AI

Generative AI applications support a variety of potential use cases and potential outputs, which are explored in the following sections.

### Natural language generation

Some generative AI applications can produce natural language outputs, such as:

- Professionally worded summaries for a LinkedIn profile
- Rich descriptions of items in an online storefront
- Ideas for healthy meals

For example, given the user input *Give me three ideas for a healthy breakfast including peppers*, a generative AI application might produce the following output:

*OK, here are three healthy breakfasts that include peppers:*

1. *Egg and Pepper Scramble: Dice up some bell peppers and sauté them in a pan until they're slightly softened. Then, add in some beaten eggs and scramble everything together. Serve with whole-grain toast for a nutritious breakfast.*

2. *Pepper and Avocado Toast: Toast a slice of whole-grain bread and top it with sliced bell peppers, mashed avocado, and a sprinkle of salt and pepper. This is a great way to get some healthy fats from the avocado along with the vitamin C from the peppers.*

3. *Breakfast Burrito with Peppers: Sauté some diced bell peppers, onions, and scrambled eggs together in a pan. Then, spoon the mixture onto a whole-grain tortilla and top with some salsa or hot sauce. Roll it up and enjoy a satisfying and nutritious breakfast.*

### Image generation

Some generative AI applications produce image outputs from natural language inputs. Depending on the application and its models, users might be able to specify:

- The people or things to appear the image
- The artistic style to create the image in
- References for generating similar images

Image generation can create virtual avatars for online accounts, design logos for a business, or provide artistic inspiration for creators. For example, a user may input the request, *Create an image of an elephant eating a burger*. A generative AI application might produce the following output:

:::image type="content" source="../media/how-genai-and-llms-work/generated-image.png" lightbox="../media/how-genai-and-llms-work/generated-image.png" alt-text="Example AI generated image of an elephant eating a hamburger.":::

### Audio generation

Some generative AI applications produce audio outputs from natural language inputs. Depending on the application and its models, users might be able to:

- Synthesize natural sounding voices from input text
- Create music in a specific style or featuring certain instruments
- Modify input audio files based on a set criteria provided in natural language

Audio generation can provide spoken responses from digital voice assistants, add backing instruments to songs for music production, or reproduce a user's original voice from reference recordings.

### Code generation

Some generative AI applications produce code from natural language inputs. Depending on the application and its models, users might be able to generate code that:

- Is in the language of their choice
- Accepts a specific input and output structure
- Uses specific technologies based on their reference documentation

Code generation can provide quick implementations of common operations, such as sort or filter data, speed up translating code from one language to another, or answer questions about a technology based on specified reference documentation. For example, given the input "Show me how to code a game of tic-tac-toe with C#", a generative AI application might produce the following output:

*Here's a simple example of how you can code a game of tic-tac-toe in C#:*

```csharp
using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // Player 1 will start
        static int choice; // The number the player chooses
        static int flag = 0; // Set the flag value to 0

        // Check if the position is already marked or not
        private static int CheckPosition(char mark)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == mark)
                {
                    return 1;
                }
            }
            return 0;
        }

        // The rest of the generated code has been omitted for brevity
        // ...
    }
}
```

*This code creates a simple console-based tic-tac-toe game in C#. It uses a single-dimensional array to represent the board and checks for a win or draw after each move.*

## How LLMs work

When training an LLM, the training text is first broken down into [tokens](understanding-tokens.md). Each token identifies a unique text value. A token can be a distinct word, a partial word, or a combination of words and punctuation. Each token is assigned an ID, which enables the text to be represented as a sequence of token IDs.

After the text has been broken down into tokens, a contextual vector, known as an [embedding](embeddings.md), is assigned to each token. These embedding vectors are multi-valued numeric data where each element of a token's vector represents a semantic attribute of the token. The elements of a token's vector are determined based on how commonly tokens are used together or in similar contexts.

The goal is to predict the next token in the sequence based on the preceding tokens. A weight is assigned to each token in the existing sequence that represents its relative influence on the next token. A calculation is then performed that uses the preceding tokens' weights and embeddings to predict the next vector value. The model then selects the most probable token to continue the sequence based on the predicted vector.

This process continues iteratively for each token in the sequence, with the output sequence being used regressively as the input for the next iteration. The output is built one token at a time. This strategy is analogous to how auto-complete works, where suggestions are based on what's been typed so far and updated with each new input.

During training, the complete sequence of tokens is known, but all tokens that come after the one currently being considered are ignored. The predicted value for the next token's vector is compared to the actual value and the loss is calculated. The weights are then incrementally adjusted to reduce the loss and improve the model.

## Related content

- [Understand Tokens](understanding-tokens.md)
- [Prompt engineering](prompt-engineering-dotnet.md)
- [Large language models](/training/modules/fundamentals-generative-ai/3-language%20models)
