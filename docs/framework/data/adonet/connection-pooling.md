---
title: "Connection Pooling"
description: Learn about connection pooling, an optimization technique that ADO.NET uses to minimize the cost of opening connections to data sources.
ms.date: "03/30/2017"
ms.assetid: 955c057f-aea8-4ba8-aa6d-e3dfa18ba8d5
---
# Connection Pooling

Connecting to a data source can be time consuming. To minimize the cost of opening connections, ADO.NET uses an optimization technique called *connection pooling*, which minimizes the cost of repeatedly opening and closing connections. Connection pooling is handled differently for the .NET Framework data providers. While connection pooling improves performance and resource utilization, several factors can influence its efficiency depending on the database environment and configuration:

- **Connection Limits and Resource Constraints:** In database environments, connection limits are often tied to service tiers or resource configurations. For instance, Azure SQL Database defines connection limits based on the selected service tier, while Azure SQL Managed Instance enforces limits based on allocated resources, such as CPU, memory, or vCores. When connection pool configurations exceed these limits, applications may experience rejected connections, throttling, or degraded performance.

- **Authentication Methods:** Token-based authentication mechanisms, such as Microsoft Entra ID authentication, can impact connection pooling due to token expiration. Expired tokens may invalidate connections within the pool, disrupting reuse. This behavior occurs in both cloud-based and on-premises database systems that use modern authentication protocols.

- **Network Latency and Endpoints:** Network latency and endpoint configurations can influence the efficiency of connection pooling. Public endpoints, commonly used in cloud-hosted databases, typically introduce higher latency compared to private or direct connections. In cloud-native applications with dynamic IP addressing, connection reuse may be disrupted if firewall rules are not updated to accommodate changing IP addresses.

- **Encryption Requirements:** Databases that enforce TLS/SSL encryption require alignment between connection pooling configurations and encryption settings. For example, omitting required encryption parameters in connection strings, such as `Encrypt=True`, can lead to connection failures, reducing pooling efficiency.

- **DNS Resolution:** Private endpoints and custom DNS configurations may pose challenges for connection pooling. Misconfigured or inconsistent DNS settings can delay or block connection establishment, impacting the performance and reliability of connection reuse. This is especially relevant in environments with hybrid or private cloud setups.
  
## In This Section  

 [SQL Server Connection Pooling (ADO.NET)](sql-server-connection-pooling.md)  
 Provides an overview of connection pooling and describes how connection pooling works in SQL Server.  
  
 [OLE DB, ODBC, and Oracle Connection Pooling](ole-db-odbc-and-oracle-connection-pooling.md)  
 Describes connection pooling for the .NET Framework Data Provider for OLE DB, the .NET Framework Data Provider for ODBC, and the .NET Framework Data Provider for Oracle.  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [ADO.NET Overview](ado-net-overview.md)
