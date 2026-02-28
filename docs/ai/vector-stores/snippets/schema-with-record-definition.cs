// <DefineYourStorageSchemaUsingARecordDefin1>
using Microsoft.Extensions.VectorData;

var hotelDefinition = new VectorStoreCollectionDefinition
{
    Properties = new List<VectorStoreProperty>
    {
        new VectorStoreKeyProperty("HotelId", typeof(ulong)),
        new VectorStoreDataProperty("HotelName", typeof(string)) { IsIndexed = true },
        new VectorStoreDataProperty("Description", typeof(string)) { IsFullTextIndexed = true },
        new VectorStoreVectorProperty("DescriptionEmbedding", typeof(float), dimensions: 4) { DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw },
    }
};
// </DefineYourStorageSchemaUsingARecordDefin1>

// <DefineYourStorageSchemaUsingARecordDefin2>
var collection = vectorStore.GetCollection<ulong, Hotel>("skhotels", hotelDefinition);
// </DefineYourStorageSchemaUsingARecordDefin2>

// <VectorStoreKeyProperty>
new VectorStoreKeyProperty("HotelId", typeof(ulong)),
// </VectorStoreKeyProperty>

// <VectorStoreDataProperty>
new VectorStoreDataProperty("HotelName", typeof(string)) { IsIndexed = true },
// </VectorStoreDataProperty>

// <VectorStoreVectorProperty>
new VectorStoreVectorProperty("DescriptionEmbedding", typeof(float), dimensions: 4) { DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw },
// </VectorStoreVectorProperty>