// <SnippetAddUsings>
using Microsoft.ML.Data;
// </SnippetAddUsings>

namespace SentimentAnalysis
{
    // <SnippetDeclareTypes>
    public class SentimentData
    {
        [LoadColumn(0)]
        public string? SentimentText;

        [LoadColumn(1), ColumnName("Label")]
        public bool Sentiment;
    }

    public class SentimentPrediction : SentimentData
    {

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
    // </SnippetDeclareTypes>
}
