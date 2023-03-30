---
description: "Learn more about: Generating Data Type Classes from XML"
title: "Generating Data Type Classes from XML"
ms.date: 03/24/2023
ms.topic: how-to
---
# Generate data type classes from XML

.NET Framework 4.5 includes a new feature to generate data type classes from XML. This article describes how to automatically generate data types for the .NET Blog RSS feed.  
  
## Obtain the XML from the .NET Blog RSS feed  
  
1. In a browser, navigate to the [.NET Blog RSS feed](https://devblogs.microsoft.com/dotnet/feed/).
  
2. Copy the text of the feed by pressing <kbd>Ctrl+A</kbd> to select all text, and <kbd>Ctrl+C</kbd> to copy.  
  
## Create the data types  
  
1. Open a code file where the proxy is to be used. This file should be part of a .NET Framework 4.5 or later project.  
  
2. Place the cursor in a location in the file outside any existing classes.  
  
3. Select **Edit** > **Paste Special** > **Paste XML as Classes**.  
  
4. Classes called `link`, `rss`, `rssChannel`, `rssChannelImage`, `rssChannelItem`, and `rssChannelItemGuid` are created with the necessary members for accessing the elements in the RSS feed.  
  
## Use the generated classes  
  
Once the classes are generated, you can use them in code like any other classes. The following code example returns a new instance of the `rssChannelImage` class.  
  
```csharp
var channelImage = new rssChannelImage()
{
    title = "MyImage",
    link = "http://www.contoso.com/images/channelImage.jpg",
    url = "http://www.contoso.com/entries/myEntry.html"
};  
```
