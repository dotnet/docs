---
title: Tutorial - Evaluate a model's response
description: Create an MSTest app and add a custom evaluator to evaluate the AI chat response of a language model, and learn how to use the caching and reporting features of Microsoft.Extensions.AI.Evaluation.
ms.date: 03/14/2025
ms.topic: tutorial
ms.custom: devx-track-dotnet-ai
---

# Tutorial: Evaluate a model's response with response caching and reporting

In this tutorial, you create an MSTest app to evaluate the chat response of an Azure OpenAI model. The test app uses the [Microsoft.Extensions.AI.Evaluation](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation) libraries. The tutorial uses a built-in evaluator and a custom evaluator.

## Prerequisites

- [.NET 8 or a later version](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Configure the AI service

To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article. In the "Deploy a model" step, select the `gpt-4o` model.

## Create the test app

Complete the following steps to create an MSTest project that connects to the `gpt-4o` AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new MSTest app with the `dotnet new` command:

    ```dotnetcli
    dotnet new mstest -o TestAIWithReporting
    ```

1. Navigate to the `TestAI` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.AI.Abstractions --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Quality --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Reporting --prerelease
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

1. Run the following commands to add [app secrets](/aspnet/core/security/app-secrets) for your Azure OpenAI endpoint, model name, and tenant ID:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-azure-openai-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-azure-openai-model-name>
    dotnet user-secrets set AZURE_TENANT_ID <your-tenant-id>
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

## Add the test app code

1. Rename the file *Test1.cs* to *MyTests.cs*, and then open the file and rename the class to `MyTests`.
1. Add the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> property to the class.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="TestContext":::

1. Add the `GetAzureOpenAIChatConfiguration` method, which creates the <xref:Microsoft.Extensions.AI.IChatClient> that the evaluator uses to communicate with the model.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="GetChatConfig":::

1. Set up the reporting functionality.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="ReportingSetup":::

   **Scenario name**

   The [scenario name](xref:Microsoft.Extensions.AI.Evaluation.Reporting.ScenarioRun.ScenarioName) is set to the fully qualified name of the current test method. However, you can set it to any string of your choice when you call <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration.CreateScenarioRunAsync(System.String,System.String,System.Collections.Generic.IEnumerable{System.String},System.Threading.CancellationToken)>. Here are some considerations for choosing a scenario name:

   - When using disk-based storage, the scenario name is used as the name of the folder under which the corresponding evaluation results are stored. So it's a good idea to keep the name reasonably short and avoid any characters that aren't allowed in file and directory names.
   - By default, the generated evaluation report splits scenario names on `.` so that the results can be displayed in a hierarchical view with appropriate grouping, nesting, and aggregation. This is especially useful in cases where the scenario name is set to the fully qualified name of the corresponding test method, since it allows the results to be grouped by namespaces and class names in the hierarchy. However, you can also take advantage of this feature by including periods (`.`) in your own custom scenario names to create a reporting hierarchy that works best for your scenarios.

   **Execution name**

   The execution name is used to group evaluation results that are part of the same evaluation run (or test run) when the evaluation results are stored. If you don't provide an execution name when creating a <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration>, all evaluation runs will use the same default execution name of `Default`. In this case, results from one run will be overwritten by the next and you lose the ability to compare results across different runs.

   This example uses a timestamp as the execution name. If you have more than one test in your project, ensure that results are grouped correctly by using the same execution name in all reporting configurations used across the tests.

   In a more real-world scenario, you might also want to share the same execution name across evaluation tests that live in multiple different assemblies and that are executed in different test processes. In such cases, you could use a script to update an environment variable with an appropriate execution name (such as the current build number assigned by your CI/CD system) before running the tests. Or, if your build system produces monotonically increasing assembly file versions, you could read the <xref:System.Reflection.AssemblyFileVersionAttribute> from within the test code and use that as the execution name to compare results across different product versions.

   **Reporting configuration**

   A <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration> identifies:

   - The set of evaluators that should be invoked for each <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ScenarioRun> that's created by calling <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration.CreateScenarioRunAsync(System.String,System.String,System.Collections.Generic.IEnumerable{System.String},System.Threading.CancellationToken)>.
   - The LLM endpoint that the evaluators should use (see <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration.ChatConfiguration?displayProperty=nameWithType>).
   - How and where the results for the scenario runs should be stored.
   - How LLM responses related to the scenario runs should be cached.
   - The execution name that should be used when reporting results for the scenario runs.

   This test uses a disk-based reporting configuration.

1. Add the `WordCountEvaluator` class, which is a custom evaluator that implements <xref:Microsoft.Extensions.AI.Evaluation.IEvaluator>.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/WordCountEvaluator.cs":::

   The `WordCountEvaluator` counts the number of words present in the response. Unlike some evaluators, it isn't based on AI. The `EvaluateAsync` method returns an <xref:Microsoft.Extensions.AI.Evaluation.EvaluationResult> includes a <xref:Microsoft.Extensions.AI.Evaluation.NumericMetric> that contains the word count.

   The `EvaluateAsync` method also attaches a default interpretation to the metric. The default interpretation considers the metric to be good (acceptable) if the detected word count is at or under 100. Otherwise, the metric is considered failed. This default interpretation can be overridden by the caller, if needed.

1. Add a method to gather the evaluators to use in the evaluation.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="GetEvaluators":::

1. Add a method to add a system prompt <xref:Microsoft.Extensions.AI.ChatMessage>, define the [chat options](xref:Microsoft.Extensions.AI.ChatOptions), and ask the model for a response to a given question.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="GetResponse":::

   The test in this tutorial evaluates the LLM's response to an astronomy question. Since the <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration> has response caching enabled, and since the supplied <xref:Microsoft.Extensions.AI.IChatClient> is always fetched from the <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ScenarioRun> created using this reporting configuration, the LLM response for the test is cached and reused. The response will be reused until the corresponding cache entry expires (in 14 days by default), or until any request parameter, such as the the LLM endpoint or the question being asked, is changed.

1. Add a method to validate the response.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="Validate":::

    > [!TIP]
    > Since `includeReasoning` was set to `true` when the <xref:Microsoft.Extensions.AI.Evaluation.Quality.RelevanceTruthAndCompletenessEvaluator> was created in `GetEvaluators`, the relevance, truth, and completeness metrics each include a single informational diagnostic that explains the reasoning for the score. This diagnostic is included in the generated report and can be viewed by hovering over the corresponding metric's card in the report.

1. Finally, add the [test method](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) itself.

   :::code language="csharp" source="./snippets/evaluate-with-reporting/MyTests.cs" id="TestMethod":::

   This test method:

   - Creates the <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ScenarioRun>.
   - Gets the LLM's response to a specific astronomy question. Since response caching is turned on for the reporting configuration, the LLM response will be fetched either:
     - Directly from the LLM endpoint in the very first run of the current test.
     - From the (disk-based) response cache that was configured in `s_defaultReportingConfiguration` in every subsequent run of the test, until the cached entry expires (in 14 days by default).
   - Runs the evaluators against the response. Since response caching is enabled, the evaluation will be either:
     - Performed using the the LLM endpoint in the very first run of the current test.
     - Fetched from the (disk-based) response cache that was configured in `s_defaultReportingConfiguration` in every subsequent run of the test, until the cached entry expires (in 14 days by default).
   - Runs some basic validation on the evaluation result.
     - This step is optional and mainly for demonstration purposes. In real-world evaluations, you might not want to validate individual results since the LLM responses and evaluation scores can change over time as your product (and the models used) evolve. You might not want individual evaluation tests to "fail" and block builds in your CI/CD pipelines when this happens. Instead, it might be better to rely on the generated report and track the overall trends for evaluation scores across different scenarios over time (and only fail individual builds when there's a significant drop in evaluation scores across multiple different tests). That said, there is some nuance here and the choice of whether to validate individual results or not can vary depending on the specific use case.

   When the method returns, the `scenarioRun` object is disposed and the evaluation result for the evaluation is stored to the (disk-based) result store that's configured in `s_defaultReportingConfiguration`.

## Run the test/evaluation

Run the test using your preferred test workflow, for example, by using the CLI command `dotnet test` or through [Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).

## Next steps

- Navigate to the directory where the test results are stored (which is `C:\TestReports`, unless you modified the location when you created the <xref:Microsoft.Extensions.AI.Evaluation.Reporting.ReportingConfiguration>). In the `results` subdirectory, notice that there's a folder for each test run named with a timestamp (`ExecutionName`). Inside each of those folders is a folder for each scenario name&mdash;in this case, just the single test method in the project. That folder contains a JSON file with the all the data including the messages, response, and evaluation result.
- Expand the evaluation. Here are a couple ideas:
  - Add an additional custom evaluator, such as an evaluator that uses AI to determine the measurement system that's used in the response.
  - Add another test method, for example, a method that evaluates multiple responses from the LLM.
