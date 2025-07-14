# Contoso University Management System Migration Sample for GitHub Copilot App Modernization for .NET (Preview)

To demonstrate GitHub Copilot App Modernization for .NET (Preview), we've provided a migration sample [Contoso University sample web app](https://github.com/Azure-Samples/dotnet-migration-copilot-samples/tree/main/ContosoUniversity).  

This fictional university management system is originally built with .NET Framework 4.8 and contains functionalities such as student enrollment, course management, and instructor assignments. It uses legacy Windows-based components, including:

- **SQL Server LocalDB** for database storage  
- **Local file system** for file management  
- **Microsoft Message Queue (MSMQ)** for notification messaging  

## After Migration

Using App Modernization for .NET (Preview), the sample can be updated to leverage modern, cloud-native Azure services, including:

- **Azure SQL Database** replacing SQL Server LocalDB  
- **Azure Blob Storage** replacing local file system access  
- **Azure Service Bus** replacing MSMQ  
- **Azure Key Vault** for secure secrets management  

This migration showcases how legacy on-premises applications can be transformed into scalable, maintainable cloud-native solutions using GitHub Copilot and Azure services.

## See Also

- [Quickstart: assess and migrate a .NET project using GitHub Copilot App Modernization for .NET (Preview)](quick-start.md)