using Microsoft.Extensions.VectorData;

// <Overview>
public class Hotel
{
    // <VectorStoreKeyAttribute>
    [VectorStoreKey]
    public ulong HotelId { get; set; }
    // </VectorStoreKeyAttribute>

    // <VectorStoreDataAttribute>
    [VectorStoreData(IsIndexed = true)]
    public required string HotelName { get; set; }
    // </VectorStoreDataAttribute>

    [VectorStoreData(IsFullTextIndexed = true)]
    public required string Description { get; set; }

    // <VectorStoreVectorAttribute1>
    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
    // </VectorStoreVectorAttribute1>

    [VectorStoreData(IsIndexed = true)]
    public required string[] Tags { get; set; }
}
// </Overview>
