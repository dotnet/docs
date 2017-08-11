---
title: Troubleshooting Type Providers
description: Discover potential solutions for the problems that you are most likely to encounter when you use type providers in F#.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 44533045-9862-43c5-81d9-3e05157e975a 
---

# Troubleshooting Type Providers

This topic describes and provides potential solutions for the problems that you are most likely to encounter when you use type providers.


## Possible Problems with Type Providers
If you encounter a problem when you work with type providers, you can review the following table for the most common solutions.



|Problem|Suggested Actions|
|-------|-----------------|
|**Schema Changes**. Type providers work best  when the data source schema is stable. If you add a data table or column or make another change to that schema, the type provider doesn’t automatically recognize these changes.|Clean or rebuild the project. To clean the project, choose **Build**, **Clean** *ProjectName* on the menu bar. To rebuild the project, choose **Build**, **Rebuild** *ProjectName* on the menu bar. These actions reset all type provider state and force the provider to reconnect to the data source and obtain updated schema information.|
|**Connection Failure**. The URL or connection string is incorrect, the network is down, or the data source or service is unavailable.|For a web service or OData service, you can try the URL in Internet Explorer to verify whether the URL is correct and the service is available. For a database connection string, you can use the data connection tools in **Server Explorer** to verify whether the connection string is valid and the database is available. After you restore your connection, you should then clean or rebuild the project so that the type provider will reconnect to the network.|
|**Not Valid Credentials**. You must have valid permissions for the data source or web service.|For a SQL connection, the username and the password that are specified in the connection string or configuration file must be valid for the database. If you are using Windows Authentication, you must have access to the database. The database administrator can identify what permissions you need for access to each database and each element within a database.<br /><br />For a web service or a data service, you must have appropriate credentials. Most type providers provide a DataContext object, which contains a Credentials property that you can set with the appropriate username and access key.|
|**Not Valid Path**. A path to a file was not valid.|Verify whether the path is correct and the file exists. In addition, you must either quote any backlashes in the path appropriately or use a verbatim string or triple-quoted string.|

## See Also
[Type Providers](index.md)
