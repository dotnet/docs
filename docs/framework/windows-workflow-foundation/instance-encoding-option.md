---
title: "Instance Encoding Option"
ms.date: "03/30/2017"
ms.assetid: 89e4b029-4f68-438c-8117-9b21fe094ef4
---
# Instance Encoding Option
The **Instance Encoding Option** property of the SQL Workflow Instance Store lets you specify whether the SQL persistence provider should compress the workflow instance state information using the GZip algorithm before saving the information into the persistence database. The allowed values for this property are: GZip and None. The default value is None. The following list describes these options.  
  
1.  **GZip**. The persistence provider encodes the state information using the GZip algorithm before persisting the state information in the persistence database.  
  
2.  **None**. The persistence provider does not encode the state information before saving the information into the persistence database.  
  
 Encoding workflow instance state information using the GZip reduces memory consumption in the SQL database and also reduces network consumption if the database resides on a different computer on the network from the computer on which the workflow service host is running. A general guidance is to set the **Instance Encoding Option** property to **None** if the workflow instance state is small.
