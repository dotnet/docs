---
title: "Tutorial: Express your design intent with nullable and non-nullable reference types"
description: Build a small survey app that uses nullable and non-nullable reference types to declare which references can be null and have the compiler enforce that intent.
ms.date: 05/04/2026
ms.topic: tutorial
ms.subservice: nullable-reference-types
ai-usage: ai-assisted

#customer intent: As a C# developer, I want to use nullable and non-nullable reference types in a real design so that the compiler catches null-handling mistakes for me.
---
# Tutorial: Express your design intent with nullable and non-nullable reference types

> [!TIP]
> **New to nullable reference types?** Read [Nullable reference types](../null-safety/nullable-reference-types.md) first. This tutorial assumes you understand the difference between non-nullable and nullable reference types and how the compiler tracks null-state.
>
> **Coming from another language?** If you've used Kotlin's nullable types, TypeScript's `strictNullChecks`, or Swift's optionals, the conceptual model maps directly. The exercise here is about *expressing design intent*, not learning the syntax.

In this tutorial, you build a small library that models running a survey. The data has two distinct patterns that nullable reference types let you distinguish:

- A *survey question* must always be present. The list of questions and the text of each question can never be `null`.
- A *response to a question* might be missing. Respondents can decline to answer some or all questions, and the model should make that explicit.

You declare those rules with non-nullable and nullable reference types. The compiler then warns whenever the code's behavior doesn't match the design.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create the application.
> - Build the survey questions.
> - Build a survey of questions.
> - Test the not-null requirement.
> - Build response types.
> - Create respondents.
> - Generate one survey response.
> - Build a set of survey responses.
> - Examine the survey results.

Three classes model the survey:

- `SurveyQuestion`: one question. The text and question type are required.
- `SurveyRun`: the collection of questions plus the list of respondents.
- `SurveyResponse`: one respondent's answers, which might be missing.

Each type uses non-nullable reference types for required values and nullable reference types for missing values.

## Prerequisites

[!INCLUDE [Prerequisites](../../../../includes/prerequisites-basic.md)]

This tutorial assumes you're familiar with C# and either Visual Studio or the .NET CLI.

## Create the application and enable nullable reference types

Create a new console application named `NullableIntroduction`:

```dotnetcli
dotnet new console -n NullableIntroduction
cd NullableIntroduction
```

## Build the survey questions

Add a new file named `SurveyQuestion.cs` to the project, and replace its contents with the following code. The text and the question type are non-nullable, so the constructor must initialize both:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyQuestion.cs":::

The constructor parameters are non-nullable reference types, so the compiler warns the caller if either argument might be `null`.

## Build a survey of questions

Next, add a new file named `SurveyRun.cs` to the project and define a `SurveyRun` class to hold the list of questions:

```csharp
namespace NullableIntroduction;

public class SurveyRun
{
    private List<SurveyQuestion> surveyQuestions = [];

    public void AddQuestion(QuestionType type, string question) =>
        AddQuestion(new SurveyQuestion(type, question));

    public void AddQuestion(SurveyQuestion surveyQuestion) =>
        surveyQuestions.Add(surveyQuestion);
}
```

The `surveyQuestions` field is a non-nullable `List<SurveyQuestion>`. It uses a [collection expression](../../language-reference/operators/collection-expressions.md) to initialize an empty list. Both `AddQuestion` overloads accept non-nullable parameters, so the compiler enforces that callers don't pass `null`.

In `Program.cs`, create a `SurveyRun` and add three questions:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="SnippetAddQuestions":::

## Test the not-null requirement

To see how the compiler enforces non-nullable parameters, try adding the following line and rebuilding:

```csharp
surveyRun.AddQuestion(QuestionType.Text, default);
```

The compiler issues warning *CS8625* because `default` evaluates to `null` for a reference type, and `AddQuestion` expects a non-nullable `string`. Remove the line before continuing.

## Build response types

Respondents can decline to take the survey, and even when they participate, they can skip individual questions. Both forms of "missing" are valid outcomes, and the type system should make them visible. You express both forms with `null`.

