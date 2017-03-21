// The following class is an example of code that exposes 
// external process management.
// Add the LicenseProviderAttribute to the control.
[LicenseProvider (typeof(LicFileLicenseProvider))]
public class MyControl : System.Windows.Forms.Control
{
    // Create a new, null license.
    private License license = null;

    [HostProtection (ExternalProcessMgmt = true)]
    public MyControl ()
    {
        // Determine if a valid license can be granted.
        bool isValid = LicenseManager.IsValid (typeof(MyControl));
        Console.WriteLine ("The result of the IsValid method call is " + 
            isValid.ToString ());
    }

    protected override void Dispose (bool disposing)
    {
        if (disposing)
        {
            if (license != null)
            {
                license.Dispose ();
                license = null;
            }
        }
    }
}