---
ms.topic: include
ms.date: 09/16/2025
---

```mermaid
%% STEPS TO GENERATE IMAGE
%% =======================
%% 1. Install mermaid CLI v10.9.1 (see https://github.com/mermaid-js/mermaid-cli/blob/master/README.md):
%%    npm i -g @mermaid-js/mermaid-cli@10.9.1
%% 2. Run command: mmdc -i default-azure-credential-environment-variable-development.md -o ../../media/mermaidjs/default-azure-credential-environment-variable-development.svg

%%{
  init: {
    'theme': 'base',
    'themeVariables': {
      'tertiaryBorderColor': '#fff',
      'tertiaryColor': '#fff'
    }
  }
}%%

flowchart LR;
    accTitle: DefaultAzureCredential authentication flow without deployed service credentials;
    accDescr: Flowchart showing the credential chain implemented by DefaultAzureCredential when AZURE_TOKEN_CREDENTIALS is set to "dev";

    D(Visual Studio):::developer -->
    E(Visual Studio Code):::developer -->
    F(Azure CLI):::developer -->
    G(Azure PowerShell):::developer -->
    H(Azure Developer CLI):::developer -->
    J(Broker):::developer;

    %% Define styles for credential type boxes
    classDef developer fill:#F5AF6F, stroke:#EB7C39, stroke-width:2px;
```
