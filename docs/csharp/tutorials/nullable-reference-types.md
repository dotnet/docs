---
title: Design with nullable reference types
description: This advanced tutorial provides an introduction to nullable reference types. You'll learn to express your design intent on when reference values may be null, and have the compiler enforce when they cannot be null.
ms.date: 12/03/2018
ms.custom: mvc
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

You’ll need to set up your machine to run .NET Core, including the C# 8.0 beta compiler. The C# 8 beta compiler is available with [Visual Studio 2019 preview 1](https://visualstudio.microsoft.com/vs/preview/), or [.NET Core 3.0 preview 1](https://dotnet.microsoft.com/download/dotnet-core/3.0).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Incorporate nullable reference types into your designs

In this tutorial, you'll build a library that models running a survey. The code uses both nullable reference types and non-nullable reference types to represent the real-world concepts. The survey questions can never be null. A respondent might prefer not to answer a question. The responses might be null in this case.

The code you'll write for this sample expresses that intent, and the compiler enforces that intent.

## Create the application and enable nullable reference types

Create a new console application either in Visual Studio or from the command line using `dotnet new console`. Name the application `NullableIntroduction`. Once you've created the application, you'll need to enable C# 8 beta features. Open the `csproj` file, and add a `LangVersion` element to the `PropertyGroup` element:

```xml
<LangVersion>8.0</LangVersion>
```

Alternatively, you can use the Visual Studio project properties to enable C# 8. In Solution Explorer, right click on the project node, select **Properties**. Then, select the **build** tab, and click **Advanced...**. In the dropdown for language version, select **C# 8.0 (beta)**.

You must opt into the **nullable reference types** feature, even in C# 8 projects. That's because once the feature is turned on, existing reference variable declarations become **non-nullable reference types**. While that decision will help find issues where existing code may not have proper null-checks, it may not accurately reflect your original design intent. You turn on the feature with a new pragma:

```csharp
#nullable enable
```

You can add the preceding pragma anywhere in a source file, and the nullable reference type feature is turned on from that point. The pragma also supports the `disable` argument to turn off the feature.

You can also turn on **nullable reference types** for an entire project by adding the following element to your .csproj file, for example, immediately following the `LangVersion` element that enabled C# 8.0:

```xml
<NullableReferenceTypes>true</NullableReferenceTypes>
```

### Design the types for the application

This survey application requires creating a number of classes:

- A class that models the list of questions.
- A class that models a list of people contacted for the survey.
- A class that models the answers from a person that took the survey.

These types will make use of both nullable and non-nullable reference types to express which members are required and which members are optional. Nullable reference types communicate that design intent clearly:

- The questions that are part of the survey can never be null: It makes no sense to ask an empty question.
- The respondents can never be null. You'll want to track people you contacted, even respondents that declined to participate.
- Any response to a question may be null. Respondents can decline to answer some or all questions.

If you've programmed in C#, you may be so accustomed to reference types that allow null values that you may have missed other opportunities to declare non-nullable instances:

- The collection of questions should be non-nullable.
- The collection of respondents should be non-nullable.

As you write the code, you'll see that a non-nullable reference type as the default for references avoids common mistakes that could lead to null reference exceptions. One lesson from this tutorial is that you made decisions about which variables could or could not be null. The language didn't provide syntax to express those decisions. Now it does.

The app you'll build will do the following steps:

1. Create a survey and add questions to it.
1. Create a pseudo-random set of respondents for the survey.
1. Contact respondents until the completed survey size reaches the goal number.
1. Write out important statistics on the survey responses.

## Build the survey with nullable and non-nullable types

The first code you'll write creates the survey. You'll write classes to model a survey question and a survey run. Your survey has three types of questions, distinguished by the format of the answer: Yes/No answers, number answers, and text answers. Create a `public` `SurveyQuestion` class. Include the `#nullable enable` pragma immediately after the `using` statements:

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

Because you haven't initialized `QuestionText`, the compiler issues a warning that a non-nullable property hasn't been initialized. Your design requires the question text to be non-null, so you add a constructor to initialize it and the `QuestionType` value as well. The finished class definition looks like the following code:

[!code-csharp[DefineQuestion](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyQuestion.cs)]

Adding the constructor removes the warning. The constructor argument is also a non-nullable reference type, so the compiler doesn't issue any warnings.

Next, create a `public` class named `SurveyRun`. Include the `#nullable enable` pragma following the `using` statements. This class contains a list of `SurveyQuestion` objects and methods to add questions to the survey, as shown in the following code:

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

