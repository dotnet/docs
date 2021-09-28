// <SnippetUsings>
using Microsoft.ML.Data;
// </SnippetUsings>

namespace IrisFlowerClustering
{
    // <SnippetClassDefinitions>
    public class IrisData
    {
        [LoadColumn(0)]
        public float SepalLength;

        [LoadColumn(1)]
        public float SepalWidth;

        [LoadColumn(2)]
        public float PetalLength;

        [LoadColumn(3)]
        public float PetalWidth;
    }

    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[] Distances;
    }
    // </SnippetClassDefinitions>
}
