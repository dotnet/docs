// <Example1>
// Create the definition to define the schema.
VectorStoreCollectionDefinition definition = new()
{
    Properties = new List<VectorStoreProperty>
    {
        new VectorStoreKeyProperty("Key", typeof(string)),
        new VectorStoreDataProperty("Term", typeof(string)),
        new VectorStoreDataProperty("Definition", typeof(string)),
        new VectorStoreVectorProperty("DefinitionEmbedding", typeof(ReadOnlyMemory<float>), dimensions: 1536)
    }
};

// When getting your collection instance from a vector store instance
// specify the Dictionary, using object as the key type for your database
// and also pass your record definition.
// Note that you have to use GetDynamicCollection instead of the regular GetCollection method
// to get an instance of a collection using Dictionary<string, object?>.
var dynamicDataModelCollection = vectorStore.GetDynamicCollection(
    "glossary",
    definition);

// Since schema information is available from the record definition
// it's possible to create a collection with the right vectors,
// dimensions, indexes, and distance functions.
await dynamicDataModelCollection.EnsureCollectionExistsAsync();

// When retrieving a record from the collection, key, data, and vector values can
// now be accessed via the dictionary entries.
var record = await dynamicDataModelCollection.GetAsync("SK");
Console.WriteLine(record["Definition"]);
// </Example1>

// <Example2>
new AzureAISearchDynamicCollection(
    searchIndexClient,
    "glossary",
    new() { Definition = definition });
// </Example2>