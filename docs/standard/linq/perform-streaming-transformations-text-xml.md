---
title: How to perform streaming transformations of text to XML in C# - LINQ to XML
description: You can use an extension method that releases a line at a time to stream a text file for processing. This technique reduces memory requirements compared to techniques which load the entire file and then process it.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
ms.topic: how-to
---

# How to perform streaming transformations of text to XML in C# (LINQ to XML)

You can use an extension method that releases a line at a time to stream a text file for processing. This technique reduces memory requirements compared to techniques which load the entire file and then process it.

The extension method can provide the line using the `yield return` construct. A LINQ query can process the stream in a lazy deferred fashion. If you use <xref:System.Xml.Linq.XStreamingElement> to stream output, you can create a transformation from the text file to XML that uses a minimal amount of memory, regardless of the size of the source text file.

> [!NOTE]
> The technique is best applied in situations in which you can process the entire file once, taking the lines in order from the source document. Processing the file more than once, or sorting before processing, reduces the performance benefits of a streaming technique.

## Example Use an extension method to stream text

The example uses the following text file, People.txt, as its source:

```text
#This is a comment
1,Tai,Yee,Writer
2,Nikolay,Grachev,Programmer
3,David,Wright,Inventor
```

In the code for the example, extension method `Lines` provides the text a line at a time:

```csharp
public static class StreamReaderSequence
{
    public static IEnumerable<string> Lines(this StreamReader source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        string line;
        while ((line = source.ReadLine()) != null)
        {
            yield return line;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var sr = new StreamReader("People.txt");
        var xmlTree = new XStreamingElement("Root",
            from line in sr.Lines()
            let items = line.Split(',')
            where !line.StartsWith("#")
            select new XElement("Person",
                       new XAttribute("ID", items[0]),
                       new XElement("First", items[1]),
                       new XElement("Last", items[2]),
                       new XElement("Occupation", items[3])
                   )
        );
        Console.WriteLine(xmlTree);
        sr.Close();
    }
}
```

The example produces the following output:

```xml
<Root>
  <Person ID="1">
    <First>Tai</First>
    <Last>Yee</Last>
    <Occupation>Writer</Occupation>
  </Person>
  <Person ID="2">
    <First>Nikolay</First>
    <Last>Grachev</Last>
    <Occupation>Programmer</Occupation>
  </Person>
  <Person ID="3">
    <First>David</First>
    <Last>Wright</Last>
    <Occupation>Inventor</Occupation>
  </Person>
</Root>
```

## See also

- <xref:System.Xml.Linq.XStreamingElement>
