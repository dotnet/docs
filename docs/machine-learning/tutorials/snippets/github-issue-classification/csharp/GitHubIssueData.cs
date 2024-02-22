// <SnippetAddUsings>
using Microsoft.ML.Data;
// </SnippetAddUsings>

namespace GitHubIssueClassification
{
    // <SnippetDeclareTypes>
    public class GitHubIssue
    {
        [LoadColumn(0)]
        public string? ID { get; set; }
        [LoadColumn(1)]
        public string? Area { get; set; }
        [LoadColumn(2)]
        public required string Title { get; set; }
        [LoadColumn(3)]
        public required string Description { get; set; }
    }

    public class IssuePrediction
    {
        [ColumnName("PredictedLabel")]
        public string? Area;
    }
    // </SnippetDeclareTypes>
}
