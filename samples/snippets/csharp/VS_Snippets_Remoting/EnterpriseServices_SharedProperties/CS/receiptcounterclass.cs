// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;


[assembly: ApplicationName("ReceiptNumberGenerator")] 
[assembly: ApplicationActivation(ActivationOption.Library)] 

public class ReceiptNumberGeneratorClass
{
    // Generates a new receipt number based on the receipt number
    // stored by the Shared Property Manager (SPM)
    public int GetNextReceiptNumber() 
    {
        bool groupExists,propertyExists;
        int nextReceiptNumber = 0;
        PropertyLockMode lockMode = PropertyLockMode.SetGet;
        PropertyReleaseMode releaseMode = PropertyReleaseMode.Standard;

// <snippet1>
        // Create a shared property group manager.
        SharedPropertyGroupManager groupManager = new SharedPropertyGroupManager();
// </snippet1>
// <snippet21>
// <snippet2>
        // Create a shared property group.
        SharedPropertyGroup group = groupManager.CreatePropertyGroup("Receipts",
                                   ref lockMode, ref releaseMode, out groupExists);
// </snippet2>
        // Create a shared property.
        SharedProperty ReceiptNumber;
        ReceiptNumber = group.CreateProperty("ReceiptNumber",out propertyExists);
// </snippet21>
// <snippet3>
        // Retrieve the value from shared property, and increment the shared 
        // property value.
        nextReceiptNumber = (int) ReceiptNumber.Value;
        ReceiptNumber.Value = nextReceiptNumber + 1;
// </snippet3>
        // Return nextReceiptNumber
        return nextReceiptNumber;
            
    }
}
// </snippet0>

