---
description: "Learn more about: Property let procedure not defined and property get procedure did not return an object"
title: "Property let procedure not defined and property get procedure did not return an object"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID451"
ms.assetid: 8542382a-689f-4e1b-abc0-c1e2dadb92f4
---
# Property let procedure not defined and property get procedure did not return an object

Certain properties, methods, and operations can only apply to `Collection` objects. You specified an operation or property that is exclusive to collections, but the object is not a collection.  
  
## To correct this error  
  
1. Check the spelling of the object or property name, or verify that the object is a `Collection` object.  
  
2. Look at the `Add` method used to add the object to the collection to be sure the syntax is correct and that any identifiers were spelled correctly.  
  
## See also

- <xref:Microsoft.VisualBasic.Collection>
