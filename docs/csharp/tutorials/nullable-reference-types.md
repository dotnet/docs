---
title: Design with nullable reference types
description: This advanced tutorial provides an introduction to nullable reference types. You'll learn to express your design intent on when reference values may be null, and have the compiler enforce when they cannot be null.
ms.date: 11/30/2018
---
# Tutorial: Express your design intent more clearly with nullable and non-nullable reference types

C# 8 introduces **nullable reference types**, which complement reference types the same way nullable value types complement value types. You declare a variable to be a **nullable reference type** by appending a `?` to the type. For example, `string?` represents a nullable `string`. You can use these new types to more clearly express your design intent: some variables *must always have a value*, others *may be missing a value*.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Incorporate nullable and non-nullable reference types into your designs
> * Enable nullable reference type checks throughout your code.
> * Write code where the compiler enforces those design decisions.
> * Use the nullable reference feature in your own designs

## Prerequisites

You’ll need to setup your machine to run .NET Core, including the C# 8 beta compiler.  The C# 8 beta compiler is available with Visual Studio 2019 preview 1, or .NET Core 3.0 preview 1.

This tutorial assumes you are familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Incorporate nullable reference types into your designs

In this tutorial, you'll build a library that models running a survey. The code uses both nullable reference types and non-nullable reference types to represent the real world concepts. For example, the survey questions would never be null. However, a respondent might prefer not to answer an optional question. The responses might be null in this example.

The code you'll write for this sample expresses that intent, and the compiler enforces that intent.

## Create the application and enable nullable reference types

Create a new console application, either in Visual Studio or from the command line using `dotnet new console`. Name the application `NullableIntroduction`. Once you've created the application, you'll need to enable C# 8 beta features. Open the `csproj` file, and add a `LangVersion` element to the `PropertyGroup` element:

```xml
<LangVersion>8.0</LangVersion>
```

Alternatively, you can use the Visual Studio project properties to enable C# 8. Right click on the project node, select **Properties**. Then, select the **build** tab, and click **Advanced...**. In the dropdown for language version, select **C# 8.0 (beta)**.

You must opt into the **nullable reference types** feature, even in C# 8 projects. That's because once the feature is turned on, existing reference variable declarations become **non-nullable reference types**. While that decision will help find issues where existing code may not have proper null-checks, it may not accurately reflect your original design intent. You turn on the feature with a new pragma:

```csharp
#nullable enable
```

You can add the preceding pragma anywhere in a source file, and the nullable reference type feature is turned on from that point. The pragma also supports the `disable` argument to turn off the feature.

> [!NOTE]
> Future previews will build on the `#nullable` pragma to control the feature at a project level. In preview 1, you'll need to add this pragma to every source file.

### Design the types for the application

This survey application requires creating a number of classes:

- A class that models the list of questions.
- A class that models a list of people contacted for the survey.
- A class that models the answers from a person that took the survey.

These types will make use of both nullable and non-nullable reference types to express which members are required, and which members are optional. Nullable reference types communicates that design intent clearly:

- The questions that are part of the survey can never be null: It makes no sense to ask a blank question.
- The respondents can never be null. You'll want to track people you contacted, even those that declined to participate.
- Any response to a question may be null. Respondents can decline to answer some, or all questions.

If you've programmed in C#, you may be so accustomed to reference types allowing null values that you may have missed other opportunities to declare non-nullable instances:

- The collection of questions should be non-nullable.
- The collection of respondents should be non-nullable.

As you write the code, you'll see that selecting a non-nullable reference type as the default for references avoids common mistakes that could lead to null reference exceptions. This tutorial points out where you may have made a default decision in your C# coding.

The app you'll build will do the following steps:

1. Create a survey and add questions to it.
1. Create a pseudo-random set of respondents for the survey
1. Contact respondents until the completed survey size reaches the goal number.
1. Write out imprtant statistics on the survey responses.

## Build the survey with nullable and non-nullable types

The first code you'll write creates the survey. You'll write classes to model a survey question and a survey run. Your survey has three types of questions, distinguished by the format of the answer: Yes/No answers, number answers, and text answers. Create a `public` `SurveyQuestion` class. Include the `nullable enable` pragma immediately after the `using` statements:

```csharp
#nullable enable
namespace NullableIntroduction
{
    public class SurveyQuestion
    {
    }
}
```

