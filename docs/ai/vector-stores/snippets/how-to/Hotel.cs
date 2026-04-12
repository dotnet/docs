// <DataModel>
using Microsoft.Extensions.VectorData;

public record class Hotel
{
    [VectorStoreKey]
    public int HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string? HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string? Description { get; set; }

    [VectorStoreVector(Dimensions: 1536, DistanceFunction = DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string[]? Tags { get; set; }
}
// </DataModel>
