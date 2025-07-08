using Indexers;

var readOnlyStringCollection = new ReadOnlySampleCollection<string>("Hello, World");
Console.WriteLine(readOnlyStringCollection[0]);

var stringCollection = new SampleCollection<string>();
stringCollection[0] = "Hello, World";
Console.WriteLine(stringCollection[0]);
