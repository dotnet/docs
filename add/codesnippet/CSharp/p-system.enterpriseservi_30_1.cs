        // Retrieve the value from shared property, and increment the shared 
        // property value.
        nextReceiptNumber = (int) ReceiptNumber.Value;
        ReceiptNumber.Value = nextReceiptNumber + 1;