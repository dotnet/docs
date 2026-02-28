// <4CollectionAndIndexCreation>
[VectorStoreVector(1536, DistanceFunction = DistanceFunction.DotProductSimilarity]
public ReadOnlyMemory<float>? Embedding { get; set; }
// </4CollectionAndIndexCreation>

// <RecommendedCommonPatternsAndPractices>
public sealed class MyDBCollection<TRecord> : VectorStoreCollection<string, TRecord>
{
    public MyDBCollection(MyDBClient myDBClient, string collectionName, MyDBCollectionOptions<TRecord>? options = default)
    {
    }

    ...
}

public class MyDBCollectionOptions<TRecord> : VectorStoreCollectionOptions
{
}
// </RecommendedCommonPatternsAndPractices>