Add a new file named `SurveyResponse.cs` to the project and define a `SurveyResponse` class. Use a [primary constructor](../../whats-new/tutorials/primary-constructors.md) (parameters declared on the type itself, available throughout the body) to capture the always-required `Id`:

```csharp
namespace NullableIntroduction;

public class SurveyResponse(int id)
{
    public int Id { get; } = id;
}
```

## Create respondents

Add a *static factory method* (a `static` method that creates and returns a new instance of the type, an alternative to calling the constructor directly) that creates respondents with a random ID:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="SnippetRandom":::

## Generate one survey response

Next, add the method that asks the survey to a respondent. Store the answers in a nullable dictionary so the type itself communicates that the respondent might decline:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="SnippetAnswerSurvey":::

The `surveyResponses` field is `Dictionary<int, string>?`. If you dereference the field without first checking for `null`, the compiler issues a warning. Inside `AnswerSurvey`, the compiler tracks that `surveyResponses` is *not-null* immediately after the `new` expression, so the loop body needs no extra check.

## Build a set of survey responses

Add a method on `SurveyRun` that builds up a list of respondents until enough consent to participate:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyRun.cs" id="SnippetPerformSurvey":::

The `respondents` field is `List<SurveyResponse>?` - it's `null` until the survey runs.

Call `PerformSurvey` from `Main`:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="SnippetRunSurvey":::

## Examine the survey results

To report results, expose a few helpers from `SurveyResponse` and `SurveyRun`. On `SurveyResponse`, add [expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md) (members defined with `=>` and a single expression instead of a `{ ... }` block) that handle the nullable dictionary:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyResponse.cs" id="SnippetSurveyStatus":::

`AnsweredSurvey` checks the field against `null`. `Answer` uses the [`?.` null-conditional operator](../../language-reference/operators/member-access-operators.md#null-conditional-operators--and-) (which evaluates to `null` when the left side is `null` instead of throwing) to dereference safely, and the [`??` null-coalescing operator](../../language-reference/operators/null-coalescing-operator.md) (which substitutes the right operand when the left is `null`) to provide a non-null fallback. The method's return type is non-nullable `string`, so callers don't need null checks.

On `SurveyRun`, add expression-bodied members that expose the list of participants and questions:

:::code language="csharp" source="snippets/NullableIntroduction/SurveyRun.cs" id="SnippetRunReport":::

`AllParticipants` returns a non-nullable sequence even though `respondents` might be `null`. The `??` operator substitutes `Enumerable.Empty<SurveyResponse>()` when the field isn't populated yet. If you remove the `??` clause, the compiler warns that the method might return `null` despite a non-nullable return type.

Finally, write the report at the bottom of `Main`:

:::code language="csharp" source="snippets/NullableIntroduction/Program.cs" id="SnippetWriteAnswers":::

Notice that no null check is needed for `participant`, `surveyRun.Questions`, or `surveyRun.GetQuestion(i)`. The types declare those values as non-nullable, so the compiler treats them as *not-null* throughout the loop.

Run the application:

```dotnetcli
dotnet run
```

The output is different on each run because respondents are generated randomly, but every line either reports a participant's answers or notes that they declined.

## Conclusion

The finished sample is in the [csharp/NullableIntroduction](https://github.com/dotnet/samples/tree/main/csharp/NullableIntroduction) folder of the [dotnet/samples](https://github.com/dotnet/samples) repository. Experiment by changing types between nullable and non-nullable. Removing a `?` where the design allows missing values produces compiler warnings that point to every place the missing value matters.

## Related content

- [Nullable reference types](../null-safety/nullable-reference-types.md)
- [Resolve nullable warnings](../null-safety/common-tasks/resolve-warnings.md)
- [Nullable migration strategies](../../advanced-topics/update-applications/nullable-migration-strategies.md)
- [Working with nullable reference types in EF Core](/ef/core/miscellaneous/nullable-reference-types)
