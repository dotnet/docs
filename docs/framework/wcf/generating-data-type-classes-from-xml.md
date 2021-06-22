---
description: "Learn more about: Generating Data Type Classes from XML"
title: "Generating Data Type Classes from XML"
ms.date: "03/30/2017"
ms.topic: how-to
---
# Generating Data Type Classes from XML

.NET Framework 4.5 includes a new feature to generate data type classes from XML. This topic describes how to automatically generate data types for the .NET Blog RSS feed.  
  
### Obtaining the XML from the .NET Blog RSS feed  
  
1. In Internet Explorer, navigate to the [.NET Blog RSS feed](https://devblogs.microsoft.com/dotnet/feed/).  
  
2. Right-click the page and select **View Source**.  
  
3. Copy the text of the feed by pressing **Ctrl+A** to select all text, and **Ctrl+C** to copy.  
  
### Creating the data types  
  
1. Open a code file where the proxy is to be used. This file should be part of a .NET Framework 4.5 project.  
  
2. Place the cursor in a location in the file outside any existing classes.  
  
3. Select **Edit**, **Paste Special**, **Paste XML as Classes**.  
  
4. Classes called `link`, `rss`, `rssChannel`, `rssChannelImage`, `rssChannelItem` and `rssChannelItemGuid` are created with the necessary members for accessing the elements in the RSS feed.  
  
### Using the generated classes  
  
1. Once the classes are generated, they can be used in code like any other classes. The following code example returns a new instance of the `rssChannelImage` class.  
  
    ```csharp
    var channelImage = new rssChannelImage()
    {
        title = "MyImage",
        link = "http://www.contoso.com/images/channelImage.jpg",
        url = "http://www.contoso.com/entries/myEntry.html"
    };  
    ```
