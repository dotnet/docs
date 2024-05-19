### Create a GitHub secret

GitHub provides a mechanism for creating encrypted secrets. The secrets that you create are available to use in GitHub Actions workflows. You're going to see how GitHub Actions can be used to automate the deployment of the app, in conjunction with Azure :::no-loc text="Bicep":::. :::no-loc text="Bicep"::: is a domain-specific language (DSL) that uses a declarative syntax to deploy Azure resources. For more information, see [What is Bicep](/azure/azure-resource-manager/bicep/overview?tabs=bicep). Using the output from the [Create a service principal](#create-a-service-principal) step, you'll need to create a GitHub secret named `AZURE_CREDENTIALS` with the JSON-formatted credentials.

Within the GitHub repository, select **Settings** > **Secrets** > **Create a new secret**. Enter the name `AZURE_CREDENTIALS` and paste the JSON credentials from the previous step into the **Value** field.

:::image type="content" source="../../media/github-secret.png" alt-text="GitHub Repository: Settings > Secrets" lightbox="../../media/github-secret.png":::

For more information, see [GitHub: Encrypted Secrets](https://docs.github.com/actions/security-guides/encrypted-secrets).
