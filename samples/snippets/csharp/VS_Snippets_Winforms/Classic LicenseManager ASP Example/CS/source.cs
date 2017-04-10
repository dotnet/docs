// <snippet1>
using System;
using System.ComponentModel;
using System.Web.UI;

// Adds the LicenseProviderAttribute to the control.
public class MyServerControl : Control 
{
    // Creates a new, null license.
    private License license = null;

    public MyServerControl() 
    {
        // Adds Validate to the control's constructor.
        license = LicenseManager.Validate(typeof(MyServerControl), this);

        // Insert code to perform other instance creation tasks here.
    }

    public override void Dispose() 
    {      
        if (license != null) 
        {
            license.Dispose();
            license = null;
        }

        base.Dispose();
    }    
}
// </snippet1>