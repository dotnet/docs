---
ms.topic: include
ms.date: 07/31/2024
ms.custom: devx-track-azurecli
---
#### [Azure App Service](#tab/azure-app-service)

```azurecli
az webapp identity assign \
    --resource-group <resource-group-name> \
    --name <web-app-name>
```

#### [Azure Virtual Machines](#tab/azure-virtual-machines)

```azurecli
az vm identity assign \
    --resource-group <resource-group-name> \
    --name <virtual-machine-name>
```

---
