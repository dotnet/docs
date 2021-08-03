---
description: "Learn more about: Usage of Serialization Binder"
title: "Usage of Serialization Binder"
ms.date: "03/30/2017"
ms.assetid: ab46c087-200c-45bf-9c95-5a6cda6e8b98
---
# Usage of Serialization Binder

This sample shows how to use the <xref:System.Runtime.Serialization.SerializationBinder> to change the version of a generic type when it is serialized.

## Demonstrates

 <xref:System.Runtime.Serialization.SerializationBinder>, <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>

## Discussion

This sample shows how two entities that are targeting different versions of the .NET Framework can communicate using the binary formatter and the serialization binder.

This sample was developed using .NET Remoting. It consists of a server targeting .NET Framework 4, which implements a contract with generic types, and two different clients, one targeting .NET Framework 2.0 and another targeting .NET Framework 4.

The server attaches a <xref:System.Runtime.Serialization.SerializationBinder> to the binary formatter to be able to change the version of the types accordingly on serialization, so both clients can deserialize those types properly.

#### To set up, build and run the sample

1. To execute the client, right-click the solution, SBGenericsVTS (6 projects) and then select **Properties**.

2. In **Common Properties**, select **Startup Project**, then select **Multiple Startup Projects**.

3. Select **Server** first, then **Client20** and then **Client40**. Select the **Start** action to these three projects and leave the rest set to **None**.

4. Click **OK** and then press **F5** to run the sample.
