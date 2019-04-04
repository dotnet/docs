---
title: "Instance Completion Action"
ms.date: "03/30/2017"
ms.assetid: 90cc99d2-9fef-42fd-bcbf-a56917993721
---
# Instance Completion Action
The **Instance Completion Action** property of the SQL Workflow Instance Store lets you specify whether the data and metadata of workflow instances is deleted from the persistence database after the instances are completed. The allowed values for this property are **DeleteAll** and **DeleteNothing**. The following list describes these options:  
  
-   **DeleteAll (default).** If the value of the property is set to DeleteAll, the data and metadata of workflow instances is deleted from the persistence database after the instances are completed.  
  
-   **DeleteNothing.** If the value of the property is set to DeleteNothing, the data and metadata of workflow instances is kept in the persistence database even after the instances are completed.  
  
    > [!CAUTION]
    >  Keeping instance state information after the instances are completed causes the persistence database to grow in size. As the size of the database grows the database operations that the persistence subsystem performs take longer, so you need to purge the instance state information from the persistence database periodically to have services perform at the level that satisfy your performance needs.
