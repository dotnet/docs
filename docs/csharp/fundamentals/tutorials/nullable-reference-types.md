---
title: "Tutorial: Express your design intent with nullable and non-nullable reference types"
description: Build a small survey app that uses nullable and non-nullable reference types to declare which references can be null and have the compiler enforce that intent.
ms.date: 05/04/2026
ms.topic: tutorial
ms.subservice: null-safety
ai-usage: ai-assisted

#customer intent: As a C# developer, I want to use nullable and non-nullable reference types in a real design so that the compiler catches null-handling mistakes for me.
---
# Tutorial: Express your design intent with nullable and non-nullable reference types

> [!TIP]
> **New to nullable reference types?** Read [Nullable reference types](../null-safety/nullable-reference-types.md) first. This tutorial assumes you understand the difference between non-nullable and nullable reference types and how the compiler tracks null-state.
>
> **Coming from another language?** If you've used Kotlin's nullable types, TypeScript's `strictNullChecks`, or Swift's optionals, the conceptual model maps directly. The exercise here is about *expressing design intent*, not learning the syntax.

In this tutorial, you build a small library that models running a survey. The data has two kinds of "missing" values that nullable reference types let you distinguish:

- A *survey question* must always be present. The list of questions and the text of each question can never be `null`.
- A *response to a question* might be missing. Respondents can decline to answer some or all questions, and the model should make that explicit.

You declare those rules with non-nullable and nullable reference types. The compiler then warns whenever the code's behavior doesn't match the design.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create a console app that has nullable reference types enabled.
> - Build the survey with non-nullable reference types for required values.
> - Generate respondents that use nullable reference types for missing answers.
> - Read the survey results without writing any null checks the compiler hasn't asked for.

## Prerequisites

[!INCLUDE [Prerequisites](../../../../includes/prerequisites-basic.md)]

This tutorial assumes you're familiar with C# and either Visual Studio or the .NET CLI.

## Create the application and enable nullable reference types

Create a new console application named `NullableIntroduction`:

```dotnetcli
dotnet new console -n NullableIntroduction
cd NullableIntroduction
```

Open `NullableIntroduction.csproj` and confirm the `<Nullable>enable</Nullable>` element is set in the `PropertyGroup`. Templates from .NET 6 onward include it by default; add it manually if it's missing:

:::code language="xml" source="snippets/NullableIntroduction/NullableIntroduction.csproj":::

With the feature enabled, every reference type variable is non-nullable unless you append `?`. The compiler issues warnings when your code's null-handling doesn't match those declarations.

## Design the survey types

Three classes model the survey:

- `SurveyQuestion` — one question. The text and question type are required.
- `SurveyRun` — the collection of questions plus the list of respondents.
- `SurveyResponse` — one respondent's answers, which might be missing.

Each type uses non-nullable reference types for required values and nullable reference types where missing values are part of the design.

## Build the survey questions

Replace the contents of `SurveyQuestion.cs` with the following code. The text and the question type are non-nullable, so the compiler requires the constructor to initialize both:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyQuestion.cs":::

The constructor parameters are non-nullable reference types, so the compiler warns the caller if either argument might be `null`.

Next, add a `SurveyRun` class to hold the list of questions:

```csharp
namespace NullableIntroduction;

public class SurveyRun
{
    private List<SurveyQuestion> surveyQuestions = new();

    public void AddQuestion(QuestionType type, string question) =>
        AddQuestion(new SurveyQuestion(type, question));

    public void AddQuestion(SurveyQuestion surveyQuestion) =>
        surveyQuestions.Add(surveyQuestion);
}
```

The `surveyQuestions` field is a non-nullable `List<SurveyQuestion>`. Initializing it at the declaration satisfies the non-nullable contract. Both `AddQuestion` overloads accept non-nullable parameters, so the compiler enforces that callers don't pass `null`.

In `Program.cs`, create a `SurveyRun` and add three questions:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="AddQuestions":::

To see how the compiler enforces non-nullable parameters, try adding the following line and rebuilding:

```csharp
surveyRun.AddQuestion(QuestionType.Text, default);
```

The compiler issues warning *CS8625* because `default` evaluates to `null` for a reference type, and `AddQuestion` expects a non-nullable `string`. Remove the line before continuing.

## Create respondents and capture answers

A respondent's answers are different from a survey's questions: any individual answer might be missing, and a respondent might decline to participate at all. Both are valid states, and both are expressed with `null`.

Add a `SurveyResponse` class. Start with the always-required `Id` property and a constructor that initializes it:

```csharp
namespace NullableIntroduction;

public class SurveyResponse
{
    public int Id { get; }

    public SurveyResponse(int id) => Id = id;
}
```

Add a static factory method that creates respondents with a random ID:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="Random":::

Next, add the method that asks the survey to a respondent. Store the answers in a nullable dictionary so the type itself communicates that the respondent might decline:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="AnswerSurvey":::

The `surveyResponses` field is `Dictionary<int, string>?`. Anywhere the field is dereferenced without first checking against `null`, the compiler issues a warning. Inside `AnswerSurvey`, the compiler tracks that `surveyResponses` is *not-null* immediately after the `new` expression, so the loop body needs no extra check.

Add a method on `SurveyRun` that builds up a list of respondents until enough consent to participate:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyRun.cs" id="PerformSurvey":::

The `respondents` field is `List<SurveyResponse>?`—it's `null` until the survey runs.

Call `PerformSurvey` from `Main`:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="RunSurvey":::

## Examine the survey results

To report results, expose a few helpers from `SurveyResponse` and `SurveyRun`. On `SurveyResponse`, add expression-bodied members that handle the nullable dictionary:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="SurveyStatus":::

`AnsweredSurvey` checks the field against `null`. `Answer` uses the `?.` operator to dereference safely and the `??` operator to substitute a non-null fallback. The method's return type is non-nullable `string`, so callers don't need null checks.

On `SurveyRun`, add expression-bodied members that expose the list of participants and questions:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyRun.cs" id="RunReport":::

`AllParticipants` returns a non-nullable sequence even though `respondents` might be `null`. The `??` operator substitutes `Enumerable.Empty<SurveyResponse>()` when the field hasn't been populated yet. If you remove the `??` clause, the compiler warns that the method might return `null` despite a non-nullable return type.

Finally, write the report at the bottom of `Main`:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="WriteAnswers":::

Notice that no null check is needed for `participant`, `surveyRun.Questions`, or `surveyRun.GetQuestion(i)`. The types declare those values as non-nullable, so the compiler treats them as *not-null* throughout the loop.

Run the application:

```dotnetcli
dotnet run
```

The output is different on each run because respondents are generated randomly, but every line either reports a participant's answers or notes that they declined.

## Get the code

The finished sample is in the [csharp/NullableIntroduction](https://github.com/dotnet/samples/tree/main/csharp/NullableIntroduction) folder of the [dotnet/samples](https://github.com/dotnet/samples) repository.

Experiment by changing types between nullable and non-nullable. Removing a `?` where the design allows missing values produces compiler warnings that point to every place the missing value matters.

## Related content

- [Nullable reference types](../null-safety/nullable-reference-types.md)
- [Resolve nullable warnings](../null-safety/resolve-warnings.md)
- [Nullable migration strategies](../null-safety/migration-strategies.md)
- [Working with nullable reference types in EF Core](/ef/core/miscellaneous/nullable-reference-types)
