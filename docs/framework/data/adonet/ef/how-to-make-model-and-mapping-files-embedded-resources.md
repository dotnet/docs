---
description: "Learn more about deploying model and mapping files as embedded resources of an Entity Framework application."
title: "How to: Make Model and Mapping Files Embedded Resources"
ms.date: "03/30/2017"
---
# How to: Make Model and Mapping Files Embedded Resources

Entity Framework enables you to deploy model and mapping files as embedded resources of an application. The assembly with the embedded model and mapping files must be loaded in the same application domain as the entity connection. For more information, see [Connection Strings](connection-strings.md). By default, the Entity Data Model tools embed the model and mapping files. When you manually define the model and mapping files, use this procedure to ensure that the files are deployed as embedded resources together with an Entity Framework application.

> [!NOTE]
> To maintain embedded resources, you must repeat this procedure whenever the model and mapping files are modified.

## To embed model and mapping files

1. In **Solution Explorer**, select the conceptual (.csdl) file.

2. In the **Properties** pane, set **Build Action** to **Embedded Resource**.

3. Repeat steps 1 and 2 for the storage (.ssdl) file and the mapping (.msl) file.

4. In **Solution Explorer**, double-click the App.config file and then modify the `Metadata` parameter in the `connectionString` attribute based on one of the following formats:

   - `Metadata=` `res://<assemblyFullName>/<resourceName>;`
   - `Metadata=` `res://*/<resourceName>;`
   - `Metadata=res://*;`

   For more information, see [Connection Strings](connection-strings.md).

## See also

- [Modeling and Mapping](modeling-and-mapping.md)
