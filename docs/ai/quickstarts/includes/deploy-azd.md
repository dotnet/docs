---
author: jmatthiesen
ms.author: jomatthi
ms.date: 07/03/2024
ms.topic: include
---

## Deploy the Azure resources

Ensure that you follow the [Prerequisites](#prerequisites) to have access to Azure OpenAI Service as well as the Azure Developer CLI, and then use the following guide to get started with the sample application.

1. Clone the repository: [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the _src\quickstarts\azure-openai_ directory (on macOS or Linux, replace the '\\' character with a '/').
1. The following command provisions the Azure OpenAI resources. It might take several minutes to create the Azure OpenAI service and deploy the model.

   ```azdeveloper
   azd up
   ```

    > [!NOTE]
    > If you encounter an error during the `azd up` deployment, visit the [troubleshooting](#troubleshoot) section.