Adding the `#nullable enable` pragma means the compiler interprets every reference type variable declaration as a **non-nullable** reference type. You can see your first warning by adding properties for the question text and the type of question, as shown in the following code:

```csharp
#nullable enable
namespace NullableIntroduction
{
    public enum QuestionType
    {
        YesNo,
        Number,
        Text
    }

    public class SurveyQuestion
    {
        public string QuestionText { get; }
        public QuestionType TypeOfQuestion { get; }
    }
}
```

Because you haven't initialized `QuestionText`, the compiler issues a warning that a non-nullable property has not been initialized. Your design requires the question text to be non-null, so you add a constructor to initialize it and the `QuestionType` value as well. The finished class definition looks like the following code:

```csharp
#nullable enable
namespace NullableIntroduction
{
    public enum QuestionType
    {
        YesNo,
        Number,
        Text
    }

    public class SurveyQuestion
    {
        public string QuestionText { get; }
        public QuestionType TypeOfQuestion { get; }

        public SurveyQuestion(QuestionType typeOfQuestion, string text) =>
            (TypeOfQuestion, QuestionText) = (typeOfQuestion, text);
    }
}
```

Adding the constructor removes the warning. The constructor argument is also a non-nullable reference type, so the compiler does not issue any warnings.

Next, create a `public` class named `SurveyRun`. Include the `nullable enable` pragma following the `using` statements. This class contains a list of `SurveyQuestion` objects and methods to add questions to the survey, as shown in the following code:

```csharp
using System.Collections.Generic;

#nullable enable
namespace NullableIntroduction
{
    public class SurveyRun
    {
        private List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();

       public void AddQuestion(QuestionType type, string question) =>
            AddQuestion(new SurveyQuestion(type, question));
        public void AddQuestion(SurveyQuestion surveyQuestion) => surveyQuestions.Add(surveyQuestion);
    }
}
```

As before, you must initialize the list object to a non-null value or the compiler issues a warning. There's no null checks in the second overload of `AddQuestion` because it's not needed: You've declared that variable to be non-nullable. Its value can't be `null`.

Switch to `program.cs` in your editor, and replace the contents of `Main` with the following lines of code:

```csharp
var surveyRun = new SurveyRun();
surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
surveyRun.AddQuestion(QuestionType.Text, default);
```

Without the `#nullable enable` pragma at the top of the file, the compiler doesn't issue a warning when you pass `null` as the text for the `AddQuestion` argument. Fix that by adding `#nullable enable` following the `using` statement. Now, that last line generates a warning. Remove that line because it can cause bugs later.

## Create respondents and get answers to the survey

Next, write the code that generates answers to the survey. This involves several small tasks:

1. Build a method that generates respondent objects. These represent people asked to fill out the survey.
1. Build logic to simulate asking the questions to a respondent, collecting answers or noting that a respondent did not answer.
1. Repeat until enough respondents have answered the survey.

You'll need a class to represent a survey response, so add that now. Enable nullable support. Add an Id field and a constructor that initializes the ID field, as shown in the following code:

```csharp
#nullable enable
namespace NullableIntroduction
{
    public class SurveyResponse
    {
        public int Id { get; }

        public SurveyResponse(int id) => Id = id;
    }
}
```

Next, add a `static` method to create new participants by generating a random id:

```csharp
private static Random idGenerator = new Random();
public static SurveyResponse GetRandomId() => new SurveyResponse(idGenerator.Next());
```

The main responsibility of this this class is to generate the responses for a participant to the questions in the survey. This responsibility has a few steps:

1. Ask for participation in the survey. If the person doesn't consent, return a missing (or null) response.
1. Ask each question and record the answer. Each answer may also be missing (or null).

Add the following code to your `SurveyRespondent` class:

