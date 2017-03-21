      // Create a shared property group.
      SharedPropertyGroup^ group =
         groupManager->CreatePropertyGroup( "Receipts",  lockMode,  releaseMode,  groupExists );

      // Create a shared property.
      SharedProperty^ ReceiptNumber;
      ReceiptNumber = group->CreateProperty( "ReceiptNumber",  propertyExists );