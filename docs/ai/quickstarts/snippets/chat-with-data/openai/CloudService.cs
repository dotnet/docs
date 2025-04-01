using Microsoft.Extensions.VectorData;

namespace VectorDataAI
{
    internal class CloudService
    {
        [VectorStoreRecordKey]
        public int Key { get; set; }

        [VectorStoreRecordData]
        public string Name { get; set; }

        [VectorStoreRecordData]
        public string Description { get; set; }

        [VectorStoreRecordVector(384, DistanceFunction.CosineSimilarity)]
        public ReadOnlyMemory<float> Vector { get; set; }
    }
}
