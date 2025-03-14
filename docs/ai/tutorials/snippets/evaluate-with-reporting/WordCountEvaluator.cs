using System.Text.RegularExpressions;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;

namespace TestAIWithReporting;

/// <summary>
/// A non-AI-based evaluator that counts the number of words present in the response.
/// </summary>
/// <remarks>
/// The word count is returned via a <see cref="NumericMetric"/> as part of the returned
/// <see cref="EvaluationResult"/>.
/// </remarks>
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
    /// <remarks>
    /// The default interpretation provided in this method considers the supplied <paramref name="metric"/> to be good
    /// (acceptable) if the detected word count is at or under 100. Otherwise, the/ <paramref name="metric"/> is
    /// considered as failed.
    /// </remarks>
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
            var reason = $"The response is {metric.Value} words long.";
            metric.Interpretation =
                metric.Value <= 100
                    ? new EvaluationMetricInterpretation(EvaluationRating.Good, reason: reason)
                    : new EvaluationMetricInterpretation(EvaluationRating.Unacceptable, failed: true, reason);
        }
    }

    public ValueTask<EvaluationResult> EvaluateAsync(
        IEnumerable<ChatMessage> messages,
        ChatMessage modelResponse,
        ChatConfiguration? chatConfiguration = null,
        IEnumerable<EvaluationContext>? additionalContext = null,
        CancellationToken cancellationToken = default)
    {
        // Count the number of words in the supplied <see cref="modelResponse"/>.
        int wordCount = CountWords(modelResponse.Text);

        // Create a <see cref="NumericMetric"/> with value set to the word count.
        var metric = new NumericMetric(WordCountMetricName, value: wordCount);

        // Attach a default <see cref="EvaluationMetricInterpretation"/> for the metric.
        // An evaluator can provide a default interpretation for each metric that it produces.
        // This default interpretation can be overridden by the caller if needed.
        Interpret(metric);

        // Return an <see cref="EvaluationResult"/> that contains the previous metric.
        return new ValueTask<EvaluationResult>(new EvaluationResult(metric));
    }
}
