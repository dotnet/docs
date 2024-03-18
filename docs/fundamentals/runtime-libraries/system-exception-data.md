---
title: System.Exception.Data property
description: Learn about the System.Exception.Data property.
ms.date: 01/24/2024
---
# System.Exception.Data property

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Collections.IDictionary?displayProperty=nameWithType> object returned by the <xref:System.Exception.Data> property to store and retrieve supplementary information relevant to the exception. The information is in the form of an arbitrary number of user-defined key/value pairs. The key component of each key/value pair is typically an identifying string, whereas the value component of the pair can be any type of object.

## Key/value pair security

The key/value pairs stored in the collection returned by the <xref:System.Exception.Data> property are not secure. If your application calls a nested series of routines, and each routine contains exception handlers, the resulting call stack contains a hierarchy of those exception handlers. If a lower-level routine throws an exception, any upper-level exception handler in the call stack hierarchy can read and/or modify the key/value pairs stored in the collection by any other exception handler. This means you must guarantee that the information in the key/value pairs is not confidential and that your application will operate correctly if the information in the key/value pairs is corrupted.

## Key conflicts

A key conflict occurs when different exception handlers specify the same key to access a key/value pair. Use caution when developing your application because the consequence of a key conflict is that lower-level exception handlers can inadvertently communicate with higher-level exception handlers, and this communication might cause subtle program errors. However, if you are cautious you can use key conflicts to enhance your application.

## Avoid key conflicts

Avoid key conflicts by adopting a naming convention to generate unique keys for key/value pairs. For example, a naming convention might yield a key that consists of the period-delimited name of your application, the method that provides supplementary information for the pair, and a unique identifier.

Suppose two applications, named Products and Suppliers, each has a method named Sales. The Sales method in the Products application provides the identification number (the stock keeping unit or SKU) of a product. The Sales method in the Suppliers application provides the identification number, or SID, of a supplier. Consequently, the naming convention for this example yields the keys, "Products.Sales.SKU" and "Suppliers.Sales.SID".

## Exploit key conflicts

Exploit key conflicts by using the presence of one or more special, prearranged keys to control processing. Suppose, in one scenario, the highest level exception handler in the call stack hierarchy catches all exceptions thrown by lower-level exception handlers. If a key/value pair with a special key exists, the high-level exception handler formats the remaining key/value pairs in the <xref:System.Collections.IDictionary> object in some nonstandard way; otherwise, the remaining key/value pairs are formatted in some normal manner.

Now suppose, in another scenario, the exception handler at each level of the call stack hierarchy catches the exception thrown by the next lower-level exception handler. In addition, each exception handler knows the collection returned by the <xref:System.Exception.Data> property contains a set of key/value pairs that can be accessed with a prearranged set of keys.

Each exception handler uses the prearranged set of keys to update the value component of the corresponding key/value pair with information unique to that exception handler. After the update process is complete, the exception handler throws the exception to the next higher-level exception handler. Finally, the highest level exception handler accesses the key/value pairs and displays the consolidated update information from all the lower-level exception handlers.
