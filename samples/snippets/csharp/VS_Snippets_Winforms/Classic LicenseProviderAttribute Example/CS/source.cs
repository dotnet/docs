using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Class1{
    // <Snippet1>
    [LicenseProvider(typeof(LicFileLicenseProvider))]
     public class MyControl : Control {
     
        // Insert code here.
     
        protected override void Dispose(bool disposing) {
           /* All components must dispose of the licenses they grant. 
            * Insert code here to dispose of the license. */
        }
     }
    // </Snippet1>
    // <Snippet2>
    public static int Main() {
        // Creates a new component.
        MyControl myNewControl = new MyControl();
     
        // Gets the attributes for the component.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewControl);
     
        /* Prints the name of the license provider by retrieving the LicenseProviderAttribute 
         * from the AttributeCollection. */
        LicenseProviderAttribute myAttribute = (LicenseProviderAttribute)attributes[typeof(LicenseProviderAttribute)];
        Console.WriteLine("The license provider for this class is: " + myAttribute.LicenseProvider.ToString());
     
        return 0;
     }
    // </Snippet2>
}
