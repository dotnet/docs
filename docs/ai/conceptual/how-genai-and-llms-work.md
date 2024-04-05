---
title: "Concept - How Generative AI and LLMs work"
description: "Understand how Generative AI and large language models (LLMs) work and how they may be useful in your .NET projects."
ms.topic: concept-article
ms.date: 04/04/2024

#customer intent: As a .NET developer, I want to understand how Generative AI and large language models (LLMs) work and how they may be useful in my .NET projects.

---

# How Generative AI and LLMs work

Generative AI is a type of artificial intelligence capable of creating original content, such as natural language, images, audio, code, etc. The output of a generative AI is based on the inputs provided by the user. One common way for users to interact with generative AI is through chat applications which use natural language as their input. ChatGPT, developed by OpenAI, is a popular example of this. Generative AI applications which use natural language as an input are powered by large language models (LLMs) to perform natural language processing (NLP).

## How does Generative AI work?

All generative AI is built on top of models. These models are trained with large sets of data in the form of content, such as natural language, images, audio, code, etc. Generative AI models use the patterns identified in the training data to produce new, statistically similar content.

The input provided by the user is the seed that the generative AI model builds its output from. The input is first parsed into a form of data that the model can understand. The model then uses that data to identify matching patterns from its training that it will combine to build the final output. Generative AI models are designed to produce unique content, so they won't generate the same output for identical inputs.

Generative AI applications which support natural language as an input or output utilize LLMs to do so. The LLM is used to perform NLP, classifying the input text and determining its sentiment. That classification and sentiment analysis is used by the generative AI model to identify patterns and build the output. If the output is text, the LLM alone can be used to generate it. If the ouput is audio, images, etc., additional models are used to provide the data and patterns for generating outputs in that format.

## Potential uses of Generative AI

Because generative AI applications can support a variety of output formats, there are many potential use cases for them.

### Natural language generation

Some generative AI applications can produce natural language outputs, such as:

- Ideas for healthy meals
- Professionally worded summaries for a LinkedIn profile
- Rich descriptions of items in an online storefront

For example, a user may input the request, "Give me three ideas for a healthy breakfast including peppers." A generative AI application might produce the following output:

_OK, here are three healthy breakfasts that include peppers:_

1. _Egg and Pepper Scramble: Dice up some bell peppers and sauté them in a pan until they're slightly softened. Then, add in some beaten eggs and scramble everything together. Serve with whole-grain toast for a nutritious breakfast._

2. _Pepper and Avocado Toast: Toast a slice of whole-grain bread and top it with sliced bell peppers, mashed avocado, and a sprinkle of salt and pepper. This is a great way to get some healthy fats from the avocado along with the vitamin C from the peppers._

3. _Breakfast Burrito with Peppers: Sauté some diced bell peppers, onions, and scrambled eggs together in a pan. Then, spoon the mixture onto a whole-grain tortilla and top with some salsa or hot sauce. Roll it up and enjoy a satisfying and nutritious breakfast._

### Image generation

Some generative AI applications can produce image outputs from natural language inputs. Depending on the application and its model(s), users may be able to specify:

- The people or things to appear the image
- The artistic style to create the image in
- References for generating similar images

Image generation can be used to create virtual avatars for online accounts, design logos for a business, or provide artistic inspiration for creators. For example, a user may input the request, "Create an image of an elephant eating a burger." A generative AI application might produce the following output:

:::image type="content" source="../media/how-genai-and-llms-work/generated-image.png" lightbox="../media/how-genai-and-llms-work/generated-image.png" alt-text="Example AI generated image of an elephant eating a hamburger.":::

### Audio generation

Some generative AI applications can produce audio outputs from natural language inputs. Depending on the application and its model(s), users may be able to:

- Synthesize natural sounding voices from input text
- Create music in a specific style or featuring certain instruments
- Modify input audio files based on a set criteria provided in natural language

Audio generation can be used to provide spoken responses from digital voice assistants, add backing instruments to songs for music production, or reproduce a user's original voice from reference recordings if they have experienced some form of speech impairment.

### Code generation

Some generative AI applications can produce code from natural language inputs. Depending on the application and its model(s), users may be able to generate code:

- In the language of their choice
- That accepts a specific input and output structure
- That uses specific technologies based on their reference documentation

Code generation can be used to provide quick implementations of common operations, such as sorting or filtering data, speed up translating code from one language to another, or answer questions about a technology based on specifed reference documentation. For example, a user may input the request, "Show me how to code a game of tic-tac-toe with Python". A generative AI application might produce the following output:

