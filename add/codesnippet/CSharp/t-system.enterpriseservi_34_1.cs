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

        // Create a shared property group manager.
        SharedPropertyGroupManager groupManager = new SharedPropertyGroupManager();
        // Create a shared property group.
        SharedPropertyGroup group = groupManager.CreatePropertyGroup("Receipts",
                                   ref lockMode, ref releaseMode, out groupExists);
        // Create a shared property.
        SharedProperty ReceiptNumber;
        ReceiptNumber = group.CreateProperty("ReceiptNumber",out propertyExists);
        // Retrieve the value from shared property, and increment the shared 
        // property value.
        nextReceiptNumber = (int) ReceiptNumber.Value;
        ReceiptNumber.Value = nextReceiptNumber + 1;
        // Return nextReceiptNumber
        return nextReceiptNumber;
            
    }
}