```csharp
private Dictionary<int, string>? surveyResponses;
public void AnswerSurvey(IEnumerable<SurveyQuestion> questions)
{
    if (ConsentToSurvey())
    {
        surveyResponses = new Dictionary<int, string>();
        int index = 0;
        foreach (var question in questions)
        {
            var answer = GenerateAnswer(question);
            if (answer != null)
            {
                surveyResponses.Add(index, answer);
            }
            index++;
        }
    }
}

private bool ConsentToSurvey() => randomGenerator.Next(0, 2) == 1;

private string? GenerateAnswer(SurveyQuestion question)
{
    switch (question.TypeOfQuestion)
    {
        case QuestionType.YesNo:
            int n = randomGenerator.Next(-1, 2);
            return (n == -1) ? default : (n == 0) ? "No" : "Yes";
        case QuestionType.Number:
            n = randomGenerator.Next(-30, 101);
            return (n < 0) ? default : n.ToString();
        case QuestionType.Text:
        default:
            switch (randomGenerator.Next(0, 5))
            {
                case 0:
                    return default;
                case 1:
                    return "Red";
                case 2:
                    return "Green";
                case 3:
                    return "Blue";
            }
            return "Red. No, Green. Wait.. Blue... AAARGGGGGHHH!";
    }
}
```

The storage for the survey answers is a `Dictionary<int, string>?`, indicating that it may be null. You're using the new language feature to declare your design intent, both to the compiler and to anyone reading your code later. If you ever dereference `surveyResponses` without checking for the null value first, you'll get a compiler warning. You don't get a warning in the `AnswerSurvey` method because the compiler can determine the `surveyResponses` variable was set to a non-null value above.

Next, you need to write the `PerformSurvey` method in the `SurveyRun` class. Add the following code in the `SurveyRun` class:

```csharp
private List<SurveyResponse>? respondents;
public void PerformSurvey(int numberOfRespondents)
{
    int respondentsConsenting = 0;
    respondents = new List<SurveyResponse>();
    while (respondentsConsenting < numberOfRespondents)
    {
        var respondent = SurveyResponse.GetRandomId();
        if (respondent.AnswerSurvey(surveyQuestions))
            respondentsConsenting++;
        respondents.Add(respondent);
    }
}
```

Here again, your choice of a nullable `List<SurveyResponse>?` indicates that the response may be null. That indicates that the survey has not been given to any respondents yet. Notice that respondents are added until enough have consented.

The last step to run the survey is to add a call to perform the survey at the end of the `Main` method:

```csharp
surveyRun.PerformSurvey(50);
```

## Examine survey responses

The last step is to display survey results. You'll add code to many of the classes you've written. This code demonstrates the value of distinguishing nullable and non-nullable reference types. Start by adding the following two expression bodied members to the `SurveyResponse` class:

```csharp
public bool AnsweredSurvey => surveyResponses != null;
public string Answer(int index) => surveyResponses?.GetValueOrDefault(index) ?? "No answer";
```

Because `surveyResponses` is a non-nullable reference type no checks are necessary before de-referencing it. The `Answer` method returns a non-nullable string, so choose the overload of `GetValueOrDefault` that takes a second argument for the default value.

Next, add these three expression bodied members to the `SurveyRun` class:

```csharp
public IEnumerable<SurveyResponse> AllParticipants => (respondents ?? Enumerable.Empty<SurveyResponse>());
public ICollection<SurveyQuestion> Questions => surveyQuestions;
public SurveyQuestion GetQuestion(int index) => surveyQuestions[index];
```

The `AllParticipants` member must take into account that the `respondents` variable might be null, but the return value can't be null. If you change that expression by removing the `??` and the empty sequence that follows, the compiler warns you that the method might return `null` and its return signature returns a non-nullable type.

Finally, add the following loop at the bottom of the `Main` method:

```csharp
foreach (var participant in surveyRun.AllParticipants)
{
    Console.WriteLine($"Participant: {participant.Id}:");
    if (participant.AnsweredSurvey)
    {
        for (int i = 0; i < surveyRun.Questions.Count; i++)
        {
            string answer = participant.Answer(i);
            Console.WriteLine($"\t{surveyRun.GetQuestion(i)} : {answer}");
        }
    }
    else
        Console.WriteLine("\tNo responses");
}
```

You don't need any `null` checks in this code because you've designed the underlying interfaces so that they all return non-nullable reference types.

## Get the code

You can get the code for the finished tutorial from our [samples](https://github.com/dotnet/samples) repository int the [csharp/IntroToNullables](https://github.com/dotnet/samples/tree/master/csharp/IntroToNullables) folder.

Experiment by changing the type declarations between nullable and non-nullable reference types. See how that generates different warnings to ensure you don't accidentally de-reference a `null`.

## Next steps

Learn more by reading an overview of nullable reference types...
> [!div class="nextstepaction"]
> [Next steps button](../programming-guide/nullable-references.md)
