        ' Create a shared property group.
        Dim group As SharedPropertyGroup = groupManager.CreatePropertyGroup("Receipts", lockMode, releaseMode, groupExists)
        ' Create a shared property.
        Dim ReceiptNumber As SharedProperty
        ReceiptNumber = group.CreateProperty("ReceiptNumber", propertyExists)