_Sure, here's a simple implementation of a tic-tac-toe game in C#:_

```csharp
using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // Player 1 starts
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // whenever loop starts, the screen will be cleared
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0) // checking the chance of the player
                {
                    Console.WriteLine("Turn Player 2");
                }
                else
                {
                    Console.WriteLine("Turn Player 1");
                }
                Console.WriteLine("\n");
                Board(); // calling the board Function
                choice = int.Parse(Console.ReadLine()); // taking users choice
                if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    if (player % 2 == 0) // checking the chance of the player
                    {
                        board[choice - 1] = 'O';
                        player++;
                    }
                    else
                    {
                        board[choice - 1] = 'X';
                        player++;
                    }
                }
                else // if there is already an X or O, the position is already filled
                {
                    Console.WriteLine("Sorry the row {0} is already marked with an {1}", choice, board[choice - 1]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Console.WriteLine("\n");
                    System.Threading.Thread.Sleep(2000);
                }
                flag = CheckWin(); // calling of check win
            } while (flag != 1 && flag != -1); // This is to check if the game is finished or not
            Console.Clear(); // clearing the console
            Board(); // getting the board again
            if (flag == 1) // if flag value is 1 then some one has win or means who played marked last time which has win
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else // if the value is -1 the game will be draw and no one is winner
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        private static void Board() // Board method which creats board
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin() // checking of winner
        {
            #region Horzontal Winning Condtion
            // Winning Condition For First Row
            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }
            // Winning Condition For Second Row
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }
            // Winning Condition For Third Row
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condtion
            // Winning Condition For First Column
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }
            // Winning Condition For Second Column
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            // Winning Condition For Third Column
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}
```

_You can copy and paste this code into a new C# console application project in your preferred development environment to run and play the game._

## How do LLMs work?

The latest LLMs are based on the _transformer_ architecture built on techniques that have proven successful in modeling _vocabularies_ to support NLP. Transformer models are trained with large data sets of text; this enables them to recognize semantic relationships between words and use those relationships to determine probable sequences of text that will make sense to a human reader. The larger a transformer model's vocabulary, the more difficult it is to distinguish its output from a human's.

Transformer model architecture consists of two components, or _blocks_:

- An _encoder_ block that creates semantic representations of the training vocabulary
- A _decoder_ block that generates new language sequences

The specific implementations of this architecture may vary. Some models may only use the encoder block, such as the Bidirectional Encoder Representations from Transformers (BERT) model developed by Google to support their search engine. Other models may only use the decoder block, like the Generative Pre-trained Transformer (GPT) model developed by OpenAI.

When training a transformer model the training text is first broken down into tokens. These tokens each identify a unique text value. A token may be an distinct word, but can also be a partial word or combination of words and punctuation. Each token is then assigned an ID, which enables the text to be represented as a sequence of token IDs.

After the text has been broken down into tokens, a contextual vector, known as an _embedding_, is assigned to each token. These embedding vectors are multi-valued numeric data where each element of a token's vector represents a semantic attribute of the token. The elements of a token's vector are determined based on how commonly words are used together or in similar contexts.

The goal is to predict the vector for the next token in the sequence based on the preceding tokens. A weight is assigned to each token in the sequence so far that represents their relative influence on the next token. A calculation is then performed on these weighted vectors that produces an _attention score_ that can be used to calculate a possible vector for the next token.

In practice, a technique called multi-head attention uses different elements of the embedding vectors to calculate multiple attention scores. A neural network is then used to evaluate all possible tokens to determine the most probable token with which to continue the sequence. The process continues iteratively for each token in the sequence, with the output sequence so far being used regressively as the input for the next iteration, building the output one token at a time.

During training the complete sequence of tokens is known, but all tokens that come after the one currently being considered are ignored. The predicted value for the next token's vector is compared to the actual value and the loss is calculated. The weights are then incrementally adjusted to reduce the loss and improve the model.

## Potential uses of LLMs

LLMs can be used to perform a variety of NLP tasks, including:

- Determining the sentiment and classifying text
- Summarizing large blocks of text into the most important details
- Comparing multiple texts to detect potential plagiarism
- Rephrasing text meant for one audience to better suit another

## Related content

<!-- TODO: Update these links once we have the file names -->

- [Understanding Token](understanding-tokens.md)
- [Prompt engineering](prompt-engineering.md)
