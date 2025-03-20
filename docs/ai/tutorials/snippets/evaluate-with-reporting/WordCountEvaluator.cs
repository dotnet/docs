using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;

namespace TestAIWithReporting;

public class WordCountEvaluator : IEvaluator
{
    public const string WordCountMetricName = "Words";

    public IReadOnlyCollection<string> EvaluationMetricNames => [WordCountMetricName];

    /// <summary>
    /// Counts the number of words in the supplied string.
    /// </summary>
    private static int CountWords(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        MatchCollection matches = Regex.Matches(input, @"\b\w+\b");
        return matches.Count;
    }

    /// <summary>
    /// Provides a default interpretation for the supplied <paramref name="metric"/>.
    /// </summary>
    private static void Interpret(NumericMetric metric)
    {
        if (metric.Value is null)
        {
            metric.Interpretation =
                new EvaluationMetricInterpretation(
                    EvaluationRating.Unknown,
                    failed: true,
                    reason: "Failed to calculate word count for the response.");
        }
        else
        {
            if (metric.Value <= 100 && metric.Value > 5)
                metric.Interpretation = new EvaluationMetricInterpretation(
                    EvaluationRating.Good,
                    reason: "The response was between 6 and 100 words.");
            else
                metric.Interpretation = new EvaluationMetricInterpretation(
                    EvaluationRating.Unacceptable,
                    failed: true,
                    reason: "The response was either too short or greater than 100 words.");
        }
    }

    public ValueTask<EvaluationResult> EvaluateAsync(
        IEnumerable<ChatMessage> messages,
        ChatResponse modelResponse,
        ChatConfiguration? chatConfiguration = null,
        IEnumerable<EvaluationContext>? additionalContext = null,
        CancellationToken cancellationToken = default)
    {
        // Count the number of words in the supplied <see cref="modelResponse"/>.
        int wordCount = CountWords(modelResponse.Text);

        string reason =
            $"This {WordCountMetricName} metric has a value of {wordCount} because " +
            $"the evaluated model response contained {wordCount} words.";

        // Create a <see cref="NumericMetric"/> with value set to the word count.
        // Include a reason that explains the score.
        var metric = new NumericMetric(WordCountMetricName, value: wordCount, reason);

        // Attach a default <see cref="EvaluationMetricInterpretation"/> for the metric.
        Interpret(metric);

        return new ValueTask<EvaluationResult>(new EvaluationResult(metric));
    }
}
