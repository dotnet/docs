// <Overview>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string[] Tags { get; set; }
}
// </Overview>

// <VectorStoreKeyAttribute>
[VectorStoreKey]
public ulong HotelId { get; set; }
// </VectorStoreKeyAttribute>

// <VectorStoreDataAttribute>
[VectorStoreData(IsIndexed = true)]
public string HotelName { get; set; }
// </VectorStoreDataAttribute>

// <VectorStoreVectorAttribute1>
[VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
// </VectorStoreVectorAttribute1>

// <VectorStoreVectorAttribute2>
[VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
public string DescriptionEmbedding { get; set; }
// </VectorStoreVectorAttribute2>