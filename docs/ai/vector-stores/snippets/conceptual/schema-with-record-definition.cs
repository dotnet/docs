using Microsoft.Extensions.VectorData;

public class RecordDefinitionExample
{
    public void CreateHotelDefinition()
    {
        // <UseRecordDefinition>
        VectorStoreCollectionDefinition hotelDefinition = new()
        {
            Properties =
            [
                new VectorStoreKeyProperty("HotelId", typeof(ulong)),
                new VectorStoreDataProperty("HotelName", typeof(string)) { IsIndexed = true },
                new VectorStoreDataProperty("Description", typeof(string)) { IsFullTextIndexed = true },
                new VectorStoreVectorProperty("DescriptionEmbedding", typeof(float), dimensions: 4) { DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw },
            ]
        };
        // </UseRecordDefinition>
    }
}
