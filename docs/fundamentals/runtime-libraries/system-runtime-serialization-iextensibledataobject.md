---
title: System.Runtime.Serialization.IExtensibleDataObject interface
description: Learn about the System.Runtime.Serialization.IExtensibleDataObject interface.
ms.date: 12/31/2023
ms.topic: article
---
# System.Runtime.Serialization.IExtensibleDataObject interface

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.Serialization.IExtensibleDataObject> interface provides a single property that sets or returns a structure used to store data that is external to a data contract. The extra data is stored in an instance of the <xref:System.Runtime.Serialization.ExtensionDataObject> class and accessed through the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData> property. In a roundtrip operation where data is received, processed, and sent back, the extra data is sent back to the original sender intact. This is useful to store data received from future versions of the contract. If you do not implement the interface, any extra data is ignored and discarded during a roundtrip operation.

## To use this versioning feature

1. Implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface in a class.

2. Add the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData> property to your type.

3. Add a private member of type <xref:System.Runtime.Serialization.ExtensionDataObject> to the class.

4. Implement get and set methods for the property using the new private member.

5. Apply the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to the class. Set the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> and <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A> properties to appropriate values if necessary.

For more information about versioning of types, see [Data Contract Versioning](../../framework/wcf/feature-details/data-contract-versioning.md). For information about creating forward-compatible data contracts, see [Forward-Compatible Data Contracts](../../framework/wcf/feature-details/forward-compatible-data-contracts.md). For more information about data contracts, see [Using Data Contracts](../../framework/wcf/feature-details/using-data-contracts.md).
