---
title: "Generating Data Type Classes from XML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e4e5e4e8-527f-44d1-92fa-8904a08784ea
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Generating Data Type Classes from XML
[!INCLUDE[net_v45](../../../includes/net-v45-md.md)] includes a new feature to generate data type classes from XML. This topic describes how to automatically generate data types for the .NET Blog RSS feed.  
  
### Obtaining the XML from the .NET Blog RSS feed  
  
1.  In Internet Explorer, navigate to the [.NET Blog RSS feed](https://blogs.msdn.microsoft.com/dotnet/feed/).  
  
2.  Right-click the page and select **View Source**.  
  
3.  Copy the text of the feed by pressing **Ctrl+A** to select all text, and **Ctrl+C** to copy.  
  
### Creating the data types  
  
1.  Open a code file where the proxy is to be used. This file should be part of a [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] project.  
  
2.  Place the cursor in a location in the file outside any existing classes.  
  
3.  Select **Edit**, **Paste Special**, **Paste XML as Classes**.  
  
4.  Classes called `link`, `rss`, `rssChannel`, `rssChannelImage`, `rssChannelItem` and `rssChannelItemGuid` are created with the necessary members for accessing the elements in the RSS feed.  
  
### Using the generated classes  
  
1.  Once the classes are generated, they can be used in code like any other classes. The following code example returns a new instance of the `rssChannelImage` class.  
  
    ```  
    var channelImage = new rssChannelImage()   
    {   
        title = "MyImage",   
        link = "http://www.contoso.com/images/channelImage.jpg",   
        url = "http://www.contoso.com/entries/myEntry.html"   
    };  
    ```
