---
description: "Learn more about: Feed Formatter (JSON)"
title: "Feed Formatter (JSON)"
ms.date: "03/30/2017"
ms.assetid: f9c0b295-55e7-48ea-b308-ba51c7d31143
---
# Feed Formatter (JSON)

The [JsonFeeds sample](https://github.com/dotnet/samples/tree/main/framework/wcf) shows how to serialize an instance of a <xref:System.ServiceModel.Syndication.SyndicationFeed> class in JavaScript Object Notation (JSON) format by using a custom <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> and the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>.

## Architecture of the Sample

The sample implements a class named `JsonFeedFormatter` that inherits from <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter>. The `JsonFeedFormatter` class relies on the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> to read and write the data in JSON format. Internally, the formatter uses a custom set of data contract types named `JsonSyndicationFeed` and `JsonSyndicationItem` to control the format of the JSON data produced by the serializer. These implementation details are hidden from the end user, allowing calls to be made against the standard <xref:System.ServiceModel.Syndication.SyndicationFeed> and <xref:System.ServiceModel.Syndication.SyndicationItem> classes.

## Writing JSON feeds

Writing a JSON feed can be accomplished by using the `JsonFeedFormatter` (implemented in this sample) with the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> as shown in the following sample code.

```csharp
//Basic feed with sample data
SyndicationFeed feed = new SyndicationFeed("Custom JSON feed", "A Syndication extensibility sample", null);
feed.LastUpdatedTime = DateTime.Now;
feed.Items = from s in new string[] { "hello", "world" }
select new SyndicationItem()
{
    Summary = SyndicationContent.CreatePlaintextContent(s)
};

//Write the feed out to a MemoryStream in JSON format
DataContractJsonSerializer writeSerializer = new DataContractJsonSerializer(typeof(JsonFeedFormatter));
writeSerializer.WriteObject(stream, new JsonFeedFormatter(feed));
```

## Reading a JSON feed

Obtaining a <xref:System.ServiceModel.Syndication.SyndicationFeed> from a stream of JSON-formatted data can be accomplished with the `JsonFeedFormatter` as show in the following code.

 `//Read in the feed using the DataContractJsonSerializer`

 `DataContractJsonSerializer readSerializer = new DataContractJsonSerializer(typeof(JsonFeedFormatter));`

 `JsonFeedFormatter formatter = readSerializer.ReadObject(stream) as JsonFeedFormatter;`

 `SyndicationFeed feedRead = formatter.Feed;`

#### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
