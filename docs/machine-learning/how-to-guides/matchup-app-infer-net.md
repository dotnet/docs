---
title: Create a game match up list app with Infer.NET and probabilistic programming
description: Discover how to use probabilistic programming with Infer.NET to create a game matchup list app based on a simplified version of TrueSkill.
ms.date: 05/06/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use probabilistic programming with Infer.NET to create a game matchup list app based on a simplified version of TrueSkill.
---

# Create a game match up list app with Infer.NET and probabilistic programming

This how-to guide teaches you about probabilistic programming using Infer.NET. Probabilistic programming is a machine learning approach where custom models are expressed as computer programs. It allows for incorporating domain knowledge in the models and makes the machine learning system more interpretable. It also supports online inference – the process of learning as new data arrives. Infer.NET is used in various products at Microsoft in Azure, Xbox, and Bing.

## What is probabilistic programming?

Probabilistic programming allows you to create statistical models of real-world processes.

## Prerequisites

- Local development environment setup

  This how-to guide expects you to have a machine you can use for development. The .NET tutorial [Hello World in 10 minutes](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) has instructions for setting up your local development environment on macOS, Windows, or Linux.

## Create your app

1. Open a new command prompt and run the following commands:

```dotnetcli
dotnet new console -o myApp
cd myApp
```

The `dotnet` command creates a `new` application of type `console`. The `-o` parameter creates a directory named `myApp` where your app is stored and populates it with the required files. The `cd myApp` command puts you into the newly created app directory.

## Install Infer.NET package

To use Infer.NET, you need to install the `Microsoft.ML.Probabilistic.Compiler` package. In your command prompt, run the following command:

```dotnetcli
dotnet add package Microsoft.ML.Probabilistic.Compiler
```

## Design your model

The example sample uses table tennis or foosball matches played in the office. You have the participants and outcome of each match.  You want to infer the player's skills from this data. Assume that each player has a normally distributed latent skill and their given match performance is a noisy version of this skill. The data constrains the winner’s performance to be greater than the loser’s performance. This is a simplified version of the popular [TrueSkill](https://www.microsoft.com/research/project/trueskill-ranking-system/) model, which also supports teams, draws, and other extensions. An [advanced version](https://www.microsoft.com/research/publication/trueskill-2-improved-bayesian-skill-rating-system/) of this model is used for matchmaking in the best-selling game titles Halo and Gears of War.

You need to list the inferred player skills, alongside with their variance – the measure of uncertainty around the skills.

*Game result sample data*

Game |Winner | Loser
---------|----------|---------
 1 | Player 0 | Player 1
 2 | Player 0 | Player 3
 3 | Player 0 | Player 4
 4 | Player 1 | Player 2
 5 | Player 3 | Player 1
 6 | Player 4 | Player 2

With a closer look at the sample data, you’ll notice that players 3 and 4 both have one win and one loss. Let's see what the rankings look like using probabilistic programming. Notice also there is a player zero because even office match up lists are zero based to us developers.

## Write some code

Having designed the model, it’s time to express it as a probabilistic program using the Infer.NET modeling API. Open `Program.cs` in your favorite text editor and replace all of its contents with the following code:

```csharp
namespace myApp

{
    using System;
    using System.Linq;
    using Microsoft.ML.Probabilistic;
    using Microsoft.ML.Probabilistic.Distributions;
    using Microsoft.ML.Probabilistic.Models;

    class Program
    {

        static void Main(string[] args)
        {
            // The winner and loser in each of 6 samples games
            var winnerData = new[] { 0, 0, 0, 1, 3, 4 };
            var loserData = new[] { 1, 3, 4, 2, 1, 2 };

            // Define the statistical model as a probabilistic program
            var game = new Range(winnerData.Length);
            var player = new Range(winnerData.Concat(loserData).Max() + 1);
            var playerSkills = Variable.Array<double>(player);
            playerSkills[player] = Variable.GaussianFromMeanAndVariance(6, 9).ForEach(player);

            var winners = Variable.Array<int>(game);
            var losers = Variable.Array<int>(game);

            using (Variable.ForEach(game))
            {
                // The player performance is a noisy version of their skill
                var winnerPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[winners[game]], 1.0);
                var loserPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[losers[game]], 1.0);

                // The winner performed better in this game
                Variable.ConstrainTrue(winnerPerformance > loserPerformance);
            }

            // Attach the data to the model
            winners.ObservedValue = winnerData;
            losers.ObservedValue = loserData;

            // Run inference
            var inferenceEngine = new InferenceEngine();
            var inferredSkills = inferenceEngine.Infer<Gaussian[]>(playerSkills);

            // The inferred skills are uncertain, which is captured in their variance
            var orderedPlayerSkills = inferredSkills
               .Select((s, i) => new { Player = i, Skill = s })
               .OrderByDescending(ps => ps.Skill.GetMean());

            foreach (var playerSkill in orderedPlayerSkills)
            {
                Console.WriteLine($"Player {playerSkill.Player} skill: {playerSkill.Skill}");
            }
        }
    }
}
```

## Run your app

In your command prompt, run the following command:

```dotnetcli
dotnet run
```

## Results

Your results should be similar to the following:

```console
Compiling model...done.
Iterating:
.........|.........|.........|.........|.........| 50
Player 0 skill: Gaussian(9.517, 3.926)
Player 3 skill: Gaussian(6.834, 3.892)
Player 4 skill: Gaussian(6.054, 4.731)
Player 1 skill: Gaussian(4.955, 3.503)
Player 2 skill: Gaussian(2.639, 4.288)
```

In the results, notice that player 3 ranks slightly higher than player 4 according to our model. That’s because the victory of player 3 over player 1 is more significant than the victory of player 4 over player 2 – note that player 1 beats player 2. Player 0 is the overall champ!

## Keep learning

Designing statistical models is a skill on its own. The Microsoft Research Cambridge team has written a [free online book](http://mbmlbook.com/), which gives a gentle introduction to the article. Chapter 3 of this book covers the TrueSkill model in more detail. Once you have a model in mind, you can transform it into code using the [extensive documentation](https://dotnet.github.io/infer/) on the Infer.NET website.

## Next steps

Check out the Infer.NET GitHub repository to continue learning and find more samples.
> [!div class="nextstepaction"]
> [dotnet/infer GitHub repository](https://github.com/dotnet/infer)