As before, you must initialize the list object to a non-null value or the compiler issues a warning. There are no null checks in the second overload of `AddQuestion` because they aren't needed: You've declared that variable to be non-nullable. Its value can't be `null`.

Switch to `Program.cs` in your editor and replace the contents of `Main` with the following lines of code:

[!code-csharp[AddQuestions](../../../samples/csharp/NullableIntroduction/NullableIntroduction/Program.cs#AddQuestions)]

Without the `#nullable enable` pragma at the top of the file, the compiler doesn't issue a warning when you pass `null` as the text for the `AddQuestion` argument. Fix that by adding `#nullable enable` following the `using` statement. Try it by adding the following line to `Main`:

```csharp
surveyRun.AddQuestion(QuestionType.Text, default);
```

## Create respondents and get answers to the survey

Next, write the code that generates answers to the survey. This involves several small tasks:

1. Build a method that generates respondent objects. These represent people asked to fill out the survey.
1. Build logic to simulate asking the questions to a respondent and collecting answers or noting that a respondent didn't answer.
1. Repeat until enough respondents have answered the survey.

You'll need a class to represent a survey response, so add that now. Enable nullable support. Add an `Id` property and a constructor that initializes it, as shown in the following code:

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

Next, add a `static` method to create new participants by generating a random ID:

[!code-csharp[GenerateRespondents](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyResponse.cs#Random)]

The main responsibility of this class is to generate the responses for a participant to the questions in the survey. This responsibility has a few steps:

1. Ask for participation in the survey. If the person doesn't consent, return a missing (or null) response.
1. Ask each question and record the answer. Each answer may also be missing (or null).

Add the following code to your `SurveyRespondent` class:

[!code-csharp[AnswerSurvey](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyResponse.cs#AnswerSurvey)]

The storage for the survey answers is a `Dictionary<int, string>?`, indicating that it may be null. You're using the new language feature to declare your design intent, both to the compiler and to anyone reading your code later. If you ever dereference `surveyResponses` without checking for the null value first, you'll get a compiler warning. You don't get a warning in the `AnswerSurvey` method because the compiler can determine the `surveyResponses` variable was set to a non-null value above.

Next, you need to write the `PerformSurvey` method in the `SurveyRun` class. Add the following code in the `SurveyRun` class:

[!code-csharp[PerformSurvey](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyRun.cs#PerformSurvey)]

Here again, your choice of a nullable `List<SurveyResponse>?` indicates the response may be null. That indicates the survey hasn't been given to any respondents yet. Notice that respondents are added until enough have consented.

The last step to run the survey is to add a call to perform the survey at the end of the `Main` method:

[!code-csharp[RunSurvey](../../../samples/csharp/NullableIntroduction/NullableIntroduction/Program.cs#RunSurvey)]

## Examine survey responses

The last step is to display survey results. You'll add code to many of the classes you've written. This code demonstrates the value of distinguishing nullable and non-nullable reference types. Start by adding the following two expression-bodied members to the `SurveyResponse` class:

[!code-csharp[ReportResponses](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyResponse.cs#SurveyStatus)]

Because `surveyResponses` is a non-nullable reference, type no checks are necessary before de-referencing it. The `Answer` method returns a non-nullable string, so choose the overload of `GetValueOrDefault` that takes a second argument for the default value.

Next, add these three expression-bodied members to the `SurveyRun` class:

[!code-csharp[ReportResults](../../../samples/csharp/NullableIntroduction/NullableIntroduction/SurveyRun.cs#RunReport)]

The `AllParticipants` member must take into account that the `respondents` variable might be null, but the return value can't be null. If you change that expression by removing the `??` and the empty sequence that follows, the compiler warns you the method might return `null` and its return signature returns a non-nullable type.

Finally, add the following loop at the bottom of the `Main` method:

[!code-csharp[DisplaySurveyResults](../../../samples/csharp/NullableIntroduction/NullableIntroduction/Program.cs#WriteAnswers)]

You don't need any `null` checks in this code because you've designed the underlying interfaces so that they all return non-nullable reference types.

## Get the code

You can get the code for the finished tutorial from our [samples](https://github.com/dotnet/samples) repository in the [csharp/IntroToNullables](https://github.com/dotnet/samples/tree/master/csharp/NullableIntroduction) folder.

Experiment by changing the type declarations between nullable and non-nullable reference types. See how that generates different warnings to ensure you don't accidentally dereference a `null`.

## Next steps

Learn more by reading an overview of nullable reference types..
> [!div class="nextstepaction"]
> [An overview of nullable references](../nullable-references.md)
