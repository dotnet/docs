---
author: jmatthiesen
ms.author: jomatthi
ms.date: 07/03/2024
ms.topic: include
---

The sample GitHub repository is structured as an Azure Developer CLI (`azd`) template, which `azd` can use to provision the Azure OpenAI service and model for you.

1. From a terminal or command prompt, navigate to the `src\quickstarts\azure-openai` directory of the sample repo.
1. Run the `azd up` command to provision the Azure OpenAI resources. It might take several minutes to create the Azure OpenAI service and deploy the model.

   ```azdeveloper
   azd up
   ```

   `azd` also configures the required user secrets for the sample app, such as the Azure OpenAI endpoint and model name.
