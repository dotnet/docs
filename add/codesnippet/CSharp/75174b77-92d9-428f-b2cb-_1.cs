        // Create a shared property group.
        SharedPropertyGroup group = groupManager.CreatePropertyGroup("Receipts",
                                   ref lockMode, ref releaseMode, out groupExists);
        // Create a shared property.
        SharedProperty ReceiptNumber;
        ReceiptNumber = group.CreateProperty("ReceiptNumber",out propertyExists);