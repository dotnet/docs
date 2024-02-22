// </SnippetAddUsing>
using Microsoft.ML.Data;
// </SnippetAddUsing>

namespace PhoneCallsAnomalyDetection
{
    // <SnippetDeclareTypes>
    public class PhoneCallsData
    {
        [LoadColumn(0)]
        public string? timestamp;

        [LoadColumn(1)]
        public double value;
    }

    public class PhoneCallsPrediction
    {
        // Vector to hold anomaly detection results, including isAnomaly, anomalyScore,
        // magnitude, expectedValue, boundaryUnits, upperBoundary and lowerBoundary.
        [VectorType(7)]
        public double[]? Prediction { get; set; }
    }
    // </SnippetDeclareTypes>
}
